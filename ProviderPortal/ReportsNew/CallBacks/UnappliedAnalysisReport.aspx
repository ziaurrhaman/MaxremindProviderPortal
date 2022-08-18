<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnappliedAnalysisReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_UnappliedAnalysisReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
        <div class="Filter SearchCriteria" style="display: none">
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
                <div class="col-lg-3 SelectDates" style="padding-bottom: 0px; padding-top: 0 !important;">
                    <label style=""><b style="color: black">From:</b></label>
                    <span>
                        <input type="date" id="DateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                    </span>
                    <label><b style="color: black">To:</b></label>
                    <span>
                        <input type="date" style="" id="DateTo" class="Datetxtbox" placeholder="Date To" />
                    </span>
                </div>

                <div class="col-lg-3" style="margin-top: 0 !important;">
                    <div>
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterUnappliedAnalysisReport()" />
                        <input class="btn primary" type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeUnAppliedAnalysis()" />

                    </div>
                </div>


            </div>

        </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>

            <div class="GridReports" id="printableArea">
                <table>
                    <thead>
                        <tr>
                            <th>
                                <span class="report-column-title">Transaction</span>
                            </th>
                            <th>
                                <span class="report-column-title">Post Date</span>
                            </th>
                            <th>
                                <span class="report-column-title">Payment Id</span>
                            </th>
                            <th>
                                <span class="report-column-title">Type</span>
                            </th>
                            <th>
                                <span class="report-column-title">Payer</span>
                            </th>
                            <th>
                                <span class="report-column-title">Service Date</span>
                            </th>
                            <th>
                                <span class="report-column-title">Claim Id</span>
                            </th>
                            <th>
                                <span class="report-column-title">Patient Name</span>
                            </th>
                            <th>
                                <span class="report-column-title">Amount</span>
                            </th>
                            <th>
                                <span class="report-column-title">Unapplied Balance</span>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="9">
                                <sapn style="float: right;">Begining Unapplied Balance</sapn></th>
                            <th>
                                <sapn style="float: left;" id="BeginingUnappliedBalance">
                                    <asp:Label ID="lblBeginingUnappliedBalance" runat="server"></asp:Label></sapn>
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tbodyReportList" class="Unapplied">
                        <asp:Repeater ID="rptUnappliedAnalysis" runat="server" OnItemDataBound="rptUnappliedAnalysis_ItemDataBound">
                            <ItemTemplate>
                                <td>
                                    <%# Eval("[Transaction]")%>
                                </td>
                                <td>
                                    <%# Eval("PostDate")%>
                                </td>
                                <td>
                                    <%# Eval("PmtId")%>
                                </td>
                                <td>
                                    <%# Eval("[Type]")%>
                                </td>
                                <td>
                                    <%# Eval("Payer")%>
                                </td>
                                <td>
                                    <%# Eval("ServiceDate")%>
                                </td>
                                <td>
                                    <asp:Label ID="lblClaimId" runat="server" Style="font-weight: bold;"></asp:Label>
                                </td>
                                <td>
                                    <%# Eval("PatientName")%>
                                </td>
                                <td>
                                    <asp:Label ID="lblAmt" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblUnappliedBalance" runat="server"></asp:Label>
                                </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    
                                    <tr>
                                        <td colspan="9" style="border-top:1px solid #CCC; border-right:1px solid #CCC;"><sapn style="float:right;">Change in Unaplied Balance</sapn></td>
                                        <td style="border-top:1px solid #CCC;"><asp:Label ID="lblChangeInUnapliedBallance" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="9" style="font-weight:bold; border-top:1px solid #CCC; border-right:1px solid #CCC;"><sapn style="float:right;">Ending Unapplied Balance</sapn></td>
                                        <td style="border-top:1px solid #CCC;"><asp:Label ID="lblEndingUnappliedBalance" runat="server"></asp:Label></td>
                                    </tr>
                                    </tbody>
                                   
                                </FooterTemplate>
                        </asp:Repeater>


                    
                        
                    </tbody>
                </table>
            </div>

            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <input type="hidden" id="hdnPaymentType" runat="server" value="" />
            <input type="hidden" id="hdnDateFrom" runat="server" value="0" />
            <input type="hidden" id="hdnDateTo" runat="server" value="0" />
            <input type="hidden" id="hdnInsuranceId" runat="server" value="" />



            <div id="CustomizeUnAppliedAnalysis" style="display: none; padding: 20px;">
                <div class="row">

                    <div class="col-lg-3" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Dates:</span>
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
                    <div class="col-lg-6 SelectDates" style="padding-bottom: 0px; padding-top: 0px !important;">
                        <label style=""><b style="color: black">From:</b></label>
                        <span>
                            <input type="date" id="CustomizeDateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox" placeholder="Date To" />
                        </span>
                    </div>

                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divInsuranceType">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Insurance Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlInsuranceType">
                                    <asp:DropDownList ID="ddlPaymentType" CssClass="" runat="server" Style="">
                                        <asp:ListItem Value="">Select Payment Type</asp:ListItem>
                                        <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                                        <asp:ListItem Value="Patient">Patient</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="col-lg-6">
                        <div id="divReportPayerScenario" style="padding-bottom: 45px">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Payer Scenario :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPayerScenario',this);">
                                            <div class="selectedText">
                                                All Payer Scenario
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divPayerScenario" class="div-multi-checkboxes-wrapper divPayerScenario" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect">
                                                <ul id="ulMultiPayerScenario">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                            <input type="checkbox" id="chkPayerScenarioAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                            <span>All Payer Scenario</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptPayerScenario">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label name='<%#Eval("InsuranceId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkPayerScenario chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("InsuranceId") %>' />
                                                                    <span><%#Eval("Name") %></span>
                                                                    <input type="hidden" value='<%#Eval("InsuranceId") %>' id="InsuranceId" />
                                                                </label>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
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
                                        DateFrom: DateFrom,
                                        DateTo: DateTo,
                                        Insurance: $("[id$='hdnPayer']").val(),
                                        PaymentType: $("[id$='hdnPaymentType']").val(),
                                        Rows: Rows1,
                                        PageNumber: pageNumber,
                                        SortBy: sortValue,
                                        action: "Filter"
                                    };

                                    debugger
                                    Report_ReloadData(_selectedReport_Filter, params, paging);
                                }
                            }
                            $('.SelectFilterMessage').css("display", "none")
                            $('.message').css("display", "none")


                        </script>
            ###endReport###
        </div>
    </form>
</body>
</html>
