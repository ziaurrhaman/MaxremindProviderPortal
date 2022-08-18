<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProviderCollectionReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_ProviderCollectionReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        ###startReport###
           <script src="../js/MainReport.js"></script>
        <script src="../js/SummaryReports.js"></script>
        <script src="../js/FilterReports.js"></script>
        <style>
            .Filter {
                display: none
            }

            .radiobtn {
                padding: 4px 0;
            }

                .radiobtn input {
                    margin-top: 0;
                }

                .radiobtn label {
                    font-weight: normal;
                }

            .by-month {
                padding-top: 20px;
                width: 48%;
                padding-right: 2%;
            }

            .by-date .form-group {
                display: block;
                margin-bottom: 10px;
            }

            .by-date {
                width: 48%;
                padding-top: 20px;
            }

            .SearchCriteria legend {
                font-weight: 600;
                background: #006ebd;
                padding: 2px 10px;
                color: #fff;
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

            .divBranchName {
                width: 100%;
            }

            .ddlselect {
                float: left;
                max-height: 140px;
                overflow-y: auto;
                margin-bottom: -2px;
                background-color: white
            }

            .maindivofddl {
                float: left;
                width: 100%;
                margin-top: 32px;
                background: white;
                position: relative;
                z-index: 999;
                border: 1px solid #ccc;
                padding: 0px 2px;
            }

            #DupShow {
                margin-top: 68px;
                width: 500px;
            }

            input[type="text"] {
                width: 170px;
            }

            .filterbtn {
                margin-left: 870px
            }

            .selectedText {
                width: 94%;
            }
        </style>
        <script src="../js/MainReport.js"></script>
        <script src="../js/SummaryReports.js"></script>
        <div class="Filter SearchCriteria">


            <div class="row">
                <div class="col-3 SelectDateType">
                    <div class="" id="divReportFilterBy">
                        <div id="divPostType" runat="server" style="padding-bottom: 45px;">
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
                <div class="col-3" style="margin-top: 36px;">
                    <div>
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterProviderCollectionReport()" />

                        <input class='btn primary' type="button" title="Customize Filter" value="Customize Report" id="CustomieReport" onclick="CustomizeProviderCollectionReport()" />

                    </div>
                </div>

            </div>

        </div>
        <div>
            <div style="text-align: center" class="TimeSpan" id="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="txtDateFrom"></asp:Label>
                -
                <asp:Label runat="server" ID="txtDateTo"></asp:Label>
            </div>
            <asp:Repeater ID="rptProviderCollectionReport" runat="server">
                <HeaderTemplate>
                    <div class="GridReports" id="printableArea">
                        <table>
                            <thead id="providercollection">
                                <tr>
                                    <th class="center" style="width: 0%">#</th>
                                    <th class="center" style="width: 3%">
                                        <span class="report-column-title">Provider</span><span></span>
                                    </th>
                                    <th class="center" style="width: 1%">
                                        <span class="report-column-title">Patient Count</span><span></span>
                                    </th>
                                    <th class="center" style="width: 1%">
                                        <span class="report-column-title">Procedure Frequency</span><span></span>
                                    </th>
                                    <th class="center" style="width: 1%">
                                        <span class="report-column-title center">Total Charges</span>
                                    </th>
                                    <th class="center" style="width: 1%">
                                        <span class="report-column-title center">Balance Due</span>
                                    </th>
                                    <th class="center" style="width: 1%">
                                        <span class="report-column-title center">Inprocess</span>
                                    </th>

                                    <th class="center " style="width: 2%">
                                        <span runat="server" id="lblswitch">Payments</span>

                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList" class="tbodyProviderCollection">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="center"><%# Container.ItemIndex + 1 %></td>
                        <td class='AlignString tdAttendingPhysician'>
                            <%# Eval("Provider")%>
                        </td>
                        <td class="AlignDate AlignPayment">
                            <%# Convert.ToString(Eval("PatientCount"))==""?"0":Eval("PatientCount")%>
                        </td>
                        <td class="TotalPaidClaim center"><%# Convert.ToString(Eval("ClaimCount"))==""?"0":Eval("ClaimCount")%>
                        </td>
                        <td class="TotalPaidAmount AlignPayment">$<%#(Convert.ToString(Eval("TotalCharges"))=="" ? "0.00":(Eval("TotalCharges","{0:F2}")))%>
                        </td>
                        <td class="TotalPaidAmount AlignPayment">$<%#(Convert.ToString(Eval("BalanceDue"))=="" ? "0.00":(Eval("BalanceDue","{0:F2}")))%>
                        </td>
                        <td class="TotalPaidAmount AlignPayment">$<%#(Convert.ToString(Eval("Inprocess"))=="" ? "0.00":(Eval("Inprocess","{0:F2}")))%>
                        </td>
                        <td class="TotalPaidAmount AlignPayment">$<%#(Convert.ToString(Eval("Payments"))=="" ? "0.00":(Eval("Payments","{0:F2}")))%>
                        </td>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                                </table>
                            </div>
                </FooterTemplate>
            </asp:Repeater>
            <input type="hidden" id="hdnTotalRows" runat="server" />
            <input type="hidden" id="hdnDateFrom" runat="server" />
            <input type="hidden" id="hdnDateTo" runat="server" />
            <input type="hidden" id="hdnDateType" runat="server" />
            

        </div>
        <div class="ProviderWiseDetail" style="display:none"></div>
      

        <div style="display: none; padding: 20px;" id="CustomizeProviderCollectionReport">

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
                <div class="col-lg-6" style="padding-bottom: 5px;">
                    <div class="divBranchName DivBrName">
                        <span class="spnBranchName" style="">Filter By:</span>
                        <div class="clsPostDate BranceInput" id="divddlGroupBy" onchange="EnableDisableGroup('ProviderCollection', this);">
                            <asp:DropDownList ID="ddlGroupBy" CssClass="ddlGroupBy" runat="server" Style="">
                                <asp:ListItem Value="Location">Location</asp:ListItem>
                                <asp:ListItem Value="Provider">Provider</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6" style="padding-bottom: 5px;">
                    <div id="divPracticeLocationId" runat="server">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Location:</span>
                            <div class="BranceInput">
                                <div class="reportdropdown" style="">
                                    <a onclick="ShowMenuFilters('divPracticeLocation', this);">
                                        <div class="selectedText" id="AllLocations">
                                            All Locations
                               
                                        </div>
                                        <div class="dropDownIcon" style="width: 8.5%; position: absolute; right: 0; top: 4px;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                        <div class="ddlselect ProviderCollectionDynamicLocations ProviderCollectionLocations">
                                            <ul id="ProviderCollectionLocations">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" style="float: left;">
                                                        <input type="checkbox" id="chkProviderCollectionLocationsAll" class="chk-multi-checkboxes-all" onclick="Report_ClickMultiCheckBoxAll(this,'ProviderCollectionLocations'),GetPracticeStaffLocation('ProviderCollectionLocations')" />
                                                        <span>All</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptLocation">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label onclick="Report_ClickMultiCheckBox(this,'ProviderCollectionLocations');" style="float: left;">
                                                                <input type="checkbox" class="chk-multi-checkboxes" id="chkProviderCollectionLocations" onclick="ReportAlert(this,'ProviderCollectionLocations'),GetPracticeStaffLocation('ProviderCollectionLocations')" value='<%#Eval("PracticeLocationsId") %>' />
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
                                        <div class="dropDownIcon" style="width: 8.5%; position: absolute; right: 0; top: 4px;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                        <div class="ddlselect ProviderCollectionDynamicProviders ProviderCollectionProviders">
                                            <ul id="ProviderCollectionDynamicProviders">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes dynamicStaff" onclick="Report_ClickMultiCheckBoxAll(this)" style="float: left;">
                                                        <input type="checkbox" id="chkProviderCollectionDynamicProvidersAll" class="chk-multi-checkboxes-all" disabled="disabled" />
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







            <span class="float_left ml_0 mt_5" style="margin-top: 0px; padding: 5px 0px 5px 0px"></span>




        </div>

        <script type="text/javascript">
            debugger
            $(document).ready(function () {
                $('#txtfromcustomize').val($("[id$='hdnDateFrom']").val());
                $('#txttocustomize').val($("[id$='hdnDateTo']").val());
                $("#ddlPostTypeProviderCollection").val("PostDate")
                $("#txtReportDateFrom").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-11 : +0",
                    maxDate: new Date(),

                });

                $("#txtReportDateTo").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-11 : +0",
                    maxDate: new Date(),

                });
            });
            $(".message").show();
            $(".message_box").hide();
            $('.Reports_Rows_Per_Page').hide();
            $(".InitialMsg").css("display", "none");
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();

                var paging = true;
                if (_selectedReport_Filter.includes("ilter")) {
                    _selectedReport_Filter = _selectedReport_Filter.slice(6);
                }
                if (_selectedReport_Filter != "") {
                    params = {
                        Payers: $("[id$='hdnPayers']").val(),
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
                        DateType: $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val(),
                        Rows: Rows1,
                        PageNumber: pageNumber,
                        ProviderId: $("[id$='hdnProvider']").val(),
                        LocationId: $("[id$='hdnLocation']").val(),
                        action: "FilterReport",
                    };

                    
                    Report_ReloadDataProviderWiseReport(_selectedReport_Filter, params, true);
                }


            }

        </script>
        <%--End Added by Faiza Bilal 2-16-2022--%>
        <div class="dialogue" style="display: none"></div>


        ###endReport###
        ###StartFilterReport###
        
        <asp:Repeater runat="server" ID="RptFilterProviderCollectionReport">
            <ItemTemplate>
                <tr>
                    <td class="center"><%# Container.ItemIndex + 1 %></td>
                    <td class='AlignString tdAttendingPhysician' >
                        <%# Eval("Provider")%>
                    </td>
                    <td class="AlignDate AlignPayment">
                        <%# Convert.ToString(Eval("PatientCount"))==""?"0":Eval("PatientCount")%>
                    </td>
                    <td class="TotalPaidClaim center"><%# Convert.ToString(Eval("ClaimCount"))==""?"0":Eval("ClaimCount")%>
                    </td>
                    <td class="TotalPaidAmount AlignPayment">$<%#(Convert.ToString(Eval("TotalCharges"))=="" ? "0.00":(Eval("TotalCharges","{0:F2}")))%>
                    </td>
                    <td class="TotalPaidAmount AlignPayment">$<%#(Convert.ToString(Eval("BalanceDue"))=="" ? "0.00":(Eval("BalanceDue","{0:F2}")))%>
                    </td>
                    <td class="TotalPaidAmount AlignPayment">$<%#(Convert.ToString(Eval("Inprocess"))=="" ? "0.00":(Eval("Inprocess","{0:F2}")))%>
                    </td>
                    <td class="TotalPaidAmount AlignPayment">$<%#(Convert.ToString(Eval("Payments"))=="" ? "0.00":(Eval("Payments","{0:F2}")))%>
                    </td>
                    <%--<td class="TotalPaidAmount center">$<%#(Convert.ToString(Eval("TotalPayment"))=="" ? "0.00":(Eval("TotalPayment","{0:F2}")))%>--%>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <input type="hidden" id="hdnLocation" runat="server" value="0" />
            <input type="hidden" id="hdnProvider" runat="server" value="0" />
            <input type="hidden" id="hdnPayer" runat="server" value="0" />
        ###EndFilterReport###
        ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
    </form>
</body>
</html>
