public interface ICommand
{
    void Execute();
}

// Real Command
public class TurnOnCommand : ICommand
{
    private TV _tv;

    public TurnOnCommand(TV tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.TurnOn();
    }
}

// Invoker
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        // logging, listing ...
        _command.Execute();
    }
}

// Receiver
public class TV
{
    public void TurnOn()
    {
        Console.WriteLine("Open Tv");
    }

    // ... More command
}

// Client
class Program
{
    static void Main(string[] args)
    {
        TV tv = new TV();

        // Can be replicated
        ICommand turnOnCommand = new TurnOnCommand(tv);

        RemoteControl remote = new RemoteControl();

        remote.SetCommand(turnOnCommand);
        remote.PressButton();
    }
}
