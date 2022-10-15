using API.Entities;
using MediatR;

namespace API.Services
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; set; }
    }
}

