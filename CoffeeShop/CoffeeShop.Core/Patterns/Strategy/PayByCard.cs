using CoffeeShop.Core.Abstract.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Patterns.Strategy
{
    public class PayByCard : Payment
    {
        private string _cardNumber;
        private string _cvv;
        private DateOnly _expirationDate;
        public PayByCard(string cardNumber, string cvv, DateOnly expirationDate)
        {
            _cardNumber = cardNumber;
            _cvv = cvv;
            _expirationDate = expirationDate;
        }
        public void Pay(decimal price)
        {
            Console.WriteLine($"I paid {price} lei with my card having the number {_cardNumber} and the cvv {_cvv}");
        }
    }
}
