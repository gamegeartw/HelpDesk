<%@ Page Title="首頁" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelpDesk._Default" %>

<%@ Register Src="~/Components/FormViewSearchComponent.ascx" TagPrefix="uc1" TagName="FormViewSearchComponent" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <asp:Literal runat="server" ID="LiteralEnrollCaption" meta:resourcekey="LiteralEnrollCaption"/>
                    </h3>
                </div>
            </div>
            <div class="box-body">

            </div>
        </div>
        
        <div class="col-md-6">
            <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <asp:Literal runat="server" ID="LiteralComputerCaption" meta:resourcekey="LiteralComputerCaption"/>
                    </h3>
                </div>
            </div>
            <div class="box-body">

            </div>
        </div>
    </div>
</asp:Content>
