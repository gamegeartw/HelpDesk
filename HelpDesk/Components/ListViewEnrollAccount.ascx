<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListViewEnrollAccount.ascx.cs" Inherits="HelpDesk.Components.ListViewEnrollAccount" %>
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
        ID="ListViewMain">
        <LayoutTemplate>
            <table class="table table-bordered table-hover table-condensed table-responsive">
                <thead>
                <tr>
                    <th>#</th>
                    <th>
                        <asp:Literal runat="server" ID="HeaderDocNo" meta:resourcekey="HeaderDocNo"/>
                    </th>
                    <th>
                        <asp:Literal runat="server" ID="LiteralDeptNo" meta:resourcekey="HeaderDeptNo"/>
                    </th>
                    <th>
                        <asp:Literal runat="server" ID="LiteralEmpoylee" meta:resourcekey="HeaderEmpoylee"/>
                    </th>
                    <th>
                        <asp:Literal runat="server" ID="LiteralStatus" meta:resourcekey="HeaderStatus"/>
                    </th>
                    <th>
                        <asp:Literal runat="server" ID="LiteralEnrollDate" meta:resourcekey="HeaderEnrollDate"/>
                    </th>
                </tr>
                </thead>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Panel runat="server" ID="PanelBtns" Visible="False" CssClass="btn btn-group btn-group-vertical">
                        <asp:LinkButton runat="server" CssClass="btn btn-info btn-flat btn-sm" CommandName="Edit">修訂進度</asp:LinkButton>
                        <asp:LinkButton runat="server" CssClass="btn btn-info btn-flat btn-sm" CommandName="Delete">刪除</asp:LinkButton>
                    </asp:Panel>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>