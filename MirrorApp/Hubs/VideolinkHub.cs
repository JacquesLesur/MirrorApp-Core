using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirrorApp.Hubs
{
    public class VideolinkHub: Hub
    {


        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        public async Task ChangeVideoLink(string videoLink)
        {
            await Clients.All.SendAsync("ChangeLinkJs", videoLink);
        }
    }
}
