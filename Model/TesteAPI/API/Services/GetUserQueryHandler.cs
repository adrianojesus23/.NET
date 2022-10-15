using API.Entities;
using API.Repositories;
using AutoMapper;
using MediatR;
namespace API.Services
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAllUsers();

            return _mapper.Map<IEnumerable<UserDto>>(result);
        }
    }
}
