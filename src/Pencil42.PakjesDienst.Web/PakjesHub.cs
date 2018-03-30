using Microsoft.AspNetCore.SignalR;

namespace Pencil42.PakjesDienst.Web
{
    public class PakjesHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}