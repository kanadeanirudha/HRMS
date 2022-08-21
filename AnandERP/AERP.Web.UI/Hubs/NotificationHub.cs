using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using AERP.Web.UI.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AERP.Web.UI.Hubs
{
    public class NotificationHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ToString();
        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.updateMessages();
        }
    }
}