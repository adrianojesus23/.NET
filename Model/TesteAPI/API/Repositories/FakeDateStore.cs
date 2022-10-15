using Demo;

namespace API.Repositories
{
    public static class FakeDateStore
    {
        public static ICollection<Person> GetPerons()
        {
            return new List<Person>
            {
                new Person(1)
                {
                    FirstName ="Jesus",
                    LastName = "Neves",
                   Address= "Lisbon",
                    DateOfBirth = DateTimeOffset.UtcNow
                },
                new Person(2)
                {
                    FirstName ="Jesus",
                    LastName = "Neves",
                    Address= "Lisbon",
                    DateOfBirth = DateTimeOffset.UtcNow
                },
                new Person(1)
                {
                    FirstName ="Jesus",
                    LastName = "Neves",
                    Address= "Lisbon",
                    DateOfBirth = DateTimeOffset.UtcNow
                }
            };
        }
    }
}
