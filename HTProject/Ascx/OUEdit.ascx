<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OUEdit.ascx.cs" Inherits="HTProject.Ascx.OUEdit" %>

<script type="text/javascript">
    function winto(url) {
        this.location = url;
    }
</script>

<div id="Div1" style="width: 100%; float: left" class="PlaceHolder_PartStyle">
    <div class="PageBg" style="left: 200px; position: absolute; width: 640px; height: 480px;
        display: none; background-color: Cornsilk; background-position: center;" id="divContent"
        runat="server" onclick="HidDivContent();">
    </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="PlaceHolder_3_1" style="height: 19px">
            </td>
            <td class="PlaceHolder_3_bg" style="height: 19px" colspan="3">
            </td>
            <td class="PlaceHolder_3_2" style="height: 19px">
            </td>
        </tr>
        <tr>
            <td class="PlaceHolder_2_1" valign="bottom" style="height: 2px">
                <span class="PlaceHolder_2"></span>
            </td>
            <td class="PlaceHolder_2_bg" id="OE" valign="middle" align="center" runat="server" style="height: 200px;
                width: 45%; background-color: #D1E6FA; cursor: pointer" title="企业信息" >
                <table style="text-align: center; width: 100%; height: 100%;">
                    <tr style="cursor: pointer; background-color: #A1E6FB; height: 50px;">
                        <td style="background-image: url(Pages/images/营业执照.JPG); background-repeat: no-repeat;
                            background-position: center;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <img src="../Images/BigIcon/home.gif" /><br />
                                <asp:Label ID="lblQYEditMessage" runat="server" Text="企业信息修改"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="PlaceHolder_2_2" valign="bottom" style="height: 2px">
                <span class="PlaceHolder_3"></span>
            </td>
            <td class="PlaceHolder_2_bg" id="UE" valign="middle" align="center" style="height: 200px;
                width: 45%; background-color: #D1E6FA;" title="企业人员信息">
                <table style="text-align: center; width: 100%; height: 100%;">
                    <tr onclick="winto('Pages/RG_QYUser/RG_QYUser_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>',800,700)"
                        style="cursor: pointer; background-color: #A1E6FB; height: 50px;">
                        <td colspan="3" style="background-image: url(Pages/images/职业资格证书.JPG); background-repeat: no-repeat;
                            background-position: center;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%;">
                            <div style="cursor: pointer;" onclick="winto('Pages/RG_QYUser/RG_QYUser_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>')">
                                <img src="../Images/BigIcon/meiti.gif" /><br />
                                查看所有人员
                            </div>
                        </td>
                        <td style="background-color: #A1E6FB;">
                        </td>
                        <td style="width: 49%" title="未提交及被退回人员">
                            <div style="cursor: pointer;" onclick="winto('Pages/RG_QYUser/RG_QYUser_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>&Status=60,80')">
                                <img src="../Images/BigIcon/meiti.gif" /><br />
                                未提交或被退回人员<asp:Label ID="lblNoPassRYCount" runat="server" 
                                    ForeColor="Red"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="PlaceHolder_2_2" valign="bottom" style="height: 2px">
                <span class="PlaceHolder_3"></span>
            </td>
        </tr>
        <tr>
            <td class="PlaceHolder_3_1" style="height: 19px">
            </td>
            <td class="PlaceHolder_3_bg" style="height: 19px" colspan="3">
            </td>
            <td class="PlaceHolder_3_2" style="height: 19px">
            </td>
        </tr>
        <tr>
            <td class="PlaceHolder_2_1" valign="bottom" style="height: 2px">
                <span class="PlaceHolder_2"></span>
            </td>
            <td class="PlaceHolder_2_bg" id="Td1" valign="middle" align="center" style="height: 200px;
                width: 45%; background-color: #D1E6FA; cursor: pointer" title="企业资质信息">
                <table style="text-align: center; width: 100%; height: 100%;">
                    <tr onclick="winto('Pages/RG_QYZiZhi/RG_QYZiZhi_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>',800,700)"
                        style="cursor: pointer; background-color: #A1E6FB; height: 50px;">
                        <td colspan="3" style="background-image: url(Pages/images/资质证书.JPG); background-repeat: no-repeat;
                            background-position: center;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%;">
                            <div style="cursor: pointer;" onclick="winto('Pages/RG_QYZiZhi/RG_QYZiZhi_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>')">
                                <img src="../Images/BigIcon/meiti.gif" /><br />
                                查看所有资质
                            
                            </div>
                        </td>
                        <td style="background-color: #A1E6FB;">
                        </td>
                        <td style="width: 49%" title="未提交及被退回资质">
                            <div style="cursor: pointer;" onclick="winto('Pages/RG_QYZiZhi/RG_QYZiZhi_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>&Status=60,80')">
                                <img src="../Images/BigIcon/meiti.gif" /><br />
                                未提交或被退回资质<asp:Label ID="lblQYZZCount" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="PlaceHolder_2_2" valign="bottom" style="height: 2px">
                <span class="PlaceHolder_3"></span>
            </td>
            <td class="PlaceHolder_2_bg" id="Td2" valign="middle" align="center" style="height: 200px;
                width: 45%; background-color: #D1E6FA;" title="项目备案信息">
                <table style="text-align: center; width: 100%; height: 100%;">
                    <tr onclick="winto('Pages/RG_XMBeiAn/RG_XMBeiAn_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>',800,700)"
                        style="cursor: pointer; background-color: #A1E6FB; height: 50px; vertical-align: middle;">
                        <td colspan="3">
                            <span style="background-color: White; font-size: 40; height: 100%; vertical-align: middle;
                                text-align: center; width: 350px;">项 目 备 案 信 息</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%;">
                            <div style="cursor: pointer;" onclick="winto('Pages/RG_XMBeiAn/RG_XMBeiAn_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>')">
                                <img src="../Images/BigIcon/meiti.gif" /><br />
                                查看所有备案
                            </div>
                        </td>
                        <td style="background-color: #A1E6FB;">
                        </td>
                        <td style="width: 49%" title="未提交及被退回备案">
                            <div style="cursor: pointer;" onclick="winto('Pages/RG_XMBeiAn/RG_XMBeiAn_List.aspx?DWGuid=<%=ViewState["DWGuid"].ToString() %>&Status=60,80')">
                                <img src="../Images/BigIcon/meiti.gif" /><br />
                                未提交或被退回备案<asp:Label ID="lblBACount" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="PlaceHolder_2_2" valign="bottom" style="height: 2px">
                <span class="PlaceHolder_3"></span>
            </td>
        </tr>
        <tr>
            <td class="PlaceHolder_3_1" style="height: 19px">
            </td>
            <td class="PlaceHolder_3_bg" style="height: 19px" colspan="3">
            </td>
            <td class="PlaceHolder_3_2" style="height: 19px">
            </td>
        </tr>
    </table>
</div>
