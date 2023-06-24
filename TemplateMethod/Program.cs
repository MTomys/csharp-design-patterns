using System.Threading.Channels;
using TemplateMethod;

Console.Title = "Template Method";

var exchangeMailParser = new ExchangeMailParser();
Console.WriteLine(exchangeMailParser.ParseHtmlMailBody("asd"));
Console.WriteLine();

ApacheMailParser apacheMailParser = new();
Console.WriteLine(apacheMailParser.ParseHtmlMailBody("asd"));
Console.WriteLine();
