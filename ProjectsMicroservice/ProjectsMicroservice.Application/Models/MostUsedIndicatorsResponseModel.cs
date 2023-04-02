using ProjectsMicroservice.Domain.Infrastructure.Models;

namespace ProjectsMicroservice.Application.Models;

public class MostUsedIndicatorsResponseModel
{
    public List<IndicatorCount> Indicators { get; set; } = new();
}

