<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageNoLocation.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.RG_Matters.Matter_List" Title="事项列表" CodeBehind="Matter_List.aspx.cs" %>

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
            OpenDialogArgs('Matter_Add.aspx?ParentGuid=<%=ParentGuid%>', "", 700, 680);
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
                                        <td>
                                            &nbsp;<epoint:Button MouseOverClass="ButtonOK" ForeColor="black" CssClass="ButtonOKNoBg"
                                                ID="btnSearch" runat="server" Text="打开搜索" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="查找" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                                        </td>
                                        <%--  <td>
                                            <input type="hidden" id="hidSelectedFields" runat="server" />
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                                ID="btnExcel" OnClientClick="if (!SelectColumns()) {return false;}" runat="server"
                                                Text="导出EXCEL" OnClick="btnExcel_ServerClick" />
                                        </td>--%>
                                        <td id="tdAdd" runat="server">
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="新增事项" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:DeleteButton Text="删除选定" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="您确定删除选定事项吗?" />
                                        </td>
                                        <td id="tdQuickAdd" runat="server">
                                            <epoint:Button ID="btnQuickNew" runat="server" Text="快速添加" CssClass="ButtonAddNoBg"
                                                MouseOverClass="ButtonAdd" OnClick="btnQuickNew_Click" />
                                        </td>
                                        <td id="tdSave" runat="server">
                                            <epoint:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存修改" MouseOverClass="ButtonSave"
                                                CssClass="ButtonSaveNoBg" />
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
                                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="事项名称" SortExpression="MatterName">
                                        <HeaderStyle HorizontalAlign="Center" Width="140px"></HeaderStyle>
                                        <ItemTemplate>
                                            <%-- <%# DataBinder.Eval(Container, "DataItem.MatterName") %>--%>
                                            <epoint:TextBox ID="txtName" CssClass="inputtxt" MaxLength="100" TextAlign="Left"
                                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MatterName") %>'
                                                AllowNull="false" Width="140px"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="事项地址" SortExpression="MatterUrl">
                                        <HeaderStyle HorizontalAlign="Center" Width="300px"></HeaderStyle>
                                        <ItemTemplate>
                                            <epoint:TextBox ID="txtAddress" CssClass="inputtxt" MaxLength="200" TextAlign="Left"
                                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MatterUrl") %>'
                                                AllowNull="true" Width="298px"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="排序" SortExpression="OrderNum">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemTemplate>
                                            <epoint:TextBox ID="txtOrderNum" CssClass="inputtxt" MaxLength="50" TextAlign="Left"
                                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OrderNum") %>'
                                                AllowNull="false" Width="90%"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="来源" SortExpression="OrderNum">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                                        <ItemTemplate>
                                            <%# getSource(DataBinder.Eval(Container, "DataItem.RowGuid").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="企业类型授权" SortExpression="">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('RG_Matter_OUTypeRight.aspx?MatterGuid='+'<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','600','500')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="账号类型授权" SortExpression="">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('RG_Matter_RoleRight.aspx?MatterGuid='+'<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','600','500')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%-- <asp:TemplateColumn HeaderText="默认" SortExpression="IsDefault">
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsDefault"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="禁用" SortExpression="IsForbidden">
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsForbidden"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="隐藏" SortExpression="IsHidden">
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsHidden"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%-- <asp:TemplateColumn HeaderText="弹出" SortExpression="IsBlank">
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsBlank"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="修改">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenDialogArgs("Matter_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>","",700,680)'>
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
                    <tr>
                        <td colspan="2">
                            <table width="100%" height="100%" align="center">
                                <tr>
                                    <td>
                                        <div class="tit" id="menu1" title="生成模块菜单脚本">
                                            <div class="titpic" id="pc1">
                                            </div>
                                            <a title="生成模块菜单脚本" target="" class="on" id="A1" tabindex="1">生成模块菜单脚本 </a>
                                        </div>
                                        <div class="list" id="menu1_child" title="生成模块菜单脚本">
                                            <epoint:Button ID="btnGenerateSQL" runat="server" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                                Text="生成脚本" OnClick="btnGenerateSQL_Click"></epoint:Button>
                                            <asp:TextBox ID="txtSQL" runat="server" Height="300px" TextMode="MultiLine" Width="97%"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="100%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;
</asp:Content>
