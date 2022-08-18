<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Claims.aspx.cs" Inherits="BillingManager_Claims_Claims" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1 class="pagetitle">Claims</h1>



    
    <div class="Grid" id="divClaims">
        <table style="width: 100%;">
            <thead>
                <tr>
                    <th style="width: 2%;">#
                    </th>
                    <th style="width: 8%;">Claim No
                    </th>
                    <th>Account No</th>
                    <th>Patient Name</th>
                    <th>DOS</th>
                    <th>Bill Date</th>
                    <th>Primary Insurance</th>
                    <th>Status</th>
                    <th style="width: 20%;">PTL Reason</th>
                    <th>PTL</th>
                </tr>
                <tr>
                    <th>
                        <span class="iconSearch"></span>
                    </th>
                    <th>
                        <input type="text" id="txtClaimNo" onkeyup="RowsChange('FilterClaims');" />
                    </th>
                    <th>
                        <input type="text" id="txtPatientAccount" onkeyup="RowsChange('FilterClaims');" />
                    </th>
                    <th>
                        <input type="text" id="txtPatientName" onkeyup="RowsChange('FilterClaims');" />
                    </th>
                    <th>
                        <input type="text" id="txtDateOfService" class="ServiceDate" onkeyup="RowsChange('FilterClaims');" />
                    </th>
                    <th>
                        <input type="text" id="txtBillDate" class="BillDate" onkeyup="RowsChange('FilterClaims');" />
                    </th>
                    <th>
                        <asp:DropDownList ID="ddlInsurance" runat="server" CssClass="select" Style="float: none;" onchange="RowsChange('FilterClaims');"></asp:DropDownList>
                    </th>
                    <th>
                        <asp:DropDownList ID="ddlSubmissionStatus" runat="server" CssClass="select" Style="float: none;" onchange="RowsChange('FilterClaims');"></asp:DropDownList>
                    </th>
                    <th>
                        <div class="dropdownMenuMultiCheckMainWrapper">
                            <select></select>
                            <div class="div-dropdown-label-wrapper" onclick="HideShowPTLReasonDropDown(this);">
                                <span class="custom-drop-down-label"></span>
                            </div>
                            <div class="dropdownMenuMultiCheck" style="top: 25px; width: 100%;">
                                <div class="div-drop-down" style="height: 150px;">
                                    <ul id="ulPTLReasonFilterList" style="text-align: left; overflow-x: hidden;">
                                        <li>
                                            <label>
                                                <input type="checkbox" class="chkPTLReasonsAll" onclick="SelectUnselectPTLReasons_All(this);" />
                                                All
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptPTLReasons">
                                            <ItemTemplate>
                                                <li>
                                                    <label>
                                                        <input type="checkbox" id='chkPatientPTLReasonsId<%#Eval("PTLReasonsId") %>' class="chkReason" onclick="SelectUnselectPTLReasons(this);" />
                                                        <span class="spnReason"><%#Eval("Reason")%></span>

                                                        <input type="hidden" class="hdnPTLReasonsId" value='<%#Eval("PTLReasonsId") %>' />
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <div class="divBottom">
                                    <input type="button" onclick="OkMultiCheckDropDownPTLReason(this, 'Patient');" value="OK" />
                                </div>
                            </div>
                        </div>
                    </th>
                    <th>
                        <input type="checkbox" id="chkPTL" onclick="RowsChange('FilterClaims');" />
                    </th>
                </tr>
            </thead>
            <tbody id="ClaimsList">
                <asp:Repeater ID="rptClaims" runat="server" OnItemDataBound="rptClaims_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td onclick="loadCreateClaimForm(this);" style="cursor: pointer;">
                                <i><%# Eval("ROWNUMBER")%></i>
                            </td>
                            <td>
                                <span onclick="loadCreateClaimForm(this);"><%# Eval("ClaimId")%></span>
                                <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                                <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                                <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                                <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                            </td>
                            <td onclick="loadCreateClaimForm(this);" style="cursor: pointer;">
                                <%# Eval("PatientId")%>
                            </td>
                            <td onclick="loadCreateClaimForm(this);" style="cursor: pointer;">
                                <%# Eval("PatientName")%>
                            </td>
                            <td style="text-align: center; cursor: pointer;" onclick="loadCreateClaimForm(this);">
                                <%# Eval("ServiceDate", "{0:d}")%>
                            </td>
                            <td style="text-align: center;cursor: pointer;" onclick="loadCreateClaimForm(this);">
                                <%# Eval("BillDate")%>
                            </td>
                            <td onclick="loadCreateClaimForm(this);" style="cursor: pointer;">
                                <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                            </td>
                            <td style="white-space: nowrap; cursor: pointer;" onclick="loadCreateClaimForm(this);">
                                <%# Eval("SubmissionStatus")%>
                            </td>
                            <td>
                                <asp:Label ID="lblPTLReason" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center;">
                                <asp:CheckBox runat="server" ID="chkPTL" Enabled="false" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="message">
            <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
        </div>
        <div class="pager">
            <div class="PageEntries">
                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                    <select id="ddlPagingClaims" style="margin-top: 5px;" onchange="RowsChange('FilterClaims');">
                        <option value="10">10</option>
                        <option value="25">25</option>
                        <option value="50">50</option>
                        <option value="75">75</option>
                        <option value="100">100</option>
                    </select>
                </span><span style="float: left;">&nbsp;entries</span>
            </div>
            <div class="PageButtons">
                <ul style="float: right; margin-right: 15px;">
                </ul>
            </div>
        </div>
        <asp:HiddenField ID="hdnClaimsCount" runat="server" />
    </div>


    <script type="text/javascript">

        $(document).ready(function () {
            $("[id$='txtDateOfService'] , [id$='txtBillDate']").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-5 : +5",
                onSelect: function () {
                    RowsChange('FilterClaims');
                }
            }).mask("99/99/9999");

            GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");

            if ($("[id$='hdnClaimsCount']").val() > 0) {

                $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
            }
        });

        function FilterClaims(pageNumber, paging) {
            $("[id$='divRightsSettings']").hide();
            var ClaimId = $.trim($("[id$='txtClaimNo']").val());
            var PatientId = $.trim($("[id$='txtPatientAccount']").val());
            var PatientName = $.trim($("[id$='txtPatientName']").val());
            var DateOfService = $.trim($("[id$='txtDateOfService']").val());
            var BillDate = $.trim($("[id$='txtBillDate']").val());
            var InsuranceId = $.trim($("[id$='ddlInsurance']").val());
            var SubmissionStatusId = $.trim($("[id$='ddlSubmissionStatus']").val());
            var IsPTL = $("[id$='chkPTL']").is(":checked");
            var PTLReasons = GetPTLReasons("ulPTLReasonFilterList");

            $.post("CallBacks/ClaimFilterHandler.aspx", {
                ClaimId: ClaimId,
                PatientId: PatientId,
                PatientName: PatientName,
                DateOfService: DateOfService,
                BillDate: BillDate,
                InsuranceId: InsuranceId,
                SubmissionStatusId: SubmissionStatusId,
                IsPTL: IsPTL,
                PTLReasons: PTLReasons,
                Rows: $("#ddlPagingClaims").val(),
                PageNumber: pageNumber
            },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("###StartClaimFilterHandler###") + 29;
                var end = data.indexOf("###EndClaimFilterHandler###");
                $("#ClaimsList").html(returnHtml.substring(start, end));
                if (paging == true) {
                    GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");
                }
                if ($("[id$='hdnClaimsCount']").val() > 0) {
                    $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
                }
            });
        }

        function callFilterFunction() {
            callFrom = $("#spnTitle").html();
            if (callFrom == "Claims") {
                RowsChange('FilterClaims');
            } else {
                RowsChange('FilterClaims');
            }
        }


        function OkMultiCheckDropDownPTLReason(elem, PTLType) {
            FilterClaims(0, true);

            HideShowPTLReasonDropDown(elem);
        }

        function HideShowPTLReasonDropDown(elem) {
            var dropdownDivMainWrapper = $(elem).closest(".dropdownMenuMultiCheckMainWrapper");

            if (dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").is(":visible")) {
                dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").hide();
            }
            else {
                dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").show();
            }
        }

        function GetPTLReasons(ReasonUl) {
            var strPTLReasons = "";

            $("#" + ReasonUl + " .chkReason:checked").each(function () {
                strPTLReasons += $(this).parent().find(".hdnPTLReasonsId").val() + ",";
            });

            if (strPTLReasons.length > 1) {
                strPTLReasons = strPTLReasons.slice(0, -1);
            }

            return strPTLReasons;
        }
    </script>

</asp:Content>

