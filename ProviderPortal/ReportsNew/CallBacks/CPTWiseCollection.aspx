<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CPTWiseCollection.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_CPTWiseCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
            <%--/// Modified By Irfan Mahmood 11/Feb/2022--%>
            <script src="../js/MainReport.js"></script>
            <script src="../js/FilterReports.js" type="text/javascript"></script>
            <style>
                .Filter {
                    display: none
                }

                .divReportName {
                    color: black;
                    font-weight: bold;
                    line-height: 24px;
                    margin-bottom: 10px;
                }

                .spnBranchName {
                    float: left;
                    font-weight: bold;
                    width: 20%;
                    padding-top: 5px;
                }

                .BranceInput {
                    width: 80%;
                    float: left;
                }

                .reportdropdown {
                    padding: 5px 0px 4px 4px;
                    width: 74.6%;
                    float: right;
                    position: absolute;
                    background-color: #FFFFFF;
                    border: 1px solid #ccc;
                    -moz-border-radius: 3px;
                    -webkit-border-radius: 3px;
                    color: #000000;
                    text-align: left;
                    min-width: 175px;
                    height: 20px;
                    z-index: 1000;
                }

                .selectedText {
                    width: 92%;
                    height: 32px;
                    overflow: hidden;
                    top: 6px;
                    position: absolute;
                    white-space: nowrap;
                    margin-left: 2%;
                }

                .divBranchName {
                    width: 100%;
                }

                .ddlselect {
                    float: left;
                    max-height: 170px;
                    overflow-y: auto;
                    margin-bottom: -2px;
                    border: 1px solid #c4c4c4;
                    background: white;
                    margin-top: 6px;
                }

                .SearchCriteria {
                    height: 155px;
                }
            </style>
            <script src="../js/MainReport.js"></script>
            <script src="../js/SummaryReports.js"></script>

            <div class="Filter SearchCriteria">

                <div class="row">
                    <div class="col-lg-3">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" runat="server" style="padding-bottom: 0px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="PostDate">Payment Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">CPT Service Date</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-3" style="padding-bottom: 0px;">
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
                    <div class="col-lg-3" style="margin-top: 0px !important;">

                        <div>
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterCPTWise()" />
                            <input class='btn primary' type="button" title="Customize" value="Customize Filter" id="CustomizeReports" onclick="CustomizeCPTWiseCollection()" />


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
                    <thead id="cptwise">
                        <tr>
                            <th style="width: 0%">#</th>
                            <th class="center" style="width: 2%">
                                <span class="report-column-title">Procedure </span>
                            </th>
                            <th class="center" style="width: 2%">
                                <span class="report-column-title">Patient Count </span>
                            </th>
                            <th class="center" style="width: 1%">
                                <span class="report-column-title">Procedure Frequency</span>
                            </th>
                            <th class="center" style="width: 2%">
                                <span class="report-column-title">Total Charges</span>
                            </th>
                            <th class=" center" style="width: 2%">
                                <span class="report-column-title">Balance Due</span>
                            </th>
                            <th class="center" style="width: 2%">
                                <span class="report-column-title">In-Process</span>
                            </th>
                            <th class="center " style="width: 2%">
                                <span runat="server" id="lblswitch">Payments</span>
                            </th>

                        </tr>
                    </thead>
                    <tbody id="tbodyReportList" class="tbodyCPTWiseCollecion">
                        <asp:Repeater ID="rptReportData" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="center"><%# Container.ItemIndex + 1 %></td>
                                    <td class="center">

                                        <%# Convert.ToString(Eval("CPTCode"))==""?"0":Eval("CPTCode")%>
                                    </td>
                                    <td class="center"><%#(Convert.ToString(Eval ("PatientCount")))==""?"0":(Eval("PatientCount"))%></td>
                                    <td class="center"><%#Convert.ToString(Eval("ClaimCount"))==""?"0":Eval("ClaimCount")%></td>
                                    <td class="AlignPayment"><%#(Convert.ToString(Eval ("Totalcharges"))==""?"0.00":(Eval("Totalcharges","{0:c}")))%></td>
                                    <td class="AlignPayment"><%#(Convert.ToString(Eval ("BalanceDue")))==""?"0.00":(Eval("BalanceDue","{0:c}"))%></td>
                                    <td class="AlignPayment"><%#(Convert.ToString(Eval ("Inprocess"))==""?"0.00":(Eval("Inprocess","{0:c}")))%></td>
                                    <td class="AlignPayment"><%#(Convert.ToString(Eval ("Payments"))==""?"0.00":(Eval("Payments","{0:c}")))%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <input type="hidden" id="hdnDateType" runat="server" value="0" />
            <input type="hidden" id="hdnStartDate" runat="server" value="0" />
            <input type="hidden" id="hdnEndDate" runat="server" value="0" />
            <script type="text/javascript">

                $("[id$='ddlPostType']").val("PostDate")
                debugger
                $('.message').hide();
                $('.Reports_Rows_Per_Page').hide();
                $("[id$='ReportDateFrom']").val(DateFrom);
                $("[id$='ReportDateTo']").val(DateTo);
                /*Commented by Faiza Bilal 3-24-2022*/
                /* $("#TimeSpan").hide();*/
                /*End Commented by Faiza Bilal 3-24-2022*/
                $('.InitialMsg').css("display", "none");
                var Rows1 = "";
                function RowsChange(PageNumber, sortValue) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        params = {
                            Payers: $("[id$='hdnPayer']").val(),
                            DateFrom: $("[id$='hdnDateFrom']").val(),
                            DateTo: $("[id$='hdnDateTo']").val(),
                            PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                            CPTCode: $("[id$='hdnCPTCode']").val(),
                            ProviderId: $("[id$='hdnProviderId']").val(),
                            DateTypeCPT: $("#" + SubReportDivName).find("[id$='ddlPostType']").val(),
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            Paymentid: $("[id$='hdnCheckNo']").val(),
                            PaymentType: $("[id$='hdnPaymentType']").val(),
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }


                }
                //var CPTNPI = [];
                //var CPTLocations = [];
                //var Locations = "";
                //var Providers = "";
                //var ProviderId = "";
                //if (_GroupBy == "Provider") {
                //    $('#chkCPTWiseCollectionAllProvider').prop("checked", false)
                //    $("[id$='ddlGroupBy']").val("Provider")

                //    CPTNPI = _CPTProviderNPI.split(",");
                //    CPTLocations = _PracticeLocationId.split(",");
                //    for (var i = 0; i < CPTLocations.length; i++) {
                //        $("[id$='DynamiculMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
                //            if ($(this).val() == CPTLocations[i]) {
                //                $(this).prop("checked", true);
                //                Locations += $(this).parent().find("span").html() + ","
                //            }
                //        });
                //    }
                //    if (Locations == "") {
                //        $('#AllLocations').text("All Locations")

                //    } else {
                //        $('#AllLocations').text(Locations)
                //    }
                //    for (var i = 0; i < CPTNPI.length; i++) {
                //        $(".CPTWCProvider .chk-multi-checkboxes").each(function () {
                //            if ($(this).val() == CPTNPI) {
                //                $(this).prop("checked", true);
                //                Providers += $(this).parent().find("span").html() + ","
                //            }
                //        });
                //    }



                //    if (Providers == "") {
                //        $('#AllProviders').text("All Providers")

                //    } else {
                //        $('#AllProviders').text(Providers)
                //        $("#divReportServiceProvider *").prop('disabled', false);

                //    }
                //}
                //else {
                //    CPTNPI = _CPTProviderNPI.split(",");
                //    $("[id$='CPTWiseCollectionDynamicProvider'] .chk-multi-checkboxes").each(function () {
                //        if ($(this).val() == CPTNPI[i]) {
                //            $(this).prop("checked", true);
                //            Providers += $(this).parent().find("span").html() + ","
                //        }
                //    });
                //    if (Providers == "") {
                //        $('#AllProviders').text("All Providers")

                //    } else {
                //        $('#AllProviders').text(Providers)
                //        $("#divReportServiceProvider *").prop('disabled', false);

                //    }

                //    if ($("[id$='CPTWiseCollection'] .chk-multi-checkboxes:checked").length == $("[id$='CPTWiseCollection'] .chk-multi-checkboxes").length) {
                //        $("#chkCPTWiseCollectionAll").prop("checked", true);
                //        $('#AllLocations').text("All Locations")
                //        $('#AllProviders').text("All Providers")
                //    }
                //    else {
                //        $("#chkCPTWiseCollectionAll").prop("checked", false);
                //        $("#DynamicchkPracticeLocationAll").prop("checked", false);

                //    }
                //    debugger
                //    CPTLocations = _PracticeLocationId.split(",");
                //    for (var i = 0; i < CPTLocations.length; i++) {

                //        $("[id$='CPTWiseCollectionLocations'] #chkCPTWiseCollectionLocations").each(function () {
                //            if ($(this).val() == _PracticeLocationId[i]) {
                //                $(this).prop("checked", true);
                //                Locations += $(this).parent().find("span").html() + ","

                //            }
                //        });
                //    }



            </script>

            <div style="display: none" id="CustomizeCPTWiseCollection">

                <div class="" id="divReportFilterBy">
                    <div class="row">
                        <div class="col-lg-6">
                            <div id="div1" runat="server" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostTypeCustomize" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="PostDate">Payment Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">CPT Service Date</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6" style="padding-bottom: 5px;">
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
                        <div class="col-lg-6 SelectDates" style="padding-bottom: 0px; padding-top: 20px !important;">
                            <label style=""><b style="color: black">From:</b></label>
                            <span>
                                <input type="date" id="CustomizeDateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                            </span>
                            <label><b style="color: black">To:</b></label>
                            <span>
                                <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox" placeholder="Date To" />
                            </span>
                        </div>
                        <div class="col-lg-6">
                            <div class="divBranchName DivBrName">
                                <span class="spnBranchName" style="">Filter By:</span>
                                <div class="clsPostDate BranceInput" id="divddlGroupBy" onchange="EnableDisableGroup('CPTWiseCollection', this);">
                                    <asp:DropDownList ID="ddlGroupBy" CssClass="ddlGroupBy" runat="server" Style="">
                                        <asp:ListItem Value="Location">Location</asp:ListItem>
                                        <asp:ListItem Value="Provider">Provider</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div id="divPracticeLocationId" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Location:</span>
                                    <div class="BranceInput">
                                        <div class="reportdropdown" style="">
                                            <a onclick="ShowMenuFilters('divPracticeLocation',this);">
                                                <div class="selectedText" id="AllLocations">
                                                    All Locations
                               
                                                </div>
                                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-top: 0%;">
                                                    <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                                </div>
                                            </a>
                                            <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                                <div class="ddlselect CPTWiseCollectionLocations CPTWiseCollectionDynamicLocations">
                                                    <ul id="CPTWiseCollectionLocations">
                                                        <li style="float: left; width: 100%;">
                                                            <label class="lbl-multi-checkboxes" style="float: left;">
                                                                <input type="checkbox" id="chkCPTWiseCollectionLocationAll" class="chk-multi-checkboxes-all" onclick="Report_ClickMultiCheckBoxAll(this,'CPTWiseCollectionLocations'),GetPracticeStaffLocation('CPTWiseCollectionLocations')" />
                                                                <span>All</span>
                                                                <input type="hidden" value="0" />
                                                            </label>
                                                        </li>
                                                        <asp:Repeater runat="server" ID="rptLocation">
                                                            <ItemTemplate>
                                                                <li style="float: left; width: 100%;">
                                                                    <label name='<%#Eval("PracticeLocationsId") %>' style="float: left;">
                                                                        <input type="checkbox" class="chk-multi-checkboxes" id="chkCPTWiseCollectionLocations" onclick="ReportAlert(this,'CPTWiseCollectionLocations'),GetPracticeStaffLocation('CPTWiseCollectionLocations')" value='<%#Eval("PracticeLocationsId") %>' />
                                                                        <span><%#Eval("Name") %></span>
                                                                        <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' class="PracticeLocationsId" />
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
                        <div class="col-lg-6">
                            <div id="divReportServiceProvider" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Provider :</span>
                                    <div class="BranceInput">
                                        <div class="reportdropdown" style="">
                                            <a onclick="ShowMenuFilters('divServiceProvider', this);">
                                                <div class="selectedText" id="AllProviders">
                                                    All Providers
                               
                                                </div>
                                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-top: 0%;">
                                                    <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                                </div>
                                            </a>
                                            <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                                <div class="ddlselect CPTWiseCollectionDynamicProviders CPTWiseCollectionProviders">
                                                    <ul id="CPTWiseDynamicProviders">
                                                        <li style="float: left; width: 100%;">
                                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                                <input type="checkbox" id="DynamicCPTWiseProviderChkAll" class="chk-multi-checkboxes-all" disabled="disabled" />
                                                                <span>All Providers</span>
                                                                <input type="hidden" value="0" />
                                                            </label>
                                                        </li>

                                                        <asp:Repeater runat="server" ID="DynamicProviders">
                                                            <ItemTemplate>
                                                                <li style="float: left; width: 100%;">
                                                                    <label style="float: left;">
                                                                        <input type="checkbox" value='<%#Eval("StaffNPI") %>' class="StaffNPI chk-multi-checkboxes" disabled="disabled" />
                                                                        <span><%#Eval("StaffName") %></span>
                                                                        <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="PracticeStaffId" />

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
                        <div class="col-lg-6" style="padding-bottom: 10px;">
                            <div id="divReportPayerScenario">
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
                    <div class="col-lg-6">
                        <div id="divCPT" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">CPT:</span>
                                <div class="clsDiagnosis BranceInput" style="position: relative;">

                                    <input type="text" id="txtServiceCode" placeholder="Search CPT" class="required" runat="server" onkeyup="ServiceCode(event, this,'ClaimSummaryCPT')" />
                                    <div class="divselectedServiceCode" style="position:relative;">

                                        <div id="divCPTSearched" style="width: 100%; max-height: 250px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto; margin-top: 0%; margin-bottom: 10px;">
                                            <div class="Grid" style="width: 99%; height: auto;">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th>Code</th>
                                                            <th>Description</th>
                                                            <th><span onclick="closecptdiv(this,'ClaimSummaryCPT')">
                                                                <img src="../../Images/close_icon.png" width="25" height="25" /></span></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="CPTSearchedList" ></tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                </div>


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
