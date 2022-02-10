using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Products
{
    public class Chip : Product
    {
        public Chip(string name, decimal price) : base(name, price)
        {

        }
        public override string ItemMessage()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
