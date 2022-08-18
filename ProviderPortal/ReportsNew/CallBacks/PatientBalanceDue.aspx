<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientBalanceDue.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientBalanceDue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 ###startReport###
                     <div class="BalnceDuefilter">
            <span>
              <input type="text" id="patientId" class="patientInput" placeholder="Patient Id"/>
            </span>

             <span>
              <input type="text" id="patientName" class="patientInput" placeholder="Patient Name"/>
            </span>

             <span>
              <input type="button" id="filterbtn" value="Filter"/>
            </span>

        </div>
    
              <div class="GridReports" id="printableArea">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                <span class="report-column-title">Patient ID</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                <span class="report-column-title">Patient Name</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'TotalVisits');">
                                                <span class="report-column-title">Total Visits</span><span></span>
                                            </th> 
                                            <th class="asc" onclick="SortReportList(this,'TotalClaims');">
                                                <span class="report-column-title">Total Claims</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'Charges');">
                                                <span class="report-column-title">Charges</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'InsurancePayment');">
                                                <span class="report-column-title">Insurance Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Adjustment');">
                                                <span class="report-column-title">Adjustment/Write off</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientPayment');">
                                                <span class="report-column-title">Patient Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'BalanceDue');">
                                                <span class="report-column-title">Balance Due</span><span></span>
                                            </th>
                                        <%--    <th>
                                                <span class="report-column-title">View Detail</span><span></span>
                                            </th>--%>
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
                                                        <%# Eval("PatientId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("TotalVisits")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("TotalClaims")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Charges")%>
                                                    </td>
                                                     <td>
                                                        <%# Eval("InsurancePayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Adjustment")%>
                                                    </td>
                                                     <td>
                                                        <%# Eval("PatientPayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("BalanceDue")%>
                                                    </td>
                                                 <%--   <td class="action">
                                                        <div>
                                                            <span title="View" class="spneye" onclick="Report_ViewBalanceDueDetail(this);"></span>
                                                        </div>

                                                        <input type="hidden" class="hdnPatientId" value='<%#Eval("PatientId") %>' />
                                                    </td>--%>
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
             function RowsChange(PageNumber) {
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
                         //SortBy: _SortBy + " " + _SortByValue,
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
