<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataPageComponent.ascx.cs" Inherits="HelpDesk.Web.Components.DataPageComponent" %>
<div>
    <asp:DataPager runat="server" ID="DataPager1">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
            <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info btn-flat" NextPreviousButtonCssClass="btn btn-default btn-flat" NumericButtonCssClass="btn btn-default btn-flat" />
            <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
        </Fields>

    </asp:DataPager>
</div>