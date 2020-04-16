<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeptListComponent.ascx.cs" Inherits="HelpDesk.Web.Components.DeptListComponent" %>
<asp:ListBox
    runat="server"
    OnDataBound="ListBoxMain_OnDataBound"
    ItemType="HelpDesk.Models.Dept"
    SelectMethod="SelectDepts"
    DataTextField="DisplayName"
    DataValueField="DeptNo"
    ID="ListBoxMain"/>