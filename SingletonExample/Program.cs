using System;
using System.IO;

namespace SingletonPatternExample
{
    // Singleton Logger class
    public sealed class Logger
    {
        private static Logger _instance = null;
        private static readonly object _lock = new object();
        private string _logFilePath;

        // Private constructor to prevent direct instantiation
        private Logger()
        {
            // Log file path (can be any location you prefer)
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        }

        // Public static property to access the single instance
        public static Logger Instance
        {
            get
            {
                // Thread-safe double-check locking to ensure only one instance is created
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        // Method to log a message
        public void Log(string message)
        {
            string logMessage = $"{DateTime.Now}: {message}";
            Console.WriteLine(logMessage); // Output to the console
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine); // Append to log file
        }
    }

    // Example class using the Logger
    class Database
    {
        public void Connect()
        {
            Logger.Instance.Log("Database connected.");
        }
    }

    // Example class using the Logger
    class UserSession
    {
        public void StartSession(string userName)
        {
            Logger.Instance.Log($"User session started for {userName}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Using the singleton logger in different parts of the application
            Logger.Instance.Log("Application started.");

            Database db = new Database();
            db.Connect();

            UserSession session = new UserSession();
            session.StartSession("JohnDoe");

            Logger.Instance.Log("Application finished.");
        }
    }
}
