<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientInvoiceDetail.aspx.cs" Inherits="ProviderPortal_Claims_CallBacks_ClientInvoiceDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartERAClientInvoiceDetail###
            
                <style type="text/css">
                    #divSoftwareAddress {
                        width: 50%;
                        float: left;
                        padding-top: 35px;
                    }

                    #divInvoice {
                        width: 40%;
                        float: right;
                        padding-top: 20px;
                    }

                    #divPracticeAddress {
                        width: 100%;
                        float: left;
                    }

                    #divClientInvoiceTable {
                        width: 100%;
                    }

                    .thPrint {
                        background: #3B4E87;
                        color: white;
                    }

                    .clsInvoice {
                        background-color: #3B4E87;
                        color: white;
                    }

                    .clsOther {
                        /*background-color: #483D8B;*/
                        margin-top: -0.1%;
                        color: white;
                        border: 1px solid #3B4E87;
                    }

                    #divBillTo {
                        background-color: #3B4E87;
                        width: 100%;
                        color: white;
                    }

                    .tblTh th {
                        font-size: 95%;
                        color: white !important;
                        border: none !important;
                        font-weight: bold;
                        height: 30px;
                        line-height: 19px;
                        /* background: #aadeff; */
                        white-space: nowrap;
                        background: #3B4E87 !important;
                    }

                    #divDueDate {
                        background-color: #D2D8EC;
                    }

                    #tdTotal {
                        background-color: #D2D8EC;
                    }
                   .Grid{
                       width:100% !important;
                   }
                   .ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-dialog-buttons {
    width: 80% !important;
}
                </style>
            <div class="payment-left" id="divClientIvoiceDetail">
                <style type="text/css">
                    @media print {
                         #divSoftwareAddress {
                        width: 50%;
                        float: left;
                        padding-top: 35px;
                    }

                    #divInvoice {
                        width: 40%;
                        float: right;
                        /*padding-top: -20px;*/
                        margin-top:-20%! important;
                        margin-left:20%;
                    }

                    #divPracticeAddress {
                        width: 100%;
                        float: left;
                    }

                    #divClientInvoiceTable {
                        width: 100%;
                    }

                        .clsOther {
                            margin-top: -0.1%;
                            border: 1px solid #3B4E87;
                            -webkit-print-color-adjust: exact;
                        }

                        .clsInvoice {
                            color: black;
                            -webkit-print-color-adjust: exact;
                        }

                        .thPrint {
                            background: #3B4E87 !important;
                            color: white;
                            -webkit-print-color-adjust: exact;
                        }


                        #tbClientInvoices {
                            height: 400px;
                        }

                        #divBillTo {
                            background-color: #3B4E87;
                            width: 100%;
                            color: white;
                            -webkit-print-color-adjust: exact;
                        }

                        .Grid {
                            float: left;
                            width: 100%;
                            border: 1px solid #cbcdcf;
                            border-bottom-left-radius: 4px;
                            border-bottom-right-radius: 4px;
                            border-top-left-radius: 4px;
                            border-top-right-radius: 4px;
                            background: #FFF;
                            border: 1px solid black;
                            -webkit-print-color-adjust: exact;
                        }

                            .Grid th {
                                font-size: 95%;
                                font-weight: bold;
                                height: 30px;
                                line-height: 19px;
                                white-space: nowrap;
                                border-left: 1px solid white !important;
                                -webkit-print-color-adjust: exact;
                            }

                            .Grid > table > tbody > tr:nth-child(even) {
                                background: #EEEEEE;
                                -webkit-print-color-adjust: exact;
                            }

                            .Grid tr {
                                height: 25px;
                                -webkit-print-color-adjust: exact;
                            }

                        .clsOther {
                            color: white !important;
                            background-color: #3B4E87 !important;
                            -webkit-print-color-adjust: exact;
                        }

                        .Grid td {
                            padding: 7px 5px;
                            border-left: 1px solid #C4C4C4;
                            -o-text-overflow: ellipsis;
                            font-size: 100%;
                            -webkit-print-color-adjust: exact;
                        }

                        #divDueDate {
                            background-color: #D2D8EC;
                            -webkit-print-color-adjust: exact;
                        }

                        #tdTotal {
                            background-color: #D2D8EC;
                            -webkit-print-color-adjust: exact;
                        }

                        .letTableLable {
                            /*float: left;
                            text-align: right;
                            margin-left:25% !important;*/
                        }

                        .letTableLable2 {
                            float: left;
                            text-align: right;
                            margin-left: 0 !important;
                        }

                        .letTableLable3 {
                            float: left;
                            text-align: right;
                        }
                        .letTableLable4{
                            width:50% !important;
                        }
                        .clsTd{
                            font-size:12px !important;
                        }
                    }
                </style>
                <asp:HiddenField ID="hdncollections" runat="server" />
                <asp:HiddenField ID="hdncollectionsList" runat="server" />
                <div id="divSoftwareAddress" style="padding-left: 5px;">
                    <span>
                        <img src="../../../Images/max-remind-logo.png" style="width: 36%;" />
                    </span>
                    <div>
                        820 S. Macarthur Blvd Ste 105-147
           
                    <br />
                        Coppell, TX 75019
                    <div id="divPhone">
                        Phone: (469)-567- 3418
                    </div>
                        <div id="divFax">
                            Fax: (855)-574-7238
                        </div>
                        <div>
                            Website:<a href="#">www.mremind.com</a>
                        </div>

                    </div>

                </div>
                <div id="divInvoice">
                    <h1 style="float: right; padding-right: 53px; color: #3B4E87; height: 20px;" class="clsInvoiceh1">INVOICE</h1>
                    <table class="clsTblInvoice">
                        <tr>

                            <td style="text-align: right; padding-right: 20px;" class="clsDate">Date:</td>
                            <td style="border: 1px solid black; width: 53%; margin-left: 42%; text-align: center;" class="clsTd">
                                <asp:Label ID="lblDateNow" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 20px;" class="letTableLable">Invoice #:</td>
                            <td style="border: 1px solid black; width: 53%; margin-left: 42%; text-align: center;" class="clsTd">
                                <asp:Label ID="lblInvoice" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 20px;" >Customer Id:</td>
                            <td style="border: 1px solid black; width: 53%; margin-left: 42%; text-align: center;" class="clsTd">
                                <asp:Label ID="lblCustomerId" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 20px;" class="letTableLable">Due Date:</td>
                            <td style="border: 1px solid black; width: 53%; margin-left: 42%; text-align: center;" id="divDueDate" class="clsTd">
                                <asp:Label ID="lblDueDate" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 20px;" class="letTableLable4">Statement period:</td>
                            <td style="border: 1px solid black; width: 53%; margin-left: 42%; text-align: center;" class="clsTd">
                                <asp:Label ID="lblDateFromDateTo" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div id="divPracticeAddress" style="width: 50%; padding-bottom: 15px; /*padding-top: 12px;*/">
                    <div id="divBillTo">
                        <h3 class="clsBillTo">BILL TO</h3>
                    </div>
                    <div id="divPracticeName" style="width: 100%; float: left; margin-top: -3%; padding-left: 6px;">
                        <asp:Label ID="lblPracticeName" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblPracticeAddress" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblCityStateZip" runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                </div>
                <div id="divClientInvoiceTable" style="width: 100%; float: left;">
                    <asp:Repeater ID="rptClientInvoices" runat="server" OnItemDataBound="rptClientInvoices_ItemDataBound">
                        <HeaderTemplate>
                            <div class="Grid">
                                <table style="width: 100%;" class="tblTh">
                                    <thead>
                                        <tr class="thPrint">
                                            <th class="thPrint">Quantity</th>
                                            <th class="thPrint">Description</th>
                                            <th class="thPrint">Collection </th>
                                            <th class="thPrint">Rate</th>
                                            <th class="thPrint">AMOUNT</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbClientInvoices">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center;"><%# Eval("Quantity") %></td>
                                <td style="text-align: center;"><%# Eval("ItemDescription") %></td>
                                <td style="text-align: center;"><%# Eval("[Collection]","{0:c}") %> </td>
                                <td style="text-align: center;"><%--<%# Eval("RATE") %>%--%>
                                    <asp:Label ID="lblRate" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: right;"><%# Eval("Amount","{0:c}") %>
                                    <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            </tbody> </table>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div id="divOtherCoiments" style="width: 50%; border: 1px solid #3B4E87; float: left; margin-top: 4%;">
                    <h3 class="clsOther" style="color: white !important; background-color: #3B4E87 !important;">OTHER COMMENTS</h3>
                    <div style="margin-left: 2%; margin-top: -3%; padding-bottom: 35px;">
                        1. Total payment due in 15 days<br />
                        2. Please include the invoice number on your check
                    </div>
                </div>
                <div id="divTotal" style="width: 30%; float: right;">
                    <table style="width: 100%;">
                        <tr>
                            <td>Subtotal</td>
                            <td style="text-align: right;"><span style="">$</span><span style="text-align: right;"><asp:Label ID="lblSubTotal" runat="server"></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td>Taxable</td>
                            <td>-</td>
                        </tr>
                        <tr>
                            <td>Tax rate</td>
                            <td>-</td>
                        </tr>
                        <tr>
                            <td>Tax due</td>
                            <td>-</td>
                        </tr>
                        <tr>
                            <td>Other</td>
                            <td>-</td>
                        </tr>
                        <tr>
                            <td style="border-top: 1px solid #C4C4C4; font-weight: bold;">Total<asp:Label ID="Label1" runat="server"></asp:Label></td>
                            <td style="border-top: 1px solid #C4C4C4; font-weight: bold; text-align: right;" id="tdTotal"><span style="">$</span><span style="text-align: right;"><asp:Label ID="lblTotal" runat="server"></asp:Label></span></td>
                        </tr>
                    </table>
                    <div style="text-align: center; padding-top: 18px;">
                        Make all checks payable to
                    <br />
                        <h3 style="margin-top: -1%;">MaxRemind</h3>
                    </div>
                </div>
                <div id="divContact" style="width: 100%; text-align: center; float: left; padding-top: 18px;">
                    If you have any questions about this invoice, please contact
            <br />
                    CustomerSupport, (469)-567- 3418, CustomerSupport@mremind.com
            <h3 style="margin-top: 0%;">Thank You For Your Business!</h3>
                </div>
            </div>





            <div class="payment-div">
                    <div class="payment-header">
                        <div class="payment-heading">
                            <h1>
                                Payments Details
                            </h1>
                            <div class="payments-icons">
                                <img src="../../Images/visa-icon.png" />
                                 <img src="../../Images/master-icon.png" />
                                 <img src="../../Images/amer-icon.png" />
                                 <img src="../../Images/paypal.jpg" />
                            </div>

                        </div>

                        <div class="pay-scure-icon">
                            <img src="../../../Images/secure_icon.png" />
                        </div>

                    </div>

                    <div class="payment-form">
                        <div class="payment">
      <div class="payment-details">
        <label for="card_name">Card Holder</label>
        <input id="card_name" type="text" placeholder="edison chee">
        <div class="card_number_container">
          <label for="card_number">Card Number</label>
          <input id="card_number" type="text" placeholder="1234 1234 1234 1234" maxlength="16" />
          <svg class="social-icon" id="mc-icon">
            <use xlink:href="#mc"></use>
          </svg>
          <svg class="social-icon" id="visa-icon">
            <use xlink:href="#visa"></use>
          </svg>
        </div>
        <div class="row">
          <div class="expiry-date">
            <label>Expiry Date (MM/YY)</label>
            <div>
              <input id="expiry_month" type="text" placeholder="08" maxlength="2" />
              <span>/</span>
              <input id="expiry_year" type="text" placeholder="25" maxlength="2" />
            </div>
          </div>
          <div class="cvc">
            <label for="cvc">CVV/CVC</label>
            <input id="cvc" type="text" placeholder="123" maxlength="3" />
          </div>
        </div>
          <div class="row">
              <label for="card_name">Payable Amount</label>
       <div class="amount-outer"> <input id="pay_amount" type="text" placeholder="100.00 USD" /></div>
          </div>
          <p class="agreement">By clicking "Pay" you agree to aur <a href="#">Terms and Conditions</a></p>
          <div class="row">
              <div class="pay-btn-outer">
        <a class="button">Cancel</a>
        <a class="button">Pay</a>
      </div>
              </div>
      </div>
    </div>
                    </div>

                </div>
            <script>

                !function (a) { "function" == typeof define && define.amd ? define(["jquery"], a) : a("object" == typeof exports ? require("jquery") : jQuery) }(function (a) { var b, c = navigator.userAgent, d = /iphone/i.test(c), e = /chrome/i.test(c), f = /android/i.test(c); a.mask = { definitions: { 9: "[0-9]", a: "[A-Za-z]", "*": "[A-Za-z0-9]" }, autoclear: !0, dataName: "rawMaskFn", placeholder: "_" }, a.fn.extend({ caret: function (a, b) { var c; if (0 !== this.length && !this.is(":hidden")) return "number" == typeof a ? (b = "number" == typeof b ? b : a, this.each(function () { this.setSelectionRange ? this.setSelectionRange(a, b) : this.createTextRange && (c = this.createTextRange(), c.collapse(!0), c.moveEnd("character", b), c.moveStart("character", a), c.select()) })) : (this[0].setSelectionRange ? (a = this[0].selectionStart, b = this[0].selectionEnd) : document.selection && document.selection.createRange && (c = document.selection.createRange(), a = 0 - c.duplicate().moveStart("character", -1e5), b = a + c.text.length), { begin: a, end: b }) }, unmask: function () { return this.trigger("unmask") }, mask: function (c, g) { var h, i, j, k, l, m, n, o; if (!c && this.length > 0) { h = a(this[0]); var p = h.data(a.mask.dataName); return p ? p() : void 0 } return g = a.extend({ autoclear: a.mask.autoclear, placeholder: a.mask.placeholder, completed: null }, g), i = a.mask.definitions, j = [], k = n = c.length, l = null, a.each(c.split(""), function (a, b) { "?" == b ? (n--, k = a) : i[b] ? (j.push(new RegExp(i[b])), null === l && (l = j.length - 1), k > a && (m = j.length - 1)) : j.push(null) }), this.trigger("unmask").each(function () { function h() { if (g.completed) { for (var a = l; m >= a; a++)if (j[a] && C[a] === p(a)) return; g.completed.call(B) } } function p(a) { return g.placeholder.charAt(a < g.placeholder.length ? a : 0) } function q(a) { for (; ++a < n && !j[a];); return a } function r(a) { for (; --a >= 0 && !j[a];); return a } function s(a, b) { var c, d; if (!(0 > a)) { for (c = a, d = q(b); n > c; c++)if (j[c]) { if (!(n > d && j[c].test(C[d]))) break; C[c] = C[d], C[d] = p(d), d = q(d) } z(), B.caret(Math.max(l, a)) } } function t(a) { var b, c, d, e; for (b = a, c = p(a); n > b; b++)if (j[b]) { if (d = q(b), e = C[b], C[b] = c, !(n > d && j[d].test(e))) break; c = e } } function u() { var a = B.val(), b = B.caret(); if (o && o.length && o.length > a.length) { for (A(!0); b.begin > 0 && !j[b.begin - 1];)b.begin--; if (0 === b.begin) for (; b.begin < l && !j[b.begin];)b.begin++; B.caret(b.begin, b.begin) } else { for (A(!0); b.begin < n && !j[b.begin];)b.begin++; B.caret(b.begin, b.begin) } h() } function v() { A(), B.val() != E && B.change() } function w(a) { if (!B.prop("readonly")) { var b, c, e, f = a.which || a.keyCode; o = B.val(), 8 === f || 46 === f || d && 127 === f ? (b = B.caret(), c = b.begin, e = b.end, e - c === 0 && (c = 46 !== f ? r(c) : e = q(c - 1), e = 46 === f ? q(e) : e), y(c, e), s(c, e - 1), a.preventDefault()) : 13 === f ? v.call(this, a) : 27 === f && (B.val(E), B.caret(0, A()), a.preventDefault()) } } function x(b) { if (!B.prop("readonly")) { var c, d, e, g = b.which || b.keyCode, i = B.caret(); if (!(b.ctrlKey || b.altKey || b.metaKey || 32 > g) && g && 13 !== g) { if (i.end - i.begin !== 0 && (y(i.begin, i.end), s(i.begin, i.end - 1)), c = q(i.begin - 1), n > c && (d = String.fromCharCode(g), j[c].test(d))) { if (t(c), C[c] = d, z(), e = q(c), f) { var k = function () { a.proxy(a.fn.caret, B, e)() }; setTimeout(k, 0) } else B.caret(e); i.begin <= m && h() } b.preventDefault() } } } function y(a, b) { var c; for (c = a; b > c && n > c; c++)j[c] && (C[c] = p(c)) } function z() { B.val(C.join("")) } function A(a) { var b, c, d, e = B.val(), f = -1; for (b = 0, d = 0; n > b; b++)if (j[b]) { for (C[b] = p(b); d++ < e.length;)if (c = e.charAt(d - 1), j[b].test(c)) { C[b] = c, f = b; break } if (d > e.length) { y(b + 1, n); break } } else C[b] === e.charAt(d) && d++, k > b && (f = b); return a ? z() : k > f + 1 ? g.autoclear || C.join("") === D ? (B.val() && B.val(""), y(0, n)) : z() : (z(), B.val(B.val().substring(0, f + 1))), k ? b : l } var B = a(this), C = a.map(c.split(""), function (a, b) { return "?" != a ? i[a] ? p(b) : a : void 0 }), D = C.join(""), E = B.val(); B.data(a.mask.dataName, function () { return a.map(C, function (a, b) { return j[b] && a != p(b) ? a : null }).join("") }), B.one("unmask", function () { B.off(".mask").removeData(a.mask.dataName) }).on("focus.mask", function () { if (!B.prop("readonly")) { clearTimeout(b); var a; E = B.val(), a = A(), b = setTimeout(function () { B.get(0) === document.activeElement && (z(), a == c.replace("?", "").length ? B.caret(0, a) : B.caret(a)) }, 10) } }).on("blur.mask", v).on("keydown.mask", w).on("keypress.mask", x).on("input.mask paste.mask", function () { B.prop("readonly") || setTimeout(function () { var a = A(!0); B.caret(a), h() }, 0) }), e && f && B.off("input.mask").on("input.mask", u), A() }) } }) });

                $('#card_number').on('keyup', function () {
                    var val = $(this).val();
                    var len = val.replace(/\_/g, '').length;
                    if (!isNaN(val.slice(-1))) {
                        $('#expiry_month').focus();
                    }
                    if (!isNaN(val.slice(0, 4))) {
                        if (val[0] === '4') {
                            $('#visa-icon').css('opacity', 1);
                            $('#mc-icon').css('opacity', 0);
                        } else if (val[0] === '5') {
                            $('#mc-icon').css('opacity', 1);
                            $('#visa-icon').css('opacity', 0);
                        }
                    } else {
                        $('#mc-icon, #visa-icon').css('opacity', 0);
                    }
                });

                $("#card_number").mask("9999 9999 9999 9999");

                $("#expiry_month").on('keyup', function () {
                    var val = this.value;
                    if (val.length === 2) {
                        $("#expiry_year").focus();
                    }
                });

                $("#expiry_year").on('keyup', function () {
                    var val = this.value;
                    if (val.length === 2) {
                        $("#cvc").focus();
                    }
                });
            </script>
            ###EndERAClientInvoiceDetail###
        </div>
    </form>
</body>
</html>
