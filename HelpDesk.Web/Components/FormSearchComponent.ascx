<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormSearchComponent.ascx.cs" Inherits="HelpDesk.Web.Components.FormSearchComponent" %>
<div class="box box-info">
    <div class="box-header with-border">
        <h3 class="box-title">搜尋選項:</h3>
    </div>
    <div class="box-body">
        <asp:Panel runat="server" ID="PanelMain">
            <div class="form-inline">
                <asp:Panel runat="server" ID="PanelSearchText" CssClass="form-group" Visible="False">
                    <label class="control-label">關鍵字查詢:</label>
                    <asp:TextBox runat="server" ID="TextBoxSearchText" CssClass="form-control"/>
                </asp:Panel>
                <asp:Panel runat="server" ID="PanelStartDate" CssClass="form-group" Visible="False">
                    <label class="control-label">開始日期：</label>
                    <asp:TextBox runat="server" ID="TextBoxStartDate" CssClass="form-control"/>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderStartDate" runat="server" TargetControlID="TextBoxStartDate"/>
                </asp:Panel>
                <asp:Panel runat="server" ID="PanelCloseDate" CssClass="form-group" Visible="False">
                    <label class="control-label">開始日期：</label>
                    <asp:TextBox runat="server" ID="TextBoxCloseDate" CssClass="form-control"/>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderCloseDate" runat="server" TargetControlID="TextBoxCloseDate"/>
                </asp:Panel>
                <div class="form-group">
                    <asp:LinkButton runat="server" ID="LinkButtonSubmit" OnClick="LinkButtonSubmit_OnClick" CssClass="btn btn-flat btn-info">
                        <i class="fa fa-search"></i>查詢
                    </asp:LinkButton>
                </div>
            </div>

        </asp:Panel>

    </div>
</div>
