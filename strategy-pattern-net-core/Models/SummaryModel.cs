namespace StrategyPatternAspNetCore.Models;

public record SummaryModel(string Title, string Summary, double Rating, List<string> FoundAt);