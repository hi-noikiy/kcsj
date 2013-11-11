<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="FuJian.ascx.cs" Inherits="HTProject.Ascx.FuJian" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<script language="javascript">
    function FileSumit(obj) {
        //alert('1');
        reg = /File1/g;
        var idtag = obj.id.replace(reg, "");
        //alert(idtag);
        //alert(document.all(idtag + "txtFile").value);
        //alert(document.all(idtag + "cmdAttach"));
        //document.all(idtag + "txtFile").value = obj.value;
        document.all(idtag + "cmdAttach").click();
    }
    
</script>

<style type="text/css">
    .fileInput
    {
        width: 102px;
        height: 25px;
        background: url(../images/upFileBtn.png);
        overflow: hidden;
        position: relative;
    }
    .upfile
    {
        position: absolute;
        top: -100px;
    }
    .upFileBtn
    {
        width: 102px;
        height: 25px;
        opacity: 0;
        filter: alpha(opacity=0);
        cursor: pointer;
    }
</style>

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" id="tabMain" runat="server">
            <tr>
                <td>
                    <table width="100%">
                        <tr valign="middle">
                            <td class="TableSpecial1" width="30%">
                                <%=ClientTag %>
                            </td>
                            <td class="TableSpecial1" colspan="2" runat="server" id="trAdd">
                                <div class="fileInput left">
                                    <input id="File1" style="width: 54px; height: 22px;" type="file" onchange="FileSumit(this);"
                                        size="1" runat="server" class="upFileBtn" />
                                    </div>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td>
                                <input id="txtFile" style="width: 70%; height: 22px" type="text" runat="server" contenteditable="false"
                                    class="inputtxt" /><input type="hidden" runat="server" id="hiSize" value="300" />
                            </td>
                            <td style="text-align: center; vertical-align: middle; display: none">
                                <asp:DropDownList ID="drpAttachType" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:Button ID="cmdAttach" Style="visibility: hidden" runat="server" Width="1px"
                                    CausesValidation="false" Text="添加" Height="1px" OnClick="cmdAttach_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td colspan="3">
                                <asp:DataGrid ID="dgAttachment" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                    DataKeyField="AttachGuid" BackColor="White" BorderColor="#CCCCCC" PageSize="16"
                                    BorderWidth="1px" CellPadding="3" Width="100%" OnItemDataBound="dgAttachment_ItemDataBound"
                                    OnItemCommand="dgAttachment_ItemCommand">
                                    <FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
                                    <SelectedItemStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#669999">
                                    </SelectedItemStyle>
                                    <AlternatingItemStyle Font-Size="X-Small"></AlternatingItemStyle>
                                    <ItemStyle Font-Size="X-Small" ForeColor="#000066"></ItemStyle>
                                    <HeaderStyle BackColor="#F1F5FF" ForeColor="#000033" HorizontalAlign="center"></HeaderStyle>
                                    <Columns>
                                        <asp:TemplateColumn HeaderText="附件名称">
                                            <ItemTemplate>
                                                <%#getAttachInfo(DataBinder.Eval(Container.DataItem, "AttachGuid"), DataBinder.Eval(Container.DataItem, "AttachFileName"), DataBinder.Eval(Container.DataItem, "ContentType"))%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="附件类型">
                                            <HeaderStyle Width="80px"></HeaderStyle>
                                            <ItemStyle Width="80px" />
                                            <ItemTemplate>
                                                <%# getFuJianType(DataBinder.Eval(Container.DataItem, "AttachGuid"))%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="附件大小">
                                            <HeaderStyle Width="80px"></HeaderStyle>
                                            <ItemStyle Width="80px" />
                                            <ItemTemplate>
                                                <%# getFuJianDX(DataBinder.Eval(Container.DataItem, "AttachGuid"))%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="操作">
                                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Button ID="cmdDel" runat="server" CausesValidation="false" CssClass="btnbg"
                                                    Text="删除" OnClientClick="return window.confirm('确定删除？');" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle NextPageText="下一页" PrevPageText="上一页" HorizontalAlign="Left" ForeColor="#000066"
                                        BackColor="White"></PagerStyle>
                                </asp:DataGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trRemark" runat="server" style="display: none">
                <td colspan="2">
                    <font color="#0000ff">* 点击“浏览”可上传文件</font>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="labMsg" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
