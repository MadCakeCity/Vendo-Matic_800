using Capstone.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        public Dictionary<string,Product> Inventory { get; }

        public decimal Balance { get; private set; } = 0;
        public string PurchaseCode { get; set; }
        

        public VendingMachine(string filePath)
        {
            //new inventory dictionary for (slotID and product)
            Inventory = new Dictionary<string, Product>();

            string directory = @"C:\Users\Student\workspace\c-sharp-mini-capstone-module-1-team-1";
            string file = filePath;
            string fullPath = Path.Combine(directory,file);
            //Read the input file and sort the products by type
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        Product newProduct = null;
                        string line = sr.ReadLine();
                        string[] pipes = line.Split("|");
                        //split the input flie by line
                        string typeOfProduct = pipes[3];


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
                        Inventory.Add(pipes[0], newProduct);



                    
                        Console.WriteLine($"{PurchaseCode}: \n{Inventory[pipes[0]].Name} \nPrice: ${Inventory[pipes[0]].Price} \nQuantity Available: {Inventory[pipes[0]].Inv}\n");   //Inv needs to say SOLD OUT when applicable
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        public void CurrentInventory()
        {
            // build a for loop

            foreach (KeyValuePair<string, Product> entry in Inventory)
            {
                Console.WriteLine($"{PurchaseCode}: \n{Inventory[PurchaseCode].Name} \nPrice: ${Inventory[PurchaseCode].Price} \nQuantity Available: {Inventory[PurchaseCode].Inv}\n");   //Inv needs to say SOLD OUT when applicable
            }


            //Console.WriteLine($"{pipes[0]}: \n{Inventory[pipes[0]].Name} \nPrice: ${Inventory[pipes[0]].Price} \nQuantity Available: {Inventory[pipes[0]].Inv}\n");   //Inv needs to say SOLD OUT when applicable
        }
        //"(1) Feed Money" allows the customer to
        //repeatedly feed money into the machine in valid, whole dollar amounts
        public void FeedMoney(decimal money)
        {
            if(money > 0)
            {
                Balance += money;
                
            }
           
        }
        //"(2) Select Product" allows the customer to select a product to purchase.
        public void SelectProduct(string slotID)
        {
            if (Balance > 0)
            {

                if (Inventory.ContainsKey(slotID))
                {
                    Inventory[slotID].VendItem();


                    Balance -= Inventory[slotID].Price;
                }
            }
        }
        //(3) Finish Transaction" allows the
        //customer to complete the transaction and receive any remaining change
        public Change FinishTransaction()
        {
            //give the customer change once change class is complete


            Change change = new Change();

            change.ChangeReturn(Balance);

            return change;
        }
        //Finish Transaction....
       
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