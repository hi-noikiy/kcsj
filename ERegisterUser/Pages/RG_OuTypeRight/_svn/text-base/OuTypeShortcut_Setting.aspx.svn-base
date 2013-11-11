<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="true"
    CodeBehind="OuTypeShortcut_Setting.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_OuTypeRight.OuTypeShortcut_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript" type="text/javascript">
        function AutoSetMValue(Item, ShortcutGuid) {
            var HidGuid = document.getElementById("<%=HidShortcutGuid.ClientID%>").value;
            HidGuid = HidGuid.replace(ShortcutGuid + ";", "")
            if (Item.checked) {
                HidGuid = HidGuid + ShortcutGuid + ";";
            }
            document.getElementById("<%=HidShortcutGuid.ClientID%>").value = HidGuid;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="Div_ControlNoTop" align="left">
                <table border="0" cellpadding="0" cellspacing="0" height="100%">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <epoint:Button ID="savbtn" MouseOverClass="ButtonSave" runat="server" CssClass="ButtonSaveNoBg"
                                Text="保存设置" OnClick="savbtn_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                                OnClientClick="window.close();" runat="server" Text="取消设置" /><asp:HiddenField ID="HidShortcutGuid"
                                    runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" cellspacing="1">
        <tr>
            <td height="32" class="TableSpecial1">
                <asp:Label ID="lblName" runat="server"></asp:Label><asp:Label ID="lblOuName" runat="server"></asp:Label>
                说明： 如果该模块设置为完全公开，则在这里不能设置。
            </td>
        </tr>
        <tr>
            <td>
                <asp:Repeater ID="rptFirShortcut" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <table width="100%" height="100%">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend>
                                            <%# DataBinder.Eval(Container.DataItem,"ItemText")%>
                                        </legend>
                                        <table width="100%">
                                            <tr>
                                                <td width="40px">
                                                </td>
                                                <td>
                                                    <asp:Repeater ID="rptOthShortcut" runat="server" DataSource='<%#getSubShortcutView(DataBinder.Eval(Container.DataItem, "ItemValue")) %>'>
                                                        <ItemTemplate>
                                                            <%#getShortcutGuid(DataBinder.Eval(Container.DataItem, "ShortcutText"), DataBinder.Eval(Container.DataItem, "RowGuid"))%>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
</asp:Content>
