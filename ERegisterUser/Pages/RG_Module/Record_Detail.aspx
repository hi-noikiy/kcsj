<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_Module.Record_Detail" Title="�鿴������ϸ" CodeBehind="Record_Detail.aspx.cs" %>

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
                            ��ģ��ID:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ParentID_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ģ������:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ModuleName_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="TableSpecial1" width="15%">
                            ģ���ַ:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ModuleAddress_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ����:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="OrderNum_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            �Ƿ����:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="IsForbid_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ģ��ͼƬ��С��:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="SmallImgAddress_103" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ģ��ͼƬ����:
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
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">û�����ݣ�</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
