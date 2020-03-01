<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ButtonListComponent.ascx.cs" Inherits="HelpDesk.Components.ButtonListComponent" %>
<asp:Panel runat="server" ID="PanelLarge">
    <asp:LinkButton runat="server" OnCommand="OnCommand" CommandName="Create" ID="LinkButtonCreate" CssClass="btn btn-flat btn-primary"><i class="fa fa-file-o"></i>建立(Create)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" CommandName="Insert" ID="LinkButtonInsert" CssClass="btn btn-flat btn-primary running" OnClientClick="return window.flag=confirm('即將新增,是否確定?\n(Data will insert,confirm?)')"><i class="fa fa-file-o"></i>新增(Insert)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" Command="Edit" ID="LinkButtonEdit" CssClass="btn btn-flat btn-info"><i class="fa fa-file-o"></i>修改(Edit)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" Command="Update" ID="LinkButtonUpdate" CssClass="btn btn-flat btn-info running" OnClientClick="return window.flag=confirm('即將更新,是否確定?\n(Data will update,confirm?)')"><i class="fa fa-file-o"></i>更新(Update)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" Command="Delete" ID="LinkButtonDelete" CssClass="btn btn-flat btn-warning running" OnClientClick="return window.flag=confirm('即將刪除,是否確定?\n(Data will delete,confirm?)')"><i class="fa fa-file-o"></i>刪除(Delete)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" Command="Search" ID="LinkButtonSearch" CssClass="btn btn-flat btn-success"><i class="fa fa-file-o"></i>搜尋(Search)</asp:LinkButton>
</asp:Panel>

<asp:Panel runat="server" ID="PanelSmall" Visible="False">
    <asp:LinkButton runat="server" OnCommand="OnCommand" CommandName="Create" ID="LinkButtonCreateS" CssClass="btn btn-flat btn-sm btn-primary"><i class="fa fa-file-o"></i>建立(Create)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" CommandName="Insert" ID="LinkButtonInsertS" CssClass="btn btn-flat btn-sm btn-primary" OnClientClick="return window.flag=confirm('即將新增,是否確定?\n(Data will insert,confirm?)')"><i class="fa fa-file-o"></i>新增(Insert)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" Command="Edit" ID="LinkButtonEditS" CssClass="btn btn-flat btn-sm btn-info"><i class="fa fa-file-o"></i>修改(Edit)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" Command="Update" ID="LinkButtonUpdateS" CssClass="btn btn-flat btn-sm btn-info" OnClientClick="return window.flag=confirm('即將更新,是否確定?\n(Data will update,confirm?)')"><i class="fa fa-file-o"></i>更新(Update)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" Command="Delete" ID="LinkButtonDeleteS" CssClass="btn btn-flat btn-sm btn-warning" OnClientClick="return window.flag=confirm('即將刪除,是否確定?\n(Data will delete,confirm?)')"><i class="fa fa-file-o"></i>刪除(Delete)</asp:LinkButton>
    <asp:LinkButton runat="server" OnCommand="OnCommand" Command="Search" ID="LinkButtonSearchS" CssClass="btn btn-flat btn-sm btn-success"><i class="fa fa-file-o"></i>搜尋(Search)</asp:LinkButton>
</asp:Panel>