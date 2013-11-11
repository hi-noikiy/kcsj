<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin.Master" AutoEventWireup="True"
    Codebehind="Code_Item_AddInfo.aspx.cs" Inherits="HTProject.Pages.Code.Code_Item_AddInfo"
    Title="" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <Epoint:Button ID="btnAdd" runat="server" MouseOverClass="ButtonCon" CssClass="ButtonConNoBg"
                                OnClick="btnAdd_Click" Text="保存并新建" /></td>
                        <td>
                            <Epoint:Button ID="btnAddClose" runat="server" MouseOverClass="ButtonSave" CssClass="ButtonSaveNoBg"
                                Text="保存并关闭" OnClick="btnAddClose_Click" /></td>
                        <td>
                            <Epoint:Button MouseOverClass="ButtonCancle" CssClass="ButtonCancleNoBg" ID="btnCancel"
                                OnClientClick="window.close();" runat="server" Text="取消添加" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel ID="UpdatePanel2" runat="server" >
            <ContentTemplate>
            
     <table width="100%" cellspacing="1">
        <tr>
            <td align="right" class="TableSpecial1">
                上级代码项：
            </td>
            <td align="left" class="TableSpecial">
                &nbsp;<asp:Label ID="txtPreItemName"   runat="server" ></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1">
                代码项名称：
            </td>
            <td align="left" class="TableSpecial">
                &nbsp;<Epoint:TextBox ID="txtItemText" MaxLength="50"  CssClass="inputtxt"  TextAlign="Left" runat="server" AllowNull="false"></Epoint:TextBox>
                
            </td>
        </tr>
        <tr id="spnInd" runat="server">
            <td align="right" class="TableSpecial1">
                代码项值：
            </td>
            <td align="left" class="TableSpecial">
                &nbsp;<Epoint:TextBox ID="txtItemValue" MaxLength="50"  CssClass="inputtxt"  TextAlign="Left" runat="server" AllowNull="false"></Epoint:TextBox>
                
            </td>
        </tr>
       
        <tr>
            <td align="right" class="TableSpecial1">
                拼音简称：</td>
            <td class="TableSpecial">
                &nbsp;<Epoint:TextBox ID="txtPinYinJc"  CssClass="inputtxt"  TextAlign="Left" runat="server" AllowNull="true"></Epoint:TextBox></td>
        </tr>
        <tr>
            <td align="right" class="TableSpecial1">
                排 序 值：</td>
            <td align="left" class="TableSpecial">
                &nbsp;<Epoint:NumericTextBox ID="txtOrderNumber" CssClass="inputtxt" TextAlign="left" runat="server"
                   >
                <NumericProperty ShowCharacter="false" MaxValue="10000" />
                </Epoint:NumericTextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtOrderNumber"
                    Display="Dynamic" ErrorMessage="无效数字" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator></td>
        </tr>
    </table>
    </ContentTemplate>
        </asp:UpdatePanel>
    <div style="width: 95%; line-height: 25px; margin-left: 20px;" id="divNote" runat="server">
        备注：代码项名称,代码项值不能重复。</div>
</asp:Content>
