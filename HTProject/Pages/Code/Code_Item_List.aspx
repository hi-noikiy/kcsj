
<%@ Page Language="C#" AutoEventWireup="True" Codebehind="Code_Item_List.aspx.cs" Inherits="HTProject.Pages.Code.Code_Item_List"
    MasterPageFile="~/WebMaster/MainpageNoLocation.Master" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/ecmascript" language="javascript">
			function ShowAddNew()
			{	
			    
				OpenDialogRefresh('Code_Item_AddInfo.aspx?ItemCode=<%=Request["ItemCode"]%>&MainGuid=<%=Request["MainGuid"]%>',"<%=Request.QueryString["ItemCode"]%>","600","500");
			}
			
				
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            代码类别名称：<asp:Label ID="lblCodeName" runat="server" Text=""></asp:Label></td>
                        <td>
                            &nbsp; &nbsp; &nbsp; &nbsp;<input id="btnAddIpt" class="ButtonAddNoBg" onclick="javascript:ShowAddNew();"
                                type="button" value="新增代码" onmouseout="this.className='ButtonAddNoBg'" onmouseover="this.className='ButtonAdd'" /></td>
                        <td>
                            <Epoint:Button ID="btnSave" MouseOverClass="ButtonSave" runat="server" CssClass="ButtonSaveNoBg"
                                Text="保存修改" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
            
            
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:DataGrid ID="grdList" runat="server" CellSpacing="1" AutoGenerateColumns="False"
                DataKeyField="ItemGuid" Width="99%" OnItemCommand="grdList_ItemCommand">
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
                    <asp:TemplateColumn HeaderText="代码显示名称">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                        <ItemTemplate>
                            <Epoint:TextBox ID="tItemText" CssClass="inputtxt" AllowNull="false" Text='<%# DataBinder.Eval(Container, "DataItem.ItemText") %>'
                                TextAlign="left" runat="server" Width="80%" MaxLength="50"></Epoint:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="代码值">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                        <ItemTemplate>
                            <Epoint:TextBox ID="tItemValue" CssClass="inputtxt" AllowNull="false" Text='<%# DataBinder.Eval(Container, "DataItem.ItemValue") %>'
                                TextAlign="left" runat="server" Width="80%" MaxLength="50"></Epoint:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="对应编码" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container, "DataItem.ItemCode") %>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="拼音简称">
                        <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                        <ItemTemplate>
                            <Epoint:TextBox ID="tPinYinJc" CssClass="inputtxt" Text='<%# DataBinder.Eval(Container, "DataItem.PinYinJc") %>'
                                TextAlign="left" runat="server" Width="70px" MaxLength="50"></Epoint:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="排序">
                        <HeaderStyle HorizontalAlign="Center" Width="55px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="55px"></ItemStyle>
                        <ItemTemplate>
                            <Epoint:NumericTextBox ID="tOrderNumber" CssClass="inputtxt" TextAlign="left" Text='<%# DataBinder.Eval(Container, "DataItem.OrderNumber") %>'
                                runat="server" Width="40px">
                <NumericProperty ShowCharacter="false" MaxValue="10000" />
                            </Epoint:NumericTextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="删除">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        <ItemTemplate>
                            <Epoint:Button OnClientClick="return confirm('您确认删除选定代码项吗？');" ID="btnDel" runat="server" CssClass="BtnDel" Text="" CommandName="Del"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ItemCode") %>'></Epoint:Button>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
