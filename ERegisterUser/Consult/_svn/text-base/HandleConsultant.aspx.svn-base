<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    Codebehind="HandleConsultant.aspx.cs" Inherits="EpointRegisterUser.Consult.HandleConsultant"
    Title="咨询回复" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script>
    function DoPostBackUp()
    {
         var reValue=OpenDialog('HandleSendBack.aspx','670','360')
         if(reValue=="")
         {
             alert('退回原因必须填写！');
         }
         else
         {
             if(reValue!=null)
             {
                 __doPostBack("SendBack",reValue);
             }
         }
         return false;
    }
    
    function DoResend()
    {
         var reValue=OpenDialog('HandleChuanFa.aspx','670','460')
         if(reValue!=null&&reValue!="")
         {
            //alert(reValue);
            __doPostBack("ReSend",reValue);
         }
         return false;
     }

     function OpenPrintWin() 
     {
         var url = 'PrintConsultant.aspx?HistoryGuid=<%=Request.QueryString["HistoryGuid"]%>&Row_ID=<%=Request.QueryString["Row_ID"]%>';
         window.open(url);
     }
    </script>

    <div id="Div_ControlNoTop">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <cc3:DeleteButton ID="BtnDel" OnClick="BtnDel_Click" runat="server" RaiseMsg="您确定删除该信件吗?"
                        Text="删除信件" MouseOverClass="ButtonDel" CssClass="ButtonDelNoBg" CausesValidation="False">
                    </cc3:DeleteButton></td>
                <td>
                    <cc1:Button ID="BtnReply" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        OnClick="BtnReply_Click" Text="回复信件" /></td>
                <td>
                    <cc1:Button ID="btnSave" runat="server" MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg"
                        OnClick="BtnSave_Click" Text="保存修改" /></td>
                <td>
                    <cc1:Button ID="btnBack" runat="server" MouseOverClass="ButtonDel" CssClass="ButtonDelNoBg"
                        OnClientClick="return DoPostBackUp()" Text="退回信件" CausesValidation="False" /></td>
                <td>
                    <cc1:Button ID="BtnChange" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                        OnClientClick="return DoResend()" Text="转发信件" CausesValidation="False" /></td>
                <td>
                    <cc1:Button ID="BtnZbcl" runat="server" CssClass="ButtonOKNoBg" MouseOverClass="ButtonOK"
                        OnClick="BtnZbcl_Click" Text="暂不处理" CausesValidation="False"></cc1:Button></td>
                <td>
                    <cc1:Button ID="BtnHfcl" runat="server" MouseOverClass="ButtonCon" OnClick="BtnHfcl_Click"
                        CssClass="ButtonConNoBg" Text="恢复处理" CausesValidation="False" /></td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                        OnClientClick="window.close();" runat="server" Text="关闭窗口" CausesValidation="False" /></td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnPrint"
                        OnClientClick="OpenPrintWin();" runat="server" Text="打印预览" CausesValidation="False" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" align="center" class="Table" cellspacing="1">
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
            <td align="right" class="TableSpecial1" width="100">
                提交人：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPostUserName" runat="server"></asp:Label></td>
        </tr>
      <%--  <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                性别：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblSex" runat="server"></asp:Label></td>
        </tr>--%>
        <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                提交人IP：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblUserIP" runat="server"></asp:Label></td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                提交日期：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPostDate" runat="server"></asp:Label></td>
        </tr>
      <%--  <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                联系电话：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblPhone" runat="server"></asp:Label></td>
        </tr>--%>
       <%-- <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                咨询人E-mail：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                咨询人联系地址：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
        </tr>--%>
        <tr>
            <td align="right" class="TableSpecial1" width="100" height="100">
                内容：</td>
            <td class="TableSpecial" align="left" valign="top">
                <cc1:TextBox ID="txtContent" CssClass="inputtxt" TextAlign="Left" runat="server"
                    AllowNull="false" TextMode="MultiLine" Height="200px" Width="99%"></cc1:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                回复意见：</td>
            <td class="TableSpecial" align="left">
                <cc1:TextBox ID="txtReplyOption"
                    runat="server" TextMode="MultiLine" Height="100px" Width="99%" CssClass="inputtxt"
                    AllowNull="false"></cc1:TextBox>
            </td>
        </tr>
        <tr height="30" id="trIsPub" runat="server">
            <td align="right" class="TableSpecial1" width="100">
                是否发布：</td>
            <td class="TableSpecial" align="left">
                <asp:RadioButtonList ID="RblPublishOnweb" runat="server" Width="200" RepeatDirection="Horizontal">
                    <asp:ListItem Value="true" Selected="True">在网站中发布</asp:ListItem>
                    <asp:ListItem Value="false">不在网站中发布</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr height="30"  id="trReplyType" runat="server">
            <td align="right" class="TableSpecial1" width="100">
                回复方式：</td>
            <td class="TableSpecial" align="left">
                <asp:RadioButtonList ID="Rdo_HuiFu" runat="server" Width="192px" RepeatDirection="Horizontal">
                    <asp:ListItem Value="个人回复" Selected="True">个人回复</asp:ListItem>
                    <asp:ListItem Value="网站回复">网站回复</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="30" id="trfenfa" runat="server">
            <td align="right" class="TableSpecial1" width="100">
                分发意见：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lbzfcomment" runat="server"></asp:Label></td>
        </tr>
        <tr height="30" id="trfenfadate" runat="server">
            <td align="right" class="TableSpecial1" width="100">
                分发日期：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblFenfaDate" runat="server"></asp:Label></td>
        </tr>
        <tr height="30">
            <td align="right" class="TableSpecial1" width="100">
                受理情况：</td>
            <td class="TableSpecial" align="left">
                <asp:Label ID="lblHandled" runat="server"></asp:Label></td>
        </tr>
        
    </table>
</asp:Content>
