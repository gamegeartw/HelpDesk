<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnCallDetailComponent.ascx.cs" Inherits="HelpDesk.Web.Components.OnCallDetailComponent" %>
<%@ Register TagPrefix="uc1" TagName="StatusComponent" Src="~/Components/StatusComponent.ascx" %>
<div class="box box-info">
    <div class="box-header with-border">
        <h3 class="box-title">報修明細</h3>
    </div>
    <div class="box-body">
        <div>
            <asp:FormView
                ID="FormViewMain"
                runat="server"
                ItemType="HelpDesk.Models.OnCallModel"
                SelectMethod="Select"
                RenderOuterTable="False">
                <ItemTemplate>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">
                                <asp:Literal runat="server" ID="Literal_Label_DocNo" Text="<%$ Resources:Pages,Table_DocNo %>" />
                            </label>
                            <div class="col-md-4 col-sm-6 col-xs-6">
                                <asp:Literal runat="server" ID="Literal_DocNo" Text="<%#: Item.DocNo %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">
                                <asp:Literal runat="server" ID="Literal_Label_Employee" Text="<%$ Resources:Pages,Table_Employee %>" />
                            </label>
                            <div class="col-md-4 col-sm-6 col-xs-6">
                                <asp:Literal runat="server" ID="Literal1" Text="<%#: Item.EmpName %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">
                                
                                <asp:Literal runat="server" ID="Literal_Label_OnCallDate" Text="<%$ Resources:Pages,Table_OnCallDate %>" />
                            </label>
                            <div class="col-md-4 col-sm-6 col-xs-6">
                                <asp:DynamicControl runat="server" ID="DynamicControlDate" DataField="CreateTime" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">
                                <asp:Literal runat="server" ID="Literal_Label_Status" Text="<%$ Resources:Pages,Table_Status %>" />
                            </label>
                            <div class="col-md-4 col-sm-6 col-xs-6">
                                <uc1:StatusComponent runat="server" ID="StatusComponent" HelpDeskStatus="<%#: Item.ProcessStatus %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">
                                <asp:Literal runat="server" ID="Literal_Label_OnCallReason" Text="<%$ Resources:Pages,Table_OnCallReason %>" />
                            </label>
                            <div class="col-md-10 col-sm-12 col-xs-12">
                                <asp:Literal runat="server" ID="Literal_OnCallReason" Text="<%#: Item.OnCallReason %>" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:FormView>

        </div>
        <div>
            <div>
                <asp:DataPager runat="server" ID="DataPager1" PagedControlID="ListViewMain">
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
                    ItemType="HelpDesk.Models.OnCallReportModel"
                    ID="ListViewMain">
                    <LayoutTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th><asp:Literal runat="server" ID="Literal_Table_DocNo" Text="<%$ Resources:Pages,Table_DocNo %>"/></th>
                                    <th><asp:Literal runat="server" ID="Literal_Table_Dept" Text="<%$ Resources:Pages,Table_Dept %>"/></th>
                                    <th><asp:Literal runat="server" ID="Literal_Table_User" Text="<%$ Resources:Pages,Table_ProcessUser %>"/></th>
                                    <th><asp:Literal runat="server" ID="Literal_Table_Content" Text="<%$ Resources:Pages,Table_Content %>"/></th>
                                </tr>
                            </thead>
                        </table>
                    </LayoutTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</div>
