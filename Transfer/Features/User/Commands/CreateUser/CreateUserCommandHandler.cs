using AutoMapper;
using MediatR;
using Transfer.Context;

namespace Transfer.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Entities.User>(request);

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
}