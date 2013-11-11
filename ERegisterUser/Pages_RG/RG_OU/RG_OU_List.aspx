<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_OU.RG_OU_List" CodeBehind="RG_OU_List.aspx.cs" 
    Title="���ݼ�¼�б�" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"  TagPrefix="epoint" %>
    
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>			
	
		function OpenUrl()
		{		  
		          OpenWindow('RG_OU_Add.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>',800,700);
		}
		
		function SelectColumns()
		{
		   var url='<%=Request.ApplicationPath %>/EpointMis/Pages/CommonPages/SelectExportFields.aspx?TableID=<%=TableID%>';
		   var SelectedColumns= OpenDialog(url,800,400);
		   document.all("<%=hidSelectedFields.ClientID %>").value=SelectedColumns;
		   if(SelectedColumns!="")
		   {
		      return true;
		   }
		   else
		   {
		      return false;
		   }
		}


//-->
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0" class="table">
                <tbody>
                    <tr  style="display:none">
                        <td style="height: 30px" class="tablespecial" colspan="2">
                            ��ǰ���ݱ�<asp:Label ID="lblTableName" runat="server"></asp:Label><input id="HidState"
                                type="hidden" value="0" name="HidState" runat="server"> 
                        </td>
                    </tr>
                    <tr class="tablespecial">                        
                        <td id="tdCl" valign="middle" align="center" colspan="2" runat="server" style="display:none">
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>  
                                               
                        </td>
                    </tr>
                 <tr>
                        <td>
                            <div id="Div_Control">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;<epoint:Button MouseOverClass="ButtonOK" ForeColor="black" CssClass="ButtonOKNoBg"
                                                ID="btnSearch" runat="server" Text="������" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="����" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                                        </td>
                                      <td>
                                            <input type="hidden" id="hidSelectedFields" runat="server" />
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                                ID="btnExcel" OnClientClick="if (!SelectColumns()) {return false;}" runat="server"
                                                Text="����EXCEL" OnClick="btnExcel_ServerClick" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="������¼" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:DeleteButton Text="ɾ��ѡ��" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;" RaiseMsg="��ȷ��ɾ��ѡ����¼��?" /></td>
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
                        <td align="center" colspan="2"><asp:datagrid id="Datagrid1" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"  AccessKey=1 
 DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Width="100%" OnItemCreated="Datagrid1_ItemCreated" OnSortCommand="Datagrid1_SortCommand">
<PagerStyle Visible="False"></PagerStyle><AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
<ItemStyle CssClass="RowStyle"></ItemStyle>
<HeaderStyle HorizontalAlign="Center" Height="30px"  CssClass="HeaderStyle"></HeaderStyle>
<Columns><asp:TemplateColumn>
<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
<HeaderTemplate>
<INPUT id="chkAddAll" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd">
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkAdd" Runat="server" ></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="���">
<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
<ItemTemplate>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��ҵӢ������" SortExpression="EnterpriseEName">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.EnterpriseEName") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ע���̱�" SortExpression="ShangBiao">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ShangBiao") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Logo" SortExpression="Logo">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.Logo") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��ҵ��������" SortExpression="EnterpriseName">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.EnterpriseName") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��������" SortExpression="ChengLiDate">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ChengLiDate", "{0:yyyy-M-d}") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ע���" SortExpression="ZhuCeDi">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ZhuCeDi") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ע����ϸ��ַ" SortExpression="ZhuCeDi_XX">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ZhuCeDi_XX") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��1Code" SortExpression="YunYingDi1Code">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi1Code") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��1" SortExpression="YunYingDi1">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi1") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��3" SortExpression="YunYingDi3">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi3") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��3Code" SortExpression="YunYingDi3Code">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi3Code") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��ϸ��ַ3" SortExpression="YunYingDi3_XX">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi3_XX") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��������">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ZhaoShangZT") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��ϵ��" SortExpression="LianXiRen">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.LianXiRen") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��ϵ�˵绰" SortExpression="LianXiRenTel">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.LianXiRenTel") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��ϵ���ֻ�" SortExpression="LianXiRenMobile">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.LianXiRenMobile") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��ϵ��Email" SortExpression="LianXiRenEmail">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.LianXiRenEmail") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��ϵ��ְ��" SortExpression="LianXiRenZW">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.LianXiRenZW") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��˾���">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.GongSiJJ") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="����˵��">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.WenZiSM") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="���¼�����ҵ" SortExpression="Is_GX">
<ItemTemplate>
<%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("�Ƿ�", Convert.ToString(DataBinder.Eval(Container, "DataItem.Is_GX"))) %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��׼����Ŷ" SortExpression="PiZhunDate">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.PiZhunDate", "{0:yyyy-M-d}") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="֤��" SortExpression="ZhengShu">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ZhengShu") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="����ϯ��" SortExpression="DongShiXS">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.DongShiXS") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��������" SortExpression="DongShiXM">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.DongShiXM") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="����ϯ��" SortExpression="JianShiXS">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.JianShiXS") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��������" SortExpression="JianShiXM">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.JianShiXM") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="�߹�����">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.GaoGuanMD") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ע���Code" SortExpression="ZhuCeDiCode">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ZhuCeDiCode") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��ϸ��ַ1" SortExpression="YunYingDi1_XX">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi1_XX") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��2" SortExpression="YunYingDi2">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi2") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��2Code" SortExpression="YunYingDi2Code">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi2Code") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��Ӫ��ϸ��ַ2" SortExpression="YunYingDi2_XX">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.YunYingDi2_XX") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��ҵ����" SortExpression="QiYeType">
<ItemTemplate>
<%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("Z03_�й�����������", Convert.ToString(DataBinder.Eval(Container, "DataItem.QiYeType"))) %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="��˾����PPT" SortExpression="GongSiJS">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.GongSiJS") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="˰�����ܷ�ʽ" SortExpression="ShuiShouFS">
<ItemTemplate>
<%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("Z04_�Ļ��̶�", Convert.ToString(DataBinder.Eval(Container, "DataItem.ShuiShouFS"))) %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="�鿴">
<ItemStyle HorizontalAlign="Center" width=40></ItemStyle>
<ItemTemplate>
<a href='javascript:parent.OpenDiagWin2("�鿴��ϸ","RG_OU_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
<img src='../../../images/bigview.gif' border='0'></a>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="�޸�">
<ItemStyle HorizontalAlign="Center" width=40></ItemStyle>
<ItemTemplate>
<a href='javascript:parent.OpenDiagWin2("�޸ļ�¼","RG_OU_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
<img src='../../../images/add1.gif' border='0'></a>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
<PagerStyle Visible="False" ></PagerStyle>
</asp:datagrid>
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