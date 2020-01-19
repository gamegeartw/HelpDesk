<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListViewEnrollAccount.ascx.cs" Inherits="HelpDesk.Components.ListViewEnrollAccount" %>
<%@ Register Src="~/Components/LabelStatusEx.ascx" TagPrefix="uc1" TagName="LabelStatusEx" %>
<div>
    <asp:DataPager runat="server" ID="DataPager1" PagedControlID="ListViewMain">
        <Fields>
            <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
            <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info btn-flat" NextPreviousButtonCssClass="btn btn-default btn-flat" NumericButtonCssClass="btn btn-default btn-flat" />
            <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
        </Fields>
    </asp:DataPager>
    <asp:Literal runat="server" ID="LiteralDesc" />

</div>
<div>
    <asp:ListView
        runat="server"
        SelectMethod="SelectList"
        UpdateMethod="UpdateList"
        ItemType="HelpDesk.ViewModels.AccountEnrollViewModel"
        OnItemDataBound="ListViewMain_OnItemDataBound"
        ID="ListViewMain">
        <LayoutTemplate>
            <table class="table table-bordered table-hover table-condensed table-responsive">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>
                            <asp:Literal runat="server" ID="HeaderDocNo" meta:resourcekey="HeaderDocNo" />
                        </th>
                        <th>
                            <asp:Literal runat="server" ID="LiteralDeptNo" meta:resourcekey="HeaderDeptNo" />
                        </th>
                        <th>
                            <asp:Literal runat="server" ID="LiteralEmpoylee" meta:resourcekey="HeaderEmpoylee" />
                        </th>
                        <th>
                            <asp:Literal runat="server" ID="LiteralStatus" meta:resourcekey="HeaderStatus" />
                        </th>
                        <th>
                            <asp:Literal runat="server" ID="LiteralEnrollDate" meta:resourcekey="HeaderEnrollDate" />
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Panel runat="server" ID="PanelBtns" Visible="False" CssClass="btn btn-group btn-group-vertical">
                        <asp:LinkButton runat="server" CssClass="btn btn-info btn-flat btn-sm" CommandName="Edit">
                            修訂進度
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" CssClass="btn btn-info btn-flat btn-sm running" CommandName="Delete" OnClientClick="return window.flag=confirm('即將刪除,是否確定?')">
                            刪除
                        </asp:LinkButton>
                    </asp:Panel>
                </td>
                <td>
                    <%#: Item.DocNo %>
                </td>
                <td>
                    <%#: Item.Employee %>
                </td>

                <td>
                    <asp:DynamicControl runat="server" ID="DynamicControlEnrollDate" DataField="EnrollDate" DataFormatString="{0:yyyy/MM/dd}" />
                </td>
                <td>
                    <uc1:LabelStatusEx runat="server" ID="LabelStatusEx" />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            目前沒有資料
        </EmptyDataTemplate>
    </asp:ListView>

</div>
