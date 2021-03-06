﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnCallDetailComponent.ascx.cs" Inherits="HelpDesk.Web.Components.OnCallDetailComponent" %>
<%@ Register TagPrefix="uc1" TagName="StatusComponent_1" Src="~/Components/StatusComponent.ascx" %>
<div>
    <a onclick="history.back();" class="btn btn-default btn-flat">回上一頁</a>
</div>
<div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">報修明細</h3>
        </div>
        <div class="box-body">
            <asp:FormView
                ID="FormViewMain"
                runat="server"
                ItemType="HelpDesk.Models.OnCallModel"
                SelectMethod="Select"
                RenderOuterTable="False">
                <ItemTemplate>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">案件編號(DocNo)</label>
                            <div class="col-md-4 col-sm-6 col-xs-6">
                                <asp:Literal runat="server" ID="Literal_DocNo" Text="<%#: Item.DocNo %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">報修人(EmpName)</label>
                            <div class="col-md-4 col-sm-6 col-xs-6">
                                <asp:Literal runat="server" ID="Literal1" Text="<%#: Item.EmpName %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">報修時間(Date)</label>
                            <div class="col-md-4 col-sm-6 col-xs-6">
                                <asp:DynamicControl runat="server" ID="DynamicControlDate" DataField="CreateTime" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">進度(Status)</label>
                            <div class="col-md-4 col-sm-6 col-xs-6">
                                <uc1:StatusComponent_1 runat="server" ID="StatusComponent" HelpDeskStatus="<%#: Item.ProcessStatus %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-6 col-xs-6">報修原因(Reason)</label>
                            <div class="col-md-10 col-sm-12 col-xs-12">
                                <asp:Literal runat="server" ID="Literal_OnCallReason" Text="<%#: Item.OnCallReason %>" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:FormView>

        </div>
    </div>

    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">報修進度</h3>
        </div>
        <div class="box-body">
            <asp:ListView
                runat="server"
                ItemType="HelpDesk.Models.OnCallReportModel"
                SelectMethod="SelectOnCallReportList"
                ID="ListViewMain">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover table-responsive">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>No</th>
                                <th>處理時間</th>
                                <th>處理人員</th>
                                <th>處理過程</th>
                                <th>進度</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td></td>
                        <td><%#: Item.Line %></td>
                        <td>
                            <asp:DynamicControl runat="server" ID="DynamicControl_Time" DataField="ProcessTime" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" />
                        </td>
                        <td><%#: Item.EmpName %></td>
                        <td>
                            <uc1:StatusComponent_1 runat="server" ID="StatusComponent" HelpDeskStatus="<%#: Item.ProcessStatus %>" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>


