namespace Singleton
{
    public  class Logger
    {
        private static readonly Lazy<Logger> _lazyLogger = new(() => new Logger());

        protected Logger()
        {
        }

        public static Logger Instance => _lazyLogger.Value;
        

        public void Log(string message)
        {
            Console.WriteLine($"Message to log: {message}");
        }
    }
  
}
