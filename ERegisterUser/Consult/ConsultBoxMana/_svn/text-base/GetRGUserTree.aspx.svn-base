<%@ Page Language="C#" AutoEventWireup="true" Codebehind="GetDeptTree.aspx.cs" Inherits="EpointRegisterUser.Consult.GetDeptTree" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<html>
<head id="Head1" runat="server">
    <title>栏目列表</title>
    <base target="main1">
</head>

<script language="javascript">    
function AutoSetOuValue(check,ouName,ouGuid)
{
    var options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstOu").options; 
    var HidOuList= parent.document.getElementById("ctl00_ContentPlaceHolder2_HidOuList");
    if(check.checked)
    { 	
        for (var i=0; i < options.length; i++) 
        {   
            if (options[i].value==ouGuid)
            {
                return;
            }
        }  
	    options.add(new Option(ouName,ouGuid));	   
   	}
    else
   	{
   	    for (var i=0; i < options.length; i++) 
        {   
            if (options[i].value==ouGuid)
            {
                options[i] = null; i--;                             
            }
        }  
   	} 
   	options = parent.document.getElementById("ctl00_ContentPlaceHolder1_lstOu").options; 
   	var temp="";
   	for(var i=0; i < options.length; i++)
   	{
   	    temp=temp+options[i].value+"★";   	    
   	}
    HidOuList.value= temp;

}
</script>

<body topmargin="0" leftmargin="5">
    <form id="Tree" method="post" runat="server">
        <div>
            <cc1:TreeView ID="TreeView1" runat="server" Target="main1" InputType="CheckBox" OnTreeNodePopulate="TreeView1_TreeNodePopulate1">
            </cc1:TreeView>
        </div>
    </form>
</body>
</html>
