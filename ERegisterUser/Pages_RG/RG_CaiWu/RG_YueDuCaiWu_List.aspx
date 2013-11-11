<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_CaiWu.RG_YueDuCaiWu_List" CodeBehind="RG_YueDuCaiWu_List.aspx.cs"
    Title="数据记录列表" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>

        function OpenUrl() {
            OpenWindow('RG_YueDuCaiWu_Add.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>&RowGuid=<%=Guid.NewGuid().ToString()%>&DWGuid=<%=ViewState["DWGuid"]%>', 800, 700);
        }

        function SelectColumns() {
            var url = '<%=Request.ApplicationPath %>/EpointMis/Pages/CommonPages/SelectExportFields.aspx?TableID=<%=TableID%>';
            var SelectedColumns = OpenDialog(url, 800, 400);
            document.all("<%=hidSelectedFields.ClientID %>").value = SelectedColumns;
            if (SelectedColumns != "") {
                return true;
            }
            else {
                return false;
            }
        }


        //-->
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
                        <td id="tdCl" valign="middle" align="center" colspan="2" runat="server" style="display: none">
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
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
                                        <td style="display: none">
                                            &nbsp;<epoint:Button MouseOverClass="ButtonOK" ForeColor="black" CssClass="ButtonOKNoBg"
                                                ID="btnSearch" runat="server" Text="打开搜索" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="查找" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                                        </td>
                                        <td style="display: none">
                                            <input type="hidden" id="hidSelectedFields" runat="server" />
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                                ID="btnExcel" OnClientClick="if (!SelectColumns()) {return false;}" runat="server"
                                                Text="导出EXCEL" OnClick="btnExcel_ServerClick" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="新增记录" />
                                        </td>
                                        <td style="display: none">
                                            &nbsp;<epoint:DeleteButton Text="删除选定" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="您确定删除选定记录吗?" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" style="height: 31px" class="tablespecial">
                            <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                PagingButtonType="Image" NavigationButtonType="Image" PageSize="20" OnPageChanged="Pager_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:DataGrid ID="Datagrid1" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                AllowSorting="True" Width="100%" OnItemCreated="Datagrid1_ItemCreated" OnSortCommand="Datagrid1_SortCommand">
                                <PagerStyle Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <HeaderTemplate>
                                            <input id="chkAddAll" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAdd" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="序号">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="单位Guid" SortExpression="DWGuid">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DWGuid") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <%--<asp:TemplateColumn HeaderText="单位名称" SortExpression="DWName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DWName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="年" SortExpression="Year">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.Year") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="月" SortExpression="Month">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.Month") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="年月" SortExpression="YearMonth">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.YearMonth", "{0:yyyy-M-d}") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="货币类型" SortExpression="BiZhong">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("苏州创投_货币类型", Convert.ToString(DataBinder.Eval(Container, "DataItem.BiZhong")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="货币资金" SortExpression="HuiBiZiJin">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HuiBiZiJin") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="总资产" SortExpression="ZongZiChan">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZongZiChan") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="其他应收款" SortExpression="OtherShouKuan">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.OtherShouKuan") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="应收账款" SortExpression="YingShouZhangKuan">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.YingShouZhangKuan") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="存货" SortExpression="CunHuo">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.CunHuo") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="流动资产" SortExpression="LiuDongZiChan">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.LiuDongZiChan") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <%--<asp:TemplateColumn HeaderText="长期借款" SortExpression="ChangQiJieKuan">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ChangQiJieKuan") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="总负债" SortExpression="ZongFuZhai">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZongFuZhai") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="股本" SortExpression="GuBen">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.GuBen") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="所有者权益" SortExpression="SuoYouZheQY">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.SuoYouZheQY") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="当期总收入" SortExpression="DangQiZongShouRu">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DangQiZongShouRu") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="主营业务收入" SortExpression="ZhuYingShouRu">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuYingShouRu") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="主营业务成本" SortExpression="ZhuYIngChengBen">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuYIngChengBen") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="当期净利润" SortExpression="DangQiJingLiRun">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DangQiJingLiRun") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="状态" SortExpression="Status">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.Status") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="更新人" SortExpression="UpdateUserName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.UpdateUserName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="更新日期" SortExpression="UpdateTime">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.UpdateTime", "{0:yyyy-MM-dd}") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="审核人" SortExpression="CheckUserName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.CheckUserName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="审核日期" SortExpression="CheckTime">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.CheckTime", "{0:yyyy-MM-dd}")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="短期借款" SortExpression="DuanQiJieKuan">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DuanQiJieKuan") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="流动负债" SortExpression="LiuDongFuZhai">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.LiuDongFuZhai") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="毛利率" SortExpression="MaoLiLv">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.MaoLiLv") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="管理费用" SortExpression="GuanLiFeiYong">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.GuanLiFeiYong") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="研发费用" SortExpression="YanFaFeiYong">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.YanFaFeiYong") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="当期利润" SortExpression="DangQiLiRun">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DangQiLiRun") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="查看">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenWindow("RG_YueDuCaiWu_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",800,700)'>
                                                <img src='../../../images/bigview.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="修改">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenWindow("RG_YueDuCaiWu_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",800,700)'>
                                                <img src='../../../images/add1.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DataGrid ID="GridExcel" runat="server" CssClass="GridView" PageSize="20" Width="100%"
                                AllowSorting="True" AutoGenerateColumns="False" DataKeyField="RowGuid" BorderWidth="1px"
                                OnItemDataBound="GridExcel_ItemDataBound" EnableViewState="false">
                                <PagerStyle Visible="False"></PagerStyle>
                                <HeaderStyle CssClass="HeaderStyle" HorizontalAlign="Center" />
                                <AlternatingItemStyle CssClass="RowStyle" />
                                <ItemStyle CssClass="RowStyle" />
                            </asp:DataGrid>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;
</asp:Content>
