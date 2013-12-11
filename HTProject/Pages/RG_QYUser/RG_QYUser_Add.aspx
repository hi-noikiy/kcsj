<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYUser.RG_QYUser_Add" Title="�������ݼ�¼" CodeBehind="RG_QYUser_Add.aspx.cs" %>

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
                                OnClick="btnAdd_Click" CausesValidation="false"></epoint:Button>
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
                                <span style="color:Red">��Ա������Ϣ�������֤��Ϣ����һ��</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XM_2019" runat="server" MaxLength="50" AllowNull="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    �Ա�:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="Sex_2019" runat="server" Width="132">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ֤������:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="IDType_2019" runat="server" Width="80%" Height="50%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ֤������:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="IDNum_2019" runat="server" MaxLength="50" AllowNull="false" Width="80%"  onBlur="customFieldCalculate(this.form, this);"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ������ƹ���:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="GongLing_2019" runat="server" AllowNull="false" Width="80%"><NumericProperty TextBoxType=Int /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ѧרҵ:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ZhuanYe_2019" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%"></epoint:TextBox><span style="color: Red">���ҵ֤��רҵһ��,���ж��������/����</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ѧ��:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="XueLi_2019" runat="server" Width="80%" Height="50%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ҵʱ��:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="BiYeDate_2019" runat="server" InputDateType="Input" Character="HX"
                                        Width="120px"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ҵԺУ:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="BiYeXueXiao_2019" runat="server" MaxLength="100" Width="80%"></epoint:TextBox>
                                    <br />
                                    <span style="color: Red">����ѧרҵ˳�򱣳�һ��,���ж��������/����</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����רҵ��ע��רҵ:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextTreeView ID="RegionTreeView" runat="server" DivHeight="250px" RelationName="����רҵ"
                                        DivWidth="300px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="רҵѡ��" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                        InputType="CheckBox" AllowNull="false" SelectItemMax="3" MultiSelect="true">
                                    </epoint:TextTreeView>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ִҵӡ�º�1:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YinZhangNo_2019" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ע����1��Ч��:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ZCZ_YXQ_2019" runat="server" InputDateType="Select"
                                        Character="HX" Width="120px"></epoint:DateTextBox><span style="color:Red">����ִҵӡ�£��ɲ���д</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ִҵӡ�º�2:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YinZhangNo1_2019" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ע����2��Ч��:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ZCZ_YXQ1_2019" runat="server" InputDateType="Select"
                                        Character="HX" Width="120px"></epoint:DateTextBox><span style="color:Red">����ִҵӡ�£��ɲ���д</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ִҵӡ�º�3:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YinZhangNo2_2019" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ע����3��Ч��:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ZCZ_YXQ2_2019" runat="server" InputDateType="Select"
                                        Character="HX" Width="120px"></epoint:DateTextBox><span style="color:Red">����ִҵӡ�£��ɲ���д</span>
                                </td>
                            </tr>
                            <tr>
                                
                                <td class="TableSpecial1" width="15%">
                                    ְ��:
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ZhiCheng_2019" runat="server" Width="50%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    Ƹ�ú�ͬ��:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="HeTongNo_2019" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ͬ��ֹʱ��:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="HeTongEndDate_2019" runat="server" InputDateType="Select" AllowNull="false"
                                        Character="HX" Width="120px"></epoint:DateTextBox><span style="color:Red">���ǳ��ڣ���ͳһ�ں�ͬǩ��ʱ��<br />�Ļ����ϼ�50��</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    סַ:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ryzz_2019" runat="server" MaxLength="100" Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��֤����:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="fzjg_2019" runat="server" MaxLength="100" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="mz_2019" runat="server" MaxLength="100" Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��������:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="csrq_2019" runat="server" InputDateType="Input" Character="HX"
                                        Width="120px"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ���֤��Ч��ʼ:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="sfzyxqs_2019" runat="server" InputDateType="Input" Character="HX"
                                        Width="120px"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ���֤��Ч��ֹ:<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="sfzyxqz_2019" runat="server" InputDateType="Input" Character="HX"
                                        Width="120px"></epoint:DateTextBox><span style="color:Red">���ǳ��ڣ���ͳһ����Ч�ڿ�ʼʱ��<br />�Ļ����ϼ�50��</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ظ���
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3">
                                    ���ڱ������Ӹ���
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
                                    <asp:Button ID="btID" runat="server" OnClick="btID_Click" CausesValidation="false"/>
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
