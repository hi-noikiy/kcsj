<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="HandleXinFangFenFa.aspx.cs" Inherits="EpointRegisterUser.Consult.HandleXinFangFenFa"
    Title="分发信件" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="cc4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script>

function DoBack()
{
var BoxGuid=document.getElementById("ctl00$ContentPlaceHolder1$TextTreeView1$ValueTextTreeView1").value;
var Scurse="网站回复";
if(document.getElementById("rdo1") != null){
if(document.getElementById("rdo1").checked)
{
    Scurse="个人回复";
}}
var comment=document.getElementById("ctl00$ContentPlaceHolder1$TextBox1").value;//分发意见
if(BoxGuid=="")
{
    alert('分发信箱必须选择！');
}
else
{
    if(comment=="")
    {
        alert('分发意见必须填写！');
    }
    else
    {
        window.returnValue=BoxGuid+'★'+Scurse+'★'+comment;//分发意见
        window.close();
    }
}
return false;
}
    </script>

    <div id="Div_ControlNoTop">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <cc1:Button ID="btnAdd" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        OnClientClick="return DoBack()" Text="交办" CausesValidation="false" />
                </td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                        OnClientClick="window.close();" runat="server" Text="取消" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" align="center" class="Table" cellspacing="1">
        <tr>
            <td align="right" class="TableSpecial1" width="100">
                选择交办部门：
            </td>
            <td align="left" class="TableSpecial" width="450">
                <cc4:TextTreeView ID="TextTreeView1" runat="server" RootNodeText="信箱分类树" ImgFolds="../../../Images/TreeImages"
                    InputType="CheckBox" DivHeight="260" MultiSelect="true" enablesearch="true" >
                </cc4:TextTreeView>
            </td>
        </tr>
        <tr  id="trReplyType" runat="server">
            <td class="TableSpecial1" align="right" width="100">
                回复方式：
            </td>
            <td class="TableSpecial" align="left">
                <input id="rdo1" type="radio" name="Rdo_HuiFu" />个人回复&nbsp;&nbsp;
                <input id="rdo2" type="radio" name="Rdo_HuiFu" />网站回复
            </td>
        </tr>
        <tr>
            <td class="TableSpecial1" align="right" width="100">
                分发意见：
            </td>
            <td class="TableSpecial" align="left">
                <cc1:TextBox ID="TextBox1" runat="server" MaxLength="100" CssClass="inputtxt" Height="170px"
                    TextMode="MultiLine" Width="424px" Text="请处理"></cc1:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TextBox1"
                    WatermarkText="请处理" WatermarkCssClass="watermarked"/>
            </td>
        </tr>
    </table>

</asp:Content>
