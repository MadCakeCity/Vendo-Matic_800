using Capstone.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;



namespace Capstone
    {
        public class VendingMachine
        {
            public Dictionary<string, Product> Inventory { get; } = new Dictionary<string, Product>();

            public decimal Balance { get; private set; } = 0.00M;    //let's see where else we need to change this to have 2 decimal places and 'M'

            public string SlotID { get; set; }    // new change

            public VendingMachine()
            {

                //buildInventory();        
                // taking this out. will call on it manually.
              

                //new inventory dictionary for (slotID and product)

                //Inventory = new Dictionary<string, Product>();    // look up above

                //string directory = Environment.CurrentDirectory;
                // string file = filePath;
                //string fullPath = Path.Combine(directory,filePath);
                //Read the input file and sort the products by type


            }

            public void buildInventory()
            {
                string filePath = @"C:\Users\Student\workspace\c-sharp-mini-capstone-module-1-team-1\vendingmachine.csv";
                // probably want to copy this file to the environment directory so that anyone downloading the code will easily access the file


                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            Product newProduct = null;   // this is going to reset as null every loop iteration
                            string line = sr.ReadLine();
                            //List<string> pipes = new List<string>();
                            //requires using System.Linq
                            //pipes = line.Split('|').ToList();
                            string[] pipes = line.Split("|");


                            string typeOfProduct = pipes[3];
                            SlotID = pipes[0];   // new change

                            if (typeOfProduct.Contains("Candy"))
                            {
                                newProduct = new Candy(pipes[1], decimal.Parse(pipes[2]));
                            }
                            else if (typeOfProduct.Contains("Chip"))
                            {
                                newProduct = new Chip(pipes[1], decimal.Parse(pipes[2]));
                            }
                            else if (typeOfProduct.Contains("Gum"))
                            {
                                newProduct = new Gum(pipes[1], decimal.Parse(pipes[2]));
                            }
                            else if (typeOfProduct.Contains("Drink"))
                            {
                                newProduct = new Drink(pipes[1], decimal.Parse(pipes[2]));
                            }
                            Inventory.Add(SlotID, newProduct);

                            // below is just for debugging purposes
                            //Console.WriteLine($"{PurchaseCode}: \n{Inventory[pipes[0]].Name} \nPrice: ${Inventory[pipes[0]].Price} \nQuantity Available: {Inventory[pipes[0]].Inv}\n");   //Inv needs to say SOLD OUT when applicable

                            // below is just for debugging purposes
                            //Console.WriteLine(newProduct.ItemMessage());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The Inventory data could not be aquired! The VENDO-MATIC 800 will shut down now!");
                    Thread.Sleep(4000);
                    Environment.Exit(0);

                }


            }
        
            public void CurrentInventory()
            {
                // build a for loop

                foreach (KeyValuePair<string, Product> entry in Inventory)
                {
                    if (entry.Value.Inv == 0)
                    {
                        Console.WriteLine($"{entry.Key}: \n{entry.Value.Name} \nPrice: ${entry.Value.Price} \nITEM SOLD OUT!\n");
                    }
                
                    else
                    {
                        Console.WriteLine($"{entry.Key}: \n{entry.Value.Name} \nPrice: ${entry.Value.Price} \nQuantity Available: {entry.Value.Inv}\n");   //Inv needs to say SOLD OUT when applicable
                    }
                    

                
                }


                //Console.WriteLine($"{pipes[0]}: \n{Inventory[pipes[0]].Name} \nPrice: ${Inventory[pipes[0]].Price} \nQuantity Available: {Inventory[pipes[0]].Inv}\n");   //Inv needs to say SOLD OUT when applicable
            }


            //"(1) Feed Money" allows the customer to
            //repeatedly feed money into the machine in valid, whole dollar amounts
            public void FeedMoney(decimal money)
            {
    
                Balance += money;    
                Log.Log.VendLog("FEED MONEY :", money , Balance);

                    //accepts on 1s 2s 5s 10s

            }
            //"(2) Select Product" allows the customer to select a product to purchase.
            public void SelectProduct(string slotID)
            {
                
                

                SlotID = slotID;
                decimal startBal = Balance;

                Balance -= Inventory[slotID].Price;   // might want to make this startBal instead of Balance???
                            
            
                Inventory[slotID].VendItem();
                Log.Log.VendLog(Inventory[slotID].Name, startBal, Balance);  // moved this up here

            }

            


            public void FinishTransaction()    //changing to void becuase the Console.WriteLine will give me the returned message from the Change class' ChangeReturn method   // public Change FinishTransaction()
        {
                decimal startBal = Balance;
                //give the customer change once change class is complete
                Change change = new Change();

                Console.WriteLine(change.ChangeReturn(Balance));
                //change.ChangeReturn(Balance);
                Balance = 0.00M;

                Console.WriteLine($"\nCurrent Money Provided: {Balance}");

                Log.Log.VendLog("GIVE CHANGE :", startBal, Balance);

                //return change;
            
            }


        }

    }

/*A1|Potato Crisps|3.05|Chip
A2|Stackers|1.45|Chip
A3|Grain Waves|2.75|Chip
A4|Cloud Popcorn|3.65|Chip
B1|Moonpie|1.80|Candy
B2|Cowtales|1.50|Candy
B3|Wonka Bar|1.50|Candy
B4|Crunchie|1.75|Candy
C1|Cola|1.25|Drink
C2|Dr. Salt|1.50|Drink
C3|Mountain Melter|1.50|Drink
C4|Heavy|1.50|Drink
D1|U-Chews|0.85|Gum
D2|Little League Chew|0.95|Gum
D3|Chiclets|0.75|Gum
D4|Triplemint|0.75|Gum*/