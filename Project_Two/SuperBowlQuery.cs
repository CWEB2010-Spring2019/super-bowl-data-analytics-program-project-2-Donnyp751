using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Project_Two
{
    class SuperBowlQuery
    {
        private List<SuperBowlEntry> Entries;
        private const int PlaceHolderWidth = 30;
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
            string outputText = "";
            outputText += FormatLine(PlaceHolderWidth*6, new []{"######Superbowl winners######"});

            outputText += FormatLine(PlaceHolderWidth, new string[] {"Team name", "year", "QB", "Coach", "MVP", "Point lead"});

            foreach (var superBowlEntry in Entries)
            {
                outputText += FormatLine(PlaceHolderWidth,
                    new[]
                    {
                        superBowlEntry.WinningTeam, superBowlEntry.Date.Year.ToString(),superBowlEntry.WinningQB, superBowlEntry.WinningCoach,
                        superBowlEntry.MVP, (superBowlEntry.WinningPoints - superBowlEntry.LosingPoints).ToString()
                    });
            }

            outputText += "\r\n\r\n";

            outputText += FormatLine(PlaceHolderWidth*6, new []{"######Top five attended######"});


            outputText += FormatLine(PlaceHolderWidth, new string[] {"Year", "Winning team", "Losing team", "City", "State", "Stadium"});

            var sortedByAttendanceEntries = Entries.OrderByDescending(entry => entry.Attendance).Take(5);

            foreach (var entry in sortedByAttendanceEntries)
            {
                
                outputText += FormatLine(PlaceHolderWidth,
                    new[]
                    {
                        entry.Date.Year.ToString(),entry.WinningTeam,entry.LosingTeam, entry.City,
                        entry.State, entry.Stadium
                    });
            }

            outputText += "\r\n\r\n";
            outputText += FormatLine(PlaceHolderWidth * 6, new[] { "######State that hosted the most Super Bowls######" });

            //var SuperBowlsSortedByMostInState = 
            SuperBowlEntry hostedMost = null;
            int mostHostedCount = -1;

            foreach (var entry in Entries)
            {
                if (Entries.Where(e => e.State == entry.State).Count() > mostHostedCount)
                {
                    hostedMost = entry;
                }
            }

            outputText += FormatLine(PlaceHolderWidth,
                new[]
                {
                    hostedMost.City,
                    hostedMost.State, hostedMost.Stadium
                });

            outputText += "\r\n\r\n";
            outputText += FormatLine(PlaceHolderWidth * 6, new[] { "######MVP's more then once######" });

            var MVPMoreThenOnce = Entries.Where(e => Entries.Where(z => z.MVP == e.MVP).Count() > 1).ToList();

            foreach (var mvp in MVPMoreThenOnce)
            {
                Console.Write(mvp.MVP);
            }

            File.WriteAllText(fileName, outputText);
            return false;
        }

        private string FormatLine(int placeHolderSpace, string[] columns)
        {
            string line = string.Empty;

            foreach (string s in columns)
            {
                line += BufferSegment(placeHolderSpace, s);
            }
            return line + "\r\n";
        }

        private string BufferSegment(int width, string text)
        {
            if (text.Length >= width)
            {
                return text;
            }else
            {
                string buf = "";
                for (int i = 0; i < (width - text.Length) / 2; i++)
                    buf += " ";
                if(text.Length % 2 == 0)
                    return buf + text + buf;
                else 
                    return buf + text + buf+" ";
            }
        }
    }
}
