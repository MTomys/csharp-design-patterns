using Singleton;

Console.Title = "Singleton";

//var logger = new Logger();

var logger1 = Logger.Instance;
var logger2 = Logger.Instance;

if (logger1 == logger2 && logger2 == Logger.Instance)
{
    Console.WriteLine("Instances are equal");
}