<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnCallList.aspx.cs" Inherits="HelpDesk.Web.UserPages.OnCallList" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormSearchComponent runat="server" ID="FormSearchComponent" ShowItems="SearchText" />

    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">報修明細</h3>
        </div>
        <div class="box-body">
            <div style="padding-bottom: 10px">
                <asp:DataPager runat="server" ID="DataPager1"></asp:DataPager>
            </div>
            <div>
                <asp:ListView
                    ItemType="HelpDesk.Models.OnCallModel"
                    runat="server"
                    SelectMethod="SelectValue"
                    ID="ListViewMain"></asp:ListView>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
