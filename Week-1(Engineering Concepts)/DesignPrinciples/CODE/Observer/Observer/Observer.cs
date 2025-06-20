using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    interface IObserver
    {
        void Update(float price);
    }

    interface IStock
    {
        void Register(IObserver o);
        void Unregister(IObserver o);
        void Notify();
    }

    class StockMarket : IStock
    {
        private List<IObserver> observers = new List<IObserver>();
        private float price;

        public void SetPrice(float newPrice)
        {
            price = newPrice;
            Notify();
        }

        public void Register(IObserver o) => observers.Add(o);
        public void Unregister(IObserver o) => observers.Remove(o);

        public void Notify()
        {
            foreach (var o in observers)
                o.Update(price);
        }
    }

    class MobileApp : IObserver
    {
        public void Update(float price)
        {
            Console.WriteLine($" MobileApp: Stock price updated to Rs.{price}");
        }
    }

    class WebApp : IObserver
    {
        public void Update(float price)
        {
            Console.WriteLine($" WebApp: Stock price updated to Rs.{price}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StockMarket stock = new StockMarket();

            MobileApp mobile = new MobileApp();
            WebApp web = new WebApp();

            stock.Register(mobile);
            stock.Register(web);

            stock.SetPrice(150.5f);
            stock.SetPrice(155.3f);

            Console.ReadLine(); // to keep console open
        }
    }
}
