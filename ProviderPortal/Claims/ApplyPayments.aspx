<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="ApplyPayments.aspx.cs" Inherits="HomeHealth_EpisodeClaims_ApplyPayments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
      .NoClaim {
       
        border: 1px solid #FFF;
        padding: 0;
        width: 20%;
        box-shadow: 0px 0px 0px 1px lightgray;
        -moz-box-shadow: 0px 0px 0px 1px lightgray;
        border-radius: 5px;
        -moz-border-radius: 5px;
        margin: 8px 0 14px 40%;
        border-radius: 5px;
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        background-color: #ADFF2F;
        float: left;
        line-height: 40px;
        text-align: center;
        display: none; 
      }  
    </style>   
    <script type="text/javascript">
        var totalPayments;
        $(document).ready(function() {
            totalPayments = parseFloat($("[id$='lblTotalAmount']").html());
            
        });
        function  CalculateRemaining() {
            var totalPaid = 0;
            $(".DataRow").each(function () {
                var paidAmount = 0;
                var adjustments = 0;

                if ($(this).children().eq(5).find('input').val() != "") {
                   
                    totalPaid += parseFloat($(this).children().eq(5).find('input').val());
                    paidAmount = parseFloat($(this).children().eq(5).find('input').val());
                }

                if ($(this).children().eq(6).find('input').val() != "") {
                    totalPaid += parseFloat($(this).children().eq(6).find('input').val());
                    adjustments = parseFloat($(this).children().eq(6).find('input').val());
                }

                $(this).children().eq(7).html("$"+(parseFloat($.trim($(this).children().eq(3).html()).substring(1)) - (paidAmount + adjustments)));


            });
            $("[id$='lblTotalAmount']").html(totalPayments - totalPaid);
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
                if ($(this).children().eq(9).find('input:checked').prop('checked') == true) {
                    var row = $(this).siblings()[0];
                    var procedurePayments = new Object();
                    procedurePayments.ClaimNumber = $(row).children().eq(0).find('span').html();
                    procedurePayments.ClaimChargesId = $(this).attr('id');
                    procedurePayments.CheckNumber = checkNumber;
                    procedurePayments.CheckDate = checkDate;
                    procedurePayments.PaymentMethod = paymentMethod;
                    procedurePayments.AllowedAmount = $(this).children().eq(4).find('input').val();
                    procedurePayments.PaidAmount = $(this).children().eq(5).find('input').val();
                    if (procedurePayments.PaidAmount == "")
                        procedurePayments.PaidAmount = 0;
                    procedurePayments.AdjustedAmount = $(this).children().eq(6).find('input').val();
                    if (procedurePayments.AdjustedAmount == "")
                        procedurePayments.AdjustedAmount = 0;
                    procedurePayments.PaidUnits = $.trim($(this).children().eq(2).html());
                    if (procedurePayments.PaidUnits == "")
                        procedurePayments.PaidUnits = 0;
                    procedurePayments.PayerId = payerId;
                    procedurePaymentsList.push(procedurePayments);
                    increment++;
                }
            });
            if (increment == 0) {
                alert("Please Select a Claim");
                return;
            }
            $.post("CallBacks/EOBApplyPaymentsHandler.aspx", { procedurePaymentsList: JSON.stringify(procedurePaymentsList) },
                 function (data) {
                     var returnHtml = data;
                     var start = data.indexOf("###StartResult###") + 19;
                     var end = data.indexOf("###EndResult###");
                     alert(returnHtml.substring(start, end));
                     resultString = returnHtml.substring(start, end);
                     if ($.trim(resultString) == "Payment Posted Successfully") {
                         window.location = "AllClaims.aspx";
                     }

                 });
             }

             function filterClaims() {
                
                 $(".Grid").show();
                 var claimNumber = $("#txtClaimNumber").val();
                 var name = $("#txtPatientName").val().toUpperCase();
                 $(".Widget .Grid").each(function () {
                     if (claimNumber != "" && name != "") {
                         if ($.trim($(this).children().eq(0).children().eq(0).children().eq(1).find('span').html().toUpperCase()).indexOf(name) > -1 && parseInt($.trim($(this).children().eq(0).children().eq(0).children().eq(0).find('span').html())) == claimNumber)
                             $(this).show();
                         else
                             $(this).hide();
                     }
                     
                     if (name != "" && claimNumber == "") {
                         if ($.trim($(this).children().eq(0).children().eq(0).children().eq(1).find('span').html().toUpperCase()).indexOf(name) > -1 )
                             $(this).show();
                         else
                             $(this).hide();

                     }

                     if (name == "" && claimNumber != "") {
                         if (parseInt($.trim($(this).children().eq(0).children().eq(0).children().eq(0).find('span').html())) == claimNumber)
                             $(this).show();
                         else
                             $(this).hide();

                     }


                 });
             }

             function ViewAllClaims() {
                 window.location = "AllClaims.aspx";

             }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="quicklaunch">
        <span style="margin-left: 5px; font-size: 14px; font-weight: bold;">Apply EOB Payments</span>
        <div style="float: right">
            <input type="button" onclick="ViewAllClaims()" value="Cancel"/>
          <div id="divbtnPayments" runat="server" style="float: right;">
            <input type="button" onclick="ApplyPayment()" value="Apply Payments" />
        </div>
           
        </div>
        </div>
    <table id="tblTotalAmount" runat="server" style="width: 25%">
        <tr>
            <td>
                Total Amount
            </td>
            <td>
                <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label>$
            </td>
        </tr>
    </table>
    <table id="tblSearch" runat="server" style="width: 100%; margin: 5px 0;">
        <tr style="height: 42px;">
            <td class="PatientSearchLabel">
                Patient Name
            </td>
            <td>
                <input id="txtPatientName" type="text" />
            </td>
            <td class="PatientSearchLabel">
                Claim Number
            </td>
            <td>
                <input id="txtClaimNumber" type="text" />
            </td>
            <td>
                <input id="txtSearch" type="button" value="Search" onclick="filterClaims();" />
            </td>
        </tr>
    </table>
    <div class="Widget">
        <asp:Repeater ID="rptClaims" runat="server" 
            onitemdatabound="rptClaims_ItemDataBound">
            <ItemTemplate>
            
                <table id="<%# Eval("ClaimId") %>" class="Grid" style="margin: 10px 10px 5px 10px; width: 98%" >
                    <tr>
                        <th>
                            Claim Number : <span id="claimNumber">
                                <%# Eval("ClaimId") %></span>
                        </th>
                        <th id="thPatientName">
                            Patient Name : <span id="spnPatientName">
                                <%# Eval("PatientName")%>
                            </span>
                        </th>
                        <th>
                            Date :
                            <%# Eval("BillDate", "{0:d}")%>
                        </th>
                        <th>
                            MR# :
                            <%# Eval("PatientId") %>
                        </th>
                       
                    </tr>
                   </table>
                    <asp:Repeater ID="rptClaimCharges" runat="server">
                        <HeaderTemplate>
                        <table class="Grid" style="margin: 10px; width: 98%">
                            <tr>
                                <th>
                                    Date
                                </th>
                                <th>
                                    CPTCode
                                </th>
                                <th>
                                    Unit
                                </th>
                                <th>
                                    Charges
                                </th>
                                <th>
                                    Allowed Amount
                                </th>
                                <th>
                                    Paid Amount
                                </th>
                                <th>
                                    Adjustments
                                </th>
                                <th>
                                    Balance
                                </th>
                                <th>
                                    Status
                                </th>
                                <th>
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="DataRow" id="<%# Eval("ClaimChargesId") %>">
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
                                    <%# Eval("TotalCharges","{0:c}") %>
                                </td>
                                <td>
                                    <input type="text" onkeypress="return ValidateNumber(event)" value="<%# Eval("TotalCharges") %>" />
                                </td>
                                <td>
                                    <input type="text" onkeyup="CalculateRemaining()" onkeypress="return ValidateNumber(event)" />
                                </td>
                                <td>
                                    <input type="text" onkeyup="CalculateRemaining()" onkeypress="return ValidateNumber(event)" />
                                </td>
                                <td>
                                     <%# Eval("TotalCharges","{0:c}") %>
                                </td>
                                <td>
                                    Pending
                                </td>
                                <td>
                                    <input id="chkSelect" type="checkbox" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
            </ItemTemplate>
            <FooterTemplate>
                </FooterTemplate>
        </asp:Repeater>
        
        <asp:HiddenField ID="hdnCheckIssueDate" runat="server" />
        <asp:HiddenField ID="hdnPaymentMethod" runat="server" />
        <asp:HiddenField ID="hdnCheckNumber" runat="server" />
        <asp:HiddenField ID="hdnPayerId" runat="server" />
    </div>
    <div id="divNoClaim" runat="server" class="NoClaim">
        <span style="margin-left: 5px; font-size: 14px; font-weight: bold;">No Pending Claim Found</span>
    </div>
</asp:Content>

