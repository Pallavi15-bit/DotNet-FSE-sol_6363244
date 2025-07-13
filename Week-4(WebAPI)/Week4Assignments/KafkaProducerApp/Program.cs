using Confluent.Kafka;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092" // default Kafka port
        };

        using (var producer = new ProducerBuilder<Null, string>(config).Build()) { 

            Console.WriteLine("Enter messages to send to Kafka. Type 'exit' to quit.");
            while (true)
            {
                Console.Write("> ");
                var message = Console.ReadLine();

                if (message?.ToLower() == "exit") break;

                var result = await producer.ProduceAsync("test-topic", new Message<Null, string> { Value = message });
                Console.WriteLine($"Sent: {message} to Partition: {result.Partition}, Offset: {result.Offset}");
            }
        }
    }
}
