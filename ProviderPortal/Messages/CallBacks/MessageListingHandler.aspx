<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageListingHandler.aspx.cs"
    Inherits="HomeHealth_Messages_CallBacks_MessageListingHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###MessageListStart###
    <asp:Repeater runat="server" ID="rptMessageList" OnItemDataBound="rptMessageList_ItemDataBound">
        <ItemTemplate>
            <tr id='<%#Eval("MessagesId")%>' style='font-weight: <%#Eval("MessageStatus").ToString()=="Read"?"":"bold"%>;'>
                <td style="display: none;">
                    <%#Eval("RowNumber")%>
                </td>
                <td style="text-align: center;">
                    <input type="checkbox" id='<%#Eval("MessagesId")%>' class="chkBox" />
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <span class='<%#Eval("MessageStatus").ToString()=="Read"?"iconReadMessage":"iconUnReadMessage"%>'>
                    </span>
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <%#Eval("Name")%>
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <span style="margin-right: 5px; width: 3px; height: 13px;">
                        <asp:Image runat="server" ID="imgPriority" />
                    </span>
                    <%#Eval("Subject")%>
                    <span style="float: right" class='<%#int.Parse(Eval("Attachment").ToString()) > 0 ?"iconAttachment":""%>'>
                    </span>
                </td>
                <td style="text-align: center; cursor: pointer;" onclick="GetMessageDetail('<%#Eval("MessagesId")%>')">
                    <%#Eval("CreatedDate")%>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr id='<%#Eval("MessagesId")%>' style='font-weight: <%#Eval("MessageStatus").ToString()=="Read"?"":"bold"%>;'
                class="alternatingRow">
                <td style="display: none;">
                    <%#Eval("RowNumber")%>
                </td>
                <td style="text-align: center;">
                    <input type="checkbox" id='<%#Eval("MessagesId")%>' class="chkBox" />
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <span class='<%#Eval("MessageStatus").ToString()=="Read"?"iconReadMessage":"iconUnReadMessage"%>'>
                    </span>
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <%#Eval("Name")%>
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <span style="margin-right: 5px; width: 3px; height: 13px;">
                        <asp:Image runat="server" ID="imgPriority" />
                    </span>
                    <%#Eval("Subject")%>
                    <span style="float: right" class='<%#int.Parse(Eval("Attachment").ToString()) > 0 ?"iconAttachment":""%>'>
                    </span>
                </td>
                <td style="text-align: center; cursor: pointer;" onclick="GetMessageDetail('<%#Eval("MessagesId")%>')">
                    <%#Eval("CreatedDate")%>
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
    <asp:Repeater runat="server" ID="rptSentMessageList" OnItemDataBound="rptSentMessageList_ItemDataBound">
        <ItemTemplate>
            <tr id='<%#Eval("MessagesId")%>'>
                <td style="display: none;">
                    <%#Eval("RowNumber")%>
                </td>
                <td style="text-align: center;">
                    <input type="checkbox" id='<%#Eval("MessagesId")%>' class="chkBox" />
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <%#Eval("SentUsers")%>
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <span style="margin-right: 5px; width: 3px; height: 13px;">
                        <asp:Image runat="server" ID="imgPriority" />
                    </span>
                    <%#Eval("Subject")%>
                    <span style="float: right" class='<%#int.Parse(Eval("Attachment").ToString()) > 0 ?"iconAttachment":""%>'>
                    </span>
                </td>
                <td style="text-align: center; cursor: pointer;" onclick="GetMessageDetail('<%#Eval("MessagesId")%>')">
                    <%#Eval("CreatedDate")%>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr id='<%#Eval("MessagesId")%>' class="alternatingRow">
                <td style="display: none;">
                    <%#Eval("RowNumber")%>
                </td>
                <td style="text-align: center;">
                    <input type="checkbox" id='<%#Eval("MessagesId")%>' class="chkBox" />
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <%#Eval("SentUsers")%>
                </td>
                <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                    <span style="margin-right: 5px; width: 3px; height: 13px;">
                        <asp:Image runat="server" ID="imgPriority" />
                    </span>
                    <%#Eval("Subject")%>
                    <span style="float: right" class='<%#int.Parse(Eval("Attachment").ToString()) > 0 ?"iconAttachment":""%>'>
                    </span>
                </td>
                <td style="text-align: center; cursor: pointer;" onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" >
                    <%#Eval("CreatedDate")%>
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
    ###MessageListEnd### ###RowCountStart###
    <asp:Literal runat="server" ID="ltrlRowsCount"></asp:Literal>
    ###RowCountEnd###
    </form>
</body>
</html>
