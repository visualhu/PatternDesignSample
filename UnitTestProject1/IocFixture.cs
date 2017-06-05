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
    public class TimeClientFixture
    {
        [TestMethod]
        public void TimeClientTest()
        {
            ITimeProvider timeProvider = (new Assembler()).Create<ITimeProvider>();
            Assert.IsNotNull(timeProvider);
            Client client = new Client(timeProvider);
        }
    }
}
