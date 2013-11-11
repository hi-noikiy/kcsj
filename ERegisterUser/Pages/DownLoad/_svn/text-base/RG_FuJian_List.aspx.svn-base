<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_OU.RG_FuJian_List" CodeBehind="RG_FuJian_List.aspx.cs"
    Title="附件记录列表" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.ButtonControls"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>


        function CreatFuJianList(obj) {
            var lis = document.getElementById('<%=hiFuJianList.ClientID %>').value;
            if (obj.checked == true) {

                lis = lis + obj.value + ";";
            }
            else {
                lis = lis.replace(obj.value + ";", '');
            }
            document.getElementById('<%=hiFuJianList.ClientID %>').value = lis;

        }

        //-->
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0" class="table">
                <tbody>
                    <tr style="display: none">
                        <td style="height: 30px" class="tablespecial" colspan="2">
                            当前数据表：<asp:Label ID="lblTableName" runat="server"></asp:Label><input id="HidState"
                                type="hidden" value="0" name="HidState" runat="server">
                        </td>
                    </tr>
                    <tr class="tablespecial">
                        <td id="tdCl" valign="middle" align="center" colspan="2" runat="server" style="display: none">
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                            <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                                <tr>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        项目经理
                                    </td>
                                    <td class="Tablespecial" width="35%" height="25" valign="middle">
                                        <epoint:TextBox ID="s_xiangMuJL" CssClass="inputtxt" runat="server" MaxLength="50"></epoint:TextBox>
                                    </td>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        登记日期
                                    </td>
                                    <td class="Tablespecial" width="35%" height="25" valign="middle">
                                        <epoint:DateFromTo ID="d_dengJiRQ" FromTextCssClass="inputtxt" ToTextCssClass="inputtxt"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        项目编号
                                    </td>
                                    <td class="Tablespecial" width="35%" height="25" valign="middle">
                                        <epoint:TextBox ID="s_xiangmuBH" CssClass="inputtxt" runat="server" MaxLength="200"></epoint:TextBox>
                                    </td>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        决策日期
                                    </td>
                                    <td class="Tablespecial" width="35%" height="25" valign="middle">
                                        <epoint:DateFromTo ID="d_TouZiJCSJ" FromTextCssClass="inputtxt" ToTextCssClass="inputtxt"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        项目登记人
                                    </td>
                                    <td class="Tablespecial" width="35%" height="25" valign="middle">
                                        <epoint:TextBox ID="s_dengJiR" CssClass="inputtxt" runat="server" MaxLength="50"></epoint:TextBox>
                                    </td>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        项目来源
                                    </td>
                                    <td class="Tablespecial" width="35%" height="25" valign="middle">
                                        <asp:DropDownList ID="s_xiangMuLY" runat="server" Height="100%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        项目名称
                                    </td>
                                    <td class="Tablespecial" width="35%" height="25" valign="middle">
                                        <epoint:TextBox ID="s_xiangMuMC" CssClass="inputtxt" runat="server" MaxLength="200"></epoint:TextBox>
                                    </td>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        项目公司全称
                                    </td>
                                    <td class="Tablespecial" width="35%" height="25" valign="middle">
                                        <epoint:TextBox ID="s_xiangMuGSQC" CssClass="inputtxt" runat="server" MaxLength="200"></epoint:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        管理平台
                                    </td>
                                    <td class="Tablespecial" width="85%" height="25" valign="middle" colspan="3">
                                        <asp:CheckBoxList ID="s_GuanLiPT" runat="server" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Tablespecial1" width="15%" align="Right">
                                        项目状态
                                    </td>
                                    <td class="Tablespecial" width="85%" height="25" valign="middle" colspan="3">
                                        <asp:CheckBoxList ID="s_xiangMuZT" runat="server" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                            <input type="hidden" runat="server" id="hiFuJianList" />
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
                                                ID="btnSearch" runat="server" Text="打开搜索" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            &nbsp;<epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                                Text="查找" CssClass="ButtonSearchNoBg" OnClick="btnOK_Click"></epoint:Button>
                                        </td>
                                        <td>
                                            &nbsp;<epoint:DeleteButton Text="批量下载" ID="btnDel" MouseOverClass="ButtonAdd" runat="server"
                                                CssClass="ButtonAddNoBg" OnClick="btnDown_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                                RaiseMsg="您确定下载选定记录吗?" />
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
                                            <input id="chkAddAll" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd"
                                                style="display: none">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<asp:CheckBox ID="chkAdd" runat="server" onclick="CreatFuJianList(this)" value='<%# DataBinder.Eval(Container, "DataItem.RowGuid")%>' ></asp:CheckBox>--%>
                                            <input id="chkAdd" runat="server" onclick="javascript:CreatFuJianList(this)" type="checkbox"
                                                value='<%# DataBinder.Eval(Container, "DataItem.RowGuid")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="序号">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="附件名称" SortExpression="pic_FuJian_FileName">
                                        <ItemTemplate>
                                            <%--<%# DataBinder.Eval(Container, "DataItem.pic_FuJian_FileName")%>--%>
                                            <%# "<a target='_blank'  href='" + Request.ApplicationPath + "/EpointMis/Pages/CommonPages/RetrieveImageData.aspx?TableName=GY_CaiLiaoEntityFuJian&FieldName=pic_FuJian&RowGuid=" + DataBinder.Eval(Container, "DataItem.RowGuid") + "'><font color='red'>" + DataBinder.Eval(Container, "DataItem.pic_FuJian_FileName") + "</font></a>" %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="业务类别" SortExpression="s_YeWuMC">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.s_YeWuMC")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="归属项目" SortExpression="s_xiangmumc">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.s_xiangmumc")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="归属企业" SortExpression="DWName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.DWName")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="上传时间" SortExpression="d_TiJiaoSJ">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.d_TiJiaoSJ", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="删除状态" SortExpression="i_delete">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.i_delete").ToString() == "1"?"已删除":""%>
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
                                EnableViewState="false">
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
