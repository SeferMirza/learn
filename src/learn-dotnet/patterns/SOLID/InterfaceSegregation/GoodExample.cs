public interface IMoveable
{
    void Move();
}

public interface ISmith
{
    void Craft();
}

public interface ISomethingIDK
{
    void Transform();
}

public class Car : IMoveable
{
    public void Move()
    {
        // Move the car
    }

    // We no longer have to give irrelevant methods to the class
}

// ...
