<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="ClaimPayments.aspx.cs" Inherits="HomeHealth_EpisodeClaims_ClaimPayments" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                alert("Please Select a Claim");
                return;
            }
            window.location = "ViewClaims.aspx?" + queryString;
        }

        function ViewAllClaims() {
            window.location = "AllClaims.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="quicklaunch">
        <span style="margin-left: 5px; font-size: 14px; font-weight: bold;">Select Claims</span>
        <div style="float: right">
            <input type="button" onclick="ViewAllClaims()" value="Cancel" />
        </div>
    </div>
    <asp:Repeater ID="rptERAClaimPayments" runat="server" OnItemDataBound="rptERAClaimPayments_ItemDataBound">
        <HeaderTemplate>
            <table class="Grid">
                <tr>
                    <th>
                    </th>
                    <th>
                        Claim Number
                    </th>
                    <th>
                        Patient Name
                    </th>
                    <th>
                        Claim Charges
                    </th>
                    <th>
                        Claim Payments
                    </th>
                    <th>
                        Claim Status
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="ClaimRow" id="<%# Eval("ERAClaimPaymentsId") %>">
                <td>
                    <input id="chkSelect" type="checkbox" />
                </td>
                <td>
                    <%# Eval("ClaimNumber") %>
                </td>
                <td>
                    <%# Eval("PatientFirstName") %>
                    <%# Eval("PatientLastName") %>
                </td>
                <td>
                    <%# Eval("ClaimCharges","{0:c}") %>
                </td>
                <td>
                    <%# Eval("ClaimPayments","{0:c}") %>
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
    <div style="float: right; margin: 10px 0px;">
        <input id="btnViewClaims" onclick="viewClaims()" type="button" value="View Claims" />
    </div>
</asp:Content>

