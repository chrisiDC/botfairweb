<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Cache.aspx.cs" Inherits="BotFair.Web.Cache" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <asp:Panel runat="server" ID="pnl1" >
 
    <%#GetTableString() %>
  </asp:Panel>
</asp:Content>
