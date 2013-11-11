<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_Application.RG_Application_Add" Title="添加应用子系统"
    CodeBehind="RG_Application_Add.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="epoint" %>
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
                var txt1 = document.getElementById("<%=ShortcutImg_118.ClientID%>");
                txt1.value = returnIcon;
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
                            <epoint:Button ID="btnAdd" runat="server" Text="添加保存" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnAdd_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="取消添加" runat="server" CausesValidation="false" OnClientClick="window.close();">
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
                                    系统名称<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="AppName_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="AppName_118"
                                        Display="Dynamic" runat="server" ErrorMessage="系统名称：必填！"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    系统首页地址
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="AppUrl_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    隐藏地址
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="HidUrl_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    用户数据同步推送地址
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="SynTargetAddr_118" runat="server" MaxLength="100" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否禁用
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsForbid_118" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否弹出新窗口
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsBlank_118" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否顶部菜单
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsTopMenu_118" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否认可单位才可见
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="AuditedOUVisible_118" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    快捷菜单图片
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutImg_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <%-- <asp:TextBox ID="txtbigIconAddress" CssClass="inputtxt" runat="server"></asp:TextBox>--%>
                                    <input class="BtnTime" onclick="openicon('ShortcutImg_118','EpointRegisterUser/Images/RegisterUser/AppIcon')"
                                        type="button">
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    快捷菜单文字
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutText_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    排&nbsp;&nbsp;&nbsp;&nbsp;序
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="OrderNum_118" runat="server" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr id="User" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    应用系统管理员
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextTreeView ID="AppManager" runat="server" InputType="CheckBox" ImgFolds="../../../Images/TreeImages"
                                        OnTreeNodePopulate="AppManager_TreeNodePopulate" RootNodeText="应用系统管理员" DivHeight="150px"
                                        DivWidth="400px" Width="150px">
                                    </epoint:TextTreeView>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    会员Token参数名
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="TokenParam_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr id="name" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    用&nbsp;户&nbsp;名<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="UserName_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="UserName_118"
                                        Display="Dynamic" runat="server" ErrorMessage="用户名：必填！"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="pwd" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    用户密码<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="UserPwd_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="UserPwd_118"
                                        Display="Dynamic" ErrorMessage="用户密码：必填！"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: none">
                                    <epoint:TextBox ID="AppGuid_118" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="ParentGuid_118" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="UserGuid_118" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <span style="color: Red; padding-left: 10px">注意：1.隐藏地址代表用于隐式单点登录的地址。2.只有应用系统管理员可以设置应用系统的模块。3.Token参数是指应用系统用于获取单点登录Token和应用系统服务Token的参数名称。
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                ShowMessageBox="True"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
