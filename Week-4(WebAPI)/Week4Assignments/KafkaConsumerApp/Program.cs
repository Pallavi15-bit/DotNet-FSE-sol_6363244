using System;
using System.Threading;
using Confluent.Kafka;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092", // Change if needed
            GroupId = "chat-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe("chat-topic"); // Change topic name if needed
            Console.WriteLine("Kafka Consumer started. Listening to topic...");

            CancellationTokenSource cts = new CancellationTokenSource();

            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true; // prevent app from closing immediately
                cts.Cancel();
            };

            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    var cr = consumer.Consume(cts.Token);
                    Console.WriteLine($"Received message: {cr.Message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Consumer closing...");
                consumer.Close();
            }
        }
    }
}
