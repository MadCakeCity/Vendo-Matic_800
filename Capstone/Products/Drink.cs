using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Products
{
    public class Drink : Product
    {
        public Drink(string name, decimal price) : base(name, price)
        {

        }
        public override string ItemMessage()
        {
            return "Glug Glug, Yum!";
        }
    }
}
