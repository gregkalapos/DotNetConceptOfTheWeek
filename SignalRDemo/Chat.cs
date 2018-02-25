using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo
{
    public class Chat : Hub
    {
        public Chat()
        {
        }

        public Task Send(string message)
        {
            Console.WriteLine(message);
            return Clients.All.InvokeAsync("Send", message);
        }
    }
}
