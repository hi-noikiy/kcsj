<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetUserTree.aspx.cs" Inherits="EpointRegisterUser.Consult.GetUserTree" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<html>
<head id="Head1" runat="server">
    <title>栏目列表</title>
    <base target="main1">
</head>

<script language="javascript">   

 function AutoSetPValue_OuGuid(check,OuGuid)
{
//    try
//    {
//        var div_Progress =window.parent.document.getElementById("ctl00_WebProcess1_upnlUpdate");
//        div_Progress.style.display="";
//    }catch(err){}
        
    var hasSelectGuidLst="",hasSelectDisplayNameLst="";
    //var options = parent.document.all("ListReceiverName").options;
    var options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstUser").options; 
    for (j=0; j < options.length; j++)  
    {
        hasSelectGuidLst+=options[j].value+";";
        hasSelectDisplayNameLst+=options[j].text+";";
    }
        
    if (check.checked) 
    {
        //alert(OuGuid);
        PageMethods.getAllUserByOuGuid(hasSelectGuidLst,hasSelectDisplayNameLst,OuGuid,true,CallBack_AutoSetPValue_OuGuid,OnFailed);
     }
    else
        PageMethods.getAllUserByOuGuid(hasSelectGuidLst,hasSelectDisplayNameLst,OuGuid,false,CallBack_AutoSetPValue_OuGuid,OnFailed);
}
    
function CallBack_AutoSetPValue_OuGuid( response)
{
    if(response!="0")
    {
        //var options = parent.document.all("ListReceiverName").options;
        var options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstUser").options; 
        for (i=0; i < options.length; i++) 
        {
            options[i] = null; i--;
        }
        var  GuidName= response.split("★");
        var arrUserGuid=GuidName[0].split(";");
        var arrDispName=GuidName[1].split(";");

        for (i=0; i < arrUserGuid.length; i++) 
	    {
	        if(arrUserGuid[i]!="" && arrDispName[i]!="")
                options.add(new Option(arrDispName[i],arrUserGuid[i]));
        }
    }
    
    var HidUserList= parent.document.getElementById("ctl00_ContentPlaceHolder2_HidUserList");
    options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstUser").options; 
    var temp="";
    for(i=0; i < options.length; i++)
    {
        temp=temp+options[i].value+"★";   	    
    } 
    HidUserList.value=temp;
    
//    try
//    {
//        var div_Progress =window.parent.document.getElementById("ctl00_WebProcess1_upnlUpdate");
//        div_Progress.style.display="none";
//    }catch(err){}
}


//添加一个错误的处理，防止系统默认弹出一个Alert对话框，另外可以作为错误信息提示
function OnFailed(error)
{
   
}

 
function AutoSetUserValue(check,displayName,userGuid)
{
    var options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstUser").options; 
    var HidUserList= parent.document.getElementById("ctl00_ContentPlaceHolder2_HidUserList");   
    if(check.checked)
    { 	
        for (var i=0; i < options.length; i++) 
        {   
            if (options[i].value==userGuid)
            {
                return;
            }
        }  
	    options.add(new Option(displayName,userGuid));	   
   	}
    else
   	{
   	    for (var i=0; i < options.length; i++) 
        {   
            if (options[i].value==userGuid)
            {
                options[i] = null; i--;                             
            }
        }  
   	} 
    options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstUser").options; 
   	var temp="";
   	for(var i=0; i < options.length; i++)
   	{
   	    temp=temp+options[i].value+"★";   	    
   	}
   	HidUserList.value=temp;
}
//function AutoSetOuValue(check,displayName,userGuid)
//{  
//    var i,k;       
//    var name=displayName.split('★');
//    var guid=userGuid.split('★'); 
//             
//    var options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstUser").options; 
//    var HidUserList= parent.document.getElementById("ctl00_ContentPlaceHolder2_HidUserList");
//    var is_exit; 
//    if(check.checked)
//    { 
//        for(i=0;i<guid.length;i++)
//        {
//             is_exit=false;
//             for (k=0; k < options.length; k++) 
//             {   
//                if (options[k].value==guid[i])
//                {
//                   is_exit=true;
//                }
//             }
//             if(!is_exit)
//             {  
//                options.add(new Option(name[i],guid[i]));
//             }           
//        }      
//    }
//    else
//    {
//        for(i=0;i<guid.length;i++)
//        {       
//            for (k=0; k < options.length; k++) 
//            {   
//                if (options[k].value==guid[i])
//                {
//                    options[k] = null; k--;                   
//                }
//            }  
//        }
//    } 
//    
//    options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstUser").options; 
//    var temp="";
//    for(i=0; i < options.length; i++)
//    {
//        temp=temp+options[i].value+"★";   	    
//    } 
//    HidUserList.value=temp;
//}
</script>

<body topmargin="0" leftmargin="5">
    <form id="Tree" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="false"
            EnablePageMethods="true">
        </asp:ScriptManager>
        <div>
            <cc1:TreeView ID="TreeView1" runat="server" Target="main1" RunClickEvtWhenCheckChild="false"
                InputType="CheckBox" OnTreeNodePopulate="TreeView1_TreeNodePopulate1">
            </cc1:TreeView>
        </div>
    </form>
</body>
</html>
