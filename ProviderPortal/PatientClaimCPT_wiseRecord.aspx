<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientClaimCPT_wiseRecord.aspx.cs" Inherits="ProviderPortal_PatientClaimCPT_wiseRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/Rizwan/DashboardCharts.js"></script>
    <script src="../../Scripts/Exporting.js"></script>
    <script src="../../Scripts/HighCharts.js"></script>
    <script src="../Scripts/DashboardRPM.js"></script>
    <script src="../Scripts/Common.js"></script>
    <link href="../packages/Font.Awesome.5.15.3/Content/Content/fontawesome.css" rel="stylesheet" />
    <link href="../StyleSheets/DashboardRPM.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.2/jspdf.debug.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       
            ###StartPatient_wiseRecord###
        <div class="report-export">
                   <span style="float: left; margin-left: 5px;padding-top: 7px;box-sizing: border-box;">Export To: &nbsp;</span>                         

             <span style="float: left;padding-top:2px;margin-left:7px">
                  <select id="ddlExportTo" class="custom-export-drop-down" onchange="ExportReportForSummary('PatientClaimCPT_wiseRecord.aspx',this,'CPTWise_Reports')">
                       <option></option>
                       <option value="Excel">Excel</option>
                      <%-- <option value="PDF" >PDF</option>--%>
                       <option value="Word">Word</option>
                  </select>
             </span>              
     </div> 
         <div class="Grid PrintableReports">
             <div class="CPTWise_Reports">
            <table style="width: 100%;" id="tblPatient">
                                    <thead>
                                        <tr>
                                            <th style="width: 2%;">#
                                                
                                            </th>
                                           
                                            <th style="width: 5%" onclick="sortedbyAscDescCLaimRPM(this,'Patient id')">Patient id
                                                 
                                            </th>
                                            <th style="width: 10%" onclick="sortedbyAscDescCLaimRPM(this,'Patient Name')">Patient Name
                                                 
                                            </th>
                                            <th style="width: 6%" onclick="sortedbyAscDescCLaimRPM(this,'DOB')">DOB
                                                 
                                            </th>
                                            <th style="width: 6%" onclick="sortedbyAscDescCLaimRPM(this,'Bill Date')">Gender
                                                 
                                            </th>
                                            <th style="width: 18%" onclick="sortedbyAscDescCLaimRPM(this,'Attending Physician')">Address
                                                 
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Billed As')">Phone No 
                                                 
                                            </th>
                                            
                                            
                                            
                                        </tr>
                                        
                                    </thead>
                                    <tbody id="PatientsList">
                                        <asp:Repeater ID="rptPatient_wiseRecord" runat="server" >
                                            <ItemTemplate>
                                                <tr>
                                                  
                                                    <td><%#Eval("ROWNUMBER")%></td>
                                                    
                                                    <td><%#Eval("PatientId")%></td>
                                                    <td><%#Eval("Patient")%></td>
                                                    <td><%#Eval("DateOfBirth","{0:d}")%></td>
                                                    <td><%#Eval("Gender")%></td>
                                                    <td><%#Eval("Address")%></td>
                                                    <td><%#Eval("PhoneNumber")%></td>
                                                    
                                                   
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                 </div>
             </div>
            ###EndPatient_wiseRecord###

             ###StartClaim_wiseRecord###
        <div class="report-export">
                   <span style="float: left; margin-left: 5px;padding-top: 7px;box-sizing: border-box;">Export To: &nbsp;</span>                         

             <span style="float: left;padding-top:2px;margin-left:7px">
                  <select id="ddlExportTo1" class="custom-export-drop-down" onchange="ExportReportForSummary('PatientClaimCPT_wiseRecord.aspx',this,'CPTWise_Reports')">
                       <option></option>
                       <option value="Excel">Excel</option>
                       <%--<option value="PDF" >PDF</option>--%>
                       <option value="Word">Word</option>
                  </select>
             </span>              
     </div> 
         <div class="Grid PrintableReports">
             <div class="CPTWise_Reports">
            <table style="width: 100%;" id="tblClaim">
                                    <thead>
                                        <tr>
                                            <th style="width: 2%;">#
                                                
                                            </th>
                                           
                                            <th style="width: 5%;" onclick="sortedbyAscDescCLaimRPM(this,'Claim No')">Claim No
                                                
                                            </th>
                                            <th style="width: 5%" onclick="sortedbyAscDescCLaimRPM(this,'Patient id')">Patient id
                                                 
                                            </th>
                                            <th style="width: 10%" onclick="sortedbyAscDescCLaimRPM(this,'Patient Name')">Patient Name
                                                 
                                            </th>
                                            <th style="width: 6%" onclick="sortedbyAscDescCLaimRPM(this,'DOS')">DOS
                                                 
                                            </th>
                                            <th style="width: 6%" onclick="sortedbyAscDescCLaimRPM(this,'Bill Date')">Location
                                                 
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Attending Physician')">Attending Physician
                                                 
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Billed As')">Billed As
                                                 
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Status')">Claim Payer
                                                
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Claim Status')">Claim Status
                                                
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Charges')">Charges
                                                
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Payment')">Payment
                                                
                                            </th>
                                            <th style="width: 16%" onclick="sortedbyAscDescCLaimRPM(this,'BalanceDue')">BalanceDue
                                                
                                            </th>
                                            <th style="width: 16%" onclick="sortedbyAscDescCLaimRPM(this,'Pending Insurance')">ClaimType
                                                
                                            </th>
                                            
                                            
                                            
                                        </tr>
                                        
                                    </thead>
                                    <tbody id="ClaimsList">
                                        <asp:Repeater ID="rptClaim_wiseRecord" runat="server" >
                                            <ItemTemplate>
                                                <tr>
                                                 
                                                    <td><%#Eval("ROWNUMBER")%></td>
                                                    <td><%#Eval("Claimid")%></td>
                                                    <td><%#Eval("PatientId")%></td>
                                                    <td><%#Eval("PatientName")%></td>
                                                    <td><%#Eval("DOS","{0:d}")%></td>
                                                    <td><%#Eval("Location")%></td>
                                                    <td><%#Eval("AttendingPhysician")%></td>
                                                    <td><%#Eval("BilledAs")%></td>
                                                    <td><%#Eval("ClaimPayer")%></td>
                                                    <td><%#Eval("ClaimStatus")%></td>
                                                    <td><%#Eval("Charges")%></td>
                                                    <td><%#Eval("Payment")%></td>
                                                    <td><%#Eval("BalanceDue")%></td>
                                                    <td><%#Eval("ClaimType")%></td>
                                                   
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                 </div>
             </div>
            ###EndClaim_wiseRecord###

                     ###StartCPT_wiseRecord###
        <div class="report-export">
                   <span style="float: left; margin-left: 5px;padding-top: 7px;box-sizing: border-box;">Export To: &nbsp;</span>                         

             <span style="float: left;padding-top:2px;margin-left:7px">
                  <select id="ddlExportTo2" class="custom-export-drop-down" onchange="ExportReportForSummary('PatientClaimCPT_wiseRecord.aspx',this,'CPTWise_Reports')">
                       <option></option>
                       <option value="Excel">Excel</option>
                       <%--<option value="PDF" >PDF</option>--%>
                       <option value="Word">Word</option>
                  </select>
             </span>              
     </div> 
         <div class="Grid PrintableReports">
             <div class="CPTWise_Reports">
            <table style="width: 100%;" id="tblCPT">
                                    <thead>
                                        <tr>
                                            <th style="width: 2%;">#
                                                
                                            </th>
                                            <th style="width: 5%;" onclick="sortedbyAscDescCLaimRPM(this,'Claim No')">Claim No
                                                
                                            </th>
                                            <th style="width: 5%;" onclick="sortedbyAscDescCLaimRPM(this,'Claim No')">CPTCode
                                                
                                            </th>
                                            <th style="width: 5%" onclick="sortedbyAscDescCLaimRPM(this,'Patient id')">Patient id
                                                 
                                            </th>
                                            <th style="width: 10%" onclick="sortedbyAscDescCLaimRPM(this,'Patient Name')">Patient Name
                                                 
                                            </th>
                                            <th style="width: 6%" onclick="sortedbyAscDescCLaimRPM(this,'DOS')">DOS
                                                 
                                            </th>
                                            <th style="width: 6%" onclick="sortedbyAscDescCLaimRPM(this,'Bill Date')">Location
                                                 
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Attending Physician')">Attending Physician
                                                 
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Billed As')">Billed As
                                                 
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Status')">Claim Payer
                                                
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Claim Status')">Claim Status
                                                
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Charges')">Charges
                                                
                                            </th>
                                            <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Payment')">Payment
                                                
                                            </th>
                                            <th style="width: 16%" onclick="sortedbyAscDescCLaimRPM(this,'BalanceDue')">Pending Insurance
                                                
                                            </th>
                                             
                                        </tr>
                                        
                                    </thead>
                                    <tbody id="CPTList">
                                        <asp:Repeater  ID="rptCPT_wiseRecord" runat="server" >
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("ROWNUMBER")%></td>
                                                    <td><%#Eval("Claimid")%></td>
                                                    <td><%#Eval("CPTCode")%></td>
                                                    <td><%#Eval("PatientId")%></td>
                                                    <td><%#Eval("PatientName")%></td>
                                                    <td><%#Eval("DOS","{0:d}")%></td>
                                                    <td><%#Eval("Location")%></td>
                                                    <td><%#Eval("AttendingPhysician")%></td>
                                                    <td><%#Eval("BilledAs")%></td>
                                                    <td><%#Eval("ClaimPayer")%></td>
                                                    <td><%#Eval("ClaimStatus")%></td>
                                                    <td><%#Eval("Charges")%></td>
                                                    <td><%#Eval("Payment")%></td>
                                                    <td><%#Eval("PendingInsurance")%></td>
                                                 
                                                   
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                 </div>
             </div>
            ###EndCPT_wiseRecord###
    </form>
</body>
</html>
