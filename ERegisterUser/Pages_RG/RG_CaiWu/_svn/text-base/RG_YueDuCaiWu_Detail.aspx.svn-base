<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_CaiWu.RG_YueDuCaiWu_Detail" CodeBehind="RG_YueDuCaiWu_Detail.aspx.cs"
    Title="查看数据明细" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="宋体"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1" align="center" id="tabContent">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            企业名称
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="DWName_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            年
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Year_2020" runat="server" MaxLength="50"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            月
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Month_2020" runat="server" MaxLength="50"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            货币类型
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="BiZhong_2020" runat="server">
                            </asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            固定资产净值
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="GuDingZCJZ" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            无形资产净值
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="WuXIngZCJZ" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            货币资金
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="HuiBiZiJin_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            总资产
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZongZiChan_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            应收账款
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="YingShouZhangKuan_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            其他应收款
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="OtherShouKuan_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            存货
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="CunHuo_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            流动资产
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LiuDongZiChan_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            短期借款
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DuanQiJieKuan_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            流动负债
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LiuDongFuZhai_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            长期借款
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ChangQiJieKuan_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            总负债
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZongFuZhai_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            股本（实收资本）
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="GuBen_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            所有者权益
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="SuoYouZheQY_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            主营业务收入
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZhuYingShouRu_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            主营业务成本
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZhuYIngChengBen_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            当月总收入
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DangQiZongShouRu_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            毛利率
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="MaoLiLv_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            管理费用
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="GuanLiFeiYong_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            研发费用
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="YanFaFeiYong_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            当期利润
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DangQiLiRun_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            当期净利润
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DangQiJingLiRun_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            更新人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="UpdateUserName_2020" runat="server" MaxLength="50"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            更新时间
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="UpdateTime_2020" runat="server" InputDateType="Input" Character="HX"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            审核人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="CheckUserName_2020" runat="server" MaxLength="50"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            审核时间
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="CheckTime_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td colspan="4">
                            <asp:Label ID="YearMonth_2020" runat="server" InputDateType="Input" Character="HX"
                                Style="display: none"></asp:Label>
                            <asp:Label ID="Status_2020" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="UpdateUserGuid_2020" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="CheckUserGuid_2020" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="IsHistory_2020" runat="server" MaxLength="50"></asp:Label>
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%" colspan="4">
                            历史记录
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4" style="height: 31px" class="tablespecial">
                            <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                PagingButtonType="Image" NavigationButtonType="Image" PageSize="20" OnPageChanged="Pager_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
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
                                    <asp:TemplateColumn HeaderText="年">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.Year") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="月">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.Month") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="货币资金">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HuiBiZiJin")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="总资产">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZongZiChan")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
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
                                            <%# DataBinder.Eval(Container, "DataItem.CheckTime", "{0:yyyy-MM-dd}") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="状态" SortExpression="Status">
                                        <ItemTemplate>
                                            <%#GetStatus( DataBinder.Eval(Container, "DataItem.Status")) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="查看">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenWindow("RG_YueDuCaiWu_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",800,700)'>
                                                <img src='../../../images/bigview.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="修改">
                                                <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                <ItemTemplate>
                                                    <a href='javascript:parent.OpenDiagWin2("修改记录","RG_DongTai_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&sType=1&DWGuid=<%=ViewState["DWGuid"]%>")'>
                                                        <img src='../../../images/add1.gif' border='0'></a>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>--%>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" height="40">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">没有数据！</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
