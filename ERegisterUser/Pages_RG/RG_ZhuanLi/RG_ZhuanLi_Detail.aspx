<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_ZhuanLi.RG_ZhuanLi_Detail" CodeBehind="RG_ZhuanLi_Detail.aspx.cs"
    Title="查看数据明细" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register Src="../../Ascx/CaiLiao.ascx" TagName="CaiLiao" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="宋体"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1">
                    <tr>
                        <td class="TableSpecial1" width="20%">
                            专利号:
                        </td>
                        <td class="TableSpecial" width="80%" height="26">
                            <asp:Label ID="ZhuanLiNo_2026" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="20%">
                            专利名称:
                        </td>
                        <td class="TableSpecial" width="80%" height="26">
                            <asp:Label ID="ZhuanLiName_2026" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="20%">
                            专利类型:
                        </td>
                        <td class="TableSpecial" width="80%" height="26">
                            <asp:Label ID="ZhuanLiType_2026" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="20%">
                            专利状态:
                        </td>
                        <td class="TableSpecial" width="80%" height="26">
                            <asp:Label ID="ZhuanLiStatus_2026" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="20%">
                            持有人:
                        </td>
                        <td class="TableSpecial" width="80%" height="26">
                            <asp:Label ID="ChiYouRen_2026" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="20%">
                            附件
                        </td>
                        <td class="TableSpecial" width="80%" height="26" align="left">
                            <uc1:CaiLiao ID="CL_ZLJS" runat="server" YeWuMC="企业-专利及技术" ReadOnly="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" height="40">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">没有数据！</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
