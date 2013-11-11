<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_Module.Record_Edit" Title="修改模块" CodeBehind="Record_Edit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
        function openicon(controlName, Dir) {
            var url = "../../../Pages/Modules/selectIcon.aspx?Dir=" + Dir;
            var returnIcon;
            returnIcon = OpenDialog(url, "520px", "420px");
            if (returnIcon != "" && typeof (returnIcon) != "undefined") {
                if (controlName == "BigImgAddress_103") {
                    var txt1 = document.getElementById("<%=BigImgAddress_103.ClientID%>");
                    txt1.value = returnIcon;
                }
                else {
                    var txt1 = document.getElementById("<%=SmallImgAddress_103.ClientID%>");
                    txt1.value = returnIcon;
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
                                    模块名称<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ModuleName_103" runat="server" MaxLength="100" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="req_ModuleName_103" runat="server" Display="Dynamic"
                                        ControlToValidate="ModuleName_103" ErrorMessage="模块名称：必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trBelongtoApp" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    挂接应用系统
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="BelongToApp" runat="server" Width="80%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    模块地址
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ModuleAddress_103" runat="server" Width="80%" Height="40" MaxLength="300"
                                        TextMode="MultiLine"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    隐藏地址
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="HidUrl_103" runat="server" Width="80%" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="OrderNum_103" runat="server" Width="80%"><NumericProperty TextBoxType=Int /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否属于业务
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsBelongtoBus_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否禁用
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsForbid_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否隐藏
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsHidden_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否弹出新窗口
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsBlank_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    模块图片（大）
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="BigImgAddress_103" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <input class="BtnTime" onclick="openicon('BigImgAddress_103','Images/ModuleImages/BigIcon')"
                                        type="button">
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    模块图片（小）
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="SmallImgAddress_103" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <input class="BtnTime" onclick="openicon('SmallImgAddress_103','Images/ModuleImages/SmallIcon')"
                                        type="button">
                                </td>
                            </tr>
                            <tr>
                                <td style="display: none">
                                    <asp:RadioButtonList ID="IsBelongtoApp_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                    <%--<epoint:TextBox ID="ParentGuid_103" runat="server"></epoint:TextBox>--%>
                                    <epoint:TextBox ID="AppGuid_103" runat="server"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <span style="color: Red; padding-left: 10px">注意：隐藏地址代表用于隐式单点登录的地址。如果不需要单点登录，则把隐藏地址设为空。</span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
