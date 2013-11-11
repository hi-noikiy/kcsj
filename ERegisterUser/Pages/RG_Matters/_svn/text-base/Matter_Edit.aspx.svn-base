<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.RG_Matters.Matter_Edit" Title="修改事项" CodeBehind="Matter_Edit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
    </script>
    <epoint:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <epoint:Button ID="btnEdit" runat="server" Text="修改保存" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnEdit_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="取消修改" runat="server" CausesValidation="false" OnClientClick="window.close();">
                            </epoint:Button>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center" id="tabContent">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否默认
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsDefault_131" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="statusSel_Changed">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr id="MatterNameSel" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    事项内容
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="dplMatterName" runat="server" Width="50%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    事项名称<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="MatterName_131" runat="server" MaxLength="100"></epoint:TextBox>
                                </td>
                                <asp:RequiredFieldValidator ID="req_MatterName_131" runat="server" Display="Dynamic"
                                    ControlToValidate="MatterName_131" ErrorMessage="事项名称：必填！" EnableClientScript="true"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    所属应用系统
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="App" runat="server" Width="50%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="trIsHangPage" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    是否挂接页面
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsHangPage_131" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    事项地址
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="MatterUrl_131" runat="server" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr id="trInstr" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    说明页面Url
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="InstrUrl_131" runat="server" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="OrderNum_131" runat="server"><NumericProperty TextBoxType=Int /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否禁用
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsForbidden_131" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否弹出
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsBlank_131" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否隐藏
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsHidden_131" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial" width="100%" colspan="3">
                                    说明内容：
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial" width="100%" style="height: 100% !important;" align="left"
                                    colspan="4" bgcolor="red" valign="top">
                                    <FCKeditorV2:FCKeditor ID="Content" BasePath="~/FCKeditor/" Height="290px" runat="server">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <font color="red">注：常规事项的所属应用系统在第三级配，如果为空则属于直接挂接的事项。一级事项如果选择了挂接页面，则首页元件中挂接的是第三方系统的事项页面，在事项地址中填写相应的访问地址。如果挂接页面为否但是配了应用系统，则下面挂的是该应用系统的模块，不要再为其加子事项，名称最好也和应用系统对应。</font>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <epoint:TextBox ID="UniqueID_131" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="ParentGuid_131" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="AppGuid_131" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="Instruction_131" runat="server"></epoint:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
