using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Capstone
{
    public class Menu
    {

        VendingMachine vm = new VendingMachine();

        public void MainMenu()
        {
            //VendingMachine vm = new VendingMachine();

            // figure out how to remove this one empty line at the top
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit\n");
            string selection = Console.ReadLine();
            Console.WriteLine("");

            while (!(selection.Equals("1") || selection.Equals("2") || selection.Equals("3")))
            {
                // nothing will happen
                // allows the user to keep entering other options
                // can add a message here if needed but was thinking might leave out a message for a Vending Machine?

                Console.Clear();
                MainMenu();
                selection = Console.ReadLine();
            }

            if (selection.Equals("1"))
            {
                //VendingMachine vm1 = new VendingMachine();
                Console.Clear();
                vm.CurrentInventory();
                Console.WriteLine("\n\n");
                MainMenu();
                selection = Console.ReadLine();
                // call on the class.method the shows the list of all items in the vending machine with remaining quanity.
            }
            else if (selection.Equals("2"))
            {
                // go to the Purchase submenu
                Console.Clear();
                PurchaseMenu();
                // do we want to keep the list of items above?
            }
            else if (selection.Equals("3"))
            {
                // exit out of the application
                Console.Clear();
                Console.WriteLine("You have exited the Vending Machine application!");
                Environment.Exit(0);
            }


        }


        public void PurchaseMenu()
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"\nCurrent Money Provided: ${vm.Balance}\n");     // have to get the balance to return to this string!!!
            string selection = Console.ReadLine();


            while (!(selection.Equals("1") || selection.Equals("2") || selection.Equals("3")))
            {
                // nothing will happen
                // allows the user to keep entering other options until they enter correct input
                // can add a message here if needed but was thinking might leave out a message for a Vending Machine?
                // maybe clear what was entered 

                Console.Clear();
                PurchaseMenu();
                selection = Console.ReadLine();


               /* selection = Console.ReadLine();
                Console.Clear();*/
            }

            if (selection.Equals("1"))    // Feeding money Menu
                
            {

                // call on the class.method that allows the user to feed money (The FeedMoney() method)
                // what should the console display during this??
                // maybe change the console to reflect "Feeding money" but keeping the balance at the bottom still?


                decimal money = (Decimal.Parse(FeedingMoneyMenu()));   // nesting the FeedingMoneyMenu in this argument because it returns a string for the decimal variable to parse
                vm.FeedMoney(money);

                Console.Clear();
                PurchaseMenu();




            }
            else if (selection.Equals("2"))
            {

                Console.WriteLine("");
                vm.CurrentInventory();   // need to make an if/else statement here to account for if the user doesn't choose to see the list at the beginning, then
                // build inventory here.  Need to build the inventory BEFORE accessing the menu.

                Console.Write("\n\nEnter Purchase Code: ");
                selection = Console.ReadLine();


                SelectProductMenu(selection);
                
                //vm.SelectProduct(selection);

                // Select Product
                // calls on method to show the list of available products(and their purchase code?) and allows customer to enter code
                // If product code doesn't exist, then inform customer and (Thread.Sleep(3000)) - equal to 3 seconds...before returning to Purchase Menu
                // If product is sold out, then inform customer and (Thread.Sleep(3000)) - equal to 3 seconds...before returning to Purchase Menu
                // NOTE: can't call the build inventory method because that will restock the VM

            }
            else if (selection.Equals("3"))
            {       
                // Finish Transaction
                // Customer's money is returned using nickels, dimes, quarters (smallest amount of coins possible)
                // Machine's current balance returns to 0
            }


        }


        public string FeedingMoneyMenu()
        {

            Console.Clear();
            Console.WriteLine("Please insert a valid bill [ $1 | $2 | $5 | $10 ]\n\n");
            Console.WriteLine($"\nCurrent Money Provided: ${vm.Balance}\n");
            Console.Write("Insert: ");
            string inputMoney = Console.ReadLine();

            while (!(inputMoney.Equals("1") || inputMoney.Equals("2") || inputMoney.Equals("5") || inputMoney.Equals("10")))
            {
                Console.Write("\n(Not a valid bill)");
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("Please insert a valid bill [ $1 | $2 | $5 | $10 ]\n\n");
                Console.WriteLine($"\nCurrent Money Provided: ${vm.Balance}\n");
                Console.Write("Insert: ");
                inputMoney = Console.ReadLine();

            }

            return inputMoney;

        }


        public void SelectProductMenu(string slotID)
        {
            //vm.SlotID = slotID;
            decimal startBal = vm.Balance;
            if (vm.Inventory.ContainsKey(slotID))
            {
                //vm.Inventory[slotID].VendItem();  //slotID

                if (vm.Inventory[slotID].Inv <= 0)
                {
                    Console.WriteLine("SORRY, THAT ITEM IS CURRENTLY OUT OF STOCK!");
                    Thread.Sleep(4000);
                    Console.Clear();
                    PurchaseMenu();    //then return to Purchase Menu
                }

                if (vm.Inventory[slotID].Inv > 0 && startBal < vm.Inventory[slotID].Price)
                {
                    Console.WriteLine($"\nInsufficient funds!\n{vm.Inventory[slotID].Name} is ${vm.Inventory[slotID].Price} | Current Balance: ${startBal}");
                    Thread.Sleep(5000);
                    Console.Clear();
                    PurchaseMenu();    //then return to Purchase Menu

                }
                    
                else
                {
                    // call on the SelectProduct method from VendingMachine class
                    vm.SelectProduct(slotID);
                    // print the message from the product here
                    Console.WriteLine(vm.Inventory[slotID].ItemMessage());
                    Thread.Sleep(3000);
                    Console.Clear();
                    PurchaseMenu();



                    /*vm.Balance -= vm.Inventory.[slotID].Price;   // might want to make this startBal instead of Balance???
                    vm.Inventory[slotID].VendItem();
                    Log.Log.VendLog(vm.Inventory[slotID].Name, startBal, vm.Balance);  // moved this up here*/
                }
            }
            else
            {
                Console.WriteLine("\n\n(Invalid Product Entered!)\n\n\n");   // then return to the Purchase menu
                Thread.Sleep(3000);
                Console.Clear();
                PurchaseMenu();

            }

        }

    }
}









