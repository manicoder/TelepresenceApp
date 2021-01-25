using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TelepresenceApp.CallHandler
{
    public class ControlEventManager
    {
        public event EventHandler OnRecieved;
        HubConnection hubConnection;
        public async Task Init(string url = "https://mobomedia.in/sendhub")
        {
            hubConnection = new HubConnectionBuilder().WithUrl(url).Build();

            hubConnection.On<string>("StartNewCall", (value) =>
            {
                OnRecieved?.Invoke(value, new EventArgs());
            });
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await hubConnection.StartAsync();
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }
        public void SendRequestControlEvents(string elementEventHandler)
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                hubConnection.SendAsync("StartNewCall", elementEventHandler);
            }
        }
    }
}
