using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    interface IPaymentStrategy
    {
        void Pay(string amount);
    }

    class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(string amount) => Console.WriteLine($"Paid {amount} using Credit Card");
    }

    class PayPalPayment : IPaymentStrategy
    {
        public void Pay(string amount) => Console.WriteLine($"Paid {amount} using PayPal");
    }

    class PaymentContext
    {
        private IPaymentStrategy strategy;

        public PaymentContext(IPaymentStrategy strategy) => this.strategy = strategy;

        public void Execute(string amount)
        {
            strategy.Pay(amount);
        }
    }

    class Strategy
    {
        static void Main(string[] args)
        {
            var context = new PaymentContext(new CreditCardPayment());
            context.Execute("Rs.500");

            context = new PaymentContext(new PayPalPayment());
            context.Execute("Rs.750");
        }
    }
}
