<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_Application.RG_Application_Edit" Title="�޸�Ӧ����ϵͳ"
    CodeBehind="RG_Application_Edit.aspx.cs" %>

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
        function SetAppManager() {
            var userguid = document.getElementById("ctl00_ContentPlaceHolder1_AppManager_ValueAppManager").value;
            document.getElementById("<%= UserGuid_118.ClientID%>").value = userguid;
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
                            <epoint:Button ID="btnEdit" runat="server" Text="�޸ı���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnEdit_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="ȡ���޸�" runat="server" CausesValidation="false" OnClientClick="window.close();">
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
                                    ϵͳ����<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="AppName_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="AppName_118"
                                        Display="Dynamic" runat="server" ErrorMessage="ϵͳ���ƣ����"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ϵͳ��ҳ��ַ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="AppUrl_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ���ص�ַ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="HidUrl_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �û�����ͬ�����͵�ַ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="SynTargetAddr_118" runat="server" MaxLength="100" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsForbid_118" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ񵯳��´���
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsBlank_118" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ񶥲��˵�
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsTopMenu_118" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ��Ͽɵ�λ�ſɼ�
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="AuditedOUVisible_118" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ݲ˵�ͼƬ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutImg_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <input class="BtnTime" onclick="openicon('ShortcutImg_118','Images/ModuleImages/BigIcon')"
                                        type="button">
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ݲ˵�����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutText_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��&nbsp;&nbsp;&nbsp;&nbsp;��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="OrderNum_118" runat="server" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    Ӧ��ϵͳ����Ա
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextTreeView ID="AppManager" runat="server" InputType="CheckBox" ImgFolds="../../../Images/TreeImages"
                                        OnTreeNodePopulate="AppManager_TreeNodePopulate" RootNodeText="Ӧ��ϵͳ����Ա" DivHeight="150px"
                                        DivWidth="400px" Width="150px" JSFunAfterSelect="SetAppManager();">
                                    </epoint:TextTreeView>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    Token����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="TokenParam_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <%-- <tr id="trTokenValue" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    Ӧ��ϵͳ��ʶ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="AppGuid_118" ReadOnly="true" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="display: none">
                                    <epoint:TextBox ID="ParentGuid_118" runat="server"></epoint:TextBox>
                                    <epoint:TextBox ID="UserGuid_118" runat="server"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr id="name" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    ��&nbsp;��&nbsp;��<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="UserName_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="UserName_118"
                                        Display="Dynamic" runat="server" ErrorMessage="�û��������"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="pwd" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    �û�����<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="UserPwd_118" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="UserPwd_118"
                                        Display="Dynamic" ErrorMessage="�û����룺���"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <span style="color: Red; padding-left: 10px">ע�⣺1.���ص�ַ����������ʽ�����¼�ĵ�ַ��2.ֻ��Ӧ��ϵͳ����Ա��������Ӧ��ϵͳ��ģ�顣3.Token������ָӦ��ϵͳ���ڻ�ȡ�����¼Token��Ӧ��ϵͳ����Token�Ĳ������ơ�
                                    </span>
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
