<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZZCheck.ascx.cs" Inherits="HTProject.Ascx.ZZCheck" %>

<script type="text/javascript">
    function winto(url) {
        this.location = url;
    }
</script>

<div id="Div1" style="width: 100%; float: left" class="PlaceHolder_PartStyle">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="PlaceHolder_3_1" style="height: 19px">
            </td>
            <td class="PlaceHolder_3_bg" style="height: 19px">
            </td>
            <td class="PlaceHolder_3_2" style="height: 19px">
            </td>
        </tr>
        <tr>
            <td class="PlaceHolder_2_1" valign="bottom" style="height: 2px">
                <span class="PlaceHolder_2"></span>
            </td>
            <td class="PlaceHolder_2_bg" id="OE" valign="middle" align="center" style="height: 200px;
                background-color: #D1E6FA;" >
                <table style="text-align: center; width: 100%; height:100%; ">
                    <tr>
                        <td style="width: 49%;">
                            <div style=" cursor: pointer" onclick="winto('<%=Epoint.Frame.Bizlogic.common.GetApplicationPath() %>/HTProject/Pages/RG_QYZiZhi/RG_QYZiZhiAD_List.aspx')">
                                <img src="../Images/ModuleImages/BigIcon/network.gif" /><br />
                                <asp:Label ID="Label1" runat="server">查看所有资质</asp:Label>
                            </div>
                        </td>
                        <td style="background-color: #A1E6FB;">&nbsp;
                        </td>
                        <td style="width: 49%;">
                            <div style=" cursor: pointer" onclick="winto('<%=Epoint.Frame.Bizlogic.common.GetApplicationPath() %>/HTProject/Pages/WaitBL/WaitHandle_NeedHandle_Banli.aspx?pType=审核企业资质')">
                                <img src="../Images/ModuleImages/BigIcon/network.gif" /><br />
                                <asp:Label ID="lblNeedCount" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="PlaceHolder_2_2" valign="bottom" style="height: 2px">
                <span class="PlaceHolder_3">
                    <input type="hidden" runat="server" id="hiID" value="审核企业资质" /></span>
            </td>
        </tr>
        <tr>
            <td class="PlaceHolder_3_1" style="height: 19px">
            </td>
            <td class="PlaceHolder_3_bg" style="height: 19px">
            </td>
            <td class="PlaceHolder_3_2" style="height: 19px">
            </td>
        </tr>
    </table>
</div>
