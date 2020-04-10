<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ButtonListComponent.ascx.cs" Inherits="HelpDesk.Web.Components.ButtonListComponent" %>
<div class="btn btn-group">
    <asp:LinkButton OnCommand="LinkButton_OnCommand" runat="server" ID="LinkButtonDetail" CommandName="Detail" CssClass="btn btn-flat btn-info" Visible="False">
        <i class="fa fa-list"></i>明細(Detail)
    </asp:LinkButton>
    <asp:LinkButton OnCommand="LinkButton_OnCommand" runat="server" ID="LinkButtonCreate" CommandName="Create" CssClass="btn btn-flat btn-info" Visible="False">
        <i class="fa fa-save"></i>建檔(Create)
    </asp:LinkButton>
    <asp:LinkButton OnCommand="LinkButton_OnCommand" runat="server" ID="LinkButtonInsert" CommandName="Insert" CssClass="btn btn-flat btn-info" Visible="False" OnClientClick="return window.flag=confirm('即將新增,是否確定?(Data will insert)')">
        <i class="fa fa-plus"></i>新增(Insert)
    </asp:LinkButton>
    <asp:LinkButton OnCommand="LinkButton_OnCommand" runat="server" ID="LinkButtonEdit" CommandName="Edit" CssClass="btn btn-flat btn-warning" Visible="False">
        <i class="fa fa-edit"></i>編輯(Edit)
    </asp:LinkButton>
    <asp:LinkButton OnCommand="LinkButton_OnCommand" runat="server" ID="LinkButtonUpdate" CommandName="Update" CssClass="btn btn-flat btn-warning" Visible="False" OnClientClick="return window.flag=confirm('即將更新,是否確定?(Data will update)')">
        <i class="fa fa-upload"></i>更新(Update)
    </asp:LinkButton>
    <asp:LinkButton OnCommand="LinkButton_OnCommand" runat="server" ID="LinkButtonDelete" CommandName="Delete" CssClass="btn btn-flat btn-danger" Visible="False" OnClientClick="return window.flag=confirm('即將刪除,是否確定?(Data will delete)')">
        <i class="fa fa-remove"></i>刪除(Delete)
    </asp:LinkButton>
    <asp:LinkButton OnCommand="LinkButton_OnCommand" runat="server" ID="LinkButtonCancel" CommandName="Cancel" CssClass="btn btn-flat btn-default" Visible="False">
        <i class="fa fa-recycle"></i>取消(Cancel)
    </asp:LinkButton>
</div>
