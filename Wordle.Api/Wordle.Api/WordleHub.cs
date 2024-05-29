using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using Wordle.Api.Models;

namespace Wordle.Api;
[SignalRHub]
public class WordleHub : Hub
{
    [SignalRMethod]
    public async void SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    } 
}
