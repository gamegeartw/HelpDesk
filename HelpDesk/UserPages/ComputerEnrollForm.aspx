<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComputerEnrollForm.aspx.cs" Inherits="HelpDesk.UserPages.ComputerEnrollForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:FormView 
                ID="FormViewMain"
                DefaultMode="Insert"
                InsertMethod="InsertForm"
                RenderOuterTable="False"
                ItemType="HelpDesk.ViewModels.ComputerEnrollViewModel"
                runat="server">

            </asp:FormView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
