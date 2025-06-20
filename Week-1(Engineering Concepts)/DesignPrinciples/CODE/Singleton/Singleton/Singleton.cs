using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                    return _instance;
                }
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var logger1 = Logger.Instance;
            var logger2 = Logger.Instance;

            logger1.Log("Logging from logger1");
            logger2.Log("Logging from logger2");

            Console.WriteLine($"Same instance? {logger1 == logger2}");
        }
    }
}