<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppointmentsDetailReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_AppointmentsDetailReport" %>

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
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                
                                                    <th class="asc" onclick="SortReportList(this,'Start/End');">
                                                        <span class="report-column-title">Start/End</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AppointmentDate');">
                                                        <span class="report-column-title">Appointment Date</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Provider');">
                                                        <span class="report-column-title">Provider</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Patient </span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'DateOfBirth');">
                                                        <span class="report-column-title">DateOfBirth</span><span class="filterIcon asc"></span>
                                                    </th>
                                                     <th class="asc" onclick="SortReportList(this,'Phone');">
                                                        <span class="report-column-title">Phone</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'HomePhone');">
                                                        <span class="report-column-title">HomePhone</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'location');">
                                                        <span class="report-column-title">location</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Description');">
                                                        <span class="report-column-title">Description</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Status');">
                                                        <span class="report-column-title">Status</span><span></span>
                                                    </th>

                                                     <th class="asc" onclick="SortReportList(this,'Status');">
                                                        <span class="report-column-title">Copay</span><span></span>
                                                    </th>

                                                      <th class="asc" onclick="SortReportList(this,'Status');">
                                                        <span class="report-column-title">P.Bal</span><span></span>
                                                    </th>

                                                    <th class="asc" onclick="SortReportList(this,'Notes');">
                                                        <span class="report-column-title">Notes</span><span></span>
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
                                            <%# Eval("StartandEndTime")%>
                                        </td>
                                        <td>
                                            <%# Eval("AppointmentDate","{0:d}")%>
                                        </td>
                                        <td>
                                            <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                            <%# Eval("Patient")%>
                                        </td>
                                        <td>
                                            <%# Eval("DateOfBirth","{0:d}")%>
                                        </td>
                                        <td>
                                            <%# Eval("Phone")%>
                                        </td>
                                        <td>
                                            <%# Eval("HomePhone")%>
                                        </td>
                                         <td>
                                            <%# Eval("Name")%>
                                        </td>
                                         <td>
                                            <%# Eval("[Description]")%>
                                        </td>
                                       
                                        <td>
                                            <%# Eval("StatusName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Copay")%>
                                        </td>
                                        <td>
                                              <%# Eval("[Patient-Bal]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Notes")%>
                                        </td>
                                    </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
         <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
        <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
     <asp:HiddenField runat="server" ID="hdnDateType" />
      <asp:HiddenField runat="server" ID="hdnPatient" />
          <asp:HiddenField runat="server" ID="hdnProviderId" />
          <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
          <asp:HiddenField runat="server" ID="hdnStatus" />
          <asp:HiddenField runat="server" ID="hdnReasons" />


                   <script type="text/javascript">
                     
                       var Rows1 = "";
                       function RowsChange(PageNumber) {
                           debugger;
                           var params;
                           pageNumber = PageNumber;
                           Rows1 = $("#ddlPaging").val();
                           var PracticeLocationId = $("[id$='hdnPracticeLocationId']").val();
                           var DateFrom = $("[id$='hdnDateFrom']").val();
                           var DateTo = $("[id$='hdnDateTo']").val();
                           var DateType = $("[id$='hdnDateType']").val();
                           var PatientIds = $("[id$='hdnPatient']").val();
                           var ProviderId = $("[id$='hdnProviderId']").val();
                           var Status = $("[id$='hdnStatus']").val();
                           var Reasons = $("[id$='hdnReasons']").val();
                           var paging = true;

                           if (_selectedReport_Filter != "") {
                               params = {
                                   PracticeLocationId: PracticeLocationId,
                                   DateFrom: DateFrom,
                                   DateTo: DateTo,
                                   DateType: DateType,
                                   PatientIds: PatientIds,
                                   ProviderId:ProviderId,
                                   Status: Status,
                                   Reasons:Reasons,
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


      ###endReport###
    </div>
    </form>
</body>
</html>
