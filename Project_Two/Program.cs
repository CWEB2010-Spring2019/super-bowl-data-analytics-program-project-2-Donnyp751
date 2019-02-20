using System;
using System.Collections.Generic;
using System.Globalization;
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
                catch(Exception e)
                {
                    //eat exceptions from entry that failed to load.
                    Console.WriteLine("Failed to load : "+entry + " "+ e.Message);
                }
            }


            Console.WriteLine("Press t for text file, or h for html");
            char key;
            bool selected;
            do
            {
                key = Console.ReadKey().KeyChar;
                selected = (key != 't' || key != 'h');
                if(!selected)
                    Console.WriteLine("INVALID CHOICE");
            } while (!selected);

            Console.WriteLine("Enter file name");
            string outputFileName = Console.ReadLine();

            //entries.ForEach(entry => Console.WriteLine(entry.ToString()));

            var SuperBowlSorter = new SuperBowlQuery(entries);

            


        }
    }
}
