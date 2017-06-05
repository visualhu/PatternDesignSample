using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

        //const string Mark = "technical";
        [AttributeUsage(AttributeTargets.Method,AllowMultiple =true)]
        public class CategoryAttribute : Attribute
        {
            public string Name { get; private set; }
            public CategoryAttribute(string name)
            {
                Name = name;
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public class XAttribute : Attribute
        {

        }
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public class YAttribute : Attribute
        {

        }

    public class A
    {
        const string Mark = "technical";
        [Category(Mark)]
        [Category("M1")]
        [X]
        public int M1()
        {
            return 0;
        }


        [Category("M2")]
        [X]
        [Y]
        public int M2()
        {
            return -1;
        }

        [Category(Mark)]
        public void M3(int a,int b)
        {
        }

        [Category(Mark)]
        [Category(Mark)]
        [Category("M4")]
        [X]
        public int M4(int a,int b)
        {
            return 0;
        }
    }
}
