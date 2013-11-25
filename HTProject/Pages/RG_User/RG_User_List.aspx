<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="HTProject.Pages.RG_User.RG_User_List" Title="��Ա����" CodeBehind="RG_User_List.aspx.cs" %>

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
            OpenWindow('Record_Add.aspx?DanWeiGuid=<%=Request["DanWeiGuid"]%>', 800, 600);
        }
        var FirstDigest;
        var Digest = "01234567890123456";

        function Validate() {
            Digest = "01234567890123456";
            var TheForm;
            TheForm = document.forms["ValidForm"];

            //alert("1.����ePassND��ȫ�ؼ�");
            try {
                document.all.ePass.GetLibVersion();
            }
            catch (err) {
                if (err.number == '&H1B6') {
                    alert("����ePassND��ȫ�ؼ�");
                }
                return false;
            }
            //alert("2.�򿪵�һ��ePassND");
            try {
                document.all.ePass.OpenDevice(1, "");
            }
            catch (err) {
                alert('�����USBKEY.');
                return false;
            }
            var results;
            results = "01234567890123456";
            results = document.all.ePass.GetStrProperty(7, 0, 0);

            try {
                document.all.ePass.CloseDevice();
                //window.location = "ePassVerify.aspx?SN_SERAL=" + results + "&PassWord=" + PassWord; //"&Digest=" + Digest
                document.getElementById('<%=PINCode.ClientID %>').value = results;
            }
            catch (err) {
                alert(err.message);
            }
        }
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
                            <table width="100%">
                                <tr>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        ��λ����
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <epoint:TextBox ID="DWName" runat="server"></epoint:TextBox>
                                    </td>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        ��ʾ����
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <epoint:TextBox ID="DispName" runat="server"></epoint:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        ��¼ID
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <epoint:TextBox ID="LoginID" runat="server"></epoint:TextBox>
                                    </td>
                                    <td class="TableSpecial1" width="15%" align="right">
                                        ������PIN
                                    </td>
                                    <td class="TableSpecial" width="35%" height="26">
                                        <epoint:TextBox ID="PINCode" runat="server"></epoint:TextBox>
                                        <epoint:Button ID="btnInitEPwd" CssClass="ButtonOkNoBg" MouseOverClass="ButtonOkNoBg"
                                            Text="��ȡPIN" runat="server" CausesValidation="false" OnClientClick="Validate();return false;">
                                        </epoint:Button>
                                        <object id="Object1" name="ePass" style="z-index: 101; left: 488px; position: absolute;
                                            top: 408px" height="1" width="1" classid="clsid:E1D396DC-D064-4846-8B50-A3301BDD6243"
                                            codebase="includes/install.cab#Version=1,00,0000">
                                        </object>
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
                                                ID="btnSearch" runat="server" Text="������" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="����" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                                        </td>
                                        <td id="tdadd" runat="server">
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="����û�" />
                                        </td>
                                        <td id="td1" runat="server" style="display: none">
                                            &nbsp;<epoint:Button Text="ͨ�����" ID="btnPass" MouseOverClass="ButtonAdd" runat="server"
                                                CssClass="ButtonAddNoBg" OnClick="btnPass_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="��ȷ��ͨ�����ѡ����¼��?" />
                                        </td>
                                        <td id="td2" runat="server" style="display: none">
                                            &nbsp;<epoint:DeleteButton Text="����ɾ��" ID="btnRemove" MouseOverClass="ButtonDel"
                                                runat="server" CssClass="ButtonDelNoBg" OnClick="btnRemove_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="��ȷ������ɾ��ѡ����¼��?" />
                                        </td>
                                        <td id="tddel" runat="server">
                                            &nbsp;<epoint:DeleteButton Text="ɾ��ѡ��" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnRemove_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="��ȷ��ɾ��ѡ����¼��?" />
                                        </td>
                                        <td id="tdrecover" runat="server">
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="Button1" OnClick="btnRecover" runat="server" Text="�ָ�ѡ��" />
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="statusSel" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                OnSelectedIndexChanged="statusSel_Changed">
                                                <asp:ListItem Selected="True" Text="δɾ��" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="��ɾ��" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="����" Value="all"></asp:ListItem>
                                            </asp:RadioButtonList>
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
                                    <asp:TemplateColumn HeaderText="���">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ʾ����" SortExpression="DispName">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DispName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��¼��" SortExpression="LoginID">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.LoginID") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ҵ����" SortExpression="DanWeiGuid">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <%# GetOUName(DataBinder.Eval(Container, "DataItem.DanWeiGuid"))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="������PIN" SortExpression="PINCode">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.PINCode")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%--<asp:TemplateColumn HeaderText="��Ա״̬" SortExpression="UserStatus">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("��Ա״̬", Convert.ToString(DataBinder.Eval(Container, "DataItem.UserStatus")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <%--<asp:TemplateColumn HeaderText="�Ƿ���Ч" SortExpression="IsValid">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("�Ƿ�", Convert.ToString(DataBinder.Eval(Container, "DataItem.IsValid")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>--%>
                                    <asp:TemplateColumn HeaderText="�޸�">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenWindow("Record_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>",800,600)'>
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
