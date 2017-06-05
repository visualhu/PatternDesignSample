using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Delegate,Event Sample
    /// </summary>
    public interface IInstrumentTarget
    {
        void Process(int newValue);
    }

    public class InstrumentLogger : IInstrumentTarget
    {
        public void Process(int newValue)
        {
            Trace.WriteLine("Log:" + newValue);
        }
    }

    public class RuleEngine : IInstrumentTarget
    {
        const int AlertValue = 3;
        public void Process(int newValue)
        {
            if (newValue > AlertValue)
            {
                Trace.WriteLine("Alert:" + newValue);
            }
        }
    }

    public class InstrumentWindowUI : IInstrumentTarget
    {
        public void Process(int newValue)
        {
            Trace.WriteLine("Display new value:" + newValue);
        }
    }

    public class Counter
    {
        int currentValue;
        List<IInstrumentTarget> instrumentTargets = new List<IInstrumentTarget>();
        public static Counter operator ++(Counter c1)
        {
            c1.currentValue++;
            c1.instrumentTargets.ForEach(x => x.Process(c1.currentValue));
            return c1;
        }

        public Counter Register(IInstrumentTarget target)
        {
            if (target == null)
                throw new ArgumentNullException();
            instrumentTargets.Add(target);
            return this;
        }

        public Counter UnRegister(IInstrumentTarget target)
        {
            if (target == null)
                throw new ArgumentNullException();

            instrumentTargets.Remove(target);
            return this;
        }




    }
}


