using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WirestormProducts.Models;
using WirestormProducts.DAL;

namespace WirestormProducts.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Will only get the form to add product
        /// </summary>
        /// <returns></returns>
        public ActionResult Products()
        {
            ProductAddUpdateModel model = new ProductAddUpdateModel();
            return View(model);
        }

        /// <summary>
        /// To get All Products in partial view
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductList()
        {
            ProductListModel model = new ProductListModel();
            model.List = ProductDAL.getProducts();

            return PartialView("ProductList", model);
        }

        /// <summary>
        /// Will add product with Ajax post from client side
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        public JsonResult ProductAdd(string Name, string Description, double Price)
        {
            Product p = new Product();
            p.Name = Name.Trim();
            p.Description = Description.Trim();
            p.Price = Price;
            ProductDAL.addProduct(p);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// to get partial view to view the product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public ActionResult ViewProduct(int ProductID)
        {
            ProductViewModel model = new ProductViewModel();
            Product p = ProductDAL.getProductByID(ProductID);

            model.Description = p.Description;
            model.Name = p.Name;
            model.Price = p.Price;
            model.ProductID = p.ProductID;
            model.Comments = p.Comments;

            return PartialView("ViewProduct", model);
        }

        /// <summary>
        /// Will add comment on selected product with Ajax post from client side
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="CommentText"></param>
        /// <returns></returns>
        public JsonResult CommentAdd(int ProductID, string CommentText)
        {
            ProductComment pc = new ProductComment()
            {
                Comment = (CommentText + "").Trim(),
                ProductID = ProductID
            };

            ProductDAL.addComment(pc);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
 