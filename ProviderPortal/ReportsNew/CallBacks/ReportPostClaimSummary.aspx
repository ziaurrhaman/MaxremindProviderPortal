k<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportPostClaimSummary.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_ReportPostClaimSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
            .GridReports table tr td {
    padding-left: 132px;
    padding-right: 6px !important;
}
        </style>
        <script src="../../../Scripts/tableHeadFixer.js"></script>
        <div class="Filter SearchCriteria PostClaimsFilter" style="display: none;">
            <div class="row">
                <div class="col-lg-3">
                    <div id="divPostType" style="width: 100% !important;">

                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="float: left; margin-left: 0%;">Date Type:</span>
                            <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableFilter(this)" style="width: 65% !important;">
                                <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server">
                                    <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                    <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                    <asp:ListItem Value="SubmissionDate">Submission Date</asp:ListItem>
                                </asp:DropDownList>
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
                <div class="col-lg-3" style="padding: 0;">
                    <div id="divBillDates">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="" id="Dateslbl">Dates:<span style="color: red; display: none">*</span></span>
                            <div class="BranceInput">
                                <div class="ReportPostClaimSummary-fields" style="width: 100%">
                                   
                                            <input type="date" id="DateFrom" class="required" autocomplete="off" />
                                      
                                   

                                            <input type="date" id="DateTo" class="required" autocomplete="off" />
                                      
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
                <%--   <div class="col-lg-3">
                    <div id="divReportReportType">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="float: left; margin-left: 0%;">Report Type :</span>
                            <div class="clsPostDate BranceInput" id="divddlReportType">
                                <asp:DropDownList ID="ddlReportType" CssClass="ddlReportType" runat="server" onchange="ChangeReportType(this)">
                                    <asp:ListItem Value="PROLevel">CPT Wise</asp:ListItem>
                                    <asp:ListItem Value="CLMLevel">Claim Wise</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                </div>--%>


                <div class="col-lg-3" style="margin-top: 0 !important;">
                    <input class="btn primary" type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPostClaimSummary()" style="margin-top: -2px !important;" />
                    <input class="btn primary" type="button" title="Customize" value="Customize" id="CustomizeFilter" onclick="CustomizePostClaimSummary()" style="margin-top: -2px !important;" />


                </div>
            </div>
        </div>
        <div style="text-align: center" class="TimeSpan" id="TimeSpan">
            <span style="font-weight: 600">Time Span:</span>
            <asp:Label runat="server" ID="txtDateFrom"></asp:Label>-<asp:Label runat="server" ID="txtDateTo"></asp:Label>
        </div>
        <div class="GridReports" id="printableArea">

            <table class="fixTable">
                <thead style="border: 1px solid white; background-color: #c9e6f3; color: black" class="RpostClaimsThead">
                    <tr>
                        <th style="text-align: center">Procedure Code</th>
                        <th style="text-align: center">Frequency</th>
                        <th style="text-align: center">Charges</th>
                        <th style="text-align: center">Payments</th>
                        <th style="text-align: center">AR</th>
                    </tr>
                </thead>
                <tbody class="checkdetailTbody">
                    <asp:Repeater runat="server" ID="rptpostlciam" OnItemDataBound="rptpostlciam_ItemDataBound">
                        <ItemTemplate>



                            <tr runat="server" id="ProviderNameTr" style="display: none;">
                                <td></td>
                                <td></td>
                                <td style="color: blue; cursor: pointer; font-size: 14px; width: 100%; text-decoration: underline; padding-left: 28px;" onclick="OpenDialoguePostClaim(this)">
                                    <asp:Label runat="server" ID="LBLProviderName" CssClass="ProviderName"></asp:Label></td>
                                <td></td>
                                <td></td>

                            </tr>
                            <tr runat="server" id="ColumnsTr" style="display: none; border: 1px solid; background-color: #c9e6f3; line-height: 1.5;">
                                <td style="font-weight: 600; text-align: center; width: 20%">ProcedureCode</td>
                                <td style="font-weight: 600; text-align: center; width: 20%">Frequency</td>
                                <td style="font-weight: 600; text-align: center; width: 20%">Charges</td>
                                <td style="font-weight: 600; text-align: center; width: 20%">Payments</td>
                                <td style="font-weight: 600; text-align: center; width: 20%">AR</td>
                            </tr>
                            <tr runat="server" id="DataRowTr" style="display: none; border: 1px solid #ccc">

                                <td style="text-align: center; width: 20%; border-right: 1px solid #ccc"><%# Eval("ProcedureCode")%></td>
                                <td style="text-align: center; width: 20%; border-right: 1px solid #ccc"><%# Eval("Frequency")%></td>
                                <td style="text-align: right; width: 20%; border-right: 1px solid #ccc"><%# Eval("Charges","{0:c}")%></td>
                                <td style="text-align: right; width: 20%; border-right: 1px solid #ccc"><%# Eval("Payments","{0:c}")%></td>
                                <td style="text-align: right; width: 20%"><%#Eval("AR","{0:c}")%></td>
                            </tr>
                            <tr runat="server" id="ProviderSummaryTr" style="border: 1px solid; width: 100%; background-color: #ecebeb; display: none">
                                <td style="font-weight: 600; font-size: 14px; text-align: center; width: 20%">Total</td>

                                <td style="text-align: center; width: 20%">
                                    <asp:Label runat="server" ID="lblFrequency"></asp:Label></td>
                                <td style="text-align: right; width: 20%">
                                    <asp:Label
                                        runat="server" ID="lblCharges"></asp:Label></td>
                                <td style="text-align: right; width: 20%">
                                    <asp:Label runat="server" ID="lblPayments"></asp:Label></td>
                                <td style="text-align: right; width: 20%">
                                    <asp:Label
                                        runat="server" ID="lblAR"></asp:Label></td>
                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>

                <asp:HiddenField runat="server" ID="hdnDateType" />
                <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
                <asp:HiddenField runat="server" ID="hdnPlaceOfService" />
                <asp:HiddenField runat="server" ID="hdnproviders" />
                <asp:HiddenField runat="server" ID="hdnpayer" />
                <asp:HiddenField runat="server" ID="hdnClaimStatus" />
                <asp:HiddenField runat="server" ID="hdnReportTypeLevel" />
                <asp:HiddenField runat="server" ID="hdnPOSCode" />
                <asp:HiddenField runat="server" ID="hdnFileSearchId" />
                <asp:HiddenField runat="server" ID="hdnStartDate" />
                <asp:HiddenField runat="server" ID="hdnEndDate" />
            </table>
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <div id="divDialogReportFilters" class="divDialogReportFilters" style="display: none;"></div>

        </div>

        <script type="text/javascript">
            $(document).ready(function () {
                $('.message').hide();
                //$("#divReportServiceProvider *").prop('disabled', true);
                //$("#divPracticeLocation *").prop('disabled', false);
                //$('.chkPracticeLocation').prop("checked", false)
                //$('#chkServiceProviderAll').prop("checked", false)
                //$('#chkPracticeLocationAll').prop("checked", false)
                //$("[id$='rbReportTimeSpanMonthToDate']").prop("checked", true)

            });
            $(".fixTable").tableHeadFixer();
        </script>

        <div style="display: none; padding: 20px;" id="CustomizePostClaimSummary">
            <div class="row">


                <div class="col-lg-4">
                    <div id="divPostType" style="width: 100% !important;">

                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="float: left; margin-left: 0%;">Date Type:</span>
                            <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableFilter(this)">
                                <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server">
                                    <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                    <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                    <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                    <asp:ListItem Value="SubmissionDate">Submission Date</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div id="divPracticeStaffOnNpiNum" style="padding-bottom: 45px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="float: left; margin-left: 0%;">Providers :</span>
                            <div class="clsPatientId BranceInput" onchange="EnableDisableFilter(this)">
                                <asp:DropDownList ID="ProvidersCustomize" CssClass="ddlPatientList" runat="server" Style=""></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Bill Dates:</span>
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

                 <div class="col-lg-4" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">From:</span>
                            <div class="BranceInput">
                             <input type="date" id="CustomizeDateFrom" class="Datetxtbox CustomizeDate" style="width:100%;" placeholder="Date From" onchange="EnableDisableFilter(this)" autocomplete="off" />
                            </div>
                        </div>
                    </div>

                 <div class="col-lg-4" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">To:</span>
                            <div class="BranceInput">
                               <input type="date" style="width:100%;" id="CustomizeDateTo" class="Datetxtbox CustomizeDate" placeholder="Date To" onchange="EnableDisableFilter(this)" autocomplete="off" />
                            </div>
                        </div>
                    </div>
             <%--   <div class="col-lg-3">
                    <div class="SelectDates" id="divBillDates" style="padding-bottom: 5px; padding-top: 24px !important;">
                        <label style=""><b style="color: black"></b></label>
                        <span>
                            

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            
                        </span>
                    </div>
                   
                </div>--%>
                <div class="col-lg-4">
                    <div id="divReportReportType" style="padding-bottom: 45px">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="float: left; margin-left: 0%;">Report Type :</span>
                            <div class="clsPostDate BranceInput" id="divddlReportType">
                                <asp:DropDownList ID="ddlReportTypeCustomize" CssClass="ddlReportType" runat="server" onchange="ChangeReportType(this)">
                                    <asp:ListItem Value="PROLevel">CPT Wise</asp:ListItem>
                                    <asp:ListItem Value="CLMLevel">Claim Wise</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-4">
                    <div id="divReportPayerScenario">
                        <div>
                            <div class="divBranchName" style="">
                                <label class="spnBranchName">Payers:</label>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="z-index: 1000">
                                        <a onclick="ShowMenuFilters('divPayerScenario',this);">
                                            <div class="selectedText">
                                                <label id="SelectInsurances">All Payers </label>
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; right: -9px; position: absolute;">
                                                <img src="../../Images/dropdown.gif" style="width: 10px; margin-top: 2px; margin-left: 0px;" />
                                            </div>
                                        </a>
                                        <div id="divPayerScenario" class="div-multi-checkboxes-wrapper divPayerScenario" style="display: none; max-height: 15px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect analysisddlselect ddlpayerselect">
                                                <ul id="ulMultiPayerScenario">
                                                    <li
                                                        style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                            <input type="checkbox" id="chkPayerScenarioAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                            <span>All Payers</span>
                                                            <input type="hidden" value="0" />

                                                        </label>

                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptInsurances">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label onclick="Report(this)" style="float: left;">
                                                                    <input type="checkbox" class="chkPayerScenario chk-multi-checkboxes" checked="checked" onclick="CheckedPayers(this),Report(this)" value='<%#Eval("InsuranceId") %>' />
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
                </div>

                <div class="col-lg-8" style="position: relative; padding-bottom: 10px;">
                    <div id="divFileSearch" style="">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Files :</span>
                            <div class="BranceInput">
                                <div class="reportdropdown" style="z-index: 1000; width: 48% !important; float: left;">
                                    <a onclick="ShowMenuFilters('divFileStatus',this);">
                                        <div class="selectedText">
                                            All Files
                                        </div>
                                        <div class="dropDownIcon" style="float: right; margin-right: 7%;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divFileStatus" class="div-multi-checkboxes-wrapper divFileStatus" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                        <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                            <ul id="ulMultiFileStatus">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                        <input type="checkbox" id="chkFileStatusAll" class="chk-multi-checkboxes-all" />
                                                        <span>All Files</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="RptFile">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label onclick="Report_ClickMultiCheckBox(this);" style="width: 100%;">

                                                                <input type="checkbox" class="MultichkFileStatus chk-multi-checkboxes" onclick="ReportAlert(this)" value='<%#Eval("UploadFilesId") %>' style="float: left" />

                                                                <span style="float: left; width: 93%;" class="Filename"><%#Eval("FileName") %></span>
                                                                <input type="hidden" value='<%#Eval("UploadFilesId") %>' id="FileId" />
                                                            </label>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>

                                    </div>
                                </div>



                                <div class="clsPatientId " id="FileSearch" style="width: 48%; float: right; position: relative;">
                                    <asp:TextBox runat="server" ID="txtFileSearch" placeholder="Search Files..." CssClass="required" Style="height: 30px" onkeyup="filesearchfunction(event)"></asp:TextBox>
                                    <input type="hidden" runat="server" id="Hidden1" />
                                    <div id="FileSearchdiv" class="Grid" style="position: absolute; z-index: 100; max-height: 150px; overflow-y: scroll; display: none">
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="col-lg-4" style="padding-bottom: 10px;">
                    <div id="divPlaceOfServiceReport">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="float: left; margin-left: 0%;">Place Of Service:</span>

                            <div class="BranceInput">
                                <div class="reportdropdown" style="z-index: 1000">
                                    <a onclick="ShowMenuFilters('divPlaceOfService',this);">
                                        <div class="selectedText">
                                            All Place Of Services
                                        </div>
                                        <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -2%;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divPlaceOfService" class="div-multi-checkboxes-wrapper divPlaceOfService" style="display: none; max-height: 215px; background: white; border: 1px solid #ccc; padding: 4px; z-index: 1; position: absolute; top: 27px; left: 0; width: 99%;">
                                        <div style="float: left; max-height: 170px; overflow-y: auto; overflow-x: hidden; width: 100%; margin-top: 1%; position: relative">
                                            <ul id="ulMultiPlaceOfService">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                        <input type="checkbox" id="chkPlaceOfServiceAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                        <span>All</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptPlaceOfService">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                <input type="checkbox" class="chkPlaceOfService chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("POSCode") %>' />
                                                                <span><%#Eval("PlaceOfService") %></span>
                                                                <input type="hidden" value='<%#Eval("POSCode") %>' id="POSCode" />
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
                <div class="col-lg-4" style="padding-bottom: 10px;">
                    <div id="divReportClaimStatus">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName claim-status-label">Claim Status :</span>
                            <div class="BranceInput claim-status-input">
                                <div class="reportdropdown" style="z-index: 1000">
                                    <a onclick="ShowMenuFilters('divCalimStatus',this);">
                                        <div class="selectedText">
                                            All Claims
                                        </div>
                                        <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -2%;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divCalimStatus" class="div-multi-checkboxes-wrapper divCalimStatus" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                        <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                            <ul id="ulMultiCalimStatus">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                        <input type="checkbox" id="chkCalimStatusAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                        <span>All Claims</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptCalimStatus">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                <input type="checkbox" class="chkCalimStatus chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("SubmissionStatusId") %>' />
                                                                <span class="ClaimStatus" value='<%#Eval("SubmissionStatus") %>'><%#Eval("SubmissionStatus") %></span>
                                                                <input type="hidden" value='<%#Eval("SubmissionStatusId") %>' id="ClaimStatusId" />
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
                <div class="col-lg-4">
                    <div id="divCPT" style="padding-bottom: 45px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">CPT:</span>
                            <div class="clsDiagnosis BranceInput" style="position: relative;">

                                <input type="text" id="txtServiceCode" placeholder="Search CPT" class="required" runat="server" onkeyup="ServiceCode(event, this)" />
                                <div class="divselectedServiceCode">

                                    <div id="divCPTSearched" style="width: 100%; max-height: 250px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto; margin-top: 0%; margin-bottom: 10px;">
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
                                                <tbody id="CPTSearchedList"></tbody>
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

    </form>
</body>
</html>
