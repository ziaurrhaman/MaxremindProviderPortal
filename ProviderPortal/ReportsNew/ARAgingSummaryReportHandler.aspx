<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ARAgingSummaryReportHandler.aspx.cs" Inherits="ProviderPortal_ReportsNew_ARAgingSummaryReportHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###SFIPart###
          <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
            <script>
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                });
            </script>
            <style>
                .HyperlinkClass {
                    text-decoration: underline;
                    color: blue;
                    cursor: pointer;
                }
            </style>

            <div class="GridReports InsuranceDetails" id="printableArea">
                <table class="fixTable">
                    <thead>
                        <tr>
                            <th style="text-align: center !important;">
                                <span class="report-column-title">Type</span>
                            </th>

                            <th>
                                <span class="report-column-title">Current</span>
                            </th>
                            <th>
                                <span class="report-column-title">31-60</span>
                            </th>
                            <th>
                                <span class="report-column-title">61-90</span>
                            </th>
                            <th>
                                <span class="report-column-title">91-120</span>
                            </th>
                            <th>
                                <span class="report-column-title">120+</span>
                            </th>
                            <th>
                                <span class="report-column-title">Total Outstanding</span>
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tbodyReportList">

                        <asp:Repeater ID="rptARAgingSummary" runat="server">
                            <ItemTemplate>
                                <tr class="cpa-trfont">
                                    <td class="HyperlinkClass" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>')" style="text-align: center;"><%# Eval("ARType") %></td>
                                    <td class="HyperlinkClass" style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','030')"><%# Eval("Current","{0:c}") %></td>
                                    <td class="HyperlinkClass" style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','3160')"><%# Eval("31-60","{0:c}") %></td>
                                    <td class="HyperlinkClass" style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','6190')"><%# Eval("61-90","{0:c}") %></td>
                                    <td class="HyperlinkClass" style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','91120')"><%# Eval("91-120","{0:c}") %></td>
                                    <td class="HyperlinkClass" style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','120+')"><%# Eval("120+","{0:c}") %></td>
                                    <td style="text-align: right;" class="HyperlinkClass" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','')"><%# Eval("TotalOutStanding","{0:c}") %></td>
                                </tr>


                            </ItemTemplate>
                        </asp:Repeater>

                        <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
                            <td style="text-align: center;">
                                <label>Grand Total</label></td>

                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txtCurrent"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt3160"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt6190"></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt91120"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt120"></asp:Label>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txtTotalOutStanding"></asp:Label></td>
                        </tr>


                    </tbody>
                </table>
            </div>

            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />

            <input type="hidden" id="hdnAgingType" runat="server" value="0" />
            <input type="hidden" id="hdnPracticeLocationId" runat="server" value="0" />
            <input type="hidden" id="hdnProviderId" runat="server" value="0" />
            <input type="hidden" id="hdnPayerId" runat="server" value="0" />
            <input type="hidden" id="hdnAsof" runat="server" value="0" />


            ###EFIPart###


          ###S2IPart###
            <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
            <script>
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                });
                function RowsChange(pagenumber, sortvalue) {
                    debugger

                    if (pagenumber == undefined) {

                        pagenumber = 0
                    }
                    var paging = true;

                    FilterARInsuranceBilledAs($("#hdnBilledAs").val(), $("#hdnAging").val(), $("#ddlPagingSecondDetail").val(), pagenumber);
                }
            </script>

            <div class="dialogdiv">
                <style>
                    .HyperlinkClass {
                        text-decoration: underline;
                        color: blue;
                        cursor: pointer;
                    }
                </style>


                <div class="exportSummary">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                    <span style="float: left; padding-top: 2px; margin-left: 7px">
                        <select id="AAID" class="custom-export-drop-down" onchange="ExportReportForSummary('AR Aging Insurance Detail',this,'printableAreaIns');">
                            <option>Select</option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>
                    </span>

                </div>

                <div class="Grid" style="height: 400px; overflow-y: scroll; overflow-x: scroll;">
                    <div class="GridReportsSummary" id="printableAreaIns">
                        <table class="fixTable">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th style="text-align: center !important;">
                                        <span class="report-column-title">ClaimId</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Patient</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">DOS</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">FirstBillDate</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">LastBillDate</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">PostDate</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Payers</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Aging</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Procedure Code</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Total Charges</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Patient Payment</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Insurance Payment</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Adjustments</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Total OutStanding</span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList" class="SecondDetail">

                                <asp:Repeater ID="rpt_InsuranceDetail" runat="server">
                                    <ItemTemplate>
                                        <tr class="cpa-trfont">
                                            <td><%# Eval("ROWNUMBER") %></td>
                                            <td style="text-align: center"><%# Eval("ClaimId") %></td>
                                            <%-- <td class="dllPractice_Class" style="text-align:left"><%# Eval("PracticeName") %></td>--%>
                                            <td style="text-align: left"><%# Eval("Patient") %></td>
                                            <td style="text-align: center"><%# Eval("DOS","{0:d}") %></td>
                                            <%--Edit Start By Sarmad Fayyaz 31/01/2020--%>
                                            <td class="FBD" style="text-align: center;"><%# Eval("FirstBillDate","{0:d}") %></td>
                                            <td class="LBD" style="text-align: center;"><%# Eval("LastBillDate","{0:d}") %></td>
                                            <td class="PPD" style="text-align: center;"><%# Eval("ProcPostDate","{0:d}") %></td>
                                            <%--Edit End By Sarmad Fayyaz 31/01/2020--%>
                                            <td style="text-align: left"><%# Eval("Payer") %></td>

                                            <td style="text-align: center"><%# Eval("Aging") %></td>
                                            <td style="text-align: center"><%# Eval("ProcedureCode") %></td>

                                            <td style="text-align: right"><%# Eval("TotalCharges","{0:c}") %></td>
                                            <td style="text-align: right"><%# Eval("PatientPayment","{0:c}") %></td>
                                            <td style="text-align: right"><%# Eval("InsurancePayment","{0:c}") %></td>
                                            <td style="text-align: right"><%# Eval("Adjustments","{0:c}") %></td>
                                            <td style="text-align: right"><%# Eval("TotalOutStanding","{0:c}") %></td>
                                            <td class="dllPatient_Class Ins_TdAction" style="display: none"><%# Eval("PatientName") %></td>
                                        </tr>


                                    </ItemTemplate>
                                </asp:Repeater>

                                <tr class="cpa-trfont" style="background-color: #e8e8e8cc !important;">
                                    <td>
                                        <label>Grand Total</label></td>

                                    <td class="FLP"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    
                                    <td style="text-align: right" id="TotalCharges">
                                        <asp:Label runat="server" ID="txtTotalCharges"></asp:Label>
                                    </td>
                                    <td style="text-align: right" id="PatientPayment">
                                        <asp:Label runat="server" ID="txtPatientPayment"></asp:Label>
                                    </td>
                                    <td style="text-align: right" id="InsurancePayment">
                                        <asp:Label runat="server" ID="txtInsurancePayment"></asp:Label></td>
                                     <td style="text-align: right" id="Adjustments">
                                         <asp:label runat="server" ID="txtAdjustments"></asp:label> </td> 
                                  <%--  <td></td>--%>
                                    <td style="text-align: right" id="TotalOutStanding">
                                        <asp:Label runat="server" ID="txtTotalOutStanding1">100.00%</asp:Label>
                                    </td>
                                    
                                

                                </tr>

                                <tr class="cpa-trfont" style="background-color: #e8e8e8cc !important;">
                                    <td>
                                        <label>Total %</label></td>

                                    <td class="FLP"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                               
                                    
                                    <td style="text-align: right" id="TotalChargesP">
                                        <asp:Label runat="server" ID="txtTotalChargesP"></asp:Label>
                                    </td>
                                    <td style="text-align: right" id="PatientPaymentP">
                                        <asp:Label runat="server" ID="txtPatientPaymentP"></asp:Label>
                                    </td>
                                    <td style="text-align: right" id="InsurancePaymentP">
                                        <asp:Label runat="server" ID="txtInsurancePaymentP"></asp:Label></td>
                                       <td style="text-align: right" id="AdjustmentsP">
                                           <asp:label runat="server" ID="txtAdjustmentsP"></asp:label> </td>
                                    <%--<td></td>--%>
                                    <td style="text-align: right" id="TotalOutStanding1P">
                                        <asp:Label runat="server" ID="txtTotalOutStanding1P">100.00%</asp:Label>
                                    </td>
                                  
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="Report_Footer rpt_footer ARAging_pagination">
                    <div class="Pagination_div rpt_pagination message_box">
                        <span class="iconInfo" style="margin: 4px;"></span>
                        <label class="totalRows" style="float: left; padding-left: 10px; padding-top: 4px;"></label>
                    </div>
                    <div class="Reports_Rows_Per_Page " style="margin-top: 2px; float: left;">
                        <span style="float: left; margin-left: 5px; font-size: 12px; font-weight: 600; padding-top: 7px; box-sizing: border-box;">Show&nbsp;</span>
                        <span style="float: left; padding-top: 2px; margin-left: 7px; margin-right: 5px;">
                            <select id="ddlPagingSecondDetail" onchange="RowsChange();">
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
                <input type="hidden" id="hdnInsRows" runat="server" value="" />
                <input type="hidden" id="hdnBilledAs" runat="server" value="" />
                <input type="hidden" id="hdnAging" runat="server" value="" />


            </div>               
            ###E2IPart###



          ###SPPart###
         <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
            <script>
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                });
            </script>

            <div class="dialogdiv">
                <style>
                    .HyperlinkClass {
                        text-decoration: underline;
                        color: blue;
                        cursor: pointer;
                    }
                </style>


                <div class="exportSummary">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                    <span style="float: left; padding-top: 2px; margin-left: 7px">
                        <select id="ddlPS" class="custom-export-drop-down" onchange="ExportReportForSummary('Patient Detail',this,'printableAreaPS');">
                            <option>Select</option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>
                    </span>


                    <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaPS')">
                        <img src="../../Images/PrintView1.png" alt="img" /></span>

                </div>

                <div class="Grid" style="height: 400px; overflow-y: scroll; overflow-x: scroll;">
                    <div class="GridReportsSummary" id="printableAreaPS">
                        <table class="fixTable">
                            <thead>
                                <tr>
                                    <th style="text-align: center;">#</th>
                                    <th style="text-align: center !important;">
                                        <span class="report-column-title">Patient</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Last Paid Date</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Current</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">31-60</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">61-90</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">91-120</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">120+</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Total Outstainding</span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList" class="ArPatientDetail">

                                <asp:Repeater ID="rpt_Patient" runat="server">
                                    <ItemTemplate>
                                        <tr class="cpa-trfont">
                                            <td style="text-align: center;"><%#Container.ItemIndex+1 %></td>
                                            <td style="text-align: left;"><%# Eval("Patient") %></td>
                                            <td style="text-align: center;"><%# Eval("LastPaidDate","{0:d}") %></td>
                                            <td class="" style="text-align: right;"><%# Eval("Current","{0:c}") %></td>
                                            <td class="" style="text-align: right;"><%# Eval("31-60","{0:c}") %></td>
                                            <td class="" style="text-align: right;"><%# Eval("61-90","{0:c}") %></td>
                                            <td class="" style="text-align: right;"><%# Eval("91-120","{0:c}") %></td>
                                            <td class="" style="text-align: right;"><%# Eval("120+","{0:c}") %></td>
                                            <td style="text-align: right;"><%# Eval("TotalOutStanding","{0:c}") %></td>
                                        </tr>


                                    </ItemTemplate>
                                </asp:Repeater>

                                <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
                                    <td style="text-align: center;">
                                        <label>Grand Total</label></td>
                                    <td></td>
                                    <td></td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label7"></asp:Label>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label8"></asp:Label>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label9"></asp:Label></td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label10"></asp:Label>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label11"></asp:Label>
                                    </td>

                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label12"></asp:Label></td>
                                </tr>
                                <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
                                    <td style="text-align: center;">
                                        <label>Total %</label></td>
                                    <td></td>
                                    <td></td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label13"></asp:Label>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label14"></asp:Label>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label15"></asp:Label></td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label16"></asp:Label>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label17"></asp:Label>
                                    </td>

                                    <td style="text-align: right;">
                                        <asp:Label runat="server" ID="Label18"></asp:Label></td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                                    
                </div>
                <div class="Report_Footer rpt_footer ARAging_pagination">
                    <div class="Pagination_div rpt_pagination message_box">
                        <span class="iconInfo" style="margin: 4px;"></span>
                        <label class="totalRows" style="float: left; padding-left: 10px; padding-top: 4px;"></label>
                    </div>
                    <div class="Reports_Rows_Per_Page " style="margin-top: 2px; float: left;">
                        <span style="float: left; margin-left: 5px; font-size: 12px; font-weight: 600; padding-top: 7px; box-sizing: border-box;">Show&nbsp;</span>
                        <span style="float: left; padding-top: 2px; margin-left: 7px; margin-right: 5px;">
                            <select id="ddlPagingPatientDetail" onchange="RowsChange();">
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
                <input type="hidden" id="hdnPatientDetailRows" runat="server" value="" />

                <input type="hidden" id="hdnAgingType1" runat="server" value="0" />
                <input type="hidden" id="hdnPracticeLocationId1" runat="server" value="0" />
                <input type="hidden" id="hdnProviderId1" runat="server" value="0" />
                <input type="hidden" id="hdnPayerId1" runat="server" value="0" />
                <input type="hidden" id="hdnAsof1" runat="server" value="0" />

                <div id="PatClaimDetailDeiloge"></div>
            </div>
                        <script type="text/javascript">
                            function RowsChange(PageNumber, sortValue) {
                                debugger
                                if (PageNumber == undefined) {
                                    PageNumber = 0
                                }

                                var paging = true;

                                FilterARPatient($("#ddlPagingPatientDetail").val(), PageNumber);
                            }
                        </script>
            ###EPPart###

         ###S2PPart###

         <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
            <script>
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                });
            </script>

            <div class="dialogdiv">
                <style>
                    .HyperlinkClass {
                        text-decoration: underline;
                        color: blue;
                        cursor: pointer;
                    }
                </style>


                <div class="exportSummary">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                    <span style="float: left; padding-top: 2px; margin-left: 7px">
                        <select id="ddlIS" class="custom-export-drop-down" onchange="ExportReportForSummary('Insurance Detail',this,'printableAreaPS');">
                            <option>Select</option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>
                    </span>


                    <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaPS')">
                        <img src="../../Images/PrintView1.png" alt="img" /></span>

                </div>

                <div class="Grid" style="height: 400px; overflow-y: scroll; overflow-x: scroll;">
                    <div class="GridReportsSummary" id="printableAreaPS">
                        <table class="fixTable">
                            <thead>
                                <tr>
                                    <th style="text-align: center !important;">
                                        <span class="report-column-title">ClaimId</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Patient</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">DOS</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">FirstBillDate</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">LastBillDate</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">ProcPostDate</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Aging</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Procedure Code</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Total Charges</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Patient Payment</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Insurance Payment</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Total OutStanding</span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList">

                                <asp:Repeater ID="rptPatClm" runat="server">
                                    <ItemTemplate>
                                        <tr class="cpa-trfont">
                                            <td style="text-align: center"><%# Eval("ClaimId") %></td>
                                            <%-- <td class="dllPractice_Class" style="text-align:left"><%# Eval("PracticeName") %></td>--%>
                                            <td style="text-align: left"><%# Eval("Patient") %></td>
                                            <td style="text-align: center"><%# Eval("DOS","{0:d}") %></td>
                                            <%--Edit Start By Sarmad Fayyaz 31/01/2020--%>
                                            <td class="FBD" style="text-align: center;"><%# Eval("FirstBillDate","{0:d}") %></td>
                                            <td class="LBD" style="text-align: center;"><%# Eval("LastBillDate","{0:d}") %></td>
                                            <td class="PPD" style="text-align: center;"><%# Eval("ProcPostDate","{0:d}") %></td>
                                            <%--Edit End By Sarmad Fayyaz 31/01/2020--%>
                                            <td style="text-align: center"><%# Eval("Aging") %></td>
                                            <td style="text-align: center"><%# Eval("ProcedureCode") %></td>

                                            <td style="text-align: right"><%# Eval("TotalCharges","{0:c}") %></td>
                                            <td style="text-align: right"><%# Eval("PatientPayment","{0:c}") %></td>
                                            <td style="text-align: right"><%# Eval("InsurancePayment","{0:c}") %></td>
                                            <%--<td style="text-align:center"><%# Eval("Adjustments","{0:c}") %></td>--%>
                                            <td style="text-align: right"><%# Eval("TotalOutStanding","{0:c}") %></td>
                                            <td class="dllPatient_Class" style="display: none"><%# Eval("PatientName") %></td>
                                        </tr>


                                    </ItemTemplate>
                                </asp:Repeater>

                                <tr class="cpa-trfont" style="background-color: #e8e8e8cc !important;">
                                    <td>
                                        <label>Grand Total</label></td>

                                    <td class="FLP" style="display: none"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>


                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="txtTotalCharges1"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="PatientPayment1"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="InsurancePayment1"></asp:Label></td>
                                     <%--<td><asp:label runat="server" ID="txtAdjustments"></asp:label> </td> --%>
                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="TotalOutStanding1">100.00%</asp:Label>
                                    </td>


                                </tr>

                                <tr class="cpa-trfont" style="background-color: #e8e8e8cc !important;">
                                    <td>
                                        <label>Total %</label></td>

                                    <td class="FLP" style="display: none"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>

                                    <td></td>
                                    <td></td>
                                    <td></td>


                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="txtTotalChargesP1"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="txtPatientPaymentP1"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="txtInsurancePaymentP1"></asp:Label></td>
                                       <td style="text-align: right">
                                        <asp:Label runat="server" ID="txtAdjustmentsP1"></asp:Label> </td>
                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="txtTotalOutStandingP1">100.00%</asp:Label>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
                <input type="hidden" id="Hidden3" runat="server" value="0" />

            </div>
            ###E2PPart###

        </div>
    </form>
</body>
</html>
