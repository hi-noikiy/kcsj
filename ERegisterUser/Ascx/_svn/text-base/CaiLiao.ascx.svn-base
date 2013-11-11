<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CaiLiao.ascx.cs" Inherits="EpointRegisterUser.Ascx.CaiLiao" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>

<script type="text/javascript">
            // 增加附件函数，增加到指定的SpanID,基数为 attaIdx 
            var attaIdx=100;
            function addBySpanID(spanId) 
            {
                addfile(spanId,attaIdx);
                attaIdx++;
                return attaIdx;
            }
                
            function addFile(attachHref)
            {
                addBySpanID(attachHref.parentNode.firstChild.id);
                txtFileIndex = attachHref.parentNode.lastChild;
                txtFileIndex.value = txtFileIndex.value + (attaIdx-1) + "|";
            }
            
            function DelAttach(AttachGuid,obj)
            {
                if(confirm("确认删除该附件吗？"))
                {
                    document.all["<%=HidAttachDel.ClientID %>"].value = AttachGuid;
                    document.all["<%=btnDelAttach.ClientID %>"].click();
                    obj.parentNode.style.display = "none";
                }
            } 
</script>

<table cellspacing="0" cellpadding="0" width="100%" align="left" border="0" class="table">
    <tbody>
        <tr>
            <td align="left">
                <span id="idfilespan" runat="server"></span><a id="attach" title="如果需要发送多个附件，请多次点击“添加附件”即可, 要注意附件总量不能超过发送限制的大小。"
                    onclick="javascript:addFile(this);this.childNodes[0].nodeValue='添加附件';" href="javascript:void(0);">
                    <img src="<%=Request.ApplicationPath%>/images/attach.gif" border="0" alt="" />添加附件</a><%=GetAttachInfoTwo()%><asp:TextBox
                        runat="server" ID="txtFileIndex" Text="|" Width="0">
                    </asp:TextBox></td>
            <td class="TableSpecial" runat="server" id="tdContainer" width="0" style="display: none">
                <input type="button" id="btnDelAttach" runat="server" onserverclick="btnDelAttach_ServerClick"
                    causesvalidation="false" />
                <asp:HiddenField ID="HidAttachDel" runat="server" />
            </td>
        </tr>
    </tbody>
</table>

<script type="text/javascript">
    try
    {
        if('<%=ViewState["ReadOnly"]%>' == 'True')
        {
            if(document.all.attach.length == undefined)
            {
                document.all.attach.innerText = "";
            }
            else
            {
                for(var i=0; i<document.all.attach.length; i++)
                {
                    document.all.attach[i].innerText = "";
                }
            }
        }
    }
    catch(e)
    {}
</script>

