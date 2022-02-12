using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Products
{
    public abstract class Product
    {
        public string Name { get; }
        public decimal Price { get; }

        public int Inv { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
            //Inv = 5;

            //Only for testing purposes:
            Inv = 2;

        }
        public void VendItem()
        {
            Inv--;
        }

        public abstract string ItemMessage();
    }
}
