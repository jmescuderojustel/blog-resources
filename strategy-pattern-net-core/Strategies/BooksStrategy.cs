using StrategyPatternAspNetCore.Models;
using StrategyPatternAspNetCore.Strategies.Contracts;

namespace StrategyPatternAspNetCore.Strategies;

public class BooksStrategy : IStrategy
{
    public bool CanHandle(string topic) => topic.ToLower() == "books";

    public SummaryModel Handle(string title)
    {
        // Get summary from Amazon
        // Get reviews from Goodreads
        return new SummaryModel(title, "Book excerpt", 4.5, new List<string> { "Amazon" });
    }
}
