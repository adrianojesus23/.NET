using API.Entities;
using Demo;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> Add(FileDetail file);
        Task<FileDetail> FileDetail(Guid id);
        Task<ICollection<PersonDetails>> GetPersonDetails();
    }
}
