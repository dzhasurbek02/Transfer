using AutoMapper;
using MediatR;
using Transfer.Context;
using Transfer.Features.PaymentMethod.Commands.CheckBalanceCommand;
using Transfer.Features.PaymentMethod.Commands.UpdateBalanceCommand;

namespace Transfer.Features.Transaction.Command.CreateTransaction;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, bool>
{
    private readonly IApplicationDBContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateTransactionCommandHandler(IApplicationDBContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }
    
    public async Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var checkBalanceCommand = new CheckBalanceCommand { Id = request.SenderId, Sum = request.Sum };
        var isBalanceSufficient = await _mediator.Send(checkBalanceCommand, cancellationToken);

        if (isBalanceSufficient)
        {
            var updateBalanceCommandSender = new UpdateBalanceCommand { Id = request.SenderId, Sum = -request.Sum };
            await _mediator.Send(updateBalanceCommandSender, cancellationToken);

            var updateBalanceCommandReceiver = new UpdateBalanceCommand { Id = request.RecipientId, Sum = request.Sum };
            await _mediator.Send(updateBalanceCommandReceiver, cancellationToken);

            return true;
        }
        else
        {
            return false;
        }
    }
}