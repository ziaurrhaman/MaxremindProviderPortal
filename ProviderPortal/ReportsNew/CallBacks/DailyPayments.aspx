<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyPayments.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_DailyPayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      ###startReport###
                  <div class="AppointmentSummaryfilter" >
                  <span id="lblLocations" class="lblMargin">
                     Date Type
                  </span>
            <span id="ddlLocation" style="float:left">
              <select id="ddlDateType" style="width:100%;">
                                    <option value="CheckIssueDate">Select Date Type</option>
                                    <option value="CheckIssueDate">Payment Date</option>
                                    <option value="PostDate">Post Date</option>
                                </select>
            </span>
                  <span class="lblMargin">
                      Date:
                  </span>
             <span>
              <input type="text" id="dateFrom" class="patientInput" onchange="RowsChange(0);" />
            </span>
                
         </div>

            <div class="GridReports" id="printableArea">
                                <table >
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaymentSource');">
                                                <span class="report-column-title">Payment Source</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                <span class="report-column-title">Payer Name</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaymentMethod');">
                                                <span class="report-column-title">Payment Method</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'CheckNumber');">
                                                <span class="report-column-title">Check/Ref #</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaymentDate');">
                                                <span class="report-column-title">Payment Date</span><span></span>
                                            </th>
                                               <th class="asc" onclick="SortReportList(this,'PaymentDate');">
                                                <span class="report-column-title">Post Date</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaidAmount');">
                                                <span class="report-column-title">Paid Amount</span><span></span>
                                            </th>
                                               <th class="asc" onclick="SortReportList(this,'PaidAmount');">
                                                <span class="report-column-title">Payment Type</span><span></span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyReportList">
                                        <asp:Repeater ID="rptReportData" runat="server" OnItemDataBound="rptReportData_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblPaymentSource"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PayerName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentMethod")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckNumber")%>
                                                    </td>   
                                                     <td>
                                                        <%# Eval("CheckIssueDate")%>
                                                    </td>  
                                                     <td>
                                                        <%# Eval("CreatedDate")%>
                                                    </td>   
                                                    <td>
                                                        <%# Eval("PaymentAmount")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentType")%>
                                                    </td>                                        
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>

        <asp:HiddenField ID="hdnDate" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0"/>

          <script type="text/javascript">
              $(document).ready(function () {
                  $("#dateFrom").datepicker({
                      changeMonth: true,
                      changeYear: true,
                      //yearRange: "1950:" + new Date,
                      minDate: "01/01/1900",
                      maxDate: new Date
                  }).mask("99/99/9999");



                  var date = $("[id$='hdnDate']").val();
                  $("#dateFrom").val(date);
              });
            

              var Rows1 = "";
              function RowsChange(PageNumber, sortValue) {
                  debugger;
                  var params;
                  pageNumber = PageNumber;
                  Rows1 = $("#ddlPaging").val();
                  var DateFrom = $("#dateFrom").val();
                  var paging = true;
                  var DateType = $("#ddlDateType").val();
                  if (_selectedReport_Filter != "") {
                      params = {
                          DateFrom: DateFrom,
                          Rows: Rows1,
                          DateType:DateType,
                          PageNumber: pageNumber,
                          SortBy: sortValue,
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
