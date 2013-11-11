<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ZZZYGX_List.aspx.cs" Inherits="HTProject.Pages.RG_XMBeiAn.ZZZYGX_List"
    MasterPageFile="~/WebMaster/MainpageNoLocation.Master" Title="" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/ecmascript" language="javascript">
        function ShowAddNew() {

            OpenDialogRefresh('AddZYForZZInfo.aspx?ZZCode=<%=Request["ItemCode"]%>&MainGuid=<%=Request["MainGuid"]%>', '<%=Request["ItemCode"]%>', "600", "500");
        }
			
				
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            代码类别名称：<asp:Label ID="lblCodeName" runat="server" Text=""></asp:Label>&nbsp; &nbsp;
                            &nbsp; &nbsp;
                        </td>
                        <td>
                            <input id="btnAddIpt" class="ButtonAddNoBg" onclick="javascript:ShowAddNew();" type="button"
                                value="新增专业" onmouseout="this.className='ButtonAddNoBg'" onmouseover="this.className='ButtonAdd'" />
                        </td>
                        <td>
                            <epoint:Button ID="btnSave" MouseOverClass="ButtonSave" runat="server" CssClass="ButtonSaveNoBg"
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
                DataKeyField="RowGuid" Width="99%" OnItemCommand="grdList_ItemCommand">
                <Columns>
                    <%--<asp:TemplateColumn>
                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        <HeaderTemplate>
                            <input id="chkAddAll" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAdd" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>--%>
                    <asp:TemplateColumn HeaderText="资质名称">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiText")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="资质Code">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiCode")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <%--<asp:TemplateColumn HeaderText="专业名称">
                        <HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container, "DataItem.ZhuanYeText")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>--%>
                    <asp:TemplateColumn HeaderText="从事专业">
                        <ItemTemplate>
                            <%# RG_DW.GetItemTextByLen("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCode"), 4)%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="注册专业">
                        <ItemTemplate>
                            <%# RG_DW.GetItemTextByLen("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCode"), 8)%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="专业Code">
                        <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container, "DataItem.ZhuanYeCode")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="其他条件" Visible="false">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                        <ItemTemplate>
                            <epoint:TextBox ID="tItemText" CssClass="inputtxt" Text='<%# DataBinder.Eval(Container, "DataItem.OWhere") %>'
                                TextAlign="left" runat="server" Width="80%" MaxLength="50"></epoint:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        <HeaderTemplate>
                            <input id="chkAddAllNP" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAddNP">需配人员
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAddNP" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.NeedRY").ToString()=="1" %>'>
                            </asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="排序">
                        <HeaderStyle HorizontalAlign="Center" Width="55px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="55px"></ItemStyle>
                        <ItemTemplate>
                            <epoint:NumericTextBox ID="tOrderNumber" CssClass="inputtxt" TextAlign="left" Text='<%# DataBinder.Eval(Container, "DataItem.OrderNo") %>'
                                runat="server" Width="40px">
                <NumericProperty ShowCharacter="false" MaxValue="10000" />
                            </epoint:NumericTextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="删除">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        <ItemTemplate>
                            <epoint:Button OnClientClick="return confirm('您确认删除选定代码项吗？');" ID="btnDel" runat="server"
                                CssClass="BtnDel" Text="" CommandName="Del" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RowGuid") %>'>
                            </epoint:Button>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        var cod = '<%=Request["ItemCode"]%>';

        if (cod.length == 4 || cod.length == 0 || cod.length == 8) {
            if (cod == '00020001' || cod == '00020002' || cod == '00020003') {
                document.all('btnAddIpt').style.display = "block";
            }
            else {
                document.all('btnAddIpt').style.display = "none";
            }
        }        
        else {
            document.all('btnAddIpt').style.display = "block";
        }
    </script>

</asp:Content>
