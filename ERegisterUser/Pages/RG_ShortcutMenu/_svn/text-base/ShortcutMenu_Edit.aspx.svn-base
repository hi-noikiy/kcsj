<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_ShortcutMenu.ShortcutMenu_Edit" Title="修改快捷方式"
    CodeBehind="ShortcutMenu_Edit.aspx.cs" %>

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
            var ShortcutType = document.getElementById("<%=ShortcutType_114.ClientID %>").value;
            var Type = "";
            if (ShortcutType == 1)
                Type = "TopShortcut";
            else
                if (ShortcutType == 2)
                    Type = "BigShortcut";
                else
                    if (ShortcutType == 3)
                        Type = "SmallShortcut";
            var url = "../../../Pages/Modules/selectIcon.aspx?Dir=" + Dir + "/" + Type;
            var returnIcon;
            returnIcon = OpenDialog(url, "520px", "420px");
            if (typeof (returnIcon) == 'undefined')
                return;
            var txt1 = document.getElementById("<%=ShortcutImg_114.ClientID%>");
            txt1.value = returnIcon;
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
                                    快捷方式名称<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutText_114" runat="server" MaxLength="100" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="ShortcutText_114" ErrorMessage="名称必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    快捷方式地址<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutUrl_114" runat="server" Width="80%" MaxLength="300"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                        ControlToValidate="ShortcutUrl_114" ErrorMessage="地址必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    快捷菜单类别
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ShortcutType_114" runat="server" MaxLength="500" Width="40%"
                                        AutoPostBack="true" OnSelectedIndexChanged="ShortcutType_OnSelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                             <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否重载树
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsReloadTree_114" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否弹出新窗口
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsBlank_114" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                           
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    快捷方式图片<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutImg_114" runat="server" MaxLength="200" Width="74%"></epoint:TextBox>
                                    <input class="BtnTime" onclick="openicon('ShortcutImg_114','EpointRegisterUser/Images/RegisterUser')"
                                        type="button">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                        ControlToValidate="ShortcutImg_114" ErrorMessage="图片必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
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
