using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace Project_Two
{
 
    class Program
    {
        static private void LinqTesting(List<SuperBowlEntry> entries)
        {

            //var linqResult = from entry in entries where entry.Attendance > 90000 select entry;

            var linqResult = from groups in
                from entry in entries
                group entry by entry.LosingCoach
                orderby groups.Count() descending
                select groups;

            //var orderedResult = from groups in linqResult orderby groups.Count() descending select groups;
                                
            foreach (var result in linqResult)
            {
                Console.WriteLine(result.Key);
                foreach(var groups in result)
                    Console.WriteLine(groups.LosingCoach);
                Console.WriteLine("\n\n");
            }

            Console.WriteLine("\n\n\n\n");


            Console.WriteLine("\n\n\n\n");


            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/

            Console.WriteLine("Enter input file path, or press enter for default path");
            string inputFileName = Console.ReadLine();
            string outputFileName = @"..\..\..\..\Super_Bowl_Project_Output.txt";

            string fileName = @"..\..\..\..\Super_Bowl_Project.csv";

            if (File.Exists(inputFileName))
            {
                fileName = inputFileName;
            }

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

            //LinqTesting(entries);
            //return;
            
            /*
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
            */
            Console.WriteLine("Enter output file name");

            string OutFileName = Console.ReadLine();
            if (File.Exists(outputFileName))
            {
                //outputFileName = OutFileName;
                var SuperBowlSorter = new SuperBowlQuery(entries);

                SuperBowlSorter.WriteTXTFile(outputFileName);
            }
        }
    }
}
