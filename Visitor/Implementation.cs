namespace Visitor
{
    public class Customer : IElement
    {
        public string Name { get; private set; }
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }

        public Customer(string name, decimal amountOrdered)
        {
            Name = name;
            AmountOrdered = amountOrdered;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Customer)} {Name}, discount given: {Discount}");
        }
    }

    public class Employee : IElement
    {
        public string Name { get; private set; }
        public int YearsEmployed { get; private set; }
        public decimal Discount { get; set; }

        public Employee(string name, int yearsEmployed)
        {
            Name = name;
            YearsEmployed = yearsEmployed;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Console.WriteLine($"Visited: {nameof(Employee)} {Name}, discount given: {Discount}");
        }
    }

    public interface IVisitor
    {
        void Visit(IElement element);
    }

    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; set; }

        private void VisitCustomer(Customer customer)
        {
            var discount = customer.AmountOrdered / 10;
            customer.Discount = discount;
            TotalDiscountGiven += discount;
        }

        private void VisitEmployee(Employee employee)
        {
            var discount = employee.YearsEmployed < 10 ? 100 : 200;
            employee.Discount = discount;
            TotalDiscountGiven += discount;
        }

        public void Visit(IElement element)
        {
            if (element is Customer cust)
            {
                VisitCustomer(cust);
            }
            else if (element is Employee emp)
            {
                VisitEmployee(emp);
            }
        }
    }

    public class Container
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in Employees)
            {
                employee.Accept(visitor);
            }

            foreach (var customer in Customers)
            {
                customer.Accept(visitor);
            }
        }
    }
}