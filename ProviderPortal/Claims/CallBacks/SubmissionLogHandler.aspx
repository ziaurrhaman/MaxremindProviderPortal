<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmissionLogHandler.aspx.cs" Inherits="HomeHealth_EpisodeClaims_CallBacks_SubmissionLogHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###StartSubmissionLogHandler###
        <asp:Repeater ID="rptSubmissionLog" runat="server" OnItemDataBound="rptSubmissionLog_ItemDataBound">
                        <ItemTemplate>
                            <tr style="cursor: pointer">
                                <td>
                                    <%# Eval("RowNumber") %>
                                </td>                                
                                <td>
                                    <%# Eval("PatientName")%>
                                </td>
                                <td>
                                    <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                                </td>  
                                <td style="text-align: center; white-space: nowrap;">
                                    <%# Eval("FileName")%>
                                </td>                                          
                                <td style="text-align: center; white-space: nowrap;">
                                    <%# Eval("ClaimNo")%>
                                </td>                
                                <td style="text-align: center; white-space: nowrap;">
                                    <%# Eval("SubmissionDate")%>
                                </td>                       
                                <td>
                                    <%# Eval("SubmissionResults")%>
                                </td>                                                           
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
        <asp:HiddenField runat="server" ID="hdnSubmissionLogCount" />
        ###EndSubmissionLogHandler###
    </div>
    </form>
</body>
</html>
