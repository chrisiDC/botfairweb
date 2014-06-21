using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace BotFair.Web
{
    public class Global : System.Web.HttpApplication
    {

        //private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Global).Name);


        //public static log4net.ILog Logger { get { return logger; } }


        public Global()
            : base()
        {

        }


        void Application_Start(object sender, EventArgs e)
        {
            //log4net.Config.XmlConfigurator.Configure();


        }



        void Session_Start(object sender, EventArgs e)
        {

            HttpContext.Current.Session["state"] = new State();

            State.Instance.GlobalDate = DateTime.Now;
            State.Instance.SetGlobalDate = true;
        }

        void Session_End(object sender, EventArgs e)
        {


        }





    }
}
