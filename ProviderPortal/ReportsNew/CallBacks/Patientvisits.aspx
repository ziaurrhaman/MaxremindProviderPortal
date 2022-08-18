<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Patientvisits.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_Patientvisits" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
    <div>
        ###startReport###
        <script src="../js/FilterReports.js"></script>
        <script src="../js/MainReport.js"></script>
        <div class="Filter SearchCriteria" style="display: none;">
                <div class="row">
                    
                        <div class="col-lg-3">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Dates:</span>
                                <select class="" id="ddlSelectDate" onchange="GetDates(this)" style="">
                                    <option value="">Select Date</option>
                                    <option value="today">Today</option>
                                    <option value="CurrentMonth" selected="selected">Month To Date</option>
                                    <option value="LastMonth">Last Month</option>
                                    <option value="L6M">Last 6 Months</option>
                                    <option value="YTD">Year To Date </option>
                                    <option value="LY">Last Year</option>
                                    <option value="FB">From Beginning</option>
                                </select>

                            </div>
                        </div>
                        <div class="col-lg-3 SelectDates" style="padding-bottom: 0px;padding-top:0 !important;">
                            <label style=""><b style="color: black">From:</b></label>
                            <span>
                                <input type="date" id="DateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                            </span>
                            <label><b style="color: black">To:</b></label>
                            <span>
                                <input type="date" style="" id="DateTo" class="Datetxtbox" placeholder="Date To" />
                            </span>
                        </div>
                   <div class="col-lg-3" style="margin-top:0 !important;">
                       <div>
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientVisitsReport(this)" />
                        <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePatientVisitsReport()" disabled/>

                    </div>
                   </div>
                    



                </div>
            </div>
             <div class="WidgetReportContent">
                                        <div style="width: 100%; float: left;">
                                            <div id="divReportListing">
                                                <asp:Repeater ID="rptReportData" runat="server">
                                                    <HeaderTemplate>
                                                        <div class="GridReports" id="printableArea">
                                                            <table>
                                                                <thead>
                                                                      <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'DOS');">
                                                <span class="report-column-title">DOS</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                <span class="report-column-title">Patient ID</span> <span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                <span class="report-column-title">Patient Name</span> <span></span>
                                            </th>                                                    
                                            <th class="asc" onclick="SortReportList(this,'ClaimId');">
                                                <span class="report-column-title">Claim ID</span> <span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'TotalCharges');">
                                                <span class="report-column-title">Total Charges</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Payment');">
                                                <span class="report-column-title">Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Adjustment');">
                                                <span class="report-column-title">Adjustment</span><span></span>
                                            </th>
                                        </tr>
                                                                </thead>
                                                                <tbody id="tbodyReportList" style="border:1px solid #ccc">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                            <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("AppointmentDate")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PATIENTID")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("ClaimId")%>
                                                    </td>
                                                     <td>
                                                        <%# Eval("ClaimTotal")%>
                                                    </td>   
                                                    <td>
                                                        <%# Eval("AmountPaid")%>
                                                    </td> 
                                                    <td>
                                                        <%# Eval("Adjustment")%>
                                                    </td>                                      
                                                </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody>
                                </table>
                            </div>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                         
        <input type="hidden" id="hdnTotalRows" runat="server" value="0"/>
          <input type="hidden" id="hdnReportHtml" runat="server"/>


        <script type="text/javascript">
            var Rows1 = "";
            function RowsChange(PageNumber) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();

                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {

                        Rows: Rows1,
                        PageNumber: pageNumber,
                        //SortBy: _SortBy + " " + _SortByValue,
                        action: "Filter"
                    };

                    debugger
                    Report_ReloadData(_selectedReport_Filter, params, paging);
                }
            }
        </script>
        
    </div>
                                            </div>
                 </div>
        ###endReport###
        </div>
    </form>
</body>
</html>
