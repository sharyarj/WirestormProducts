using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WirestormProducts.DAL;

namespace WirestormProducts.Models
{
    public class ProductListModel
    {
        public List<Product> List { get; set; }
    }

    public class ProductViewModel
    { 
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public List<ProductComment> Comments { get; set; }
    }

    public class ProductAddUpdateModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.1, 999999, ErrorMessage = "Please enter a value greater than 0 and less than 99999")]
        public double Price { get; set; }

    }


}