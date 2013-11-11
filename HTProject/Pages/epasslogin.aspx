<%@ Page Language="c#" CodeBehind="ePasslogin.aspx.cs" AutoEventWireup="True" Inherits="WuxiJSJMis.ePasslogin"
    EnableViewState="false" %>

<html>
<head id="Head1" runat="server">
    <title>登录到<%=ViewState["Title"] %></title>
    <link href="Images/User_Login.css" type="text/css" rel="stylesheet">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <style type="text/css">
        .SYS
        {
        }
    </style>
    <meta content="MSHTML 6.00.6000.16809" name="GENERATOR">
</head>
<body id="userlogin_body">
    <form id="ValidForm" method='post' action='ePassVerify.aspx' onsubmit='return Validate();'
    language='jscript'>
    <input type="hidden" value="login" name="action">
    <input id="logintype" type="hidden" name="logintype">

    <script language="javascript">
        function onChgAuth() {
            var imgsrc = document.getElementById("imgauthcode");
            imgsrc.src = "authcode.php?rnd=" + Math.random();
        }
        function doLogin() {
            if (!checkData()) return false;
            checkLoginType();
            document.getElementById("theform").submit();
        }
        function doEnterKey() {
            if (event.keyCode == 13) {
                doLogin();
            }
        }
        function checkLoginType() {
            var acct = document.getElementById("account").value;
            var emailRe = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            if (emailRe.test(acct)) {
                document.getElementById("logintype").value = "email";
            } else {
                document.getElementById("logintype").value = "username";
            }
        }
        
       

    </script>

    <script type="text/javascript">
        var FirstDigest;
        var Digest = "01234567890123456";

        function Validate() {
            Digest = "01234567890123456";
            var TheForm;
            TheForm = document.forms["ValidForm"];
            if (TheForm.UserPIN.value.length < 1) {
                alert("密码不能为空!");
                return false;
            }
            //alert("1.加载ePassND安全控件");
            try {
                document.all.ePass.GetLibVersion();
            }
            catch (err) {
                if (err.number == '&H1B6') {
                    alert("加载ePassND安全控件");
                }
                return false;
            }
            //alert("2.打开第一个ePassND");
            try {
                document.all.ePass.OpenDevice(1, "");
            }
            catch (err) {
                alert('请插入USBKEY.');
                return false;
            }
            var results;
            results = "01234567890123456";
            results = document.all.ePass.GetStrProperty(7, 0, 0);
            //alert(results);
            //alert("3.用户PIN码认证");
            //            try {
            //                document.all.ePass.VerifyPIN(0, TheForm.UserPIN.value);
            //            }
            //            catch (err) {
            //                alert('用户PIN码认证失败!!!');
            //                document.all.ePass.CloseDevice();
            //                return false;
            //            }
            //alert("4.打开第一个密码文件证");
            try {
                document.all.ePass.OpenFile(0, 1);
            }
            catch (err) {
                alert('打开第一个密码文件失败!');
                document.all.ePass.CloseDevice();
                return false;
            }
            //alert("5.HashToken compute");
            //            try {
            //                Digest = document.all.ePass.HashToken(1, 2, '<%=Session["Message"].ToString()%>');
            //            }
            //            catch (err) {
            //                alert('HashToken compute!');
            //                document.all.ePass.CloseDevice();
            //                return false;
            //            }
            //DigestID.innerHTML = "<input type='hidden' name='Digest' Value='" + Digest + "'>";
            snID.innerHTML = "<input type='hidden' name='SN_SERAL' Value='" + results + "'>";
            var PassWord = TheForm.UserPIN.value;
            //alert(Digest + '|*|' + results);
            //alert("6.CloseDevice");
            try {
                document.all.ePass.CloseDevice();
                window.location = "ePassVerify.aspx?SN_SERAL=" + results + "&PassWord=" + PassWord; //"&Digest=" + Digest
            }
            catch (err) {
                alert(err.message);
            }
        }

    </script>

    <div style="position: absolute; width: 260px; height: 42px; z-index: 1; left: 10px;
        top: 400px" id="Div1">
        提示:<br>
        &nbsp;&nbsp;&nbsp; 使用加密锁需要安装加密锁Active安全插件,如果您的浏览器禁止安装Active插件,您可以<font color="RED"><a
            href="epass.rar"><font color="RED">下载加密锁插件</font></a></font>到本地硬盘进行安装。<br />
        点击下载<font color="RED"><a href="无锡市建设工程勘察设计合同备案管理系统用户操作手册.rar"><font color="RED">《用户操作手册》。</font></a></font>
    </div>
    <object id="Object1" name="ePass" style="z-index: 101; left: 488px; position: absolute;
        top: 408px" height="1" width="1" classid="clsid:E1D396DC-D064-4846-8B50-A3301BDD6243"
        codebase="includes/install.cab#Version=1,00,0000">
    </object>
    <span id="DigestID"></span><span id="snID"></span>
    <div id="panSiteFactory" style="text-align: center">
        <div id="siteFactoryLogin">
            <div id="sysname" style='font-size: 32pt; color: White; font-family: 新宋体; vertical-align: middle;
                text-align: center;'>
                <asp:Label ID="lblSysName" runat="server"></asp:Label></div>
            <div id="user_login">
                <%--<dl style='font-size: 28pt; color: black; font-family: 新宋体;vertical-align:middle;'>
                    </dl>--%>
                <dl>
                    <dd id="user_top">
                        <ul>
                            <li class="user_top_l">
                                <%--<asp:ImageButton ID="LoginSys" runat="server" OnClick="LoginSys_Click" Style="display: none" /></li>--%>
                                <li class="user_top_c"></li>
                                <li class="user_top_r"></li>
                        </ul>
                        <dd id="user_main">
                            <ul>
                                <li class="user_main_l"></li>
                                <li class="user_main_c">
                                    <div class="user_main_box">
                                        <ul>
                                            <li class="user_main_text"></li>
                                            <li class="user_main_input"></li>
                                        </ul>
                                        <ul>
                                            <li class="user_main_text">用户密码： </li>
                                            <li class="user_main_input">
                                                <input class="TxtPasswordCssClass" id="UserPIN" type="password" name="UserPIN" runat="server"
                                                    style="width: 200px;" />
                                            </li>
                                        </ul>
                                        <ul>
                                            <li class="user_main_text"></li>
                                            <li class="user_main_input"></li>
                                        </ul>
                                    </div>
                                </li>
                                <li class="user_main_r">
                                    <img class="IbtnEnterCssClass" id="IbtnEnter" style="border-top-width: 0px; border-left-width: 0px;
                                        cursor: pointer; border-bottom-width: 0px; border-right-width: 0px" name="Submit"
                                        src="Images/user_botton.gif" name="IbtnEnter" onclick="Validate();" />
                                </li>
                            </ul>
                            <dd id="user_bottom">
                                <ul>
                                    <li class="user_bottom_l"></li>
                                    <li class="user_bottom_c"></li>
                                    <li class="user_bottom_r"></li>
                                </ul>
                            </dd>
                        </dd>
                </dl>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
