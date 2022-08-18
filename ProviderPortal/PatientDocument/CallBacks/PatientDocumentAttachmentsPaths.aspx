<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientDocumentAttachmentsPaths.aspx.cs" Inherits="ProviderPortal_PatientDocument_CallBacks_PatientDocumentAttachmentsPaths" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###Start###
    <asp:Repeater runat="server" ID="rptDocumentAttachments">
        <ItemTemplate>
            <div class="patient-attachments-wrapper">
                <input type="hidden" class="hdnDocumentPath" value='<%#Eval("DocumentPath") %>' />
                <input type="hidden" class="hdnOriginalFileName" value="<%#Eval("OriginalFileName") %>" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
    ###End###
    </form>
</body>
</html>
