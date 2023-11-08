using StrategyPatternAspNetCore.Models;
using StrategyPatternAspNetCore.Strategies.Contracts;

namespace StrategyPatternAspNetCore.Strategies;

public class AlbumsStrategy : IStrategy
{
    public bool CanHandle(string topic) => topic.ToLower() == "albums";

    public SummaryModel Handle(string title)
    {
        // Get reviews from Metacritic
        // Get track listing from Metacritic to include in summary
        // Get the place where the album can be found
        return new SummaryModel(title, "Album track listing", 4.3, new List<string> { "Spotify", "LastFM" });
    }
}
