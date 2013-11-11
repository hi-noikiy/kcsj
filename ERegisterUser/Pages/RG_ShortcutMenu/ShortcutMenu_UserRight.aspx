<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="ShortcutMenu_UserRight.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_ShortcutMenu.ShortcutMenu_UserRight"
    EnableEventValidation="false" Title="账号授权" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script language="javascript" type="text/javascript">
        function delUserChecked() {
            var options = document.getElementById("<%=lstUser.ClientID %>").options;
            for (k = 0; k < options.length; k++) {
                if (options[k].selected) {
                    options[k] = null; k--;
                }
            }
            options = document.getElementById("<%=lstUser.ClientID %>").options;
            var temp = "";
            var temp2 = "";
            for (i = 0; i < options.length; i++) {
                temp = temp + options[i].value + ";";
            }
            document.getElementById("<%=HidUserList.ClientID %>").value = temp;
            document.getElementById("<%=HidUserNameList.ClientID %>").value = temp2;
        }
        function delUserAll() {
            var options = document.getElementById("<%=lstUser.ClientID %>").options;
            for (i = 0; i < options.length; i++) {
                options[i] = null; i--;
            }
            document.getElementById("<%=HidUserList.ClientID %>").value = "";
            document.getElementById("<%=HidUserNameList.ClientID %>").value = "";
        }   
    </script>

    <div id="Div_ControlNoTop">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <cc1:Button ID="btnSave" runat="server" MouseOverClass="ButtonSave" CssClass="ButtonSaveNoBg"
                        Text="保存设置" OnClick="btnSave_Click"></cc1:Button>
                </td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnAddIpt"
                        OnClientClick="window.close();" runat="server" Text="取消设置" />
                    <asp:HiddenField ID="HidUserList" runat="server" />
                    <asp:HiddenField ID="HidUserNameList" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" align="center">
        <tr>
            <td valign="top" height="380px">
             <%--   <fieldset>
                    <legend>用户权限</legend>--%>
                    <table height="100%" width="100%" align="center" height="380px">
                        <tr>
                            <td width="49%" class="TableSpecial" height="380px">
                                <fieldset>
                                    <iframe id="Iframe1" name="mailUser" src='../RG_Module/GetUserTree.aspx' frameborder="0" width="100%"
                                        scrolling="auto" height="380px"></iframe>
                                </fieldset>
                            </td>
                            <td width="2%" class="TableSpecial1" height="380px">
                            </td>
                            <td width="49%" class="TableSpecial" height="380px">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:ListBox ID="lstUser" runat="server" Width="100%" SelectionMode="Multiple" Height="360px">
                                            </asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <input id="Button1" type="button" onmouseout="this.className='ButtonDelNoBg'" onmouseover="this.className='ButtonDel'"
                                                class="ButtonDelNoBg" value="删   除" onclick="delUserChecked();" />
                                        </td>
                                        <td align="center">
                                            <input id="Button2" type="button" onmouseout="this.className='ButtonConNoBg'" onmouseover="this.className='ButtonCon'"
                                                class="ButtonConNoBg" value="清   空" onclick="delUserAll();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
               <%-- </fieldset>--%>
            </td>
        </tr>
    </table>
</asp:Content>
