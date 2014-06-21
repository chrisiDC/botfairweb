<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="BotFair.Web.Tracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <table>
        <tr>
            <td>
                Selection:
            </td>
            <td>
                <asp:TextBox runat="server" ID="TB_Selection" />
            </td>
          
            <td><asp:Button runat="server" ID="BT_Submit" Text="Filter" CausesValidation="false" /></td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="100"
        AllowSorting="True" AutoGenerateColumns="False" 
 
        DataSourceID="SqlDataSource1">
        <Columns>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:HyperLink runat="server" NavigateUrl="<%#GetUrl(Container.DataItem) %>" Text="Follow" Target="_blank"></asp:HyperLink>
            
                 </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField DataField="marketName" HeaderText="Market" ReadOnly="True" 
                SortExpression="marketName" />
            <asp:BoundField DataField="horse" HeaderText="horse" 
                ReadOnly="True" SortExpression="horse" />
          
        </Columns>
    </asp:GridView>
   <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:botfair %>" 
        SelectCommand="select selectionId,marketId,marketName,horse from V_pricetrack group by marketid,selectionId,horse,marketName" >
         <SelectParameters>
            <asp:ControlParameter Name="marketId" ControlID="TB_Selection" PropertyName="Text" DefaultValue="0" />

        </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>
