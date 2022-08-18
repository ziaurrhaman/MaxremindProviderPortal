<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DuplicateChecks.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_DuplicateChecks" %>

<!DOCTYPE html>
<%--/// Modified By Irfan Mahmood 01/Jan/2022--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
                              <div class="Filter SearchCriteria">

                                  <div class="row">
                                      <div class="col-lg-3" style="padding-bottom: 5px;">
                                          <div class="divBranchName" style="">
                                              <span class="spnBranchName" style="">Dates:</span>
                                              <div class="BranceInput">
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
                                      <div class="col-lg-3 SelectDates" style="padding-bottom: 0px; padding-top: 0px !important;">
                                          <label style=""><b style="color: black">From:</b></label>
                                          <span>
                                              <input type="date" id="DateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                                          </span>
                                          <label><b style="color: black">To:</b></label>
                                          <span>
                                              <input type="date" style="" id="DateTo" class="Datetxtbox" placeholder="Date To" />
                                          </span>
                                      </div>
                                      <div class="col-lg-3" style="margin-top: 6px !important;">
                                          <div>
                                              <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterDuplicateChecks()" />
                                              <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeDuplicateChecks()" />

                                          </div>
                                      </div>
                                  </div>

                              </div>
            <div class="TimeSpan">
                <span style="font-weight: 600; color: black">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan" Style="color: grey"></asp:Label>

            </div>
            <script src="../../AdminPanel/js/tableHeadFixer.js" type="text/javascript"></script>

            <div class="DivForPrintExcel" style="display: none"></div>
            <div class="Grid GridReports" id="printableArea">
                <div class="department_table scroll fixTable" id="DuplicateChecks">
                    <table border="1" style="width: 100%; text-align: center !important; border-color: #afdbec;" class="fixTable">
                        <thead style="border: 1PX SOLID WHITE; color: black">
                            <tr style="background-color: #aadeff;">
                                <th class="center" style="width: 1%">
                                    <span class="report-column-title">#</span>
                                </th>
                                <th class="center" style="width: 3%">
                                    <span class="report-column-title">CheckNumber</span>
                                </th>
                                <th class="center" style="width: 3%">
                                    <span class="report-column-title">Payment Amount</span>
                                </th>
                                <th class="center" style="width: 2%">
                                    <span class="report-column-title">Payment Posted</span>
                                </th>
                                <th class="center" style="width: 1%">
                                    <span class="report-column-title">Payment Type</span>
                                </th>
                                <th class="center" style="width: 4%">
                                    <span class="report-column-title">Payer Name</span>
                                </th>
                                <th class="center" style="width: 2%">
                                    <span class="report-column-title">Post Date</span>
                                </th>
                                <th class=" center" style="width: 1%">
                                    <span class="report-column-title">IsImported</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody id="tbodyReportList">
                            <asp:Repeater ID="rptDuplicatecChecks" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("RowNumber") %></td>
                                        <td><%#Eval("CheckNumber") %></td>
                                        <td><%#Eval("PaymentAmount") %></td>
                                        <td><%#Eval("PaymentPosted") %></td>
                                        <td><%#Eval("PaymentType") %></td>
                                        <td><%#Eval("PayerName") %></td>
                                        <td><%#Eval("PostDate") %></td>
                                        <td><%#Eval("IsImported") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>
                    </table>
                    <asp:HiddenField runat="server" ID="hdnTotalRows" />

                </div>
            </div>
            <input type="text" runat="server" id="hdnDateFrom" style="display: none" />
            <input type="text" runat="server" id="hdnDateTo" style="display: none" />


            <script type="text/javascript">

                var params;
                var Rows1 = "";
                Rows1 = $("#ddlPaging").val();
                function RowsChange(PageNumber, sortValue) {

                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        var params =
                        {
                            InsuranceID: $("[id$='hdnInsuranceID']").val(),
                            DateFrom: $("[id$='hdnDateFrom']").val(),
                            DateTo: $("[id$='hdnDateTo']").val(),
                            Rows: Rows1,
                            PageNumber: PageNumber,
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }

                }
            </script>
            <div style="display: none; padding: 20px;" id="CustomizeDuplicateChecks">

                <div class="row">
                    <div class="col-lg-3" style="padding-bottom: 5px;">

                        <div class="" id="divReportFilterBy">
                            <div id="div1" runat="server">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="CustomizePostType" CssClass="ddlPostType" runat="server" Style="">

                                            <asp:ListItem Value="PostDate">Payment Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">CPT Service Date</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-3" style="padding-bottom: 5px;">
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
                    <div class="col-lg-6 SelectDates" style="padding-bottom: 5px;">
                        <label style=""><b style="color: black">From:</b></label>
                        <span>
                            <input type="date" id="CustomizeDateFrom" class="Datetxtbox CustomizeDate" style="" placeholder="Date From" />

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox CustomizeDate" placeholder="Date To" />
                        </span>
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
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
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
                    <div class="col-lg-4">
                        <div id="divCheckNumber">
                            <div class="divBranchName">
                                <span class="spnBranchName" style="">Check Number:</span>
                                <div class="clsCheckNumber BranceInput" id="divddlCheckNumber">
                                    <asp:DropDownList ID="ddlCheckNumber" CssClass="ddlCheckNumber" runat="server" Style="float: left; width: 97%; margin-top: -0.8%;">
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
