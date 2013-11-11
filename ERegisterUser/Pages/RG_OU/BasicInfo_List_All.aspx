<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" Title="所有项目"
    AutoEventWireup="true" CodeBehind="BasicInfo_List_All.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_OU.BasicInfo_List_All" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="epoint" %>
<%--<%@ Register Src="../../../Controls/DropDownButton.ascx" TagName="DropDownButton"
    TagPrefix="uc1" %>--%>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>


        function OpenUrl() {
            OpenWindow('Pro_Type_Select.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>', 800, 500);
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
        function selHY() {
            var rtnValue;
            var url;
            var ParentOUGuid;
            url = "../Fund/DiDian.aspx?Cat=HangYe";

            rtnValue = window.showModalDialog(url, '', 'dialogHeight:500px;dialogWidth:300px;edge:raised;center:Yes;help:No;resizable:Yes;status:no;scroll:yes;unadorned:yes;');

            if (rtnValue != "" && rtnValue != null) {
                var ss;

                ss = rtnValue.split("/");

                document.getElementById("<%=s_suoShuHY.ClientID %>").value = ss[0];
                document.getElementById("<%=s_suoShuHY_guid.ClientID %>").value = ss[1];


            }
        }

        //-->
    </script>
    <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0" class="table">
        <tbody>
            <tr style="display: none">
                <td style="height: 30px" class="tablespecial" colspan="2">
                    当前数据表：<asp:Label ID="lblTableName" runat="server"></asp:Label><input id="HidState"
                        type="hidden" value="0" name="HidState" runat="server">
                    <epoint:TextBox ID="s_suoShuHY_guid" CssClass="inputtxt" Width="100px" runat="server">
                    </epoint:TextBox>
                </td>
            </tr>
            <tr class="tablespecial">
                <td id="tdCl" valign="middle" align="center" colspan="2" runat="server" style="display: none">
                    <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr class="tablespecial">
                <td id="td2" valign="middle" align="center" colspan="2" runat="server" style="display: none">
                    <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                        <tr>
                            <td class="Tablespecial1" width="15%" align="Right">
                                项目经理
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <epoint:TextBox ID="s_xiangMuJL" CssClass="inputtxt" runat="server" MaxLength="50"></epoint:TextBox>
                            </td>
                            <td class="Tablespecial1" width="15%" align="Right">
                                登记日期
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <epoint:DateFromTo ID="d_dengJiRQ" FromTextCssClass="inputtxt" ToTextCssClass="inputtxt"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="Tablespecial1" width="15%" align="Right">
                                项目编号
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <epoint:TextBox ID="s_xiangmuBH" CssClass="inputtxt" runat="server" MaxLength="200"></epoint:TextBox>
                            </td>
                            <td class="Tablespecial1" width="15%" align="Right">
                                决策日期
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <epoint:DateFromTo ID="d_TouZiJCSJ" FromTextCssClass="inputtxt" ToTextCssClass="inputtxt"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="Tablespecial1" width="15%" align="Right">
                                项目登记人
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <epoint:TextBox ID="s_dengJiR" CssClass="inputtxt" runat="server" MaxLength="50"></epoint:TextBox>
                            </td>
                            <td class="Tablespecial1" width="15%" align="Right">
                                项目来源
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <asp:DropDownList ID="s_xiangMuLY" runat="server" Height="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="Tablespecial1" width="15%" align="Right">
                                项目名称
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <epoint:TextBox ID="s_xiangMuMC" CssClass="inputtxt" runat="server" MaxLength="200"></epoint:TextBox>
                            </td>
                            <td class="Tablespecial1" width="15%" align="Right">
                                项目公司全称
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <epoint:TextBox ID="s_xiangMuGSQC" CssClass="inputtxt" runat="server" MaxLength="200"></epoint:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="Tablespecial1" width="15%" align="Right">
                                所属行业
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle" style="display: none">
                                <epoint:TextBox ID="s_suoShuHY" runat="server" CssClass="inputtxt" MaxLength="50"
                                    contenteditable="false"></epoint:TextBox>
                                <input id="Button1" type="button" value="..." class="btnTime" onclick="selHY();"
                                    runat="server" />
                            </td>
                            <td class="Tablespecial1" width="15%" align="Right">
                                立项申请人
                            </td>
                            <td class="Tablespecial" width="35%" height="25" valign="middle">
                                <epoint:TextBox ID="s_LiXiangSQR" CssClass="inputtxt" runat="server" MaxLength="50"></epoint:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="Tablespecial1" width="15%" align="Right">
                                管理平台
                            </td>
                            <td class="Tablespecial" width="85%" height="25" valign="middle" colspan="3">
                                <asp:CheckBoxList ID="s_GuanLiPT" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="Tablespecial1" width="15%" align="Right">
                                项目状态
                            </td>
                            <td class="Tablespecial" width="85%" height="25" valign="middle" colspan="3">
                                <asp:CheckBoxList ID="s_xiangMuZT" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Tablespecial1">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;<epoint:Button MouseOverClass="ButtonOK" ForeColor="black" CssClass="ButtonOKNoBg"
                                    ID="btnSearch" runat="server" Text="打开搜索" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                    Text="查找" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                            </td>
                            <td>
                                <input type="hidden" id="hidSelectedFields" runat="server" />
                            </td>
                            <%--<td>
                                <uc1:DropDownButton ID="DropDownButton1" runat="server" OldProjectHref="Cop/Pro_select.aspx"
                                    NewProjectHref="Cop/BasicInfo_Add.aspx" />
                            </td>--%>
                            <td style="display: none">
                                &nbsp;<epoint:DeleteButton Text="中止项目" ID="DeleteButton1" MouseOverClass="ButtonDel"
                                    runat="server" CssClass="ButtonDelNoBg" OnClick="btnStop_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                    RaiseMsg="您确定要终止选定项目吗?" />
                            </td>
                            <td style="display: none">
                                &nbsp;<epoint:DeleteButton Text="删除选定" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                    CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                    RaiseMsg="您确定删除选定记录吗?" />
                            </td>
                            <td style="display: none">
                                &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                    ID="btnExcel" runat="server" Text="导出EXCEL" Visible="false" OnClick="btnExcel_ServerClick" />
                                <input id="hidXmlData" type="hidden" runat="server" />
                            </td>
                            <td style="display: none">
                                &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                    ID="btnTest" OnClientClick="if (!SelectColumns()) {return false;}" runat="server"
                                    Text="导出EXCEL" OnClick="btnTest_ServerClick" />
                                <input id="Hidden1" type="hidden" runat="server" />
                            </td>
                            <td style="display: none">
                                <a href="#" onclick="OpenWindow('BasicInfo_List_All_Excel.aspx',800,600);">导出</a>
                            </td>
                            <td style="display: none">
                                &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                    ID="btOther" runat="server" Text="其他数据导出" OnClientClick="OpenWindow('BasicInfo_List_All_Excel.aspx',800,600);" />
                            </td>
                        </tr>
                    </table>
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
                                <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                                <HeaderTemplate>
                                    <input id="chkAddAll" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAdd" runat="server" Enabled='<%#GetDeleteState(DataBinder.Eval(Container, "DataItem.s_xiangMuZT"))%>'>
                                    </asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="序号">
                                <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                                <ItemTemplate>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="项目编号" SortExpression="s_xiangMuBH">
                                <ItemStyle Width="100px" />
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.s_xiangMuBH") %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="项目名称" SortExpression="s_xiangMuMC">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.s_xiangMuMC") %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="管理平台" SortExpression="s_guanLiPT">
                                <ItemStyle Width="120px" />
                                <ItemTemplate>
                                    <%#new SVGBLL.Pro_Fund().Get_GuanLiPTByGuanLiPTGuid(DataBinder.Eval(Container, "DataItem.s_guanLiPT").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="项目状态" SortExpression="s_xiangMuZT">
                                <ItemStyle Width="80px" />
                                <ItemTemplate>
                                    <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("苏州创投_项目状态", Convert.ToString(DataBinder.Eval(Container, "DataItem.s_xiangMuZT"))) %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="项目经理" SortExpression="s_xiangMuJL">
                                <ItemStyle Width="50px" />
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.s_xiangMuJL") %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="登记人" SortExpression="s_dengJiR">
                                <ItemStyle Width="50px" />
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.s_dengJiR")%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="登记日期" SortExpression="d_dengJiRQ">
                                <ItemStyle Width="90px" />
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.d_dengJiRQ", "{0:yyyy-M-d}") %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="关联企业" SortExpression="DWName">
                                <ItemStyle Width="180px" />
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.DWName")%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <%--<asp:TemplateColumn HeaderText="查看">
                                <ItemStyle HorizontalAlign="Center" Width="30"></ItemStyle>
                                <ItemTemplate>
                                    <a href='javascript:OpenMaxWindow("ProjectFrame.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&ProjectGuid=<%#DataBinder.Eval(Container.DataItem,"ProjectGuid")%>&OneGuid=<%#DataBinder.Eval(Container.DataItem,"OneGuid")%>")'>
                                        <img src='../../../../images/bigview.gif' border='0'></a>
                                </ItemTemplate>
                            </asp:TemplateColumn>--%>
                            <asp:TemplateColumn HeaderText="关联">
                                <ItemStyle HorizontalAlign="Center" Width="30"></ItemStyle>
                                <ItemTemplate>
                                    <a href='javascript:OpenWindow("../SelDWForPro.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&ProjectGuid=<%#DataBinder.Eval(Container.DataItem,"ProjectGuid")%>&OneGuid=<%#DataBinder.Eval(Container.DataItem,"OneGuid")%>",800,700)'>
                                        <img src='../../../images/edit.gif' border='0'></a>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="查看">
                                <ItemStyle HorizontalAlign="Center" Width="30"></ItemStyle>
                                <ItemTemplate>
                                    <%--<a href='javascript:OpenWindow("RG_OU_DetailForPro.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>")'>
                                        <img src='../../../images/bigview.gif' border='0'></a>--%>
                                    <%#GetOULink(DataBinder.Eval(Container, "DataItem.RowGuid"), DataBinder.Eval(Container, "DataItem.DWGuid"))%>
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
                        <Columns>
                            <asp:TemplateColumn HeaderText="管理平台" SortExpression="s_guanLiPT">
                                <ItemTemplate>
                                    <%# new SVGBLL.Pro_Fund().Get_GuanLiPTByGuanLiPTGuid(DataBinder.Eval(Container, "DataItem.s_xiangMuZT").ToString()) %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
        </tbody>
    </table>
    &nbsp;
</asp:Content>
