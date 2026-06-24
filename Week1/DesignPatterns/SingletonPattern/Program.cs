using System;

public sealed class Logger
{
    private static Logger instance = null;

    private Logger()
    {
    }

    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine("[LOG]: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("First log message");
        logger2.Log("Second log message");

        if (logger1 == logger2)
        {
            Console.WriteLine("Singleton works! Both objects are the same.");
        }
        else
        {
            Console.WriteLine("Singleton failed!");
        }
    }
}