using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Products
{
    public class Gum : Product
    {
        public Gum(string name, decimal price) : base(name, price)
        {

        }
        public override string ItemMessage()
        {
            return "Chew Chew, Yum!";
        }
    }
}
