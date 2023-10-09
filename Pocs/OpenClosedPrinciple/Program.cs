//  demo
var movieFilter = new MovieFilter();

var interstellar = new Movie("Interstellar", Genre.SciFi, Duration.ThreeHours);
var inception = new Movie("Inception", Genre.SciFi, Duration.TwoHours);
var hangover = new Movie("Hangover", Genre.Comedy, Duration.TwoHours);
var wolf = new Movie("Wolf of Wall Street", Genre.Comedy, Duration.OneHour);

Movie[] movies = { interstellar, inception, hangover, wolf };

var sciFyCondition = new GenreCondition(Genre.SciFi);
var twoHoursCondition = new DurationCondition(Duration.TwoHours);
var twoHourAndSciFiCondition = new DoubleCondition<Movie>(sciFyCondition, twoHoursCondition);

var scyFyMovies = movieFilter.Filter(movies, sciFyCondition);
var twoHourMovies = movieFilter.Filter(movies, twoHoursCondition);
var twoHourSciFiMovies = movieFilter.Filter(movies, twoHourAndSciFiCondition);

var comedyMovies = movieFilter.Filter(movies, (Movie movie) => movie.Genre == Genre.Comedy);

foreach(var movie in scyFyMovies)
    Console.WriteLine("Sci-Fi Movie: " + movie.Name);

foreach(var movie in twoHourMovies)
    Console.WriteLine("2 Hour Movie: " + movie.Name);

foreach(var movie in comedyMovies)
    Console.WriteLine("Comedy Movie: " + movie.Name);

foreach(var movie in twoHourSciFiMovies)
    Console.WriteLine("2 Hour Sci-Fi Movie: " + movie.Name);

// interfaces
public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, ICondition<T> condition);
    
    IEnumerable<T> Filter(IEnumerable<T> items, Predicate<T> condition);
}

public interface ICondition<T>
{
    bool IsSatisfied(T t);
}

// classes
public class MovieFilter : IFilter<Movie>
{
    public IEnumerable<Movie> Filter(IEnumerable<Movie> movies, ICondition<Movie> condition)
    {
        foreach (var movie in movies)
        {
            if (condition.IsSatisfied(movie))
                yield return movie;
        }
    }

    public IEnumerable<Movie> Filter(IEnumerable<Movie> movies, Predicate<Movie> condition)
    {
        foreach (var movie in movies)
        {
            if (condition.Invoke(movie))
                yield return movie;
        }
    }
}

public class GenreCondition : ICondition<Movie>
{
    public Genre Genre { get; set; }
    
    public GenreCondition(Genre genre)
    {
        Genre = genre;
    }

    public bool IsSatisfied(Movie movie) => movie.Genre == Genre;
}

public class DurationCondition : ICondition<Movie>
{
    public Duration Duration { get; set; }
    
    public DurationCondition(Duration duration)
    {
        Duration = duration;
    }

    public bool IsSatisfied(Movie movie) => movie.Duration == Duration;
}

public class DoubleCondition<T> : ICondition<T>
{
    private readonly ICondition<T> _condition1, _condition2;

    public DoubleCondition(ICondition<T> condition1, ICondition<T> condition2)
    {
        _condition1 = condition1;
        _condition2 = condition2;
    }

    public bool IsSatisfied(T t) => _condition1.IsSatisfied(t) && _condition2.IsSatisfied(t);
}

public class Movie
{
    public Movie(string name, Genre genre, Duration duration)
    {
        Name = name;
        Genre = genre;
        Duration = duration;
    }
    
    public string Name { get; set; }

    public Genre Genre { get; set; }

    public Duration Duration { get; set; }
}

// enums
public enum Genre
{
    SciFi = 1,
    Comedy = 2,
    Thriller = 3 
}

public enum Duration
{
    OneHour = 1,
    TwoHours = 2,
    ThreeHours = 3,
}


