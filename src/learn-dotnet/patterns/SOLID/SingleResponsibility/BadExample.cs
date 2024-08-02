namespace SingleResponsibility;

public class RentCarBad // This class about renting a car
{
    public List<object> Cars { get; set; }

    public object Rent() => Cars[0];

    // Cars need to be washed, yes, but it is not smart to wash cars on a class
    // where cars are expected to be rented.
    public void WashCar() {}
}
