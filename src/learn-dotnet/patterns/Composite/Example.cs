public interface IMovie
{
    void showMovieInfo();
}

public class Thriller : IMovie
{
    int id;
    string name;
    string releaseDate;
    double imdb;

    public Thriller(int id, string name, string releaseDate, double imdb)
    {
        id = id;
        name = name;
        imdb = imdb;
        releaseDate = releaseDate;
    }


    public void showMovieInfo()
    {
        Console.WriteLine("Film adı : " + name);
        Console.WriteLine("Yayın tarihi : " + releaseDate);
        Console.WriteLine("İmdb : " + imdb);
        Console.WriteLine("--");
    }
}

public class Horror : IMovie
{
    int id;
    string name;
    string releaseDate;
    double imdb;

    public Horror(int id, string name, string releaseDate, double imdb)
    {
        id = id;
        name = name;
        imdb = imdb;
        releaseDate = releaseDate;
    }

    public void showMovieInfo()
    {
        Console.WriteLine("Film adı : " + name);
        Console.WriteLine("Yayın tarihi : " + releaseDate);
        Console.WriteLine("İmdb : " + imdb);
        Console.WriteLine("--");
    }
}

public class MovieContainer : IMovie
{

    List<IMovie> movies = [];

    public void showMovieInfo()
    {
        foreach(var movie in movies)
        {
            movie.showMovieInfo();
        }
    }

    public void addMovie(IMovie movie)
    {
        movies.add(movie);
    }

    public void removeMovie(IMovie movie)
    {
        movies.remove(movie);
    }

}

public class Main
{
    public static void main(String[] args)
    {

        MovieContainer thrillerContainer = new();
        thrillerContainer.addMovie(new Thriller(1, "The Silence of the Lambs", "11 Ekim 1991", 8.6));
        thrillerContainer.addMovie(new Thriller(2, "Basic Instinct", "27 Kasım 1992", 7.0));

        MovieContainer horrorContainer = new();
        horrorContainer.addMovie(new Horror(2, "Scream", "15 Ağustos 1997", 7.4));

        MovieContainer container = new();

        container.addMovie(thrillerContainer);
        container.addMovie(horrorContainer);

        container.showMovieInfo();
    }
}
