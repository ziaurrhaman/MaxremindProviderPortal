<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckPaymentDetails.aspx.cs" Inherits="ProviderPortal_Claims_CallBacks_CheckPaymentDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server"> 
        <div class="ChKPay">
            <h4>The payment against for this check number you entered is already saved. Do you still want to create?</h4>
        </div>        
        <div class="WidgetContent">
            <div style="width: 100%; float: left;">
                 <div id="CheckDetailsContainer" style="float: left;width: 100%;">
                     <asp:Repeater ID="rptChkDetails" runat="server">
                                <HeaderTemplate>
                                    <div class="Grid">
                                        <table>
                                            <thead id="Thead">
                                                <tr>                                               
                                                    <th style="width: 14%;">
                                                        Check Number
                                                    </th>
                                                    <th style="width: 6%;">
                                                        Payment Type
                                                    </th>
                                                    <th style="width: 6%;">
                                                       Check Issue Date
                                                    </th>                                                
                                                </tr>
                                            </thead>
                                <tbody id="ChkDetailList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="cursor: pointer">
                                        <td><%# Eval("CheckNumber") %></td> 
                                        <td><%# Eval("PaymentType") %></td> 
                                        <td><%# Eval("CheckIssueDate","{0:d}") %></td>                  
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>                                   
                                    <%--</tbody> </table>--%>
                                    <%--<div class="message">
                                        <span class="iconInfo" style="margin: 7px;"></span>
                                        <span class="spanInfo"></span>
                                    </div>
                                    <div class="pager">
                                        <div class="PageEntries">
                                            <span style="float: left;">
                                                <select id="ddlPagingPatient" style="margin-top: 5px;" onchange="RowsChange('FilterPatient');">
                                                    <option value="10">10</option>
                                                    <option value="25">25</option>
                                                    <option value="50">50</option>
                                                    <option value="75">75</option>
                                                    <option value="100">100</option>
                                                </select>
                                            </span><span style="float: left;">&nbsp;Entries per page</span>
                                        </div>
                                        <div class="PageButtons">
                                            <ul style="float: right; margin-right: 15px;">
                                            </ul>
                                        </div>
                                    </div>--%>
                                </FooterTemplate>
                       </asp:Repeater>
                 </div>
            </div>
        </div>   
    </form>
    ###End###
    ###StartBillPaidProc###
    <div id="MsgTrue" style="display:none"><p> ChargedProcedure and PaidProcedure are not same! that's why payment of specific CPT is not showing in the payment grid!</p>
            <b>Reason:</b> CPT code may be changed after submission.
    </div>
    <div id="MsgFalse" style="display:none">No issue is detected in the payment!</div>
    <div class="Grid" id="chkgrid">
                <table>
                     <thead>
                          <tr>
                             <th>ClaimId</th>
                             <th>Paid proc</th>
                             <th>CPT Code</th>
                             <th>Check Number</th>
                          </tr>
                     </thead>
                    <tbody id="tblChkBillProcDifPaidProc">
                        <asp:Repeater runat="server" ID="rptBillandPaidProc">
                            <ItemTemplate>
                                     <tr>
                                         <td><%# Eval("ClaimId")%></td>
                                         <td><%# Eval("PaidProcedure")%></td>
                                         <td><%# Eval("CPTCode")%></td>
                                         <td><%# Eval("CheckNumber")%></td>
                                     </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
    ###EndBillPaidProc###
</body>
</html>
