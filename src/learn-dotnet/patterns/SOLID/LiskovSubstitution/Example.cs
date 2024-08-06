public interface IBaseInterface
{
    void OtherStaff();
    void Configure();
}

// Alt sınıflar (ChildClass1 ve ChildClass2)
public class ChildClass1 : IBaseInterface
{
    public void OtherStaff()
    {
        // do something
    }

    public void Configure()
    {
        // Here the exception is thrown because it doesn't need the method. it
        // just added this interface to use the other method.
        throw new NotImplementedException();
    }
}

public class ChildClass2 : IBaseInterface
{
    public void OtherStaff()
    {
        // do something
    }

    public void Configure()
    {
        // ChildClass2 configuration
    }
}

public class BaseClass
{
    public void Configure(List<IBaseInterface> objs)
    {
        foreach(var obj in objs)
        {
            // This is a bad example and contradicts the principle of liskov
            // substitution.
            if (obj is ChildClass1)
            {
                // do nothing
            }
            else
            {
                obj.Configure();
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        BaseClass baseClass = new BaseClass();
        baseClass.Configure([new ChildClass1(), new ChildClass2()]);
    }
}
