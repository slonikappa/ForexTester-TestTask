using ProjectsMicroservice.Domain.Core.Enums;

namespace ProjectsMicroservice.Domain.Core.Models;

public class Chart
{
    public SupportedSymbol Symbol { get; set; }
    public ChartTimeframe Timeframe { get; set; }
    internal List<Indicator> Indicators { get; set; } = new();
}
