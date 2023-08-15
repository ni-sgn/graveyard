using static System.Console;
using RabbitMQ.Client;
using AutoMapper;

namespace program;

public class Program
{
    public static void Main(string[] args)
    {
        var conFactory = new RabbitMQ.Client.ConnectionFactory();
        conFactory.VirtualHost = "guest";
        conFactory.HostName    = "localhost";
        conFactory.UserName    = "guest";
        conFactory.Password    = "guest";
    }
}
