<%@ Page Title="線上會議" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MeetingForm.aspx.cs" Inherits="HelpDesk.UserPages.MeetingForm" %>

<%@ Register Src="~/Components/ListViewMeetingsComponent.ascx" TagPrefix="uc1" TagName="ListViewMeetingsComponent" %>
<%@ Register Src="~/Components/ButtonListComponent.ascx" TagPrefix="uc1" TagName="ButtonListComponent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="margin-bottom">
        <uc1:ButtonListComponent BtnType="Large" ShowBtns="Create" runat="server" id="ButtonListComponent" />
    </div>
    <uc1:ListViewMeetingsComponent runat="server" id="ListViewMeetingsComponent"/>
    
    <asp:Panel runat="server" ID="PanelDesign" Visible="False">
        <asp:FormView runat="server" ID="FormViewMain" RenderOuterTable="False">
            <ItemTemplate>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-12 col-xs-12">日期:</label>
                        <div class="col-md-9 col-sm-12 col-xs-12">
                            <asp:TextBox runat="server" CssClass="form-control" ID="TextBoxMeetingDate"/>
                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender" TargetControlID="TextBoxMeetingDate"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:FormView>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
