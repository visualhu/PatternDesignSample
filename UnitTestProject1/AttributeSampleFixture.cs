using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class AttributeSampleFixture
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [Director(3, "BuildPartA")]
        [Director(2, "BuildPartB")]
        [Director(1, "BuildPartC")]
        class AttributeBuilder : IAttributeBuilder
        {
            IList<string> log = new List<string>();
            public IList<string> Log { get { return log; } }

            public void BuildPartA()
            {
                log.Add("A");
            }
            public void BuildPartB()
            {
                log.Add("B");
            }
            public void BuildPartC()
            {
                log.Add("C");
            }
        }

        [TestMethod]
        public void BuilAccordingToAttribute()
        {
            IAttributeBuilder builder = new AttributeBuilder();
            new Director().BuildUp(builder);

            Assert.AreEqual<string>("A", builder.Log[0]);
            Assert.AreEqual<string>("B", builder.Log[1]);
            Assert.AreEqual<string>("C", builder.Log[2]);
        }
    }
}
