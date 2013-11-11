<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.RG_Application.RG_Application_List" Title="应用子系统列表"
    CodeBehind="RG_Application_List.aspx.cs" %>

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
            OpenDialogRefresh('RG_Application_Add.aspx', "", 550, 500);
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
                                        <%-- <td>
                                            <input type="hidden" id="hidSelectedFields" runat="server" />
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                                ID="btnExcel" OnClientClick="if (!SelectColumns()) {return false;}" runat="server"
                                                Text="导出EXCEL" OnClick="btnExcel_ServerClick" />
                                        </td>--%>
                                        <td>
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="添加系统" />
                                        </td>
                                        <td>
                                            <epoint:Button ID="btnQuickNew" runat="server" Text="快速添加" CssClass="ButtonAddNoBg"
                                                MouseOverClass="ButtonAdd" OnClick="btnQuickNew_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:DeleteButton Text="删除选定" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="您确定删除选定记录吗?" />
                                        </td>
                                        <td>
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
                                AccessKey="1" DataKeyField="AppGuid" AutoGenerateColumns="False" AllowPaging="True"
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
                                    <asp:TemplateColumn HeaderText="系统名称" SortExpression="AppName">
                                        <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                        <ItemTemplate>
                                            <epoint:TextBox ID="txtName" CssClass="inputtxt" MaxLength="200" TextAlign="Left"
                                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AppName") %>' AllowNull="false"
                                                Width="99%"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="系统URL" SortExpression="AppUrl">
                                        <HeaderStyle HorizontalAlign="Center" Width="360px"></HeaderStyle>
                                        <ItemTemplate>
                                            <epoint:TextBox ID="txtUrl" CssClass="inputtxt" MaxLength="200" TextAlign="Left"
                                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AppUrl") %>' AllowNull="true"
                                                Width="358px"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="排序" SortExpression="OrderNum">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemTemplate>
                                            <epoint:TextBox ID="txtOrderNum" CssClass="inputtxt" TextAlign="Left" runat="server"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.OrderNum") %>' Width="90%"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="用户名" SortExpression="ShortcutText">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.UserName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="企业类型授权" SortExpression="">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('RG_Application_OUTypeRight.aspx?AppGuid='+'<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>'+'&AppType='+'<%#(DataBinder.Eval(Container, "DataItem.AppType"))%>','<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','600','500')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="账号类型授权" SortExpression="">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('RG_Application_RoleRight.aspx?AppGuid='+'<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>'+'&AppType='+'<%#(DataBinder.Eval(Container, "DataItem.AppType"))%>','<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','600','500')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="账号授权" SortExpression="">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('RG_Application_UserRight.aspx?AppGuid='+'<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>'+'&AppType='+'<%#(DataBinder.Eval(Container, "DataItem.AppType"))%>','<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','600','500')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="禁用" SortExpression="IsForbid">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsForbid"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="弹出" SortExpression="IsBlank">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsBlank"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="事项">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenDialogRefresh("RG_Application_Matter.aspx?AppGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>","",800,600)'>
                                                <img src='../../../images/add1.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="修改">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenDialogRefresh("RG_Application_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>","",550,450)'>
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
