namespace SingleResponsibility;

public class RentCar // This class about renting a car
{
    public List<object> Cars { get; set; }

    public object Rent() {}

    // Cars need to be washed, yes, but it is not smart to wash cars on a class
    // where cars are expected to be rented.
    public void WashCar() {}
}
