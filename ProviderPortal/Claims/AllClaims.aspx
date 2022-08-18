<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" EnableViewState="false"
    AutoEventWireup="true" CodeFile="AllClaims.aspx.cs" Inherits="HomeHealth_EpisodeClaims_ERAMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ERASearchLabel
        {
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            var dateOfBirthMin = new Date();
            dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);

            $("#txtPaymentDate").datepicker({
                changeMonth: true,
                changeYear: true,
                //yearRange: "1950:" + new Date,
                minDate: "01/01/1900",
                maxDate: new Date
            }).mask("99/99/9999");

            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingERA").val(), "ERAContainer", "FilterERA");
            if ($("[id$='hdnTotalRows']").val() > 0)
                $("#ERAContainer .spanInfo").html("Showing " + $("#eraList tr:first").children().first().html() + " to " + $("#eraList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        });




        function showERAClaimPayments(ERAMasterId, elem) {

            var ERAType = $.trim($(elem).closest('tr').children().eq(1).html());
            var InsuranceId = $(elem).closest('tr').children().eq(2).attr('id');
            if (ERAType == "ERA")
                window.location = "CheckDetails.aspx?ERAMasterId=" + ERAMasterId;
            if (ERAType == "EOB")
                window.location = "ApplyEOBPayments.aspx?ERAMasterId=" + ERAMasterId + "&InsuranceId=" + InsuranceId;

        }

        function NewERA() {
            window.location = "../EDI/Claim.aspx";
        }

        function NewEOB() {
            window.location = "NewEob.aspx";
        }

        function FilterERA(pageNumber, paging) {
            var paymentType = $("#ddlPaymentType").val();
            var insurance = $("#txtInsurance").val();
            var paymentMethod = $("#ddlPaymentMethod").val();
            var checkNumber = $("#txtCheckNumber").val();
            var paymentDate = $("#txtPaymentDate").val();
            var checkAmount = $("#txtCheckAmount").val();
            var paymentPosted = $("#txtPaymentPosted").val();
            var status = $("#ddlStatus").val();


            $.post("CallBacks/ERAFilterHandler.aspx", { paymentType: paymentType, paymentMethod: paymentMethod, checkAmount: checkAmount, paymentPosted: paymentPosted, status: status, checkNumber: checkNumber, insurance: insurance, paymentDate: paymentDate, Rows: $("#ddlPagingERA").val(), pageNumber: pageNumber, SortBy: "paymentDate" },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#eraList").html(returnHtml.substring(start, end));

                var startRowsCount = data.indexOf("###StartERARowsCount###") + 23;
                var endRowsCount = data.indexOf("###EndERARowsCount###");
                $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

                if (paging == true) {

                    GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingERA").val(), "ERAContainer", "FilterERA");
                }

                if ($("[id$='hdnTotalRows']").val() > 0)
                    $("#ERAContainer .spanInfo").html("Showing " + $("#eraList tr:first").children().first().html() + " to " + $("#eraList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
            });
        }

        function RedirectClaimSubmission() {
            window.location = "ClaimSubmission.aspx";
        }

        function RedirectCreateclaim() {
            window.location = "CreateClaim.aspx";
        }

             

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hdnTotalRows" />
    <div class="quicklaunch">
        <a onclick="NewERA()">Process File</a> <a onclick="NewEOB()">New EOB</a>
    </div>
    <div class="page-content">
        <div class="Widget">
            <div class="WidgetTitle">
                <span class="widget-claims-icon"></span>ERA/EOB List
            </div>
            <div class="WidgetMainContent">
                <div id="ERAContainer" style="float: left;">
                    <asp:Repeater ID="rptERA" runat="server" OnItemDataBound="rptERA_ItemDataBound">
                        <HeaderTemplate>
                            <div class="Grid">
                                <table>
                                    <thead>
                                        <tr>
                                            <th style="width: 2%;">
                                            </th>
                                            <th style="width: 10%;">
                                                Payment Type
                                            </th>
                                            <th style="width: 22%;">
                                                Insurance
                                            </th>
                                            <th style="width: 18%;">
                                                Payment Method
                                            </th>
                                            <th style="width: 10%;">
                                                Check Number
                                            </th>
                                            <th style="width: 10%;">
                                                Payment Date
                                            </th>
                                            <th style="width: 10%;">
                                                Check Amount
                                            </th>
                                            <th style="width: 10%;">
                                                Payment Posted
                                            </th>
                                            <th style="width: 10%;">
                                                Status
                                            </th>
                                            <th style="width: 5%">
                                                Post Payment
                                            </th>
                                        </tr>
                                        <tr class="alternatingRow">
                                            <td>
                                                <span class="iconSearchMessage"></span>
                                            </td>
                                            <td>
                                                <select onchange="FilterERA(0,true)" id="ddlPaymentType">
                                                    <option value="">All</option>
                                                    <option value="ERA">ERA</option>
                                                    <option value="EOB">EOB</option>
                                                </select>
                                            </td>
                                            <td>
                                                <input onkeyup="FilterERA(0,true)" type="text" id="txtInsurance" />
                                            </td>
                                            <td>
                                                <select onchange="FilterERA(0,true)" id="ddlPaymentMethod">
                                                    <option value="">All</option>
                                                    <option value="ACH">Automated Clearing House</option>
                                                    <option value="BOP">Financial Institution Option</option>
                                                    <option value="CHK">Check</option>
                                                    <option value="FWT">Federal Reserve Funds</option>
                                                    <option value="NON">Non-Payment Data</option>
                                                </select>
                                            </td>
                                            <td>
                                                <input type="text" onkeyup="FilterERA(0,true)" onkeypress="return ValidateNumber(event)"
                                                    id="txtCheckNumber" />
                                            </td>
                                            <td>
                                                <input type="text" onkeyup="FilterERA(0,true)" id="txtPaymentDate" />
                                            </td>
                                            <td>
                                                <input type="text" onkeyup="FilterERA(0,true)" onkeypress="return ValidateNumber(event)"
                                                    id="txtCheckAmount" />
                                            </td>
                                            <td>
                                                <input type="text" onkeyup="FilterERA(0,true)" onkeypress="return ValidateNumber(event)"
                                                    id="txtPaymentPosted" />
                                            </td>
                                            <td>
                                                <select onchange="FilterERA(0,true)" id="ddlStatus">
                                                    <option value="">All</option>
                                                    <option value="Pending">Pending</option>
                                                    <option value="Partially Posted">Partially Posted</option>
                                                    <option value="Fully Posted">Fully Posted</option>
                                                </select>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody id="eraList">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="<%# Eval("ERAMasterId") %>" class="DataRow">
                                <td>
                                    <i>
                                        <%# Eval("RowNumber") %></i>
                                </td>
                                <td id="<%# Eval("PaymentType") %>">
                                    <%# Eval("PaymentType") %>
                                </td>
                                <td id="<%# Eval("PayerIdentifier") %>">
                                    <%# Eval("PayerName") %>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaymentMethod" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <%# Eval("CheckNumber") %>
                                </td>
                                <td>
                                    <%# Eval("CheckIssueDate", "{0:d}") %>
                                </td>
                                <td>
                                    <%# Eval("PaymentAmount","{0:c}") %>
                                </td>
                                <td>
                                    <%# Eval("PaymentPosted", "{0:c}")%>
                                </td>
                                <td id="<%# Eval("Status") %>">
                                    <%# Eval("Status") %>
                                </td>
                                <td>
                                    <img src="../../Images/payment.png" style="cursor: pointer" onclick="showERAClaimPayments(<%# Eval("ERAMasterId") %>,this)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                            <div class="message">
                                <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo">
                            </div>
                            <div class="pager">
                                <div class="PageEntries">
                                    <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                        <select id="ddlPagingERA" style="margin-top: 5px;" onchange="RowsChange('FilterERA');">
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
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div id="divERAClaimPayments" class="Widget" style="margin-top: 20px; float: left;
                width: 100%">
            </div>
        </div>
    </div>
</asp:Content>
