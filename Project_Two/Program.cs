using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/

            string fileName = @"..\..\..\..\Super_Bowl_Project.csv";

            List<string> rawData = File.ReadAllText(fileName).Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<SuperBowlEntry> entries = new List<SuperBowlEntry>();
            foreach (string entry in rawData)
            {
                try
                {
                    entries.Add(new SuperBowlEntry(entry));
                }
                catch
                {
                    //eat exceptions from entry that failed to load.
                }
            }
            entries.ForEach(entry => Console.WriteLine(entry.ToString()));
            
            Console.ReadKey();



        }
    }
}
