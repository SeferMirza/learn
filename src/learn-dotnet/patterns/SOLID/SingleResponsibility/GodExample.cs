namespace SingleResponsibility;

public class RentCar // This class about renting a car
{
    public List<object> Cars { get; set; }

    public object Rent() {}
}

public class CarMaintenance // This class about
{
    // This method must be in a class with this class name or similar context.
    // Under a class like car rental, most people would not think of washing cars.
    public void WashCar() {}
}
