<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSideBar1.ascx.cs" Inherits="HelpDesk.UCSideBar1" %>
<aside class="main-sidebar">
    <section class="sidebar">
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" ShowLines="True"/>
    </section>
</aside>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
