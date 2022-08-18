<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentsDetailReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PaymentsDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script src="../js/MainReport.js"></script>
        <script src="../js/SummaryReports.js"></script>
        <script src="../js/FilterReports.js"></script>
        <div>
            ###startReport###
              <div class="Filter SearchCriteria">
                  <div class="row">
                      <div class="col-lg-3" style="padding-bottom: 0px;">
                          <div class="divBranchName" style="">
                              <span class="spnBranchName" style="">Check Date:</span>
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
                      <%--<div class="col-lg-3 SelectDates" style="padding-top: 0px">
                <span>From:   
                                <asp:TextBox runat="server" ID="DateFrom" CssClass="datepicker margin_R10 margin_L10" Enabled="false" Style="width: 80px !important"></asp:TextBox>
                </span>

                <span>To:   
                                <asp:TextBox runat="server" ID="DateTo" CssClass="datepicker margin_R10 margin_L10" Enabled="false" Style="width: 80px !important"></asp:TextBox>
                </span>
            </div>--%>

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






                      <div class="col-lg-3">
                          <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPaymentsDetail(this)" />
                          <input class='btn primary' type="button" title="Customize" value="Customize" id="CustomizeReports" onclick="CustomizePaymentsDetail(this)" />



                      </div>
                  </div>
              </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <div class="WidgetReportContent" id="printableArea">
                <div style="width: 100%; float: left;">
                    <div id="divReportListing" class="GridReports">

                        <asp:Repeater ID="rptPaymentsDetail" runat="server">
                            <HeaderTemplate>
                                <div class="ReportGrid">
                                    <table style="text-align: center;">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <span class="report-column-title">#</span><span></span>
                                                </th>
                                                <th class="asc" onclick="SortReportList(this,'PaymentId');">
                                                    <span class="report-column-title">Check Number</span><span></span>
                                                </th>
                                                <th class="asc" onclick="SortReportList(this,'PostDate');">
                                                    <span class="report-column-title">Post Date</span><span></span>
                                                </th>
                                                <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                    <span class="report-column-title">Payer Name</span><span></span>
                                                </th>
                                                <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                    <span class="report-column-title">Payment Type</span>
                                                </th>
                                                <th class="asc" onclick="SortReportList(this,'Amount');">
                                                    <span class="report-column-title">Amount</span><span></span>
                                                </th>
                                                <th class="asc" onclick="SortReportList(this,'Unapplied');">
                                                    <span class="report-column-title">Unapplied</span><span></span>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbodyReportList">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="text-align: center;">
                                        <%# Eval("RowNumber")%>
                                    </td>
                                    <td>
                                        <%# Eval("PaymentId")%>
                                    </td>
                                    <td>
                                        <%# Eval("PostDate")%>
                                    </td>
                                    <td>
                                        <%# Eval("PayerName")%>
                                    </td>
                                    <td>
                                        <%# Eval("PaymentType")%>
                                    </td>
                                    <td>
                                        <%# Eval("[Amount]")%>
                                    </td>
                                    <td>
                                        <%# Eval("Unapplied")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                   
                                </table>
                            </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnReportHtml" runat="server" />
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <div id="divDialogReportFilters" style="display: none;"></div>


            <script type="text/javascript">
                debugger;
                var Rows1 = "";
                function RowsChange(PageNumber) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        params = {
                            Payers: $("[id$='hdnInsuranceID']").val(),
                            DateFrom: $("[id$='hdnDateFrom']").val(),
                            DateTo: $("[id$='hdnDateTo']").val(),
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            Paymentid: $("[id$='hdnCheckNo']").val(),
                            PaymentType: $("[id$='hdnPaymentType']").val(),
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }


                }

            </script>
            <div style="display: none; padding: 20px;" id="CustomizePaymentDetailFilter">


                <div class="row">
                    <div class="col-lg-6" style="padding-bottom: 5px;">

                        <div class="" id="divReportFilterBy">
                            <div id="div1" runat="server">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Payment Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType">
                                    <asp:DropDownList ID="ddlPaymentType" CssClass="ddlPaymentType" runat="server" Style="">
                                        <asp:ListItem Value="">Select Payment Type</asp:ListItem>
                                        <asp:ListItem Value="EOB">EOB</asp:ListItem>
                                        <asp:ListItem Value="ERA">ERA</asp:ListItem>
                                        <asp:ListItem Value="PAT">PAT</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Dates:</span>
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

                     <div class="col-lg-3" style="padding-bottom: 5px;">
                        
                            <span class="spnBranchName" style="">From:</span>
                          <div class="BranceInput">
                           <input type="date" id="CustomizeDateFrom" class="Datetxtbox CustomizeDate" style="width:100%;" placeholder="Date From" />

                        </div>
                    </div>

                      <div class="col-lg-3" style="padding-bottom: 5px;">
                           <span class="spnBranchName" style="">To:</span>
                         <div class="BranceInput">
                           
                           
                             <input type="date" style="width:100%;" id="CustomizeDateTo" class="Datetxtbox CustomizeDate" placeholder="Date To" />
                        </div>
                    </div>


                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divReportPayerScenario">
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
                                            <ul id="ulMultiPayerScenario" class="DuplicateChecksSelfPay">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this),GetCheckNo()" style="float: left;">
                                                        <input type="checkbox" id="chkPayerScenarioAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                        <span>All Payer Scenario</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptPayerScenario">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label onclick="Report_ClickMultiCheckBox(this),GetCheckNo()" style="float: left;">
                                                                <input type="checkbox" class="chkPayerScenario chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("Name") %>' />
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
                    <div class="col-lg-6">
                        <div id="divCheckNumber">
                            <div class="divBranchName">
                                <span class="spnBranchName" style="">Check Number:</span>
                                <div class="clsCheckNumber BranceInput" id="divdllCheckNumber">
                                    <asp:DropDownList ID="ddlCheckNumber" CssClass="ddlCheckNumber" runat="server" Style="float: left; width: 100%; margin-top: -0.8%;" >
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            ###endReport###
        </div>
    </form>
</body>
</html>
