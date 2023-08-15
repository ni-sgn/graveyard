using static System.Console;
using RabbitMQ.Client;
using AutoMapper;
using System.Runtime.CompilerServices;

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

    }
}
