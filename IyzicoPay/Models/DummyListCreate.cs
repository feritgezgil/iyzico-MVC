using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace IyzicoPay.Models
{
    public class DummyListCreate
    {
        public List<Product> GetProductList()
        {
            List<Product> myList = new List<Product>()
            { 
                new Product()
                {
                    ProductCode = "PR00001",
                    Name = "Product Name 1",
                    Category = "Computer",
                    SubCategory = "Desktop",
                    Price = 12.99
                },
                new Product()
                {
                    ProductCode = "PR00002",
                    Name = "Product Name 2",
                    Category = "Computer",
                    SubCategory = "Desktop",
                    Price = 34.99
                },
                new Product()
                {
                    ProductCode = "PR00003",
                    Name = "Product Name 3",
                    Category = "Computer",
                    SubCategory = "Desktop",
                    Price = 8.99
                },
                new Product()
                {
                    ProductCode = "PR00004",
                    Name = "Product Name 4",
                    Category = "Computer",
                    SubCategory = "Desktop",
                    Price = 11.99
                }
            };
     

            return myList;
        }
    }
}