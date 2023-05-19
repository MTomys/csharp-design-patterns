using Prototype;

Console.Title = "Prototype";

Console.WriteLine("\n \n \n");

var manager = new Manager("Cindy");
var managerClone = (manager.Clone() as Manager)!;

var employee = new Employee("Kevin", managerClone);
var employeeClone = employee.Clone(true) as Employee;

Console.WriteLine($"Employee was cloned: {employeeClone.Name}, with manager: {employeeClone.Manager.Name}");

managerClone.Name = "Karen";

Console.WriteLine($"2 Employee was cloned: {employeeClone.Name}, with manager: {employeeClone.Manager.Name}");