using StrategyPatternAspNetCore.Models;
using StrategyPatternAspNetCore.Strategies;
using StrategyPatternAspNetCore.Strategies.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IStrategy, BooksStrategy>();
builder.Services.AddTransient<IStrategy, MoviesStrategy>();
builder.Services.AddTransient<IStrategy, AlbumsStrategy>();

var app = builder.Build();

app.MapGet("/summary/v1/{topic}/{title}", (string topic, string title) =>
{
    if (topic.ToLower() == "books")
    {
        // Get summary from Amazon
        // Get reviews from Goodreads
        return new SummaryModel(title, "Book excerpt", 4.5, new List<string> { "Amazon" });
    }
    else if (topic.ToLower() == "movies")
    {
        // Get reviews and summary from Imdb
        // Get the place where the movie can be found
        return new SummaryModel(title, "Movie summary", 3.9, new List<string> { "Netflix" });
    }
    else if (topic.ToLower() == "albums")
    {
        // Get reviews from Metacritic
        // Get track listing from Metacritic to include in summary
        // Get the place where the album can be found
        return new SummaryModel(title, "Album track listing", 4.3, new List<string> { "Spotify", "LastFM" });
    }

    throw new NotImplementedException("We still do not support that topic. Come again later!");
});

app.MapGet("/summary/v2/{topic}/{title}", (string topic, string title) =>
{
    var strategies = new List<IStrategy>
    {
        new BooksStrategy(),
        new MoviesStrategy(),
        new AlbumsStrategy(),
    };

    var strategy = strategies.SingleOrDefault(s => s.CanHandle(topic));

    if(strategy is null)
    {
        throw new NotImplementedException("We still do not support that topic. Come again later!");
    }

    return strategy.Handle(title);
});

app.MapGet("/summary/v3/{topic}/{title}", (string topic, string title, IEnumerable<IStrategy> strategies) =>
{
    var strategy = strategies.SingleOrDefault(s => s.CanHandle(topic));

    if (strategy is null)
    {
        throw new NotImplementedException("We still do not support that topic. Come again later!");
    }

    return strategy.Handle(title);
});

app.Run();