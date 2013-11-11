<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageNoLocation.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_Module.Record_List" Title="数据记录列表" CodeBehind="Record_List.aspx.cs" %>

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
            OpenDialogArgs('Record_Add.aspx?IsBelongtoApp=<%=Request["IsBelongtoApp"]%>&ParentGuid=<%=Request.QueryString["ParentGuid"]%>&AppGuid=<%=Request["AppGuid"] %>', "", 550, 400);
        }


    </script>
    <script language="JavaScript" type="text/javascript" src="../../../javascript/navbar.js"></script>
    <link href="../../../javascript/navbar-pix.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var show = true;
        var hide = false;
        //修改菜单的上下箭头符号
        function my_on(head, body) {
            var tag_a;
            for (var i = 0; i < head.childNodes.length; i++) {
                if (head.childNodes[i].nodeName == "A") {
                    tag_a = head.childNodes[i];
                    break;
                }
            }
            tag_a.className = "on";
        }
        function my_off(head, body) {
            var tag_a;
            for (var i = 0; i < head.childNodes.length; i++) {
                if (head.childNodes[i].nodeName == "A") {
                    tag_a = head.childNodes[i];
                    break;
                }
            }
            tag_a.className = "off";
        }
        //添加菜单	
        window.onload = function () {
            m1 = new Menu("menu1", 'menu1_child', 'dtu', '100', show, my_on, my_off);
            m1.init();
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
                                        <td id="addbutton" runat="server">
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="添加记录" />
                                        </td>
                                        <td id="quickaddbutton" runat="server">
                                            <epoint:Button ID="btnQuickNew" runat="server" Text="快速添加" CssClass="ButtonAddNoBg"
                                                MouseOverClass="ButtonAdd" OnClick="btnQuickNew_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:DeleteButton Text="删除选定" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd','请选择需要删除的模块！')) return false;"
                                                RaiseMsg="确定删除该模块及其子模块？" />
                                        </td>
                                        <td>
                                            <epoint:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存修改" MouseOverClass="ButtonSave"
                                                CssClass="ButtonSaveNoBg" />
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
                                AllowSorting="True" Width="100%" OnItemCreated="Datagrid1_ItemCreated" OnSortCommand="Datagrid1_SortCommand" OnItemDataBound="Datagrid1_ItemDataBound">
                                <PagerStyle Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                    <asp:TemplateColumn HeaderText="模块名称" SortExpression="ModuleName">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <epoint:TextBox ID="txtName" CssClass="inputtxt" MaxLength="100" TextAlign="Left"
                                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ModuleName") %>'
                                                AllowNull="false" Width="98px"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="模块地址" SortExpression="ModuleAddress">
                                        <HeaderStyle HorizontalAlign="Center" Width="300px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <epoint:TextBox ID="txtAddress" CssClass="inputtxt" MaxLength="200" TextAlign="Left"
                                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ModuleAddress") %>'
                                                AllowNull="true" Width="298px"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="排序" SortExpression="OrderNum">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <epoint:TextBox ID="txtOrderNum" CssClass="inputtxt" MaxLength="50" TextAlign="Left"
                                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OrderNum") %>'
                                                AllowNull="false" Width="90%"></epoint:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderTemplate>
                                            公开<input id="chkAddAll2" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd2">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAdd2" runat="server"></asp:CheckBox>
                                            <asp:Label ID="lblRGuid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RowGuid") %>' style="display:none"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="企业类型授权" SortExpression="" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('OUTypeRight.aspx?ModuleGuid='+'<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','600','500')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="账号类型授权" SortExpression="" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('RoleRight.aspx?ModuleGuid='+'<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','600','500')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="账号授权" SortExpression="" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('UserRight.aspx?ModuleGuid='+'<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','<%#(DataBinder.Eval(Container, "DataItem.RowGuid"))%>','600','500')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="禁用" SortExpression="IsForbid">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsForbid")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="隐藏" SortExpression="IsHidden">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsHidden")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="修改">
                                        <HeaderStyle HorizontalAlign="Center" Width="40"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenDialogRefresh("Record_Edit.aspx?IsBelongtoApp=<%=Request["IsBelongtoApp"]%>&RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>","",550,400)'>
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
