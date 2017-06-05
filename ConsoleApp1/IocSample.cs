using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ITimeProvider
    {
        DateTime CurrentDate { get; }
    }

    public class SystemTimeProvider:ITimeProvider
    {
        public DateTime CurrentDate
        {
          get { return DateTime.Now; }
        }
    }

    public class Assembler
    {
        static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();
        static Assembler()
        {
            dictionary.Add(typeof(ITimeProvider), typeof(SystemTimeProvider));
        }

        public object Create(Type type)
        {
            if (type == null || !dictionary.ContainsKey(type))
            {
                throw new NullReferenceException();
            }

            return Activator.CreateInstance(dictionary[type]);
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
    }


    public class Client
    {
        ITimeProvider timeProvider;
        public Client(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }


        public ITimeProvider TimeProvider
        {
            get;set;
        }
    }

    public interface IObjectWithTimeProvider
    {
        ITimeProvider TimeProvider { get; set; }
    }

    public class ObjectClass : IObjectWithTimeProvider
    {
        public ITimeProvider TimeProvider { get; set; }
    }
 
}
