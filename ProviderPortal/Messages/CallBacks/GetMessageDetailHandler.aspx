<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetMessageDetailHandler.aspx.cs"
    Inherits="HomeHealth_Messages_CallBacks_GetMessageDetailHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###Start###
       <div class="message-header">
            <div class="info">
                <h3>
                    <span class="iconDown" style="margin-top: 0px;"></span>
                    <asp:Label ID="lblSubject" runat="server" Text=""></asp:Label></h3>
                <div class="date">
                    <asp:Label ID="lblSentDate" runat="server" Text=""></asp:Label></div>
            </div>
            <div id="msg_details">
                <div class="label">
                    From</div>
                <div class="value" id="divMessageFromUser" runat="server">
                    
                </div>
                <div class="label">
                    To</div>
                <div class="value" id="divMessageToUsers">
                    <asp:Repeater runat="server" ID="rptMessageTo">
                        <ItemTemplate>
                            <div class="tag" id='<%#Eval("ReceiverId")%>'><span>
                                <%#Eval("ToName")%>
                                (<%#Eval("UserName")%>) </span>
                                <a style="display:none;" href="#" title="Removing tag" onclick="RemoveTag(this);">&nbsp;x</a>
                                </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="label">
                    CC</div>
                <div class="value" id="divMessageCcUsers">
                    <asp:Repeater runat="server" ID="rptMessageCc">
                        <ItemTemplate>
                            <div class="tag" id='<%#Eval("ReceiverId")%>'><span>
                                <%#Eval("CcName")%>
                                (<%#Eval("UserName")%>) </span>
                                <a style="display:none;" href="#" title="Removing tag" onclick="RemoveTag(this);">&nbsp;x</a>
                                </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div> 
        <div id="divMessageAttachment" runat="server" visible="false">
           <div class="info" style="margin-bottom:8px;">
                <h2>
                    <span class="iconDown" style="margin-top: 0px;"></span>
                    <span class="iconAttachment" style="float:left; margin-right:5px;"></span>
                    <asp:Label ID="lblAttachmentCount" runat="server" Text="" style="float:left; margin-right:3px;"></asp:Label><span style="padding-right: 5px; float:left;">Attachments</span> <%--<span class="iconSave" style="margin:0 5px;border-left: 1px solid #E2E2E2;"></span><a class="blue">Save All</a>--%></h2>
            </div> 
            <div style="margin-bottom:5px; float:left;">
                <asp:Repeater ID="rptAttachmentList" runat="server" OnItemDataBound="rptAttachmentList_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="ltrlAttachment"></asp:Literal>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
         <input type="hidden" id="hidnMsgId"/>
        ###End### 
        ###BodyStart###
        <asp:Literal runat="server" ID="ltrBody"></asp:Literal>
        ###BodyEnd###
        ###StartUnreadCount###
            <asp:Literal runat="server" ID="ltrUnreadMessageCount"></asp:Literal>
        ###EndUnreadCount###
    </div>
    </form>
</body>
</html>
