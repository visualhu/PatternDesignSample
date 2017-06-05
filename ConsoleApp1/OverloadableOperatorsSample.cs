using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OOSeason
    {
        public static readonly string[] Seasons = new string[] { "Spring", "Summer", "Autumn", "Winter" };
        int current;
        public OOSeason()
        {
            current = default(int);
        }

        public override string ToString()
        {
            return Seasons[current];
        }

        public static OOSeason operator ++(OOSeason season)
        {
            season.current = (season.current + 1) % 4;
            return season;
        }


        //!!!
        public static implicit operator string(OOSeason season)
        {
            return season.ToString();
        }
    }


    public class ErrorEntity
    {
        IList<string> messages = new List<string>();
        public static ErrorEntity operator + (ErrorEntity entity,string message)
        {
            entity.messages.Add(message);
            return entity;
        }

        public IList<string> Messages { get { return messages; } }
    }
}
