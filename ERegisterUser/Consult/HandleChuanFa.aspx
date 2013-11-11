<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="HandleChuanFa.aspx.cs" Inherits="EpointRegisterUser.Consult.HandleChuanFa"
    Title="转发信件" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="cc4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        function DoBack() {

            var BoxGuid = document.getElementById("ctl00$ContentPlaceHolder1$TextTreeView1$ValueTextTreeView1").value;
            var Scurse = document.getElementById("ctl00$ContentPlaceHolder1$TextBox1").value; //原因
            //alert(BoxGuid);
            if (BoxGuid == "") {
                alert('转发信箱必须选择！');
            }
            else {
                if (Scurse != "") {
                    window.returnValue = BoxGuid + '★' + Scurse;
                    window.close();
                }
                else {
                    alert('转发意见必须填写！');
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
                        OnClientClick="return DoBack()" Text="确定转发" CausesValidation="false" />
                </td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                        OnClientClick="window.close();" runat="server" Text="取消转发" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" align="center" class="Table" cellspacing="1">
        <tr>
            <td align="right" class="TableSpecial1" width="100">
                选择信箱：
            </td>
            <td align="left" class="TableSpecial" width="450">
                <cc4:TextTreeView ID="TextTreeView1" runat="server" RootNodeText="信箱分类树" ImgFolds="../../Images/TreeImages"
                    InputType="Radio" OnTreeNodePopulate="TextTreeView1_TreeNodePopulate" DivHeight="260">
                </cc4:TextTreeView>
            </td>
        </tr>
        <tr>
            <td class="TableSpecial1" align="right" width="100">
                转发意见：
            </td>
            <td class="TableSpecial" align="left">
                <cc1:TextBox ID="TextBox1" runat="server" MaxLength="100" CssClass="inputtxt" Height="170px"
                    TextMode="MultiLine" Width="424px"></cc1:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
