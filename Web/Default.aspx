<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="BotFair.Web._Default" EnableViewState="true" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="BT_Start" runat="server" Text="Start" OnClick="BT_Start_Click" />
    <asp:Button ID="BT_Stop" runat="server" Text="Stop" OnClick="BT_Stop_Click" />
    <asp:Button ID="BT_Refresh" runat="server" Text="Refresh" 
        onclick="BT_Refresh_Click" />
       

    <table class="table">
        <tr>
            <td>
                Bot Status:
            </td>
            <td>
                <asp:Label ID="LBL_Status" runat="server" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="id" DataSourceID="DS_Configuration" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnDataBound="GridView1_DataBound" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound"
        PageSize="10">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowDeleteButton="true" />
            <asp:BoundField DataField="hotMarketsSeconds" HeaderText="hotMarketsSeconds" SortExpression="hotMarketsSeconds" />
            <asp:BoundField DataField="percentage" HeaderText="percentage" SortExpression="percentage" />
            <asp:BoundField DataField="riskValue" HeaderText="riskValue" SortExpression="riskValue" />
             <asp:BoundField DataField="newMarketsPeriod" HeaderText="newMarketsPeriod" SortExpression="newMarketsPeriod" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                SortExpression="id" />
        </Columns>
        <SelectedRowStyle BackColor="#00CC00" />
    </asp:GridView>
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="id"
        DataSourceID="DS_Configuration" DefaultMode="Insert" Height="50px" Width="125px"
        HeaderText="Insert New Configuration" OnModeChanged="DetailsView1_ModeChanged">
        <Fields>
            <asp:BoundField DataField="hotMarketsSeconds" HeaderText="hotMarketsSeconds" SortExpression="hotMarketsSeconds" />
            <asp:BoundField DataField="percentage" HeaderText="percentage" SortExpression="percentage" />
            <asp:BoundField DataField="riskValue" HeaderText="riskValue" SortExpression="riskValue" />
               <asp:BoundField DataField="newMarketsPeriod" HeaderText="newMarketsPeriod" SortExpression="newMarketsPeriod" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                SortExpression="id" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="DS_Configuration" runat="server" ConnectionString="<%$ ConnectionStrings:botfair %>"
        DeleteCommand="DELETE FROM [Configuration] WHERE [id] = @id" InsertCommand="INSERT INTO [Configuration] ([newMarketsPeriod],[hotMarketsSeconds], [percentage], [riskValue]) VALUES (@newMarketsPeriod,@hotMarketsSeconds, @percentage, @riskValue)"
        SelectCommand="SELECT [newMarketsPeriod],[hotMarketsSeconds], [percentage], [riskValue], [id] FROM [Configuration]"
        UpdateCommand="UPDATE [Configuration] SET [newMarketsPeriod] = @newMarketsPeriod,[hotMarketsSeconds] = @hotMarketsSeconds, [percentage] = @percentage, [riskValue] = @riskValue WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="hotMarketsSeconds" Type="Int32" />
            <asp:Parameter Name="percentage" Type="Double" />
            <asp:Parameter Name="riskValue" Type="Int32" />
             <asp:Parameter Name="newMarketsPeriod" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="hotMarketsSeconds" Type="Int32" />
            <asp:Parameter Name="percentage" Type="Double" />
            <asp:Parameter Name="riskValue" Type="Int32" />
            <asp:Parameter Name="id" Type="Int32" />
             <asp:Parameter Name="newMarketsPeriod" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
