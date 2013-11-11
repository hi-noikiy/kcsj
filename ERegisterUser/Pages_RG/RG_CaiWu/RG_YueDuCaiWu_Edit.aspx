<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_CaiWu.RG_YueDuCaiWu_Edit" CodeBehind="RG_YueDuCaiWu_Edit.aspx.cs"
    Title="月度财务报表" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
        function GetQY() {

            var zzc = parseFloat("0");
            var zfz = parseFloat("0");
            if (document.getElementById("<%=ZongZiChan_2020.ClientID %>").value != "") {
                zzc = parseFloat(document.getElementById("<%=ZongZiChan_2020.ClientID %>").value.replace(",", ""));
            }
            else {
                document.getElementById("<%=ZongZiChan_2020.ClientID %>").value = "0";
            }
            if (zzc == "NaN") {
                zzc = parseFloat("0");

            }
            if (document.getElementById("<%=ZongFuZhai_2020.ClientID %>").value != "") {
                zfz = parseFloat(document.getElementById("<%=ZongFuZhai_2020.ClientID %>").value.replace(",", ""));
            }
            else {
                document.getElementById("<%=ZongFuZhai_2020.ClientID %>").value = "0";
            }
            if (zfz == "NaN") {
                zfz = parseFloat("0");
            }

            document.getElementById("<%=SuoYouZheQY_2020.ClientID %>").value = zzc - zfz;
        }
        function GetMLL() {

            var sr = parseFloat("0");
            var cb = parseFloat("0");
            if (document.getElementById("<%=ZhuYingShouRu_2020.ClientID %>").value != "") {
                sr = parseFloat(document.getElementById("<%=ZhuYingShouRu_2020.ClientID %>").value.replace(",", ""));
            }
            else {
                document.getElementById("<%=ZhuYingShouRu_2020.ClientID %>").value = "0";
            }
            if (sr == "NaN") {
                sr = parseFloat("0");

            }
            if (document.getElementById("<%=ZhuYIngChengBen_2020.ClientID %>").value != "") {
                cb = parseFloat(document.getElementById("<%=ZhuYIngChengBen_2020.ClientID %>").value.replace(",", ""));
            }
            else {
                document.getElementById("<%=ZhuYIngChengBen_2020.ClientID %>").value = "0";
            }
            if (cb == "NaN") {
                cb = parseFloat("0");
            }

            document.getElementById("<%=MaoLiLv_2020.ClientID %>").value = ((sr - cb) / sr * 100).toPrecision(4).toString();
        }
        function SaveB() {
            GetQY();
            GetMLL();
            if (!Page_ClientValidate()) {
                return true;
            }
            return false;
        }
    </script>
    <cc1:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <epoint:Button ID="btnEdit" runat="server" Text="提交审核" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnEdit_Click" OnClientClick="return SaveB();"></epoint:Button>
                        </td>
                        <td style="display: none">
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="取消修改" runat="server" CausesValidation="false" OnClientClick="window.close();">
                            </epoint:Button>
                        </td>
                        <td>
                            <span style="color:Red">所有的数据均为当月数据</span>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr style="display: none">
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                        align="center" valign="middle">
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
                                    <epoint:TextBox ID="DWName_2020" runat="server" MaxLength="500" contenteditable="false"></epoint:TextBox>
                                    <epoint:TextBox ID="DWGuid_2020" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    年
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ddlYear" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    月
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ddlMonth" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    货币类型
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="BiZhong_2020" runat="server">
                                    </asp:DropDownList>
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
                                    <epoint:NumericTextBox ID="GuDingZCJZ" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    无形资产净值
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="WuXIngZCJZ" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    货币资金
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="HuiBiZiJin_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    总资产
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ZongZiChan_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" onBlur="GetQY();"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    应收账款
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="YingShouZhangKuan_2020" runat="server" TextAlign="Right"
                                        Style="padding-right: 2px; padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    其他应收款
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="OtherShouKuan_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    存货
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="CunHuo_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    流动资产
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="LiuDongZiChan_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    短期借款
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="DuanQiJieKuan_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    流动负债
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="LiuDongFuZhai_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    长期借款
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ChangQiJieKuan_2020" runat="server" TextAlign="Right"
                                        Style="padding-right: 2px; padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    总负债
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ZongFuZhai_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" onBlur="GetQY();"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    股本（实收资本）
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="GuBen_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    所有者权益
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="SuoYouZheQY_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" contenteditable="false"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    主营业务收入
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ZhuYingShouRu_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" onBlur="GetMLL();"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    主营业务成本
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ZhuYIngChengBen_2020" runat="server" TextAlign="Right"
                                        Style="padding-right: 2px; padding-left: 2px" onBlur="GetMLL();"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    当月总收入
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="DangQiZongShouRu_2020" runat="server" TextAlign="Right"
                                        Style="padding-right: 2px; padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    毛利率
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="MaoLiLv_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" contenteditable="false"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>%
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    管理费用
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="GuanLiFeiYong_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    研发费用
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="YanFaFeiYong_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    当期利润
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="DangQiLiRun_2020" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    当期净利润
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="DangQiJingLiRun_2020" runat="server" TextAlign="Right"
                                        Style="padding-right: 2px; padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td colspan="4">
                                    <epoint:TextBox ID="Year_2020" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="Month_2020" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:DateTextBox ID="YearMonth_2020" runat="server" InputDateType="Input" Character="HX"
                                        Style="display: none"></epoint:DateTextBox>
                                    <epoint:TextBox ID="Status_2020" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="UpdateUserName_2020" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="UpdateUserGuid_2020" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="UpdateTime_2020" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                    <epoint:TextBox ID="CheckUserName_2020" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="CheckUserGuid_2020" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="IsHistory_2020" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="CheckTime_2020" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
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
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
