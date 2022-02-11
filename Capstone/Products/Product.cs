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
            Inv = 5;

        }
        public void VendItem()
        {
            if(Inv > 0)
            {
                Inv--;
            }
            else
            {
                //out of stock
            }
        }
        public abstract string ItemMessage();
    }
}
