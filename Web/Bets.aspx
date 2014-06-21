<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bets.aspx.cs" Inherits="BotFair.Web.Bets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                Date From:
            </td>
            <td>
                <asp:TextBox runat="server" ID="TB_DateFrom" />
                 <asp:CustomValidator runat="server" ID="VD_DateFrom" CssClass="validators" 
                    Display="Dynamic" ErrorMessage="*" ControlToValidate="TB_DateFrom"
                    onservervalidate="VD_DateFrom_ServerValidate" />
            </td>
            <td>
                <asp:Button ID="BT_Submit" runat="server" Text="Filter" CausesValidation="true" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GV_Bets" runat="server" AllowPaging="True" PageSize="30"
        AllowSorting="True" AutoGenerateColumns="False" DataSourceID="DS_Bets" EmptyDataText="No Bets In Database">
        <Columns>
            <asp:BoundField DataField="marketId" HeaderText="marketId" 
                SortExpression="marketId" />
         
                <asp:BoundField DataField="eventDate" HeaderText="Date" 
                SortExpression="eventDate" />
            <asp:BoundField DataField="fk_selection" HeaderText="fk_selection" 
                SortExpression="fk_selection" />
            <asp:BoundField DataField="amount" HeaderText="amount" 
                SortExpression="amount" />
            <asp:CheckBoxField DataField="isLay" HeaderText="isLay" 
                SortExpression="isLay" />
            <asp:BoundField DataField="firstPrice" HeaderText="firstPrice" 
                SortExpression="firstPrice" />
            <asp:BoundField DataField="currentPrice" HeaderText="currentPrice" 
                SortExpression="currentPrice" />
            <asp:BoundField DataField="pricePosted" HeaderText="pricePosted" 
                SortExpression="pricePosted" />
            <asp:BoundField DataField="sizePosted" HeaderText="sizePosted" 
                SortExpression="sizePosted" />
            <asp:BoundField DataField="datePosted" HeaderText="datePosted" 
                SortExpression="datePosted" />
            <asp:BoundField DataField="errorCode" HeaderText="errorCode" 
                SortExpression="errorCode" />
            <asp:BoundField DataField="betFairId" HeaderText="betFairId" 
                SortExpression="betFairId" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="DS_Bets" runat="server" 
        ConnectionString="<%$ ConnectionStrings:botfair %>" 
        SelectCommand="SELECT * FROM [V_Bets] ORDER BY [datePosted] desc" FilterExpression="datePosted >= '{0}'" onfiltering="SqlDataSource1_Filtering" >
         <FilterParameters>
            <asp:ControlParameter Name="datePosted" ControlID="TB_DateFrom" PropertyName="Text" />
        </FilterParameters>
    </asp:SqlDataSource>
</asp:Content>
