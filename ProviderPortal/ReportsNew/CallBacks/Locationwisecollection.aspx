<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Locationwisecollection.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_Locationwisecollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        .ddlselect {
            float: left;
            max-height: 170px;
            overflow-y: auto;
            margin-bottom: -2px;
            border: 1px solid #c4c4c4;
            background: white;
            margin-top: 6px;
        }

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
    </style>
    <form id="form1" runat="server">
        <div>
            ###startReport###

            <div class="Filter SearchCriteria" style="display: none">

                <div class="row">
                    <div class="col-lg-3">
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
                        <div class="col-lg-3" style="margin-top:0px !important;">
                            <div>
                                <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterLocationWiseCollection(this)" />
                                <input class='btn primary' type="button" title="Customize" value="Customize Filter" id="CustomizeReports" onclick="CustomizeLocationwisecollection()" />


                            </div>
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
                <thead id="locationwise">
                    <tr>
                        <th style="width: 0%">#</th>
                        <th class="center" style="width: 12%">
                            <span class="report-column-title">Location</span>
                        </th>


                        <th class=" center" style="width: 6%">
                            <span class="report-column-title">Procedure Frequency</span>
                        </th>
                        <th class="center" style="width: 6%">
                            <span class="report-column-title">Total Charges</span>
                        </th>
                        <th class="center" style="width: 6%">
                            <span class="report-column-title">BalanceDue</span>
                        </th>
                        <th class="center" style="width: 6%">
                            <span class="report-column-title">Inprocess</span>
                        </th>
                        <%--<th class="center tdassociated" style="width: 6%">
                                <span class="report-column-title">Associated Payments</span>
                            </th>--%>
                        <th class="center " style="width: 6%">
                            <span runat="server" id="lblswitch">Payments</span>

                        </th>


                    </tr>
                </thead>
                <tbody id="tbodyReportList" class="tbodyLocationWiseCollection">
                    <asp:Repeater ID="rptReportData" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="center"><%# Container.ItemIndex + 1 %></td>
                                <td class="AlignDate">
                                    <%--<%# Eval("Name")%>--%>
                                    <%# Convert.ToString(Eval("Name"))==""?"0":Eval("Name")%>
                                </td>
                                <td class="AlignDate">
                                    <%--<%# Eval("CLaimCount")%>--%>
                                    <%# Convert.ToString(Eval("CLaimCount"))==""?"0":Eval("CLaimCount")%>
                                </td>
                                <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("TotalCharges"))==""?"0.00":(Eval("TotalCharges")))%>
                                </td>
                                <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("BalanceDue"))==""?"0.00":(Eval("BalanceDue","{0:F2}")))%>
                                </td>
                                <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("Inprocess"))==""?"0.00":(Eval("Inprocess","{0:F2}")))%>
                                </td>
                                <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("Payments"))==""?"0.00":(Eval("Payments","{0:F2}")))%>
                                </td>



                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
        <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            
        <div class="dialogue" style="display: none"></div>
        <div class="CommonReports2" style="display: none"></div>
        <script>

            $('.message').hide();
            $('.Reports_Rows_Per_Page').hide();
            /*Added By Faiza Bilal 3-21-2022*/

            debugger;
            $("#txtDateFrom").text(DateFrom)
            $("#txtDateTo").text(DateTo)


            $("[id$='ddlPostTypeLocation']").val("PostDate")
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();

                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {
                        InsuranceId: $("[id$='hdnPayers']").val(),
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
                        DateType: $("#" + SubReportDivName).find("[id$='ddlPostType']").val(),
                        Rows: Rows1,
                        PageNumber: pageNumber,
                        ProviderId: $("[id$='hdnProvider']").val(),
                        LocationId: $("[id$='hdnLocation']").val(),
                    };

                    debugger
                    Report_ReloadData(_selectedReport_Filter, params, paging);
                }


            }
        </script>

        <div style="display: none; padding:20px;" id="CustomizeLocationwisecollection">
            <div class="row">
                <div class="col-lg-3">
                       <div class="" id="divReportFilterBy">
                <div id="div1" runat="server" style="padding-bottom: 45px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Date Type:</span>
                        <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                            <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
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
                <div class="col-lg-6 SelectDates" style="padding-bottom:0px;">
                <label style=""><b style="color: black">From:</b></label>
                <span>
                    <input type="date" id="CustomizeDateFrom" class="Datetxtbox CustomizeDate" style="" placeholder="Date From" />

                </span>
                <label><b style="color: black">To:</b></label>
                <span>
                    <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox CustomizeDate" placeholder="Date To" />
                </span>
            </div>


                <div class="col-lg-4">
                      
            <div class="divBranchName DivBrName">
                <span class="spnBranchName" style="">Filter By:</span>
                <div class="clsPostDate BranceInput" id="divddlGroupBy" onchange="EnableDisableGroup('LocationWiseCollection', this);">
                    <asp:DropDownList ID="ddlGroupBy" CssClass="ddlGroupBy" runat="server" Style="">
                        <asp:ListItem Value="Location">Location</asp:ListItem>
                        <asp:ListItem Value="Provider">Provider</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
                </div>
                <div class="col-lg-4">
                    <div id="divPracticeLocationId" style="padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Location:</span>
                    <div class="BranceInput">
                        <div class="reportdropdown" style="">
                            <a onclick="ShowMenuFilters('divPracticeLocation', this);">
                                <div class="selectedText" id="AllLocations">
                                    All Locations
                               
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-top: 0%;">
                                    <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                </div>
                            </a>
                            <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                <div class="ddlselect LocationsWiseCollectionLocations LocationsWiseCollectionDynamicLocations">
                                    <ul id="LocationsWiseCollectionLocations">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" style="float: left;">
                                                <input type="checkbox" id="chkLocationsWiseCollectionLocationAll" class="chk-multi-checkboxes-all" onclick="Report_ClickMultiCheckBoxAll(this,'LocationsWiseCollectionLocations'),GetPracticeStaffLocation('LocationsWiseCollectionLocations')" />
                                                <span>All</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptLocation">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label style="float: left;">
                                                        <input type="checkbox" class="chk-multi-checkboxes" id="chkLocationsWiseCollectionLocation" onclick="ReportAlert(this,'LocationsWiseCollectionLocations'),GetPracticeStaffLocation('LocationsWiseCollectionLocations')" value='<%#Eval("PracticeLocationsId") %>' />
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
                <div class="col-lg-4">
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
                                <div class="ddlselect LocationsWiseCollectionDynamicProviders LocationsWiseCollectionProviders">
                                    <ul id="LocationsWiseCollectionDynamicProviders">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                <input type="checkbox" id="DynamicLocationsWiseProviderChkAll" class="chk-multi-checkboxes-all" disabled="disabled" />
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
                <div class="col-lg-4" style="padding-bottom: 10px;">
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
           

         
          
          
            
            
        </div>

        ###endReport###

        ###StartTbody###
           
                     <asp:Repeater ID="rptReportDataTbody" runat="server">
                         <ItemTemplate>
                             <tr>
                                 <td class="center"><%# Container.ItemIndex + 1 %></td>
                                 <td class="AlignDate">
                                     <%--<%# Eval("Name")%>--%>
                                     <%# Convert.ToString(Eval("Name"))==""?"0":Eval("Name")%>
                                 </td>
                                 <td class="AlignDate">
                                     <%-- <%# Eval("CLaimCount")%>--%>
                                     <%# Convert.ToString(Eval("CLaimCount"))==""?"0":Eval("CLaimCount")%>
                                 </td>
                                 <td class="AlignPayment">$<%#(Convert.ToString(Eval ("TotalCharges"))==""?"0.00":(Eval("TotalCharges","{0:F2}")))%>
                                 </td>
                                 <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("BalanceDue"))==""?"0.00":(Eval("BalanceDue","{0:F2}")))%>
                                 </td>
                                 <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("Inprocess"))==""?"0.00":(Eval("Inprocess","{0:F2}")))%>
                                 </td>
                                 <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("Payments"))==""?"0.00":(Eval("Payments","{0:F2}")))%>
                                 </td>


                             </tr>
                         </ItemTemplate>

                     </asp:Repeater>

        <asp:HiddenField runat="server" ID="hdnLocation" />
            <asp:HiddenField runat="server" ID="hdnPayers" />
            <asp:HiddenField runat="server" ID="hdnProvider" />

        ###EndTbody###
        ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
    </form>
</body>
</html>
