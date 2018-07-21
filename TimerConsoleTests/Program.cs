using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimerImitation;

namespace TimerConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {            
            CountdownTimer timer = new CountdownTimer();
            List<AbstractTimeObserver> observers = new List<AbstractTimeObserver>
            {
                new FirstTimeObserver(),
                new SecondTimeObserver()
            };

            foreach (var o in observers)
            {
                o.Register(timer);
            }

            timer.SetTimer(5);

            observers[0].Unregister(timer);
            timer.SetTimer(5);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("All trigers:");
            foreach (var o in observers)
            {
                foreach (var obs in o.Triggers())
                {
                    Console.WriteLine(obs);
                }
            }
        }
    }
}
