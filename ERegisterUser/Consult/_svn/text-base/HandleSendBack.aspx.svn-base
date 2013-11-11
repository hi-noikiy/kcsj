<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true" CodeBehind="HandleSendBack.aspx.cs" Inherits="EpointRegisterUser.Consult.HandleSendBack" Title="退回信件" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<script>
function DoBack()
{
if(document.getElementById("ctl00$ContentPlaceHolder1$txtBackCouse").value=="")
{
    alert('退回原因必须填写！');
    return false;
}
    if(confirm('是否确定退回信件?'))
    {
        window.returnValue=document.getElementById("ctl00$ContentPlaceHolder1$txtBackCouse").value;
        window.close();
    }
    return false;
}
</script>
    <div id="Div_ControlNoTop">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <cc1:Button ID="btnAdd" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg" OnClientClick="return DoBack()"
                        Text="确定退回" CausesValidation="false" /></td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                        OnClientClick="window.close();" runat="server" Text="取消退回" CausesValidation="False" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" align="Center" class="Table" cellspacing="1">
        <tr>
            <td align="right" class="TableSpecial1" width="100">
                退回原因：</td>
            <td align="left" class="TableSpecial" width="450px">
                <cc1:TextBox ID="txtBackCouse" runat="server" MaxLength="100" CssClass="inputtxt" Height="170px"
                            TextMode="MultiLine" Width="424px" AllowNull="true"></cc1:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>