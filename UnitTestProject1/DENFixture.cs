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
   public class DENFixture
    {
        [TestMethod]
        public void AddCounter()
        {
            var logger = new InstrumentLogger();
            var counter = new Counter()
                .Register(logger)
                .Register(new RuleEngine())
                .Register(new InstrumentWindowUI());

            Trace.WriteLine("---------------------1--------------------");
            counter++;
            counter++;
            counter++;

            Trace.WriteLine("---------------------2--------------------");
            counter.UnRegister(logger);
            counter++;
        }
    }
}
