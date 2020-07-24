<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnCallReply.aspx.cs" Inherits="HelpDesk.Web.UserPages.OnCallReply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView 
        runat="server" 
        ID="FormViewMain" 
        ItemType="HelpDesk.Models.OnCallReportModel"
        SelectMethod="SelectMain"
        InsertMethod="InsertMain"
        UpdateMethod="UpdateMain"
        RenderOuterTable="False">

    </asp:FormView>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
