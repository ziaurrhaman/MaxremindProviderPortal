<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/ProviderPortal/BillingMaster.master" CodeFile="Paypal.aspx.cs" Inherits="ProviderPortal_PayPal_Paypal" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">

  
</asp:Content>
<asp:Content runat="server" ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1">
     <meta name="viewport" content="width=device-width, initial-scale=1">
     <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <script
    src="https://www.paypal.com/sdk/js?client-id=ATf_pyUszYzz4201tdWY7ivsA52RqrujyEprYUm4Qg34nbsaFueV_lJy8r7Ec4UHu49HKXprsliRu2JV">
  </script>

    <script>$(document).ready(function () {
   
   
});





      </script>

    <script>
        var _money = $("#txtpayment").val();
            paypal.Buttons({
                createOrder: function (data, actions) {
                    // Set up the transaction
                    return actions.order.create({
                        purchase_units: [{
                            amount: {
                                value: _money
                            }
                        }]
                    });
                }
            }).render('.paypaldiv');
            function loadmoney(elem){
              _money=  $(elem).val()||0;
            }
</script>
   
    <div class="paypaldiv" style="margin:auto;padding:5% 35%;background-color:white">
         <div><input type="number" onkeyup="loadmoney(this)" id="txtpayment" placeholder="$0.00"  style=" margin: 2% 0.6%;padding: 3%;width: 92%;"/></div>
    </div>
</asp:Content>