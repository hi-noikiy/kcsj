<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.RG_Matters.Matter_Detail" Title="查看数据明细" CodeBehind="Matter_Detail.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <%--<tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="宋体"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>--%>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            事项名称:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="MatterName_131" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            事项地址:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="MatterUrl_131" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            说明页面Url:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="InstrUrl_131" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            排序:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="OrderNum_131" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            是否禁用:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="IsForbidden_131" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            是否弹出:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="IsBlank_131" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
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
