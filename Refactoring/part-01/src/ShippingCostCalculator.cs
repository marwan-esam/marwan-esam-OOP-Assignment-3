namespace RefactoringLab;

public interface ICarrier
{
    public decimal ShippingCost {get;}
    public decimal Calculate(decimal weightKg);
}

public class Aramex : ICarrier
{
    public decimal ShippingCost {get;} = 12m;

    public decimal Calculate(decimal weightKg)
    {
        return ShippingCost * weightKg;
    }
}

public class FedEx : ICarrier
{
    public decimal ShippingCost {get;} = 15m;
    
    public decimal Calculate(decimal weightKg)
    {
        return ShippingCost * weightKg;
    }
}

public class DHL : ICarrier
{
    public decimal ShippingCost {get;} = 18m;

    public decimal Calculate(decimal weightKg)
    {
        return ShippingCost * weightKg;
    }
}

public class EgyptPost : ICarrier
{
    public decimal ShippingCost {get;} = 13m;

    public decimal Calculate(decimal weightKg)
    {
        return ShippingCost * weightKg;
    }
}

public class ShippingCostCalculator
{
    public decimal Calculate(ICarrier carrier, decimal weightKg)
    {
        ArgumentNullException.ThrowIfNull(carrier);
        return carrier.Calculate(weightKg);
    }
}
