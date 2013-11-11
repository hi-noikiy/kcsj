<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPage.master" AutoEventWireup="true"
    Codebehind="ConsultGroupFrame.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultGroup.ConsultGroupFrame"
    Title="组别管理" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="cc2" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
    <%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Div_ControlNoTop">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
                     <td>
                  &nbsp;组别名称：</td>
                <td width="170px">
                   <cc1:TextBox ID="txtName" runat="server" CssClass="inputtxt" MaxLength="50" Width="200" AllowNull="false"></cc1:TextBox>
                </td>
                <td>
                    <cc1:Button ID="btnAdd" runat="server" CssClass="ButtonAddNoBg" MouseOverClass="ButtonAdd"
                        Text="添加组别" OnClick="btnAdd_Click" /></td>
                <td>
                    <cc2:DeleteButton ID="btnDel" MouseOverClass="ButtonDel" runat="server" Text="删除选定"
                        CssClass="ButtonDelNoBg" RaiseMsg="您确定删除选定记录吗?" OnClick="btnDel_Click" CausesValidation="False" /></td>
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
            <asp:DataGrid ID="DgrBoxGroup" runat="server" AutoGenerateColumns="False" DataKeyField="BoxGroupID"
                Width="100%" OnItemCreated="DgrBoxGroup_ItemCreated">
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
                    <asp:TemplateColumn HeaderText="组别名称">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="left" />
                        <ItemTemplate>
                            <cc1:TextBox ID="txtGroupName" runat="server" CssClass="inputtxt" MaxLength="50" Text='<%# DataBinder.Eval(Container, "DataItem.BoxGroupName") %>'
                                Width="80%"></cc1:TextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="排序">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <cc1:NumericTextBox ID="txtordernum" runat="server" CssClass="inputtxt" Text='<%# DataBinder.Eval(Container, "DataItem.ordernum") %>'
                                Width="88">
                            </cc1:NumericTextBox>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid></ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
