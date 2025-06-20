using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Computer
    {
        public string CPU { get; }
        public string RAM { get; }
        public string Storage { get; }

        private Computer(Builder builder)
        {
            CPU = builder.CPU;
            RAM = builder.RAM;
            Storage = builder.Storage;
        }

        public class Builder
        {
            public string CPU { get; private set; }
            public string RAM { get; private set; }
            public string Storage { get; private set; }

            public Builder SetCPU(string cpu)
            {
                CPU = cpu;
                return this;
            }

            public Builder SetRAM(string ram)
            {
                RAM = ram;
                return this;
            }

            public Builder SetStorage(string storage)
            {
                Storage = storage;
                return this;
            }

            public Computer Build()
            {
                return new Computer(this);
            }
        }

        public void ShowSpecs()
        {
            Console.WriteLine($"CPU: {CPU}, RAM: {RAM}, Storage: {Storage}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pc = new Computer.Builder()
                .SetCPU("Intel i7")
                .SetRAM("16GB")
                .SetStorage("1TB SSD")
                .Build();

            pc.ShowSpecs();
        }
    }
}
