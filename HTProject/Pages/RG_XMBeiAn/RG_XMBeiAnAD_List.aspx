<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_XMBeiAn.RG_XMBeiAnAD_List" Title="数据记录列表" CodeBehind="RG_XMBeiAnAD_List.aspx.cs" %>

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
            OpenWindow('RG_XMBeiAn_Add.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>&DWGuid=<%=Request.QueryString["DWGuid"]%>', 800, 700);
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
                            <table width="100%">
                                <tr>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        勘察设计单位
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <epoint:TextBox ID="DWName" runat="server"></epoint:TextBox>
                                    </td>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        审核状态
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <asp:DropDownList ID="ddlStatus" runat="server">
                                        </asp:DropDownList>
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
                                        <td style="display: none">
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="新增记录" />
                                        </td>
                                        <td style="display: none">
                                            &nbsp;<epoint:DeleteButton Text="删除选定" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="您确定删除选定记录吗?" />
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
                                    <%--<asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <HeaderTemplate>
                                            <input id="chkAddAll" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAdd" runat="server" Enabled='<%# new HTProject_Bizlogic.DB_RG_DW().CanOperate2(DataBinder.Eval(Container, "DataItem.Status")) %>'>
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="序号">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="项目编号" SortExpression="XMBH">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XMBH")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="项目名称" SortExpression="XMName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XMName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="项目地点" SortExpression="XMAdd">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("项目地点", Convert.ToString(DataBinder.Eval(Container, "DataItem.XMAdd")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="总投资" SortExpression="ToTalMoney">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ToTalMoney") %>万元
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="资质等级" SortExpression="ZiZhiDJ">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiDJ") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="资质编号" SortExpression="ZiZhiBH">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiBH") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="合同价格" SortExpression="HeTongMoney">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HeTongMoney") %>万元
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="项目负责人" SortExpression="XMFZR">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XMFZR") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="删除状态" SortExpression="DelStatus">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("删除状态", Convert.ToString(DataBinder.Eval(Container, "DataItem.DelStatus"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="建设单位" SortExpression="JSDWName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.JSDWName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="规模及等级" SortExpression="GuiMoDJ">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("项目规模等级", Convert.ToString(DataBinder.Eval(Container, "DataItem.GuiMoDJ"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="勘察设计单位名称" SortExpression="DWGuid">
                                        <ItemTemplate>
                                            <%# RG_DW.GetDWName( DataBinder.Eval(Container, "DataItem.DWGuid")) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="建设单位项目联系人" SortExpression="XMLXR_JS">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XMLXR_JS") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="建设单位联系人电话" SortExpression="LXDH_JS">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.LXDH_JS") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="勘察设计单位项目联系人" SortExpression="XMLXR_KS">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XMLXR_KS") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="勘察设计单位联系电话" SortExpression="LXDH_KS">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.LXDH_KS") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="审核状态" SortExpression="Status">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("审核状态", Convert.ToString(DataBinder.Eval(Container, "DataItem.Status"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="查看">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <%#HTProject_Bizlogic.CommonFunc.GetStatusPic(DataBinder.Eval(Container, "DataItem.Status"), DataBinder.Eval(Container, "DataItem.TJDate"), "../../..")%>
                                            <a href='javascript:OpenWindow("RG_XMBeiAnAD_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                <img src='../../../images/bigview.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="修改">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new HTProject_Bizlogic.DB_RG_DW().GetOperateButton(DataBinder.Eval(Container, "DataItem.RowGuid"), DataBinder.Eval(Container, "DataItem.Status"), "RG_XMBeiAn_Edit.aspx", "../../../images/add1.gif")%>
                                            <a href='javascript:OpenWindow("RG_XMBeiAn_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                <img src='../../../images/add1.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
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
