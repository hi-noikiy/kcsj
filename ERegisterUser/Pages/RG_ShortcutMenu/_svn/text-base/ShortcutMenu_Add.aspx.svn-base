<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_ShortcutMenu.ShortcutMenu_Add" Title="添加快捷方式"
    CodeBehind="ShortcutMenu_Add.aspx.cs" %>

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
            if (returnIcon != "" && typeof (returnIcon) != "undefined") {
                if (controlName == "ShortcutImg_114") {
                    var txt1 = document.getElementById("<%=ShortcutImg_114.ClientID%>");
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
                                    快捷方式名称<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutText_114" runat="server" MaxLength="200" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="req_ShortcutText_114" runat="server" Display="Dynamic"
                                        ControlToValidate="ShortcutText_114" ErrorMessage="名称必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    快捷方式地址<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ShortcutUrl_114" runat="server" MaxLength="500" Width="80%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
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
                                    <epoint:TextBox ID="ShortcutImg_114" CssClass="inputtxt" runat="server" MaxLength="200"
                                        Width="74%"></epoint:TextBox>
                                    <%-- <asp:TextBox ID="txtbigIconAddress" CssClass="inputtxt" runat="server"></asp:TextBox>--%>
                                    <input class="BtnTime" onclick="openicon('ShortcutImg_114','EpointRegisterUser/Images/RegisterUser')"
                                        type="button">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                        ControlToValidate="ShortcutImg_114" ErrorMessage="图片必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
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
