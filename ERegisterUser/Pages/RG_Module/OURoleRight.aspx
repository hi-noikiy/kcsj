<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="OUTypeRight.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_Module.OUTypeRight"
    EnableEventValidation="false" Title="会员单位权限" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script language="javascript" type="text/javascript">
        function delOUTypeChecked() {
            var options = document.getElementById("<%=lstOUType.ClientID %>").options;
            for (k = 0; k < options.length; k++) {
                if (options[k].selected) {
                    options[k] = null; k--;
                }
            }
            options = document.getElementById("<%=lstOUType.ClientID %>").options;
            var temp = "";
            var temp2 = "";
            for (i = 0; i < options.length; i++) {
                temp = temp + options[i].value + ";";
            }
            document.getElementById("<%=HidOUTypeList.ClientID %>").value = temp;
            document.getElementById("<%=HidOUTypeNameList.ClientID %>").value = temp2;

        }
        function delOUTypeAll() {
            var options = document.getElementById("<%=lstOUType.ClientID %>").options;
            for (i = 0; i < options.length; i++) {
                options[i] = null; i--;
            }
            document.getElementById("<%=HidOUTypeList.ClientID %>").value = "";
            document.getElementById("<%=HidOUTypeNameList.ClientID %>").value = "";
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
                    <asp:HiddenField ID="HidOUTypeList" runat="server" />
                    <asp:HiddenField ID="HidOUTypeNameList" runat="server" />
                </td>
                <td style="padding-left:20px">
                    <asp:CheckBox ID="chkAllowToAll" runat="server"  Text="完全公开"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="98%" align="center">
        <tr>
            <td valign="top" height="190px">
                <fieldset>
                    <legend>单位角色权限</legend>
                    <table height="100%" width="100%" align="center" height="190px">
                        <tr>
                            <td width="49%" class="TableSpecial" height="190px">
                                <fieldset>
                                    <iframe id="Iframe1" name="mailUser" src='GetOUTypeTree.aspx' frameborder="0" width="100%"
                                        scrolling="auto" height="190px"></iframe>
                                </fieldset>
                            </td>
                            <td width="2%" class="TableSpecial1" height="190px">
                            </td>
                            <td width="49%" class="TableSpecial" height="190px">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:ListBox ID="lstOUType" runat="server" Width="100%" SelectionMode="Multiple" Height="170px">
                                            </asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <input id="Button1" type="button" onmouseout="this.className='ButtonDelNoBg'" onmouseover="this.className='ButtonDel'"
                                                class="ButtonDelNoBg" value="删除角色" onclick="delOUTypeChecked();" />
                                        </td>
                                        <td align="center">
                                            <input id="Button2" type="button" onmouseout="this.className='ButtonConNoBg'" onmouseover="this.className='ButtonCon'"
                                                class="ButtonConNoBg" value="清空角色" onclick="delOUTypeAll();" />
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
