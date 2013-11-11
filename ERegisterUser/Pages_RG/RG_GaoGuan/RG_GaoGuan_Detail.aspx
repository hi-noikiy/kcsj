<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_GaoGuan.RG_GaoGuan_Detail" CodeBehind="RG_GaoGuan_Detail.aspx.cs"
    Title="查看数据明细" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
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
                        <td class="TableSpecial1" width="15%">
                            姓名:
                        </td>
                        <td class="TableSpecial" width="85%" height="26">
                            <asp:Label ID="Name_2023" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            国籍:
                        </td>
                        <td class="TableSpecial" width="85%" height="26">
                            <asp:Label ID="GuoJi_2023" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            职务:
                        </td>
                        <td class="TableSpecial" width="85%" height="26">
                            <asp:Label ID="ZhiWu_2023" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%">
                            DWGuid:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="DWGuid_2023" Width="100%" runat="server"></asp:Label>
                            <asp:Label ID="PGuid_2023" Width="100%" runat="server"></asp:Label>
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
