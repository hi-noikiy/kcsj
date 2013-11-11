<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_OuTypeRight.OuType_List" Title="会员单位列表"
    CodeBehind="OuType_List.aspx.cs" %>

<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>

        function OpenUrl() {
            OpenWindow('BusinessData_Add.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>', 800, 700);
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
                        <td style="height: 31px" colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" width="50%">
                                        <asp:Label ID="LblRecordCount1" runat="server"></asp:Label>
                                        <asp:Label ID="LblRecordEveryPage1" runat="server"></asp:Label>
                                        <asp:Label ID="LblPageCount1" runat="server"></asp:Label>
                                        <asp:Label ID="LblCurrentIndex1" runat="server"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="right" colspan="2" style="height: 31px">
                                        <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                            InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                            DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../Images/page/"
                                            PagingButtonType="Image" NavigationButtonType="Image" PageSize="15" OnPageChanged="Pager_PageChanged">
                                        </webdiyer:AspNetPager>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:DataGrid ID="Datagrid1" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                AccessKey="1" DataKeyField="ItemValue" AutoGenerateColumns="False" AllowPaging="True"
                                AllowSorting="True" Width="100%" OnItemCreated="Datagrid1_ItemCreated" OnSortCommand="Datagrid1_SortCommand">
                                <PagerStyle Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="序号" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# (this.Pager.CurrentPageIndex - 1) * this.Pager.PageSize + this.Datagrid1.Items.Count + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="会员单位" SortExpression="ItemText">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ItemText") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="模块权限" SortExpression="">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('OuTypeModule_Setting.aspx?OuTypeValue='+'<%#(DataBinder.Eval(Container, "DataItem.ItemValue"))%>','<%#(DataBinder.Eval(Container, "DataItem.ItemValue"))%>','800','800')">
                                                设置</a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="快捷菜单权限" SortExpression="">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <a href="#" onclick="OpenDialogArgs('OuTypeShortcut_Setting.aspx?OuTypeValue='+'<%#(DataBinder.Eval(Container, "DataItem.ItemValue"))%>','<%#(DataBinder.Eval(Container, "DataItem.ItemValue"))%>','600','500')">
                                                设置</a>
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
