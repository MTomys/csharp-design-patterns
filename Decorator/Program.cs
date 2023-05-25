using Decorator;

Console.Title = "Decorator";

var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi there");


var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendMail("Hi there");

var statisticsDecorator = new StatisticsDecorator(cloudMailService);
statisticsDecorator.SendMail($"Hi there via {nameof(statisticsDecorator)} wrapper");
