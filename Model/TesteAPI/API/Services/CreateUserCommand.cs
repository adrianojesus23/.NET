using API.Entities;
using MediatR;

namespace API.Services
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }
}
