using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Log
{
    public class Log
    {
        static StreamWriter sw = null;
        public static void VendLog(string method, decimal costOfTransaction, decimal balance)
        {
            string directory = Environment.CurrentDirectory;
            DateTime dateTime = DateTime.Now;
            string month = dateTime.Month.ToString("00");
            string day = dateTime.Day.ToString("00");
            string filePath = $"log.txt";
            string fullPath = Path.Combine(directory, filePath);

       
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {


                    DateTime now = DateTime.Now;
                    sw.WriteLine($"{day}/{month}/{dateTime.Year.ToString()} {now} {method} : {costOfTransaction} {balance}");
                }

            }

            catch (Exception e)
            {
                
            }

        }
    }
}
