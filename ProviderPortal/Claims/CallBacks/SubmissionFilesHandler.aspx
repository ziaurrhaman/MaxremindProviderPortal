<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmissionFilesHandler.aspx.cs" Inherits="HomeHealth_EpisodeClaims_CallBacks_SubmissionFilesHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       ###StartSubmissionFilesHandler###
        <asp:Repeater ID="rptSubmissionFiles" runat="server" OnItemDataBound="rptSubmissionFiles_ItemDataBound">
                        <ItemTemplate>
                            <tr style="cursor: pointer">
                                <td>
                                    <%# Eval("RowNumber") %>
                                </td>                                
                                <td>
                                  <%# Eval("FileName")%>
                                </td>
                                <td>
                                    <%# Eval("CreatedDate")%>
                                </td>
                                <td style="text-align: center">
                                    <asp:Label  runat="server" ID="lblFileStatus" Text='<%# Eval("FileStatus")%>'></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <%# Eval("SubmissionResults")%>
                                </td>                     
                                <td style="text-align: center;">
                                    <div style="width:50%;">
                                        <asp:Literal runat="server" ID="ltrlAttachment"></asp:Literal>                                                                            
                                    </div>                                            
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
        <asp:HiddenField runat="server" ID="hdnSubmissionFilesCount" />
        ###EndSubmissionFilesHandler###
    </div>
    </form>
</body>
</html>
