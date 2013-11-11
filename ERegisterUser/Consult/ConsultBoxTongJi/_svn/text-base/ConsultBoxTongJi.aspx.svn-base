<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageNoLocation.Master" AutoEventWireup="true"
    Codebehind="ConsultBoxTongJi.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxTongJi.ConsultBoxTongJi"
    Title="无标题页" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc2" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="3">
        <tr>
            <td align="left">
                提交日期从</td>
            <td>
                <cc2:DateFromTo ID="DateFromTo1" runat="server" Character="HX" FromWidth="80px" ToWidth="80px"
                    FromTextCssClass="inputtxt" ToTextCssClass="inputtxt" />
            </td>
            <td>
                <cc2:Button ID="btnSearch" runat="server" Text="查  询" CssClass="ButtonSearchNoBg"
                    MouseOverClass="ButtonSearch" OnClick="btnSearch_Click" /></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="1" bordercolor="#94B5C0">
                <tr height="25" bgcolor="#D7E7F6">
                    <td width="100" align="center">
                        信箱名称</td>
                    <td colspan="2" align="center">
                        未处理</td>
                    <td colspan="5" align="center">
                        已处理</td>
                    <td colspan="4" align="center">
                        满意度</td>
                </tr>
                <tr height="25">
                    <td width="100" rowspan="2" nowrap align=center>
                        <b>
                            <%# DataBinder.Eval(Container.DataItem ,"BoxName") %>
                        </b>
                    </td>
                    <td width="100" align="center">
                        已超时</td>
                    <td width="100" align="center">
                        未超时</td>
                    <td width="100" align="center">
                        已超时</td>
                    <td width="100" align="center">
                        未超时</td>
                    <td width="100" align="center">
                        个别回复</td>
                    <td width="100" align="center">
                        网上回复</td>
                    <td width="100" align="center">
                        暂不回复</td>
                    <td width="100" align="center">
                        满意</td>
                    <td width="100" align="center">
                        比较满意</td>
                    <td width="100" align="center">
                        不满意</td>
                    <td width="100" align="center">
                        未提交</td>
                </tr>
                <tr height="25">
                    <td align="center">
                        <%#GetCount1(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount2(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount3(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount4(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount5(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount6(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount7(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount8(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount9(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount10(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                    <td align="center">
                        <%#GetCount11(DataBinder.Eval(Container.DataItem,"BoxGuid"))%>
                    </td>
                </tr>
            </table>
            <div style="padding-top:5px;"></div>
            
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
