<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="ConsultBoxAdd.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxMana.ConsultBoxAdd"
    Title="�������" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="Div_ControlNoTop">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <cc1:Button ID="btnAdd" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        OnClick="btnAdd_Click" Text="���沢�½�" /></td>
                <td>
                    <cc1:Button ID="btnAddClose" runat="server" MouseOverClass="ButtonSave" CssClass="ButtonSaveNoBg"
                        Text="���沢�ر�" OnClick="btnAddClose_Click" /></td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                        OnClientClick="window.close();" runat="server" Text="ȡ�����" CausesValidation="False" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" align="Center" class="Table" cellspacing="1">
        <tr>
            <td align="right" class="TableSpecial1" width="100">
                �������ƣ�</td>
            <td align="left" class="TableSpecial">
                <cc1:TextBox ID="txtTitle" CssClass="inputtxt" TextAlign="Left" MaxLength="50" runat="server"
                    Width="80%" AllowNull="false"></cc1:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1" width="100">
                �������</td>
            <td align="left" class="TableSpecial">
                <asp:DropDownList ID="JpdGroup" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1">
                ���ó���</td>
            <td align="left" class="TableSpecial">
                <asp:CheckBox ID="Check_Audit" Text="����" Checked="true" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1">
                �� �� ֵ��</td>
            <td align="left" class="TableSpecial">
                <cc1:NumericTextBox ID="txtOrderNum" CssClass="inputtxt" runat="server" Width="100"></cc1:NumericTextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1">
                �������ޣ�</td>
            <td align="left" class="TableSpecial">
                <cc1:NumericTextBox ID="txtHandleDays" CssClass="inputtxt" runat="server" Width="100" NumericProperty-MinValue="1"></cc1:NumericTextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1">
                <span style="font-family: ����">�� &nbsp;&nbsp; ����</span></td>
            <td align="left" class="TableSpecial">
                <asp:TextBox ID="txtDesc" CssClass="inputtxt" runat="server" Width="95%" TextMode="MultiLine"
                    Height="160px"></asp:TextBox></td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                <span style="font-family: ����">�� &nbsp;&nbsp; Ƭ��</span></td>
            <td align="left" class="TableSpecial">
                <input class="inputtxt" id="File1" style="width: 201px; height: 22px" type="file"
                    size="14" name="File1" runat="server"><span id="spanimg" runat="server"></span>
            </td>
        </tr>
    </table>
</asp:Content>
