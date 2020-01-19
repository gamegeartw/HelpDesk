<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeptNoDropDownListComponent.ascx.cs" Inherits="HelpDesk.Components.DeptNoDropDownListComponent" %>
<asp:DropDownList
    ID="DropDownListMain"
    DataTextField="Key"
    DataValueField="Value"
    CssClass="form-control"
    OnDataBound="DropDownListMain_OnDataBound"
    SelectMethod="SelectDepts"
    runat="server"/>