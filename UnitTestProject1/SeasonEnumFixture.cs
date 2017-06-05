using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
   public  class SeasonEnumFixture
    {
        [TestMethod]
        public void SeasonEnumTest()
        {
            var winter = new SeasonCalendar(Season.Winter);
            Assert.AreEqual<int>(10, winter.StartMonth);
            Assert.AreEqual<int>(12, winter.EndMonth);
            Assert.AreEqual<Season>(Season.Winter, SeasonCalendar.GetSeason(11));

        }
    }
}
