<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerSupportHandler.aspx.cs" Inherits="EMR_Messages_CallBacks_CustomerSupportHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartPatientMessage###
        <asp:Repeater ID="rptPatientMessages" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("RowNumber")%>
                    </td>
                    <td>
                        <span class='<%# Eval("ReadStatus")%>'></span>
                    </td>
                    <td>
                        <%# Eval("PatientId")%>
                    </td>
                    <td>
                        <%# Eval("PatientName")%>
                                                        
                    </td>
                    <td>
                        <%# Eval("Priority")%>
                    </td>
                    <td>
                        <%# Eval("SubjectEHR")%>
                                                        
                    </td>
                    <td>
                        <%# Eval("MessageEHR")%>
                        <input type="hidden" class="hndcontactMessageReply" value='<%# Eval("MessageReply")%>' />
                        <input type="hidden" class="hndcontactMessage" value='<%# Eval("Message")%>' />
                        <input type="hidden" class="hndcontactSubject" value='<%# Eval("Subject")%>' />
                        <input type="hidden" class="hndcontactPatientEmail" value='<%# Eval("PatientEmail")%>' />
                        <input type="hidden" class="hndPatientContactMessagesId" value='<%# Eval("PatientContactMessagesId")%>' />
                        <input type="hidden" class="hndPriority" value='<%# Eval("Priority")%>' />
                        <input type="hidden" class="hndPatientName" value='<%# Eval("PatientName")%>' />
                        <input type="hidden" class="hndPatientId" value='<%# Eval("PatientId")%>' />
                        <input type="hidden" class="hndPatientCity" value='<%# Eval("City")%>' />
                    </td>
                    <td class="action">
                        <span class="spnview" title="View Reply" onclick="viewMessage(this);"></span>
                        <span class="iconReply" title="Edit" onclick="ReplyContactMessage(this);"></span>
                        <span class="spndelete" title="Delete" onclick="deleteContactMessage(<%# Eval("PatientContactMessagesId")%>);"></span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hdnPatientMessageTotalRows" runat="server" />
    ###EndPatientMessage###
    </div>
    </form>
</body>
</html>
