<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListViewMeetingsComponent.ascx.cs" Inherits="HelpDesk.Components.ListViewMeetingsComponent" %>
<div class="box box-info">
    <div class="box-header with-border">
        <h3 class="box-title">線上會議清單：</h3>
    </div>
    <div class="box-body">
        <asp:DataPager runat="server" PagedControlID="ListViewMain" ID="DataPager1">
            <Fields>
                <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info" NextPreviousButtonCssClass="btn btn-default" NumericButtonCssClass="btn btn-default" PreviousPageImageUrl="btn btn-default" />
                <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
        <asp:ListView runat="server" ID="ListViewMain">
            <LayoutTemplate>
                <table class="table table-bordered table-hover table-responsive">
                    <thead>
                    <tr>
                        <th>#</th>
                        <th>日期</th>
                        <th>會議名稱</th>
                        <th>開始時間</th>
                        <th>結束時間</th>
                        <th>主持人</th>
                        <th>參加人員</th>
                        <th>建立者</th>
                    </tr>
                    </thead>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"/>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
