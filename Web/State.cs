using System;
using System.Web;
using System.Diagnostics;

namespace BotFair.Web
{
    internal class State
    {
        public static State Instance
        {
            get { return (State)HttpContext.Current.Session["state"]; }
        }

        public DateTime? GlobalDate { get; set; }

        public bool SetGlobalDate { get; set; }
    }
}