public interface IEverything
{
    // Unrelated methods in different contexts
    void Move();
    void Craft();
    void Transform();
}

public class Car : IEverything
{
    public void Move()
    {
        // Move the car
    }

    public void Craft()
    {
        // do nothing
    }

    public void Transform()
    {
        // do nothing
    }
}
