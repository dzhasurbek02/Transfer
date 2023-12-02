using AutoMapper;
using Transfer.Context;
using Transfer.Features.Currency.CreateCurrency;

namespace Transfer.Features.Currency;

public class CurrencyService : ICurrencyService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CurrencyService(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task CreateCurrency(CreateCurrencyRequest request)
    {
        var currency = _mapper.Map<Entities.Currency>(request);

        await _context.Currencies.AddAsync(currency);
        await _context.SaveChangesAsync();
    }
}