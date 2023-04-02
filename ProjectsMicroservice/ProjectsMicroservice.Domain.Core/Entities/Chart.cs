using ProjectsMicroservice.Domain.Core.Enums;

namespace ProjectsMicroservice.Domain.Core.Entities;

public class Chart
{
    public SupportedSymbol Symbol { get; set; }
    public ChartTimeframe Timeframe { get; set; }
    public List<Indicator> Indicators { get; set; } = new();
}
