<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HTProject.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Images/User_Login.css" type="text/css" rel="stylesheet">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">

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

    <style type="text/css">
        .SYS
        {
        }
    </style>
    <meta content="MSHTML 6.00.6000.16809" name="GENERATOR">
</head>
<body id="userlogin_body">
    <form id="form1" runat="server">
    <input type="hidden" value="login" name="action">
    <input id="logintype" type="hidden" name="logintype">

    <script type="text/javascript">
        function checkData() {
            var acct = document.getElementById("account").value;
            var pwd = document.getElementById("password").value;
            var auth = document.getElementById("userauthcode").value;

            if (acct.length < 1) {
                alert("请输入用户名!");
                document.getElementById("account").focus();
                return false;
            } else if (pwd.length < 1) {
                alert("请输入密码!");
                document.getElementById("password").focus();
                return false;
            } else if (auth.length < 1) {
                alert("请输入验证码!");
                document.getElementById("userauthcode").focus();
                return false;
            }

            document.getElementById('<%=LoginSys.ClientID %>').click();
        }
    </script>

    <div style="position: absolute; width: 260px; height: 42px; z-index: 1; left: 10px;
        top: 400px" id="Div1">
        提示:<br>
        &nbsp;&nbsp;&nbsp; 点击下载<font color="RED"><a href="无锡市建设工程勘察设计合同备案管理系统用户操作手册.rar"><font
            color="RED">《用户操作手册》。</font></a></font>
    </div>
    <div id="panSiteFactory">
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
                                <asp:ImageButton ID="LoginSys" runat="server" OnClick="LoginSys_Click" Style="display: none" /></li>
                            <li class="user_top_c"></li>
                            <li class="user_top_r"></li>
                        </ul>
                        <dd id="user_main">
                            <ul>
                                <li class="user_main_l"></li>
                                <li class="user_main_c">
                                    <div class="user_main_box">
                                        <ul>
                                            <li class="user_main_text">用户名： </li>
                                            <li class="user_main_input">
                                                <input class="TxtUserNameCssClass" id="account" maxlength="20" name="account" runat="server"
                                                    autocomplete="off" />
                                            </li>
                                        </ul>
                                        <ul>
                                            <li class="user_main_text">密 码： </li>
                                            <li class="user_main_input">
                                                <input class="TxtPasswordCssClass" id="password" type="password" name="password"
                                                    runat="server" />
                                                <%--<a style="margin-left: -5px; color: black" href="http://admin.fax518.net/user/forgetpwd.php">
                                                    忘记密码</a>--%>
                                            </li>
                                        </ul>
                                        <ul>
                                            <li class="user_main_text">验证码： </li>
                                            <li class="user_main_input">
                                                <input class="TxtYanzheng" id="userauthcode" name="userauthcode" runat="server" autocomplete="off" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <img id="imgCode" src="ReadTempImg.aspx" style="vertical-align: top; cursor: hand"
                                                    onclick="this.src=this.src+'?'" />
                                            </li>
                                        </ul>
                                    </div>
                                </li>
                                <li class="user_main_r">
                                    <img class="IbtnEnterCssClass" id="IbtnEnter" style="border-top-width: 0px; border-left-width: 0px;
                                        cursor: pointer; border-bottom-width: 0px; border-right-width: 0px" onclick="doLogin();"
                                        src="Images/user_botton.gif" name="IbtnEnter" />
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
