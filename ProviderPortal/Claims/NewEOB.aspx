<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="NewEOB.aspx.cs" Inherits="HomeHealth_EpisodeClaims_NewEOB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtEOBDate").datepicker({
                changeMonth: true,
                changeYear: true,
                //yearRange: "1950:" + new Date,
                minDate: "01/01/1900",
                maxDate: new Date
            }).mask("99/99/9999");
        });
        function ShowClaimCCharges(elem) {
            var InsuranceId = $(elem).val();
            $.post("CallBacks/ClaimChargesHandler.aspx", { InsuranceId: InsuranceId },
                 function (data) {
                     var returnHtml = data;
                     var start = data.indexOf("###StartEpisodeClaims###") + 24;
                     var end = data.indexOf("###EndEpisodeClaims###");
                     $("#divClaimCharges").html(returnHtml.substring(start, end));

                 });
        }

        var ERAMasterId;
        function SaveEOB() {
            if (ValidateForm("tblNewEOB") == false) {
                return false;
            }
            var EOB = new Object();
            EOB.CheckIssueDate = $("#txtEOBDate").val();
            EOB.CheckNumber = $("#txtEOBRefNo").val();
            EOB.PaymentMethodCode = $("#ddlEOBPaymentMethod").val();
            EOB.PaymentAmount = $("#txtEOBAmount").val();
            EOB.PayerIdentifier = $("[id$='ddlEOBInsurance']").val();
            EOB.PayerName = $("[id$='ddlEOBInsurance'] option:selected").text();
            $.post("CallBacks/AddNewEOBHandler.aspx", { NewEOB: JSON.stringify(EOB) },
                 function (data) {
                     var returnHtml = data;
                     var start = data.indexOf("###StartResult###") + 17;
                     var end = data.indexOf("###EndResult###");
                     if (parseInt(returnHtml.substring(start, end)) > 0) {
                         ShowDialog();
                         ERAMasterId = parseInt(returnHtml.substring(start, end));
                     }

                 });
        }
        function ShowDialog() {
            $("#divReport").dialog({
                resizable: false,
                height: 140,
                modal: true,
                title: 'Success',
                buttons: {
                    "New EOB": function () {
                        ResetForm();
                        $(this).dialog("close");
                    },
                    "Apply Payments": function () {
                        ApplyPayments();
                        $(this).dialog("close");
                    }
                }
            });
        }
        
        function ResetForm() {
            $("#txtEOBDate").val("");
            $("#txtEOBRefNo").val("");
            $("#txtEOBAmount").val("");
            $("#ddlEOBPaymentMethod").val($("#ddlEOBPaymentMethod option:first").val());
        }

        function ApplyPayments() {
            var insuranceId = $("[id$='ddlEOBInsurance']").val();
            window.location = "ApplyEOBPayments.aspx?InsuranceId=" + insuranceId + "&ERAMasterId=" + ERAMasterId;
        }
        
        function ViewAllClaims() {
            window.location = "AllClaims.aspx";
        }
        
    </script>
    <style type="text/css">
      
      #tblNewEOB input {
          width: 25%;
      }
      
       #tblNewEOB select {
          width: 29.5%;
      }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="quicklaunch"></div>
    <div class="page-content">
        <div>
            <span style="margin-left: 5px; font-size: 14px; font-weight: bold;">Add New EOB</span>
            <div style="float: right">
                <input type="button" onclick="ViewAllClaims()" value="Cancel" />
                <input type="button" onclick="SaveEOB()" value="Save" />
            </div>
        </div>
        <div>
            <div class="Widget" style="float: left; width: 100%;">
                <table id="tblNewEOB" class="tblPatientDemographics" width="100%">
                    <tr style="width: 100%">
                        <td class="tdLabel">
                            Date<span class="spnError">*</span>
                        </td>
                        <td>
                            <input id="txtEOBDate" class="required" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel">
                            Check Number<span class="spnError">*</span>
                        </td>
                        <td>
                            <input id="txtEOBRefNo" class="required" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel">
                            Method
                        </td>
                        <td>
                            <select id="ddlEOBPaymentMethod">
                                <option value="ACH">Automated Clearing House</option>
                                <option value="BOP">Financial Institution Information</option>
                                <option value="CHK">Check</option>
                                <option value="FWT">Federal Reserve Funds</option>
                                <option value="NON">None</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel">
                            Amount<span class="spnError">*</span>
                        </td>
                        <td>
                            <input id="txtEOBAmount" class="required" onkeypress="return ValidateNumber(event)"
                                type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel">
                            Insurance
                        </td>
                        <td>
                            <asp:DropDownList onchange="ShowClaimCharges(this)" ID="ddlEOBInsurance" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divReport" style="float: left; display: none">
        EOB Created Successfully
    </div>
</asp:Content>

