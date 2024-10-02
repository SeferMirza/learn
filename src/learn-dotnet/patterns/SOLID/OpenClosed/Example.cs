namespace OpenClosed;

// 1. You only have one shape class in your system.
public class Rectangle
{
    public double length;
    public double height;
}

// 2. And the service where you calculate the area of shapes
public class AreaService
{
    // When you had only one class, you only took it as a parameter.
    public double CalculateArea(List<Rectangle> shapes)
    {
        double area = 0;
        foreach(Rectangle rect in shapes) // And here you directly used that class type.
        {
            area += rect.length * rect.height;
        }
        return area;
    }
}

// 3. Then somehow a new shape class arrived
public class Circle
{
    public double radius;
}

// 4. Area service needs to be updated
public class AreaServiceUpdated
{
    public double CalculateArea(List<Object> shapes)
    {
        double area = 0;
        foreach(Object shape in shapes)
        {
            // As a solution, you changed the code you wrote before
            // When a new shape comes, will there be another if?
            if (shape is Rectangle)
            {
                Rectangle rect = (Rectangle) shape;
                area += (rect.length * rect.height);
            }
            else if (shape is Circle)
            {
                Circle circle = (Circle) shape;
                area += circle.radius * circle.radius * Math.PI;
            }
            else
            {
                throw new Exception("Shape not supported");
            }
        }
        return area;
    }
}

// Something simpler should be considered as a solution. As the Open Closed
// Principle suggests. Don't change existing code all the time, but you can
// add new things to the system.
public interface IShape
{
    double GetArea();
}

public class RectangleNew : IShape
{
    public double length;
    public double height;

    public double GetArea()
    {
        return (length * height);
    }
}

public class CircleNew : IShape
{
    public double radius;

    public double GetArea()
    {
        return (radius * radius * Math.PI);
    }
}

// Done this way, we can add as many shapes as we want, as long as they derive from IShape.
public class AreaManager
{
    public double CalculateArea(List<IShape> shapes)
    {
        double area = 0;
        foreach(IShape shape in shapes)
        {
            area += shape.GetArea();
        }
        return area;
    }
}
