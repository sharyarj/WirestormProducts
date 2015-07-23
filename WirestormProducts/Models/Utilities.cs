using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WirestormProducts.DAL;

namespace WirestormProducts.Models
{
    public class Utilities
    {



    }

    public class SessionManager
    {

        public static List<Product> ProductList
        {
            get
            {
                return (List<Product>)HttpContext.Current.Session["ProductList"];
            }
            set
            {
                HttpContext.Current.Session["ProductList"] = value;
            }
        }
    }
}