<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelpDesk.Web._Default" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>
<%@ Register Src="~/Components/StatusComponent.ascx" TagPrefix="uc1" TagName="StatusComponent" %>
<%@ Register Src="~/Components/DataPageComponent.ascx" TagPrefix="uc1" TagName="DataPageComponent" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="updateProgress" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="col-md-6 hide">
        <asp:UpdatePanel runat="server" ID="UpdatePanelOnCall">
            <ContentTemplate>
                <div class="box box-info">
                    <div class="box-header with-border">
                        <h3 class="box-title">報修紀錄</h3>
                    </div>
                    <div class="box-body">
                        <div style="padding-bottom: 10px">
                            <%-- <asp:DataPager runat="server" ID="DataPager2" PagedControlID="ListViewServiceOnCall"> --%>
                            <%--     <Fields> --%>
                            <%--         <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" /> --%>
                            <%--         <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info btn-flat" NextPreviousButtonCssClass="btn btn-default btn-flat" NumericButtonCssClass="btn btn-default btn-flat" /> --%>
                            <%--         <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" /> --%>
                            <%--     </Fields> --%>
                            <%-- </asp:DataPager> --%>
                            <uc1:DataPageComponent runat="server" id="DataPageComponent" PagedControlID="ListViewServiceOnCall"/>

                        </div>
                        <asp:ListView
                            runat="server"
                            ItemType="HelpDesk.Models.OnCallModel"
                            SelectMethod="SelectServiceOnCall"
                            OnItemDataBound="ListViewServiceOnCall_OnItemDataBound"
                            ID="ListViewServiceOnCall">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover table-responsive">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>日期</th>
                                            <th>單位</th>
                                            <th>工號</th>
                                            <th>姓名</th>
                                            <th>報修項目</th>
                                            <th>處理進度</th>
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
                                        <asp:DynamicHyperLink runat="server" DataField="DocNo" Text="<%#: Item.DocNo %>" NavigateUrl='<%#: Page.ResolveClientUrl("~/UserPages/OnCallDetail.aspx?DocNo=")+Item.DocNo %>' ToolTip="查看進度" Target="_blank"></asp:DynamicHyperLink>
                                    </td>
                                    <td>
                                        <asp:DynamicControl runat="server" ID="DynamicControlCreateDate" DataField="CreateTime" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" />
                                    </td>
                                    <td><%#: Item.DeptName %></td>
                                    <td><%#: Item.EmpNo %></td>
                                    <td><%#: Item.EmpName %></td>
                                    <td><%#: Item.OnCallTypeDisplayName %></td>
                                    <td>
                                        <uc1:StatusComponent runat="server" ID="StatusComponent" HelpDeskStatus="<%#: Item.ProcessStatus %>" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div class="box-footer">
                        <span class="pull-right"><a href="~/UserPages/OnCallList.aspx" runat="server">more...</a></span>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="col-md-12">

        <asp:UpdatePanel runat="server" ID="UpdatePanelTelephone">

            <ContentTemplate>
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">電話號碼查詢</h3>
                    </div>
                    <div class="box-body">
                        <div>
                            <uc1:FormSearchComponent
                                runat="server"
                                ID="FormSearchComponent"
                                ShowItems="SearchText"
                                OnSearch="FormSearchComponent_OnSearch" />
                        </div>
                        <div style="padding-bottom: 10px">
                            <asp:DataPager PageSize="5" runat="server" ID="DataPager1" PagedControlID="ListViewMain">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info btn-flat" NextPreviousButtonCssClass="btn btn-default btn-flat" NumericButtonCssClass="btn btn-default btn-flat" />
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>

                            </asp:DataPager>
                        </div>
                        <asp:ListView
                            ID="ListViewMain"
                            ItemType="Landpy.ActiveDirectory.Entity.Object.UserObject"
                            SelectMethod="SelectValue"
                            runat="server">
                            <LayoutTemplate>
                                <table class="table table-responsive table-hover table-bordered">
                                    <thead>
                                        <tr class="bg-aqua">
                                            <th>單位</th>
                                            <th>姓名</th>
                                            <th>連絡電話</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#: Item.Department %></td>
                                    <td><%#: Item.DisplayName %></td>
                                    <td>
                                        <asp:DynamicControl runat="server" DataField="Telephone" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
