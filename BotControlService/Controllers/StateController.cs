using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bot.Shared;

namespace BotFair.ControlService.Controllers
{
    public class StateController : ApiController
    {
        private IBotServer server;

        public StateController()
        {
            string ipcPort = System.Configuration.ConfigurationManager.AppSettings["ipc_port"];
            server = (IBotServer)Activator.GetObject(typeof(IBotServer), "ipc://" + ipcPort + "/botserver/o");
        }


        public int Get()
        {

            return server.GetState();
         
        }
    }
}
