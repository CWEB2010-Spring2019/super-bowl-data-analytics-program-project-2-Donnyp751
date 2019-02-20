using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Project_Two
{
    class SuperBowlQuery
    {
        private List<SuperBowlEntry> Entries;
        public SuperBowlQuery(List<SuperBowlEntry> entries)
        {
            Entries = entries;
        }

        public void Categorize()
        {

        }

        public bool WriteHTMLFile(string fileName)
        {

            return false;
        }
        public bool WriteTXTFile(string fileName)
        {

            return false;
        }
    }
}
