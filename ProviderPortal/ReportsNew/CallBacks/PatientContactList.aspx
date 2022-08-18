<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientContactList.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientContactList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
        <div class="Filter SearchCriteria" style="display: none; height: auto !important;">
            <div class="row">
                <div class="col-lg-3">
                        <div id="divPatientSarch" runat="server" style="">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Patient Name:</span>
                                <div class="clsPatientId BranceInput" style="position: relative;">
                                    <input type="text" id="TxtPatientSearch" onkeyup="searchPatient(event,this)" />
                                    <%--<img src="../../Images/arrow_down5.PNG" style="width: 11px; margin-top: 11px; margin-left: -15px; position: absolute;" onclick="searchPatient(event,this)" />--%>
                                    <input type="hidden" id="hdnsearchpatientid" />
                                    <div id="SearchPatientList" class="PatientDetailsRptGrid" style="display: none"></div>
                                    <%--<div id="SearchPatientCustomize" style="display: none"></div>--%>
                                </div>
                            </div>
                        </div>

                    </div>
                <div class="col-3">
                    <div id="divActuvity" runat="server">

                        <div class="divBranchName">
                            <span class="spnBranchName" style="">Activity :</span>
                            <div class="clsPostDate BranceInput" id="divddlActuvity" onchange="EnableDisableDates();">
                                <asp:DropDownList ID="ddlActivity" CssClass="ddlActivity" runat="server" Style="">
                                    <asp:ListItem Value="">All</asp:ListItem>
                                    <asp:ListItem Value="30days">30 days</asp:ListItem>
                                    <asp:ListItem Value="90days">90 days</asp:ListItem>
                                    <asp:ListItem Value="180days">180 days</asp:ListItem>
                                    <asp:ListItem Value="1year">1 year</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>

                </div>
                <div class="col-3">
                    <div id="divGender">

                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Gender:</span>
                            <div class="clsPostDate BranceInput" id="divddlGender">
                                <asp:DropDownList ID="ddlGender" CssClass="ddlGender" runat="server">
                                    <asp:ListItem Value="">Both</asp:ListItem>
                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-3" style="margin-top: 0 !important;">
                    <div>
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientContactList()" />
                        <input class="btn primary" type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePatientContactList()" />

                    </div>
                </div>
            </div>


        </div>
            <%--            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>--%>
            <div class="GridReports" id="printableArea">
                <asp:Repeater ID="rptPatientClaimList" runat="server">
                    <HeaderTemplate>
                        <div>
                            <table>
                                <thead>
                                    <tr>
                                        <th>
                                            <span class="report-column-title">#</span><span></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'PatientId');">
                                            <span class="report-column-title">Num</span><span class="filterIcon asc"></span>
                                        </th>
                                        <%--<th class="asc" onclick="SortReportList(this,'Last Name');">
                                            <span class="report-column-title">Last</span><span></span>
                                        </th>--%>
                                        <th class="asc" onclick="SortReportList(this,'Patient Name');">
                                            <span class="report-column-title">Patient Name</span><span></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'Address');">
                                            <span class="report-column-title">Address</span><span></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'HomePhone');">
                                            <span class="report-column-title">Home</span><span></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'Cell');">
                                            <span class="report-column-title">Mobile</span><span></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'Email');">
                                            <span class="report-column-title">Email</span><span></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'Provider');">
                                            <span class="report-column-title">Provider</span><span></span>
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
                                <%# Eval("PatientId")%>
                            </td>
                            <%--<td>
                                <%# Eval("LastName")%>
                            </td>--%>
                            <td>
                                <%# Eval("PatientName")%>
                            </td>
                            <td>
                                <%# Eval("[Address]")%>
                            </td>
                            <td>
                                <%# Eval("HomePhone")%>
                            </td>
                            <td>
                                <%# Eval("Mobile")%>
                            </td>
                            <td>
                                <%# Eval("Email")%>
                            </td>
                            <td>
                                <%# Eval("Provider")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                </table>
                            </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnDiagnosisCode" />
            <asp:HiddenField runat="server" ID="hdnActuvity" />
            <asp:HiddenField runat="server" ID="hdnProviderId" />
            <asp:HiddenField runat="server" ID="hdnPayerId" />
            <asp:HiddenField runat="server" ID="hdnGender" />
            <asp:HiddenField runat="server" ID="hdnDOB" />
            <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <asp:HiddenField runat="server" ID="hdnProcedureCode" />


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
                            DiagnosisCode: $("[id$='hdnDiagnosisCode']").val(),
                            Activity: $("[id$='hdnActuvity']").val(),
                            ProviderId: $("[id$='hdnProviderId']").val(),
                            ProcedureCode: $("[id$='hdnProcedureCode']").val(),
                            Gender: $("[id$='hdnGender']").val(),
                            PayerId: $("[id$='hdnPayerId']").val(),

                            Rows: Rows1,
                            PageNumber: pageNumber,
                            SortBy: sortValue,
                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }


                }

            </script>
            <div style="display: none; padding: 20px;" id="CustomizeContactListFilter">
                <div class="row">
                    <div class="col-lg-4">
                        <div id="div1" runat="server" style="">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Patient Name:</span>
                                <div class="clsPatientId BranceInput" style="position: relative;">
                                    <input type="text" id="TxtPatientSearchCustomize" onkeyup="searchPatientCustomize(event,this)" />
                                    <%--<img src="../../Images/arrow_down5.PNG" style="width: 11px; margin-top: 11px; margin-left: -15px; position: absolute;" onclick="searchPatient(event,this)" />--%>
                                    <input type="hidden" id="hdnsearchpatientidCustomize" />
                                    <div id="SearchPatientListCustomize" class="PatientDetailsRptGrid" style="display: none"></div>
                                    <%--<div id="SearchPatientCustomize" style="display: none"></div>--%>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-4" style="padding-bottom: 10px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Activity :</span>
                            <div class="clsPostDate BranceInput" id="divddlActuvityCustomize" onchange="EnableDisableDates();">
                                <select name="ddlActuvity" id="ddlActivityCustomize" class="ddlActuvity" style="">
                                    <option value="">All</option>
                                    <option value="30days">30 days</option>
                                    <option value="90days">90 days</option>
                                    <option value="180days">180 days</option>
                                    <option value="1year">1 year</option>

                                </select>
                            </div>
                        </div>


                    </div>
                    <div class="col-lg-4" style="padding-bottom: 10px;">
                        <div id="divGender">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Gender:</span>
                                <div class="clsPostDate BranceInput" id="divddlGender">
                                    <asp:DropDownList ID="ddlGenderCustomize" CssClass="ddlGender" runat="server">
                                        <asp:ListItem Value="">Both</asp:ListItem>
                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6" style="padding-bottom: 10px; position: relative;">
                        <div id="divReportServiceProvider">
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
                                            <div class="ddlselect ClaimSummaryDynamicProviders ClaimSummaryProviders">

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

                    <div class="col-lg-6" style="">
                          <div id="divReportPayerScenario">
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
                                <div id="divPayerScenario" class="div-multi-checkboxes-wrapper divPayerScenario" style="display: none; width: 100%; position: absolute; max-height: 15px; padding: 0; top: 4px; left: 0;">
                                    <div class="ddlselect analysisddlselect">
                                        <ul id="ulMultiPayerScenario">
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                    <input type="checkbox" id="chkPayerScenarioARAgingSummaryAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                    <span>All Payers</span>
                                                    <input type="hidden" value="0" />

                                                </label>

                                            </li>
                                            <asp:Repeater runat="server" ID="rptInsurance">
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


                    <div class="col-lg-6">
                        <div id="divReportDiagnosis">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Diagnosis :</span>
                                <div class="clsDiagnosis BranceInput" id="divDiagnosis" style="">
                                    <table>
                                        <tr>
                                            <%--<td style="width: 140px" class="leftTd">
                                                <input type="text" id="txtIcdCode1" class="required" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc1');" style="width: 85%;" />
                                            </td>--%>
                                            <td class="leftTd">
                                                <input type="text" id="txtIcdCode1" runat="server" class="upperCase" onkeyup="searchIcDs('C',this.value, '' , this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode1');" style="float: left; width: 100%" />
                                                <span class="spnRemove" onclick="emptyICDVal(this, 1);"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                        </div>


                        <div id="divICDsSearched" style="width: 45%; left: 3%; margin-top: 0px; height: 305px; position: absolute; display: none; background-color: #fff; z-index: 999; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto;">
                            <div class="Grid" style="width: 99%; height: auto;">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Code</th>
                                            <th>Description</th>
                                        </tr>
                                    </thead>
                                    <tbody id="IcdsSearchedList">
                                    </tbody>
                                </table>
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
                                                <input type="text" id="txtCPTCode" runat="server" class="required" onkeyup="searchCPTs('C', this.value, '', this, event);" onchange="PopulateCPTCode(this, 'txtCPTDescription');" style="float: left; width: 91%;" />
                                                <span class="spnRemove" onclick="emptyCPTVal(this, 1);" style="position: absolute;">
                                                    <img src="../../Images/cancel.png" width="30" height="30" />
                                                </span>
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
