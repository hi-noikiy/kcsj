<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageNoLocation.Master" AutoEventWireup="true"
    Codebehind="ConsultBoxXinFangListMana.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxXinFang.ConsultBoxXinFangListMana"
    Title="�ޱ���ҳ" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc2" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="cc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
function HandleAll(url)
{
     //OpenDialogRefresh(url,"","750","696");	
     OpenWindow(url,screen.availWidth,screen.availHeight);
} 
    </script>

    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" height="25">
                &nbsp;</td>
            
            <td>
                ���⣺</td>
            <td>
                <cc2:TextBox ID="txtTitle" runat="server" CssClass="inputtxt"></cc2:TextBox>
            </td>
            <td>
                &nbsp;�ύ�ˣ�</td>
            <td>
                <cc2:TextBox ID="txtpostuser" runat="server" CssClass="inputtxt" MaxLength="100"
                    Width="80"></cc2:TextBox></td>
            <td>
                &nbsp;�ύʱ�䣺
            </td>
            <td>
                <cc2:DateFromTo ID="DateFromTo1" runat="server" Character="HX" runat="server" FromWidth="80px"
                    ToWidth="80px" FromTextCssClass="inputtxt" ToTextCssClass="inputtxt" />
            </td>
            <td>
                &nbsp;<cc2:Button ID="btnSearch" runat="server" Text="��  ѯ" CssClass="ButtonSearchNoBg"
                    MouseOverClass="ButtonSearch" OnClick="btnSearch_Click" /></td>
        </tr>
        <tr>
            <td align="left" height="25">
                &nbsp;</td>
            <td colspan="7">
                <table border="0">
                    <tr>
                        <td>����״����</td>
                        <td>
                            <asp:RadioButtonList ID="jpdProcesstype" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="jpdProcesstype_SelectedIndexChanged" >
                                <asp:ListItem Value="4" Enabled="true" Selected="True">Ĭ��</asp:ListItem>
                                <asp:ListItem Value="5" Enabled="true">������</asp:ListItem>
                                <asp:ListItem Value="6" Enabled="true">δ����</asp:ListItem>
                                <asp:ListItem Value="7" Enabled="true">�Ѵ���</asp:ListItem>
                                <asp:ListItem Value="8" Enabled="true">�Ѱ��</asp:ListItem>
                            </asp:RadioButtonList>
                            <!--<asp:ListItem Value="0" Enabled="false">δ�ַ�</asp:ListItem>
                            <asp:ListItem Value="1" Enabled="false">�ѷַ�</asp:ListItem>
                            <asp:ListItem Value="2" Enabled="false">�ݲ�����</asp:ListItem>
                            <asp:ListItem Value="3" Enabled="false">��ʾȫ��</asp:ListItem>-->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="Div_Control">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <cc1:DeleteButton ID="BtnDel" OnClientClick="if(!Check_SelectedStatus('chksel')) return false;"
                        runat="server" CssClass="ButtonDelNoBg" MouseOverClass="ButtonDel" OnClick="BtnDel_Click"
                        Text="ɾ��ѡ��" /></td>
                <td>
                    <cc2:Button ID="BtnEditOrderNum" runat="server" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                        Text="��������" OnClick="BtnEditOrderNum_Click" /></td>
                <td>
                    <cc2:Button ID="btnOnWeb" runat="server" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                        Text="����״̬" OnClick="btnOnWeb_Click" AfterClickJSFunction="alert('���·���״̬�ɹ���');" /></td>
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
                    PagingButtonType="Image" OnPageChanged="Pager_PageChanged" ImagePath="../../Images/page/"
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
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" DataKeyField="HistoryGuid"
        HorizontalAlign="Center" Width="100%" OnItemCreated="DgrQuestionnaire_ItemCreated">
        <HeaderStyle HorizontalAlign="center" />
        <Columns>
            <asp:TemplateColumn HeaderText="���">
                <HeaderStyle HorizontalAlign="Center" Width="35px" />
                <ItemStyle HorizontalAlign="Center" Width="35px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="&lt;input type=checkbox name=&quot;chksel&quot; id=&quot;chksel&quot; onclick=&quot;javascript:AllSelect(this)&quot;&gt;">
                <HeaderStyle Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                <ItemTemplate>
                    <asp:CheckBox ID="chksel" runat="server" />
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="ʱ��">
                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                <ItemTemplate>
                    <%# GetLight(DataBinder.Eval(Container, "DataItem.HistoryGuid"), DataBinder.Eval(Container, "DataItem.PostDate"), DataBinder.Eval(Container, "DataItem.HandleDate"), DataBinder.Eval(Container, "DataItem.InfoStatus"), DataBinder.Eval(Container, "DataItem.IsDelete"), DataBinder.Eval(Container, "DataItem.PublishOnWeb"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="��������">
                <HeaderStyle HorizontalAlign="Center" Width="90px" />
                <ItemStyle HorizontalAlign="Center" Width="90px" />
                <ItemTemplate>
                    <%# GetBoxName(DataBinder.Eval(Container, "DataItem.UserSendToBoxGuid"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="����">
                <ItemStyle CssClass="Itemstyle" HorizontalAlign="left" />
                <ItemTemplate>
                    <a href='javascript:HandleAll("HandleConsultantToXinFang.aspx?HistoryGuid=<%#DataBinder.Eval(Container, "DataItem.HistoryGuid")%>");'>
                        <%# DataBinder.Eval(Container, "DataItem.Subject") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="PostUserName" HeaderText="�ύ��" Visible="false">
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                <ItemStyle HorizontalAlign="left" Width="60px" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="PostDate" HeaderText="�ύ����" DataFormatString="{0:yyyy-MM-dd}">
                <HeaderStyle Width="80px" HorizontalAlign="Center" />
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="HandleDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}">
                <HeaderStyle Width="80px" HorizontalAlign="Center" />
                <ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="�ż�״̬">
                <HeaderStyle Width="90px" />
                <ItemStyle HorizontalAlign="Center" Width="90px" />
                <ItemTemplate>
                    <%# GetInfoStatus(DataBinder.Eval(Container, "DataItem.InfoStatus"), DataBinder.Eval(Container, "DataItem.IsDelete"), DataBinder.Eval(Container, "DataItem.PublishOnWeb"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="����">
                <ItemStyle HorizontalAlign="Center" Width="50px" />
                <ItemTemplate>
                    <cc2:NumericTextBox ID="txtXuHao" runat="server" CssClass="inputtxt" Text='<%#DataBinder.Eval(Container, "DataItem.OrderNum")%>'
                        Width="80%">
                    </cc2:NumericTextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
             <asp:TemplateColumn HeaderText="���Ϸ���" Visible="false">
                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Center" Width="50px" />
                <ItemTemplate>
                    <asp:CheckBox ID="chkOnWeb" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.publishonweb")%>' />
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
                    PagingButtonType="Image" OnPageChanged="Pager_PageChanged" ImagePath="../../Images/page/"
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
