using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
   public  class SeasonFixture
    {
        [TestMethod]
        public void TestSeasonIterator()
        {
            var season = new OOSeason();

            Assert.AreEqual<string>(OOSeason.Seasons[0], season);
            Trace.WriteLine(season);

            season++;
            season++;

            Assert.AreEqual<string>(OOSeason.Seasons[2], season);
            Trace.WriteLine(season);
        }
    }


    [TestClass]
    public class ErrorEntityFixture
    {
        [TestMethod]
        public void ErrorEntityTest()
        {
            var entity=new ErrorEntity();
            entity += "Username must be required.";
            entity += "Titile must be required.";
            entity += "Domain must be required.";

            Assert.AreEqual<int>(3, entity.Messages.Count);
            Trace.WriteLine(string.Join("\n", entity.Messages));
        }
    }
}
