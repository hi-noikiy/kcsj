<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_DingQi.RG_DingQi_Detail" CodeBehind="RG_DingQi_Detail.aspx.cs"
    Title="�鿴������ϸ" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register Src="../../Ascx/CaiLiao.ascx" TagName="CaiLiao" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="450px" border="0">
        <%--<tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="����"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>--%>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1" align="center">
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            ӯ��״̬
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label ID="s_yingLiZT_2027" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            ���յȼ�
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label ID="s_fengXianDJ_2027" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            ���ڽ׶�
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label ID="s_DangQianJD_2027" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            ��ע�̶�
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label ID="s_guanZhuCD_2027" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            ʱ��
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label runat="server" ID="lblSJ">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            ��Ŀ��˾��ǰ��ֵ
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label ID="f_DangQianGZ_2027" runat="server"></asp:Label>
                            <asp:Label ID="s_DangQianGZ_BZ_2027" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            �ҹ�˾��ǰ�ֹ���ֵ
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label ID="f_dangQianChiGuZ_2027" runat="server"></asp:Label>
                            <asp:Label ID="s_dangQianChiGuZ_BZ_2027" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            ռ�ɱ���
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label ID="f_zhanGuBiLi_2027" runat="server"></asp:Label>%
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="25%">
                            ��ظ���
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <uc1:CaiLiao ID="CL_DQSX" runat="server" YeWuMC="��ҵ-��������" ReadOnly="true" />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="25%">
                            ״̬
                        </td>
                        <td class="TableSpecial" width="65%" height="26" align="left">
                            <asp:Label ID="s_Status_2027" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="DWGuid_2027" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="ProjectGuid_2027" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="d_qiJian_2027" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" height="40">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">û�����ݣ�</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
