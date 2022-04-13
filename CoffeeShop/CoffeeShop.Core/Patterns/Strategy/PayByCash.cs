using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Strategy
{
    public class PayByCash : Payment
    {
        public void Pay(double price)
        {
            Console.WriteLine($"I will pay by cash {price} lei");
        }
    }
}
