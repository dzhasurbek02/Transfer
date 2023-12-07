using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Transfer.Context;
using Transfer.Features.ExchangeRate.CreateExchangeRate;
using Transfer.Features.ExchangeRate.GetAllExchangeRates;
using Transfer.Features.ExchangeRate.GetExchangeRate;
using Transfer.Features.ExchangeRate.UpdateExchangeRate;

namespace Transfer.Features.ExchangeRate;

public class ExchangeRateService : IExchangeRateService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ExchangeRateService(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task CreateExchangeRate(CreateExchangeRateRequest request)
    {
        var rate = _mapper.Map<Entities.ExchangeRate>(request);

        await _context.ExchangeRates.AddAsync(rate);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExchangeRate(UpdateExchangeRateRequest request)
    {
        var rate = await _context.ExchangeRates
            .FirstOrDefaultAsync(r => r.Id == request.Id)
                ?? throw new Exception("Курс не найден!");

        _mapper.Map(request, rate);
        await _context.SaveChangesAsync();
    }

    public async Task<List<GetExchangeRatesResponse>> GetAllExchangeRates()
    {
        return await _context.ExchangeRates
            .AsNoTracking()
            .ProjectTo<GetExchangeRatesResponse>(_mapper.ConfigurationProvider)
            .ToListAsync()
                ?? throw new Exception("Список курса валют пуст!");
    }

    public async Task<float> GetExchangeRate(GetExchangeRateRequest request)
    {
        var exchangeRate = await _context.ExchangeRates
            .Where(e => e.Currency1Id == request.SenderCurrencyId && e.Currency2Id == request.RecipientCurrencyId)
            .Select(e => e.Rate)
            .FirstOrDefaultAsync();

        if (exchangeRate <= 0)
        {
            throw new Exception("Не удалось найти обменный курс для указанных валют.");
        }

        return exchangeRate;
    }
}