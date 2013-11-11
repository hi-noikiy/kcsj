<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageNoLocation.Master" AutoEventWireup="true"
    CodeBehind="ConsultBoxListMana.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxManage.ConsultBoxListMana"
    Title="无标题页" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc2" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>

        function HandleAll(url) {
            //OpenDialogRefresh(url,"","750","696");	
            OpenWindow(url, "750", "696");

        }

    </script>

    <table border="0" cellpadding="0" cellspacing="0">
        <tr height="25">
            <td align="left">
                &nbsp;
            </td>
            <td>
                标题：
            </td>
            <td>
                <cc2:TextBox ID="txtTitle" runat="server" CssClass="inputtxt" MaxLength="100" Width="80">
                </cc2:TextBox>
            </td>
            <td>
                &nbsp;提交人：
            </td>
            <td>
                <cc2:TextBox ID="txtpostuser" runat="server" CssClass="inputtxt" MaxLength="100"
                    Width="80">
                </cc2:TextBox>
            </td>
            <td>
                &nbsp;提交时间：
            </td>
            <td>
                <cc2:DateFromTo ID="DateFromTo1" runat="server" Character="HX" FromWidth="80px" ToWidth="80px"
                    FromTextCssClass="inputtxt" ToTextCssClass="inputtxt" />
            </td>
            <td>
                &nbsp;<cc2:Button ID="btnSearch" runat="server" Text="查  询" CssClass="ButtonSearchNoBg"
                    MouseOverClass="ButtonSearch" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr height="25">
            <td>
                &nbsp;
            </td>
            <td colspan="7">
                <table border="0">
                    <tr>
                        <td>
                            处理状况：
                        </td>
                        <td>
                            <asp:RadioButtonList ID="jpdProcesstype" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="True" OnSelectedIndexChanged="jpdProcesstype_SelectedIndexChanged">
                                <asp:ListItem Value="0" Selected="True">未处理</asp:ListItem>
                                <asp:ListItem Value="1">已处理</asp:ListItem>
                                <asp:ListItem Value="2">暂不处理</asp:ListItem>
                                <asp:ListItem Value="3">显示全部</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="display: none;">
            <td align="left">
                &nbsp;
            </td>
            <td>
                编码查询：
            </td>
            <td>
                <cc2:TextBox ID="txtConsultPWD" runat="server" CssClass="inputtxt" MaxLength="100"
                    Width="80">
                </cc2:TextBox>
            </td>
            <td>
                受理部门：
            </td>
            <td>
                <cc2:TextBox ID="txtShouLiDept" runat="server" CssClass="inputtxt" MaxLength="100"
                    Width="80">
                </cc2:TextBox>
            </td>
        </tr>
    </table>
    <div id="Div_Control">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 22px">
                    &nbsp;
                </td>
                <td>
                    <cc1:DeleteButton ID="BtnDel" runat="server" OnClientClick="if(!Check_SelectedStatus('chksel')) return false;"
                        CssClass="ButtonDelNoBg" MouseOverClass="ButtonDel" OnClick="BtnDel_Click" Text="删除选定" />
                </td>
                <td>
                    <cc2:Button ID="BtnEditOrderNum" runat="server" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                        Text="更新排序" OnClick="BtnEditOrderNum_Click" />
                </td>
                <td>
                    <cc2:Button ID="btnOnWeb" runat="server" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                        Text="更新状态" OnClick="btnOnWeb_Click" AfterClickJSFunction="alert('更新发布状态成功！');" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table border="0" id="Pp1" runat="server" cellpadding="0" cellspacing="0" class="Pagelist">
        <tr>
            <td>
                <div class="Pagelist_1">
                </div>
            </td>
            <td class="Pagelist_bg">
                <webdiyer:AspNetPager ID="Pager" runat="server" PageSize="15" NavigationButtonType="Image"
                    PagingButtonType="Image" OnPageChanged="Pager_PageChanged" ImagePath="../../../Images/page/"
                    CpiButtonImageNameExtension="r" DisabledButtonImageNameExtension="g" ButtonImageNameExtension="n"
                    ShowCustomInfoSection="Left" InputBoxClass="inputtxt" SubmitButtonClass="backendbtn22"
                    AlwaysShow="True">
                </webdiyer:AspNetPager>
            </td>
            <td>
                <div class="Pagelist_2">
                </div>
            </td>
        </tr>
    </table>
    <asp:DataGrid ID="DataGrid1" runat="server" AllowCustomPaging="True" AllowPaging="False"
        AllowSorting="False" AutoGenerateColumns="False" DataKeyField="HistoryGuid" HorizontalAlign="Center"
        Width="100%" OnItemCreated="DgrQuestionnaire_ItemCreated">
        <HeaderStyle HorizontalAlign="center" />
        <Columns>
            <asp:TemplateColumn HeaderText="序号">
                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="&lt;input type=checkbox name=&quot;chksel&quot; id=&quot;chksel&quot; onclick=&quot;javascript:AllSelect(this)&quot;&gt;">
                <HeaderStyle Width="35px" />
                <ItemStyle HorizontalAlign="Center" Width="35px" />
                <ItemTemplate>
                    <asp:CheckBox ID="chksel" runat="server" Enabled='<%# DataBinder.Eval(Container, "DataItem.HandleType").ToString()!="联办件"%>' />
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="时限">
                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                <ItemTemplate>
                    <%# GetLight(DataBinder.Eval(Container, "DataItem.HandleEndDate"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="受理部门" Visible="false">
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container, "DataItem.OUName")%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="处理信箱">
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                    <%# GetBoxName(DataBinder.Eval(Container, "DataItem.BoxGuid"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="ConsultPWD" HeaderText="信件编码" Visible="false">
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="Center" Width="60px" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="标题">
                <ItemStyle CssClass="Itemstyle" HorizontalAlign="left" />
                <ItemTemplate>
                    <div style="width: 100%; height: 100%; cursor: hand; padding-top: 6px;" onclick='HandleAll("../HandleConsultant.aspx?HistoryGuid=<%#DataBinder.Eval(Container,"DataItem.HistoryGuid")%>&Row_ID=<%#DataBinder.Eval(Container, "DataItem.Row_ID")%>");'>
                        <%# DataBinder.Eval(Container, "DataItem.Subject") %>
                    </div>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="PostUserName" HeaderText="提交人">
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="left" Width="80px" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="受理信箱" Visible="false">
                <HeaderStyle HorizontalAlign="Center" Width="90px" />
                <ItemStyle HorizontalAlign="Center" Width="90px" />
                <ItemTemplate>
                    <%# GetBoxName(DataBinder.Eval(Container, "DataItem.UserSendToBoxGuid"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="FenfaDate" HeaderText="分发日期" DataFormatString="{0:yyyy-MM-dd}">
                <HeaderStyle Width="80px" HorizontalAlign="Center" />
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="HandleDate" HeaderText="处理日期" DataFormatString="{0:yyyy-MM-dd}">
                <HeaderStyle Width="80px" HorizontalAlign="Center" />
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="处理情况">
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="Center" Width="60px" />
                <ItemTemplate>
                    <%# getHandleStat(DataBinder.Eval(Container, "DataItem.HandleStatus"), DataBinder.Eval(Container, "DataItem.IsDelete"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="排序">
                <ItemStyle HorizontalAlign="Center" Width="50px" />
                <ItemTemplate>
                    <cc2:NumericTextBox ID="txtXuHao" runat="server" CssClass="inputtxt" Text='<%#DataBinder.Eval(Container, "DataItem.OrderNum")%>'
                        Width="90%">
                    </cc2:NumericTextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="网上发布">
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="Center" Width="60px" />
                <ItemTemplate>
                    <asp:CheckBox ID="chkOnWeb" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.publishonweb")%>' />
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="满意度反馈">
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="Center" Width="60px" />
                <ItemTemplate>
                    <%# GetMYD(DataBinder.Eval(Container, "DataItem.fankui"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="访问量" Visible="false">
                <ItemStyle HorizontalAlign="Center" Width="50px" />
                <ItemTemplate>
                    <%#DataBinder.Eval(Container, "DataItem.ClickTimes")%>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    <table id="Pp2" runat="server" border="0" cellpadding="0" cellspacing="0" class="Pagelist">
        <tr>
            <td>
                <div class="Pagelist_1">
                </div>
            </td>
            <td class="Pagelist_bg">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="15" NavigationButtonType="Image"
                    PagingButtonType="Image" OnPageChanged="Pager_PageChanged" ImagePath="../../../Images/page/"
                    CpiButtonImageNameExtension="r" DisabledButtonImageNameExtension="g" ButtonImageNameExtension="n"
                    ShowCustomInfoSection="Left" InputBoxClass="inputtxt" SubmitButtonClass="backendbtn22"
                    AlwaysShow="True">
                </webdiyer:AspNetPager>
            </td>
            <td>
                <div class="Pagelist_2">
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
