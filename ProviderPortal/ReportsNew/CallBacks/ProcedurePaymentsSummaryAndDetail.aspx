<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcedurePaymentsSummaryAndDetail.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ProcedurePaymentsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
            <script type="text/javascript" src="../js/SummaryReports.js"></script>
            <div class="Filter SearchCriteria" style="display: none;">
                <div class="row">
                    <div class="col-lg-3 CustomDivPostType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" runat="server" style="padding-bottom: 0px !important;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Insurance Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType">
                                        <asp:DropDownList ID="BilledAs" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="">All</asp:ListItem>
                                            <asp:ListItem Value="Pri">Primary</asp:ListItem>
                                            <asp:ListItem Value="Sec">Secondary</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <%--<div id="divReportPayerScenario">
                            <div>
                                <div class="divBranchName" style="">
                                    <label class="spnBranchName" style="">Payers:</label>
                                    <div class="BranceInput">
                                        <div class="reportdropdown" style="">
                                            <a onclick="ShowMenuFilters('divPayerScenario', this);">
                                                <div class="selectedText">
                                                    <label id="SelectInsurances">All Payers </label>

                                                </div>
                                                <div class="dropDownIcon" style="width: 8.5%; right: -9px; position: absolute;">
                                                    <img src="../../Images/dropdown.gif" style="width: 10px; margin-top: 2px; margin-left: 0px;" />

                                                </div>

                                            </a>
                                            <div id="divPayerScenario" class="div-multi-checkboxes-wrapper divPayerScenario" style="display: none; max-height: 15px; padding: 0; top: 27px; left: 0; width: 99%;">
                                                <div class="ddlselect analysisddlselect">
                                                    <ul id="ulMultiPayerScenario">
                                                        <li style="float: left; width: 100%;">
                                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                                <input type="checkbox" id="chkPayerScenarioAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                                <span>All Payers</span>
                                                                <input type="hidden" value="0" />

                                                            </label>

                                                        </li>
                                                        <asp:Repeater runat="server" ID="rptInsurances">
                                                            <ItemTemplate>
                                                                <li style="float: left; width: 100%;">
                                                                    <label onclick="Report_ClickMultiCheckBox(this)" style="float: left;">
                                                                        <input type="checkbox" class="chkPayerScenario chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("InsuranceId") %>' />
                                                                        <span id="PayersName" class="checkBoxName PayersName"><%#Eval("Name") %></span>
                                                                        <input type="hidden" value='<%#Eval("InsuranceId") %>' id="InsuranceId" class="InsuranceId" />

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
                        </div>--%>


                    <div class="col-lg-3" style="margin-top: 35px;">
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterProcedurePaymentsSummaryAndDetail()" />
                        <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeProcedurePaymentsSummaryAndDetail()" />


                    </div>
                </div>

            </div>

            <asp:Repeater ID="rptProcedurePaymentsSummary" runat="server">
                <HeaderTemplate>
                    <div class="GridReports" id="printableArea">
                        <table>
                            <thead>
                                <tr>
                                    <th class="center" style="width: 5%">
                                        <span class="report-column-title">#</span><span></span>
                                    </th>
                                    <th class="center" style="width: 35%">
                                        <span class="report-column-title">Insurance</span><span></span>
                                    </th>
                                    <th class="center" style="width: 9%">
                                        <span class="report-column-title" style="width: 9%">CPT</span>
                                    </th>
                                    <th class="AlignPayment" style="width: 9%">
                                        <span class="report-column-title">Total Pmt</span>
                                    </th>
                                    <th class="AlignPayment" style="width: 9%">
                                        <span class="report-column-title">Avg Pmt</span>
                                    </th>
                                    <th class="center" style="width: 9%">
                                        <span class="report-column-title">Frequency</span>
                                    </th>

                                </tr>
                            </thead>
                            <tbody id="tbodyReportList">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="AlignDate">
                            <%# Eval("RowNumber")%>
                        </td>
                        <td class='AlignString tdInsurance'>
                            <%# Eval("Insurance")%>
                            <input type="hidden" class="hdnInsuranceid" value=" <%# Eval("InsId")%>"></hidden
                            <input type="hidden" class="hdnCPT" value=" <%# Eval("CPT")%>"></hidden

                        </td>
                        <td class="AlignDate tdCPT">
                            <%# Eval("CPT")%>
                        </td>
                        <td class="AlignPayment">$<%# Eval("TotalPmt","{0:0.00}")%>
                        </td>
                        <td class="AlignPayment">$<%# Eval("AVgPmt","{0:0.00}")%>
                        </td>
                        <td class="AlignDate">
                            <%# Eval("Frequency")%>
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

            <asp:HiddenField runat="server" ID="hdnCPTs" />
            <asp:HiddenField runat="server" ID="hdnInsuranceIds" />
            <asp:HiddenField runat="server" ID="hdnInsurancetype" />

            <div class="DetaildialogueBox" style="display: none"></div>

            <script>
                $(document).ready(function () {
                    debugger
                    var cpts = $('#hdnCPTs').val();
                    var insuranecs = $('#hdnInsuranceIds').val();

                    if (cpts.split(',').length > 1) {
                        $('.tdCPT').addClass('linkClass');
                        $('.tdCPT').attr('onclick', 'CPTDetail(this)');

                    }
                    else {
                        if (cpts.split(',').length == 1 && insuranecs.split(',').length == 2) {
                            $('.tdCPT').addClass('linkClass');
                            $('.tdCPT').attr('onclick', 'CPTDetail(this)');
                        }
                        else {
                            $('.tdInsurance').addClass('linkClass');
                            $('.tdInsurance').attr('onclick', 'InsuranceDetail(this)');
                        }

                    }


                    $(".message").hide();
                    $('.Reports_Rows_Per_Page').hide();
                });
                var Rows1 = "";
                var sort = "";
                function RowsChange(PageNumber, sort) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();


                    if (_selectedReport_Filter != "") {
                        params = {

                            Insurance: $("[id$='hdnInsuranceIds']").val(),
                            Rows: Rows1,
                            PageNumber: PageNumber,
                            ProviderId: $("[id$='hdnProviderId']").val(),
                            InsuranceType: $("[id$='hdnInsurancetype']").val(),

                            Location: $("[id$='hdnLocation']").val(),
                            Cptcodes: $("[id$='hdnCPTs']").val(),
                                


                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, true);


                    }
                }
            </script>
            <div style="display: none; padding: 20px;" id="CustomizeProcedurePaymentsSummaryAndDetail">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="" id="divReportFilterBy">
                            <div id="div1" runat="server" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Insurance Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType">
                                        <asp:DropDownList ID="BilledAsCustomize" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="">All</asp:ListItem>
                                            <asp:ListItem Value="Pri">Primary</asp:ListItem>
                                            <asp:ListItem Value="Sec">Secondary</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <div class="col-lg-6" id="divCPT" style="padding-bottom: 45px; width: 50% !important;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">CPT:</span>
                            <div class="clsDiagnosis BranceInput" style="">

                                <input type="text" id="txtServiceCode" placeholder="Search CPT" class="required" runat="server" onkeyup="ServiceCode(event, this)" style="width: 100%;" />
                                <div class="divselectedServiceCode" style="margin-top: 10px" />
                            </div>

                        </div>

                        <div id="divCPTSearched" style="width: auto; /*left: 21%; */ max-height: 250px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto; margin-top: 0%; margin-bottom: 10px;">
                            <div class="Grid" style="width: 99%; height: auto;">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Code</th>
                                            <th>Description</th>
                                            <th><span onclick="closecptdiv(this)">
                                                <img src="../../Images/close_icon.png" width="25" height="25" /></span></th>
                                        </tr>
                                    </thead>
                                    <tbody id="CPTSearchedList">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 CustomPracticeLocation">
                        <div id="divPracticeLocationId">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Location:</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPracticeLocation',this);">
                                            <div class="selectedText">
                                                All Locations
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; position: absolute; top: 3px; right: 0;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect">
                                                <ul id="ulMultiPracticeLocation">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                            <input type="checkbox" id="chkPracticeLocationAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                            <span>All</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptLocation">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("PracticeLocationsId") %>' />
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
                    <div class="col-lg-6 CustomReportServiceProvider">
                        <div id="divReportServiceProvider">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Provider :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divServiceProvider',this);">
                                            <div class="selectedText">
                                                All Providers
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; position: absolute; top: 3px; right: 0;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect">
                                                <ul id="ulMultiServiceProvider">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                            <input type="checkbox" id="chkServiceProviderAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                            <span>All Providers</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptProviders">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("PracticeStaffId") %>' />
                                                                    <span><%#Eval("StaffName") %></span>
                                                                    <input type="hidden" value='<%#Eval("StaffNPI") %>' class="PracticeStaffId" />
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
                        <div id="divReportPayerScenario">
                            <div>
                                <div class="divBranchName" style="">
                                    <label class="spnBranchName" style="">Payers:</label>
                                    <div class="BranceInput">
                                        <div class="reportdropdown" style="">
                                            <a onclick="ShowMenuFilters('divPayerScenarioCustomize', this);">
                                                <div class="selectedText">
                                                    <label id="SelectProPayments">All Payers </label>

                                                </div>
                                                <div class="dropDownIcon" style="width: 8.5%; top: 3px; right: 1px; position: absolute;">
                                                    <img src="../../Images/dropdown.gif" style="width: 10px;" />

                                                </div>

                                            </a>
                                            <div id="divPayerScenario" class="div-multi-checkboxes-wrapper CustomizeProPayments divPayerScenarioCustomize SelectProPayments" style="display: none; max-height: 15px; padding: 0; top: 27px; left: 0; width: 99%;">
                                                <div class="ddlselect analysisddlselect CustomProcedure">
                                                    <ul id="ulMultiPayerScenario">
                                                        <li style="float: left; width: 100%;">
                                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                                <input type="checkbox" id="chkPayerScenarioCustomizeAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                                <span>All Payers</span>
                                                                <input type="hidden" value="0" />

                                                            </label>

                                                        </li>
                                                        <asp:Repeater runat="server" ID="PayersCustomize">
                                                            <ItemTemplate>
                                                                <li style="float: left; width: 100%;">
                                                                    <label onclick="Report_ClickMultiCheckBox(this)" style="float: left;">
                                                                        <input type="checkbox" class="chkPayerScenarioCustomize chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("InsuranceId") %>' />
                                                                        <span id="PayersNameCustomize" class="checkBoxNameCustomize PayersName"><%#Eval("Name") %></span>
                                                                        <input type="hidden" value='<%#Eval("InsuranceId") %>' id="InsuranceIdCustomize" class="InsuranceIdCustomize" />

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
            </div>
            ###endReport###

        </div>
    </form>
</body>
</html>
