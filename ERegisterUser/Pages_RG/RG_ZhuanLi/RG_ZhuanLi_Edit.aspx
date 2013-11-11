<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_ZhuanLi.RG_ZhuanLi_Edit" CodeBehind="RG_ZhuanLi_Edit.aspx.cs"
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
                                <td class="TableSpecial1" width="20%">
                                    ר����
                                </td>
                                <td class="TableSpecial" width="80%" height="26" align="left">
                                    <epoint:TextBox ID="ZhuanLiNo_2026" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        RelationName="ר����"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="20%">
                                    ר������
                                </td>
                                <td class="TableSpecial" width="80%" height="26" align="left">
                                    <epoint:TextBox ID="ZhuanLiName_2026" runat="server" MaxLength="500" Width="80%"
                                        AllowNull="false" RelationName="ר������"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="20%">
                                    ר������
                                </td>
                                <td class="TableSpecial" width="80%" height="26" align="left">
                                    <asp:DropDownList ID="ZhuanLiType_2026" runat="server" Width="80%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="20%">
                                    ר��״̬
                                </td>
                                <td class="TableSpecial" width="80%" height="26" align="left">
                                    <asp:DropDownList ID="ZhuanLiStatus_2026" runat="server" Width="80%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="20%">
                                    ������
                                </td>
                                <td class="TableSpecial" width="80%" height="26" align="left">
                                    <epoint:TextBox ID="ChiYouRen_2026" runat="server" MaxLength="500" Width="80%" AllowNull="false"
                                        RelationName="������"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="20%">
                                    ����
                                </td>
                                <td class="TableSpecial" width="80%" height="26" align="left">
                                    <uc1:CaiLiao ID="CL_ZLJS" runat="server" YeWuMC="��ҵ-ר��������" />
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td colspan="2">
                                    <epoint:TextBox ID="DWGuid_2026" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="PGuid_2026" runat="server" MaxLength="50"></epoint:TextBox>
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
