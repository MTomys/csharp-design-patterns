namespace Iterator
{
    public record Person(string Name, string Country);

    public interface IPeopleIterator
    {
        Person First();
        Person Next();
        bool IsDone { get; }
        Person CurrentItem { get; }
    }

    public interface IPeopleCollection
    {
        IPeopleIterator CreateIterator();
    }

    public class PeopleCollection : List<Person>, IPeopleCollection
    {
        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        }
    }

    public class PeopleIterator : IPeopleIterator
    {
        private readonly PeopleCollection _collection;
        private int _current = 0;

        public bool IsDone => _current >= _collection.Count;
        public Person CurrentItem => 
            _collection.OrderBy(p => p.Name).ToList()[_current];

        public PeopleIterator(PeopleCollection collection)
        {
            _collection = collection;
        }

        public Person First()
        {
            _current = 0;
            return _collection.OrderBy(p => p.Name)
                .ToList()[_current];
        }

        public Person Next()
        {
            _current++;
            if (!IsDone)
            {
                return _collection.OrderBy(p => p.Name).ToList()[_current];
            }

            return null;
        }
    }
}