using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Prototype
{
    public abstract class Person
    {
        public abstract string Name { get; set; }
        public abstract Person Clone(bool deepCopy = false);
    }

    public class Manager : Person
    {
        public override string Name { get; set; }

        public Manager(string name)
        {
            Name = name;
        }

        public override Person Clone(bool deepCopy = false)
        {
            if (deepCopy)
            {
                var jsonObject = JsonConvert.SerializeObject(this);

                return JsonConvert.DeserializeObject<Manager>(jsonObject)!;
            }

            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public override string Name { get; set; }
        public Manager Manager { get; set; }

        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }

        public override Person Clone(bool deepCopy = false)
        {
            if (!deepCopy) return (Person)MemberwiseClone();
            var jsonObject = JsonConvert.SerializeObject(this);

            return JsonConvert.DeserializeObject<Employee>(jsonObject)!;
        }
    }
}