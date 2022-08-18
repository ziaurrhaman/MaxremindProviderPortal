<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master"
    AutoEventWireup="true" CodeFile="ViewClaims.aspx.cs" Inherits="HomeHealth_EpisodeClaims_ViewClaims" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            
            var claimIdsString = $("[id$='hdnQueryString']").val();
            var claimIds = claimIdsString.split(',');
            for (var i = 0; i < claimIds.length; i++) {
                $.post("CallBacks/ViewClaimInformationHandler.aspx", { ClaimId: claimIds[i] },
                 function (data) {
                     var returnHtml = data;
                     var start = data.indexOf("###Start###") + 11;
                     var end = data.indexOf("###End###");
                     $("#divClaim").append(returnHtml.substring(start, end));
                 });
             }
         });

         function PostPayment(elem) {
             
            if ($(elem).closest('div').find('table').children().eq(0).children().eq(2).children().eq(0).find('input').is(':checked') == false) {
                alert("select ");
                return;
            }
            var claimNumber = $.trim($(elem).closest('div').find('table').children().eq(0).children().eq(2).children().eq(1).html());
            var claimPayments = $.trim($(elem).closest('div').find('table').children().eq(0).children().eq(2).children().eq(3).html()).substring(1);
            var claimAdjustments = $.trim($(elem).closest('div').find('table').children().eq(0).children().eq(2).children().eq(4).html()).substring(1);
            $.post("CallBacks/PostClaimHandler.aspx", { claimNumber: claimNumber, claimPayments:claimPayments,claimAdjustments:claimAdjustments },
                function(data) {
                    var returnHtml = data;
                    var start = data.indexOf("###StartPostClaim###") + 20;
                    var end = data.indexOf("###EndPostClaim###");
                    var status = $.trim(returnHtml.substring(start, end));
                    alert(status);
                });
             $(elem).hide();
         }

         function ViewAllClaims() {
             window.location = "AllClaims.aspx";
         }
         
         function ViewClaimPayments() {
             window.location = "AllClaims.aspx";
         }

         
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="quicklaunch">
       <span style="margin-left: 5px; font-size: 14px; font-weight: bold;">Claim Payment Posting</span>
       <div style="float: right">
           
           <input type="button" onclick="ViewAllClaims()" value="Cancel"/>

       </div>
       </div>
    <div id="divClaim"></div>
    <asp:HiddenField ID="hdnQueryString" runat="server" />
</asp:Content>
