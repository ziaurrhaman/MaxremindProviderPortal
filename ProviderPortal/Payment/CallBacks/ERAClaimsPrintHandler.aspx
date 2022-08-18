<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ERAClaimsPrintHandler.aspx.cs" Inherits="HomeHealth_EpisodeClaims_CallBacks_ERAClaimsPrintHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartERAClaims###
            
          

            <div style="width: 100%; float:left; border:1px solid black; height:500px !important;overflow-y:auto" id="divERAClaimsCheckDetailPrint">
                <style type="text/css">
                    #checkPaymentsDetail td {
                        text-align: center;
                    }

                    #divERAClaimsCheckDetailPrint > div{
                        padding: 10px;
                        box-sizing:border-box;
                    }

                    tr.spanceAbove > td {
                        padding-top: 10px;
                        background-color:#f7f7f7;
                    }

                    tr.spanceBottom > td {
                        padding-top: 10px;
                        padding-bottom:10px;
                        background-color:#f7f7f7;
                    }

                    .tblcheckTotalInfo th {
                        font-weight: bold;
                        padding-bottom: 10px;
                        font-size: 82%;
                    }

                    .tblcheckTotalInfo td {
                        text-align: center;
                    }

                    .claimHeader {
                        width: 100%; 
                        float: left; 
                        padding: 8px;
                        box-sizing:border-box;
                        background-color:lightblue;
                        font-size:85%;
                    }

                    .Bold {
                        font-weight:bold;
                    }

                </style>
                <div style="width: 100%; margin-bottom: 20px; float: left;">
                    <div style="width: 50%; float: left;">
                        <asp:Label runat="server" ID="lblPayerName"></asp:Label><br />
                        <asp:Label runat="server" ID="lblPayerAddress1"></asp:Label><br />
                        <asp:Label runat="server" ID="lblPayerAddress2"></asp:Label>
                    </div>
                    <div style="width: 50%; float: left;">
                    </div>
                </div>

                <div style="width: 100%; margin-bottom: 20px; float: left;">
                    <div style="width: 50%; float: left;">
                        <asp:Label runat="server" ID="lblAgencyName"></asp:Label><br />
                        <asp:Label runat="server" ID="lblAgencyAddress1"></asp:Label><br />
                        <asp:Label runat="server" ID="lblAgencyAddress2"></asp:Label>
                    </div>
                    <div style="width: 50%; float: left;">
                        <div style="float:right;">
                        Provider:
                        <asp:Label runat="server" ID="lblPayerIdentifier"></asp:Label><br />
                        Date:
                        <asp:Label runat="server" ID="lblCheckIssueDate"></asp:Label><br />
                        Check/EFT:
                        <asp:Label runat="server" ID="lblCheckNumber"></asp:Label><br />
                        Check Amount:
                        <asp:Label runat="server" ID="lblCheckAmt" CssClass="Bold"></asp:Label>
                            </div>
                    </div>
                    <div> 
                        Transaction Handling : <asp:Label runat="server" ID="lblTransactionHandlingCode"></asp:Label>
                    </div>
                </div>

                <div style="width: 100%; float: left; margin-bottom: 5px;">
                    <asp:Repeater ID="rptERAClaimsPayments" runat="server" OnItemDataBound="rptERAClaimsPayments_ItemDataBound">
                        <ItemTemplate>
                            <div class="claimHeader">
                                <div style="width: 35%; float: left;">NAME <span style="font-weight: bold; color: blue; text-decoration: underline;"><%# Eval("PatientName") %></span></div>
                                <div style="width: 20%; float: left;">HIC <span style="font-weight: bold;"><%# Eval("HIC") %></span></div>
                                <div style="width: 15%; float: left;">ACNT <span style="font-weight: bold;"><%# Eval("ACNT") %></span></div>
                                <div style="width: 20%; float: left;">ICN <span style="font-weight: bold;"><%# Eval("ICN") %></span></div>
                                <div style="width: 10%; float: left;">ASG <span style="font-weight: bold;"><%# Eval("ASG") %></span></div>
                                <%--<div style="width: 10%; float: left;"><span style="font-weight: bold;"><%# Eval("InsurancePlanCode") %></span></div>--%>
                            </div>
                            <div style="width: 100%; float: left; border-bottom:1px solid black; font-size: 90%;">
                                <table style="width: 100%;">
                                    <thead style="border-bottom: 1px solid black; background-color: #f2f2f1; font-size: 90%; ">
                                        <th style="font-weight: normal; width: 10%;">REND PROV</th>
                                        <th style="font-weight: normal; width: 10%;">SERV DATE</th>
                                        <th style="font-weight: normal; width: 5%;">POS</th>
                                        <th style="font-weight: normal; width: 5%;">NOS</th>
                                        <th style="font-weight: normal; width: 10%;">PROC MODS</th>
                                        <th style="font-weight: normal; width: 8%;">BILLED</th>
                                        <th style="font-weight: normal; width: 8%;">ALLOWED</th>
                                        <th style="font-weight: normal; width: 8%;">DEDUCT</th>
                                        <th style="font-weight: normal; width: 8%;">COINS</th>
                                        <th style="font-weight: normal; width: 10%;">GRP CD</th>
                                        <th style="font-weight: normal; width: 8%;">RC-AMT</th>
                                        <th style="font-weight: normal; width: 10%;">PROV PD</th>
                                    </thead>
                                    <tbody id="checkPaymentsDetail">
                                        <asp:Repeater ID="rptERAClaimPaymentsDetail" runat="server" OnItemDataBound="rptERAClaimPaymentsDetail_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    
                                                    <td></td>
                                                    <td class="itemRow"><%# Eval("ServiceDate") %></td>
                                                    <td></td>
                                                    <td><%# Eval("NOS") %></td>
                                                    <td><%# Eval("ProcedureCode") %></td>
                                                    <td><%# Eval("Billed") %></td>
                                                    <td><%# Eval("Allowed") %></td>
                                                    <td><%# Eval("Deduct") %></td>
                                                    <td><%# Eval("Coins") %></td>
                                                    <td><%# Eval("GRP CD") %></td>
                                                    <td><%# Eval("RCAMT") %></td>
                                                    <td><%# Eval("PROVPD") %></td>

                               
                                                  

                                                </tr>
                                                <tr>
                                                    <td colspan="12">
                                                        <div style="width: 100%; float:left; ">
                                                        
                                                        <div style="width: 100%; float:left;">
                                                            <table style="width: 100%; float:left;">
<%--                                                                <thead style="font-size: 85%;">
                                                                    <th style="font-weight: normal; width: 15%;">GRP-CD</th>
                                                                    <th style="font-weight: normal; width: 9%;">ADJ-CD</th>
                                                                    <th style="font-weight: normal; width: 9%;">ADJ-AMT</th>
                                                                    <%--<th style="font-weight: normal; width: 9%;">ADJ UNT</th>
                                                                    
                                                                </thead>--%>
                                                                <tbody>
                                                                <asp:Repeater ID="rptERAProcedureAdjustments" runat="server" OnItemDataBound="rptERAProcedureAdjustments_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                    
                                                                            <td style="font-weight: normal; width: 10%;"></td>
                                                                            <td style="font-weight: normal; width: 10%;"></td>
                                                                            <td style="font-weight: normal; width: 5%;"></td>
                                                                            <td style="font-weight: normal; width: 5%;"></td>
                                                                            <td style="font-weight: normal; width: 10%;"></td>
                                                                            <td style="font-weight: normal; width: 8%;"></td>
                                                                            <td style="font-weight: normal; width: 8%;"></td>
                                                                            <td style="font-weight: normal; width: 8%;"></td>
                                                                            <td style="font-weight: normal; width: 8%;"></td>
                                                                            <td style="font-weight: normal; width: 10%;"><%# Eval("GROUPCode") %>-<%# Eval("ReasonCode") %></td>
                                                                            <td style="font-weight: normal; width: 8%;"><%# Eval("AdjustmentAmount") %></td>
                                                                            <td style="font-weight: normal; width: 10%;"></td>

                                                                           
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                                    </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    </td>
                                                </tr>

                                            </ItemTemplate>

                                            <FooterTemplate>
                                                <tr class="spanceAbove">
                                                    <td>PT Resp</td>
                                                    <td></td>
                                                    <td colspan="3" style="width:25%;" >CLAIMS TOTAL</td>
                                                    <td>
                                                        <asp:Label ID="lblTotalBilled" runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblTotalAllowed" runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblTotalDeduct" runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblTotalCoins" runat="server"></asp:Label></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:Label ID="lblTotalRCAMT" runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblTotalPROVPD" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr class="spanceBottom">
                                                    <td colspan="3" style="text-align: left; padding-left: 17px;">Adj to Totals:</td>
      
                                                    <td>0.00</td>
                                                    <td>INTEREST</td>
                                                    <td>0.00</td>
                                                    <td colspan="3">LATE FILLING CHARGE</td>
                                                    <td>0.00</td>
                                                    <td>NET</td>
                                                    <td>
                                                        <asp:Label ID="lblTotalNet" runat="server"></asp:Label></td>
                                                </tr>

                                            </FooterTemplate>

                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>


                <div style="width: 100%; float: left; border-bottom: 1px solid black; text-align:center;">
                    <div style="width: 100%; float: left;">
                        <div style="width: 33%; float: left; font-weight:bold;">Reason Code</div>
                        <div style="width: 33%; float: left; font-weight:bold;">Reference</div>
                        <div style="width: 33%; float: left; font-weight:bold;">Adjustment</div>
                    </div>
                    <div style="width: 98%; float: left; padding: 10px 1%;">
                        <asp:Repeater ID="rptProviderAdjustments" runat="server">
                            <ItemTemplate>

                                <div style="width: 100%;">
                                    <div style="width: 33%; float: left;"><%# Eval("AdjustmentReasonCode") %></div>
                                    <div style="width: 33%; float: left;"><%# Eval("Reference") %></div>
                                    <div style="width: 33%; float: left;"><%# Eval("Adjustment") %></div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div style="width: 100%; float: left; margin-top: 10px;">
                    <table class="tblcheckTotalInfo">
                        <thead>
                            <tr>
                                
                                <th>TOTAL NO OF CLMS</th>
                                <th>BILLED AMT</th>
                                <th>ALLOWED AMT</th>
                                <th>DEDUCT AMT</th>
                                <th>COINS AMT</th>
                                <th>TOTAL RC-AMT</th>
                                <th>PROV PD AMT</th>
                                <th>PROV ADJ AMT</th>
                                <th>CHECK</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                
                                <td>
                                    <asp:Literal ID="ltrlNoOfClaims" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltrlTotalBilledAmt" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltrlTotalAllowedAmt" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltrlTotalDeductAmt" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltrlTotalCoinsAmt" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltrlTotalRCAmt" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltrlTotalPROVPDAmt" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltrlTotalPROVADJAmt" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltrlCheck" runat="server"></asp:Literal></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div style="width: 100%; float: left; margin-top: 20px;">
                    <div style="width: 100%; float: left; margin-top: 10px; border-bottom: 1px solid black; border-top: 1px solid black;padding: 15px 0;">
                        <span>Rejection Reason and Adjustment Codes</span>
                    </div>
                    <div style="width: 98%; float: left; padding: 10px 1%;">
                        <asp:Repeater ID="rptRejReasonsAdjCodes" runat="server">
                            <ItemTemplate>
                                <div style="width:100%; float: left;padding: 5px 0;">
                                    <span><%# Eval("AdjustmentReasonCode") + " - " + Eval("CodeDescription") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            ###EndERAClaims###
        </div>

        ###StartEOBDetails###
            <div>
            <div class="Widget" style="float: left; width: 100%;">
                <div id="left" style="float:left;width:50%">
                    <h4>Payment Information</h4>
               <table id="tblNewEOB" class="tblPatientDemographics tblNewEOB" width="100%">
                    <tr style="width: 50%">
                        <td class="tdLabel">Date<span class="spnError"></span>
                            <input type="hidden" id="hdnERAMasterId" runat="server" value="0" />
                        </td>
                        <td>
                            <label id="txtEOBDate" class="required"  runat="server" style="padding: 5px 0.5% !important; width: 50% !important;"  />
                            <input type="hidden" runat="server" id="hdnCheckDate" />
                            <input type="hidden" runat="server" id="hdnPaymentType" />
                        </td>
                    </tr>
                   <tr>
                        <td class="tdLabel">Total Payment Amount<span class="spnError">*</span>
                        </td>
                        <td>
                            <label id="txtEOBAmount" class="required" onkeypress="return ValidateNumber(event)"   runat="server" style="padding: 5px 0.5% !important; width: 50% !important;"  />
                        </td>
                    </tr>
                   <tr>
                        <td class="tdLabel">Payment Type</td>
                        <td style="font-size: 15px;">
                            <asp:label runat="server" ID="lblPaymenttype"></asp:label>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td class="tdLabel">Check Number<span class="spnError">*</span>
                        </td>
                        <td>
                            <label id="txtEOBRefNo" class="required" runat="server" style="padding: 5px 0.5% !important; width: 50% !important;"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel">Method
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblPaymentMethod"></asp:Label>
                            
                        </td>
                    </tr>
                    
                    
                   <tr id="trPaymentReason" style="display:none">
                       <td class="tdLabel"  >Payment Reason</td>
                       <td class="tdLabel" >
                            <select id="ddlPaymentReason" runat="server">
                                <option value="SelfPay">Self Pay</option>
                                <option value="SelfPayOthers">Self Pay Others</option>
                            </select>
                       </td>      
                   </tr>
                   
                   
                    
         </table>
         <%--<div class="PatientArea" style="margin-left: 34%;width: 100%;float: left;">
              <table class="tblNewEOB" id="EOBMultipatient" style="width:100%;float:left">
                       <tbody id="PATList">
                            <asp:Repeater ID="rptEOBERAPatientDetails" runat="server">
                                 <ItemTemplate>
                                   <tr class="PatientId">                                             
                                     <td class="std"><strong class="strongtest"><span class="PatientName"><%# Eval("PatientName") %></span>
                                       <input type="hidden" id="hdnPatientId" value="<%# Eval("PatientId") %>">
                                       <input type="hidden" id="hdnEOBPatientId" value="<%# Eval("EOBPatientId") %>">
                                       <img src="../../Images/crossA.png" class="crossA" title="delete" alt="" onclick="Removetd(this,<%# Eval("PatientId") %>,<%# Eval("EOBPatientId") %>);"/></strong>
                                     </td>                                            
                                   </tr>
                                 </ItemTemplate>
                           </asp:Repeater>
                       </tbody>                          
               </table>
         </div>--%>
                    
                    <h4>Payment Allocation information</h4>
                    <div style="max-height:160px; overflow:scroll" >
                    <asp:Repeater runat="server" ID="RptAllocatedClaimDetails" >
                        <HeaderTemplate>

                        </HeaderTemplate>
                        <ItemTemplate >
                            <table >
                            <tr>
                                <td>
                                    <b>Patient Id-Name</b>
                                </td>
                                <td>
                                    <span><%# Eval("PatientId") %> - <%# Eval("PatientName") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Date Of Service</b></td>
                                <td><span><%# Eval("DATE","{0:d}") %></span></td>
                            </tr>
                            <tr>
                                <td> <b>Claim Id</b></td>
                                <td><span><%# Eval("ClaimId") %></span></td>
                            </tr>
                            <tr>
                                <td><b>Allocated Amount</b></td>
                                <td><span><%# Eval("PaidAmount","{0:c}") %></span></td>
                            </tr>
                                </table>
                             <br />
                             <br />
                             
                        </ItemTemplate>
                    </asp:Repeater>
                        </div>
    </div>
            
                  <div id="Right" style="float:left;width:40%;padding-top: 6px;">
                      
                      <span style="float:left;width: 15%;padding-top: 28px;">
                           
                      </span>
                     <div style="float:left;width:70%">
                          
                      <div class="divUploadfilesDropDown" style="float:left;width:100%;">            
                      <div class="attachfile_div">
                          <span style="float:left;margin-top:7px;">Attach File :</span>  <span class="spnError" style="margin-left: -282px;">*</span> 
                                 <input type="hidden" id="NewEob" value="NewEob"/>
                              <input type="hidden" runat="server" id="hdnUploadedFilesID" />                                
                      </div>
                      
              
                     </div>
                 <div class="UploadFileArea" style="margin-left:14.5%;width: 100%;float: left;margin-top:5px;">
                    <table style="width:100%;float:left">
                        <tbody id="UFileList">
                            <asp:Repeater ID="rptUFileERAEOB" runat="server">
                                 <ItemTemplate>
                                   <tr class="EOBfile">                                             
                                     <td class="std">
                                      <strong class="strongtest"><span class="EOBFileName"><%# Eval("FileName") %></span>
                                         <input type="hidden" id="hdnUploadfileId" value="<%# Eval("UploadFileId") %>">
                                         <input type="hidden" id="hdnERAAttachfileId" value="<%# Eval("ERAAttachfileId") %>">
                                         <input type="hidden" id="hdnFileName" value="<%# Eval("FileName") %>">
                                         <input type="hidden" id="hdnFileLocation" value="<%# Eval("FileLocation") %>">
                                         <img src="../../Images/crossA.png" class="crossA deleteFile" title="Delete" alt="" onclick="Removetd(this,<%# Eval("UploadFileId") %>,'AttachFile');"/>
                                         <img src="../../Images/view.png" class="crossA" title="View" alt="" onclick="ViewFile(this)"/>
                                      </strong>
                                     </td>                                            
                                   </tr>
                                 </ItemTemplate>
                           </asp:Repeater>
                       </tbody>                          
                    </table>
                  </div>
                </div>     
            </div>
                
            </div>
           
            
            </div>    
      <div class="divShowImage" id="divShowImage"></div>



        ###EndEOBDetails###

    </form>
</body>
</html>
