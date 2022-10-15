using API.Entities;
using MediatR;

namespace API.Services
{
    public class GetUserQuery : IRequest<IEnumerable<UserDto>>
    {
        public GetUserQuery()
        {
        }
    }
}
