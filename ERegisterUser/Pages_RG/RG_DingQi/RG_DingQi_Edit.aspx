<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_DingQi.RG_DingQi_Edit" CodeBehind="RG_DingQi_Edit.aspx.cs"
    Title="�޸����ݼ�¼" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Ajax.FileUpload" Namespace="Epoint.Ajax.FileUpload"
    TagPrefix="cc1" %>
<%@ Register Src="../../Ascx/CaiLiao.ascx" TagName="CaiLiao" TagPrefix="uc1" %>
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
    <cc1:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
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
                            <epoint:Button ID="btnWC" runat="server" Text="ȷ�����" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnWC_Click" OnClientClick="return confirm('ȷ�����?');"></epoint:Button>
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
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                        align="center" valign="middle">
                        <%=ViewState ["TableName"]%>
                    </td>
                </tr>
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center" id="tabContent">
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    ӯ��״̬
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <asp:DropDownList ID="s_yingLiZT_2027" runat="server" Width="60%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    ���յȼ�
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <asp:DropDownList ID="s_fengXianDJ_2027" runat="server" Width="60%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    ���ڽ׶�
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <asp:DropDownList ID="s_DangQianJD_2027" runat="server" Width="60%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    ��ע�̶�
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <asp:DropDownList ID="s_guanZhuCD_2027" runat="server" Width="60%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    ʱ��
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <asp:DropDownList runat="server" ID="jpdYear">
                                    </asp:DropDownList>
                                    ��
                                    <asp:DropDownList runat="server" ID="jpdMonth">
                                    </asp:DropDownList>
                                    ��
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    ��Ŀ��˾��ǰ��ֵ
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <epoint:NumericTextBox ID="f_DangQianGZ_2027" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" MaxValue="100"/></epoint:NumericTextBox>
                                    <asp:DropDownList ID="s_DangQianGZ_BZ_2027" runat="server" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    �ҹ�˾��ǰ�ֹ���ֵ
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <epoint:NumericTextBox ID="f_dangQianChiGuZ_2027" runat="server" TextAlign="Right"
                                        Style="padding-right: 2px; padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" MaxValue="100"/></epoint:NumericTextBox>
                                    <asp:DropDownList ID="s_dangQianChiGuZ_BZ_2027" runat="server" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    ռ�ɱ���
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <epoint:NumericTextBox ID="f_zhanGuBiLi_2027" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" MaxValue="100" /></epoint:NumericTextBox>%
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="25%">
                                    ��ظ���
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <uc1:CaiLiao ID="CL_DQSX" runat="server" YeWuMC="��ҵ-��������" />
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="25%">
                                    ״̬
                                </td>
                                <td class="TableSpecial" width="65%" height="26" align="left">
                                    <epoint:TextBox ID="s_Status_2027" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="DWGuid_2027" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="ProjectGuid_2027" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="d_qiJian_2027" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
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
