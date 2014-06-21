using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BotFair.Web;

namespace Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_PreRender(object sender, EventArgs e)
        {
            State.Instance.SetGlobalDate = false;
            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            LBL_Version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (!Page.IsPostBack)
                TB_GlobalDate.Text = State.Instance.GlobalDate.Value.ToShortDateString();


        }

        public void ShowErrorMessage(string msg)
        {
            if (msg != null)
            {
                if(msg.Length > 40) LBL_ERROR.Text = "ERROR: " + msg.Substring(0,39);
                else LBL_ERROR.Text = "ERROR: " + msg;
            }
        }


        protected void VD_DateFrom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime t;

            args.IsValid = DateTime.TryParse(args.Value, out t);

        }

        protected void TB_GlobalDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BT_ChangeDate_Click(object sender, EventArgs e)
        {
            if (VD_GlobalDate.IsValid)
            {
                State.Instance.GlobalDate = DateTime.Parse(TB_GlobalDate.Text);
                TB_GlobalDate.Text = State.Instance.GlobalDate.Value.ToShortDateString();
                State.Instance.SetGlobalDate = true;
            }
        }



        protected void ValidateGlobalDate(object source, ServerValidateEventArgs args)
        {
            DateTime t;

            args.IsValid = DateTime.TryParse(args.Value, out t);
            
        }

    }
}
