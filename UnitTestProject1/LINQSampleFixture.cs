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
    public class LINQSampleFixture
    {
        const string Mark = "technical";
        [TestMethod]
        public void LinqToQueryReflectionInfo()
        {
            (from method in typeof(A).GetMethods()
             where
             (from attribute in method.GetCustomAttributes(typeof(CategoryAttribute), false)
              .AsEnumerable().Cast<CategoryAttribute>()
              where string.Equals(Mark, attribute.Name)
              select attribute).Count() > 0 && (method.ReflectedType == typeof(int))
             select method.Name)
             .ToList().ForEach(x => Trace.WriteLine(x));
        }
    }
}
