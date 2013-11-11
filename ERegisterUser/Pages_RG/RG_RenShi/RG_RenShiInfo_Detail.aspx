<%@ Page Language="C#" MasterPageFile="~/WebMaster/Blank.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_RenShi.RG_RenShiInfo_Detail" CodeBehind="RG_RenShiInfo_Detail.aspx.cs"
    Title="查看人事信息" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Ajax.FileUpload" Namespace="Epoint.Ajax.FileUpload"
    TagPrefix="cc1" %>
<%@ Register Src="../../Ascx/CaiLiao.ascx" TagName="CaiLiao" TagPrefix="uc1" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr style="display: none">
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="宋体"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1" align="center">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            员工人数
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="YuanGong_2022" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            兼职人数
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="JianZhi_2022" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            博士人数
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="BoShi_2022" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            硕士人数
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ShuoShi_2022" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            本科人数
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="BenKe_2022" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            其他人员数量
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="OtherRenYaun_2022" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            海归人数
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="HaiGui_2022" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            季度
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="lblJD" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            海外归国人员信息
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="HaiGuiInfo_2022" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            更新人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="UpdateUserName_2022" runat="server" MaxLength="50"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            更新时间
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="UpdateTime_2022" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            审核人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="CheckUserName_2022" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            审核时间
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="CheckTime_2022" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%" colspan="4">
                            <%--<asp:Label ID="UpdateUserName_2022" runat="server" MaxLength="50"></asp:Label>--%>
                            <asp:Label ID="IsHistory_2022" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="Status_2022" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="UpdateUserGuid_2022" runat="server" MaxLength="50"></asp:Label>
                            <%--<asp:Label ID="UpdateTime_2022" runat="server"></asp:Label>
                                    <asp:Label ID="CheckUserName_2022" runat="server" MaxLength="50"></asp:Label>--%>
                            <asp:Label ID="CheckUserGuid_2022" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="DWName_2022" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="DWGuid_2022" runat="server" MaxLength="50"></asp:Label>
                            <%--<asp:Label ID="CheckTime_2022" runat="server"></asp:Label>--%>
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                            <epoint:DateTextBox CssClass="inputtxt" ID="s_qiJian_2022" runat="server" InputDateType="Input"
                                        Width="202px" Character="HX" Style="display: none"></epoint:DateTextBox>
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
                                    <asp:TemplateColumn HeaderText="日期">
                                        <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                                        <ItemTemplate>
                                            <%#GetJD(DataBinder.Eval(Container, "DataItem.s_qiJian"))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="员工人数">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.YuanGong")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="兼职人数">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.JianZhi")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="博士人数">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.BoShi")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="硕士人数">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ShuoShi")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="本科人数">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.BenKe")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="海归人数">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HaiGui")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="其他人员">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.OtherRenYaun")%>
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
                                            <a href='javascript:OpenWindow("RG_RenShiInfo_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",800,700)'>
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
