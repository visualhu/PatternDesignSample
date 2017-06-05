using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RawGenericFactory<T>
    {
        public T Create(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                throw new ArgumentNullException("typeName");

            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }
    }

    interface IProduct
    {

    }

    class ConcreteProduct : IProduct
    {

    }

    interface IUser
    {

    }

    class ConcreteUserA : IUser
    {

    }

    public class RawGenericFactoryTest
    {
        public static void Run()
        {
            var typeName = typeof(ConcreteProduct).AssemblyQualifiedName;
            Console.WriteLine($"ConcreteProduct AssemblyQualifiedName:{typeName}");

            var product = new RawGenericFactory<IProduct>().Create(typeName);

            //var product1 = new RawGenericFactory<IProduct>().Create("ConcreteProduct"); // Error

            var user = new RawGenericFactory<IUser>().Create(typeof(ConcreteUserA).AssemblyQualifiedName);

            Console.WriteLine($"Type compare:{user.GetType() == typeof(ConcreteUserA)}");

        }
    }
}
