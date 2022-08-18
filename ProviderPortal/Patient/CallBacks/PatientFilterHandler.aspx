<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientFilterHandler.aspx.cs" Inherits="HomeHealth_Patient_CallBacks_PatientFilter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###Start###
    <asp:Repeater ID="rptPatients" runat="server" OnItemDataBound="rptPatients_ItemDataBound">
                    <ItemTemplate>
                        <tr style="cursor:pointer" >
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <i><%# Eval("RowNumber") %></i>
                            </td>
                            <td class="PatId" style="text-align: center;" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("PatientId") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("LastName") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("FirstName") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("Gender") %>
                            </td>
                            <td class="txtalign-cntr" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("DateOfBirth", "{0:d}") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("Name") %>
                            </td>
                            <td class="txtalign-cntr" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("Cell") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("Address") %>
                            </td>
                            <td style="text-align:right" class="hidetd" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <asp:Literal ID="ltrPatientResposibilty" runat="server"></asp:Literal>
                            </td>
                            <td style="text-align:right" class="hidetd" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                 <asp:Literal ID="ltrPatientPayment" runat="server"></asp:Literal>
                            </td>
                            <td style="text-align:right" class="hidetd" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                 <asp:Literal ID="ltrPatientBalence" runat="server"></asp:Literal>
                            </td>
                            <td style="text-align: center; width:100%" class="hidetd">
                                <a class="payment-link" href="#" title="View Patient" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                    <img src="../../Images/viewEye.png" /></a>
                                <a class="payment-link" href="#" id="openPostpayment" title="Post Payment" onclick="PostEOBPayment(this)">
                                    <img src="../../Images/payment.png" /></a>
                                <a class="payment-link" href="#" id="openBalanceSheet" title="Post Payment" onclick="ViewPaymentDetails(this)">
                                    <img src="../../Images/balance-sheet.png" / style="height:15px;width:15px"></a>
                                <asp:HiddenField   id="hdnPatientId" value='<%#Eval("PatientId")%>'  runat="server"/> 
                               
                                <input type="hidden" class="PatientName" id="PatientName" text='<%#Eval("FullName")%>'  runat="server"/>
                              
                            </td>
                            <td style="display:none" class="hdnPatientid"><%#Eval("PatientId")%></td>
                            <td style="display:none" class="hdnFullName"><%#Eval("FullName")%></td>
                            <td style="display:none" class="hdnCheckNos1"><asp:HiddenField   id="hdnCheckNos"   runat="server"/></td>
                             
                      
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
    ###End###
    ###StartPatientRowsCount###
    <asp:Literal runat="server" ID="ltrlPatientRowsCount"></asp:Literal>
    ###EndPatientRowsCount###
    </div>
    </form>
</body>
</html>
  