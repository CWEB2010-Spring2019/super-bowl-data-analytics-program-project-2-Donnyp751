using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Two
{
    class SuperBowlEntry
    {
        private static List<string> monthsLutList = new List<string>()
        {
            "Jan",
            "Feb"
        };
        public string WinningTeam { get; set; }
        public string WinningCoach { get; set; }
        public string WinningQB { get; set; }
        public DateTime Date { get; set; }
        public string SuperbowlNumerial { get; set; }
        public int Attendance { get; set; }
        public int WinningPoints { get; set; }
        public string LosingTeam { get; set; }
        public string LosingCoach { get; set; }
        public string LosingQB { get; set; }
        public int LosingPoints { get; set; }
        public string MVP { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        private string originalEntry;

        public SuperBowlEntry(string entryText)
        {
            this.originalEntry = entryText;
            string[] fields = entryText.Split(',');
            if (!(fields.Length >=15 && fields.Length <=16))
            {
                throw new Exception("INVALID ENTRY");
            }

            //this.date = fields[0];
            this.Date = convertToDateTime(fields[0]);
            this.SuperbowlNumerial = fields[1];
            this.Attendance = Convert.ToInt32(fields[2]);
            this.WinningQB = fields[3];
            this.WinningCoach = fields[4];
            this.WinningTeam = fields[5];
            this.WinningPoints = Convert.ToInt32(fields[6]);
            this.LosingQB = fields[7];
            this.LosingCoach = fields[8];
            this.LosingTeam = fields[9];
            this.LosingPoints = Convert.ToInt32(fields[10]);
            this.MVP = fields[11];
            this.Stadium = fields[12];
            this.City = fields[13];
            this.State = fields[14];

        }

        private DateTime convertToDateTime(string date)
        {
            string[] parts = date.Split('-');
            if(Convert.ToInt32(parts[2]) < 60) //There wasn't a superbowl before the 60's so it must be in the 2000's
            {
                parts[2] = "20" + parts[2];
            }
            return new DateTime(Convert.ToInt32(parts[2]), monthsLutList.IndexOf(parts[1])+1, Convert.ToInt32(parts[0]));
        }

        public override string ToString()
        {
            return this.originalEntry;
        }
    }

}

