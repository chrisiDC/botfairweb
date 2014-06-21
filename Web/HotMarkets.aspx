<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotMarkets.aspx.cs" Inherits="BotFair.Web.HotMarkets" %>
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
  <asp:GridView ID="GV_HotMarkets" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" 
            DataSourceID="DS_HotMarkets" PageSize="30" EmptyDataText="No Markets In Database">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                    SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
           
          
                <asp:BoundField DataField="date" HeaderText="eventDate" 
                    SortExpression="date" />
            
            
          
    
      
      
         
                <asp:BoundField DataField="country" HeaderText="country" 
                    SortExpression="country" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="DS_HotMarkets" runat="server" 
            ConnectionString="<%$ ConnectionStrings:botfair %>" 
            SelectCommand="SELECT * FROM [V_HotMarkets] ORDER BY [date] DESC"  FilterExpression="date >= '{0}'" onfiltering="SqlDataSource1_Filtering">
            <FilterParameters>
            <asp:ControlParameter Name="eventDate" ControlID="TB_DateFrom" PropertyName="Text" />
        </FilterParameters>
        </asp:SqlDataSource>
</asp:Content>
