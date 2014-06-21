<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Markets.aspx.cs" Inherits="BotFair.Web.Markets" %>

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
               <%-- <asp:CompareValidator runat="server" ID="VD_DateFrom" Display="Dynamic" ErrorMessage="*"
                    ControlToValidate="TB_DateFrom" Operator="DataTypeCheck" Type="Date" />--%>
                 <asp:CustomValidator runat="server" ID="VD_DateFrom" CssClass="validators" 
                    Display="Dynamic" ErrorMessage="*" ControlToValidate="TB_DateFrom"
                    onservervalidate="VD_DateFrom_ServerValidate"/>
            </td>
            <td>
                <asp:Button ID="BT_Submit" runat="server" Text="Filter" CausesValidation="true"/>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"
        DataKeyNames="id" AllowSorting="true" PageSize="30" AllowPaging="True" EmptyDataText="No Markets In Database">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="menuPath" HeaderText="menuPath" SortExpression="menuPath" />
            <asp:BoundField DataField="totalAmount" HeaderText="totalAmount" SortExpression="totalAmount" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            <asp:BoundField DataField="runners" HeaderText="runners" SortExpression="runners" />
            <asp:BoundField DataField="winners" HeaderText="winners" SortExpression="winners" />
            <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
            <asp:BoundField DataField="marketStatus" HeaderText="state" SortExpression="marketStatus" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:botfair %>"
        SelectCommand="SELECT * FROM [V_Markets] order by date asc" 
        FilterExpression="date >= '{0}'" onfiltering="SqlDataSource1_Filtering">
        <FilterParameters>
            <asp:ControlParameter Name="date" ControlID="TB_DateFrom" PropertyName="Text" />
        </FilterParameters>
    </asp:SqlDataSource>
</asp:Content>
