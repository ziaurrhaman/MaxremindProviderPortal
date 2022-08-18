<%@ Page Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="ClientInvoice.aspx.cs" Inherits="ProviderPortal_Claims_ClientInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ERASearchLabel {
            font-weight: bold;
        }

        .WidgetTitle {
            background: #006291;
            height: 21px;
            color: white;
            font-weight: bold;
            font-size: 16px;
            width: 99%;
        }
    </style>
    <script type="text/javascript" src="js/Sorting.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:HiddenField runat="server" ID="hdnTotalRows" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
    <asp:HiddenField runat="server" ID="hdnRow" />
    <asp:HiddenField runat="server" ID="hdnPageNumber" />
    <asp:HiddenField runat="server" ID="hdnEraMasterId" />
    <asp:HiddenField runat="server" ID="hdnClientInvoiceId" />
    <asp:HiddenField runat="server" ID="hdnCheckNumber" />
    <div class="page-content">
        <div class="Widget">
            <div class="Headerbar">
                
            <h1 style="width: 80%; float: left; color: #006291; height: 3px; margin-top: -1px;">Invoice Detail</h1>
            <div style="width: 20%; height: 22px; background-color: #F2F2F2; float:right;">
                <table style="float: right; width: 14%;margin-top: -2px;">
                    <tr>
                        <td style="width: 5%; padding-right: 3px;">
                            <input type="button" id="btnPrintView" name="FilterInvoices" value="Print View" onclick=" GetInvoicePrintView();" style="background: #3B4E87; color: white; margin-right: 14%;" />
                        </td>
                        <td style="width: 5%; padding-right: 13px;">
                            <input type="button" id="btnInvoiceGrid" name="FilterInvoices" value="Invoice Grid" onclick=" GetInvoiceGrid();" style="background: #3B4E87; color: white; margin-right: 14%;" />
                        </td>
                    </tr>
                </table>
            </div>
                </div>
            <style type="text/css">
                #divSoftwareAddress {
                    width: 50%;
                    float: left;
                }

                #divInvoice {
                    width: 33%;
                    float: right;
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

                #civCollection {
                    background-color: #3B4E87;
                    width: 100%;
                    color: white;
                }

                #divInvoiceh1 {
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
                    white-space: nowrap;
                    background: #3B4E87 !important;
                }

                #divDueDate {
                    background-color: #D2D8EC;
                }

                #tdTotal {
                    background-color: #D2D8EC;
                }

                .sortByERA {
                    text-align: left;
                }

                @media print {

                    .clsOther {
                        margin-top: -0.1%;
                        border: 1px solid #3B4E87;
                    }

                    .clsInvoice {
                        color: black;
                    }

                    .thPrint {
                        background: #3B4E87 !important;
                        color: white;
                    }

                    .Grid {
                        border: 1px solid black;
                    }

                    #tbClientInvoices {
                        height: 400px;
                    }

                    #divBillTo {
                        background-color: #3B4E87;
                        color: white !important;
                        width: 100%;
                        -webkit-print-color-adjust: exact;
                    }

                    .Grid th {
                        font-size: 95%;
                        font-weight: bold;
                        height: 30px;
                        line-height: 19px;
                        white-space: nowrap;
                        /*border: 2px solid #3B4E87 !important;*/
                        /*border-left:1px solid #3B4E87 !important;*/
                        /*border-right:1px solid #3B4E87 !important;*/
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
                        float: left;
                        text-align: right;
                        margin-left: 11% !important;
                    }

                    .letTableLable2 {
                        float: left;
                        text-align: right;
                        margin-left: 0 !important;
                    }

                    .letTableLable3 {
                        float: left;
                        text-align: right;
                        margin-left: 0 !important;
                    }
                }
            </style>
            
 <%--   <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>
            <script type="text/javascript">
                $(document).ready(function () {


                    debugger;
                   

                    $("#txtPaymentDate").datepicker({
                        changeMonth: true,
                        changeYear: true
                    }).mask("99/99/9999");
                     

                    GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingERA").val(), "ERAContainer", "FilterERA");
                    if ($("[id$='hdnTotalRows']").val() > 0)
                        $("#ERAContainer .spanInfo").html("Showing " + $("#tbClientInvoices tr:first").children().first().html() + " to " + $("#tbClientInvoices tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
                });
                function GetClientInvoiceDetail(elem) {
                    debugger;
                    var CurrentRow = $(elem).closest("tr");
                    var ClientInvoiceId = $.trim(CurrentRow.find(".hdnClientinvoiceId").val());
                    var CheckNo = $.trim(CurrentRow.find(".hdnCheckNumber").val());
                    $.post(_ResolveUrl + "ProviderPortal/Claims/CallBacks/ClientInvoiceDetail.aspx", { ClientInvoiceId: ClientInvoiceId, CheckNo: CheckNo }, function (data) {
                        var returnHtml = data;
                        var start = data.indexOf("###StartERAClientInvoiceDetail###") + 33;
                        var end = data.indexOf("###EndERAClientInvoiceDetail###");
                        debugger;
                        $("#divERAClaimsPrint").html(returnHtml.substring(start, end));
                        $("#divERAClaimsPrint").dialog({
                            width: 960,
                            modal: true,
                            title: "Client Invoice Detail",
                            open: function () {
                                $(".ui-widget-overlay").last().css("z-index", "9999999");
                                $(".ui-dialog").last().css("z-index", "99999999");
                            },
                            buttons: {

                                "Invoice Detail": function () {
                                    printHtml("divClientIvoiceDetail");
                                    $(this).dialog("destroy");
                                    $("#divClientIvoiceDetail").hide();
                                    $("#divERAClaimsPrint").hide();
                                    $("#divERAClaimsPrint").css("display", "none");
                                    $("#divHumburger").css("display", "block");
                                    
                                },
                                Print: function () {
                                    printHtml("divClientIvoiceDetail");
                                    $(this).dialog("destroy");
                                    $("#divClientIvoiceDetail").hide();
                                    $("#divERAClaimsPrint").hide();
                                    $("#divERAClaimsPrint").css("display", "none");
                                },
                                Close: function () {
                                    $(this).dialog("destroy");
                                    $("#divClientIvoiceDetail").hide();
                                    $("#divERAClaimsPrint").hide();
                                    $("#divERAClaimsPrint").css("display", "none");
                                }
                            }
                        });
                    })
                }

                function FilterERA(pageNumber, paging) {
                    var PaymentType = $("[id$='ddlPaymentType']").val();
                    var PayerName = $("#txtPayerName").val();
                    var PaymentMethod = $("#txtPaymentMethod").val();
                    var checkNumber = $("#txtCheckNumber").val();
                    var PaymentDate = $("#txtPaymentDate").val();
                    var Collection = $("#txtCollection").val();
                    var ClientInvoiceId = $("[id$='hdnClientInvoiceId']").val();
                    var sort = $("[id$='sortBy']").val();
                    //var sort = SORTBY;
                    //if (sort == "") { sort = "Check Number DESC" }
                    $.post("ClientInvoiceHandler.aspx", {
                        Rows: $("#ddlPagingERA").val(), pageNumber: pageNumber, sort: sort, PaymentType: PaymentType, PayerName: PayerName, PaymentMethod: PaymentMethod, checkNumber: checkNumber, PaymentDate: PaymentDate, Collection: Collection, ClientInvoiceId: ClientInvoiceId
                    },
                    function (data) {
                        debugger;
                        var returnHtml = data;
                        var start = data.indexOf("###Start###") + 11;
                        var end = data.indexOf("###End###");
                        $("#tbClientInvoices").html(returnHtml.substring(start, end));

                        var startRowsCount = data.indexOf("###StartERARowsCount###") + 23;
                        var endRowsCount = data.indexOf("###EndERARowsCount###");
                        $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

                        if (paging == true) {

                            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingERA").val(), "ERAContainer", "FilterERA");
                        }

                        if ($("[id$='hdnTotalRows']").val() > 0)
                            $("#ERAContainer .spanInfo").html("Showing " + $("#tbClientInvoices tr:first").children().first().html() + " to " + $("#tbClientInvoices tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
                    });

                }

                function PrintCheckInvoiceInfo(elem) {
                    var CurrentRow = $(elem).closest("tr");
                    var claimCheckId = $.trim(CurrentRow.find(".hdnClaimCheckId").val());
                    $.post(_ResolveUrl + "ProviderPortal/Payment/CallBacks/ERAClaimsPrintHandler.aspx", { ClaimCheckId: claimCheckId }, function (data) {
                        var returnHtml = data;
                        var start = data.indexOf("###StartERAClaims###") + 20;
                        var end = data.indexOf("###EndERAClaims###");
                        $("#divERAClaimsPrint").html(returnHtml.substring(start, end));

                        $("#divERAClaimsPrint").dialog({
                            width: 960,
                            modal: true,
                            title: "ERA Claims Print",
                            open: function () {
                                $(".ui-widget-overlay").last().css("z-index", "9999999");
                                $(".ui-dialog").last().css("z-index", "99999999");
                            },
                            buttons: {
                                Print: function () {
                                    printHtml("divERAClaimsCheckDetailPrint");
                                    $(this).dialog("destroy");
                                    $("#divERAClaimsCheckDetailPrint").hide();
                                    $("#divERAClaimsPrint").hide();
                                    $("#divERAClaimsPrint").css("display", "none");
                                },
                                Close: function () {
                                    $(this).dialog("destroy");
                                    $("#divERAClaimsCheckDetailPrint").hide();
                                    $("#divERAClaimsPrint").hide();
                                    $("#divERAClaimsPrint").css("display", "none");
                                }
                            }
                        });
                    })
                }
                function CollectionKeyPress(event) {
                    debugger;
                    if (event.which < 46 || event.which > 59) {
                        event.preventDefault();
                    }

                    if (event.which == 46 && $(this).val().indexOf('.') != -1) {
                        event.preventDefault();
                    }
                }
                function SetSearch(event) {
                    debugger;
                    var a = event.which || event.keyCode;
                    if (a == 13) {
                        if ($("#FilterIcon").hasClass("active")) {
                            FilterERA(0, true);
                            $("#FilterIcon").css("color", "#065172");
                        }
                    }
                    else {
                        $("#FilterIcon").addClass("active");
                        $("#FilterIcon").css("color", "red");
                    }

                }
                function GetInvoiceGrid() {
                    debugger;
                    window.location.href = "../InvoiceGenerated.aspx";
                }
                function GetInvoicePrintView() {
                    debugger;
                    var ClientInvoiceId = $("[id$='hdnClientInvoiceId']").val();
                    var CheckNo = $("[id$='hdnCheckNumber']").val();
                    $.post(_ResolveUrl + "ProviderPortal/Claims/CallBacks/ClientInvoiceDetail.aspx", { ClientInvoiceId: ClientInvoiceId, CheckNo: CheckNo }, function (data) {
                        var returnHtml = data;
                        var start = data.indexOf("###StartERAClientInvoiceDetail###") + 33;
                        var end = data.indexOf("###EndERAClientInvoiceDetail###");
                        debugger;
                        $("#divERAClaimsPrint").html(returnHtml.substring(start, end));
                        $("#divERAClaimsPrint").css("z-index", "9999999");
                        $("#divERAClaimsPrint").dialog({
                            width: 960,
                            modal: true,
                            title: "Client Invoice Detail",
                            open: function () {
                               // $(".ui-widget-overlay").last().css("z-index", "9999999");
                                //$(".ui-dialog").last().css("z-index", "99999999");
                            },
                            buttons: {
                                "Pay Through": function () {
                                    debugger;
                                    $("#divDivPayThrough").dialog({
                                        width: 368,
                                        modal: true,
                                        title: "Pay Through",
                                        open: function () {
                                            $(".ui-widget-overlay").last().css("z-index", "9999999");
                                            $(".ui-dialog").last().css("z-index", "99999999");
                                        },
                                        buttons: {

                                            "Close": function () {
                                                $(this).dialog("close");
                                            }
                                        }
                                    });
                                },
                                "Invoice Detail": function () {
                                    debugger;
                                    window.location.href = "ClientInvoice.aspx?ClientInvoiceId=" + ClientInvoiceId + "&CheckNo=" + CheckNo;
                                    $(this).dialog("close");
                                },
                                Print: function () {
                                    /*printHtml("divClientIvoiceDetail");
                                    $(this).dialog("destroy");
                                    $("#divClientIvoiceDetail").hide();
                                    $("#divERAClaimsPrint").hide();
                                    $("#divERAClaimsPrint").css("display", "none");*/
                                    var divToPrint = document.getElementById('divClientIvoiceDetail');
                                    var newWin = window.open('', 'Print-Window');
                                    newWin.document.open();
                                    newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
                                    newWin.document.close();
                                    setTimeout(function () { newWin.close(); }, 10);
                                },
                                OK: function () {
                                    $(this).dialog("destroy");
                                    $("#divClientIvoiceDetail").hide();
                                    $("#divERAClaimsPrint").hide();
                                    $("#divERAClaimsPrint").css("display", "none");
                                }
                            }
                        });
                    })
                }
            </script>
            <div id="divInvoice" style="width: 33%;padding-top: 16px; float: left;">
                 <div style="background-color: #3B4E87; width: 100%; color: white; height:16px;">
                </div>
                <div style="padding-top:5px;">
                <table style="width: 80%;">
                    <tr>

                        <td style="text-align: right; width: 50%;">Date:</td>
                        <td style="border: 1px solid black; text-align: center;">
                            <asp:Label ID="lblDateNow" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 50%;" class="letTableLable">INVOICE #:</td>
                        <td style="border: 1px solid black; text-align: center;">
                            <asp:Label ID="lblInvoice" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 50%;" class="letTableLable2">CUSTOMER ID:</td>
                        <td style="border: 1px solid black; text-align: center;">
                            <asp:Label ID="lblCustomerId" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 50%;" class="letTableLable">DUE DATE:</td>
                        <td style="border: 1px solid black; text-align: center;" id="divDueDate">
                            <asp:Label ID="lblDueDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 50%;" class="letTableLable3">Statement period:</td>
                        <td style="border: 1px solid black; text-align: center;">
                            <asp:Label ID="lblDateFromDateTo" runat="server"></asp:Label></td>
                    </tr>
                </table>
                    </div>
            </div>
            <div id="divInvoiceCollection" style="width: 66%; float: left; margin-top: -2px;">
                <div id="civCollection">
                    <h3 class="clsCollection" style="margin-left: 26%; height:16px;"></h3>
                </div>
                <table style="width: 58%;margin-left: 28%; margin-top:-9px;">
                    <asp:Repeater ID="rptClientInvoicesCollection" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: right; width: 26%;"><%# Eval("ItemDescription") %>:</td>
                                <td style="border:1px solid black; text-align:center; width: 20%;"><%# Eval("Amount","{0:c}") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td style="text-align: right; width: 26%;">Sub Total:</td>
                        <td  style="border:1px solid black; text-align:center; width: 20%;">
                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 26%;">Total:</td>
                        <td  style="border:1px solid black; text-align:center; width: 20%;">
                            <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <div class="WidgetMainContent">
                <div id="ERAContainer" style="float: left; width: 100%;">
                    <asp:Repeater ID="rptClientInvoices" runat="server">
                        <HeaderTemplate>
                            <div class="Grid">
                                <table>
                                    <thead>
                                        <tr class="sortByERA">
                                            <th style="width: 3%;">S.No
                                           <asp:HiddenField ID="sortBy" runat="server" />
                                            </th>
                                            <th style="width: 10%;" onclick="sort(this)">Payment Type
                              
                                            </th>
                                            <th style="width: 22%;" onclick="sort(this)">Payer Name
                                            </th>
                                            <th style="width: 18%;" onclick="sort(this)">Payment Method
                                            </th>
                                            <th style="width: 10%;" onclick="sort(this)">Check Number
                                            </th>
                                            <th style="width: 10%;" onclick="sort(this)">Payment Date
                                            </th>
                                            <th style="width: 10%;" onclick="sort(this)">Collection
                                            </th>
                                        </tr>
                                        <tr>
                                            <th><i class="fa fa-filter" style="color: #065172; font-size: 20px !important;" id="FilterIcon" onclick="FilterERA(0, true)"></i>
                                            </th>
                                            <th>
                                                <%--<input type="text" id="txtPaymentType" onkeyup="SetSearch(event)" />--%>
                                                 <asp:DropDownList ID="ddlPaymentType" runat="server" onchange="FilterERA(0, true)">
                                                            <asp:ListItem Value="" Text="" Selected="True">All</asp:ListItem>
                                                            <asp:ListItem Value="EOB" >EOB</asp:ListItem>
                                                            <asp:ListItem Value="ERA">ERA</asp:ListItem>
                                                            <asp:ListItem Value="PAT">PAT</asp:ListItem>
                                                        </asp:DropDownList>
                                            </th>
                                            <th>
                                                <input type="text" id="txtPayerName" onkeyup="SetSearch(event)" /></th>
                                            <th>
                                                <input type="text" id="txtPaymentMethod" onkeyup="SetSearch(event)" /></th>
                                            <th>
                                                <input type="text" id="txtCheckNumber" onkeyup="SetSearch(event)" /></th>
                                            <th>
                                                <input type="text" id="txtPaymentDate" onchange="FilterERA(0, true);" /></th>
                                            <th>
                                                <input type="text" id="txtCollection" onkeyup="SetSearch(event)" onkeypress="return CollectionKeyPress(event);" /></th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbClientInvoices">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="DataRow">
                                <td>
                                    <i>
                                        <%# Eval("RowNumber") %></i>
                                </td>
                                <td id="<%# Eval("PaymentType") %>">
                                    <%# Eval("PaymentType") %>
                                </td>
                                <td id="<%# Eval("Insurance") %>">
                                    <%# Eval("Insurance") %>
                                </td>
                                <td>
                                    <%# Eval("PaymentMethodCode") %>
                                </td>
                                <td>
                                    <span style="cursor: pointer; color: blue; border-bottom: 1px solid blue;" onclick="PrintCheckInvoiceInfo(this);"><%# Eval("CheckNumber") %></span>
                                    <input type="hidden" class="hdnClaimCheckId" value='<%# Eval("ERAMasterId")%>' />
                                </td>
                                <td>
                                    <%# Eval("PaymentDate", "{0:d}") %>
                                </td>
                                <td>
                                    <%# Eval("CheckAmount","{0:c}") %>
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
                                        <select id="ddlPagingERA" style="margin-top: 5px;" onchange="FilterERA(0, true)">
                                            <option value="10">10</option>
                                            <option value="25">25</option>
                                            <option value="50">50</option>
                                            <option value="75">75</option>
                                            <option value="100">100</option>
                                            <option value="100000">All</option>
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

            <div id="divERAClaimPayments" class="Widget" style="margin-top: 20px; float: left; width: 100%">
            </div>
        </div>
    </div>
    <div id="divItemPdf" style="display: none;">
    </div>
    <div id="divDivPayThrough" style="display: none;">
        <h1>Under Construction</h1>
    </div>
</asp:Content>

