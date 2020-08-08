using Microsoft.AspNetCore.SignalR;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.SignalR
{
    public class QLVLXD_Hub : Hub
    {
        public async Task SendMessage(AnnouncementViewModel message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}