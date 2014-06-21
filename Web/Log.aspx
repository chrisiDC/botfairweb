<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Log.aspx.cs" Inherits="BotFair.Web.Log" %>

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
                <asp:CustomValidator runat="server" ID="VD_DateFrom" CssClass="validators" Display="Dynamic"
                    ErrorMessage="*" ControlToValidate="TB_DateFrom" OnServerValidate="VD_DateFrom_ServerValidate" />
            </td>
            <td>
                Message Type:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="DDL_MessageType">
                    <asp:ListItem Text="- ALL -" Value="" />
                    <asp:ListItem Text="error" />
                    <asp:ListItem Text="warning" />
                    <asp:ListItem Text="information" />
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="BT_Submit" runat="server" Text="Filter" CausesValidation="true" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GV_Log" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        DataKeyNames="id" DataSourceID="DS_Log" PageSize="30">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                SortExpression="id" />
            <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
            <asp:BoundField DataField="message" HeaderText="message" SortExpression="message" />
            <asp:BoundField DataField="eventId" HeaderText="eventId" SortExpression="eventId" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="DS_Log" runat="server" ConnectionString="<%$ ConnectionStrings:botfair %>"
        SelectCommand="SELECT * FROM [Log] ORDER BY [date] DESC" FilterExpression="date >= '{0}' and type LIKE '{1}'"
        OnFiltering="SqlDataSource1_Filtering">
        <FilterParameters>
            <asp:ControlParameter Name="date" ControlID="TB_DateFrom" PropertyName="Text" />
            <asp:ControlParameter Name="type" ControlID="DDL_MessageType" PropertyName="Text" ConvertEmptyStringToNull="true" DefaultValue="*" />
        </FilterParameters>
    </asp:SqlDataSource>
</asp:Content>
 <%--FilterExpression="date >= '{0}' and type like '{1}'"--%>