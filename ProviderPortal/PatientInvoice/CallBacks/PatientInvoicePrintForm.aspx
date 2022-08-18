<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientInvoicePrintForm.aspx.cs" Inherits="ProviderPortal_PatientInvoice_CallBacks_PatientInvoicePrintForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>  
</head>
<body>
   <form  runat="server">       
    <div>
             
       ####PatientInvoiceStart####
        <link href="../../../StyleSheets/PatientInvoice.css" rel="stylesheet" />
         <style>
             @page {size: A4 portrait;margin: 14%;}
             #divInvoiceDLG {
                max-height: 550px !important;
                overflow-x: hidden;
                overflow-y: auto;
             }
         </style>
         <div class="PatientInvoice">
            <div class="InvoiceHeader">
                <div class="InvoiceHeaderCol">
                    <div class="InvoiceHeaderUpper">
                        <div style="width:100%; float:left;">
                            <div style="width:25%; float:left; height:10px; background-color:black;"></div>
                            <div style="width:50%; float:left; text-align:center; font-weight:bold;"></div>
                            <div style="width:25%; float:left; height:10px; background-color:black;"></div>
                        </div>

                        <div class="ServiceProvider">
                            <div class="SrviceProviderName"><span id="spServiceProviderName" runat="server">Service Provider Name </span></div>
                            <div class="SrviceProviderAddress"><span id="spServiceProviderAddress" runat="server" >Service Provider Address</span></div>
                            <div class="SrviceProviderCity"><span id="spServiceProviderZip" runat="server">City, State, Zip</span></div>
                        </div>

                        <div style="width:100%; float:left; margin-bottom:15px;">RETURN SERVICE REQUESTED</div>

                        <div style="width:100%; float:left;">
                            <div style="width:25%; float:left; font-size:14px;">LAST PAID AMOUNT</div>
                            <div style="width:75%; float:left; font-size:14px;"><span id="spLastPaidAmount" runat="server">$0.00</span></div>
                        </div>

                        <div style="width:100%; float:left; margin-top:20px;">
                            <div class="divCheckBox" style="float:left;"></div>
                            <div style="width:90%; float:left; margin-left:5px;">Please check the box, if insurance information has changed or address is incorrect, and indicate change on reverse side.</div>
                        </div>

                    </div>
                    <div class="InvoiceHeaderLower">

                        
                        <div class="PatientInfo">
                            <div class="PatientName"><span id="spPatientName" runat="server">Patient Name </span></div>
                            <div class="PatientAddress"><span id="spPatientAddress" runat="server">Patient Address</span></div>
                            <div class="PatientCity"><span id="spPatientZip" runat="server">City, State, Zip</span></div>
                        </div>

                    </div>
                </div>
                <div class="InvoiceHeaderCol">
                    <div class="InvoiceHeaderUpper">

                        <div class="VisaCard">
                            <div style="text-align:center;width:100%; border-bottom:1px solid black;"><span>IF PAYING BY MASTERCARD OR VISA, FILL OUT BELOW</span></div>
                            <div>
                                <div style="text-align:center;width:100%; font-size:10px;">CHECK CARD USING FOR PAYMENT</div>
                                <div style="width:100%; float:left; padding-left: 10px; padding-top: 10px; padding-bottom: 3px; font-size: 10px; border-bottom:1px solid black; box-sizing: border-box;">
                                    <%--Master Card--%>
                                    <div style="width:25%; float:left;">
                                        <div style="width:30%; float:left;"><img style="width:80%;" src="../../../Images/MasterCard.png" alt="Master Card"></img></div>
                                        <div style="width:50%; float:left;">
                                            <div class="divCheckBox"></div>
                                            <div> Master Card</div>
                                        </div>
                                    </div>

                                    <%--Visa Card--%>
                                     <div style="width:25%; float:left;">
                                        <div style="width:30%; float:left;"><img style="width:80%;" src="../../../Images/visa.png" alt="Visa Card"></img></div>
                                        <div style="width:50%; float:left;">
                                            <div class="divCheckBox"></div>
                                            <div>Visa Card</div>
                                        </div>
                                    </div>

                                    <%--American Express--%>
                                     <div style="width:25%; float:left;">
                                        <div style="width:30%; float:left;"><img style="width:80%;" src="../../../Images/AmericanExpress.png" alt="AmericanExpress"></img></div>
                                        <div style="width:50%; float:left;">
                                            <div class="divCheckBox"></div>
                                            <div>American Express</div>
                                        </div>
                                    </div>

                                    <%--Discover--%>
                                     <div style="width:25%; float:left;">
                                        <div style="width:30%; float:left;"><img style="width:80%;" src="../../../Images/Discover.png" alt="Visa Card"></img></div>
                                        <div style="width:50%; float:left;">
                                            <div class="divCheckBox"></div>
                                            <div>Discover Network</div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div style="width:100%; height:35px; float:left;font-size: 10px; border-bottom:1px solid black; box-sizing: border-box;">
                                <div style="width:69%;float:left; border-right:1px solid black; height:35px;"><div style="padding: 3px;">CARD NUMBER</div></div>
                                <div style="width:30%;float:left;"><div style="padding: 3px;">SIGNATURE CODE</div></div>
                            </div>
                            <div style="width:100%; height:35px; float:left;font-size: 10px; border-bottom:1px solid black; box-sizing: border-box;">
                                <div style="width:69%;float:left; border-right:1px solid black; height:35px;"><div style="padding: 3px;">SIGNATURE</div></div>
                                <div style="width:30%;float:left;"><div style="padding: 3px;">EXP. DATE</div></div>
                            </div>
                            <div style="width:100%; height:45px; float:left;font-size: 10px; box-sizing: border-box;">
                                <div style="width:33%;float:left; border-right:1px solid black; height:45px;">
                                    <div class="Col3">STATEMENT DATE</div>
                                    <div class="Col3"><span id="spStatementDate" runat="server"></span></div>
                                </div>
                                <div style="width:33%;float:left; border-right:1px solid black; height:45px;">
                                    <div class="Col3">PAY THIS AMOUNT</div>
                                    <div class="Col3"><span id="spPayThisAmount" runat="server">$200</span></div>
                                </div>
                                <div style="width:33%;float:left; height:45px;">
                                    <div class="Col3">ACCT.#</div>
                                    <div class="Col3"><span id="spACCT" runat="server">4015</span></div>
                                </div>
                            </div>


                        </div>

                            <div style="width:100%; float:left; height:45px; ">
                                <div style="width:48%; float:left; padding:10px; box-sizing:border-box;">PAGE 1 of 1</div>
                                <div class="AmountPaid"><span>AMOUNT PAID</span>
                                   <span id="TPaidAmount" runat="server" style="width:100%;float:left;"></span>
                                </div>
                            </div>

                    </div>
                    <div class="InvoiceHeaderLower">
                        
                        <div class="ServiceProvider">
                            <div class="SrviceProviderName"><span id="spServiceProviderNameL" runat="server">Service Provider Name</span></div>
                            <div class="SrviceProviderAddress"><span id="spServiceProviderAddressL" runat="server" > Service Provider Address</span></div>
                            <div class="SrviceProviderCity"><span id="spServiceProviderZipL" runat="server">City, State, Zip</span></div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="Seprator">
                <div>---------------------------------------------------------------------------------------------------------------------------------------------</div>
                <div style="font-size:10px;">PLEASE RETURN TOP PORTION WITH YOUR PAYMENT INFORMATION</div>
            </div>

            <div class="InvoiceDetail">
                <div class="DetailHeading">STATEMENT</div>
                <div>
                    
                    <table cellspacing="1" cellpadding="0"  class="StatementTable">
                        <thead>
                            <tr>
                                <th style="width:10%;background-color:lightgray;">DOS</th>
                                <th style="width:15%;background-color:lightgray;">Provider</th>
                                <th style="width:30%;background-color:lightgray;">Service Description</th>
                                <th style="width:10%;background-color:lightgray;">Allowed</th>
                                <th style="width:10%;background-color:lightgray;">Paid</th>                                
                                <th style="width:10%;background-color:lightgray;">Adjusted</th>
                                <th style="width:10%;background-color:lightgray;">Balance</th>                                
                            </tr>
                        </thead>
                        <tbody>
                            

                            <asp:Literal ID="ltStatementTable" runat="server"></asp:Literal>

                        </tbody>
                        
                    </table>


                </div>

            </div>
            
            <div class="InvoiceFooter">

                <div style="width:100%; float:left; text-align:center; border:1px solid black; padding:5px; box-sizing:border-box;">** Payment is due upon receipt. Thank you. **</div>

                <div style="width:68%; float:left; border:1px solid black; margin-top:10px; margin-right:1%;">
                    <div style="width:100%; text-align:center; float:left; padding:5px; box-sizing:border-box; border-bottom:1px solid black;">Message</div>
                    <div style="width:100%; text-align:center; float:left; padding:5px; box-sizing:border-box; height:55px;"><span id="spnMessage" runat="server"></span></div>
                </div>

                <div class="BalancBox">
                    <div class="BalanceRow">
                        <div class="BalanceColumnL">Total Balance</div>
                        <div class="BalanceColumnR"><span id="spTotalBalance" runat="server"></span></div>
                    </div>
                    <div class="BalanceRow">
                        <div class="BalanceColumnL">* Insurance Pending</div>
                        <div class="BalanceColumnR"><span id="spInsurancePending" runat="server"></span></div>
                    </div>
                    <div class="BalanceRow" style="border-bottom:none;">
                        <div class="BalanceColumnL">Amount Due Now</div>
                        <div class="BalanceColumnR" style="font-size:13px;"><span id="spAmountDueNow" runat="server"></span></div>
                    </div>
                </div>

                <div class="PaymentGrid">
                    <%--1--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">Statement Date</div>
                        <div class="PaymentGridRow2"><span id="spStatementDateG" runat="server"></span></div>
                    </div>
                    <%--2--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">Acc#</div>
                        <div class="PaymentGridRow2"><span id="spAccG" runat="server"></span></div>
                    </div>
                    <%--3--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">Current</div>
                        <div class="PaymentGridRow2" style="font-size:13px;"><span id="spCurrentBalanceG" runat="server"></span></div>
                    </div>
                    <%--4--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">30 Days</div>
                        <div class="PaymentGridRow2"><span id="sp30BalanceG" runat="server"></span></div>
                    </div>
                    <%--5--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">60 Days</div>
                        <div class="PaymentGridRow2"><span id="sp60BalanceG" runat="server"></span></div>
                    </div>
                    <%--6--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">90 Days</div>
                        <div class="PaymentGridRow2"><span id="sp90BalanceG" runat="server"></span></div>
                    </div>
                    <%--7--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">120 Days</div>
                        <div class="PaymentGridRow2"><span id="sp120BalanceG" runat="server"></span></div>
                    </div>
                    <%--8--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">Total Balance</div>
                        <div class="PaymentGridRow2" style="font-size:13px;"><span id="spTotalBalanceG" runat="server"></span></div>
                    </div>
                    <%--9--%>
                    <div class="PaymentGridCol">
                        <div class="PaymentGridRow">Ins Pending</div>
                        <div class="PaymentGridRow2"><span id="spInsPendingG" runat="server"></span></div>
                    </div>

                    

                </div>

                
              

                 <div style=" /*width: 54%; float: left; border: 1px solid black; margin-top: 5px; margin-right:1%;*/
    width: 54%;
    float: left;
    border: 1px solid black;
    margin-top: 0px;
    margin-right: 1%;
      height: 104px;
                ">
                     <div style="width:100%; text-align:center; float:left; padding:5px; box-sizing:border-box; border-bottom:1px solid black;">Make Checks Payable To</div>
                    <div class="ServiceProvider">

                         
                        <div class="SrviceProviderName"><span id="spServiceProviderNameLL" runat="server">Service Provider Name</span></div>
                        <div class="SrviceProviderAddress"><span id="spServiceProviderAddressLL" runat="server">Service Provider Address</span></div>
                        <div class="SrviceProviderCity"><span id="spServiceProviderZipLL" runat="server">City, State, Zip</span></div>
                         <div class="otherInfo"><span id="spnOtherInfo" runat="server"></span><b><span id="Spanother2" runat="server"></span></b></div>
                    </div>

                </div>

                <div style="/*width:44%; float:left; border:1px solid black; margin-top:10px;*/
    width: 44%;
    float: left;
    border: 1px solid black;
    margin-top: 1px;
    height: 104px;
">
                    <div style="width:100%; text-align:center; float:left; padding:5px; box-sizing:border-box; border-bottom:1px solid black;">Billing Questions</div>
                    <div style="width:100%; text-align:center; float:left; padding:5px; box-sizing:border-box; height:60px;"><span id="spBillingQuestions" runat="server"></span></div>
                </div>

            </div>

        </div>
        
             
                     <asp:Literal  ID="ltrRandomInfo" runat="server"></asp:Literal>
                    <asp:HiddenField ID="totalPage" runat="server"/>
             <div style="display:none">
                 <span class="spTotalBalanceG3">sa</span>
                 <span class="spTotalBalanceG2">sa</span>
                 
             </div>
                
         <script>
             $(document).ready(function () {

                 //alert($("[id$='spTotalBalanceG']").text());
                 //$(".t1").text($("[id$='spTotalBalanceG']").text());
             });
         </script>    
         <script>

             var page = document.getElementById("totalPage").value;

             if (page > 1) {

                 var x = document.getElementsByClassName("spTotalBalanceG3");

                 //document.getElementById("spTotalBalanceG2").innerHTML = x[0].innerHTML;

             }

         </script> 
        <style type="text/css">
         @media print {
                .MessBord{
                    margin-left:-3px !important;
                }
                .BlnBord{
                    margin-left:3px !important;
                }
            }
            .ui-dialog {
                margin-top: 10% !important;
                top: 0px !important;
            }
        </style>
        
        ####PatientInvoiceEnd####
         </div>
   </form>
</body>
</html>
