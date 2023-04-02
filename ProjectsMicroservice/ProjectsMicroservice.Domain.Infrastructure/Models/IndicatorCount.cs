using ProjectsMicroservice.Domain.Core.Enums;

namespace ProjectsMicroservice.Domain.Infrastructure.Models;

public class IndicatorCount
{
    public IndicatorName Name { get; set; }
    public int Used { get; set; }
}