using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Service
{
    public class SignalHub : Hub
    {
        public static int Count { get; set; } = 0;
        public async void SendMessage()
        {
            Count++;
            await Clients.All.SendAsync("sendMessageToManager", Count);
        }
    }
}

