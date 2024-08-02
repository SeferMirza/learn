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
public class AreaService
{
    public double CalculateArea(List<Object> shapes)
    {
        double area = 0;
        foreach(Object shape in shapes)
        {
            // As a solution, you changed the code you wrote before
            // When a new shape comes, will there be another if?
            if (shape instanceof Rectangle)
            {
                Rectangle rect = (Rectangle) shape;
                area += (rect.length * rect.height);
            }
            else if (shape instanceof Circle)
            {
                Circle circle = (Circle) shape;
                area += circle.radius * cirlce.radius * Math.PI;
            } else
            {
                throw new RuntimeException("Shape not supported");
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

public class Rectangle : IShape
{
    public double length;
    public double height;

    public double GetArea()
    {
        return (length * height);
    }
}

public class Circle : IShape
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
            area += shape.getArea();
        }
        return area;
    }
}
