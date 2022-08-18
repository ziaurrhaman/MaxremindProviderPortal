<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProviderPortal/BillingMaster.master" CodeFile="PatientDemographics.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_PatientDemographics" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    ###startReport###

    <div class="Filter SearchCriteria">
        <div class="row">
            
            <div class="col-lg-3" style="padding-bottom: 5px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Post Date:</span>
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
            <div class="col-lg-3" style="margin-top: 4px !important;">
                <div>
                    <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientDemographics()" />
                    <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePatientDemographics()" />

                </div>
            </div>
        </div>
    </div>

    <div class="TimeSpan">
        <span style="font-weight: 600; color: black">Time Span:</span>
        <asp:Label runat="server" ID="TimeSpan" Style="color: grey"></asp:Label>

    </div>
    <div id="PatientContainer" style="float: left; /* margin: 1% 1% 1%; */width: 100%;">
        <div class="Grid">
            <div class="ReportGridPrint GridReports" style="height: 375px;">
                <table class="fixTable " style="width: 100%;">
                    <thead>
                        <tr>
                            <asp:HiddenField ID="sortBy" runat="server" />
                            <th style="width: 2%;" class="ReportHide">#
                            </th>
                            <th style="display: none" class="Report">Practice
                            </th>
                            <th style="width: 6%; cursor: pointer;" onclick="sort(this)" class="ReportHide">Account Number
                            </th>

                            <th style="width: 7%; cursor: pointer;" onclick="sort(this)" class="ReportHide">Last Name
                            </th>
                            <th style="width: 7%; cursor: pointer;" onclick="sort(this)" class="ReportHide">First Name
                            </th>
                            <th style="width: 4%; cursor: pointer;" onclick="sort(this)" class="ReportHide">DOB
                            </th>

                            <th style="width: 7%; cursor: pointer;" onclick="sort(this)" class="ReportHide">SSN
                            </th>


                            <th style="width: 4%; cursor: pointer;" onclick="sort(this)" class="ReportHide">Gender
                            </th>


                            <th style="width: 6%; cursor: pointer;" onclick="sort(this)" class="ReportHide">Phone
                            </th>
                            <th style="width: 10%; cursor: pointer;" onclick="sort(this)" class="ReportHide">Pri Ins
                            </th>
                            <%--/// Modified By Irfan Mahmood 15-Oct-2021///--%>
                            <th style="width: 7%; cursor: pointer;" onclick="sort(this)" class="ReportHide">Policy Number
                            </th>
                            <%--/// End Modified By Irfan Mahmood 15-Oct-2021///--%>
                            <th style="width: 8%; cursor: pointer;" onclick="sort(this)" class="ReportHide">Address
                            </th>
                            <th style="width: 3%; cursor: pointer;" onclick="sort(this)" class="ReportHide">City
                            </th>
                            <th style="width: 3%; cursor: pointer;" onclick="sort(this)" class="ReportHide">State
                            </th>
                            <th style="width: 3%; cursor: pointer;" onclick="sort(this)" class="ReportHide">Zip
                            </th>
                            <th style="display: none" class="Report">Phone
                            </th>
                            <th style="display: none" class="Report">Active
                            </th>
                            <th style="display: none" class="Report">Emergency Contact Name
                            </th>
                            <th style="display: none" class="Report">Pri Policy Number 
                            </th>
                            <th style="display: none" class="Report">Pri Termination Date
                            </th>
                            <th style="display: none" class="Report">Pri Terminate
                            </th>
                            <th style="display: none" class="Report">Sec Payer
                            </th>
                            <th style="display: none" class="Report">Sec Policy Number
                            </th>
                            <th style="display: none" class="Report">Sec Termination Date
                            </th>
                            <th style="display: none" class="Report">Sec Terminate
                            </th>
                        </tr>
                        <%--<tr class="removeForExcel">
                           <th>
                               <i class="fa fa-filter" style="color: #065172; font-size: 20px !important;" id="FilterIcon" onclick="FilterPatient(0, true)"></i>
                           </th>

                           <th>
                               <input type="text" id="txtPatientId" onkeyup="SetSearch(event)" onkeypress="return ValidateNumberExceptDot(event);" />
                           </th>
                           <th>
                               <input type="text" id="txtLastName" onkeyup="SetSearch(event)" onkeypress="return ValidateCharacters(event)" autocomplete="Last-Name" />
                           </th>
                           <th>
                               <input type="text" id="txtFirstName" onkeyup="SetSearch(event)" onkeypress="return ValidateCharacters(event)" autocomplete="First-Name" />
                           </th>

                           <th>
                               <asp:TextBox runat="server" ID="txtDateOfBirth" onkeyup="SetSearch(event)"></asp:TextBox>
                           </th>
                           <th>
                               <input type="text" id="txtSSN" onkeyup="SetSearch(event)" onkeypress="return ValidateNumberExceptDot(event);" />
                           </th>
                           <th>
                               <select id="ddlGender" style="width: 100%;" onchange="FilterPatient(0, true);">
                                   <option value=""></option>
                                   <option value="Male">Male</option>
                                   <option value="Female">Female</option>
                               </select>
                           </th>
                           <th>
                               <input type="text" id="txtPhone" onkeyup="SetSearch(event)" autocomplete="Phone" onkeypress="return ValidateForPhoneNumber(event);" />
                           </th>
                           <th>
                               <input type="text" id="txtPriIns" onkeyup="SetSearch(event)" autocomplete="off" />
                           </th>

                           <th>
                               <input type="text" id="txtPolicyNumber" onkeyup="SetSearch(event)" onkeypress="return ValidateCharactersNumber(event)" autocomplete="Policy-Number" />
                           </th>

                           <th style="width: 5%;">
                               <input type="text" id="txtAddress" onkeyup="SetSearch(event)" autocomplete="Address" />
                           </th>
                           <th style="width: 2%;">
                               <input type="text" id="txtCity" onkeyup="SetSearch(event)" autocomplete="City" onkeypress="return ValidateCharacters(event)" />
                           </th>
                           <th style="width: 2%;">
                               <input type="text" id="txtState" onkeyup="SetSearch(event)" autocomplete="State" onkeypress="return ValidateCharacters(event)" />
                           </th>
                           <th style="width: 2%;">
                               <input type="text" id="txtZip" onkeyup="SetSearch(event)" autocomplete="Zip" onkeypress="return ValidateNumberExceptDot(event);" />
                           </th>




                       </tr>--%>
                    </thead>
                    <tbody id="tbodyReportList" style="overflow-y: scroll;">
                        <asp:Repeater ID="rptPatients" runat="server">
                            <ItemTemplate>
                                <tr style="cursor: pointer">

                                    <td class="ReportHide"><i><%# Eval("RowNumber") %></i></td>
                                    <td style="display: none" class="Report"><%# Eval("Practice") %>
                                    </td>
                                    <td class="ReportHide"><%# Eval("PatientId") %></td>

                                    <td class="ReportHide">
                                        <%# Eval("LastName") %>
                                    </td>
                                    <td class="ReportHide">
                                        <%# Eval("FirstName") %>
                                    </td>
                                    <td class="ReportHide">
                                        <%# Eval("DateOfBirth", "{0:d}") %>
                                    </td>

                                    <td class="ReportHide">
                                        <%# Eval("SSN") %></td>
                                    <td class="ReportHide">
                                        <%# Eval("Gender") %>
                                    </td>

                                    <td class="ReportHide">
                                        <%# Eval("Cell") %>
                                    </td>
                                    <td class="ReportHide">
                                        <%# Eval("Name") %>
                                    </td>
                                    <td class="ReportHide">
                                        <%# Eval("PolicyNumber") %>
                                    </td>
                                    <td class="ReportHide">
                                        <%# Eval("Address") %>
                                    </td>
                                    <td class="ReportHide">
                                        <%# Eval("City") %>
                                    </td>
                                    <td class="ReportHide">
                                        <%# Eval("State") %>
                                    </td>
                                    <td class="ReportHide">
                                        <%# Eval("Zip") %>
                                    </td>
                                    <td style="display: none" class="Report"><%# Eval("Cell") %>
                                    </td>
                                    <td style="display: none" class="Report"><%# Eval("IsActive") %>
                                    </td>
                                    <td style="display: none" class="Report"><%# Eval("EmergencyContactName") %>
                                    </td>
                                    <td style="display: none" class="Report"><%# Eval("PolicyNumber") %></td>
                                    <td style="display: none" class="Report"><%# Eval("PriTerminationDate") %></td>
                                    <td style="display: none" class="Report"><%# Eval("PriTerminate") %></td>
                                    <td style="display: none" class="Report"><%# Eval("SecPayer") %></td>
                                    <td style="display: none" class="Report"><%# Eval("SecPollicyNo") %></td>
                                    <td style="display: none" class="Report"><%# Eval("SecTerminationDate") %></td>
                                    <td style="display: none" class="Report"><%# Eval("SecTerminate") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

                <input type="hidden" id="hdnTotalRows" runat="server" />
                <input type="hidden" id="hdnStartDate" runat="server" />
                <input type="hidden" id="hdnEndDate" runat="server" />
                <input type="hidden" id="hdnInsuranceId" runat="server" />
                <input type="hidden" id="hdnGender" runat="server" />

            </div>



        </div>


    </div>
    <script type="text/javascript">
        debugger;
        var Rows1 = "";
        var selfpay = $.trim($('ul#ulMultiPayerScenario li:first').text());
        if (selfpay == 'SelfPay') {
            $('ul#ulMultiPayerScenario li:first').remove();
        }
        function RowsChange(PageNumber, sortValue) {
            debugger;
            var params;
            pageNumber = PageNumber;
            Rows1 = $("#ddlPaging").val();

            var paging = true;

            if (_selectedReport_Filter != "") {
                params = {
                    Rows: Rows1,
                    PageNumber: pageNumber,
                    Gender: $("[id$='hdnGender']").val(),
                    PayerId: $("[id$='hdnInsuranceId']").val(),
                    Datefrom: $("[id$='hdnStartDate']").val(),
                    DateTo: $("[id$='hdnEndDate']").val(),
                    action: "Filter"
                };

                debugger
                Report_ReloadData(_selectedReport_Filter, params, paging);
            }


        }
    </script>
    <div id="CustomizePatientDemographics" style="display: none; padding: 20px;">
        <div class="row">
            
            <div class="col-lg-4" style="padding-bottom: 5px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Post Date:</span>
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
            <div class="col-lg-8 SelectDates" style="padding-bottom: 0px; padding-top: 20px !important;">
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
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Gender:</span>
                        <div class="clsPostDate BranceInput" id="divddlInsuranceType">
                            <asp:DropDownList ID="ddlGender" CssClass="" runat="server" Style="">
                                <asp:ListItem Value="">Select Gender</asp:ListItem>
                                <asp:ListItem Value="Male">Male</asp:ListItem>
                                <asp:ListItem Value="Female">Female</asp:ListItem>

                            </asp:DropDownList>
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
                                <a onclick="ShowMenuFilters('divPayerScenario', this);">
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
</asp:Content>

