abstract class Beverage
{
    // Template Method
    public void PrepareBeverage()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    void BoilWater()
    {
        Console.WriteLine("Water boiling...");
    }

    abstract void Brew();

    void PourInCup()
    {
        Console.WriteLine("The drink is poured into the glass...");
    }

    abstract void AddCondiments();
}

class Tea : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Tea is brewing...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Lemon adding...");
    }
}

class Coffee : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Coffee is brewing...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Milk adding...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Beverage teaWithLemon = new Tea();
        teaWithLemon.PrepareBeverage();

        Beverage coffeeWithMilk = new Coffee();
        coffeeWithMilk.PrepareBeverage();
    }
}