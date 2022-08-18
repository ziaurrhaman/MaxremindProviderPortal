<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterClaimSummaryAndDetail.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterClaimsDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <div>
      ###StartProcedureDetail###
        <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script> 
        <script>
            $(document).ready(function () { 

                $(".fixTable").tableHeadFixer();
            });
        </script>
        <div class="parent">
         <%--  <div style="text-align:center"> <span style="background-color: #aadeff;padding: 5px;">Procedure Detail</span></div>--%>
               <div class="exportSummary">
                   <span style="float: left; margin-left: 5px;padding-top: 7px;box-sizing: border-box;">Export To: &nbsp;</span>                         

             <span style="float: left;padding-top:2px;margin-left:7px">
                  <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('Procedure Detail',this,'printableAreaRDC');">
                       <option></option>
                       <option value="Excel">Excel</option>
                       <option value="PDF" >PDF</option>
                       <option value="Word">Word</option>
                  </select>
             </span>         
                   
                   
                      <span style="margin-left:10px;cursor:pointer;margin-top:5px;position:absolute;" onclick="PrintReoprt('printableAreaRDC')"><img src="../../Images/PrintView1.png" alt="img" /></span>
                        
     </div> 
   
      <div class="Grid GridReports" id="printableAreaRDC"  style="height:400px;overflow-y:auto;width:100% !important;padding-top:0 !important;">
      
        <table class="fixTable">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Patient Name</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Patient DOB</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim Pri Insurance</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim DOS</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Location </span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim Physician</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">CPT Code</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">CPT Charges</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">CPT Allowed</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">CPT Insurance Paid</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Patient Paid</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">CPT Total Paid</span>
                                            </th>

                                           
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyChargedProcedure">
                                        <asp:Repeater id="rptReportData"  runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                  <td><%# Container.ItemIndex + 1 %></td>
                                                    <td class="AlignString">
                                                        <%# Eval("Patient Name")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Patient DOB")%>
                                                    </td>
                                                   
                                                    <td class="AlignDate">
                                                        <%# Eval("Claim Pri Insurance")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("Claim DOS")%>
                                                    </td>
                                                     <td class="AlignString">
                                                        <%# Eval("Service Location")%>
                                                    </td> 
                                                    
                                                    <td class="AlignString">
                                                        <%# Eval("Claim Physician")%>
                                                    </td>
                                                     <td class="AlignString">
                                                        <%# Eval("CPT Code")%>
                                                    </td> 
                                                    <td class="AlignPayment">
                                                        $<%# Eval("CPT Charges","{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("CPT Allowed", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("CPT Insurance Paid", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment ">
                                                        $<%# Eval("Patient Paid", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment ">
                                                        $<%# Eval("CPT Total Paid", "{0:0.00}") %>
                                                    </td>
                                                    
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
    </div>

            </div>
        <div class="Report_Footer rpt_footer ClaimSummaryPagination">
                    <div class="Pagination_div rpt_pagination message_box">
                        <span class="iconInfo" style="margin: 4px;"></span>
                        <label class="totalRows" style="float: left; padding-left: 10px; padding-top: 4px;"></label>
                    </div>
                    <div class="Reports_Rows_Per_Page" style="margin-top: 2px; float: left;">
                        <span style="float: left; margin-left: 5px; font-size: 12px; font-weight: 600; padding-top: 7px; box-sizing: border-box;">Show&nbsp;</span>
                        <span style="float: left; padding-top: 2px; margin-left: 7px; margin-right: 5px;">
                            <select id="ddlClaimSummaryDetail" onchange="RowsChange();">
                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                                <option value="1000000">All</option>

                            </select>
                        </span><span style="float: left; padding-top: 7px; box-sizing: border-box;">&nbsp;Entries</span>
                    </div>
                    <div class="Pagination_div rpt_pagination">


                        <div class="PageButton">
                            <span class="Report_Footer_child btn_report" onclick="LastPage()" title="Last"><i onclick="LastPage()" class="fas fa-angle-right"></i></span>
                            <span class="Report_Footer_child" id="Next" onclick="NextPage()"><i id="filtersubmitright" class="fas fa-angle-double-right"></i></span>

                            <label class="lblTotalPages" id="TotalPages"></label>
                            <label class="rpt-of-pagination">of</label>
                            <input class="txt_page_Number" type="text" value="1" onkeyup="PageNumOnTxt()" />
                            <span class="Report_Footer_child" onclick="PreviousPage()"><i id="filtersubmitleft" class="fas fa-angle-double-left"></i></span>
                            <span class="Report_Footer_child btn_report" onclick="FirstPage()" title="First" style="margin-top: -5px;"><i onclick="FirstPage()" class="fas fa-angle-left"></i></span>
                        </div>
                    </div>
                </div>
                <input type="hidden" id="hdnInsRowsCPT" runat="server" value="" />
                <input type="hidden" id="Hidden2" runat="server" value="" />
                <input type="hidden" id="Hidden3" runat="server" value="" />


                   <script type="text/javascript">
           $(document).ready(function () { $("#fixTable").tableHeadFixer(); });
                   
          function RowsChange(PageNumber, sortValue) {
              debugger
              if (PageNumber == undefined) {

                  PageNumber = 0
              }
              var paging = true;
              if (level == "CLM" || level == "CLMFilter") {
                  level = "CLMFilter";
              }
              else {
                  level = "ProcedureFilter";
              }
              var NoOfRows = $("#ddlClaimSummaryDetail").val();
              claimDetailFilters(PageNumber, NoOfRows, level, type);
                       }
                       </script>   ###EndProcedureDetail###
    
    
   
      ###StartCLMDetail###

       <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script> 
        <script>
            $(document).ready(function () {

                $(".fixTable").tableHeadFixer();
            });
        </script>

        <div class="parent">
         <%-- <div style="text-align:center"> <span style="background-color: #aadeff;padding: 5px;">Claim  Detail</span></div>--%>
               <div class="exportSummary">
                   <span style="float: left; margin-left: 5px;padding-top: 7px;box-sizing: border-box;">Export To: &nbsp;</span>                         

             <span style="float: left;padding-top:2px;margin-left:7px">
                  <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('Claim Detail',this,'printableAreaRDC');">
                       <option></option>
                       <option value="Excel">Excel</option>
                       <option value="PDF" >PDF</option>
                       <option value="Word">Word</option>
                  </select>
             </span>         
                   
                   
                      <span style="margin-left:10px;cursor:pointer;margin-top:5px;position:absolute;" onclick="PrintReoprt('printableAreaRDC')"><img src="../../Images/PrintView1.png" alt="img" /></span>
                        
     </div> 
    
      <div class="Grid GridReports" id="printableAreaRDC"  style="height:400px;overflow-y:auto; width:100% !important;padding-top:0 !important;">
      
        <table class="fixTable">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                           <th class="center" style="width:5%">
                                                <span class="report-column-title">Patient Account</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Patient Name</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Patient DOB</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim Pri Insurance</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim Id</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim DOS</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Primary Status</span>
                                            </th>
                                            <th class="center" style="width:6%">
                                                <span class="report-column-title">Claim Status</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim Location</span>
                                            </th>
                                             <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim Physician</span>
                                            </th>
                                             <%--<th class="center" style="width:5%">
                                                <span class="report-column-title">CPTs</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Billed As</span>
                                            </th>--%>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim Charges</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Total Allowed</span>
                                            </th>
                                            <%--<th class="center" style="width:5%">
                                                <span class="report-column-title">Pri Paid</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Sec Paid</span>
                                            </th>--%>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Insurance Paid</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Patient Paid</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Total Paid</span>
                                            </th>
                                             <%--<th class="center" style="width:5%">
                                                <span class="report-column-title">WriteOffAdjustment</span>
                                            </th>
                                             <th class="center" style="width:5%">
                                                <span class="report-column-title">Total Adjustment</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Balance Due</span>
                                            </th>--%>
                                             <th class="center" style="width:5%">
                                                <span class="report-column-title">Post Date</span>
                                            </th>
                                             <th class="center" style="width:5%">
                                                <span class="report-column-title">Check Date</span>
                                            </th>
                                             <th class="center" style="width:5%">
                                                <span class="report-column-title">Check Number</span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyChargedClm">
                                        <asp:Repeater id="rptclmdetail"  runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                  <td class="AlignPayment">
                                                        <%# Eval("RowNumber")%>
                                                    </td>

                                                    <td class="AlignPayment">
                                                        <%# Eval("Patient Acct")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Patient Name")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("Patient DOB")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Claim Pri Insurance")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Claim ID")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("Claim DOS")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("PrimaryStatus")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("ClaimStatus")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Service Location")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Claim Physician")%>
                                                    </td>
                                                    <%--<td class="AlignPayment">
                                                        <%# Eval("CPTs")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Billed As")%>
                                                    </td>--%>
                                                    <td class="AlignPayment">
                                                        <%# Eval("claim Charges","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Total Allowed","{0:c}")%>
                                                    </td>
                                                    <%--<td class="AlignPayment">
                                                        <%# Eval("Pri Paid","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Sec Paid","{0:c}")%>
                                                    </td>--%>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Insurance Paid","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Patient Paid","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Total Paid","{0:c}")%>
                                                    </td>
                                                    <%--<td class="AlignPayment">
                                                        <%# Eval("WriteOffAdjustment","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Total Adjustments","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Balance Due","{0:c}")%>
                                                    </td>--%>
                                                    <td class="AlignDate">
                                                        <%# Eval("Claim Post Date")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("CheckDate","{0:M/dd/yyyy}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("CheckNumber")%>
                                                    </td>
                                                 
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
    </div>
            </div>
        <div class="Report_Footer rpt_footer ClaimSummaryPagination">
                    <div class="Pagination_div rpt_pagination message_box">
                        <span class="iconInfo" style="margin: 4px;"></span>
                        <label class="totalRows" style="float: left; padding-left: 10px; padding-top: 4px;"></label>
                    </div>
                    <div class="Reports_Rows_Per_Page" style="margin-top: 2px; float: left;">
                        <span style="float: left; margin-left: 5px; font-size: 12px; font-weight: 600; padding-top: 7px; box-sizing: border-box;">Show&nbsp;</span>
                        <span style="float: left; padding-top: 2px; margin-left: 7px; margin-right: 5px;">
                            <select id="ddlClaimSummaryDetail" onchange="RowsChange();">
                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                                <option value="1000000">All</option>

                            </select>
                        </span><span style="float: left; padding-top: 7px; box-sizing: border-box;">&nbsp;Entries</span>
                    </div>
                    <div class="Pagination_div rpt_pagination">


                        <div class="PageButton">
                            <span class="Report_Footer_child btn_report" onclick="LastPage()" title="Last"><i onclick="LastPage()" class="fas fa-angle-right"></i></span>
                            <span class="Report_Footer_child" id="Next" onclick="NextPage()"><i id="filtersubmitright" class="fas fa-angle-double-right"></i></span>

                            <label class="lblTotalPages" id="TotalPages"></label>
                            <label class="rpt-of-pagination">of</label>
                            <input class="txt_page_Number" type="text" value="1" onkeyup="PageNumOnTxt()" />
                            <span class="Report_Footer_child" onclick="PreviousPage()"><i id="filtersubmitleft" class="fas fa-angle-double-left"></i></span>
                            <span class="Report_Footer_child btn_report" onclick="FirstPage()" title="First" style="margin-top: -5px;"><i onclick="FirstPage()" class="fas fa-angle-left"></i></span>
                        </div>
                    </div>
                </div>
                <input type="hidden" id="hdnInsRowsClaimSummary" runat="server" value="" />

                   <script type="text/javascript">
                       function RowsChange(PageNumber, sortValue) {
                           debugger
                           if (PageNumber == undefined) {

                                PageNumber = 0
                            }
                            var paging = true;
                            if (level == "CLM" || level == "CLMFilter") {
                                level = "CLMFilter";
                            }
                            else {
                                level = "ProcedureFilter";
                            }
                            var NoOfRows = $("#ddlClaimSummaryDetail").val();
                            claimDetailFilters(PageNumber, NoOfRows, level, type);
                       }
                   </script>
    ###EndCLMDetail###




       ###StartCLMDetailAfterpagenation###
           
                                        <asp:Repeater id="rptfilterclmdetail"  runat="server">
                                            <ItemTemplate>
                                                <tr runat="server">
                                                  <td class="AlignPayment">
                                                        <%# Eval("RowNumber")%>
                                                    </td>

                                                    <td class="AlignPayment">
                                                        <%# Eval("Patient Acct")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Patient Name")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("Patient DOB")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Claim Pri Insurance")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Claim ID")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("Claim DOS")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("PrimaryStatus")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("ClaimStatus")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Service Location")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Claim Physician")%>
                                                    </td>
                                                    <%--<td class="AlignPayment">
                                                        <%# Eval("CPTs")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Billed As")%>
                                                    </td>--%>
                                                    <td class="AlignPayment">
                                                        <%# Eval("claim Charges","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Total Allowed","{0:c}")%>
                                                    </td>
                                                    <%--<td class="AlignPayment">
                                                        <%# Eval("Pri Paid","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Sec Paid","{0:c}")%>
                                                    </td>--%>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Insurance Paid","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Patient Paid","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Total Paid","{0:c}")%>
                                                    </td>
                                                    <%--<td class="AlignPayment">
                                                        <%# Eval("WriteOffAdjustment","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Total Adjustments","{0:c}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("Balance Due","{0:c}")%>
                                                    </td>--%>
                                                    <td class="AlignDate">
                                                        <%# Eval("Claim Post Date")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("CheckDate","{0:M/dd/yyyy}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        <%# Eval("CheckNumber")%>
                                                    </td>
                                                 
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                   
       ###ENDCLMDetailAfterpagenation###


      ###StartPRODetailAfterpagenation###
                                        <asp:Repeater id="rptProceduredetail"  runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                <td class="AlignString">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Patient Name")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Patient DOB")%>
                                                    </td>
                                                   
                                                    <td class="AlignDate">
                                                        <%# Eval("Claim Pri Insurance")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("Claim DOS")%>
                                                    </td>
                                                     <td class="AlignString">
                                                        <%# Eval("Service Location")%>
                                                    </td> 
                                                    
                                                    <td class="AlignString">
                                                        <%# Eval("Claim Physician")%>
                                                    </td>
                                                     <td class="AlignString">
                                                        <%# Eval("CPT Code")%>
                                                    </td> 
                                                    <td class="AlignPayment">
                                                        $<%# Eval("CPT Charges","{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("CPT Allowed", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("CPT Insurance Paid", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment ">
                                                        $<%# Eval("Patient Paid", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment ">
                                                        $<%# Eval("CPT Total Paid", "{0:0.00}") %>
                                                    </td>
                                                    
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
       ###ENDPRODetailAfterpagenation###

    </div>
    </form>
</body>
</html>
