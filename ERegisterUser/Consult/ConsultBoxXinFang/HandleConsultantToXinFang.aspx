<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="HandleConsultantToXinFang.aspx.cs" Inherits="EpointRegisterUser.Consult.HandleConsultantToXinFang"
    Title="�ż��ַ�" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc5" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="cc4" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="cc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="cc4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        //�ַ�
        function DoResendPostBack() {
            var reValue = OpenDialog('HandleXinFangFenFa.aspx?ReplyType=<%=ViewState["ReplyType"] %>&HistoryGuid=<%=Request.QueryString["HistoryGuid"]%>', '670', '460')
            if (reValue != null && reValue != "") {
                __doPostBack("ReSend", reValue);
            }
            return false;
        }
    </script>
    <div id="Div_ControlNoTop">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <cc3:DeleteButton ID="BtnDel" OnClick="BtnDel_Click" runat="server" RaiseMsg="��ȷ��ɾ�����ż���?"
                        Text="ɾ���ż�" MouseOverClass="ButtonDel" CssClass="ButtonDelNoBg" CausesValidation="False">
                    </cc3:DeleteButton>
                </td>
                <td>
                    <cc1:Button ID="btnSave" runat="server" MouseOverClass="ButtonSave" CssClass="ButtonSaveNoBg"
                        Text="������" CausesValidation="true" OnClick="btnSave_Click" />
                </td>
                <td>
                    <cc1:Button ID="btnReply" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        Text="ȷ���ظ�" CausesValidation="true" OnClick="btnReply_Click" />
                </td>
                <td style="display: none">
                    <cc1:Button ID="BtnOk" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        Text="ֱ�ӷַ�" CausesValidation="true" OnClick="BtnOk_Click" />
                </td>
                <td>
                    <cc1:Button ID="btnChange" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        Text="�ַ��ż�" CausesValidation="true" OnClientClick="return DoResendPostBack();" />
                </td>
                <td>
                    <cc1:Button ID="BtnZbcl" runat="server" CssClass="ButtonOKNoBg" MouseOverClass="ButtonOK"
                        OnClick="BtnZbcl_Click" Text="�ݲ�����" CausesValidation="False"></cc1:Button>
                </td>
                <td>
                    <cc1:Button ID="BtnHfcl" runat="server" MouseOverClass="ButtonCon" OnClick="BtnHfcl_Click"
                        CssClass="ButtonConNoBg" Text="�ָ�����" CausesValidation="False" />
                </td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                        OnClientClick="window.close();" runat="server" Text="�رմ���" CausesValidation="False" />
                </td>
                <td>
                    <input id="txtPostBack" type="hidden" runat="server" name="txtPostBack" />
                </td>
                <td>
                    <cc1:Button MouseOverClass="ButtonSearch" CssClass="ButtonSearchNoBg" ID="Button1"
                        OnClientClick="window.print();return false;" runat="server" Text="��ӡ" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" align="center" class="Table" cellspacing="1">
        <tr height="30">
            <td width="100" class="TableSpecial1" align="right">
                �����ֹ���ڣ�
            </td>
            <td class="TableSpecial" align="left">
                <cc1:DateTextBox ID="txtEndDate" runat="server" CssClass="Inputtxt" Character="HX"
                    Width="80px" AllowNull="false"></cc1:DateTextBox><span id="spnbeizhu" runat="server"
                        style="color: Red;"></span>
            </td>
        </tr>
        <tr height="30">
            <td width="100" class="TableSpecial1" align="right">
                �������䣺
            </td>
            <td class="TableSpecial" align="left">
                <cc4:TextTreeView ID="treeSendToBox" runat="server" RootNodeText="����" ImgFolds="../../../Images/TreeImages"
                    InputType="Radio" DivHeight="260" MultiSelect="false">
                </cc4:TextTreeView>
            </td>
        </tr>
        <tr height="30">
            <td width="100" class="TableSpecial1" align="right">
                �ż����⣺
            </td>
            <td class="TableSpecial" align="left">
                <cc1:TextBox ID="lblSubject" CssClass="inputtxt" TextAlign="Left" runat="server"
                    Width="99%" AllowNull="false"></cc1:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                �ύ�ˣ�
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPostUserName" runat="server"></asp:Label>
            </td>
        </tr>
        <%--  <tr height="30">
            <td align="right" class="TableSpecial1">
                �Ա�
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblSex" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                �ύ���ڣ�
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPostDate" runat="server"></asp:Label>
            </td>
        </tr>
        <%--<tr height="30">
            <td align="right" class="TableSpecial1">
                ��ϵ�绰��
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPhone" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <%-- <tr height="30">
            <td align="right" class="TableSpecial1">
                ��ѯ��E-mail��
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr height="30" style="display: none;">
            <td align="right" class="TableSpecial1">
                �Ƿ񷢲���
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblToWeb" runat="server"></asp:Label>
            </td>
        </tr>
        <%-- <tr height="30">
            <td align="right" class="TableSpecial1">
                ��ѯ����ϵ��ַ��
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                ��ѯ��IP��
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblIP" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1" width="100" height="100">
                ���ݣ�
            </td>
            <td class="TableSpecial" align="left" valign="top">
                <cc1:TextBox ID="txtContent" CssClass="inputtxt" TextAlign="Left" runat="server"
                    AllowNull="false" TextMode="MultiLine" Height="200px" Width="99%"></cc1:TextBox>
            </td>
        </tr>
        <tr height="30" id="trreply" runat="server">
            <td align="right" class="TableSpecial1" width="100">
                �ظ������
            </td>
            <td class="TableSpecial" align="left">
                <cc1:TextBox ID="txtReplyOption" runat="server" TextMode="MultiLine" Height="100px"
                    Width="99%" CssClass="inputtxt" AllowNull="true"></cc1:TextBox>
                <span style="color: Red;">��������зַ�����Ĵ���Ȩ�ޣ����ڴ�ֱ�ӻظ�����</span>
            </td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                �Ƿ�ֱ�ӻظ�����վ��
            </td>
            <td class="TableSpecial" align="left">
                <asp:RadioButtonList ID="RblPublishOnweb" runat="server" Width="200" RepeatDirection="Horizontal">
                    <asp:ListItem Value="true" Selected="True">��</asp:ListItem>
                    <asp:ListItem Value="false">��</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="30" id="trReplyType" runat="server">
            <td align="right" class="TableSpecial1">
                �ظ���ʽ��
            </td>
            <td class="TableSpecial" align="left">
                <asp:RadioButtonList ID="RblType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="���˻ظ�">���˻ظ�</asp:ListItem>
                    <asp:ListItem Value="��վ�ظ�">��վ�ظ�</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                ���������
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblHandled" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
