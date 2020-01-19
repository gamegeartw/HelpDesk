<%@ Page
Title="首頁" 
Language="C#" 
MasterPageFile="~/Site.Master" 
AutoEventWireup="true" 
CodeBehind="Default.aspx.cs" 
meta:resourcekey="Page"
Inherits="HelpDesk._Default" %>

<%@ Register Src="~/Components/ListViewEnrollAccount.ascx" TagPrefix="uc1" TagName="ListViewEnrollAccount" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <asp:Literal runat="server" ID="LiteralEnrollCaption" meta:resourcekey="LiteralEnrollCaption"/>
                    </h3>
                </div>
                <div class="box-body">
                    <uc1:ListViewEnrollAccount runat="server" id="ListViewEnrollAccount" />
                </div>
                <div class="box-footer">
                    <div class="pull-right">
                        <a href="~/" class="btn btn-default btn-flat" runat="server">
                            <asp:Literal runat="server" ID="LiteralEnrollPage" meta:resourcekey="LiteralEnrollPage" />
                        </a>
                    </div>
                </div>
            </div>

        </div>
        
        <div class="col-md-6">
            <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">
                        <asp:Literal runat="server" ID="LiteralComputerCaption" meta:resourcekey="LiteralComputerCaption"/>
                    </h3>
                </div>
                <div class="box-body">
                    <div>
                        None...

                    </div>
                </div>
            
                <div class="box-footer">
                    <div class="pull-right">
                        <a href="~/" class="btn btn-default btn-flat"  runat="server">
                            <asp:Literal runat="server" ID="LiteralComputer" meta:resourcekey="LiteralComputer" />
                        </a>
                    </div>

                </div>
            </div>
           
        </div>
    </div>
</asp:Content>
