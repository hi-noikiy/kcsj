<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddZYForZZInfo.aspx.cs"
    Inherits="HTProject.Pages.RG_XMBeiAn.AddZYForZZInfo" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
        function MyPageValidate(message) {
            var bRet = false;
            if (Page_ClientValidate()) {
                return window.confirm(message);
            }
            else {
                bRet = false;
            }
            return bRet;
        }
    </script>

    <epoint:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <epoint:Button ID="btnAdd" runat="server" Text="添加保存" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnAdd_Click" OnClientClick="return MyPageValidate('确定保存？');"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="取消添加" runat="server" CausesValidation="false" OnClientClick="window.close();">
                            </epoint:Button>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <table width="100%" cellspacing="1" align="center">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            专业<span style="color: Red">*</span><br />
                            <asp:Label ID="lblZZText" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left">                            
                            <epoint:TextTreeView ID="RegionTreeView" runat="server" DivHeight="250px" RelationName="所有专业"
                                DivWidth="300px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                RootNodeText="专业选择" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                InputType="CheckBox" AllowNull="false"  TextMode="MultiLine" TextBoxHeight="100px" SelectItemMax="100"
                                MultiSelect="true">
                            </epoint:TextTreeView>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                ShowMessageBox="True"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
