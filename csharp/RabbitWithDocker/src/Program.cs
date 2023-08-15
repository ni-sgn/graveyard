using static System.Console;
using RabbitMQ.Client;
using AutoMapper;
using System.Runtime.CompilerServices;
using System.Text;

namespace program;

public class Program
{
    public static void Main(string[] args)
    {
        var conFactory = new RabbitMQ.Client.ConnectionFactory();
        conFactory.VirtualHost = "/";
        conFactory.HostName    = "172.17.0.3";
        conFactory.UserName    = "guest";
        conFactory.Password    = "guest";

        var con   = conFactory.CreateConnection();
        var model = con.CreateModel();

        model.ExchangeDeclare("exchange1", "fanout", true, false, null);
        var queue1 = model.QueueDeclare("queue1", true, false, false, null);
        //model.QueueBind("queue1", "exchange1", "route", null);

        var body = Encoding.UTF8.GetBytes("Hello rabbit, I'm here");
        model.BasicPublish(string.Empty, "queue1", null, body);
    }
}
