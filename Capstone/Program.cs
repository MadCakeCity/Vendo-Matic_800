using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //input file for reading in VendingMachine
            //VendingMachine vm = new VendingMachine();
            //Log.Log.VendLog("TESTLOG YO", 1.00M, 1.00M);//Log Test REMOVE 
            Menu menu = new Menu();
            menu.MainMenu();
            //vm.FeedMoney(3); 
            //vm.SelectProduct("A1");//Test for 2
            //vm.FinishTransaction();//Test for 3
        }
    }
}
