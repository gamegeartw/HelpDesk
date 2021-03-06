﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="HelpDesk.Web.SideBar" %>
<!-- Left side column. contains the logo and sidebar -->
<aside class="main-sidebar">

    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
        <ul class="sidebar-menu" data-widget="tree">
            <li class="header">HEADER</li>
        </ul>
        <asp:TreeView
            ID="TreeView1"
            runat="server" 
            DataSourceID="SiteMapDataSource1">
            <RootNodeStyle Width="208px" />
            <LeafNodeStyle Width="208px" />

        </asp:TreeView>
        <!-- Sidebar user panel (optional) -->
        <%-- <div class="user-panel"> --%>
        <%--     <div class="pull-left image"> --%>
        <%--         <img src="Images/User.png" class="img-circle" alt="User Image"> --%>
        <%--     </div> --%>
        <%--     <div class="pull-left info"> --%>
        <%--         <p>Alexander Pierce</p> --%>
        <%--         <!-- Status --> --%>
        <%--         <a href="#"><i class="fa fa-circle text-success"></i> Online</a> --%>
        <%--     </div> --%>
        <%-- </div> --%>

        <!-- search form (Optional) -->
        <%-- <div> --%>
        <%--     <div class="input-group"> --%>
        <%--         <input type="text" name="q" class="form-control" placeholder="Search..."> --%>
        <%--         <span class="input-group-btn"> --%>
        <%--             <button type="submit" name="search" id="search-btn" class="btn btn-flat"><i class="fa fa-search"></i> --%>
        <%--             </button> --%>
        <%--         </span> --%>
        <%--     </div> --%>
        <%-- </div> --%>
        <!-- /.search form -->

        <!-- Sidebar Menu -->
        <%-- <ul class="sidebar-menu" data-widget="tree"> --%>
        <%--     <li class="header">HEADER</li> --%>
        <%--     <!-- Optionally, you can add icons to the links --> --%>
        <%--     <li class="active"><a href="#"><i class="fa fa-link"></i> <span>Link</span></a></li> --%>
        <%--     <li><a href="#"><i class="fa fa-link"></i> <span>Another Link</span></a></li> --%>
        <%--     <li class="treeview"> --%>
        <%--         <a href="#"><i class="fa fa-link"></i> <span>Multilevel</span> --%>
        <%--             <span class="pull-right-container"> --%>
        <%--                 <i class="fa fa-angle-left pull-right"></i> --%>
        <%--             </span> --%>
        <%--         </a> --%>
        <%--         <ul class="treeview-menu"> --%>
        <%--             <li><a href="#">Link in level 2</a></li> --%>
        <%--             <li><a href="#">Link in level 2</a></li> --%>
        <%--         </ul> --%>
        <%--     </li> --%>
        <%-- </ul> --%>
        <!-- /.sidebar-menu -->
    </section>
    <!-- /.sidebar -->
</aside>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server"/>
