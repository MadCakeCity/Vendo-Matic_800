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
        

        public VendingMachine(string filePath)
        {
            Inventory = new Dictionary<string, Product>();

            string directory = Environment.CurrentDirectory;
            string file = filePath;
            string fullPath = Path.Combine(directory,file);

            try
            {
                using(StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        Product newProduct = null;
                        string line = sr.ReadLine();
                        string [] pipes = line.Split("|");
                        
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
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("");
            }
           
        }
        public void FeedMoney(decimal money)
        {
            if(money > 0)
            {
                Balance += money;

            }
           
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