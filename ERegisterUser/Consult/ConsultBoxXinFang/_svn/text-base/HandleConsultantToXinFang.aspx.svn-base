<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="HandleConsultantToXinFang.aspx.cs" Inherits="EpointRegisterUser.Consult.HandleConsultantToXinFang"
    Title="信件分发" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc5" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="cc4" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="cc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="cc4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        //分发
        function DoResendPostBack() {
            var reValue = OpenDialog('HandleXinFangFenFa.aspx?ReplyType=<%=ViewState["ReplyType"] %>&HistoryGuid=<%=Request.QueryString["HistoryGuid"]%>', '670', '460')
            if (reValue != null && reValue != "") {
                __doPostBack("ReSend", reValue);
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
                    <cc3:DeleteButton ID="BtnDel" OnClick="BtnDel_Click" runat="server" RaiseMsg="您确定删除该信件吗?"
                        Text="删除信件" MouseOverClass="ButtonDel" CssClass="ButtonDelNoBg" CausesValidation="False">
                    </cc3:DeleteButton>
                </td>
                <td>
                    <cc1:Button ID="btnSave" runat="server" MouseOverClass="ButtonSave" CssClass="ButtonSaveNoBg"
                        Text="保　存" CausesValidation="true" OnClick="btnSave_Click" />
                </td>
                <td>
                    <cc1:Button ID="btnReply" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        Text="确定回复" CausesValidation="true" OnClick="btnReply_Click" />
                </td>
                <td style="display: none">
                    <cc1:Button ID="BtnOk" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        Text="直接分发" CausesValidation="true" OnClick="BtnOk_Click" />
                </td>
                <td>
                    <cc1:Button ID="btnChange" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        Text="分发信件" CausesValidation="true" OnClientClick="return DoResendPostBack();" />
                </td>
                <td>
                    <cc1:Button ID="BtnZbcl" runat="server" CssClass="ButtonOKNoBg" MouseOverClass="ButtonOK"
                        OnClick="BtnZbcl_Click" Text="暂不处理" CausesValidation="False"></cc1:Button>
                </td>
                <td>
                    <cc1:Button ID="BtnHfcl" runat="server" MouseOverClass="ButtonCon" OnClick="BtnHfcl_Click"
                        CssClass="ButtonConNoBg" Text="恢复处理" CausesValidation="False" />
                </td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                        OnClientClick="window.close();" runat="server" Text="关闭窗口" CausesValidation="False" />
                </td>
                <td>
                    <input id="txtPostBack" type="hidden" runat="server" name="txtPostBack" />
                </td>
                <td>
                    <cc1:Button MouseOverClass="ButtonSearch" CssClass="ButtonSearchNoBg" ID="Button1"
                        OnClientClick="window.print();return false;" runat="server" Text="打印" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" align="center" class="Table" cellspacing="1">
        <tr height="30">
            <td width="100" class="TableSpecial1" align="right">
                处理截止日期：
            </td>
            <td class="TableSpecial" align="left">
                <cc1:DateTextBox ID="txtEndDate" runat="server" CssClass="Inputtxt" Character="HX"
                    Width="80px" AllowNull="false"></cc1:DateTextBox><span id="spnbeizhu" runat="server"
                        style="color: Red;"></span>
            </td>
        </tr>
        <tr height="30">
            <td width="100" class="TableSpecial1" align="right">
                发送信箱：
            </td>
            <td class="TableSpecial" align="left">
                <cc4:TextTreeView ID="treeSendToBox" runat="server" RootNodeText="信箱" ImgFolds="../../../Images/TreeImages"
                    InputType="Radio" DivHeight="260" MultiSelect="false">
                </cc4:TextTreeView>
            </td>
        </tr>
        <tr height="30">
            <td width="100" class="TableSpecial1" align="right">
                信件标题：
            </td>
            <td class="TableSpecial" align="left">
                <cc1:TextBox ID="lblSubject" CssClass="inputtxt" TextAlign="Left" runat="server"
                    Width="99%" AllowNull="false"></cc1:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                提交人：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPostUserName" runat="server"></asp:Label>
            </td>
        </tr>
        <%--  <tr height="30">
            <td align="right" class="TableSpecial1">
                性别：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblSex" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                提交日期：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPostDate" runat="server"></asp:Label>
            </td>
        </tr>
        <%--<tr height="30">
            <td align="right" class="TableSpecial1">
                联系电话：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPhone" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <%-- <tr height="30">
            <td align="right" class="TableSpecial1">
                咨询人E-mail：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr height="30" style="display: none;">
            <td align="right" class="TableSpecial1">
                是否发布：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblToWeb" runat="server"></asp:Label>
            </td>
        </tr>
        <%-- <tr height="30">
            <td align="right" class="TableSpecial1">
                咨询人联系地址：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                咨询人IP：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblIP" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1" width="100" height="100">
                内容：
            </td>
            <td class="TableSpecial" align="left" valign="top">
                <cc1:TextBox ID="txtContent" CssClass="inputtxt" TextAlign="Left" runat="server"
                    AllowNull="false" TextMode="MultiLine" Height="200px" Width="99%"></cc1:TextBox>
            </td>
        </tr>
        <tr height="30" id="trreply" runat="server">
            <td align="right" class="TableSpecial1" width="100">
                回复意见：
            </td>
            <td class="TableSpecial" align="left">
                <cc1:TextBox ID="txtReplyOption" runat="server" TextMode="MultiLine" Height="100px"
                    Width="99%" CssClass="inputtxt" AllowNull="true"></cc1:TextBox>
                <span style="color: Red;">（如果你有分发信箱的处理权限，可在此直接回复。）</span>
            </td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                是否直接回复到网站：
            </td>
            <td class="TableSpecial" align="left">
                <asp:RadioButtonList ID="RblPublishOnweb" runat="server" Width="200" RepeatDirection="Horizontal">
                    <asp:ListItem Value="true" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="false">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="30" id="trReplyType" runat="server">
            <td align="right" class="TableSpecial1">
                回复方式：
            </td>
            <td class="TableSpecial" align="left">
                <asp:RadioButtonList ID="RblType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="个人回复">个人回复</asp:ListItem>
                    <asp:ListItem Value="网站回复">网站回复</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1">
                处理情况：
            </td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblHandled" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
