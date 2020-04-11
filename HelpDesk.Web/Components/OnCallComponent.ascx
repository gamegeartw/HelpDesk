<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnCallComponent.ascx.cs" Inherits="HelpDesk.Web.Components.OnCallComponent" %>
<asp:DropDownList
    DataTextField="key"
    DataValueField="value"
    CssClass="form-control"
    SelectMethod="SelectList"
    runat="server"/>