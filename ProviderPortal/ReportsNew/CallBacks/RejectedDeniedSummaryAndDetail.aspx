<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RejectedDeniedSummaryAndDetail.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_RejectedDeniedClaims" %>

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
        </style>
        <div>
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

                    <div class="col-lg-4" style="padding-top: 9px;">
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterRejectedDeniedSummaryAndDetail()" />
                        <input class='btn primary' type="button" title="Customize Reports" value="Customize Reports" id="CustomizeReports" onclick="CustomizeRejectedDeniedSummaryAndDetail()" />


                    </div>
                </div>

            </div>




            <asp:Repeater ID="rptSummary" runat="server" OnItemDataBound="rptSummary_ItemDataBound">
                <HeaderTemplate>
                    <div class="GridReports RejectedDeniedSummary" id="printableArea">
                        <table style="width: 100%">
                            <thead>
                                <tr>
                                    <th style="width: 3%" class="center">
                                        <span class="report-column-title">#</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PatientId');" style="width: 7%">
                                        <span class="report-column-title">Insurance</span>
                                        <%-- <span class="filterIcon asc"></span>--%>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PatientName');" style="width: 12%">
                                        <span class="report-column-title">Rejected</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'Claimid');" style="width: 7%">
                                        <span class="report-column-title">Denied</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'DOS');" style="width: 8%">
                                        <span class="report-column-title">Paid Up</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'DOS');" style="width: 8%">
                                        <span class="report-column-title">Total</span><span></span>
                                    </th>


                                </tr>
                            </thead>
                            <tbody id="tbodyReportList">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="center">
                            <%# Container.ItemIndex+1 %>
                        </td>
                        <td class="AlignString">
                            <%# Eval("Payer")%>
                        </td>
                        <td class="center linkClass" onclick="RejDenSummary('<%# Eval("InsNameId")%>','Rejected')" style="cursor: pointer" id="lblrejcted">

                            <asp:Label ID="lblrejected" runat="server" Text=' <%# Eval("Rejected")%>'></asp:Label>
                        </td>
                        <td class="center linkClass" onclick="RejDenSummary('<%# Eval("InsNameId")%>','Denied')" style="cursor: pointer">
                            <%# Eval("Denied")%>
                        </td>
                        <td class="center linkClass" onclick="RejDenSummary('<%# Eval("InsNameId")%>','Paid Up')" style="cursor: pointer">
                            <%# Eval("PaidUp")%>  
                        </td>

                        <td class="center linkClass" onclick="RejDenSummary('<%# Eval("InsNameId")%>','')">
                            <%# Eval("[Total]")%>
                                           
                        </td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                                       <tfooter>
                                           <tr class="BtmToatlTr">

                                               <td style="border-top: 1px solid #C4C4C4;">
                                                   <asp:Label ID="Label1" runat="server" Style="font-weight: bold"></asp:Label></td>
                                               <td style="border-left: none; border-top: 1px solid #C4C4C4; font-weight: bold; float: right; width: 98%;">
                                                   <asp:Label ID="lblGrand" runat="server" Style="font-weight: bold">Grand Total</asp:Label></td>
                                               <td style="border-top: 1px solid #C4C4C4;" class="linkClass" onclick="RejDenSummary('','Rejected')">
                                                   <asp:Label ID="lblRejectedTotal" runat="server" Style="font-weight: bold"></asp:Label></td>
                                               <td style="border-top: 1px solid #C4C4C4;" class="linkClass" onclick="RejDenSummary('','Denied')">
                                                   <asp:Label ID="lblDeniedTotal" runat="server" Style="font-weight: bold"></asp:Label></td>
                                               <td style="border-top: 1px solid #C4C4C4;" class="linkClass" onclick="RejDenSummary('','Paid Up')">
                                                   <asp:Label ID="lblPPaidTotal" runat="server" Style="font-weight: bold"></asp:Label></td>
                                               <td style="border-top: 1px solid #C4C4C4;" class="linkClass" onclick="RejDenSummary('','')">
                                                   <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight: bold"></asp:Label></td>
                                           </tr>

                                       </tfooter>
                    </table> 
                            </div>
                </FooterTemplate>
            </asp:Repeater>


        </div>


        <div class="dialogue" style="display: none"></div>


        <input type="hidden" id="hdnTotalRows" runat="server" />
        <asp:HiddenField ID="hdnBilledAs" runat="server" />
        <asp:HiddenField ID="hdnPayer" runat="server" />
        <asp:HiddenField ID="hdnAging" runat="server" />

        <div id="CustomizeRejectedDeniedSummaryAndDetail" style="display: none; padding: 20px;">
            <div class="row">
                <div class="col-lg-4">
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
                <div class="col-lg-4">
                    <div id="divAging  padding-bottom: 45px;">

                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Aging:</span>
                            <div class="clsPostDate BranceInput" id="divAgingIn" style="padding-bottom: 10px;">
                                <asp:DropDownList ID="ddlAging" CssClass="ddlAgingType" runat="server" onchange="EnableDisableFilter(this)">
                                    <asp:ListItem Value="">All</asp:ListItem>
                                    <asp:ListItem Value="0-30">0-30</asp:ListItem>
                                    <asp:ListItem Value="31-60">31-60</asp:ListItem>
                                    <asp:ListItem Value="61-90">61-90</asp:ListItem>
                                    <asp:ListItem Value="90+">90+</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-4">
                    <div id="divReportPayerScenario">
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
                                            <div class="ddlselect analysisddlselect" style="top: 5px !important;">
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
                 <div class="col-lg-6 CustomPracticeLocation" style="padding-bottom: 10px;">
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
        </div>
        <script type="text/javascript">
            debugger;


            $('.message').css("display", "none")

        </script>

        ###endReport###
    
    </form>
</body>
</html>
