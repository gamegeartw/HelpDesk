<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnCallList.aspx.cs" Inherits="HelpDesk.Web.UserPages.OnCallList" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormSearchComponent runat="server" ID="FormSearchComponent" ShowItems="SearchText" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
