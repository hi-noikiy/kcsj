<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYUser.RG_QYUser_Add_Card" Title="新增数据记录" CodeBehind="RG_QYUser_Add_Card.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script type="text/JavaScript" src="../IDCard.js"></script>

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
        function customFieldCalculate(form, gmsfzhm) {
            var sfzhm = gmsfzhm.value;
            if (sfzhm != "") {
                sfzhm = sfzhm.replace("x", "X");
                if (checkId1(sfzhm) != "身份证验证通过!") {
                    alert(checkId1(sfzhm));
                    document.getElementById("<%=IDNum_2019.ClientID%>").value = "";
                }
                else {
                    document.getElementById("<%=btID.ClientID%>").click();
                }
            }
        }

        function checkId1(idcard) {

            var Errors = new Array(
                "身份证验证通过!",
                "身份证号码位数不对!",
                "身份证号码出生日期超出范围或含有非法字符!",
                "身份证号码校验错误!",
                "身份证地区非法!"
                );
            var area = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外" }


            var idcard, Y, JYM;
            var S, M;
            var idcard_array = new Array();
            idcard_array = idcard.split("");
            //地区检验
            if (area[parseInt(idcard.substr(0, 2))] == null) return Errors[4];
            //身份号码位数及格式检验
            switch (idcard.length) {
                case 15:
                    if ((parseInt(idcard.substr(6, 2)) + 1900) % 4 == 0 || ((parseInt(idcard.substr(6, 2)) + 1900) % 100 == 0 && (parseInt(idcard.substr(6, 2)) + 1900) % 4 == 0)) {
                        ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}$/; //测试出生日期的合法性
                    } else {
                        ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}$/; //测试出生日期的合法性
                    }
                    if (ereg.test(idcard)) return Errors[0];
                    else return Errors[2];
                    break;
                case 18:
                    //18位身份号码检测
                    //出生日期的合法性检查
                    //闰年月日:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))
                    //平年月日:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))
                    if (parseInt(idcard.substr(6, 4)) % 4 == 0 || (parseInt(idcard.substr(6, 4)) % 100 == 0 && parseInt(idcard.substr(6, 4)) % 4 == 0)) {
                        ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}[0-9Xx]$/; //闰年出生日期的合法性正则表达式
                    } else {
                        ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}[0-9Xx]$/; //平年出生日期的合法性正则表达式
                    }
                    if (ereg.test(idcard)) {//测试出生日期的合法性
                        //计算校验位
                        S = (parseInt(idcard_array[0]) + parseInt(idcard_array[10])) * 7
                + (parseInt(idcard_array[1]) + parseInt(idcard_array[11])) * 9
                + (parseInt(idcard_array[2]) + parseInt(idcard_array[12])) * 10
                + (parseInt(idcard_array[3]) + parseInt(idcard_array[13])) * 5
                + (parseInt(idcard_array[4]) + parseInt(idcard_array[14])) * 8
                + (parseInt(idcard_array[5]) + parseInt(idcard_array[15])) * 4
                + (parseInt(idcard_array[6]) + parseInt(idcard_array[16])) * 2
                + parseInt(idcard_array[7]) * 1
                + parseInt(idcard_array[8]) * 6
                + parseInt(idcard_array[9]) * 3;
                        Y = S % 11;
                        M = "F";
                        JYM = "10X98765432";
                        M = JYM.substr(Y, 1); //判断校验位
                        if (M == idcard_array[17])
                            return Errors[0]; //检测ID的校验位
                        else
                            return Errors[3];
                    }
                    else return Errors[2];
                    break;
                default:
                    return Errors[1];
                    break;
            }

        }
    </script>

    <script type="text/javascript">
        function MyGetData() {
            //alert('MyGetData');
            //alert(document.getElementById("<%=Sex_2019.ClientID%>").selectedIndex);
            //alert(document.all.GT2ICROCX.SexL);
            document.getElementById("<%=XM_2019.ClientID%>").value = document.all.GT2ICROCX.NameL;
            if (document.all.GT2ICROCX.SexL == '男') {
                document.getElementById("<%=Sex_2019.ClientID%>").selectedIndex = 0;
            }
            else {
                document.getElementById("<%=Sex_2019.ClientID%>").selectedIndex = 1;
            }
            var birthdayShort = document.all.GT2ICROCX.Born;
            document.getElementById("<%=csrq_2019.ClientID%>").value = birthdayShort.substr(0, 4) + '-' + birthdayShort.substr(4, 2) + '-' + birthdayShort.substr(6, 2);
            document.getElementById("<%=IDNum_2019.ClientID%>").value = document.all.GT2ICROCX.CardNo;

            //补充
            document.getElementById("<%=mz_2019.ClientID%>").value = document.all.GT2ICROCX.NationL;
            document.getElementById("<%=ryzz_2019.ClientID%>").value = document.all.GT2ICROCX.Address;
            document.getElementById("<%=fzjg_2019.ClientID%>").value = document.all.GT2ICROCX.Police;
            var ActivityLFromShort = document.all.GT2ICROCX.ActivityLFrom;
            document.getElementById("<%=sfzyxqs_2019.ClientID%>").value = ActivityLFromShort.substr(0, 4) + '-' + ActivityLFromShort.substr(4, 2) + '-' + ActivityLFromShort.substr(6, 2);
            var ActivityLToShort = document.all.GT2ICROCX.ActivityLTo;
            //var ActivityLToShort = "长期";
            if (ActivityLToShort != "长期") {
                document.getElementById("<%=sfzyxqz_2019.ClientID%>").value = ActivityLToShort.substr(0, 4) + '-' + ActivityLToShort.substr(4, 2) + '-' + ActivityLToShort.substr(6, 2);
            }
            else {
                document.getElementById("<%=sfzyxqz_2019.ClientID%>").value = "";
            }

            //photo.value = document.all.GT2ICROCX.GetPhotoBuffer();
            //jpgPhotoFace1.value = document.all.GT2ICROCX.GetFaceJpgBase64(1);
            //jpgPhotoFace2.value = document.all.GT2ICROCX.GetFaceJpgBase64(2);
            //document.getElementById("<%=cardJPG.ClientID%>").value = document.all.GT2ICROCX.GetFaceJpgBase64(2);
            document.getElementById("<%=cardJPG.ClientID%>").value = document.all.GT2ICROCX.GetPhotoBuffer();
        }

        function MyClearData()//OCX读卡失败后的回调函数
        {
            //alert('MyClearData');
            document.getElementById("<%=XM_2019.ClientID%>").value = "";
            document.getElementById("<%=csrq_2019.ClientID%>").value = ""
            document.getElementById("<%=IDNum_2019.ClientID%>").value = "";

            //补充
            document.getElementById("<%=mz_2019.ClientID%>").value = "";
            document.getElementById("<%=ryzz_2019.ClientID%>").value = "";
            document.getElementById("<%=fzjg_2019.ClientID%>").value = "";
            document.getElementById("<%=sfzyxqs_2019.ClientID%>").value = "";
            document.getElementById("<%=sfzyxqz_2019.ClientID%>").value = "";

        }

        function MyGetErrMsg()//OCX读卡消息回调函数
        {
            //alert(document.all.GT2ICROCX.ErrMsg);
            document.all.Status.innerText = document.all.GT2ICROCX.ErrMsg;
        }

        function StartRead()//开始读卡
        {
            //alert('StartRead');
            //alert(document.all.GT2ICROCX);
            //alert(document.all.GT2ICROCX.GetState());
            //document.all.GT2ICROCX.PhotoPath = "C:\Windows\Temp"
            //document.all.GT2ICROCX.Start() //循环读卡
            //单次读卡(点击一次读一次)
            if (document.all.GT2ICROCX.GetState() == 0) {
                alert("start");
                document.all.GT2ICROCX.ReadCard();
                alert("end");
                //从用户基本表中查询已有数据
            }
        }

        function StartReadNoCheck()//开始读卡
        {
            //alert('StartReadNoCheck');
            //document.all.GT2ICROCX.PhotoPath = "C:\Windows\Temp"
            //document.all.GT2ICROCX.Start() //循环读卡
            //单次读卡(点击一次读一次)
            if (document.all.GT2ICROCX.GetState() == 0) {
                document.all.GT2ICROCX.ReadCard();
            }
        }

    </script>

    <script type="text/javascript" language="javascript" for="GT2ICROCX" event="GetData">
    //alert('GetData');
	    MyGetData();
    </script>

    <script language="javascript" for="GT2ICROCX" event="GetErrMsg">
    //alert('GetErrMsg');
	    MyGetErrMsg();
    </script>

    <script language="javascript" for="GT2ICROCX" event="ClearData">
        //alert('ClearData');
	    MyClearData();
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
                                OnClick="btnAdd_Click"></epoint:Button>
                        </td>
                        <td>
                            &nbsp;<input id="btnReadCard" style="height: 20" type="button" value="读卡" class="inputtxt"
                                onclick="StartRead();" />&nbsp;
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
                <tr>
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x;"
                        align="center" valign="middle">
                        <%=ViewState["TableName"]%>
                    </td>
                </tr>
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center">
                            <tr>
                                <td colspan="4">
                                    <span style="color: Red">人员基本信息请与身份证信息保持一致</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    姓名:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XM_2019" runat="server" MaxLength="50" AllowNull="false" contenteditable="false"></epoint:TextBox>
                                </td>
                                <td rowspan="5" class="TableSpecial1" width="15%">
                                    照片
                                </td>
                                <td rowspan="5" class="TableSpecial" width="35%" height="26" align="left">
                                    <object name="GT2ICROCX" width="102" height="126" classid="CLSID:220C3AD1-5E9D-4B06-870F-E34662E2DFEA"
                                        codebase="IdrOcx.cab#version=1,0,1,2">
                                    </object>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    性别:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="Sex_2019" runat="server" Width="132" Enabled="false">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    证件号码:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="IDNum_2019" runat="server" MaxLength="50" AllowNull="false" Width="80%"
                                        contenteditable="false" onBlur="customFieldCalculate(this.form, this);"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    民族:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="mz_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    出生日期:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="csrq_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" ClearImageVisible="false" SelectImageVisible="false" Width="120px"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    住址:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ryzz_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    发证机关:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="fzjg_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    身份证有效期始:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="sfzyxqs_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" Width="120px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    身份证有效期止:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="sfzyxqz_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" Width="120px"></epoint:DateTextBox><span style="color: Red">如是长期，请统一在有效期开始时间<br />
                                            的基础上加50年</span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    状态
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="Status_2019" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                    <epoint:TextBox ID="DWGuid_2019" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="cardJPG" runat="server"></epoint:TextBox>
                                    <epoint:TextBox ID="CardIMG_2019" runat="server"></epoint:TextBox>
                                    <epoint:TextBox ID="CardImgType_2019" runat="server"></epoint:TextBox>
                                    <asp:DropDownList ID="IDType_2019" runat="server" Width="80%" Height="50%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    删除状态
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="DelStatus_2019" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                    <epoint:TextBox ID="ZhuanYeCSCode_2019" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="ZhuanYeCS_2019" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                    <epoint:TextBox ID="ZuZhiJGDM_2019" runat="server" Width="80%"></epoint:TextBox>
                                    <asp:Button ID="btID" runat="server" OnClick="btID_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                ShowMessageBox="True"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
