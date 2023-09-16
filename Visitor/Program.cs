using System.Threading.Channels;
using Visitor;

Console.Title = "Visitor";

var container = new Container();

container.Customers.Add(new Customer("Sophie", 500));
container.Customers.Add(new Customer("Sophie", 1000));
container.Employees.Add(new Employee("Sophie", 18));
container.Employees.Add(new Employee("Sophie", 5));

DiscountVisitor discountVisitor = new();

container.Accept(discountVisitor);

Console.WriteLine($"Total discount: {discountVisitor.TotalDiscountGiven}");
