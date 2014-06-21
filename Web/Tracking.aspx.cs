using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BotFair.Web
{
    public partial class Tracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Error(object sender, EventArgs e)
        {

        }

        protected string GetUrl(object data)
        {

            return "http://localhost:669/botfair2/selectiontrack/default?marketId=" + ((DataRowView)data)["marketId"] + "&selectionId=" + ((DataRowView)data)["selectionId"];
   
        }
        protected void SqlDataSource1_Filtering(object sender, SqlDataSourceFilteringEventArgs e)
        {
            //if (DDL_Lay.SelectedValue == "1") e.ParameterValues["isLay"] = 1;
            //else if (DDL_Lay.SelectedValue == "0") e.ParameterValues["isLay"] = 0; 
        }
    }
}