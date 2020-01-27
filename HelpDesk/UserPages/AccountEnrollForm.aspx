<%@ Page Title="帳號需求申請單" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountEnrollForm.aspx.cs" Inherits="HelpDesk.UserPages.AccountEnrollForm" %>

<%@ Register Src="~/Components/DeptNoDropDownListComponent.ascx" TagPrefix="uc1" TagName="DeptNoDropDownListComponent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:FormView
                runat="server"
                DefaultMode="Insert"
                RenderOuterTable="False"
                ItemType="HelpDesk.ViewModels.AccountEnrollViewModel"
                ID="FormViewMain">
                <InsertItemTemplate>
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <h3>豐達科技股份有限公司<small>帳號需求申請單(New Account Application)</small></h3>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="control-label col-md-2">申請部門:</label>
                                    <div class="col-md-4">
                                        <uc1:DeptNoDropDownListComponent runat="server" id="DeptNoDropDownListComponent" />
                                    </div>
                                    <label class="control-label col-md-2">需求日期:</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="TextBoxRequireDate" />
                                        <ajaxToolkit:CalendarExtender runat="server" Format="yyyy/MM/dd" ID="CalenderExtender" TargetControlID="TextBoxRequireDate" />

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="box-body">
                            <table class="table table-bordered table-responsive">
                                <tr>
                                    <th>需求類別:</th>
                                    <td>
                                        <asp:RadioButtonList
                                            runat="server"
                                            ID="RadioButtonListRequireMode" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                            <Items>
                                                <asp:ListItem Text="一般" Value="7" />
                                                <asp:ListItem Text="急件" Value="3" />
                                                <asp:ListItem Text="特急件" Value="1" />
                                            </Items>
                                        </asp:RadioButtonList>

                                    </td>
                                </tr>
                                <tr>
                                    <th>驗收方式:</th>
                                    <td>
                                        <asp:RadioButtonList
                                            runat="server"
                                            ID="RadioButtonListFinishMode" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                            <Items>
                                                <asp:ListItem Text="主管驗收" Value="1" />
                                                <asp:ListItem Text="使用者驗收" Value="0" />
                                            </Items>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="CheckBoxAllowADAccount" OnCheckedChanged="CheckBox_OnCheckedChanged" />
                                            申請AD帳號(
                                                <a data-toggle="modal" data-target="#modal-default">
                                                    說明
                                                </a>):
                                            </label>
                                        </div>
                                        
                                    </th>
                                    <td>
                                        <asp:Panel runat="server" ID="PanelAllowADAccount">

                                       
                                        <div id="showADaccountPanel">
                                            <br />
                                            <div class="form-horizontal">
                                                <div class="form-group">
                                                    <label class="control-label col-md-2" title="(請填工號)">申請人:</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox
                                                            runat="server"
                                                            Enabled="False"
                                                            CssClass="form-control bg-yellow"
                                                            ID="TextBoxEmpNo" />
                                                    </div>
                                                    <br />
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label col-md-2">帳號:</label>
                                                    <div class="col-md-4">
                                                        <asp:TextBox 
                                                            runat="server" 
                                                            ID="TextBoxADAccount" 
                                                            Enabled="False"
                                                            Text="<%#: BindItem.ADAccount %>" 
                                                            CssClass="form-control bg-yellow" />
                                                    </div>

                                                    <label class="control-label  col-md-2">密碼:</label>
                                                    <div class="col-md-4">
                                                        <asp:TextBox
                                                            runat="server"
                                                            ID="ADPassword"
                                                            TextMode="Password"
                                                            Enabled="False"
                                                            Text="<%#: BindItem.ADPassword %>"
                                                            CssClass="form-control bg-yellow" />
                                                    </div>
                                                    <br />
                                                </div>

                                                <div class="form-group">
                                                    <label class="control-label col-md-2">
                                                        <a href="#" title="※詳情請參閱電子郵件管理辦法(QP2103)">E-MAIL空間:</a>

                                                    </label>
                                                    <div class="col-md-10">
                                                        <div class="input-group">
                                                            <asp:TextBox
                                                                runat="server"
                                                                Enabled="False"
                                                                CssClass="form-control bg-yellow"
                                                                ID="TextBoxEmailQuota"
                                                                Text="<%#:BindItem.EmailQuota %>" />
                                                            <span class="input-group-addon">MB</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        </asp:Panel>
                                        </td>
                                </tr>
                                <tr>
                                    <th>
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="CheckBoxAllowPublicFolder" />申請【資料夾】使用權限
                                        <a href="#" data-toggle="modal" data-target="#modal-default2">(說明)</a>
                                            </label>
                                        </div>
                                    </th>
                                    <td>
                                        <asp:Panel runat="server" ID="PanelAllowPublicFolder">

                                        <div id="showPublicFolderPanel">
                                            <div class="form-horizontal">
                                                <div class="form-group">
                                                    <label class="control-label col-md-2">路徑:</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox
                                                            runat="server"
                                                            Enabled="False"
                                                            CssClass="form-control bg-yellow"
                                                            Text="<%#: BindItem.PublicFolderPath %>"
                                                            ID="TextBoxPublicFolder" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        </asp:Panel>

                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="CheckBoxAllowInternet" /><span title="※需理級主管簽核">申請網際網路使用</span><a data-toggle="modal" data-target="#modal-default3">(說明)</a>

                                            </label>
                                        </div>
                                    </th>
                                    <td>
                                        <asp:Panel runat="server" ID="PanelAllowInternet">
                                            <div class="form-horizontal">
                                                <div class="form-group">
                                                    <label class="control-label col-md-2">需求原因:</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox
                                                            runat="server"
                                                            Enabled="False"
                                                            CssClass="form-control bg-yellow"
                                                            ID="TextBoxRequireReason"
                                                            Text="<%#: BindItem.RequireInternetReason %>" />

                                                    </div>
                                                </div>
                                            </div>

                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="CheckBoxAllowTMS" />TMS權限申請
                                            </label>
                                        </div>
                                    </th>
                                    <td>預設開放所屬單位權限，跨單位請會簽負責人</td>
                                </tr>
                                <tr>
                                    <th>
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="CheckBoxIsExtraEnroll" />其他
                                            </label>
                                        </div>
                                    </th>
                                    <td>
                                        <asp:Panel runat="server" ID="PanelIsExtraEnroll">
                                            <div class="form-horizontal">
                                                <div class="form-group">
                                                    <label class="control-label col-md-2">需求:</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox
                                                            runat="server"
                                                            ID="TextBoxExtraEnroll"
                                                            Enabled="False"
                                                            CssClass="form-control bg-yellow"
                                                            Text="<%#: BindItem.ExtraEnroll %>" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label col-md-2">原因:</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox
                                                            runat="server"
                                                            ID="TextBoxExtraEnrollReason"
                                                            Enabled="False"
                                                            CssClass="form-control bg-yellow"
                                                            Text="<%#: BindItem.ExtraEnrollReason %>" />
                                                    </div>
                                                </div>
                                            </div>

                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="box-footer">
                            <div class="btn btn-group">
                                <asp:LinkButton runat="server" ID="LinkButtonSubmit" CssClass="btn btn-flat btn-primary running" OnClientClick="return window.flag=confirm('即將送出,是否確定?')">送出申請單</asp:LinkButton>
                                <input type="reset" class="btn btn-default btn-flat"/>
                            </div>
                        </div>
                    </div>
                </InsertItemTemplate>
            </asp:FormView>
        </div>
    </div>
    
<!-- Modal Group-->

<!--AD說明 -->
<div class="modal fade" id="modal-default">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">申請說明</h4>
            </div>
            <div class="modal-body">
                <ul>
                    <li>帳號命名規則:如英文名.英文姓,例如「jack.lin」</li>
                    <li>密碼規則：8碼以上(含)，需同時存在---英文字母大寫、小寫、數字, 例如Nafco12345</li>
                    <li>申請單不填密碼或不符規則，預設將設Nafco12345,但會強迫第一次登入更改密碼。</li>
                    <li>※詳情請參閱電子郵件管理辦法(QP2103)</li>
                </ul>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->
    
<div class="modal fade" id="modal-default2">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">申請說明</h4>
            </div>
            <div class="modal-body">
                <ul>
                    <li>預設開放所屬單位資料夾權限，開啟專案資料夾或跨單位資料夾請會簽負責人，並註明讀或寫的權限。</li>
                    <li>詳情請參閱資料夾管理辦法(QP2107)</li>
                </ul>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
    
<div class="modal fade" id="modal-default3">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">申請說明</h4>
            </div>
            <div class="modal-body">
                <ul>
                    <li>Internet權限需理級主管簽核。</li>
                    <li>Oracle ERP權限申請網址：<a href="http://webap224.getac.com.tw/erp_ad_apply_v3/login.aspx?groupid=A" target="_blank">按這裡申請</a> </li>
                    <li>內網申請權限:<a target="_blank" href="http://mis.nafco.com.tw">按這裡申請</a></li>
                </ul>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
