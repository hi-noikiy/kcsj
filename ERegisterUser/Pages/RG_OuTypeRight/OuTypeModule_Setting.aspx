<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="true"
    CodeBehind="OuTypeModule_Setting.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_OuTypeRight.OuTypeModule_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript" type="text/javascript">
        function GetParentClick(e, mcode) {
            var elen = e.name.length;
            var chk = document.getElementsByTagName("input");
            for (var i = 0; i < chk.length; i++) {
                //将所有的下级都选上
                if (chk[i].name.substring(0, elen) == e.name) {
                    chk[i].checked = e.checked;
                }
                //如果是勾上的，将所有的上级也勾上
                if (e.checked) {
                    if (chk[i].name == e.name.substring(0, chk[i].name.length)) {
                        chk[i].checked = true;
                    }
                }
            }
            //判断是否需要取消上级的权限
            if (!e.checked) {
                //需要检验的chkbox的ID，chkID
                for (var chkID = e.name.substring(0, e.name.length - 4); chkID != ""; chkID = chkID.substring(0, chkID.length - 4)) {
                    //alert(1)
                    //alert(chkID);
                    //遍历一下checkbox
                    for (var i = 0; i < chk.length; i++) {
                        if (chk[i].name.substring(0, chkID.length) == chkID && chk[i].name.length != chkID.length && chk[i].checked) {
                            //alert(2)
                            //alert(chk[i].name);
                            return;
                        }
                    }
                    //alert(3);
                    document.getElementById(chkID).checked = false;
                }
            }
        }

        function AutoSetMValue(Item, ModuleGuid) {
            var HidGuid = document.getElementById("<%=HidModuleGuid.ClientID%>").value;
            HidGuid = HidGuid.replace(ModuleGuid + ";", "")
            if (Item.checked) {
                HidGuid = HidGuid + ModuleGuid + ";";
            }
            document.getElementById("<%=HidModuleGuid.ClientID%>").value = HidGuid;
        }

        function propertyChange(e) {
            if (e.checked)
                document.getElementById("trAppModule").style.display = '';
            else
                document.getElementById("trAppModule").style.display = 'none';
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
                                OnClientClick="window.close();" runat="server" Text="取消设置" /><asp:HiddenField ID="HidModuleGuid"
                                    runat="server" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <input type="checkbox" name="chkshow" runat="server" onclick="propertyChange(this)" />显示子系统模块
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
                <table width="100%" height="100%">
                    <tr>
                        <td>
                            <fieldset>
                                <legend>会员系统模块 </legend>
                                <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <fieldset>
                                                        <legend>
                                                            <%#getModuleGuid(DataBinder.Eval(Container.DataItem, "RowGuid"), DataBinder.Eval(Container.DataItem, "ModuleCode"), DataBinder.Eval(Container.DataItem, "ModuleName"))%>
                                                        </legend>
                                                        <table width="100%" id="td_<%#DataBinder.Eval(Container.DataItem, "ModuleCode")%>">
                                                            <tr>
                                                                <td>
                                                                    <asp:Repeater ID="rptSecModule" runat="server" DataSource='<%#getSubModuleView(DataBinder.Eval(Container.DataItem, "ModuleCode"),1) %>'>
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td width="40px">
                                                                                    </td>
                                                                                    <td>
                                                                                        <%#getModuleGuid(DataBinder.Eval(Container.DataItem, "RowGuid"), DataBinder.Eval(Container.DataItem, "ModuleCode"), DataBinder.Eval(Container.DataItem, "ModuleName"))%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="40px">
                                                                                    </td>
                                                                                    <td>
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td width="40px">
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Repeater ID="rptOthModule" runat="server" DataSource='<%#getSubModuleView(DataBinder.Eval(Container.DataItem, "ModuleCode"),2) %>'>
                                                                                                        <ItemTemplate>
                                                                                                            <%#getModuleGuid(DataBinder.Eval(Container.DataItem, "RowGuid"), DataBinder.Eval(Container.DataItem, "ModuleCode"), DataBinder.Eval(Container.DataItem, "ModuleName"))%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trAppModule" style="display: none">
            <td>
                <asp:Repeater ID="Repeater3" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <table width="100%" height="100%">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend>
                                            <%# DataBinder.Eval(Container.DataItem, "AppName")%>
                                        </legend>
                                        <asp:Repeater ID="Repeater2" runat="server" DataSource='<%#bindRpt2(DataBinder.Eval(Container.DataItem, "AppGuid")) %>'>
                                            <ItemTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <fieldset>
                                                                <legend>
                                                                    <%#getModuleGuid(DataBinder.Eval(Container.DataItem, "RowGuid"), DataBinder.Eval(Container.DataItem, "ModuleCode"), DataBinder.Eval(Container.DataItem, "ModuleName"))%>
                                                                </legend>
                                                                <table width="100%" id="td_<%#DataBinder.Eval(Container.DataItem, "ModuleCode")%>">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Repeater ID="rptSecModule" runat="server" DataSource='<%#getSubModuleView(DataBinder.Eval(Container.DataItem, "ModuleCode"),1) %>'>
                                                                                <ItemTemplate>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td width="40px">
                                                                                            </td>
                                                                                            <td>
                                                                                                <%#getModuleGuid(DataBinder.Eval(Container.DataItem, "RowGuid"), DataBinder.Eval(Container.DataItem, "ModuleCode"), DataBinder.Eval(Container.DataItem, "ModuleName"))%>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td width="40px">
                                                                                            </td>
                                                                                            <td>
                                                                                                <table width="100%">
                                                                                                    <tr>
                                                                                                        <td width="40px">
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:Repeater ID="rptOthModule" runat="server" DataSource='<%#getSubModuleView(DataBinder.Eval(Container.DataItem, "ModuleCode"),2) %>'>
                                                                                                                <ItemTemplate>
                                                                                                                    <%#getModuleGuid(DataBinder.Eval(Container.DataItem, "RowGuid"), DataBinder.Eval(Container.DataItem, "ModuleCode"), DataBinder.Eval(Container.DataItem, "ModuleName"))%>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:Repeater>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
</asp:Content>
