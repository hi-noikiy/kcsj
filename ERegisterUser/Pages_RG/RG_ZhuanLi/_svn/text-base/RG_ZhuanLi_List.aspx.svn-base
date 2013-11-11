<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_ZhuanLi.RG_ZhuanLi_List" CodeBehind="RG_ZhuanLi_List.aspx.cs" 
    Title="数据记录列表" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"  TagPrefix="epoint" %>
    
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>			
	
		function OpenUrl()
		{		  
		          OpenWindow('RG_ZhuanLi_Add.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>',800,700);
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
                            当前数据表：<asp:Label ID="lblTableName" runat="server"></asp:Label><input id="HidState"
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
                                                ID="btnSearch" runat="server" Text="打开搜索" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="查找" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                                        </td>
                                      <td>
                                            <input type="hidden" id="hidSelectedFields" runat="server" />
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                                ID="btnExcel" OnClientClick="if (!SelectColumns()) {return false;}" runat="server"
                                                Text="导出EXCEL" OnClick="btnExcel_ServerClick" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                                ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="新增记录" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:DeleteButton Text="删除选定" ID="btnDel" MouseOverClass="ButtonDel" runat="server"
                                                CssClass="ButtonDelNoBg" OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;" RaiseMsg="您确定删除选定记录吗?" /></td>
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
<asp:TemplateColumn HeaderText="序号">
<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
<ItemTemplate>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="专利号" SortExpression="ZhuanLiNo">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ZhuanLiNo") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="专利名称" SortExpression="ZhuanLiName">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ZhuanLiName") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="专利类型" SortExpression="ZhuanLiType">
<ItemTemplate>
<%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("性别", Convert.ToString(DataBinder.Eval(Container, "DataItem.ZhuanLiType"))) %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="专利状态" SortExpression="ZhuanLiStatus">
<ItemTemplate>
<%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("性别", Convert.ToString(DataBinder.Eval(Container, "DataItem.ZhuanLiStatus"))) %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="持有人" SortExpression="ChiYouRen">
<ItemTemplate>
<%# DataBinder.Eval(Container, "DataItem.ChiYouRen") %>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="查看">
<ItemStyle HorizontalAlign="Center" width=40></ItemStyle>
<ItemTemplate>
<a href='javascript:parent.OpenDiagWin2("查看明细","RG_ZhuanLi_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
<img src='../../../images/bigview.gif' border='0'></a>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="修改">
<ItemStyle HorizontalAlign="Center" width=40></ItemStyle>
<ItemTemplate>
<a href='javascript:parent.OpenDiagWin2("修改记录","RG_ZhuanLi_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
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