<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintConsultant.aspx.cs"
    Inherits="EpointRegisterUser.Consult.PrintConsultant" %>

<html>
<head runat="server">
    <title>咨询回复打印预览</title>
    <style type="text/css">
        body
        {
            font-family: 宋体,Arial;
            font-size: 9pt;
            border: 0;
            margin: 0;
            background-position: center;
            background-repeat: repeat-y;
            background-color: #FFFFFF;
            text-align: center;
        }
        TD
        {
            font-size: 10.5pt;
            color: #000000;
            padding: 5px;
            line-height: 18px;
        }
        TABLE
        {
            border-collapse: collapse;
        }
        .btn
        {
            border-right: 0px solid #6AAAA3;
            border-top: 0px solid #6AAAA3;
            border-left: 0px solid #6AAAA3;
            border-bottom: 0px solid #6AAAA3;
            background-repeat: no-repeat;
            background-position: left bottom;
            padding-left: 15px;
            width: 92px;
            height: 24px;
            color: #000000;
            cursor: hand;
            background-color: Transparent;
            padding-top: 3px;
            font: 12px/1.4 Verdana, sans-serif;
            background-image: url(../../App_Themes/EpointWebThree/img/ButtonOkNoBg.gif);
        }
        .btnclose
        {
            border-right: 0px solid #6AAAA3;
            border-top: 0px solid #6AAAA3;
            border-left: 0px solid #6AAAA3;
            border-bottom: 0px solid #6AAAA3;
            background-image: url(../../App_Themes/EpointWebThree/img/ButtonCancleNoBg.gif);
            background-repeat: no-repeat;
            background-position: left bottom;
            padding-left: 15px;
            width: 92px;
            height: 24px;
            color: #000000;
            cursor: hand;
            background-color: Transparent;
            padding-top: 3px;
            font: 12px/1.4 Verdana, sans-serif;
        }
    </style>
    <style media="print" type="text/css">
        .noprint
        {
            display: none;
        }
        .print
        {
            height: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" width="720" style="text-align:right" cellspacing="1" class="noprint">
        <tr height="30">
            <td align="right">
                <input id="btnclose" onclick="window.close();" type="button" value="关 闭" class="btnclose" />
            </td>
            <td  style="width:1px"><input
                    id="btnprint" onclick="window.print();" type="button" value="打 印" class="btn" /></td>
        </tr>
    </table>
    <table border="0" cellspacing="1" align="center" width="720">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <b>信箱名称</b>：
                        </td>
                        <td align="left">
                            <asp:Label ID="lblBoxName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <b>信件编号</b>：
                        </td>
                        <td align="left">
                            <asp:Label ID="lblXjbh" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="1" width="720" align="center" cellspacing="1" bordercolor="#000000">
        <tr height="30">
            <td width="120" align="right">
                信件标题：
            </td>
            <td align="left">
                <asp:Label ID="lblSubject" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                提交人：
            </td>
            <td align="left">
                <asp:Label ID="lblPostUserName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                性别：
            </td>
            <td align="left">
                <asp:Label ID="lblSex" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                提交人IP：
            </td>
            <td align="left">
                <asp:Label ID="lblUserIP" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                提交日期：
            </td>
            <td align="left">
                <asp:Label ID="lblPostDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                联系电话：
            </td>
            <td align="left">
                <asp:Label ID="lblPhone" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                咨询人E-mail：
            </td>
            <td align="left">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right">
                咨询人联系地址：
            </td>
            <td align="left">
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" height="100" class="print">
                内容：
            </td>
            <td align="left" valign="top">
                <asp:Label ID="lblContent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right" height="100" class="print">
                回复意见：
            </td>
            <td align="left" valign="top">
                <asp:Label ID="lblReplyOption" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30" id="trfenfa" runat="server">
            <td align="right" height="100" class="print">
                分发意见：
            </td>
            <td align="left">
                <asp:Label ID="lbzfcomment" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30" id="trfenfadate" runat="server">
            <td align="right">
                分发日期：
            </td>
            <td align="left">
                <asp:Label ID="lblFenfaDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td align="right" class="print">
                受理情况：
            </td>
            <td align="left" valign="top">
                <asp:Label ID="lblHandled" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
