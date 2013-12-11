<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYUser.SelQYUser_M" Title="���ݼ�¼�б�" CodeBehind="SelQYUser_M.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function SelMe(obj) {
            var NAndG = obj.value.split("*");
            var Name = document.getElementById('<%=SelUserNames.ClientID %>').value;
            var Guid = document.getElementById('<%=SelUserGuids.ClientID %>').value;
            if (obj.checked) {
                Name += NAndG[1];
                Name += ";";
                Guid += NAndG[0];
                Guid += ";";
            }
            else {
                var g = NAndG[0] + ";";
                var n = NAndG[1] + ";";
                Name = Name.replace(n, "");
                Guid = Guid.replace(g, "");
            }
            document.getElementById('<%=SelUserNames.ClientID %>').value = Name;
            document.getElementById('<%=SelUserGuids.ClientID %>').value = Guid;
        }
        function RT() {
            var Guids = document.getElementById('<%=SelUserGuids.ClientID %>').value;
            window.returnValue = Guids;
            //alert(Guids);
            window.close();
        }
        function MyPageValidate(message) {
            var bRet = false;
            if (Page_ClientValidate()) {
                return window.confirm(message);
            }
            else {
                bRet = false;
            }
            return bRet;
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="Div_Control">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            &nbsp;<epoint:Button MouseOverClass="ButtonOK" ForeColor="black" CssClass="ButtonOKNoBg"
                                                ID="btnSave" runat="server" Text="ȷ��ѡ��" OnClick="btnSave_Click" OnClientClick="return MyPageValidate('ȷ��ѡ��');" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button MouseOverClass="ButtonOK" ForeColor="black" CssClass="ButtonOKNoBg"
                                                ID="btnSearch" runat="server" Text="������" OnClick="btnSearch_Click" CausesValidation="false" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="����" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click" CausesValidation="false">
                                            </epoint:Button>
                                        </td>
                                        <td style="width:100%">
                                        <span style="color:Red">���޷�ѡ����Ա�������������ݣ�1����ҵ��Ϣ�Ƿ����ͨ����2�������Ͷ���ͬ�Ƿ��ڣ�3���籣֤���Ƿ��ڣ�4���������֤�Ƿ��ڣ�5�����˵���Ϣ�Ƿ����ͨ����6��ע������Ч���Ƿ����</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            ��ѡ����Ա
                                        </td>
                                        <td colspan="3">
                                            <epoint:TextBox ID="SelUserNames" runat="server" MaxLength="500" AllowNull="false"
                                                contenteditable="false" Width="90%"></epoint:TextBox>
                                            <epoint:TextBox ID="SelUserGuids" runat="server" MaxLength="500" Width="90%" style="display:none"></epoint:TextBox><%----%>
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
                                    <asp:TemplateColumn HeaderText="ѡ��">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                            <input type="checkbox" runat="server" id="cbSel" value='<%# DataBinder.Eval(Container, "DataItem.RowGuid") +"*" +DataBinder.Eval(Container, "DataItem.XM")%> '
                                                onclick="SelMe(this)" />
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
                                    <asp:TemplateColumn HeaderText="ְ��" SortExpression="ZhiCheng">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("ְ��", Convert.ToString(DataBinder.Eval(Container, "DataItem.ZhiCheng"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ͬ��ֹʱ��" SortExpression="HeTongEndDate">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HeTongEndDate", "{0:yyyy-MM-dd}") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ע��ӡ�º�" >
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.YinZhangNo") + ";" + DataBinder.Eval(Container, "DataItem.YinZhangNo1") + ";" + DataBinder.Eval(Container, "DataItem.YinZhangNo2")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="����רҵ" SortExpression="ZhuanYeCS">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanYeCS") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="����רҵ">
                                        <ItemTemplate>
                                            <%# RG_DW.GetItemTextSByLen("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 4)%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ע��רҵ">
                                        <ItemTemplate>
                                            <%# RG_DW.GetItemTextByLen("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 8)%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����" SortExpression="GongLing">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.GongLing") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="�鿴">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenWindow("RG_QYUser_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                <img src='../../../images/bigview.gif' border='0'></a>
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
