using API.Entities;
using Demo;
using Mapster;
using System.Collections;
using System.Collections.ObjectModel;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Collection<User> _users;
        private readonly Collection<FileDetail> _fileDetails;

        public UserRepository()
        {
            _users = new Collection<User>
            {
                new User { UserId = 1, Name = "Jesus", Address = "Rua XPTO", Email = "j@xxpto.pt" },
                new User { UserId = 2, Name = "Jesus2", Address = "Rua XPTO2", Email = "j2@xxpto.pt" },
                new User { UserId = 3, Name = "Jesus3", Address = "Rua XPTO3", Email = "j3@xxpto.pt" }
            };
            _fileDetails = new Collection<FileDetail>();
        }

        public Task<bool> Add(FileDetail file)
        {
            _fileDetails.Add(file);

            return Task.FromResult(false);
        }

        public class Comparer : IComparer
        {
            public int Compare(object? x, object? y)
            {
                return this.Compare(x, y);
            }

            public int ComparerTo(int x, int y)
            {
                return x.CompareTo(y);
            }
        }

        public List<int> GetSorting(int id, Comparer comparer)
        {
            comparer = new();
            var list = new List<int>();
            list.Sort(comparison: comparer.ComparerTo);

            int v = list.BinarySearch(id);

            if (v < 0) list.Add(id);


            return list;
        }



        public Task<User> CreateAsync(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            _users.Add(user);
            return Task.FromResult(user);
        }

        public Task<FileDetail> FileDetail(Guid id)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return Task.FromResult(_fileDetails.FirstOrDefault(x => x.Id == id));
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public Task<IEnumerable<User>> GetAllUsers() => (Task<IEnumerable<User>>)(IEnumerable<User>)Task.FromResult(_users);

        public async Task<ICollection<PersonDetails>> GetPersonDetails()
        {
            var people = FakeDateStore.GetPerons();
            var personDetails = people.Adapt<PersonDetails>();
            return (ICollection<PersonDetails>)await Task.FromResult(personDetails);
        }

        public Task<User> GetUserById(int id)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return Task.FromResult(_users.FirstOrDefault(x => x.UserId == id));
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }
    }
}
