<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_Module.Record_Detail" Title="查看数据明细" CodeBehind="Record_Detail.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1">
                  <%--  <tr>
                        <td class="TableSpecial1" width="15%">
                            父模块ID:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ParentID_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            模块名称:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ModuleName_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="TableSpecial1" width="15%">
                            模块地址:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ModuleAddress_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            排序:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="OrderNum_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            是否禁用:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="IsForbid_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            模块图片（小）:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="SmallImgAddress_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            模块图片（大）:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="BigImgAddress_103" Width="100%" runat="server"></asp:Label>
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
