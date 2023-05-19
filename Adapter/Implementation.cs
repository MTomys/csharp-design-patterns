namespace Adapter
{

    public class CityFromExternalSystem
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Inhabitants { get; set; }

        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }
    }

    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Antwerp", "'t stadt", 500_000);
        }
    }

    public class City
    {
        public string FullName { get; set; }
        public long Inhabitants { get; private set; }

        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }
    }

    public interface ICityAdapter
    {
        City GetCity();
    }

    public class CityAdapter : ICityAdapter
    {
        public ExternalSystem ExternalSystem { get; } = new();

        public City GetCity()
        {
            var cityFromExternalSystem = ExternalSystem.GetCity();

            return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}",
                cityFromExternalSystem.Inhabitants);
        }
    }

    
    
}