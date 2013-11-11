<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPage.master" AutoEventWireup="True"
    Inherits="HTProject.Pages.RG_User.Record_Detail" Title="��Ա���" CodeBehind="Record_Detail.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script>

    function OpenUrl() {
        OpenDialogRefresh('RG_SendMessage.aspx?UserGuid=<%=Request["RowGuid"]%>', "", 600, 300);
    }
    </script>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <div id="Div_Control">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;<epoint:Button MouseOverClass="ButtonOK" ForeColor="black" CssClass="ButtonOKNoBg"
                                    ID="btnCheck" runat="server" Text="���ͨ��" OnClick="Check_Click" />
                            </td>
                            <td>
                                &nbsp;<epoint:Button Text="��ͨ��" ID="btnNotPass" MouseOverClass="ButtonDel" runat="server"
                                    CssClass="ButtonDelNoBg" OnClick="NotPass_Click" OnClientClick="OpenUrl();"  />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1">
                    <tr>
                        <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                            <font style="font-weight: bold">������Ϣ</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��Ա���:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="UserType_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��&nbsp;½&nbsp;��:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="LoginID_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ʾ����:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="DispName_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            �ֻ�����:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="Mobile_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            �Ƿ���ܶ�������:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="isEnableSMS" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            �Ƿ�������������:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="EnableOnlineChat" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trperson" runat="server">
                        <td class="TableSpecial1" width="15%">
                            ���֤����:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" colspan="3">
                            <asp:Label ID="UserIdendity_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            �û���ɫ:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" colspan="3">
                            <asp:Label ID="RoleName" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" id="trDanwei">
                        <td class="TableSpecial1" width="15%">
                            ������λ
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="OUBelong" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trOuType" runat="server">
                        <td class="TableSpecial1" width="15%">
                            ��λ���
                        </td>
                        <td class="TableSpecial" height="26" align="left" colspan="3">
                            <asp:Label ID="OUType" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                            <font style="font-weight: bold">������Ϣ</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Sex_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Race_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="BirthDay_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            סլ�绰
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="HomeTel_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            �칫�绰
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="OfficeTel_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="PostCode_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            QQ&nbsp;����
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="QQAccount_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            MSN����
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="MSNAccount_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="EMail_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��&nbsp;��&nbsp;��
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="SuoZaiDi_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ͨѶ��ַ
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="Address_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ������ϵ��ʽ
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="OtherContact_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ƭ
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <input id="Photo_99" runat="server" type="file" />&nbsp;<asp:Label ID="lbl_Photo_99"
                                runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ע
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="ChangeLog_99" Width="100%" runat="server" Height="100"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="1" id="tabou" runat="server">
                    <tr>
                        <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                            <font style="font-weight: bold">��λ��Ϣ</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��λ����
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="EnterpriseName" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��֯��������֤
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="CodeCertificate" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��λ����
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="EnterpriseType" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ���˴���
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="LegalPerson" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            Ӫҵִ�ձ��
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="BusinessLicenseNO" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ҵ��������
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="RegionCharacter" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            �� ϵ ��
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="Contacter" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ϵ�绰
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="Tel" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��ϵ�����֤
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="ContacterID" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            �����ʼ�
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="Email" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��λ��ַ
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="Address" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ע �� ��
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="RegistAddress" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ע
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="BeiZhu" Width="100%" runat="server" Height="100px"></asp:Label>
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
