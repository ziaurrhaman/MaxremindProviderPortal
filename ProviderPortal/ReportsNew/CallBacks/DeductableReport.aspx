<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeductableReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_DeductableReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                                                     <asp:ListItem Value="BillDate">Bill Date</asp:ListItem>

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
                                     <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterDeductableReport()" />
                                     <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeDeductableReport()" />

                                 </div>
                             </div>
                         </div>

                     </div>
            <div class="TimeSpan">
                <span style="font-weight: 600; color: black">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan" Style="color: grey"></asp:Label>

            </div>


            <div class="Grid GridReports" id="printableArea">
                <div class="department_table scroll">
                    <table style="width: 100%; text-align: center !important; border-color: #afdbec;">
                        <tbody style="border: 1PX SOLID WHITE; color: BLACK" id="Deductible">
                            <tr style="width: 100%; background-color: #aadeff; font-weight: bold; font-size: smaller">

                                <td>Deductible:  
                                    <asp:Label runat="server" ID="lblDeductible" Style="color: grey"></asp:Label></td>

                                <td>Co Insurance:
                                    <asp:Label runat="server" ID="lblCoInsurance" Style="color: grey"></asp:Label></td>

                                <td>Co Payment:
                                    <asp:Label runat="server" ID="lblCoPayment" Style="color: grey"></asp:Label></td>

                                <td>Total PR:
                                    <asp:Label runat="server" ID="lblTotalPR" Style="color: grey"></asp:Label></td>

                            </tr>
                        </tbody>
                    </table>
                    <table border="1" style="width: 100%; text-align: center !important; border-color: #afdbec;">
                        <thead style="border: 1PX SOLID WHITE; color: BLACK">
                            <tr style="background-color: #aadeff;">
                                <th>
                                    <span class="report-column-title ml-10x">#</span><span></span>
                                </th>

                                <th class="asc pl-15x">
                                    <span class="report-column-title">Cpt</span><span></span>
                                </th>
                                <th class="asc pl-15x">
                                    <span class="report-column-title">Claim</span><span></span>
                                </th>
                                <th class="asc pl-15x">
                                    <span class="report-column-title">Pat</span><span></span>
                                </th>
                                <th class="asc pl-15x">
                                    <span class="report-column-title">DOS</span><span></span>
                                </th>
                                <%--  <th class="asc pl-15x">
                                                <span class="report-column-title">Created <br />Date</span><span></span>
                                            </th>--%>
                                <th class="asc pl-15x ">
                                    <span class="report-column-title">Pri Inc</span><span></span>
                                </th>
                                <th class="asc pl-15x">
                                    <span class="report-column-title">Pri Status</span><span></span>
                                </th>
                                <th class="asc pl-15x ">
                                    <span class="report-column-title">Sec Inc</span><span></span>
                                </th>

                                <th class="asc pl-15x">
                                    <span class="report-column-title">Sec Status</span><span></span>
                                </th>

                                <th class="asc pl-15x">
                                    <span class="report-column-title">Charges</span><span></span>
                                </th>
                                <th class="asc pl-15x">
                                    <span class="report-column-title">Paid Amt.</span><span></span>
                                </th>
                                <th class="asc pl-15x">
                                    <span class="report-column-title">Bal Due</span><span></span>
                                </th>

                                <th class="asc pl-15x">
                                    <span class="report-column-title">PR</span><span></span>
                                </th>
                                <th class="asc pl-15x">
                                    <span class="report-column-title">PR Amt.</span><span></span>
                                </th>



                            </tr>
                        </thead>
                        <tbody id="tbodyReportList">
                            <asp:Repeater ID="rptDeductableReport" runat="server" OnItemDataBound="rptDeductableReport_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <%--<td>
                                                        <%# Eval("ClaimChargesId")%>
                                                    </td>--%>
                                        <td class="align_center">
                                            <%# Eval("CptCode")%>
                                        </td>
                                        <td class="align_centre">
                                            <%# Eval("ClaimId")%>
                                        </td>
                                        <td class="align_center">
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td class="align_center">
                                            <%# Eval("DOS")%>
                                        </td>
                                        <%-- <td>
                                                        <%# Eval("CreatedDate")%>
                                                    </td>--%>
                                        <td title="<%# Eval("PrimaryInsurance")%>">
                                            <asp:Label runat="server" ID="lblPriIns"></asp:Label>
                                        </td>
                                        <td>
                                            <%# Eval("PriSubmissionStatus")%>
                                        </td>
                                        <td title="<%# Eval("SecondaryInsurance")%>">
                                            <asp:Label runat="server" ID="lblsecins"></asp:Label>
                                        </td>

                                        <td>
                                            <%# Eval("SecSubmissionStatus")%>
                                        </td>
                                        <td class="align_right">
                                            <%# Eval("TotalCharges")%>
                                        </td>
                                        <td class="align_right">
                                            <%# Eval("PaidAmount")%>
                                        </td>
                                        <td class="align_right">
                                            <%# Eval("BalanceDue")%>
                                        </td>

                                        <td>
                                            <%# Eval("CodeDescription").ToString().Substring(0,11)%>
                                        </td>
                                        <td class="align_right">
                                            <%# Eval("AdjustedAmount")%>
                                        </td>



                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <input type="hidden" id="hdnUserId" runat="server" value="0" />
            <input type="hidden" id="hdnDateType" runat="server" value="0" />
            <input type="hidden" id="hdnStartDate" runat="server" value="0" />
            <input type="hidden" id="hdnEndDate" runat="server" value="0" />
            <input type="hidden" id="hdnPracticeLocationId" runat="server" />
            <input type="hidden" id="hdnProviderId" runat="server" />
            <input type="hidden" id="hdnInsuranceId" runat="server" />
            <input type="hidden" id="hdnInsuranceType" runat="server" />
            <input type="hidden" id="hdnPriClaimStatus" runat="server" />
            <input type="hidden" id="hdnSecClaimStatus" runat="server" />
            <input type="hidden" id="hdnReasonCode" runat="server" value="0" />
            <script>
                var Rows1 = ""; var UserId = 0;
                function RowsChange(PageNumber, sortValue) {

                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();
                    //UserId = $("[id$='hdnUserId']").val();
                    var StartDate = $("[id$='hdnStartDate']").val();
                    var EndDate = $("[id$='hdnEndDate']").val();
                    var paging = true;
                    var DateType = $("#" + SubReportDivName).find("#ddlPostType").val();

                    if (_selectedReport_Filter != "") {
                        params = {

                            Rows: Rows1,
                            PageNumber: pageNumber,
                            SortBy: sortValue,
                            //UserId: UserId,
                            PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                            ProviderId: $("[id$='hdnProviderId']").val(),
                            Insurance: $("[id$='hdnInsuranceId']").val(),
                            InsuranceType: $("[id$='hdnInsuranceType']").val(),
                            StartDate: StartDate,
                            EndDate: EndDate,
                            DateType: DateType,
                            ClaimStatus: $("[id$='hdnPriClaimStatus']").val() || $("[id$='hdnSecClaimStatus']").val(),
                            ReasonCodeValues: $("[id$='hdnReasonCode']").val(),
                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }
                }
            </script>
            <div id="CustomizeDeductableReport" style="display: none; padding: 20px;">
                <div class="row">
                    <div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                            <asp:ListItem Value="BillDate">Bill Date</asp:ListItem>

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
                    <div class="col-lg-6 SelectDates" style="padding-bottom: 0px; padding-top: 0px !important;">
                        <label style=""><b style="color: black">From:</b></label>
                        <span>
                            <input type="date" id="CustomizeDateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox" placeholder="Date To" />
                        </span>
                    </div>


                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divInsuranceType">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Insurance Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlInsuranceType">
                                    <asp:DropDownList ID="ddlInsuranceType" CssClass="" runat="server" Style="">
                                        <asp:ListItem Value="">Select Insurance Type</asp:ListItem>
                                        <asp:ListItem Value="Pri">Primary Insurance</asp:ListItem>
                                        <asp:ListItem Value="Sec">Secondary Insurance</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div class="divPatient" id="divPatient">
                            <fieldset class="divTable" id="divPR">
                                <legend><span class="spnTimeSpan" id="AgencyReportFilterBox_tdlblPR">PR:</span></legend>
                                <div class="row" id="div2">
                                    <div id="divchk">
                                        <input type="checkbox" class="multicheckbox" name="chk" id="all" value="" checked="checked" onclick="DefaultChkbox()" />All                                                                          
                                     <input type="checkbox" class="multicheckbox" name="chk" id="ChkDeductable" value="1" onclick="DefaultChkbox()" />Deductable                                      
                                     <input type="checkbox" class="multicheckbox" name="chk" id="ChkCoInsurance" value="2" onclick="DefaultChkbox()" />Co Insurane                                      
                                     <input type="checkbox" class="multicheckbox" name="chk" id="ChkCoPayment" value="3" onclick="DefaultChkbox()" />Co Payment                                                                                                                                              
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div id="divReportClaimStatus" style="padding-bottom: 45px;" class="none-d">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName claim-status-label">Claim Status :</span>
                                <div class="BranceInput claim-status-input">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divCalimStatus',this);">
                                            <div class="selectedText">
                                                All Claims
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
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
                                                                    <span><%#Eval("SubmissionStatus") %></span>
                                                                    <input type="hidden" value='<%#Eval("SubmissionStatusId") %>' id="SubmissionStatusId" />
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
                        <div id="divReportPayerScenario" style="padding-bottom: 45px">
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
                </div>
            </div>
        ###endReport###
   
    </form>
</body>
</html>
