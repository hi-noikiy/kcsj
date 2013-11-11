<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPage_NoAjax.master" AutoEventWireup="true"
    CodeBehind="WaitHandle_NeedHandle_Banli.aspx.cs" Inherits="HTProject.Pages.WaitBL.WaitHandle_NeedHandle_Banli"
    Title="待办件" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript">
    var t1 = new Date().getTime();
    </script>

    <script type="text/javascript">
    function selectall(value)
	 { 
       var checkboxes = document.getElementsByTagName("input");
       for (i = 0; i < checkboxes.length; i++)
       { 
           if(checkboxes[i].type=='checkbox')
           {
                if (value.checked)
                 { 
                    checkboxes[i].checked = true; // this checks all the boxes 
                 }
                else
                 { 
                    checkboxes[i].checked = false; // this unchecks all the boxes 
                 } 
             }
       } 
     }
     function window_onload() {
//         var tmp = ('服务器端执行时间:<%=ViewState["ServerTimeSpan"] %>毫秒;客户端加载本页耗时' + (new Date().getTime() - t1) + "毫秒");
//         document.getElementById("TimeShow").innerHTML = tmp;
         /*
         <table>
         <tr>
         <td>
         <div id="TimeShow">
         </div>
         </td>
         </tr>
         </table>
         */
     }

    </script>

    <div class="Div_ControlNoTop_Class">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td align="right" nowrap>
                    时间：
                </td>
                <td align="left" nowrap>
                    <epoint:DateFromTo ID="DateFromTo" Character="HX" runat="server" FromWidth="73px" ToWidth="73px"
                        FromTextCssClass="inputtxt" ToTextCssClass="inputtxt" />
                </td>
                <td align="right" nowrap>
                    标题：
                </td>
                <td align="left" nowrap>
                    <asp:TextBox ID="txtTitle" Width="80px" runat="server"></asp:TextBox>
                </td>
                <td align="right" nowrap id="tdArchiveS1" runat="server">
                    &nbsp;文号：
                </td>
                <td align="left" nowrap id="tdArchiveS2" runat="server">
                    <asp:TextBox ID="txtArchiveNo" Width="80px" runat="server"></asp:TextBox>
                </td>
                <td align="right" id="tdtype" runat="server" nowrap>
                    类别：
                </td>
                <td align="left" nowrap>
                    <asp:DropDownList ID="dropType" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left" nowrap>
                    <epoint:Button ID="btnSearch" runat="server" Text="查  询" OnClick="btnSearch_Click" CssClass="ButtonSearchNobg"
                        MouseOverClass="ButtonSearch" />
                </td>
            </tr>
        </table>
    </div>
    <div class="Div_ControlNoTop_Class" style="display:none">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td align="left" nowrap>
                    <epoint:DeleteButton ID="btnDel" runat="server" Text="删除选定" CssClass="ButtonDelNoBg"
                        MouseOverClass="ButtonDel" OnClientClick="if(!Check_SelectedStatus('toSelect','请选择需要删除的待办件！')) return false;"
                        OnClick="btnDel_Click" />
                </td>
                <td align="left" nowrap>
                    <epoint:Button ID="btnAddFavorite" runat="server" Text="加入收藏夹" CssClass="ButtonConNobg"
                        OnClientClick="if(!Check_SelectedStatus('toSelect','请选择需要加入收藏夹的待办件！')) return false;"
                        MouseOverClass="ButtonCon" OnClick="btnAddFavorite_Click" />
                </td>
                <td align="left" nowrap>
                    <epoint:Button ID="btn_Huanban" runat="server" Text="转为缓办" CssClass="ButtonOKNobg" MouseOverClass="ButtonOK"
                        OnClientClick="if(!Check_SelectedStatus('toSelect','请选择需要转为缓办的待办件！')) return false;"
                        OnClick="btn_Huanban_Click" />
                </td>
            </tr>
        </table>
    </div>

    <script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table id="Pp1" runat="server" border="0" cellpadding="0" cellspacing="0" class="Pagelist">
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
    <asp:DataGrid ID="GridHandle" runat="server" Width="100%" DataKeyField="MessageItemGuid"
        AutoGenerateColumns="False" CellSpacing="1">
        <HeaderStyle HorizontalAlign="center" />
        <Columns>
            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center" />
                <HeaderStyle Width="30" HorizontalAlign="Center" />
                <HeaderTemplate>
                    <input id="ckboxAll" type="checkbox" onclick="selectall(this)" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input id="toSelect" name="toSelect" type="checkbox" runat="server" />
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="序号" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                <HeaderStyle Width="30" />
                <ItemTemplate>
                    <%# (this.Pager.CurrentPageIndex-1) * this.Pager.PageSize + this.GridHandle.Items.Count + 1%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="标题">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <%# getTopic(DataBinder.Eval(Container, "DataItem.MessageItemGuid"), DataBinder.Eval(Container, "DataItem.Title"), DataBinder.Eval(Container, "DataItem.HandleUrl"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="文号" ItemStyle-HorizontalAlign="left">
                <HeaderStyle />
                <ItemStyle Wrap="false" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container, "DataItem.ArchiveNo ")%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="步骤名称" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Wrap="false" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container, "DataItem.BeiZhu ")%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="办理人" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Wrap="false" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container, "DataItem.TargetDispName ")%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="提交人" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Wrap="false" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container, "DataItem.FromDispName ")%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="GenerateDate" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                HeaderText="发送时间">
                <HeaderStyle Width="120" />
                <ItemStyle Width="120" Wrap="false" />
            </asp:BoundColumn>
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
