using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    interface IPaymentProcessor
    {
        void ProcessPayment(string amount);
    }

    class Razorpay
    {
        public void MakePayment(string amt)
        {
            Console.WriteLine($"Razorpay processing {amt}");
        }
    }

    class RazorpayAdapter : IPaymentProcessor
    {
        private readonly Razorpay _razorpay = new Razorpay();
        public void ProcessPayment(string amount)
        {
            _razorpay.MakePayment(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor processor = new RazorpayAdapter();
            processor.ProcessPayment("$100");
        }
    }
}