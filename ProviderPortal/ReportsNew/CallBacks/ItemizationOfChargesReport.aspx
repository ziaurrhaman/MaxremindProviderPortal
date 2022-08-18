<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemizationOfChargesReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ItemizationOfChargesReport" %>

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
                .SelectFilterMessage {
                    align-items: center;
                    text-align: center;
                    margin-top: 60px;
                    border: 2px solid #b7b4b4;
                    padding: 25px 10px;
                    color: black;
                    background: #eeefef;
                    width: 30%;
                    margin-left: auto;
                    border-radius: 6px;
                    margin-right: auto;
                    margin-bottom: 60px;
                }
            </style>
            <script type="text/javascript">
                debugger
                

            </script>
            <div class="Filter SearchCriteria" style="height: auto !important;">

                <div class="row">

                    <div class="col-lg-3">
                        <div id="divPatientSarch" style="position: relative;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Patient Name:</span>
                                <div class="clsPatientId BranceInput" style="position:relative;">
                                    <input type="text" id="TxtPatientSearch" onclick="searchPatient(event,this)" onkeyup="searchPatient(event,this)" style="width: 100% !important;" />
                                    <%--<img src="../../Images/arrow_down5.PNG" style="width: 11px; margin-top: 11px; margin-left: -15px; position: absolute;" onclick="searchPatient(event,this)" />--%>
                                    <input type="hidden" id="hdnsearchpatientid" />
                                     <div id="SearchPatientList" class="CustomPatientList" style="display: none"></div>
                                </div>
                            </div>
                           

                        </div>
                    </div>

                    <%--                    <div class="col-lg-3 customAsDate">
                        <div id="divAsof" style="padding-bottom: 45px; float: left !important; margin-left: 1%; margin-right: 40px; clear: none;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="float: left; margin-left: 0%;">As of:</span>
                            <div class="clsPatientId BranceInput">
                                <input type="date" id="dateasof" style="height: 29px; width: 100%" onchange="EnableDisableFilter(this)" />
                            </div>
                        </div>
                    </div>
                    </div>--%>
                    <div class="col-lg-3" style="margin-top: 0px !important;">
                        <div>
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterItemizationOfChargesReport(this)" />

                            <input class="btn primary" type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeItemizationOfChargesReport()" />


                        </div>

                    </div>

                </div>


            </div>
            <div style="display: none; padding: 20px;" id="CustomizeItemizationOfChargesReport">

                <div class="row">
                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divAgingBy" style="padding-bottom: 0px !important; width: 100% !important;">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Date Type:</span>
                                <div class="clsPostDate BranceInput" id="DivddlAgingBy" onchange="EnableDisableFilter(this)">
                                    <asp:DropDownList ID="CustomizeDateType" CssClass="ddlPostType" runat="server" Style="">
                                        <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                        <asp:ListItem Value="PostDate">Post Date</asp:ListItem>
                                        <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6" style="padding-bottom: 10px;">
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
                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divPatientSarchCustomize" style="position: relative;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Patient Name:</span>
                                <div class="clsPatientId BranceInput">
                                    <input type="text" id="TxtPatientSearchCustomize" onkeyup="searchPatientCustomize(event,this)" style="width: 100% !important; height: 30px;" />
                                    <%--<img src="../../Images/arrow_down5.PNG" style="width: 11px; top: 37px; right: 6px; position: absolute;" onclick="searchPatientCustomize(event,this)" />--%>
                                    <input type="hidden" id="hdnsearchpatientidCustomize" />
                                </div>
                            </div>
                            <div id="SearchPatientListCustomize" class="CustomPatientList" style="display: none"></div>

                        </div>
                    </div>
                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divReportPayerScenario">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Payer Scenario :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPayerScenario', this);">
                                            <div class="selectedText">
                                                All Payer Scenario
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; position: absolute; top: 3px; right: 0;">
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
                                                                    <span id="PayersName"><%#Eval("Name") %></span>
                                                                    <%--<span><%#Eval("Payers") </span> --%>
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
                    <div class="col-lg-6 CustomPracticeLocation" style="padding-bottom: 10px;">
                        <div id="divPracticeLocationId">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Location:</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPracticeLocation', this);">
                                            <div class="selectedText">
                                                All Locations
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; position: absolute; top: 3px; right: 0;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect">
                                                <ul id="ulMultiPracticeLocation" onchange="GetServiceProviderDropDown();">
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
                                                                <label name='<%#Eval("PracticeLocationsId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
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
                    <div class="col-lg-6 CustomReportServiceProvider" style="padding-bottom: 10px;">
                        <div id="divReportServiceProvider">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Provider :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divServiceProvider', this);">
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
                                                                <label name='<%#Eval("PracticeStaffId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
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

                </div>
                <div id="ReportPatient"></div>
            </div>
            <div id="reportItem"></div>

            ###endReport###

        </div>
    </form>
</body>
</html>
