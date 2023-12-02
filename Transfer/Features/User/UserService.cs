using AutoMapper;
using Transfer.Context;
using Transfer.Features.User.CreateUser;

namespace Transfer.Features.User;

public class UserService : IUserService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserService(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task CreateUser(CreateUserRequest request)
    {
        var user = _mapper.Map<Entities.User>(request);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}