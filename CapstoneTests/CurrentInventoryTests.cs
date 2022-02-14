using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CurrentInventoryTests
    {
        [TestMethod]
        public void Current_Inventory_check()
        {
            VendingMachine sut = new VendingMachine();

            sut.CurrentInventory();

        }



    }
}
