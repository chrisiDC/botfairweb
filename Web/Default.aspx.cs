using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using Bot.Shared;
using BotFair;
using Web;
using Tools;

namespace BotFair.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected IBotServer server;
        private int state;
        private SiteMaster master;
        private int currentBotConfiguration;
        private GridViewRow selectedRow;


      


        public _Default()
        {
            string ipcPort = System.Configuration.ConfigurationManager.AppSettings["ipc_port"];
            server = (IBotServer)Activator.GetObject(typeof(IBotServer), "ipc://" + ipcPort + "/botserver/o");
         
        }



        protected void Page_Init(object sender, EventArgs e)
        {
            master = (SiteMaster)Master;
            try
            {
                state = server.GetState();
                currentBotConfiguration = server.GetActiveConfiguration();
            }
            catch (RemotingException ex)
            {
                //Global.Logger.Error(ex);
                master.ShowErrorMessage("Failed To Connect Bot Server!");//"xxx");

            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            BotState stateEnum = (BotState)Enum.Parse(typeof(BotState), state.ToString());
            LBL_Status.Text = Enum.GetName(typeof(BotState), state);

            int configId;

            try
            {
                configId = server.GetActiveConfiguration();

                if (configId > 0)
                {
                    DbAccess db =
                        new DbAccess(System.Configuration.ConfigurationManager.ConnectionStrings["botfair"].ConnectionString);
                    try
                    {
                        var rows = db.DoQuery("select * from configuration where id=" + configId)[0];

                        //LBL_Percentage.Text = Convert.ToString(rows["percentage"]);
                        //LBL_HotMarkets.Text = Convert.ToString(rows["hotmarketsseconds"]);
                        //LBL_RiskValue.Text = Convert.ToString(rows["riskvalue"]);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (RemotingException ex)
            {
                
                master.ShowErrorMessage(ex.ToString());
            }

        }


        protected void BT_Start_Click(object sender, EventArgs e)
        {
            try
            {
                server.Start();
            }
            catch (RemotingException ex)
            {

                master.ShowErrorMessage(ex.ToString());// ("xxx");
            }
        }

        protected void BT_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                server.ShutDown();
            }
            catch (RemotingException ex)
            {

                master.ShowErrorMessage(ex.ToString());
            }
        }



        protected void DetailsView1_ModeChanged(object sender, EventArgs e)
        {
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)GridView1.SelectedDataKey.Value;

            bool success = false;
            try
            {
                success = server.ChangeConfiguration(id);
                if (!success) ((SiteMaster)Master).ShowErrorMessage("error when changing configuration");
            }
            catch (RemotingException ex)
            {
                master.ShowErrorMessage(ex.ToString());

            }


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (currentBotConfiguration != 0 && e.Row.RowType == DataControlRowType.DataRow)
            {
                var key = (int)GridView1.DataKeys[e.Row.RowIndex].Value;
                if (key == currentBotConfiguration)
                {
                    selectedRow = e.Row;
                }
               
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (selectedRow != null)
                GridView1.SelectRow(selectedRow.RowIndex);
            else
            {
                GridView1.SelectedIndex = -1;

            }
        }

        protected void BT_Refresh_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
        }

    }
}
