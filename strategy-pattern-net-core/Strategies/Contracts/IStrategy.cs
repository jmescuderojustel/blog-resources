using StrategyPatternAspNetCore.Models;

namespace StrategyPatternAspNetCore.Strategies.Contracts;

public interface IStrategy
{
    bool CanHandle(string topic);
    SummaryModel Handle(string title);
}
