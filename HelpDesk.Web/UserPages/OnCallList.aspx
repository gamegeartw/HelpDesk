<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnCallList.aspx.cs" Inherits="HelpDesk.Web.UserPages.OnCallList" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>
<%@ Register Src="~/Components/StatusComponent.ascx" TagPrefix="uc1" TagName="StatusComponent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormSearchComponent runat="server" ID="FormSearchComponent" ShowItems="SearchText" OnSearch="FormSearchComponent_OnSearch" />
    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">報修案件清單</h3>
        </div>
        <div class="box-body">
            <div>
                <asp:DataPager runat="server" ID="DataPager1" PagedControlID="ListViewMain">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info btn-flat" NextPreviousButtonCssClass="btn btn-default btn-flat" NumericButtonCssClass="btn btn-default btn-flat" />
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>

                </asp:DataPager>
            </div>
            <asp:ListView 
                ItemType="HelpDesk.Models.OnCallModel"
                SelectMethod="SelectValue"
                OnItemCommand="ListViewMain_OnItemCommand"
                runat="server" 
                ID="ListViewMain">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover table-responsive">
                        <thead>
                        <tr>
                            <th>#</th>
                            <th>編號</th>
                            <th>送修單位</th>
                            <th>送修人員</th>
                            <th>送修時間</th>
                            <th>處理人員</th>
                            <th>目前進度</th>
                        </tr>
                        </thead>
                        <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"/>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HyperLink runat="server" ID="HyperLinkDetail" CssClass="btn btn-info btn-sm btn-flat" NavigateUrl='<%#: "OnCallDetail.aspx?DocNo="+ Item.DocNo %>'>
                                <i class="fa fa-list"></i>明細
                            </asp:HyperLink>
                            
                            <asp:HyperLink runat="server" ID="HyperLinkReport" CssClass="btn btn-default btn-sm btn-flat" NavigateUrl='<%#: "OnCallReply.aspx?DocNo="+ Item.DocNo %>'>
                                <i class="fa fa-mail-reply"></i>回報
                            </asp:HyperLink>

                            <asp:LinkButton runat="server" ID="LinkButtonClose" CommandName="CloseReport" CommandArgument="<%#:Item.Id %>" CssClass="btn btn-primary btn-sm btn-flat">
                                <i class="fa fa-save"></i>結案
                            </asp:LinkButton>
                        </td>
                        <td><%#: Item.DocNo %></td>
                        <td><%#: Item.DeptNo %>-<%#: Item.DeptName %></td>
                        <td><%#: Item.EmpNo %>-<%#: Item.EmpName%></td>
                        <td><asp:DynamicControl runat="server" ID="DynamicControlDate" DataField="CreateTime" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}"/></td>
                        <td><%#: Item.ProcessUser %></td>
                        <td>
                            <uc1:StatusComponent runat="server" ID="StatusComponent" HelpDeskStatus="<%#: Item.ProcessStatus %>" />
                            
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
