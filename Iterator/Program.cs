using Iterator;

Console.Title = "Iterator";

PeopleCollection people = new();

people.Add(new Person("cevin Dockx", "Belgium"));
people.Add(new Person("boland Guijt", "The Netherlands"));
people.Add(new Person("ahomas Claudius Huber", "Germany"));


var peopleIterator = people.CreateIterator();
for (var person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
{
    Console.WriteLine(person.Name);
}