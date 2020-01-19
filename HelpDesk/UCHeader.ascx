﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeader.ascx.cs" Inherits="HelpDesk.UCHeader" %>
<header class="main-header">
    <!-- Logo -->
    <a href="~/" runat="server" id="hrefHome" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>H</b>elp</span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><b>Help</b>Desk</span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
      </a>
    <div class="collapse navbar-collapse pull-right" id="navbar-collapse">
        <ul class="nav navbar-nav">
            <li><a href="#">
                <asp:Literal runat="server" ID="LiteralChangeLng" meta:resourcekey="LiteralChangeLng"/>
            </a></li>
            <li>
                <div style="margin-top: 8px">
                    <div class="form-inline">
                        <asp:DropDownList 
                            runat="server" 
                            CssClass="form-control runningDDL"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="DropDownListLng_OnSelectedIndexChanged"
                            ID="DropDownListLng">
                            <Items>
                                <asp:ListItem Text="中文(繁體)" Value="zh-TW"/>
                                <asp:ListItem Text="中文(簡体)" Value="zh-CHS"/>
                                <asp:ListItem Text="英文(Eng)" Value="en-US"/>
                            </Items>
                        </asp:DropDownList>
                    </div>

                </div>

            </li>
            <li class="active"><a href="#">Link <span class="sr-only">(current)</span></a></li>
            <li><a href="#">Link</a></li>
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                <ul class="dropdown-menu" role="menu">
                    <li><a href="#">Action</a></li>
                    <li><a href="#">Another action</a></li>
                    <li><a href="#">Something else here</a></li>
                    <li class="divider"></li>
                    <li><a href="#">Separated link</a></li>
                    <li class="divider"></li>
                    <li><a href="#">One more separated link</a></li>
                </ul>
            </li>
        </ul>

    </div>    
    

    </nav>
  </header>