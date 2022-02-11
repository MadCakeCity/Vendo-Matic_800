using System;
using System.Collections.Generic;
using System.Text;

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
                vm.buildInventory();
                MainMenu();
                // call on the class.method the shows the list of all items in the vending machine with remaining quanity.
            }
            else if (selection.Equals("2"))
            {
                // go to the Purchase submenu
                Console.Clear();
                PurchaseMenu();   // do we want to keep the list of items above?
            }
            else if (selection.Equals("3"))
            {
                // exit out of the application
                Console.Clear();
                Console.WriteLine("You have exited the Vending Machine application!");
                System.Environment.Exit(0);
            }


        }


        public void PurchaseMenu()
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("\nCurrent Money Provided: ");     // have to get the balance to return to this string!!!
            string selection = Console.ReadLine();


            while (!(selection.Equals("1") || selection.Equals("2") || selection.Equals("3")))
            {
                // nothing will happen
                // allows the user to keep entering other options until they enter correct input
                // can add a message here if needed but was thinking might leave out a message for a Vending Machine?
                // maybe clear what was entered 

                selection = Console.ReadLine();
                Console.Clear();
            }

            if (selection.Equals("1"))
            {
                // call on the class.method that allows the user to feed money (The FeedMoney() method)
                // what should the console display during this??
                // maybe change the console to reflect "Feeding money" but keeping the balance at the bottom still?

                //VendingMachine.FeedMoney();


            }
            else if (selection.Equals("2"))
            {

                vm.CurrentInventory();   // need to make an if/else statement here to account for if the user doesn't choose to see the list at the beginning, then
                // build inventory here.  Need to build the inventory BEFORE accessing the menu.



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



    }
}









