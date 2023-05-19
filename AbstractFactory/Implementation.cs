namespace AbstractFactory
{
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostService CreateShippingCostsService();
    }

    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage { get; }
    }

    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage { get; }
    }

    public interface IShippingCostService
    {
        decimal ShippingCosts { get; }
    }

    public class BelgiumShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts { get; }
    }

    public class FranceShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts { get; }
    }

    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostService CreateShippingCostsService()
        {
            return new BelgiumShippingCostService();
        }
    }

    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostService CreateShippingCostsService()
        {
            return new FranceShippingCostService();
        }
    }

    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostService = factory.CreateShippingCostsService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine(
                $"Total costs: {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCosts}");
        }
    }
}