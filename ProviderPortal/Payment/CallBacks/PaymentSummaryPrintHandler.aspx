<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentSummaryPrintHandler.aspx.cs" Inherits="ProviderPortal_Payment_CallBacks_PaymentSummaryPrintHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         ###StartERAClaims###
       <style>
            .ui-dialog
                        {
                           top: 103.5px !important;
                        } 
       </style>
      <div style="width: 100%; height:350px; float:left;" id="divERAClaimsCheckDetailPrint">
           
                <div>
                    <div style="text-align:center">
  <h3> Payment Summary </h3>
                    </div>
                  <div>
     <table>
                        <tbody style="text-align:center">
                          <tr>
                                 <td></td>
                                <td style="text-align:right">
                                     <div id="firstDate" style=""><asp:Label runat="server" ID="txtfirst">First Date</asp:Label></div>
                                </td><td style="text-align:right">
                                     <div id="" style="text-align: center"><asp:Label runat="server" ID="Label1">-</asp:Label></div>
                                </td>
                                <td>
                                     
                                <div id="LastDate" style="text-align:left"><asp:Label runat="server" ID="txtlast">Second last</asp:Label></div>
                                </td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                  </div>
               
                  
                </div>

                <div style="width: 100%; margin-top: 20px;">
                    <div id="payerType" style="width:20%; float:left;margin-left:12%">
                        <table>
                            <tbody style="text-align:left">
                                <tr>
                                    <td style="border-bottom:1px solid black">
                                        <label> Payer Type</label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                    
                                        <label style="text-decoration:solid underline;color:#4288d3">Insurance</label>
                                       
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                        <label style="text-decoration:solid underline;color:#4288d3"> Other</label>
                                    </td></tr>
                                <tr>
                                    <td>
                                        <label style="text-decoration:solid underline;color:#4288d3"> Patient</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-top:1px solid black">
                                        <label style=" font-size:14px ;font-weight:bold">Total</label>
                                    </td>
                                </tr>
                                
                            </tbody>

                        </table>
                    </div>
                     <div id="Amount"style="width:20%; margin-left:6%;float:left">
                                <table>
                            <tbody style="text-align:right">
                                <tr>
                                    <td style="border-bottom:1px solid black">
                                        <label> Amount</label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                     <asp:Label runat="server" ID="TxtInsurance">0.00</asp:Label>
                                 
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                    <asp:Label runat="server"  ID="TxtOther"> $0.00</asp:Label>
                                 
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                         <asp:Label runat="server"  ID="TxtPatient">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-top:1px solid black">
                                     
                                    <asp:Label runat="server"  ID="TxtTotal" style=" font-size:14px ;font-weight:bold">0.00</asp:Label>
                                    </td>
                                </tr>
                            </tbody>

                        </table>
                    </div>
                     <div id="Unapplied"style="width:20%; margin-right:12% ;float:right">
                                <table>
                            <tbody style="text-align:right">
                                <tr>
                                    <td style="border-bottom:1px solid black">
                                    <asp:Label runat="server">Unapplied</asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                  <%--   <asp:Label runat="server" ID=" TxtuInsurance">0.00</asp:Label>--%>
                                        <asp:Label runat="server" ID="TxtUinsu">0.00</asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                    <asp:Label runat="server" ID="TxtUOther">$0.00</asp:Label>
                                    </td></tr>
                                <tr>
                                    <td>
                                     <asp:Label runat="server" ID="TxtUPatient"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="border-top:1px solid black">
                                       
                                           <asp:Label runat="server" ID="UTotal" style=" font-size:14px ;font-weight:bold"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>

                        </table>
                    </div>
                </div>

                <div style="width: 100%; float: left; margin-bottom: 5px;">
                  <div id="GrandTotal"style="width:20%; margin-left:12% ;float:Left; margin-top:20px"> 
                                <table>
                            <tbody style="text-align:left">
                                <tr>
                                    <td style="border-bottom:1px solid black">
                                   
                                    <asp:Label runat="server" ID="Label2" style=" font-size:14px ;font-weight:bold">Grand Total</asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                         <label id="lbl" style="float:left">Amount</label>
                                    <%-- <asp:Label runat="server" ID=" TxtUInsurance">0.00</asp:Label>--%>
                                       <asp:Label runat="server" ID="AmountTotal" style="float:right"></asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td style="border-bottom:1px solid black">
                                         <label id="lbl" style="float:left">Unapplied</label>
                                  <%--  <asp:Label runat="server" ID=" TxtUOther">0.00</asp:Label>--%>
                                          <asp:Label runat="server" ID="UnAppliedTotal" style="float:right">$0.00</asp:Label>
                                    </td>
                                    </tr>
                             
                                 <tr>
                                    <td style="float:right">
                                         <asp:Label style=" font-size:14px ;font-weight:bold; float:right " id="GrandTotals" runat="server"> 0.00</asp:Label>
                                         
                                    </td>
                                </tr>
                            </tbody>

                        </table>
                    </div>
                </div>



        
            </div>
            ###EndERAClaims###
    </div>
    </form>
</body>
</html>
