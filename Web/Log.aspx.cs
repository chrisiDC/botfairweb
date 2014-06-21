using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BotFair.Web
{
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack || State.Instance.SetGlobalDate)
            {

                TB_DateFrom.Text = State.Instance.GlobalDate.Value.ToShortDateString();
            }
        }

        protected void VD_DateFrom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime t;

            args.IsValid = DateTime.TryParse(args.Value, out t);

        }

        protected void SqlDataSource1_Filtering(object sender, SqlDataSourceFilteringEventArgs e)
        {
            e.Cancel = !VD_DateFrom.IsValid;
        }
    }
}