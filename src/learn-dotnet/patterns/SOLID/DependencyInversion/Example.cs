// For now it's looking ok
public class SomeService
{
    void DoSomething() {}
}

public class SomeClass
{
    private SomeService someService;

    public SomeClass()
    {
        someService = new SomeService();
    }

    public void DoSomething()
    {
        someService.DoSomething();
    }
}

// But if we need to change it like that
public class OtherService {}
public class ChangedSomeService
{
    void DoSomething(OtherService otherService) {}
}

public class SomeClass2
{
    private SomeService someService;
    private OtherService otherService;

    public SomeClass2()
    {
        // We made this class dependent on another class that has nothing to do
        // with this class just because another class we use in this class needs it.
        otherService = new OtherService();
        someService = new ChangedSomeService();
    }

    public void DoSomething()
    {
        someService.DoSomething(otherService);
    }
}