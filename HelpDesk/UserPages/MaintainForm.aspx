<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintainForm.aspx.cs" Inherits="HelpDesk.UserPages.MaintainForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ListView
        runat="server"
        ID="ListViewMain">
        <LayoutTemplate>
            <table class="table table-bordered table-hover table-responsive">
                <thead>
                <tr>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
                </thead>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
