<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyIndicatorReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_CompanyIndicatorReport" %>

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
             <div class="Filter SearchCriteria" style="display: none">
                 <div class="row">
                     <div class="col-lg-3 SelectDateType">
                     <div class="" id="divReportFilterBy">
                         <div id="divPostType" style="padding-bottom: 45px;">
                             <div class="divBranchName" style="">
                                 <span class="spnBranchName" style="">Date Type:</span>
                                 <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                     <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="">
                                         <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                         <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                         

                                     </asp:DropDownList>
                                 </div>
                             </div>
                         </div>

                     </div>
                 </div>
                     <div class="col-lg-3">
                         <div class="divBranchName" style="">
                             <span class="spnBranchName" style="">Dates:</span>
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
                         <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterCompanyIndicator(this)" />
                         <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeCompanyIndicatorReport()" disabled />

                     </div>
                 </div>
             </div>
            <div class="TimeSpan">
                <span style="font-weight: 600; color: black">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan" Style="color: grey"></asp:Label>

            </div>
            <div class="WidgetContent">
                <div>
                    <div class="WidgetFilterBox">
                        <div id="div_Table" style="width: 90%; float: left">
                        </div>
                    </div>
                    <div class="WidgetReport" style="margin-top: 10px;">

                        <div class="WidgetReportContent">
                            <div style="width: 100%; float: left;">
                                <div id="divReportListing" runat="server">
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr runat="server" id="PracticeNameTr">

                                                    <td colspan="5" style="padding:0 !important;">



                                                        <table style="width:100%;">
                                                            <tr>
                                                                <th colspan="5" style="text-align:center;cursor: pointer; font-size: 18px; width: 100%;">
                                                                    <asp:Label runat="server" ID="LBLPracticeName" CssClass="PracticeName"></asp:Label></th>
                                                            </tr>
                                                        </table>







                                                    </td>


                                                </tr>
                                                <tr>
                                                    <%--<th>Practice
                                                    </th>--%>
                                                    <th>Procedures
                                                    </th>
                                                    <th>Charges
                                                    </th>
                                                    <th>Adjustments
                                                    </th>
                                                    <th>Receipts
                                                    </th>
                                                    <th>Balance
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody style="text-align: center" class="CompanyIndicator" id="tbodyReportList">
                                                <tr style="border-bottom: 1px solid #ccc">
                                                    <%--<td>
                                                        <asp:Label ID="Practice" runat="server"></asp:Label>
                                                    </td>--%>
                                                    <td class="text-center">
                                                        <asp:Label ID="Procedures" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="text-right">
                                                        <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="text-right">
                                                        <asp:Label ID="lblAdjustments" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="text-right">
                                                        <asp:Label ID="lblPayments" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="text-right">
                                                        <asp:Label ID="lblBalanceDue" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                                    <td>
                                                        <b>Total</b>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Procedures1" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCharges1" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAdjustments1" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPayments1" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblBalanceDue1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>--%>
                                            </tbody>
                                        </table>

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnTotalRows" runat="server" />
            </div>
            <script type="text/javascript">
                $(function () {
                    $(".datepicker").datepicker({
                        changeMonth: true,
                        changeYear: true
                    }).mask("99/99/9999");
                });
                function FilterResult() {


                    debugger;
                    var DateType;
                    var Radiobtn = '';
                    var StartDate = '';
                    var EndDate = '';
                    var Location = $("[id$='ddlLocation']").val();
                    var Provider = $("[id$='ddlBillingProvider']").val();

                    if ($("[id$='PostRb']").is(":checked")) {
                        Radiobtn = "Post";
                    }
                    else if (($("[id$='DOSRb']").is(":checked"))) {
                        Radiobtn = "DOS";
                    }

                    if ($("[id$='chkMonthToDate']").is(":checked")) {
                        DateType = "MonthToDate";
                    }
                    else if ($("[id$='chkLastMonth']").is(":checked")) {
                        DateType = "LastMonth";
                    }
                    else if ($("[id$='chkYearToDate']").is(":checked")) {
                        DateType = "YearToDate";
                    }
                    else if ($("[id$='chkSelectDate']").is(":checked")) {
                        DateType = "Select";
                        StartDate = $("[id$='txtFromDate']").val();
                        EndDate = $("[id$='txtToDate']").val();
                    }

                    var params = {
                        DateType: DateType,
                        Radiobtn: Radiobtn,
                        StartDate: StartDate,
                        EndDate: EndDate,
                        Location: Location,
                        Provider: Provider

                    };


                    $.post("../../ProviderPortal/ReportsNew/filter/FilterCompanyIndicatorReport.aspx", params, function (data) {
                        debugger;
                        var start = data.indexOf("###start###") + 20;
                        var end = data.indexOf("###End###");
                        var returnHtml = $.trim(data.substring(start, end));
                        $("#companyIndicatorId").html(returnHtml)
                            .promise()
                            .done(function () {

                            });
                    });



                }


                function CheckBoxClick(obj) {
                    debugger

                    $(obj).parent().siblings().find("input[type = 'checkbox']").prop("checked", false);
                    var a = $(obj).parent().siblings().find("input[type = 'checkbox']").prop("checked", false).length;
                    var d = $(obj).attr("id");
                    if ($("#chkSelectDate").is(":checked")) {
                        debugger
                        //$("[id$='txtFromDate']").prop("disabled", false);
                        //$("[id$='txtToDate']").prop("disabled", false);

                        if ($("[id$='chkSelectDate']").is(":checked")) {
                            $("[id$='txtFromDate']").prop("disabled", false);
                            $("[id$='txtToDate']").prop("disabled", false);
                        }
                        else {
                            $("[id$='txtFromDate']").prop("disabled", true);
                            $("[id$='txtToDate']").prop("disabled", true);
                            $("[id$='txtToDate']").val(" ");
                            $("[id$='txtFromDate']").val(" ");
                        }

                    }

                    else {
                        $("[id$='txtFromDate']").prop("disabled", true).val('');
                        $("[id$='txtToDate']").prop("disabled", true).val('');

                    }
                }



            </script>

            ###endReport###
        </div>
    </form>
</body>
</html>
