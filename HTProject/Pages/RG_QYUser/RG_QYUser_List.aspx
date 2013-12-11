<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYUser.RG_QYUser_List" Title="���ݼ�¼�б�" CodeBehind="RG_QYUser_List.aspx.cs" %>

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
            OpenWindow('RG_QYUser_Add.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>&DWGuid=<%=Request.QueryString["DWGuid"]%>', 800, 700);
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
                            ��ǰ���ݱ�<asp:Label ID="lblTableName" runat="server"></asp:Label><input id="HidState"
                                type="hidden" value="0" name="HidState" runat="server">
                        </td>
                    </tr>
                    <tr class="tablespecial">
                        <td id="tdCl" valign="middle" align="center" colspan="2" runat="server" style="display: none">
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                            <%--<table width="100%">
                                <tr>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        ��λ����
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <epoint:TextBox ID="DWName" runat="server"></epoint:TextBox>
                                    </td>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        ���״̬
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <asp:DropDownList ID="ddlStatus" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>--%>
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
                                                ID="btnSearch" runat="server" Text="������" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="����" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                                        </td>
                                        <td style="display: none">
                                            <input type="hidden" id="hidSelectedFields" runat="server" />
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                                ID="btnExcel" OnClientClick="if (!SelectColumns()) {return false;}" runat="server"
                                                Text="����EXCEL" OnClick="btnExcel_ServerClick" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="������¼" />
                                        </td>
                                        <td style="display: none;">
                                            &nbsp;<epoint:DeleteButton Text="ɾ��ѡ��" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="��ȷ��ɾ��ѡ����¼��?" Visible="false" />
                                        </td>
                                        <td style="display: none;">
                                            <epoint:Button ID="btnRefresh" MouseOverClass="ButtonSearch" runat="server" Text="ˢ��"
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
                                            <asp:CheckBox ID="chkAdd" runat="server" Enabled='<%# new HTProject_Bizlogic.DB_RG_DW().CanOperate(DataBinder.Eval(Container, "DataItem.Status")) %>'>
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����" SortExpression="XM">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XM") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="�Ա�" SortExpression="Sex">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("�Ա�", Convert.ToString(DataBinder.Eval(Container, "DataItem.Sex"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���֤����" SortExpression="IDNum">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.IDNum") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ְ��" SortExpression="ZhiCheng">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("ְ��", Convert.ToString(DataBinder.Eval(Container, "DataItem.ZhiCheng"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="Ƹ�ú�ͬ��" SortExpression="HeTongNo">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HeTongNo") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="��ͬ��ֹʱ��" SortExpression="HeTongEndDate">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HeTongEndDate", "{0:yyyy-MM-dd}") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ע��ӡ�º�" >
                                        <ItemTemplate>
                                            <%# RG_DW.GetZCZ( DataBinder.Eval(Container, "DataItem.YinZhangNo") ,DataBinder.Eval(Container, "DataItem.YinZhangNo1") ,DataBinder.Eval(Container, "DataItem.YinZhangNo2"))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����רҵ">
                                        <ItemTemplate>
                                            <%# RG_DW.GetCSZY("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 4)%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ע��רҵ">
                                        <ItemTemplate>
                                            <%# RG_DW.GetItemTextByLen2("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 0)%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����" SortExpression="GongLing">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.GongLing") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="��ҵGuid" SortExpression="DWGuid">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DWGuid") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <%--<asp:TemplateColumn HeaderText="֤������" SortExpression="IDType">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("֤������", Convert.ToString(DataBinder.Eval(Container, "DataItem.IDType"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    --%>
                                    <%--<asp:TemplateColumn HeaderText="��ѧרҵ" SortExpression="ZhuanYe">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanYe") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����רҵCode" SortExpression="ZhuanYeCSCode">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="״̬" SortExpression="Status">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("���״̬", Convert.ToString(DataBinder.Eval(Container, "DataItem.Status"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="ɾ��״̬" SortExpression="DelStatus">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("ɾ��״̬", Convert.ToString(DataBinder.Eval(Container, "DataItem.DelStatus"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="�鿴">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new HTProject_Bizlogic.DB_RG_DW().GetViewButton(DataBinder.Eval(Container, "DataItem.RowGuid"), DataBinder.Eval(Container, "DataItem.Status"), "RG_QYUser_Detail.aspx", "../../../images/bigview.gif")%>
                                            <%--<a href='javascript:OpenWindow("RG_QYUser_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                <img src='../../../images/bigview.gif' border='0'></a>--%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="�޸�">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new HTProject_Bizlogic.DB_RG_DW().GetOperateButton(DataBinder.Eval(Container, "DataItem.RowGuid"), DataBinder.Eval(Container, "DataItem.Status"), "RG_QYUser_Edit.aspx", "../../../images/add1.gif", "list")%>
                                            <%--<a href='javascript:OpenWindow("RG_QYUser_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")' >
                                                <img src='../../../images/add1.gif' border='0'/></a>--%>
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
