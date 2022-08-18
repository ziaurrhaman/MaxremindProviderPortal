

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingTransitionPatienthandler.aspx.cs" Inherits="ProviderPortal_PendingTransitions_CallBacks_PendingTransitionPatienthandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../Scripts/Rizwan/PendingTransition.js"></script>
</head>
<body>
    <form id="form1" runat="server"> 
    <div>
    ###Start###
    <asp:Repeater ID="rptPatients" runat="server">
        <ItemTemplate>
            <tr style="cursor: pointer" class="ptlid"  <%--onclick="PTLPatientDialog(' <%# Eval("PatientId") %>');"--%>>
                <td><i><%# Eval("RowNumber") %></i></td>
                <td><%# Eval("PatientId") %></td>
                <td><%# Eval("LastName") %></td>
                <td><%# Eval("FirstName") %></td>
                <td><%# Eval("Gender") %></td>
                <td><%# Eval("DateOfBirth", "{0:d}") %></td>
                <td><%# Eval("Cell") %></td>
                <td><%# Eval("Address") %></td>
               <td class="tdPTLReasons">
                    <span><%# Eval("PTLReasons")%></span>
                    <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />
                </td>

            </tr>
        </ItemTemplate>
    </asp:Repeater>
           <asp:HiddenField ID="hdnTotalRowsPatients" runat="server" />
    ###End###
    ###StartPatientRowsCount###
    <asp:Literal runat="server" ID="ltrlPatientRowsCount"></asp:Literal>
     
    ###EndPatientRowsCount###
    </div>
    </form>
</body>
</html>
