using StrategyPatternAspNetCore.Models;
using StrategyPatternAspNetCore.Strategies.Contracts;

namespace StrategyPatternAspNetCore.Strategies;

public class MoviesStrategy : IStrategy
{
    public bool CanHandle(string topic) => topic.ToLower() == "movies";

    public SummaryModel Handle(string title)
    {
        // Get reviews and summary from Imdb
        // Get the place where the movie can be found
        return new SummaryModel(title, "Movie summary", 3.9, new List<string> { "Netflix" });
    }
}
