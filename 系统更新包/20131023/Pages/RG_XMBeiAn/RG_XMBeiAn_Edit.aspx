<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_XMBeiAn.RG_XMBeiAn_Edit" Title="�޸����ݼ�¼" CodeBehind="RG_XMBeiAn_Edit.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
<%@ Register TagPrefix="uc2" TagName="FJ_BA" Src="../../Ascx/FuJian_BA.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
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
        window.moveTo(-4, -4);
        window.resizeTo(screen.availWidth + 8, screen.availHeight + 8);
    </script>

    <epoint:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <epoint:Button ID="btnEdit" runat="server" Text="�޸ı���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnEdit_Click" OnClientClick="return MyPageValidate('ȷ�����棿');"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnXZ" runat="server" Text="���ر�����" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnXZ_Click" OnClientClick="return MyPageValidate('ȷ����Ŀ����Ա��Ϣ��ȫ��');">
                            </epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnSub" runat="server" Text="�ύ���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnSub_Click" OnClientClick="return MyPageValidate('ȷ���ύ�����������ύ���������ĵȴ���\r\n������Ա������̵�ʱ����Ϊ������\r\n�������ᷢ����֪ͨ����Ŀ��ϵ���ֻ��ϡ�');">
                            </epoint:Button>
                        </td>
                        <td style="width: 50%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" style="text-align: right">
                            ������
                        </td>
                        <td colspan="2" style="vertical-align: top" class="TableSpecial">
                            <asp:Label ID="lblSHOpinion" runat="server"></asp:Label>
                        </td>
                        <td style="vertical-align: top" class="TableSpecial">
                            <asp:Label ID="lblTips" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                        align="center" valign="middle">
                        <%=ViewState ["TableName"]%>
                    </td>
                </tr>
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center" id="tabContent">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ŀ����<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="XMName_2021" runat="server" MaxLength="500" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ŀ���<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <asp:RadioButtonList ID="XMLB_2021" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ŀ��ַ<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XMAddress_2021" runat="server" MaxLength="500" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��Ŀ���ڵ���<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="XMAdd_2021" runat="server" Width="80%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ͷ��<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ToTalMoney_2021" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" AllowNull="false" Width="80%"><NumericProperty TextBoxType="Numeric" Precision="4" /></epoint:NumericTextBox>��Ԫ
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ģ<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="GuiMoDJ_2021" runat="server" Width="80%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����ָ��<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ZhiBiao_2021" runat="server" MaxLength="500" AllowNull="false"
                                        Width="80%" TextMode="MultiLine" Height="50px"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="2">
                                    ���赥λ<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left" rowspan="2">
                                    <epoint:TextBox ID="JSDWName_2021" runat="server" MaxLength="500" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��Ŀ��ϵ��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XMLXR_JS_2021" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ�˵绰
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LXDH_JS_2021" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="3">
                                    ��Ŀ������ҵ/ר��<br />
                                    /������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left" rowspan="3">
                                    <epoint:TextBox ID="ZiZhiDJ_2021" runat="server" MaxLength="500" Width="80%" contenteditable="false"></epoint:TextBox>
                                    <br />
                                    <epoint:TextBox ID="ZiZhiBH_2021" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%" contenteditable="false"></epoint:TextBox>
                                    <epoint:TextBox ID="ZiZhiDJCode_2021" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="ZiZhiDJRowGuid_2021" runat="server" MaxLength="500" Style="display: none"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��Ŀ��ϵ��<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XMLXR_KS_2021" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ�绰<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LXDH_KS_2021" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �ֻ�����<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="SJ_KS_2021" runat="server" MaxLength="50" AllowNull="false" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ͬ�۸�<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="HeTongMoney_2021" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" AllowNull="false" Width="80%"><NumericProperty TextBoxType="Numeric" Precision="4" /></epoint:NumericTextBox>��Ԫ
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��Ŀ������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XMFZR_2021" runat="server" MaxLength="50" AllowNull="false" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr id="trFW">
                                <td class="TableSpecial1" width="15%">
                                    ��λ����֤����롢�ȼ����н�ҵ��Χ<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="YeWuFW_2021" runat="server" AllowNull="false" TextMode="MultiLine"
                                        Height="100px" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr id="trFZ">
                                <td class="TableSpecial1" width="15%">
                                    �����ڽ��ճн���Ŀ���ơ��ص㡢��ҵ��𡢹�ģ�����ӳ̶�<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="FuZaCD_2021" runat="server" AllowNull="false" TextMode="MultiLine"
                                        Height="100px" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ע
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="BeiZhu_2021" runat="server" MaxLength="500" Width="80%" TextMode="MultiLine"
                                        Height="50px"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    ���״̬
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="Status_2021" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                    <epoint:TextBox ID="DWGuid_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="DWName_2021" runat="server" MaxLength="500"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ɾ��״̬
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="DelStatus_2021" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
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
                                        <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="רҵ����" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <%--<%# DataBinder.Eval(Container, "DataItem.ZhuanYeText")%>--%>
                                                    <%# RG_DW.GetItemTextByLen("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCode"), 4)%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="ע��רҵ">
                                                <ItemTemplate>
                                                    <%# RG_DW.GetItemTextByLen("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCode"), 8)%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="��Ա������Ϣ">
                                                <ItemTemplate>
                                                    <input id="btnAddRY" class="ButtonAddNoBg" onclick="javascript:ShowAddNew('<%# DataBinder.Eval(Container, "DataItem.ZhuanYeCode")%>','<%# DataBinder.Eval(Container, "DataItem.ZhuanYeText")%>');"
                                                        type="button" value="������Ա" onmouseout="this.className='ButtonAddNoBg'" onmouseover="this.className='ButtonAdd'" />
                                                    <asp:DataGrid ID="DGRenYuan" runat="server" PageSize="20" BorderWidth="1px" AccessKey="1"
                                                        DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True" OnItemCommand="DGRenYuan_ItemCommand"
                                                        AllowSorting="True" Width="100%" DataSource='<%# GetRY(DataBinder.Eval(Container, "DataItem.ZhuanYeCode"))%>'>
                                                        <PagerStyle Visible="False"></PagerStyle>
                                                        <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                                        <ItemStyle CssClass="RowStyle"></ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
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
                                                            <asp:TemplateColumn HeaderText="����רҵ">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.ZhuanYeCS")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="��ƹ���">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.GongLing")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="������ɫ">
                                                                <ItemTemplate>
                                                                    <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("��Ŀ��ɫ", Convert.ToString(DataBinder.Eval(Container, "DataItem.DDRole"))) %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="����" ItemStyle-Width="60px">
                                                                <ItemTemplate>
                                                                    <epoint:Button ID="btnUpd" runat="server" CssClass="BtnDel" Text="�޸�" Width="25px"
                                                                        CommandName="Upd" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RowGuid") %>'>
                                                                    </epoint:Button>
                                                                    |<epoint:Button OnClientClick="return confirm('��ȷ��ɾ��ѡ����������');" ID="btnDel" runat="server"
                                                                        Width="25px" CssClass="BtnDel" Text="ɾ��" CommandName="Del" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RowGuid") %>'>
                                                                    </epoint:Button>
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
                                    <uc2:FJ_BA ID="XM_HTBA" runat="server" ClientTag="������ƺ�ͬ������" MaxAttachCount="5">
                                    </uc2:FJ_BA>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" colspan="4">
                                    <uc1:FJ ID="XM_SJHT" runat="server" ClientTag="������ƺ�ͬ"></uc1:FJ>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" colspan="4">
                                    <uc1:FJ ID="QY_CXZM" runat="server" ClientTag="��ҵ����֤��"></uc1:FJ>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td colspan="4">
                                    <epoint:TextBox ID="hiZYText" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="hiZYCode" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="hiRYGuids" runat="server" MaxLength="50"></epoint:TextBox>
                                    <asp:Button ID="btInsertRY" runat="server" Text="Button" OnClick="btInsertRY_Click" />
                                    <epoint:DateTextBox ID="TJDate_2021" runat="server" InputDateType="Input" Character="HX"
                                        Width="120px"></epoint:DateTextBox>
                                    <input type="hidden" runat="server" id="hiQYZCD" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function ShowAddNew(ZYCode, ZYText) {

            var DWGuid = document.getElementById('<%=DWGuid_2021.ClientID %>').value;
            var ZiZhiCode = document.getElementById('<%=ZiZhiDJCode_2021.ClientID %>').value; //ZiZhiDJCode_2021
            //alert(ZiZhiCode);
            //var ddl = document.getElementById("<%=GuiMoDJ_2021.ClientID %>");

            //var index = ddl.selectedIndex; 
            //alert(index);
            //var GMValue = ddl.options[index].value;
            var rtnValue = window.showModalDialog('../RG_QYUser/SelQYUser_M.aspx?ZYCode=' + ZYCode + '&DWGuid=' + DWGuid + '&ItemText=' + encodeURI(ZYText), '<%=Request["RowGuid"]%>', "dialogwidth:800px; dialogHeight:500px ;status:no ;scrollbars:yes;");
            //alert(ZYCode);
            document.getElementById('<%=hiZYText.ClientID %>').value = ZYText;
            document.getElementById('<%=hiZYCode.ClientID %>').value = ZYCode;
            document.getElementById('<%=hiRYGuids.ClientID %>').value = rtnValue;
            document.getElementById('<%=btInsertRY.ClientID %>').click();
        }
    </script>

</asp:Content>
