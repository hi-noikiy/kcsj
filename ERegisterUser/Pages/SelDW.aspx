<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.SelDW" Title="��λѡ���б�" CodeBehind="SelDW.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function SelDW(rowguid, name) {
            var ss = rowguid + "/" + name;
            window.returnValue = ss;
            window.close();
        }
        //-->
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0" class="table">
                <tbody>
                    <tr class="tablespecial">
                        <td id="tdCl" valign="middle" align="center" colspan="2" runat="server" style="display: none">
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                            <table width="100%">
                                <tr>
                                    <td class="TableSpecial1" width="15%">
                                        ��λ����
                                    </td>
                                    <td class="TableSpecial" width="35%" style="height: 30px;" align="left">
                                        <epoint:TextBox ID="TxtMC" runat="server" MaxLength="50" Width="100%" Height="28px"></epoint:TextBox>
                                    </td>
                                    
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td class="TableSpecial1" align="left" width="15%">
                            ���״̬��
                        </td>
                        <td class="TableSpecial1" align="center" width="85%">
                            <asp:RadioButtonList ID="RadioAuditStatus" runat="server" RepeatDirection="Horizontal"
                                Width="500px" AutoPostBack="true" OnSelectedIndexChanged="RadioAuditStatus_SelectedIndexChanged">
                                <asp:ListItem Text="����" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="�༭��" Value="2"></asp:ListItem>
                                <asp:ListItem Text="�����" Value="3"></asp:ListItem>
                                <asp:ListItem Text="ͨ��" Value="4"></asp:ListItem>
                                <asp:ListItem Text="��ͨ��" Value="5"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td class="TableSpecial1" align="left" width="15%">
                            ��λ���ͣ�
                        </td>
                        <td class="TableSpecial1" align="center" width="85%">
                            <asp:RadioButtonList ID="RadioDWType" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="true" OnSelectedIndexChanged="RadioDWType_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
                                DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../images/page/"
                                PagingButtonType="Image" NavigationButtonType="Image" PageSize="15" OnPageChanged="Pager_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:DataGrid ID="Datagrid1" runat="server" CssClass="GridView" PageSize="15" BorderWidth="1px"
                                AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                AllowSorting="True" Width="100%" OnItemCreated="Datagrid1_ItemCreated" OnSortCommand="Datagrid1_SortCommand">
                                <PagerStyle Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="ѡ��">
                                        <HeaderStyle HorizontalAlign="Center" Width="9%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="9%"></ItemStyle>
                                        <ItemTemplate>
                                            <input type="button" class="Btnbg" value="ѡ��" onclick="SelDW('<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>','<%# DataBinder.Eval(Container, "DataItem.EnterPriseName")%>')" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���">
                                        <HeaderStyle HorizontalAlign="Center" Width="6%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ҵ��������" SortExpression="EnterpriseName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.EnterpriseName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ҵӢ������" SortExpression="EnterpriseEName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.EnterpriseEName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��������" SortExpression="ChengLiDate">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ChengLiDate", "{0:yyyy-M-d}") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���¼�����ҵ" SortExpression="Is_GX">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("�Ƿ�", Convert.ToString(DataBinder.Eval(Container, "DataItem.Is_GX"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ҵ����" SortExpression="QiYeType">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("��ҵ_��ҵ����", Convert.ToString(DataBinder.Eval(Container, "DataItem.QiYeType")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="˰�����ܷ�ʽ" SortExpression="ShuiShouFS">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("��ҵ_˰�����ܷ�ʽ", Convert.ToString(DataBinder.Eval(Container, "DataItem.ShuiShouFS")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;
</asp:Content>
