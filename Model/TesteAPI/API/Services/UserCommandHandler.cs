using API.Entities;
using API.Repositories;
using AutoMapper;
using MediatR;

namespace API.Services
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.CreateAsync(request.User);

            return _mapper.Map<UserDto>(result);
        }
    }
}
