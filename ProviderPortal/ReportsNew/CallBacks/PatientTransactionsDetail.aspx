<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientTransactionsDetail.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientTransactionsDetail" %>

<!DOCTYPE html>

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
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientTransactionsDetail()" />
                        <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePatientTransactionsDetail()" />
                    </div>
                </div>

            </div>

        </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <asp:Repeater ID="rptPatientTransactionsDetail" runat="server" OnItemDataBound="rptPatientTransactionsDetail_ItemDataBound">
                <HeaderTemplate>
                    <div class="GridReports" id="printableArea">
                        <table>
                            <thead>
                                <tr>
                                    <th>
                                        <span class="report-column-title">#</span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Patient Name</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Post Date</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Claim Id</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Procedure Code</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Date Of Service</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Provider</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Service Location</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Charges</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Adjustments</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Balance Due</span><span></span>
                                    </th>

                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Payment</span><span></span>
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
                            <%# Eval("Patient") %>
                        </td>
                        <td>
                            <%# Eval("PostDate") %>
                        </td>
                        <td>
                            <%# Eval("ClaimId") %>
                        </td>
                        <td>
                            <%# Eval("ProcedureCode") %>
                        </td>
                        <td>
                            <%# Eval("DOS") %>
                        </td>
                        <td>
                            <%# Eval("Provider") %>
                        </td>
                        <td>
                            <%# Eval("Location") %>
                        </td>
                        <td>
                    <%# Eval("Charges","{0:0.00}") %>
                </td>
                <td>
                    <%# Eval("Adjustments","{0:0.00}") %>
                </td>
                <td>
                    <%# Eval("BalanceDue","{0:0.00}") %>
                </td>

                        <td>
                            <asp:Label ID="lblPayment" runat="server"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                                </table>
                            </div>
                </FooterTemplate>
            </asp:Repeater>

            <tr style="text-align: center" >
                <td colspan="10">
                    <div class="divtotalpayment" id="TotalPayment">
                        <div style="text-align: center; margin: 10px"><span style="color: teal; font-weight: bold;">Total Payment:</span><span style="font-weight: bold;">
                            <asp:Label runat="server" ID="lbltotalPayment" CssClass="" /></span></div>
                    </div>
                </td>
            </tr>

            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnPatientId" />
            <asp:HiddenField runat="server" ID="hdnLocation" />
            <asp:HiddenField runat="server" ID="hdnProvider" />
            <asp:HiddenField runat="server" ID="hdnProcedure" />
            <div id="divDialogReportFilters" style="display: none;"></div>


            <script type="text/javascript">
                debugger;
                var Rows1 = "";
                function RowsChange(PageNumber, sortValue) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        params = {
                            DateFrom: $("#" + SubReportDivName).find("[id$='DateFrom']").val(),
                            DateTo: $("#" + SubReportDivName).find("[id$='DateTo']").val(),
                            DateType: $("#" + SubReportDivName).find("#ddlPostType").val(),
                            PatientIds: $("[id$='hdnPatientId']").val(),
                            PracticeLocationId: $("[id$='hdnLocation']").val(),
                            CPTCode: $("[id$='hdnProcedure']").val(),
                            Providerid: $("[id$='hdnProvider']").val(),
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            SortBy: sortValue || 'Patient ASC',
                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                        $('.divtotalpayment1').remove();
                    }


                }

            </script>
            <div style="display: none; padding: 20px;" id="CustomizePatientTransactionsDetail">

            <div class="row">
                <div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                            <asp:ListItem Value="PostDate">Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">Service Date</asp:ListItem>
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
                    <div id="divReportServiceProvider" runat="server" style="padding-bottom: 45px;">
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
                                                    <label class="lbl-multi-checkboxes dynamicStaff" onclick="Report_ClickMultiCheckBoxAll(this);GetLocationNamePracticestaff()" style="float: left;">
                                                        <input type="checkbox" id="chkProviderCollectionDynamicProvidersAll" class="chk-multi-checkboxes-all"  />
                                                        <span>All Providers</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="DynamicProviders">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label style="float: left;">
                                                                <input type="checkbox" value='<%#Eval("StaffNPI") %>' class="StaffNPI chk-multi-checkboxes" />
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
                <div class="col-lg-6" style="position: relative;">
                    <div id="divReportProcedure">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Procedure :</span>
                            <div class="clsDiagnosis BranceInput" id="divProcedure" style="position: relative;">
                                <table>
                                    <tr>
                                        <%--<td style="width: 140px" class="leftTd">
                                        <input type="text" id="txtCPTCode" class="required" runat="server" onkeyup="searchCPTs('C', this.value, '', this, event);" onchange="PopulateCPTDesc(this, 'txtCPTDescription');" style="width: 86%;" />
                                    </td>--%>
                                        <td class="leftTd">
                                            <input type="text" id="txtCPTCode" runat="server" class="required" onkeyup="searchCPTs('C', this.value, '', this, event);" onchange="PopulateCPTCode(this, 'txtCPTDescription');" style="float: left;" />
                                            <span class="spnRemove" onclick="emptyCPTVal(this, 1);"></span>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divCPTSearched" style="height: 305px; margin-top: -8px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto;">
                                    <div class="Grid" style="width: 99%; height: auto;">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>Code</th>

                                                    <th>
                                                        <div onclick="closeCPTSearched(this)" class="spnclose">
                                                            <img alt="" src="../../Images/close_icon.png" style="border-radius: 100px; float: right; margin-right: 6px;" width="25" height="25" />
                                                        </div>
                                                        Description</th>
                                                </tr>
                                            </thead>
                                            <tbody id="CPTSearchedList">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
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
