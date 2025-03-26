using System;

namespace DerivedInterface
{
	interface ILogger // based interface
	{
		void WriteLog(string message);
	}

	interface IFormattableLogger : ILogger // derived interface
	{
        void WriteLog(string format, params Object[] args);
    }

	class ConsoleLogger2 : IFormattableLogger // 상속받은 class는 public만 와야한다..
    {
		public void WriteLog(string message)
		{
			Console.WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
		}

        public void WriteLog(string format, params Object[] args)
        {
			string message = String.Format(format, args);
			Console.WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        }
    }

	class MainApp
	{
		static void Main(string[] args)
		{
            IFormattableLogger logger = new ConsoleLogger2();
			logger.WriteLog("The world is not flat.");
            logger.WriteLog($"{1} + {1} = {2}");
        }
	}
}
