<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageNoLocation.Master" AutoEventWireup="true"
    Codebehind="ConsultBoxMana.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxMana.ConsultBoxMana"
    Title="信箱管理" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="cc2" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function BoxAdd(url)
		{	
			 OpenDialogRefresh(url,"","500","406");	
		}
		function BoxManageSet(url)
		{	
			OpenDialog(url,"670","593");
		}
    </script>

    <div id="Div_ControlNoTop">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <input class="ButtonAddNoBg" onclick="BoxAdd('ConsultBoxAdd.aspx');" onmouseout="this.className='ButtonAddNoBg'"
                        onmouseover="this.className='ButtonAdd'" type="button" value="添加信箱" /></td>
                <td>
                    <cc2:DeleteButton ID="btnDel" MouseOverClass="ButtonDel" runat="server" Text="删除选定"
                        CssClass="ButtonDelNoBg" OnClientClick="if(!Check_SelectedStatus('chksel')) return false;" RaiseMsg="您确定删除选定记录吗?" OnClick="btnDel_Click" CausesValidation="False" /></td>
                <td>
                    <cc1:Button ID="btnUpdate" MouseOverClass="ButtonSave" runat="server" Text="保存修改"
                        CssClass="ButtonSaveNoBg" OnClick="btnUpdate_Click" AfterClickJSFunction="alert('修改成功！')"
                        CausesValidation="False"></cc1:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:DataGrid ID="DgrBox" runat="server" AutoGenerateColumns="False" DataKeyField="BoxGuid"
                Width="100%" OnItemCreated="BoxGuid_ItemCreated">
                <Columns>
                    <asp:TemplateColumn HeaderText="序号">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="&lt;input type=checkbox name=&quot;chksel&quot; id=&quot;chksel&quot; onclick=&quot;javascript:AllSelect(this)&quot;&gt;">
                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chksel" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="信箱名称">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="left" />
                        <ItemTemplate><%# DataBinder.Eval(Container, "DataItem.BoxName") %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="所属组别">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                        <ItemTemplate>
                            <%# GetGroupName(DataBinder.Eval(Container, "DataItem.BoxGuid"))%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="排序">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <cc1:NumericTextBox ID="txtordernum" runat="server" CssClass="inputtxt" Text='<%# DataBinder.Eval(Container, "DataItem.ordernum") %>'
                                Width="48">
                            </cc1:NumericTextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="处理期限">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <cc1:NumericTextBox ID="txtHandleDays" runat="server" CssClass="inputtxt" NumericProperty-MinValue="1" Text='<%# DataBinder.Eval(Container, "DataItem.HandleDays") %>'
                                Width="48">
                            </cc1:NumericTextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="权限设置">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                        <ItemTemplate>
                            <a href='javascript:BoxManageSet("ConsultBoxManageSet.aspx?BoxGuid=<%# DataBinder.Eval(Container, "DataItem.BoxGuid") %>");'>
                                权限设置</a>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                     <asp:TemplateColumn HeaderText="编辑">
                                    <HeaderStyle HorizontalAlign="Center" Width="40" />
                                    <ItemStyle CssClass="ItemStyle" HorizontalAlign="center" VerticalAlign="Middle" Width="40" />
                                    <ItemTemplate>
                                      <a href='javascript:BoxAdd("ConsultBoxAdd.aspx?BoxGuid=<%# DataBinder.Eval(Container, "DataItem.BoxGuid") %>");'>
                                            <img src="../../../images/edit.gif" border="0"></a>
                                    </ItemTemplate>
                     </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid></ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
