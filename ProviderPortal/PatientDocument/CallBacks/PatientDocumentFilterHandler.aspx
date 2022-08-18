<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientDocumentFilterHandler.aspx.cs" Inherits="ProviderPortal_PatientDocument_CallBacks_PatientDocumentFilterHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###Start###
    <asp:Repeater ID="rptPatientDocuments" runat="server">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <i><%# Eval("RowNumber") %></i>
                </td>
                <td align="center">
                    <input type="hidden" class="DocumentId" value='<%# Eval("DocumentId") %>'>
                    <input type="checkbox" class="CheckUncheckDoc" />
                </td>
                <td onclick="EditPatientDocument(this)">
                    <span class="spnCurrentDocDate">
                        <%# Eval("DocumentDate") %>
                    </span>
                </td>
                <td onclick="EditPatientDocument(this)">
                    <%# Eval("DocumentName") %>
                </td>
                <td onclick="EditPatientDocument(this)">
                    <%# Eval("CategoryName") %>
                </td>
                <td onclick="EditPatientDocument(this)">
                    <%# Eval("ProviderName")%>
                </td>
                <td class="action">
                    <div>
                        <span class="spneye" onclick="ViewPatientDocument(this)" title="View"></span>
                        <span class="spnedit" onclick="EditPatientDocument(this)" title="Edit"></span>
                        <span class="spndelete" onclick="DeletePatientDocument(this)" title="Delete"></span>
                        <span class="spndownload" onclick="DownloadPatientDocumentFileAll(this)" title="Download"></span>
                                            
                        <input type="hidden" class="hdnDocumentId" value='<%#Eval("DocumentId") %>' />
                        <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId") %>' />
                        <input type="hidden" class="hdnPatientName" value='<%# Eval("PatientName") %>' />
                    </div>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###End### 
    
    ###StartPatientDocumentRowsCount###
        <asp:Literal runat="server" ID="ltrlPatientDocumentsRowsCount"></asp:Literal>
    ###EndPatientDocumentRowsCount###
    </div>
    </form>
</body>
</html>