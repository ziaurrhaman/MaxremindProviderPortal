<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true"
    CodeFile="ApplyEOBPayments.aspx.cs" Inherits="HomeHealth_EpisodeClaims_ApplyEOBPayments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .lbl
        {
            color: #747473;
            font-weight: bold;
            font-size: 10pt;
        }
        .information
        {
            color: #747473;
            font-size: 10pt;
            font-weight: bold;
            text-decoration: underline;
        }
        #tblERAMasterInfo tr
        {
            line-height: 2;
        }
        
        .claimHeader
        {
            height: 40px;
            border: 1px solid white;
            padding: 0 5px;
            width: 99%;
            box-shadow: 0px 0px 0px 1px lightgray;
            margin-top: 8px;
            -moz-box-shadow: 0px 0px 0px 1px lightgray;
            border-radius: 5px;
            -moz-border-radius: 5px;
            margin: 8px 0 14px;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            background-color: #F0F0F0;
            float: left;
            line-height: 40px;
            position: relative;
            z-index: 101;
            margin-bottom: 5px;
        }
        
        .NoClaim
        {
            border: 1px solid #FFF;
            padding: 0;
            width: 20%;
            box-shadow: 0px 0px 0px 1px lightgray;
            -moz-box-shadow: 0px 0px 0px 1px lightgray;
            border-radius: 5px;
            -moz-border-radius: 5px;
            margin: 15px 0 14px 40%;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            background-color: #DFEDF7;
            float: left;
            line-height: 40px;
            text-align: center;
            display: none;
        }
    </style>
    <script type="text/javascript">
        var procedureAdjustmentList = new Array();
        var adjustmetnIdIncrement = 2;
        var activeRowId;

        $(document).ready(function () {
            var success = GetQueryString("S");
            if (success == "T") {
                showSuccessMessage("Payment Posted Successfully");
            }
            $(document).click(function () {
            });
        });
        function AddNewAdjustment(elem) {
            $(elem).parent().append("<div style='width:100%'><input onkeyup='CalculateRemaining()' style='width:100px' type='text'></input><span onclick='RemoveAdjustment(this)' style='margin:8px 0 0 5px' class='spanRemove'></span></div>");
        }

        function RemoveAdjustment(elem) {
            $(elem).closest('div').remove();
        }

        function CalculateRemaining() {

            var totalAmount = parseFloat($("[id$='lblCheckAmount']").html().substring(1).replace(',', ''));
            var totalPaid = 0;
            $(".DataRow").each(function () {

                var paymentAmount = $(this).children().eq(7).find('input').val();
                if (paymentAmount != "") {
                    totalPaid += parseFloat(paymentAmount);
                }
                var adjustment = $(this).children().eq(8).find('input').val();

                if (adjustment != "") {
                    totalPaid += parseFloat(adjustment);
                }


            });
            $("[id$='lblRemainingBalance']").html('$' + (totalAmount - totalPaid));
            $("[id$='lblPostedAmount']").html('$' + totalPaid);
        }

        function ApplyPayment() {
            var resultString = "";
            var increment = 0;
            var checkNumber = $("[id$='hdnCheckNumber']").val();
            var payerId = $("[id$='hdnPayerId']").val();
            var paymentMethod = $("[id$='hdnPaymentMethod']").val();
            var checkDate = $("[id$='hdnCheckIssueDate']").val();
            var procedurePaymentsList = new Array();

            $(".DataRow").each(function () {

                if ($(this).children().eq(0).find('input:checked').prop('checked') == true) {
                    var row = $(this).siblings()[0];
                    var procedurePayments = new Object();
                    procedurePayments.ClaimNumber = $.trim($(row).closest('table').prev('div').find('table').children().eq(0).children().children().eq(4).html());
                    procedurePayments.ClaimChargesId = $(this).attr('id');
                    procedurePayments.CheckNumber = checkNumber;
                    procedurePayments.CheckDate = checkDate;
                    procedurePayments.PaymentMethod = paymentMethod;
                    procedurePayments.PaidUnits = $(this).children().eq(4).find('input').val();
                    procedurePayments.AllowedAmount = $(this).children().eq(6).find('input').val();
                    procedurePayments.PaidAmount = $(this).children().eq(7).find('input').val();
                    procedurePayments.AdjustedAmount = $(this).children().eq(8).find('input').val();
                    if (procedurePayments.AdjustedAmount == "")
                        procedurePayments.AdjustedAmount = 0;
                    if (procedurePayments.PaidAmount == "")
                        procedurePayments.PaidAmount = 0;
                    if (procedurePayments.PaidUnits == "")
                        procedurePayments.PaidUnits = 0;
                    procedurePayments.PayerId = payerId;
                    procedurePaymentsList.push(procedurePayments);
                    increment++;
                }
            });
            if (increment == 0) {
                showErrorMessage("Please Select a Claim");
                return;
            }

            $.post("CallBacks/EOBApplyPaymentsHandler.aspx", { procedurePaymentsList: JSON.stringify(procedurePaymentsList), ProcedureAdjustmentList: JSON.stringify(procedureAdjustmentList) },
                function (data) {
                    window.location = _EMRPath + "/Claims/ApplyEOBPayments.aspx" + decodeURI(location.search) + "&S=T";
                });
        }
        function backToallclaims() {
            window.location = "AllClaims.aspx";
        }

        function SelectAll(elem) {
            if ($(elem).is(":checked")) {
                $(elem).closest('div').next('table').children().eq(0).find(".DataRow").children().find('input[type="checkbox"]').each(function () {
                    $(this).prop('checked', 'checked');
                });
            }
            else {
                $(elem).closest('div').next('table').children().eq(0).find(".DataRow").children().find('input[type="checkbox"]').each(function () {
                    $(this).prop('checked', false);
                });

            }
        }
        function checkMasterCb() {
            $(".tblPayments").each(function () {
                if ($(this).find(".cbpatientpayment:checked").length == $(this).find(".cbpatientpayment").length) {
                    $(this).prev("div").find(".cbMaster").prop("checked", true)
                }
                else {
                    $(this).prev("div").find(".cbMaster").prop("checked", false)
                }
            });

        }
        var adjustmentText = null;
        function ShowProcedureAdjustmentsDialog(ClaimChargesId, elem) {
            ResetSearchBox();
            ShowPreviousAdjustments(ClaimChargesId);
            adjustmentText = $(elem).prev(":text");
            $("#tbodyResult").html("");
            $("#divProcedureAdjustments").dialog({
                resizable: false,
                title: 'Add Adjustments',
                width: '600',
                modal: true,
                buttons: {
                    "OK": function () {
                        AdjustmentsToList(ClaimChargesId);

                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });
        }

        function AddNewAdjustment() {

            var row = $("#trAdjustment").clone();
            $(row).find(":text").val("");
            $(row).find("select").prop("selectedIndex", 0);
            $("#tblProcedureAdjustments").append(row);
            $("#tblProcedureAdjustments tr:last").attr('id', adjustmetnIdIncrement);
            adjustmetnIdIncrement++;
            $("#tblProcedureAdjustments tr:even").addClass("alternatingRow");

        }

        function SearchReasonCode(elem) {
            var code = $(elem).closest("tr").find("#txtReasonCode").val();
            var description = $(elem).closest("tr").find("#txtDescription").val();
            $.post("../Controls/SearchAdjustmentReasonCode.aspx", { Code: code, Description: description }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###StartReasonCode###") + 21;
                var end = data.indexOf("###EndReasonCode###");
                if ($(elem).hasClass("top"))
                    $(elem).closest("tr").find("#tbodyResult").html(returnHtml.substring(start, end));
                else
                    $(elem).closest("tr").parent().next("#tbodyResult").html(returnHtml.substring(start, end));
            });
        }

        function AssignValues(elem) {
            var code = $(elem).closest('tr').children().eq(0).find('input').val();
            var description = $(elem).closest('tr').children().eq(1).find('input').val();
            activeRowId = $(elem).closest('tr');
            $(elem).closest('tr').find("#txtReasonCode").val(code);
            $(elem).closest('tr').find("#txtDescription").val(description);
            $(elem).closest('tr').find("#divReasonCodeResults").show();
            SearchReasonCode(elem);
        }

        function ResetSearchBox() {
            $("#txtFirstReasonCode").val("");
            $("#txtFirstReasonCode").removeClass("error");
            $("#txtFirstAdjustedUnits").val("");
            $("#txtFirstAdjustedUnits").removeClass("error");

            $("#tblProcedureAdjustments .New").each(function () {
                $(this).remove();
            });
            $("#txtReasonCode").val("");
            $("#txtDescription").val("");
            $("#divReasonCodeResults").hide();

        }

        function RemoveAdjustment(elem) {
            $(elem).closest('tr').remove();
            $("#tblProcedureAdjustments tr").removeClass("alternatingRow");
            $("#tblProcedureAdjustments tr:even").addClass("alternatingRow");

        }

        function SelectAdjustment(elem) {
            var code = $.trim($(elem).children().eq(0).html());
            var description = $.trim($(elem).children().eq(1).html());
            $(activeRowId).children().eq(0).find('input').val(code);
            $(activeRowId).children().eq(1).find('input').val(description);
            $(activeRowId).find("#divReasonCodeResults").hide();
            $(activeRowId).find("#txtReasonCode,3txtDescription").val("");
            $(activeRowId).find("#tbodyResult").html("");
        }
        function AdjustmentsToList(ClaimChargesId) {

            if (ValidateForm("tblProcedureAdjustments") == false) {
                return false;
            }
            DeletePreviousAdjustments(ClaimChargesId);
            var adjustedUnitsSum = 0;
            $("#tblProcedureAdjustments .AdjustmentDataRow").each(function () {

                var procedureAdjustment = new Object();
                procedureAdjustment.ReasonCode = $(this).children().eq(0).find('input').val();
                procedureAdjustment.Description = $(this).children().eq(1).find('input').val();
                procedureAdjustment.GroupCode = $(this).children().eq(2).find('select').val();
                procedureAdjustment.AdjustedUnits = $(this).children().eq(3).find('input').val();
                adjustedUnitsSum += parseFloat(procedureAdjustment.AdjustedUnits);
                procedureAdjustment.ProcedurePaymentsId = ClaimChargesId;
                procedureAdjustmentList.push(procedureAdjustment);
            });
            $(adjustmentText).val(adjustedUnitsSum);
            $("#divProcedureAdjustments").dialog("close");
        }

        function ShowPreviousAdjustments(ClaimChargesId) {

            for (var i = 0; i < procedureAdjustmentList.length; i++) {
                if (ClaimChargesId == procedureAdjustmentList[i].ProcedurePaymentsId) {
                    var Code = procedureAdjustmentList[i].ReasonCode;
                    var GroupCode = procedureAdjustmentList[i].GroupCode;
                    var AdjustedUnits = procedureAdjustmentList[i].AdjustedUnits;
                    var Description = procedureAdjustmentList[i].Description;
                    var row = $("#trAdjustment").clone();
                    $(row).children().eq(0).find('input').val(Code);
                    $(row).children().eq(1).find('input').val(Description);
                    $(row).children().eq(2).find('select').val(GroupCode);
                    $(row).children().eq(3).find('input').val(AdjustedUnits);
                    $("#tblProcedureAdjustments").append(row);
                    $("#tblProcedureAdjustments tr:last").attr('id', adjustmetnIdIncrement);
                    adjustmetnIdIncrement++;

                }
            }
        }

        function DeletePreviousAdjustments(ClaimChargesId) {
            var previous;
            var newList = $.merge([], procedureAdjustmentList);

            for (var i = newList.length - 1; i >= 0; i--) {

                if (newList[i].ProcedurePaymentsId == ClaimChargesId) {

                    procedureAdjustmentList.splice(i, 1);

                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="Widget">
            <div class="WidgetTitle">
                <span class="widget-claims-icon"></span>Check Details</div>
            <div class="WidgetMainContent">
                <table cellpadding="0" cellpadding="0" style="line-height: 2; width: 70%">
                    <tr>
                        <td class="lbl">
                            Insurance:
                        </td>
                        <td class="information">
                            <asp:Label ID="lblInsuranceName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="lbl">
                            Check Amount:
                        </td>
                        <td class="information">
                            <asp:Label ID="lblCheckAmount" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Check Number:
                        </td>
                        <td class="information">
                            <asp:Label ID="lblCheckNumber" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="lbl">
                            Posted Amount:
                        </td>
                        <td class="information">
                            <asp:Label ID="lblPostedAmount" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Payment Type:
                        </td>
                        <td class="information">
                            <asp:Label ID="lblPaymentType" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="lbl">
                            Remaining Balance
                        </td>
                        <td class="information">
                            <asp:Label ID="lblRemainingBalance" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <input type="button" value="Back to Claims" runat="server" onclick="backToallclaims()"
                    style="float: right" />
                <input type="button" id="btnApplyPayments" value="Apply Payments" runat="server"
                    onclick="ApplyPayment()" style="float: right" />
                <div>
                    <asp:Repeater ID="rptEpisodeClaims" runat="server">
                        <HeaderTemplate>
                            <div style="float: left">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="claimHeader" style="margin-top: 20px;">
                                <table cellspacing="0" cellpadding="0" style="width: 60%">
                                    <tr>
                                        <td>
                                            <input type="checkbox" onchange="SelectAll(this)" class="cbMaster" />
                                        </td>
                                        <td class="lbl">
                                            Patient:
                                        </td>
                                        <td class="information">
                                            <%# Eval("PatientName") %>
                                        </td>
                                        <td class="lbl" style="width: 70px;">
                                            Claim No:
                                        </td>
                                        <td class="information" style="width: 75px;">
                                            <%# Eval("ClaimId") %>
                                        </td>
                                        <td class="lbl">
                                            Charges:
                                        </td>
                                        <td class="information">
                                            <%# Eval("TotalCharges","{0:c}") %>
                                        </td>
                                        <td class="lbl">
                                            Payments:
                                        </td>
                                        <td class="information">
                                            <span>
                                                <%# Eval("TotalPayments","{0:c}") %>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <table class="Grid tblPayments">
                                <tr>
                                    <th>
                                    </th>
                                    <th>
                                        Service Date
                                    </th>
                                    <th>
                                        CPT Code
                                    </th>
                                    <th>
                                        Service Units
                                    </th>
                                    <th>
                                        Paid Units
                                    </th>
                                    <th>
                                        Charges
                                    </th>
                                    <th>
                                        Allowed Amount
                                    </th>
                                    <th>
                                        Payments
                                    </th>
                                    <th>
                                        Adjustments
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptClaimCharges" DataSource='<%# Eval("EpisodeClaimsRelations") %>'
                                    runat="server">
                                    <ItemTemplate>
                                        <tr class="DataRow" id='<%# Eval("ClaimChargesId") %>'>
                                            <td>
                                                <input type="checkbox" class="cbpatientpayment" onchange="checkMasterCb()" />
                                            </td>
                                            <td>
                                                <%# Eval("ServiceDate","{0:d}") %>
                                            </td>
                                            <td>
                                                <%# Eval("CPTCode") %>
                                            </td>
                                            <td>
                                                <%# Eval("ServiceUnits") %>
                                            </td>
                                            <td>
                                                <input type="text" onkeypress="return ValidateNumber(event)" />
                                            </td>
                                            <td>
                                                <%# Eval("TotalCharges","{0:c}") %>
                                            </td>
                                            <td>
                                                <input type="text" onkeypress="return ValidateDecimalLimitedDigitBeforeDecimalPoint(event, this,8,2);"
                                                    value='<%# string.Format("{0:0.00}", Eval("TotalCharges")) %>' />
                                            </td>
                                            <td>
                                                <input type="text" onkeyup="CalculateRemaining()" onkeypress="return ValidateDecimalLimitedDigitBeforeDecimalPoint(event, this,8,2);" />
                                            </td>
                                            <td>
                                                <input type="text" onkeyup="CalculateRemaining()" onkeypress="return ValidateDecimalLimitedDigitBeforeDecimalPoint(event, this,8,2);"
                                                    style="width: 70%" />
                                                <span class="spanAdd" onclick="ShowProcedureAdjustmentsDialog('<%# Eval("ClaimChargesId") %>', this)"
                                                    style="margin: 8px 0 0 5px; float: right"></span>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div id="divProcedureAdjustments" style="float: left; display: none; position: relative;
                    overflow-y: auto; overflow-x: hidden;">
                    <input type="button" onclick="AddNewAdjustment()" value="Add New" />
                    <div style="height: 300px; width: 575px;">
                        <table id="tblProcedureAdjustments" style="margin-bottom: 20px; width: 98%;" class="Grid Widget">
                            <tr>
                                <th style="width: 17%">
                                    Reason Code
                                </th>
                                <th style="width: 28%">
                                    Description
                                </th>
                                <th style="width: 26%">
                                    Group
                                </th>
                                <th style="width: 18%">
                                    Adjusted Units
                                </th>
                                <th style="width: 9%">
                                    Action
                                </th>
                            </tr>
                            <%--<tr class="AdjustmentDataRow" id="1">
                    <td>
                        <input id="txtFirstReasonCode" onkeyup="AssignValues(this)" class="required" 

    type="text" />
                    </td>
                    <td>
                        <input onkeyup="AssignValues(this)" type="text" />
                    </td>
                    <td>
                        <select>
                            <option value="CO">Contractual Obligations</option>
                            <option value="OA">Other adjustments</option>
                            <option value="PI">Payor Initiated Reductions</option>
                            <option value="PR">Patient Responsibility</option>
                        </select>
                    </td>
                    <td>
                        <input type="text" id="txtFirstAdjustedUnits" class="required" onkeypress="return 

    ValidateNumber(event)" />
                    </td>
                    <td>
                        <span onclick="RemoveAdjustment(this)" class="spanRemove"></span>
                    </td>
                </tr>--%>
                        </table>
                    </div>
                    <table style="display: none">
                        <tr class="New AdjustmentDataRow" id="trAdjustment" style="position: relative;">
                            <td>
                                <input onkeyup="AssignValues(this)" class="required top" type="text" />
                            </td>
                            <td>
                                <input onkeyup="AssignValues(this)" type="text" class="top" />
                                <div id="divReasonCodeResults" style="position: absolute; height: 200px; display: none;
                                    overflow-y: auto; left: 13px;">
                                    <table class="Grid">
                                        <thead>
                                            <tr>
                                                <th>
                                                    Code
                                                </th>
                                                <th>
                                                    Description
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input id="txtReasonCode" onkeyup="SearchReasonCode(this)" type="text" />
                                                </td>
                                                <td>
                                                    <input id="txtDescription" onkeyup="SearchReasonCode(this)" type="text" />
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody id="tbodyResult">
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <select>
                                    <option value="CO">Contractual Obligations</option>
                                    <option value="OA">Other adjustments</option>
                                    <option value="PI">Payor Initiated Reductions</option>
                                    <option value="PR">Patient Responsibility</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" class="required" onkeypress="return ValidateNumber(event)" />
                            </td>
                            <td>
                                <span onclick="RemoveAdjustment(this)" class="spanRemove"></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="hdnCheckIssueDate" runat="server" />
                <asp:HiddenField ID="hdnPaymentMethod" runat="server" />
                <asp:HiddenField ID="hdnCheckNumber" runat="server" />
                <asp:HiddenField ID="hdnPayerId" runat="server" />
                <div id="divNoClaim" runat="server" class="NoClaim">
                    <span style="margin-left: 5px; font-size: 14px; font-weight: bold;">No Pending Claim
                        Found</span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
