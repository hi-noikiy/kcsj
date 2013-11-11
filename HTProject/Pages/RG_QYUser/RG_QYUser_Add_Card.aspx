<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYUser.RG_QYUser_Add_Card" Title="�������ݼ�¼" CodeBehind="RG_QYUser_Add_Card.aspx.cs" %>

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
                if (checkId1(sfzhm) != "���֤��֤ͨ��!") {
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
                "���֤��֤ͨ��!",
                "���֤����λ������!",
                "���֤����������ڳ�����Χ���зǷ��ַ�!",
                "���֤����У�����!",
                "���֤�����Ƿ�!"
                );
            var area = { 11: "����", 12: "���", 13: "�ӱ�", 14: "ɽ��", 15: "���ɹ�", 21: "����", 22: "����", 23: "������", 31: "�Ϻ�", 32: "����", 33: "�㽭", 34: "����", 35: "����", 36: "����", 37: "ɽ��", 41: "����", 42: "����", 43: "����", 44: "�㶫", 45: "����", 46: "����", 50: "����", 51: "�Ĵ�", 52: "����", 53: "����", 54: "����", 61: "����", 62: "����", 63: "�ຣ", 64: "����", 65: "�½�", 71: "̨��", 81: "���", 82: "����", 91: "����" }


            var idcard, Y, JYM;
            var S, M;
            var idcard_array = new Array();
            idcard_array = idcard.split("");
            //��������
            if (area[parseInt(idcard.substr(0, 2))] == null) return Errors[4];
            //��ݺ���λ������ʽ����
            switch (idcard.length) {
                case 15:
                    if ((parseInt(idcard.substr(6, 2)) + 1900) % 4 == 0 || ((parseInt(idcard.substr(6, 2)) + 1900) % 100 == 0 && (parseInt(idcard.substr(6, 2)) + 1900) % 4 == 0)) {
                        ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}$/; //���Գ������ڵĺϷ���
                    } else {
                        ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}$/; //���Գ������ڵĺϷ���
                    }
                    if (ereg.test(idcard)) return Errors[0];
                    else return Errors[2];
                    break;
                case 18:
                    //18λ��ݺ�����
                    //�������ڵĺϷ��Լ��
                    //��������:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))
                    //ƽ������:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))
                    if (parseInt(idcard.substr(6, 4)) % 4 == 0 || (parseInt(idcard.substr(6, 4)) % 100 == 0 && parseInt(idcard.substr(6, 4)) % 4 == 0)) {
                        ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}[0-9Xx]$/; //����������ڵĺϷ���������ʽ
                    } else {
                        ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}[0-9Xx]$/; //ƽ��������ڵĺϷ���������ʽ
                    }
                    if (ereg.test(idcard)) {//���Գ������ڵĺϷ���
                        //����У��λ
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
                        M = JYM.substr(Y, 1); //�ж�У��λ
                        if (M == idcard_array[17])
                            return Errors[0]; //���ID��У��λ
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
            if (document.all.GT2ICROCX.SexL == '��') {
                document.getElementById("<%=Sex_2019.ClientID%>").selectedIndex = 0;
            }
            else {
                document.getElementById("<%=Sex_2019.ClientID%>").selectedIndex = 1;
            }
            var birthdayShort = document.all.GT2ICROCX.Born;
            document.getElementById("<%=csrq_2019.ClientID%>").value = birthdayShort.substr(0, 4) + '-' + birthdayShort.substr(4, 2) + '-' + birthdayShort.substr(6, 2);
            document.getElementById("<%=IDNum_2019.ClientID%>").value = document.all.GT2ICROCX.CardNo;

            //����
            document.getElementById("<%=mz_2019.ClientID%>").value = document.all.GT2ICROCX.NationL;
            document.getElementById("<%=ryzz_2019.ClientID%>").value = document.all.GT2ICROCX.Address;
            document.getElementById("<%=fzjg_2019.ClientID%>").value = document.all.GT2ICROCX.Police;
            var ActivityLFromShort = document.all.GT2ICROCX.ActivityLFrom;
            document.getElementById("<%=sfzyxqs_2019.ClientID%>").value = ActivityLFromShort.substr(0, 4) + '-' + ActivityLFromShort.substr(4, 2) + '-' + ActivityLFromShort.substr(6, 2);
            var ActivityLToShort = document.all.GT2ICROCX.ActivityLTo;
            //var ActivityLToShort = "����";
            if (ActivityLToShort != "����") {
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

        function MyClearData()//OCX����ʧ�ܺ�Ļص�����
        {
            //alert('MyClearData');
            document.getElementById("<%=XM_2019.ClientID%>").value = "";
            document.getElementById("<%=csrq_2019.ClientID%>").value = ""
            document.getElementById("<%=IDNum_2019.ClientID%>").value = "";

            //����
            document.getElementById("<%=mz_2019.ClientID%>").value = "";
            document.getElementById("<%=ryzz_2019.ClientID%>").value = "";
            document.getElementById("<%=fzjg_2019.ClientID%>").value = "";
            document.getElementById("<%=sfzyxqs_2019.ClientID%>").value = "";
            document.getElementById("<%=sfzyxqz_2019.ClientID%>").value = "";

        }

        function MyGetErrMsg()//OCX������Ϣ�ص�����
        {
            //alert(document.all.GT2ICROCX.ErrMsg);
            document.all.Status.innerText = document.all.GT2ICROCX.ErrMsg;
        }

        function StartRead()//��ʼ����
        {
            //alert('StartRead');
            //alert(document.all.GT2ICROCX);
            //alert(document.all.GT2ICROCX.GetState());
            //document.all.GT2ICROCX.PhotoPath = "C:\Windows\Temp"
            //document.all.GT2ICROCX.Start() //ѭ������
            //���ζ���(���һ�ζ�һ��)
            if (document.all.GT2ICROCX.GetState() == 0) {
                alert("start");
                document.all.GT2ICROCX.ReadCard();
                alert("end");
                //���û��������в�ѯ��������
            }
        }

        function StartReadNoCheck()//��ʼ����
        {
            //alert('StartReadNoCheck');
            //document.all.GT2ICROCX.PhotoPath = "C:\Windows\Temp"
            //document.all.GT2ICROCX.Start() //ѭ������
            //���ζ���(���һ�ζ�һ��)
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
                            <epoint:Button ID="btnAdd" runat="server" Text="��ӱ���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnAdd_Click"></epoint:Button>
                        </td>
                        <td>
                            &nbsp;<input id="btnReadCard" style="height: 20" type="button" value="����" class="inputtxt"
                                onclick="StartRead();" />&nbsp;
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="ȡ�����" runat="server" CausesValidation="false" OnClientClick="window.close();">
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
                                    <span style="color: Red">��Ա������Ϣ�������֤��Ϣ����һ��</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XM_2019" runat="server" MaxLength="50" AllowNull="false" contenteditable="false"></epoint:TextBox>
                                </td>
                                <td rowspan="5" class="TableSpecial1" width="15%">
                                    ��Ƭ
                                </td>
                                <td rowspan="5" class="TableSpecial" width="35%" height="26" align="left">
                                    <object name="GT2ICROCX" width="102" height="126" classid="CLSID:220C3AD1-5E9D-4B06-870F-E34662E2DFEA"
                                        codebase="IdrOcx.cab#version=1,0,1,2">
                                    </object>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ա�:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="Sex_2019" runat="server" Width="132" Enabled="false">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ֤������:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="IDNum_2019" runat="server" MaxLength="50" AllowNull="false" Width="80%"
                                        contenteditable="false" onBlur="customFieldCalculate(this.form, this);"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="mz_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��������:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="csrq_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" ClearImageVisible="false" SelectImageVisible="false" Width="120px"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    סַ:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ryzz_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��֤����:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="fzjg_2019" runat="server" MaxLength="100" Width="80%" AllowNull="false"
                                        contenteditable="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ���֤��Ч��ʼ:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="sfzyxqs_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" Width="120px" ClearImageVisible="false" SelectImageVisible="false"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ���֤��Ч��ֹ:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="sfzyxqz_2019" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" Width="120px"></epoint:DateTextBox><span style="color: Red">���ǳ��ڣ���ͳһ����Ч�ڿ�ʼʱ��<br />
                                            �Ļ����ϼ�50��</span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    ״̬
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
                                    ɾ��״̬
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
