<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentSummaryPrint.aspx.cs" Inherits="ProviderPortal_Payment_CallBacks_PaymentSummaryPrintHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script src="../../Scripts/jquery-1.9.0.js"></script>
      

    <div>
 
                <div>
            ###StartERAClaims###
                    <div id="message">
                       <div class="divMessage" style="display:block ;width:15%;margin-left:37%"></div>
                   </div>
                    <style>
                        #searchbtn
                        {
                            background-image:url("../../Images/SmallSearch.png");
                        }
                        .ui-dialog
                        {
                            top: 103.5px !important;
                        } 

                    </style>
                    <script>
                       
                            debugger;
                            $("[id$=TxtStartDate]").datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                     
                            $("[id$=TxtEndDate]").datepicker({
                                changeMonth: true,
                                changeYear: true
                            });


                            $("[id$=ddldates]").on("change", function () {
                                $(".refresh-red").show();
                                $(".refresh-blue").hide();
                                var option = $("[id$=ddldates]").val();
                                if (option == "SelectDates")
                                {
                                  
                                    $("[id$=TxtStartDate]").attr("disabled", false);
                                    $("[id$=TxtStartDate]").css("background-color", "");
                                    
                                    $("[id$=TxtEndDate]").attr("disabled", false);
                                    $("[id$=TxtEndDate]").css("background-color", "");
                                }
                                else {
                                    $("[id$=TxtStartDate]").attr("disabled", true);
                                    $("[id$=TxtStartDate]").css("background-color", "#d0d4d7");
                                    $("[id$=TxtStartDate]").val("");

                                    $("[id$=TxtEndDate]").attr("disabled", true);
                                    $("[id$=TxtEndDate]").css("background-color", "#d0d4d7");
                                    $("[id$=TxtEndDate]").val("");
                                }
                              
                            });



                    </script>
                     
            <div class="payment-popup-filter" style="height:30px; margin-top:5px;margin-bottom:5px;">

                <table>
                    <tbody>
                        <tr>
                         <td style="width:4%"> 
                            Dates:
                        </td>
                          <td style="width:16%"> 
                           <asp:DropDownList runat="server" ID="ddldates" >
                                <asp:ListItem Value="Select">Select</asp:ListItem>
                               <asp:ListItem Value="SelectDates">Select Dates</asp:ListItem>
                                 <asp:ListItem Value="MonthtoDate">Month to Date</asp:ListItem>
                                 <asp:ListItem Value="LastMonth">Last Month</asp:ListItem>
                               <asp:ListItem Value="YearToDate">Year to Date</asp:ListItem>

                           </asp:DropDownList>
                        </td>
                            <td style="width:4%" class="d-none d-sm-block"> 
                            From:
                        </td>
                          <td style="width:16%"> 
                         <asp:TextBox runat="server" ID="TxtStartDate" palceholder="From" Enabled="false" autocomplete="off" style="background-color:#d0d4d7"></asp:TextBox>
                        </td>
                            <td style="width:4%" class="d-none d-sm-block"> 
                            To:
                        </td>
                          <td style="width:16%"> 
                         <asp:TextBox runat="server" ID="TxtEndDate" palceholder="To" Enabled="false" autocomplete="off" style="background-color:#d0d4d7"></asp:TextBox>
                            
                        </td>
                            <td style="float:left;margin-left:30px;margin-top:5px;">
                             <div style="cursor:pointer"><span>
                                
                                    
                                  <img style="width:20px;" class="refresh-blue"  onclick="PaymentSummarySearch()" src="../../../StyleSheets/fonts/refresh-page-option-Blue.svg"/>
                                    <img style="width:20px;display:none" class="refresh-red"  onclick="PaymentSummarySearch()" src="../../../StyleSheets/fonts/refresh-page-option-Red.svg"/>
                                                        </span>
                           

                                </div>
                            </td>

                       

                        </tr>
                        

                    </tbody>
                </table>


            </div>
          

           <%-- <div style="width: 100%; height:350px; float:left; border:1px solid black;" id="divERAClaimsCheckDetailPrint">--%>
                     <div style="width: 100%; height:350px; float:left; border:1px solid black;" id="PaymentSummaryPrint">
           <div id="PaymentSummary">
                <div  > 
                    <div style="text-align:center" id="summaryhide">
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
                                    <td style="border-top: 1px solid ">
                                        <label style=" font-size:14px ;font-weight:bold"> Total</label>
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
                                    <asp:Label runat="server"  ID="TxtOther">$0.00</asp:Label>
                                         
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
                                    <asp:Label runat="server" ID="TxtUInsurance">Unapplied</asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                    <%-- <asp:Label runat="server" ID=" TxtUInsurance">0.00</asp:Label>--%>
                                       <asp:Label runat="server" ID="uinsu"></asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                  <%--  <asp:Label runat="server" ID=" TxtUOther">0.00</asp:Label>--%>
                                          <asp:Label runat="server" ID="uother">$0.00</asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                     <asp:Label runat="server" ID="TxtUPatient">0.00</asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="border-top:1px solid black">
                                         <asp:Label style=" font-size:14px ;font-weight:bold" id="UTotal" runat="server"> 0.00</asp:Label>
                                         
                                    </td>
                                </tr>
                            </tbody>

                        </table>
                    </div>
                </div>

                <div style="width: 100%; float: left; margin-bottom: 5px;">
                   <div id="GrandTotal"style="width:25%; margin-left:12% ;float:Left; margin-top:20px"> 
                                <table>
                            <tbody style="text-align:left">
                                <tr>
                                    <td style="border-bottom:1px solid black">
                                   
                                    <asp:Label runat="server" ID="Label2" style=" font-size:14px ;font-weight:bold">Grand Total</asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                         <label id="lbl1">Amount</label>
                                    <%-- <asp:Label runat="server" ID=" TxtUInsurance">0.00</asp:Label>--%>
                                        
                                       <asp:Label runat="server" ID="AmountTotal" style="float:right"></asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td style="border-bottom:1px solid black">
                                         <label id="lbl2">Unapplied</label>

                                  <%--  <asp:Label runat="server" ID=" TxtUOther">0.00</asp:Label>--%>
                                          <asp:Label runat="server" ID="UnAppliedTotal" style="float:right">$0.00</asp:Label>
                                    </td>
                                    </tr>
                             
                                 <tr>
                                    <td style="float:right">
                                         <asp:Label style=" font-size:14px ;font-weight:bold;float:right" id="GrandTotals" runat="server"> 0.00</asp:Label>
                                         
                                    </td>
                                </tr>
                            </tbody>

                        </table>
                    </div>






                </div>


</div>
        
            </div>
                <asp:HiddenField runat="server" ID="hdn" />
            ###EndERAClaims###
        </div>
    </div>
    </form>
</body>
</html>
