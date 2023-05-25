using Facade;

Console.Title = "Facade";

var facade = new DiscountFacade();

Console.WriteLine($"Discount for id 1: {facade.CalculateDiscountPercentage(1)}");
Console.WriteLine($"Discount for id 10: {facade.CalculateDiscountPercentage(10)}");
