using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Products
{
    public class Candy : Product
    {

        public Candy(string name, decimal price) : base(name, price)
        {

        }
        public override string ItemMessage()
        {
            return "Munch Munch, Yum!";
        }

    }
}
