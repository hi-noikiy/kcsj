<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.RG_Role.Record_Edit" Title="修改角色" CodeBehind="Record_Edit.aspx.cs" %>

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
                <tr style="display: none">
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                        align="center" valign="middle">
                        <%=ViewState ["TableName"]%>
                    </td>
                </tr>
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center" id="tabContent">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    角色名称<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="RoleName_98" runat="server" MaxLength="200" Width="60%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="req_RoleName_98" runat="server" Display="Dynamic"
                                        ControlToValidate="RoleName_98" ErrorMessage="角色名称：必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    RG_会员类别<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="UserType_98" runat="server" Width="45%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    是否默认角色<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsDefault_98" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <td style="display: none">
                               <%-- <epoint:TextBox ID="UserType_98" runat="server" MaxLength="50"></epoint:TextBox>--%>
                            </td>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
