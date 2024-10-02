// Observer Interface
public interface IObserver
{
    void Update(string news);
}

// Subject (NewsAgency)
public class NewsAgency
{
    private List<IObserver> observers = new List<IObserver>();
    public string LatestNews { get; set; }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(LatestNews);
        }
    }
}

// Concrete Observer
public class CNN : IObserver
{
    public void Update(string news)
    {
        Console.WriteLine("CNN received the news: " + news);
    }
}

public class BBC : IObserver
{
    public void Update(string news)
    {
        Console.WriteLine("BBC received the news: " + news);
    }
}
