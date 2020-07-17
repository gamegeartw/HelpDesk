<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnCallDetailComponent.ascx.cs" Inherits="HelpDesk.Web.Components.OnCallDetailComponent" %>
<%@ Register Src="~/Components/OnCallDetailComponent.ascx" TagPrefix="uc1" TagName="OnCallDetailComponent" %>

<div class="box box-primary">
    <div class="box-header with-border">
        <h3 class="box-title"></h3>
    </div>
</div>

<uc1:OnCallDetailComponent runat="server" ID="OnCallDetailComponent" />
