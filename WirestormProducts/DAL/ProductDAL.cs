using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WirestormProducts.Models;

namespace WirestormProducts.DAL
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public List<ProductComment> Comments { get; set; }
    }

    public class ProductComment
    {
        public int ProductID { get; set; }
        public string Comment { get; set; }
    }

    public static class ProductDAL
    {

        private static List<ProductComment> storeComments(int productID)
        {
            try
            {
                List<ProductComment> result = new List<ProductComment>();
                result.Add(new ProductComment() { ProductID = productID, Comment = "Good!" });
                result.Add(new ProductComment() { ProductID = productID, Comment = "How much?" });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Product> getProducts()
        {
            try
            {
                List<Product> result = new List<Product>();

                if ((SessionManager.ProductList == null ? 0 : SessionManager.ProductList.Count) > 0)
                {
                    result = SessionManager.ProductList;
                }
                else
                {
                    result.Add(new Product
                    {
                        Name = "HP Laptop",
                        Description = "15 inches screen",
                        Price = 100,
                        ProductID = 1,
                        Comments = storeComments(1)
                    });

                    result.Add(new Product
                    {
                        Name = "Dell Laptop",
                        Description = "Backlit keyboard",
                        Price = 101,
                        ProductID = 2,
                        Comments = storeComments(2)
                    });


                    result.Add(new Product
                    {
                        Name = "Asus Laptop",
                        Description = "10 inches screen",
                        Price = 200,
                        ProductID = 3,
                        Comments = storeComments(3)
                    });

                    SessionManager.ProductList = result;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void addProduct(Product product)
        {
            try
            {
                List<Product> list = SessionManager.ProductList;

                product.ProductID = list.Count + 1;

                list.Add(product);

                SessionManager.ProductList = list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void addComment(ProductComment productComment)
        {
            try
            {
                List<Product> list = SessionManager.ProductList;

                List<ProductComment> pcList = list.Where(x => x.ProductID == productComment.ProductID).FirstOrDefault().Comments;

                if (pcList == null)
                {
                    pcList = new List<ProductComment>();
                    pcList.Add(productComment);

                    list.Where(x => x.ProductID == productComment.ProductID).FirstOrDefault().Comments = pcList;

                }
                else
                {
                    list.Where(x => x.ProductID == productComment.ProductID).FirstOrDefault().Comments.Add(productComment);
                }


                SessionManager.ProductList = list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Product getProductByID(int ProductID)
        {
            return SessionManager.ProductList.Where(x => x.ProductID == ProductID).FirstOrDefault();
        }

    }
}