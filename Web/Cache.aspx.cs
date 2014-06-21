using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bot.Shared;
using Tools;

namespace BotFair.Web
{
    public partial class Cache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataBind();
           

        }

        protected string GetTableString()
        {
            string ipcPort = System.Configuration.ConfigurationManager.AppSettings["ipc_port"];
            var server = (IBotServer)Activator.GetObject(typeof(IBotServer), "ipc://" + ipcPort + "/botserver/o");

            var view = server.GetCacheContent(Request.QueryString[0],Server.UrlDecode(Request.QueryString[1]).Replace("%"," "));
            return view.ToHtmlTable();

        }
    }
}