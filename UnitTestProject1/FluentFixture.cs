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
    public class FluentFixture
    {
        [TestMethod]
        public void TestFluentInterface()
        {
            IDataFacade facade = new CollectionDataFacade();
            var currentRows = facade.ExecuteQuery(null).Count();

            facade.AddNewCurrency("CNY", "Renmingbing")
                .AddNewCurrency("USD", "USD")
                .AddNewCurrency("JPY", "JPY")
                .AddNewCurrency("HKD", "HKD")
                .AddNewCurrency("FRF", "FRF")
                .AddNewCurrency("GBP", "GBP");
            Assert.AreEqual<int>(currentRows + 6, facade.ExecuteQuery(null).Count());

            facade.AddNewCurrency("DW1", "Known1")
                .AddNewCurrency("DW2", "Known2")
                .AddNewCurrency("DW3", "Known3")
                .AddNewCurrency("DW4", "Known4")
                .AddNewCurrency("DW5", "Known5")
                .AddNewCurrency("DW6", "Known6");

            Assert.AreEqual<int>(6, facade.ExecuteQuery(p => p.Code.StartsWith("DW")).Count());
        }
    }
}
