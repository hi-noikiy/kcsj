<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_XMBeiAn.RG_XMBeiAn_Detail" Title="�鿴������ϸ" CodeBehind="RG_XMBeiAn_Detail.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
<%@ Register TagPrefix="uc2" TagName="FJ_BA" Src="../../Ascx/FuJian_BA.ascx" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function Print() {
            OpenWindow('../Print/BeiAnPrint.aspx?RowGuid=<%= Request["RowGuid"]%>', '800', '700');
            return false;
        }
        
    </script>

    <div id="Div_ControlNoTop">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="45%">
                    <epoint:Button ID="btnXZ" runat="server" Text="���ر�����" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                        OnClick="btnXZ_Click"></epoint:Button>
                </td>
                <td width="50%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="TableSpecial1" style="text-align: right">
                    ������
                </td>
                <td style="vertical-align: top" class="TableSpecial">
                    <asp:Label ID="lblSHOpinion" runat="server"></asp:Label>
                </td>
                <td style="vertical-align: top" class="TableSpecial">
                    <asp:Label ID="lblTips" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="����"></font>
                <%=ViewState ["TableName"]%><asp:Label ID="XMBH_2021" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1" align="center">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��Ŀ����
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="XMName_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��Ŀ���
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="XMLB_2021" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��Ŀ��ַ
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="XMAddress_2021" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��Ŀ���ڵ�
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="XMAdd_2021" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��Ͷ��
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ToTalMoney_2021" runat="server"></asp:Label>��Ԫ
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��ģ
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="GuiMoDJ_2021" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ����ָ��
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="ZhiBiao_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%" rowspan="2">
                            ���赥λ
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" rowspan="2">
                            <asp:Label ID="JSDWName_2021" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��Ŀ��ϵ��
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="XMLXR_JS_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ϵ�˵绰
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LXDH_JS_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%" rowspan="3">
                            ��Ŀ������ҵ/ר��<br />
                            /������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" rowspan="3">
                            <asp:Label ID="ZiZhiDJ_2021" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="ZiZhiBH_2021" runat="server"></asp:Label>
                            <asp:Label ID="ZiZhiDJCode_2021" runat="server" MaxLength="50" Style="display: none"></asp:Label>
                            <asp:Label ID="ZiZhiDJRowGuid_2021" runat="server" MaxLength="500" Style="display: none"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��Ŀ��ϵ��
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="XMLXR_KS_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ϵ�绰
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LXDH_KS_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            �ֻ�����
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="SJ_KS_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ͬ�۸�
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="HeTongMoney_2021" runat="server"></asp:Label>��Ԫ
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��Ŀ������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="XMFZR_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trFW">
                        <td class="TableSpecial1" width="15%">
                            ��λ����֤����롢�ȼ����н�ҵ��Χ
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="YeWuFW_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trFZ">
                        <td class="TableSpecial1" width="15%">
                            �����ڽ��ճн���Ŀ���ơ��ص㡢��ҵ��𡢹�ģ�����ӳ̶�
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="FuZaCD_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ע
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="BeiZhu_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%">
                            ���״̬
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Status_2021" runat="server">
                            </asp:Label>
                            <asp:Label ID="DWGuid_2021" runat="server" MaxLength="50"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ɾ��״̬
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DelStatus_2021" runat="server">
                            </asp:Label>
                            <asp:Label ID="lblZiZhiType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="TableSpecial1">
                            ��Ŀ��Ա��Ϣ
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:DataGrid ID="DGZhuanYe" runat="server" CssClass="GridView" PageSize="200" BorderWidth="1px"
                                AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                AllowSorting="True" Width="100%">
                                <PagerStyle Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="רҵ" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanYeText")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��Ա������Ϣ">
                                        <ItemTemplate>
                                            <asp:DataGrid ID="DGRenYuan" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                                AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                                AllowSorting="True" Width="100%" DataSource='<%# GetRY(DataBinder.Eval(Container, "DataItem.ZhuanYeCode"))%>'>
                                                <PagerStyle Visible="False"></PagerStyle>
                                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="����">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.RYName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="֤����">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.IDNum")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ְ��">
                                                        <ItemTemplate>
                                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("ְ��", Convert.ToString(DataBinder.Eval(Container, "DataItem.ZhiCheng"))) %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ִҵӡ�º�">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.YinZhangNo")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="��ѧרҵ">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanYeSX")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <%--<asp:TemplateColumn HeaderText="����רҵ">
                                                        <ItemTemplate>
                                                            <%# RG_DW.GetItemTextByLen2("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 4)%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>--%>
                                                    <asp:TemplateColumn HeaderText="����רҵ">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanYeCS")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="ע��רҵ">
                                                        <ItemTemplate>
                                                            <%# RG_DW.GetItemTextByLen2("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 0)%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="����">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.GongLing")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="������ɫ">
                                                        <ItemTemplate>
                                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("��Ŀ��ɫ", Convert.ToString(DataBinder.Eval(Container, "DataItem.DDRole"))) %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle Visible="False"></PagerStyle>
                                            </asp:DataGrid>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" colspan="4">
                            <%--<uc1:FJ ID="HTBA" runat="server" ClientTag="������ƺ�ͬ������" ReadOnly="true"></uc1:FJ>--%>
                            <uc2:FJ_BA ID="XM_HTBA" runat="server" ClientTag="������ƺ�ͬ������" ReadOnly="true"></uc2:FJ_BA>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" colspan="4">
                            <uc1:FJ ID="SJHT" runat="server" ClientTag="������ƺ�ͬ" ReadOnly="true"></uc1:FJ>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" colspan="4">
                            <uc1:FJ ID="QY_CXZM" runat="server" ClientTag="��ҵ����֤��" ReadOnly="true"></uc1:FJ>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td colspan="4">
                            <asp:Label ID="hiZYText" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="hiZYCode" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="hiRYGuids" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="TJDate_2021" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" height="40">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">û�����ݣ�</asp:Label>
            </td>
        </tr>
    </table>

    <script type="text/javascript">

        window.moveTo(-4, -4);
        window.resizeTo(screen.availWidth + 8, screen.availHeight + 8);
    </script>

</asp:Content>
