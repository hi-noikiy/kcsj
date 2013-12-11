<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYUser.RG_QYUser_Edit_Card" Title="修改数据记录" CodeBehind="RG_QYUser_Edit_Card.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
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
            document.all.Status.innerText = document.all.GT2ICROCX.ErrMsg;
        }

        function StartRead()//开始读卡
        {
            //alert('StartRead');
            //document.all.GT2ICROCX.PhotoPath = "C:\Windows\Temp"
            //document.all.GT2ICROCX.Start() //循环读卡
            //单次读卡(点击一次读一次)
            if (document.all.GT2ICROCX.GetState() == 0) {
                document.all.GT2ICROCX.ReadCard();
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

    <script language="javascript" for="GT2ICROCX" event="GetData">
	    MyGetData()
    </script>

    <script language="javascript" for="GT2ICROCX" event="GetErrMsg">
	    MyGetErrMsg()
    </script>

    <script language="javascript" for="GT2ICROCX" event="ClearData">
	    MyClearData()
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
                                    <span style="color: Red">需要审核人员信息、上传的附件与所提供的原件是否一致，如不一致需做好记录后统一提供给总办，然后进行身份证扫描并保存。<br />
                                    如是通过读取身份证新增的人员，只需在身份证扫描后保存即可。</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    姓名:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XM_2019" runat="server" MaxLength="50" AllowNull="false" contenteditable="false"></epoint:TextBox>
                                </td>
                                <td rowspan="5" class="TableSpecial1" width="15%">
                                    照片
                                </td>
                                <td rowspan="5" class="TableSpecial" width="35%" height="26" align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <%--<div id="image_View" height="120px" width="100px" runat="server">
                                                            </div>--%>
                                                            <img style='height: 126px' src='RetrieveImageData.aspx?RowGuid=<%=Request["RowGuid"] %>'/>
                                                        </td>
                                                        <td>
                                                            <object name="GT2ICROCX" width="102" height="126" classid="CLSID:220C3AD1-5E9D-4B06-870F-E34662E2DFEA"
                                                                codebase="IdrOcx.cab#version=1,0,1,2">
                                                            </object>
                                                            <div name="Status" id="Status">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
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
                                    证件号码:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="IDNum_2019" runat="server" MaxLength="50" AllowNull="false" Width="80%"
                                        onBlur="customFieldCalculate(this.form, this);" contenteditable="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    民族:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="mz_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    出生日期:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="csrq_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" Width="100px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    住址:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ryzz_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    发证机关:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="fzjg_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    身份证有效期始:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="sfzyxqs_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" Width="100px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    身份证有效期止:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="sfzyxqz_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" Width="100px"></epoint:DateTextBox><span style="color: Red">如是长期，请统一在有效期开始时间<br />
                                            的基础上加50年</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    勘察设计工龄:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="GongLing_2019" runat="server" contenteditable="false" Width="80%"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    所学专业:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ZhuanYe_2019" runat="server" MaxLength="50" contenteditable="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    学历:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="XueLi_2019" runat="server" Width="80%" Height="50%" Enabled="false">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    毕业时间:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="BiYeDate_2019" runat="server" InputDateType="Select"
                                        Character="HX" Width="120px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    毕业院校:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="BiYeXueXiao_2019" runat="server" MaxLength="100" Width="80%" contenteditable="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    从事专业及注册专业:
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextTreeView ID="RegionTreeView" runat="server" DivHeight="250px" RelationName="所有专业"
                                        DivWidth="300px" ImgFolds="../../../Images/TreeImages" ClearImageVisible="false" SelectImageVisible="false"
                                        RootNodeText="专业选择" TextCssClass="Inputtxt" Width="500px" OnlyReturnLeaf="true"
                                        InputType="CheckBox" SelectItemMax="3" MultiSelect="true">
                                    </epoint:TextTreeView>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    执业印章号1:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YinZhangNo_2019" runat="server" MaxLength="50" Width="80%" contenteditable="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    注册章1有效期:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ZCZ_YXQ_2019" runat="server" InputDateType="Select"
                                        Character="HX" Width="120px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    执业印章号2:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YinZhangNo1_2019" runat="server" MaxLength="50" Width="80%" contenteditable="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    注册章2有效期:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ZCZ_YXQ1_2019" runat="server" InputDateType="Select"
                                        Character="HX" Width="120px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    执业印章号3:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YinZhangNo2_2019" runat="server" MaxLength="50" Width="80%" contenteditable="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    注册章3有效期:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ZCZ_YXQ2_2019" runat="server" InputDateType="Select"
                                        Character="HX" Width="120px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                
                                <td class="TableSpecial1" width="15%">
                                    职称:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ZhiCheng_2019" runat="server" Width="50%" Height="100%" Enabled="false">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    聘用合同号:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="HeTongNo_2019" runat="server" MaxLength="50" Width="80%" contenteditable="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    合同截止时间:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="HeTongEndDate_2019" runat="server" InputDateType="Select"
                                        Character="HX" Width="120px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    相关附件
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3">
                                    <uc1:FJ ID="RY_SFZ" runat="server" ClientTag="身份证件" MaxAttachCount="2" ReadOnly="true"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="RY_BYZ" runat="server" ClientTag="毕业证" MaxAttachCount="5" ReadOnly="true"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="RY_ZCZJ" runat="server" ClientTag="注册证件" MaxAttachCount="5" ReadOnly="true"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="RY_ZhiCheng" runat="server" ClientTag="职称证" MaxAttachCount="5" ReadOnly="true"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="RY_LDHT" runat="server" ClientTag="劳动合同" MaxAttachCount="5" ReadOnly="true"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="RY_GRQM" runat="server" ClientTag="个人签名" MaxAttachCount="1" ReadOnly="true"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="RY_GRQT" runat="server" ClientTag="其他" ReadOnly="true"></uc1:FJ>
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
