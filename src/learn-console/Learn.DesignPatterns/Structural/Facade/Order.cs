namespace Learn.DesignPatterns.Structural.Facade
{
    public class Order
    {
        IOtel otel;
        ICafe cafe;
        public Order(IOtel otel, ICafe cafe)
        {
            this.otel = otel;
            this.cafe = cafe;
        }

        public void DoSomething()
        {
            cafe.GiveOrder();
            cafe.Rent();
        }

        public void Do2Something()
        {
            otel.Reservation();
            cafe.GiveOrder();
        }
    }
}
