<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientMissingAppointments.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientMissingAppointments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 ###startReport###

                                  <div class="GridReports" id="printableArea">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                <span class="report-column-title">Patient Account</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                <span class="report-column-title">Patient Name</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'TotalAppointments');">
                                                <span class="report-column-title">Total Appointments</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'Completed');">
                                                <span class="report-column-title">Completed</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Missing');">
                                                <span class="report-column-title">Missing</span><span></span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyReportList" style="text-align:center">
                                        <asp:Repeater ID="rptReportData" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("TotalAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CompletedAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("MissingAppointments")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                    
         <asp:HiddenField ID="hdnTotalRows" runat="server" />

          <script type="text/javascript">
              $(document).ready(function () {



                  $(".BalnceDuefilter").css("display", "block");


              });

              var Rows1 = "";
              function RowsChange(PageNumber, sortValue) {
                  debugger;
                  var params;
                  pageNumber = PageNumber;
                  Rows1 = $("#ddlPaging").val();
                  var PatientId = $("#patientId").val();
                  var PatientName = $("#patientName").val();
                  var paging = true;

                  if (_selectedReport_Filter != "") {
                      params = {
                          PatientId: PatientId,
                          PatientName: PatientName,
                          Rows: Rows1,
                          PageNumber: pageNumber,
                          SortBy: sortValue,
                          action: "Filter"
                      };

                      debugger
                      Report_ReloadData(_selectedReport_Filter, params, paging);
                  }
              }
              $("#filterbtn").click(function () {
                  RowsChange(0);
              });
        </script>


 ###endReport###
    </div>
    </form>
</body>
</html>
