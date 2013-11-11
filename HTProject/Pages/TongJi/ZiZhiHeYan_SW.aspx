<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiZhiHeYan_SW.aspx.cs"
    Inherits="HTProject.Pages.TongJi.ZiZhiHeYan_SW" MasterPageFile="~/WebMaster/ContentPageNoTop.Master" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function AllAreaExcel() {
            var oXL;
            try {
                oXL = new ActiveXObject("Excel.Application");
            }
            catch (e)
            { }
            if (oXL == null) {
                oXL = new ActiveXObject("ET.Application"); 
            }
            var oWB = oXL.Workbooks.Add();
            var oSheet = oWB.ActiveSheet;
            var sel = document.body.createTextRange();
            sel.moveToElementText(report);
            sel.select();
            sel.execCommand("Copy");
            oSheet.Columns("A").ColumnWidth = 5; //设置列宽
            oSheet.Columns("B:G").ColumnWidth = 20; //设置列宽
            oSheet.Columns("H").ColumnWidth = 5; //设置列宽
            oSheet.Columns("I").ColumnWidth = 10; //设置列宽
            oSheet.Columns("J").ColumnWidth = 10; //设置列宽
            oSheet.Columns("K").ColumnWidth = 20; //设置列宽 
            oSheet.Paste();
            oXL.Visible = true;
        }

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0" class="table">
                <tbody>
                    <tr style="display: none">
                        <td style="height: 30px" class="tablespecial" colspan="2">
                            当前数据表：<asp:Label ID="lblTableName" runat="server"></asp:Label><input id="HidState"
                                type="hidden" value="0" name="HidState" runat="server">
                        </td>
                    </tr>
                    <tr class="tablespecial">
                        <td id="tdCl" valign="middle" align="center" colspan="2" runat="server">
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                            <table width="100%">
                                <tr>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        核验时间
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <epoint:DateFromTo ID="HYDate" runat="server" />
                                    </td>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        &nbsp;
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
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
                                                ID="btnSearch" runat="server" Text="关闭搜索" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="查找" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                                        </td>
                                        <td>
                                            <input type="hidden" id="hidSelectedFields" runat="server" />
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                                ID="btnExcel" OnClientClick="AllAreaExcel();" runat="server"
                                                Text="导出EXCEL" />
                                        </td>
                                        <td style="display: none;">
                                            &nbsp;
                                        </td>
                                        <td style="display: none;">
                                            &nbsp;
                                        </td>
                                        <td style="display: none;">
                                            <epoint:Button ID="btnRefresh" MouseOverClass="ButtonSearch" runat="server" Text="刷新"
                                                CssClass="ButtonSearchNoBg" OnClick="btnRefresh_Click"></epoint:Button>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"  id="tdExcel" runat="server">
                            
                        </td>
                    </tr>
                    
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;
</asp:Content>
