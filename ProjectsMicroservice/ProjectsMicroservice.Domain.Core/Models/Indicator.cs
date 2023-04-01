using ProjectsMicroservice.Domain.Core.Enums;

namespace ProjectsMicroservice.Domain.Core.Models;

internal class Indicator
{
    public IndicatorName Name { get; set; }
    public string Parameters { get; set; } = string.Empty;
}
