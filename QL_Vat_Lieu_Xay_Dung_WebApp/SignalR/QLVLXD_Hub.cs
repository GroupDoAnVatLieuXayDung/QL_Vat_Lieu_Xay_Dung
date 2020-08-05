using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;

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
