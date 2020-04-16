<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersComponent.ascx.cs" Inherits="HelpDesk.Web.Components.UsersComponent" %>
<asp:ListBox
    ID="ListBoxMain"
    DataTextField="key"
    DataValueField="value"
    SelectionMode="Single"
    SelectMethod="SelectValue"
    runat="server"/>