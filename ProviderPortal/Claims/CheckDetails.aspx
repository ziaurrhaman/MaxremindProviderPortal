
<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" 

CodeFile="CheckDetails.aspx.cs" Inherits="HomeHealth_EpisodeClaims_CheckDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .lbl {
            color: #747473;
            font-weight: bold;
            font-size: 10pt;
        }
        .information {
            color: #747473;
            font-size: 10pt;
            font-weight: bold;
            text-decoration: underline;
        }
        #tblERAMasterInfo tr
        {
            line-height:2;
        }
         
    </style>

    <script type="text/javascript">
        function viewClaims() {
            var queryString = "";
            var increment = 1;
            $(".ClaimRow").each(function () {

                if ($(this).children().eq(0).find("input").is(":checked")) {
                    var id = $(this).attr("id");
                    if (increment == 1)
                        queryString = queryString + "Claim" + increment + "=" + id;
                    else
                        queryString = queryString + "&Claim" + increment + "=" + id;
                    increment++;
                }
            });

            if (increment == 1) {
                showErrorMessage("Please Select a Claim");
                return false;
            }
            window.location = "ViewClaimsDetails.aspx?ERAMasterId=" + $("[id$='hdnERAMasterId']").val() +
"&" + queryString;
        }
        function SelectAll(elem) {
            if ($(elem).is(":checked")) {
                $(".ClaimRow").each(function () {
                    $(this).children().eq(0).find('input[type="checkbox"]').prop('checked', true);
                });
            }
            if ($(elem).is(":checked") == false) {
                $(".ClaimRow").each(function () {
                    $(this).children().eq(0).find('input[type="checkbox"]').prop('checked', false);
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="quicklaunch">
        <div style="float: right">
            <input type="button" onclick="RedirectClaimSubmission()" value="Claim Submission" />
            <input type="button" onclick="RedirectCreateclaim()" value="Create Claim" />
        </div>
    </div>--%>
    <h2 style="color:#747473">Check Details</h2>
    <table cellpadding="0" cellpadding="0" style="line-height:2; width:70%">
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
    
    <input type="button" value="View Claims" onclick="viewClaims()" style="float:right" />
    <asp:Repeater ID="rptDetails" runat="server" OnItemDataBound="rptDetails_ItemDataBound">
        <HeaderTemplate>
            <table class="Grid" style="margin-top: 15PX;">
                <tr>
                    <th>
                        <input type="checkbox" onchange="SelectAll(this)" style="float: left; margin-left: 

8px" />
                    </th>
                    <th>
                        Date
                    </th>
                    <th>
                        Claim No
                    </th>
                    <th>
                        Patient
                    </th>
                    <th>
                        Policy No
                    </th>
                    <th>
                        Charges
                    </th>
                    <th>
                        Payments
                    </th>
                    <th>
                        Adjustments
                    </th>
                    <th>
                        Status
                    </th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr class="ClaimRow" id="<%# Eval("ERAClaimPaymentsId") %>">
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    <%# Eval("DATE","{0:d}") %>
                </td>
                <td>
                    <%# Eval("ClaimNumber") %>
                </td>
                <td>
                    <%# Eval("PatientName") %>
                </td>
                <td>
                    <%# Eval("PatientInsuranceId") %>
                </td>
                <td>
                    <%# Eval("ClaimCharges","{0:c}") %>
                </td>
                <td>
                    <%# Eval("ClaimPayments","{0:c}") %>
                </td>
                <td>
                    <%# Eval("Adjustments","{0:c}") %>
                </td>
                <td>
                    <asp:Label ID="lblClaimStatus" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="hdnERAMasterId" runat="server" />
</asp:Content>