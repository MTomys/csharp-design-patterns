using ClassAdapter;

Console.Title = "Adapter";

ClassAdapterImplementation.ICityAdapter adapter = new ClassAdapterImplementation.CityAdapter();
var city = adapter.GetCity();

Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
