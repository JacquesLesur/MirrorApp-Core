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
        public async Task ChangeVideoLink()
        {
            await Clients.All.SendAsync("ChangeLinkJs", Config.youtubeUrl);
        }
        public async Task ChangeCitation()
        {
            await Clients.All.SendAsync("ChangeCitationJs", Config.citation);
        }
    }
}
