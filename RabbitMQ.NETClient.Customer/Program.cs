using Macrosage.RabbitMQ.Server.Config;
using Macrosage.RabbitMQ.Server.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.NETClient.Customer
{
    class Program
    {
        static void Main(string[] args)
        {

            Parallel.For(0, RabbitMQConfig.ThreadCount, i =>
            {
                IMessageCustomer customer = new MessageCustomer("test");
                customer.StartListening();
                customer.ReceiveMessageCallback = message =>
                {
                    Console.WriteLine("接收到消息：" + message);
                    return true;
                };
           });
            Console.Read();
        }
    }
}
