<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADDefault.aspx.cs" Inherits="HTProject.ADDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="Ascx/OUCheck.ascx" TagName="OUCheck" TagPrefix="uc1" %>
<%@ Register Src="Ascx/RYCheck.ascx" TagName="RYCheck" TagPrefix="uc1" %>
<%@ Register Src="Ascx/ZZCheck.ascx" TagName="ZZCheck" TagPrefix="uc1" %>
<%@ Register Src="Ascx/XMCheck.ascx" TagName="XMCheck" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="refresh" content="300">
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Scripts>
            <asp:ScriptReference Name="MicrosoftAjax.js" ScriptMode="Release" Path="~/JavaScript/MicrosoftAjax.js" />
            <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" ScriptMode="Release" Path="~/JavaScript/MicrosoftAjaxWebForms.js" />
        </Scripts>
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <%--<tr>
            <td class="Home1_1_1">
                <div class="Home1_1_1">
                </div>
            </td>
            <td class="Home1_1_bg">
                <div class="Home1_title">
                </div>
            </td>
            <td class="Home1_Line1">
            </td>
            <td class="Home1_1_bg">
            </td>
            <td class="Home1_Line1">
            </td>
            <td class="Home1_1_bg">
            </td>
            <td class="Home1_1_2">
                <div class="Home1_1_2">
                </div>
            </td>
        </tr>--%>
        <tr>
            <td ><%--class="Home1_2_1"--%>
               &nbsp; <%--<div class="Home1_2_1">
                </div>--%>
            </td>
            <td valign="top" class="Home1_2_bg">
                <uc1:OUCheck ID="OUC" runat="server" />
            </td>
            <%--<td class="Home1_Linebg">
                <div class="Home1_Line2">
                </div>
            </td>--%>
            <td>
                
            </td>
            <td class="Home1_2_bg2">
                <uc1:RYCheck ID="RYC" runat="server" />
            </td>
            <td >
               
            </td>
            <%--<td class="Home1_2_1">
                <div class="Home1_2_1">
                </div>
            </td>--%>
            <%--<td class="Home1_Linebg">
                <div class="Home1_Line2">
                </div>
            </td>
            <td class="Home1_2_bg3">
                <uc1:Calender ID="Calender1" runat="server" />
            </td>
            <td class="Home1_2_2">
                <div class="Home1_2_2">
                </div>
            </td>--%>
        </tr>
        <tr>
            <td >
                <%--<div class="Home1_2_1">
                </div>--%>
            </td>
            <td valign="top" class="Home1_2_bg">
                <uc1:ZZCheck ID="ZZC" runat="server" />
            </td>
            <%--<td class="Home1_Linebg">
                <div class="Home1_Line2">
                </div>
            </td>--%>
            <td>
                
            </td>
            <td class="Home1_2_bg2">
                <uc1:XMCheck ID="XMC" runat="server" />
            </td>
            <td>
                
            </td>
            <%--<td class="Home1_2_1">
                <div class="Home1_2_1">
                </div>
            </td>--%>
            <%--<td class="Home1_Linebg">
                <div class="Home1_Line2">
                </div>
            </td>
            <td class="Home1_2_bg3">
                <uc1:Calender ID="Calender1" runat="server" />
            </td>
            <td class="Home1_2_2">
                <div class="Home1_2_2">
                </div>
            </td>--%>
        </tr>
        <%--<tr>
            <td class="Home1_3_1">
                <div class="Home1_3_1">
                </div>
            </td>
            <td class="Home1_3_bg">
            </td>
            <td class="Home1_Line3">
                <div class="Home1_Line3">
                </div>
            </td>
            <td class="Home1_3_bg">
            </td>
            <td class="Home1_Line3">
                <div class="Home1_Line3">
                </div>
            </td>
            <td class="Home1_3_bg">
            </td>
            <td class="Home1_3_2">
                <div class="Home1_3_2">
                </div>
            </td>
        </tr>--%>
    </table>
    
    </form>
</body>
</html>
