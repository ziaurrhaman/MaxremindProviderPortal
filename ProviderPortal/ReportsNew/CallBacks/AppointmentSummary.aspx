<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppointmentSummary.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_AppointmentSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###startReport###
         <div class="Filter SearchCriteria" style=" height: auto !important;">
        


          <div class="AppointmentSummaryfilter" >
              <div class="row">
                   <div class="col-lg-3">
                   
                        <div class="divBranchName" style="">
                            <span id="lblLocations" class="spnBranchName" style="float: left; margin-left: 0%;">Locations:</span>
                            <div class="clsPatientId BranceInput" id="ddlLocation">
                                 <asp:DropDownList runat="server" ID="ddlPracticeLocations" AppendDataBoundItems="true">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                            </asp:DropDownList>
                            </div>
                        </div>
                 
                    </div>
                   <div class="col-lg-3 SelectDates" style="padding-bottom: 0px; padding-top: 0 !important;">
                            <label style=""><b style="color: black">From:</b></label>
                            <span>
                                <input type="text" id="dateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                            </span>
                            <label><b style="color: black">To:</b></label>
                            <span>
                                <input type="text" style="" id="dateTo" class="Datetxtbox" placeholder="Date To" />
                            </span>
                        </div>

                  <div class="col-lg-3" style="margin-top:0 !important;">
                       <input class='btn primary' type="button" title="Filter" value="Filter" id="filterbtnAppointment" / style="margin-top:0 !important;">
                    
                  </div>
                 



                  

<%--                  <span class="lblMargin">
                      Date From:
                  </span>
             <span>
              <input type="text" id="" class="patientInput" />
            </span>
                  <span class="lblMargin">
                      Date To:
                  </span>
              <span>
              <input type="text" id="" class="patientInput"/>
            </span>--%>
             

        </div>
        </div>
        </div>






             <div class="GridReports" id="printableArea">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'AppointmentDate');">
                                                <span class="report-column-title">Appointment Date</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Location');">
                                                <span class="report-column-title">Location</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'TotalAppointments');">
                                                <span class="report-column-title">Total Appointments</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'Completed');">
                                                <span class="report-column-title">Completed</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Pending');">
                                                <span class="report-column-title">Pending</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'No-Show');">
                                                <span class="report-column-title">No-Show</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Checked-In');">
                                                <span class="report-column-title">Checked-In</span><span></span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyReportList" style="text-align:center;">
                                        <asp:Repeater ID="rptReportData" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("AppointmentDate")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Location")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("TotalAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CompletedAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PendingAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("NoShowAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckedInAppointments")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>

         <input type="hidden" id="hdnTotalRows" runat="server"/>

           <script type="text/javascript">
               //Added by Syed Sajid Ali Des:Check Validation for Dates Date:04-24-2019
               function CheckDates() {
                   debugger;
                   var from = new Date(Date.parse($("#dateFrom").attr("value")));
                   var to = new Date(Date.parse($("#dateTo").attr("value")));
                   if (from > to) {
                       $("#dateTo ").val("");
                       showErrorMessage("To Date Cannot be less than From Date!");
                       return;
                   }
               }
               //End By Syed Sajid Ali

               $(document).ready(function () {
                   $("#dateFrom").datepicker({
                       changeMonth: true,
                       changeYear: true,
                       //yearRange: "1950:" + new Date,
                       minDate: "01/01/1900",
                       maxDate: new Date,
                       onSelect: function () {
                           CheckDates();
                       },
                   }).mask("99/99/9999");

                   $("#dateTo").datepicker({
                       changeMonth: true,
                       changeYear: true,
                       //yearRange: "1950:" + new Date,
                       minDate: "01/01/1900",
                       maxDate: new Date,
                       onSelect: function () {
                           CheckDates();
                       },
                   }).mask("99/99/9999");


                   $(".AppointmentSummaryfilter").css("display", "block");


               });

               var Rows1 = "";
               function RowsChange(PageNumber) {
                   debugger;
                   var params;
                   pageNumber = PageNumber;
                   Rows1 = $("#ddlPaging").val();
                   var Location = $("[id$='ddlPracticeLocations']").val();
                   var DateFrom = $("#dateFrom").val();
                   var DateTo = $("#dateTo").val();
                   var paging = true;

                   if (_selectedReport_Filter != "") {
                       params = {
                           Location: Location,
                           DateFrom: DateFrom,
                           DateTo:DateTo,
                           Rows: Rows1,
                           PageNumber: pageNumber,
                           //SortBy: _SortBy + " " + _SortByValue,
                           action: "Filter"
                       };

                       debugger
                       Report_ReloadData(_selectedReport_Filter, params, paging);
                   }
               }
               $("#filterbtnAppointment").click(function () {
                   RowsChange(0);
               });
        </script>



         ###endReport###
    </div>
    </form>
</body>
</html>
