using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agm.Hubs
{
    public class MsgHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MsgHub>();
            context.Clients.All.displayTextMessage();
        }

    }
}