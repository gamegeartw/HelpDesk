<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnCallReportComponent.ascx.cs" Inherits="HelpDesk.Web.Components.OnCallReportComponent" %>
<div class="box box-info">
    <div class="box-header with-border">
        <h3 class="box-title">執行進度</h3>
    </div>
    <div class="box-body">
        <div>
            <asp:DataPager runat="server" ID="DataPager1">
                <Fields>
                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info btn-flat" NextPreviousButtonCssClass="btn btn-default btn-flat" NumericButtonCssClass="btn btn-default btn-flat" />
                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>
        </div>
        <div>
            <asp:ListView
                runat="server"
                ItemType="HelpDesk.Models.OnCallReport"
                ID="ListViewMain">

            </asp:ListView>
        </div>
    </div>
</div>
