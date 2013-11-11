<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="VUser_Per_Set.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_VUserM.VUser_Per_Set"
    EnableEventValidation="false" Title="关联人员" %>

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
            for (i = 0; i < options.length; i++) {
                temp = temp + options[i].value + "★";
            }
            document.getElementById("<%=HidUserList.ClientID %>").value = temp;
        }
        function delUserAll() {
            var options = document.getElementById("<%=lstUser.ClientID %>").options;
            for (i = 0; i < options.length; i++) {
                options[i] = null; i--;
            }
            document.getElementById("<%=HidUserList.ClientID %>").value = "";
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
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" align="center">
        <%--  <tr>
            <td class="TableSpecial" style="height:26px">
                <asp:Label ID="lblShowMessage" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td valign="top" height="190px">
                <fieldset>
                    <legend>授权个人</legend>
                    <table width="100%" align="center" height="190px">
                        <tr>
                            <td width="49%" class="TableSpecial" height="190px">
                                <fieldset>
                                    <iframe id="mailUser" name="mailUser" src='../../../Pages/DlgRight/GetUserTree.aspx?argsGuid=<%=Request["argsGuid"]%>&baseOuGuid=<%=Request["baseOuGuid"]%>'
                                        frameborder="0" width="100%" scrolling="auto" height="190px"></iframe>
                                </fieldset>
                            </td>
                            <td width="2%" class="TableSpecial1" height="190px">
                            </td>
                            <td width="49%" class="TableSpecial" height="190px">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:ListBox ID="lstUser" runat="server" Width="100%" Height="170px" SelectionMode="Multiple">
                                            </asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <input id="btnCancle" type="button" onmouseout="this.className='ButtonDelNoBg'" onmouseover="this.className='ButtonDel'"
                                                class="ButtonDelNoBg" value="删除用户" onclick="delUserChecked();" />
                                        </td>
                                        <td align="center">
                                            <input id="btnQkong" type="button" onmouseout="this.className='ButtonConNoBg'" onmouseover="this.className='ButtonCon'"
                                                class="ButtonConNoBg" value="清空用户" onclick="delUserAll();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
