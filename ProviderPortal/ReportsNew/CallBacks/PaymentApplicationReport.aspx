<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentApplicationReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PaymentApplicationReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
             <style>
   /*           #tbodyReportList td {
    border:none !important;*/
}
            /*  #CheckNumber_th{
                  margin-right: 40px !important;
              }*/
            </style>
           <div class="Filter SearchCriteria" style="display: none;">
               <div class="row">
                   <div class="col-lg-3" style="">
                       <div class="divBranchName" style="">
                           <span class="spnBranchName" style="">Post Dates:</span>
                           <div class="BranceInput" style="">
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
                   </div>
                   <div class="col-lg-4 SelectDates" style="padding-bottom: 0px; padding-top: 0 !important;">
                       <label style=""><b style="color: black">From:</b></label>
                       <span>
                           <input type="date" id="DateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                       </span>
                       <label><b style="color: black">To:</b></label>
                       <span>
                           <input type="date" style="" id="DateTo" class="Datetxtbox" placeholder="Date To" />
                       </span>
                   </div>

                   <div class="col-3" style="margin-top: 36px;">
                       <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPaymentApplicationReport()" />
                       <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePaymentApplicationReport()" />

                   </div>
               </div>
           </div>


        </div>
         <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
        <asp:Repeater ID="rptPaymentApplication" runat="server" OnItemDataBound="rptPaymentApplication_ItemDataBound">
            <HeaderTemplate>
                <div class="GridReports" id="printableArea">
                    <table>
                        <thead>
                            <tr>
                                <%--<th>

                                    <span class="report-column-title">#</span>
                                </th>--%>
                                <th>
                                    <span class="report-column-title" id="CheckNumber_th">Check Number</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Patient Name</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Claim Id</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Service Date</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Procedure Code</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Post Date</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Orig Charge</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Balance Forward</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Adjustment</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Payment</span>
                                </th>
                                <th>
                                    <span class="report-column-title">Balance</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody id="tbodyReportList">
            </HeaderTemplate>
            <ItemTemplate>
              
                    
                  <tr id="checknumber" runat="server">
                    <%--  <td style="text-align: center;">
                        <%# Eval("RowNumber")%>
                    </td>--%>
                    <td style="font-weight:bold; padding-left: 50px !important;"  >
                         <asp:Label ID="Checknumber_numbers" runat="server"></asp:Label>
                        <%# Eval("CheckNumber")%>
                    </td>
                    </tr>
                <tr>
                    <%-- <td style="text-align: center;">
                        <%# Eval("RowNumber")%>
                    </td>--%><td></td>
                    <td style="padding-left: 40px !important; font-weight:bold;">
                          <asp:Label ID="patient_numbers" runat="server"></asp:Label>
                      <%--  <%# Eval("Patient")%>--%>
                    </td>
                    <td>
                        <%# Eval("ClaimId")%>
                    </td>
                    <td>
                        <%# Eval("servicedate")%>
                    </td>
                    <td>
                        <%# Eval("ProcCode")%>
                    </td>
                    <td style="text-align: center;">

                        <asp:Label ID="lblPostDate" runat="server"></asp:Label>
                        <asp:Label ID="lblSubTotal" runat="server" Style="font-weight: bold;"></asp:Label>
                        <asp:Label ID="lblChkGrandTotal" runat="server" Style="font-weight: bold;"></asp:Label>
                        <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight: bold;"></asp:Label>
                    </td>
                    <td>
                        <%# Eval("OrigCharge")%>
                    </td>
                    <td>
                        <%# Eval("BalanceForward")%>
                    </td>

                    <td>
                        <%# Eval("Adjustment")%>
                    </td>
                    <td>
                        <%# Eval("Payment")%>
                    </td>
                    <td>
                        <%# Eval("Balance")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                                   
                                </table>
                            </div>
            </FooterTemplate>
        </asp:Repeater>
        <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
        <asp:HiddenField runat="server" ID="hdnTimeSpan" />
        <asp:HiddenField runat="server" ID="hdnDateFrom" />
        <asp:HiddenField runat="server" ID="hdnDateTo" />
        <asp:HiddenField runat="server" ID="hdnPayerName" />
        <asp:HiddenField runat="server" ID="hdnCheckNumber" />
        <asp:HiddenField runat="server" ID="hdnPostDate" />

        <script>
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();
                var DateFrom = $("[id$='hdnDateFrom']").val();
                var DateTo = $("[id$='hdnDateTo']").val();
                var paging = true;



                if (_selectedReport_Filter != "") {
                    params = {
                        PayerName: $("[id$='hdnPayerName']").val(),
                        CheckNumber: $("[id$='hdnCheckNumber']").val(),
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
                        Rows: Rows1,
                        PageNumber: pageNumber,
                        SortBy: sortValue,
                        action: "Filter"
                    };

                    debugger
                    Report_ReloadData(_selectedReport_Filter, params, paging);
                }
            }
        </script>
        <div style="display: none; padding: 20px;" id="CustomizePaymentApplicationReport">

            <div class="row">
                <div class="col-md-4">
                    <div class="divBranchName" style="">
                        <label class="spnBranchName" >Post Dates:</label>
                        <div class="BranceInput">
                            <select class="" id="ddlSelectDateCustomize" onchange="GetDatesCustomize(this)" style="">
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
                </div>
                <div class="col-md-8 SelectDates" style="padding-bottom: 0px; padding-top: 20px !important;">
                    <label style=""><b style="color: black">From:</b></label>
                    <span>
                        <input type="date" id="CustomizeDateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                    </span>
                    <label><b style="color: black">To:</b></label>
                    <span>
                        <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox" placeholder="Date To" />
                    </span>
                </div>
                 <div class="col-md-4">
                <div id="divPayersName" style="">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Insurance:</span>
                        <div class="clsPayerName BranceInput">
                            <asp:DropDownList ID="CustomizePayersName" CssClass="ddlPayerName" runat="server" Style="" onchange="GetPayerDropDown('divddlCheckNumber');">
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
            </div>
              
            <div class="col-md-3">
                <div id="divCheckNumber" runat="server" style="">

                    <div class="divBranchName">
                        <span class="spnBranchName" style="">Check Number:</span>
                        <div class="clsCheckNumber BranceInput" id="divddlCheckNumber">
                            <asp:DropDownList ID="ddlCheckNumber" CssClass="ddlCheckNumber" runat="server" Style="">
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-md-5" style="position: relative;">
                        <div id="divPatientSarch" runat="server" style="">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Patient Name:</span>
                            <div class="clsPatientId BranceInput" style="position:relative;">
                                <input type="text" id="TxtPatientSearch" onkeyup="searchPatient(event,this)" />
                                <%--<img src="../../Images/arrow_down5.PNG" style="width: 11px; margin-top: 11px; top:27px; right: 5px; position: absolute;" onclick="searchPatient(event,this)" />--%>
                                <input type="hidden" id="hdnsearchpatientid" />
                                <div id="SearchPatientList" class="PatientDetailsRptGrid" style="display: none"></div>
                            </div>
                        </div>
                    </div>   
                    </div>
                  </div>
        </div>
        ###endReport###
    
    </form>
</body>
</html>
