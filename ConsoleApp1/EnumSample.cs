using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum Season
    {
        Sprint,
        Summer,
        Autumn,
        Winter
    }

    public class SeasonCalendar
    {
        static Dictionary<Season, SeasonMonthEntry> monthLookup = new Dictionary<Season, SeasonMonthEntry>();

        struct SeasonMonthEntry
        {
            public Season Season { get; set; }
            public int StartMonth { get; set; }
            public int EndMonth { get; set; }
            public string Note { get; set; }
        }

        static SeasonCalendar()
        {
            monthLookup.Add(Season.Sprint, new SeasonMonthEntry()
            {
                Season = Season.Sprint,
                StartMonth = 1,
                EndMonth = 3,
                Note = "Some beautiful words."
            });
            monthLookup.Add(Season.Summer, new SeasonMonthEntry()
            {
                Season = Season.Summer,
                StartMonth = 4,
                EndMonth = 6,
                Note = "Some beautiful words."
            });
            monthLookup.Add(Season.Autumn, new SeasonMonthEntry()
            {
                Season = Season.Autumn,
                StartMonth = 7,
                EndMonth = 9,
                Note = "Some beautiful words."
            });
            monthLookup.Add(Season.Winter, new SeasonMonthEntry()
            {
                Season = Season.Winter,
                StartMonth = 10,
                EndMonth = 12,
                Note = "Some beautiful words."
            });
        }

        SeasonMonthEntry entry;

        public SeasonCalendar(Season season)
        {
            if (season == null)
                throw new ArgumentNullException("season");
            entry = monthLookup[season];

        }

        public Season Season { get { return entry.Season; } }
        public int StartMonth { get { return entry.StartMonth; } }
        public int EndMonth { get { return entry.EndMonth; } }
        public string Note { get { return entry.Note; } }

        public static Season GetSeason(int month)
        {
            if(month>12 || month < 1)
            {
                throw new NotSupportedException();
            }

            int startMonth = ((month - 1) / 3) * 3 + 1;

            return monthLookup.Values.FirstOrDefault(x => x.StartMonth == startMonth).Season;
        }
    }



}
