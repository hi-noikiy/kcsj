<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="true"
    CodeBehind="ConsultBoxManageSet.aspx.cs" Inherits="EpointRegisterUser.ConsultBox.ConsultBoxManageSet"
    Title="权限设置" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<%@ Register TagPrefix="igtab" Namespace="Infragistics.WebUI.UltraWebTab" Assembly="Infragistics2.WebUI.UltraWebTab.v6.3, Version=6.3.20063.53, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript">

        function delUserChecked() {
            var options = document.getElementById("<%=lstUser.ClientID %>").options;
            for (k = 0; k < options.length; k++) {
                if (options[k].selected) {
                    options[k] = null; k--;
                }
            }
            options = document.getElementById("<%=lstUser.ClientID %>").options;
            var temp = "";
            for (i = 0; i < options.length; i++) {
                temp = temp + options[i].value + "★";
            }
            document.getElementById("<%=HidUserList.ClientID %>").value = temp;
        }
        function delUserAll() {
            var options = document.getElementById("<%=lstUser.ClientID %>").options;
            for (i = 0; i < options.length; i++) {
                options[i] = null; i--;
            }
            document.getElementById("<%=HidUserList.ClientID %>").value = "";
        }
        function delOuChecked() {
            var options = document.getElementById("<%=lstOu.ClientID %>").options;
            for (k = 0; k < options.length; k++) {
                if (options[k].selected) {
                    options[k] = null; k--;
                }
            }
            options = document.getElementById("<%=lstOu.ClientID %>").options;
            var temp = "";
            for (i = 0; i < options.length; i++) {
                temp = temp + options[i].value + "★";
            }
            document.getElementById("<%=HidOuList.ClientID %>").value = temp;
        }
        function delOuAll() {
            var options = document.getElementById("<%=lstOu.ClientID %>").options;
            for (i = 0; i < options.length; i++) {
                options[i] = null; i--;
            }
            document.getElementById("<%=HidOuList.ClientID %>").value = "";
        }   
    </script>
    <div id="Div_ControlNoTop">
        <table align="left" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <cc1:Button ID="btnAddClose" runat="server" MouseOverClass="ButtonSave" CssClass="ButtonSaveNoBg"
                        Text="保存设置" OnClick="btnAddClose_Click" />
                </td>
                <td>
                    <cc1:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                        OnClientClick="window.close();" runat="server" Text="取消设置" CausesValidation="False" />
                </td>
                <td>
                    <asp:HiddenField ID="HidUserList" runat="server" />
                    <asp:HiddenField ID="HidOuList" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0">
        <tr>
            <td width="50%">
                <igtab:UltraWebTab ID="UltraWebTab1" runat="server" BorderStyle="Solid" BorderWidth="1px"
                    Height="497px" LoadAllTargetUrls="False" ThreeDEffect="False" Width="100%">
                    <DefaultTabStyle BackColor="GhostWhite" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                        Height="22px">
                        <Padding Top="1px" />
                    </DefaultTabStyle>
                    <RoundedImage FillStyle="LeftMergedWithCenter" HoverImage="../../../images/ig_tab_winXPs2.gif"
                        LeftSideWidth="7" NormalImage="../../../images/ig_tab_winXPs3.gif" RightSideWidth="6"
                        SelectedImage="../../../images/ig_tab_winXPs1.gif" ShiftOfImages="2" />
                    <SelectedTabStyle>
                        <Padding Bottom="2px" />
                    </SelectedTabStyle>
                    <Tabs>
                        <igtab:Tab Text="设置给前台会员">
                            <ContentPane TargetUrl="GetRGUserTree.aspx">
                            </ContentPane>
                        </igtab:Tab>
                        <igtab:Tab Text="设置给后台人员">
                            <ContentPane TargetUrl="GetBGUserTree.aspx">
                            </ContentPane>
                        </igtab:Tab>
                    </Tabs>
                </igtab:UltraWebTab>
            </td>
            <td>
                <fieldset>
                    <legend>已选择部门</legend>
                    <asp:ListBox ID="lstOu" runat="server" Width="100%" Height="201px" SelectionMode="Multiple">
                    </asp:ListBox>
                    <input id="Button1" type="button" onmouseout="this.className='ButtonDelNoBg'" onmouseover="this.className='ButtonDel'"
                        class="ButtonDelNoBg" value="删除选中" onclick="delOuChecked();" />
                </fieldset>
                <br />
                <fieldset>
                    <legend>已选择人员</legend>
                    <asp:ListBox ID="lstUser" runat="server" Width="100%" Height="201px" SelectionMode="Multiple">
                    </asp:ListBox>
                    <input id="btnCancle" type="button" onmouseout="this.className='ButtonDelNoBg'" onmouseover="this.className='ButtonDel'"
                        class="ButtonDelNoBg" value="删除选中" onclick="delUserChecked();" />
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
