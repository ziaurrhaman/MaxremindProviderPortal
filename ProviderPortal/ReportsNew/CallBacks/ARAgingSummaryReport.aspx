<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ARAgingSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ARAgingSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            ###startReport###
            <style type="text/css">
                .ddlselect.analysisddlselect {
                    float: left;
                    max-height: 170px;
                    overflow-y: auto;
                    margin-bottom: -2px;
                    border: 1px solid #c4c4c4;
                    background: white;
                    margin-top: 0;
                    padding: 7px;
                    position: relative;
                    top: 24px !important;
                }
            </style>
            <div class="divReportFilters">
                <style>
                    .HyperlinkClass {
                        text-decoration: underline;
                        color: blue;
                        cursor: pointer;
                    }
                </style>

                <div class="Filter SearchCriteria" style="display: none;">
                    <div class="row">
                        <div class="col-3">
                            <div id="divAgingBy" style="padding-bottom: 0px !important; width: 100% !important; float: left !important; margin-left: 1%;">

                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Aging By:</span>
                                    <div class="clsPostDate BranceInput" id="DivddlAgingBy" onchange="EnableDisableFilter(this)">
                                        <select class="ddl" id="ddlAgingBy">
                                            <option value="EncounterPostDate">Procedure Post Date </option>
                                            <option value="FirstBillDate">First Bill Date</option>
                                            <option value="LASTBillDate">Last Bill Date</option>
                                            <option value="DOS">DOS</option>

                                        </select>
                                    </div>

                                </div>
                            </div>

                        </div>
                        <div class="col-3">
                            <div id="divAsof" style="padding-bottom: 45px; width: 100% !important; clear: none;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="float: left; margin-left: 0%;">As of:</span>
                                    <div class="clsPatientId BranceInput">
                                        <%--<input type="text" id="dateasof" onchange="EnableDisableFilter()"/>--%>
                                        <input type="date" id="dateasof" style="height: 29px; width: 100%" onchange="EnableDisableFilter(this)" />
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="col-3" style="margin-top: 36px;">
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterArAgingSummary(this)" <%--style="margin-top: 28px !important;" --%> />

                            <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeARAgingReport()" />


                        </div>
                    </div>
                </div>


            </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span :</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <div class="GridReports" id="printableArea">
                <table>
                    <thead>
                        <tr>
                            <th style="text-align: center !important;">
                                <span class="report-column-title">Type</span>
                            </th>

                            <th>
                                <span class="report-column-title">Current</span>
                            </th>
                            <th>
                                <span class="report-column-title">31-60</span>
                            </th>
                            <th>
                                <span class="report-column-title">61-90</span>
                            </th>
                            <th>
                                <span class="report-column-title">91-120</span>
                            </th>
                            <th>
                                <span class="report-column-title">120+</span>
                            </th>
                            <th>
                                <span class="report-column-title">Total Outstanding</span>
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tbodyReportList" class="tBodyARAgingSummary">

                        <asp:Repeater ID="rptARAgingSummary" runat="server" OnItemDataBound="rptARAgingSummary_ItemDataBound">
                            <ItemTemplate>
                                <tr class="cpa-trfont">
                                    <td class="HyperlinkClass" onclick="ARSummaryDetails('<%# Eval("ARType") %>')" style="text-align: center;"><%# Eval("ARType") %></td>
                                    <td style="text-align: right;"  onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','030')">
                                        <asp:Label  id="current" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','3160')">
                                         <asp:Label  id="p31" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','6190')">
                                          <asp:Label id="p61" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','91120')">
                                        <asp:Label  id="p91" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','120+')">
                                         <asp:Label  id="p120" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','')">
                                        <asp:Label id="TotalOutStanding" runat="server" class="HyperlinkClass"></asp:Label></td>
                                </tr>


                            </ItemTemplate>
                        </asp:Repeater>

                        <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
                            <td style="text-align: center;">
                                <label>Grand Total</label></td>

                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txtCurrent"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt3160"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt6190"></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt91120"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt120"></asp:Label>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txtTotalOutStanding"></asp:Label></td>
                        </tr>

                        <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
                            <td style="text-align: center;">
                                <label>Total %</label></td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txtCurrentP"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt3160P"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt6190P"></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt91120P"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txt120P"></asp:Label>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label runat="server" ID="txtTotalOutStandingP"></asp:Label></td>
                        </tr>

                        
            <input type="hidden" id="hdnAgingType" runat="server" value="0" />
            <input type="hidden" id="hdnPracticeLocationId" runat="server" value="0" />
            <input type="hidden" id="hdnProviderId" runat="server" value="0" />
            <input type="hidden" id="hdnPayerId" runat="server" value="0" />
            <input type="hidden" id="hdnAsof" runat="server" value="0" />
                    </tbody>
                </table>
            </div>


            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
        </div>

        <div class="divInsuranceDetail" style="display: none">
        </div>
        <div id="divDialogPatint" style="display: none">
        </div>

        <div style="display: none; padding: 20px;" id="CustomizeARAgingFilter">
            <div class="row">
                <div class="col-6" style="width: 50% !important;">
                    <div id="divAgingBy" style="padding-bottom: 0px !important; width: 100% !important; float: left !important;">

                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Aging By:</span>
                            <div class="clsPostDate BranceInput" id="DivddlAgingBy">
                                <select class="ddl" id="ddlAgingByCustomize">
                                    <option value="EncounterPostDate">Procedure Post Date </option>
                                    <option value="FirstBillDate">First Bill Date</option>
                                    <option value="LASTBillDate">Last Bill Date</option>
                                    <option value="DOS">DOS</option>

                                </select>
                            </div>

                        </div>
                    </div>

                    <div id="divAsof" style="width: 100% !important; clear: none;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="float: left; margin-left: 0%;">As of:</span>
                            <div class="clsPatientId BranceInput">
                                <%--<input type="text" id="dateasof" onchange="EnableDisableFilter()"/>--%>
                                <input type="date" id="dateasofCustomize" style="height: 29px; width: 100%" onchange="EnableDisableFilter(this)" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-6" id="divReportPayerScenario" style="width: 50% !important;">
                    <div class="divBranchName DivBrName">
                        <span class="spnBranchName" style="">Filter By:</span>
                        <div class="clsPostDate BranceInput" id="divddlGroupBy" onchange="EnableDisableGroup('ARAgingSummary', this);">
                            <asp:DropDownList ID="ddlGroupBy" CssClass="ddlGroupBy" runat="server" Style="">
                                <asp:ListItem Value="Location">Location</asp:ListItem>
                                <asp:ListItem Value="Provider">Provider</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <div class="divBranchName" style="">
                            <label class="spnBranchName" style="">Payers:</label>
                            <div class="BranceInput">
                                <div class="reportdropdown" style="z-index: 1000">
                                    <a onclick="ShowMenuFilters('divPayerScenario',this);">
                                        <div class="selectedText">
                                            <label id="SelectInsurances">All Payers </label>

                                        </div>
                                        <div class="dropDownIcon" style="width: 8.5%; right: -4px; position: absolute; top: 1px; z-index: 2;">
                                            <img src="../../Images/dropdown.gif" style="width: 10px; margin-top: 2px; margin-left: 0px;" />

                                        </div>

                                    </a>
                                    <div id="divPayerScenario" class="div-multi-checkboxes-wrapper divPayerScenario" style="display: none; position: absolute; max-height: 15px; padding: 0; top: 4px; left: 0; width: 100%;">
                                        <div class="ddlselect analysisddlselect">
                                            <ul id="ulMultiPayerScenario">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                        <input type="checkbox" id="chkPayerScenarioARAgingSummaryAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                        <span>All Payers</span>
                                                        <input type="hidden" value="0" />

                                                    </label>

                                                </li>
                                                <asp:Repeater runat="server" ID="rptInsurances">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label onclick="Report(this)" style="float: left;">
                                                                <input type="checkbox" id="chkPayerScenarioARAgingSummary" class="chkPayerScenario chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("InsuranceId") %>' />
                                                                <span id="PayersName" class="checkBoxName"><%#Eval("Name") %></span>
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
                </div>
                <div class="col-6" id="divPracticeLocationId" style="width: 50% !important;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Location:</span>
                        <div class="BranceInput">
                            <div class="reportdropdown" style="z-index: 1000">
                                <a onclick="ShowMenuFilters('divPracticeLocation', this);">
                                    <div class="selectedText" id="AllLocations">
                                        All Locations
                                    </div>
                                    <div class="dropDownIcon" style="width: 8.5%; right: -4px; top: 3px; position: absolute;">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </a>
                                <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                    <div class="ddlselect ARAgingSummaryDynamicLocations ARAgingSummaryLocations">
                                        <ul id="ARAgingSummaryLocations">
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes" style="float: left;">
                                                    <input type="checkbox" id="chkARAgingSummaryLocationsAll" class="chk-multi-checkboxes-all" onclick="Report_ClickMultiCheckBoxAll(this,'ARAgingSummaryLocations'),GetPracticeStaffLocation('ARAgingSummaryLocations')" />
                                                    <span>All</span>
                                                    <input type="hidden" value="0" />
                                                </label>
                                            </li>
                                            <asp:Repeater runat="server" ID="rptLocation">
                                                <ItemTemplate>
                                                    <li style="float: left; width: 100%;">
                                                        <label style="float: left;">
                                                            <input type="checkbox" class="chk-multi-checkboxes" id="chkARAgingSummaryLocations" onclick="ReportAlert(this,'ARAgingSummaryLocations'),GetPracticeStaffLocation('ARAgingSummaryLocations')" value='<%#Eval("PracticeLocationsId") %>' />
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
                <div class="col-6" id="divReportServiceProvider" runat="server" style="width: 50% !important;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Provider :</span>
                        <div class="BranceInput">
                            <div class="reportdropdown" style="">
                                <a onclick="ShowMenuFilters('divServiceProvider', this);">
                                    <div class="selectedText" id="AllProviders">
                                        All Providers
                                    </div>
                                    <div class="dropDownIcon" style="width: 8.5%; right: -4px; top: 3px; position: absolute;">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </a>
                                <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                    <div class="ddlselect ARAgingSummaryDynamicProviders ARAgingSummaryProviders">
                                        <ul id="ProviderCollectionDynamicProviders">
                                            <asp:Repeater runat="server" ID="DynamicProviders">
                                                <ItemTemplate>
                                                    <li style="float: left; width: 100%;">
                                                        <label style="float: left;">
                                                            <input type="checkbox" id="chkARAgingDynamicProviders" class="chk-multi-checkboxes" onclick="ReportAlert(this)" value='<%#Eval("NPI") %>' disabled="disabled" />
                                                            <span class="PracticeStaff"><%#Eval("PracticeStaff") %></span>
                                                            <input type="hidden" value='<%#Eval("NPI") %>' class="StaffNPI" />
                                                            <input type="hidden" value='<%#Eval("PracticeStaffId") %>' />
                                                            <input type="hidden" value='<%#Eval("name") %>' class="locationname" />
                                                            <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' class="PracticeLocationsId" />
                                                        </label>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>


                                        <ul>
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes dynamicStaff" onclick="Report_ClickMultiCheckBoxAll(this);GetLocationNamePracticestaff()" style="float: left;">
                                                    <input type="checkbox" id="chkARAgingDynamicProvidersAll" class="chk-multi-checkboxes-all" disabled="disabled" />
                                                    <span>All Providers</span>
                                                    <input type="hidden" value="0" />
                                                </label>
                                            </li>
                                            <asp:Repeater runat="server" ID="rptProviders">
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
        </div>
                <div id="divDialogReportFilters" class="divDialogReportFilters" style="display: none"></div>
        ###endReport###




   
    </form>
</body>
</html>
