<%@ Page Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="InvoiceGenerated.aspx.cs" Inherits="ProviderPortal_Claims_InvoiceGenerated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ERASearchLabel {
            font-weight: bold;
        }

        .WidgetTitle {
            background: #006291;
            font-size: 16px;
            color: white;
            font-weight: bold;
            width: 99%;
            height: 20px;
        }

    </style>
    <script type="text/javascript" src="js/Sorting.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            if (!checkModuleRights("ClientInvoices")) {
                $("[id$='divRightsSettings']").html("You don't have rights to View Client Invoices").show();
                $("[id$='divClaimAll']").hide();
                $("[id$='ContentMaindiv']").hide();
                return false;
            }
            var dateOfBirthMin = new Date();
            dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);

            $("#txtInvoiceDueDate").datepicker({
                changeMonth: true,
                changeYear: true,
                //minDate: "01/01/1900",
                // maxDate: new Date
            }).mask("99/99/9999");

            $("#txtBillDate").datepicker({
                changeMonth: true,
                changeYear: true
            }).mask("99/99/9999");
            $("#txtStatementPeriod").datepicker({
                 changeMonth: true,
                 changeYear: true
             }).mask("99/99/9999");


            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingERA").val(), "ERAContainer", "FilterERA");
            if ($("[id$='hdnTotalRows']").val() > 0)
                $("#ERAContainer .spanInfo").html("Showing " + $("#tbClientInvoices tr:first").children().first().html() + " to " + $("#tbClientInvoices tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        });

        function sort(elem) {
            SORTBY = "";
            debugger;
            if ($(elem).find('img').length == 0) {
                $(elem).parent().find('img').remove();
                var imghtml = "   <img src='../../Images/uparrowForSorting.png'  style='width: 12px; display: inline;'>\
        <img src='../../Images/downarrowForSorting.png'  style='width: 12px; display: none;'>"

                $(elem).append(imghtml);
            }
            else {
                $(elem).find("img").toggle();
                $(elem).find("img").toggleClass('SortBy');
                var sortBy = $(elem).find("img").hasClass('SortBy');
                if (sortBy) {
                    SORTBY = $.trim($(elem).text()) + ' ASC';
                }
                else {
                    SORTBY = $.trim($(elem).text()) + ' DESC';
                }
                $("[id$='sortBy']").val(SORTBY);

                FilterERA(0, true);
            }


        }
        function FilterERA(pageNumber, paging) {
            debugger;
            var InvoiceNumber = $("#txtInvoiceNumber").val();
            var StatementPeriod = $("#txtStatementPeriod").val();
            var InvoiceDueDate = $("#txtInvoiceDueDate").val();
            var BillDate = $("#txtBillDate").val();
            var Amount = $("#txtAmount").val();
            var PayStatus = $.trim($("[id$='ddlStatus']").val());

            var sort = $("[id$='sortBy']").val();
            //var sort = SORTBY;
            //if (sort == "") { sort = "Check Number DESC" }
            $.post("CallBacks/InvoiceGeneratedHandler.aspx", { Rows: $("#ddlPagingERA").val(), pageNumber: pageNumber, sort: sort, InvoiceNumber: InvoiceNumber, StatementPeriod: StatementPeriod, InvoiceDueDate: InvoiceDueDate, BillDate: BillDate, Amount: Amount, PayStatus: PayStatus },
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
        function GetClientInvoiceDetail(elem) {
            debugger;
            var CurrentRow = $(elem).closest("tr");
            var ClientInvoiceId = $.trim(CurrentRow.find(".hdnClientinvoiceId").val());
            var CheckNo = "";//$.trim(CurrentRow.find(".hdnCheckNumber").val());
            $.post(_ResolveUrl + "ProviderPortal/Claims/CallBacks/ClientInvoiceDetail.aspx", { ClientInvoiceId: ClientInvoiceId, CheckNo: CheckNo }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###StartERAClientInvoiceDetail###") + 33;
                var end = data.indexOf("###EndERAClientInvoiceDetail###");
                debugger;
                $("#divERAClaimsPrint").html(returnHtml.substring(start, end));
                $("#divERAClaimsPrint").css("z-index", "9999999");
                $(".payment-div").css("display","none");
                $(".payment-left").css("width","98%");
                $("#divERAClaimsPrint").dialog({
                    width: 1200,
                    modal: true,
                    title: "Client Invoice Detail",
                    open: function () {
                        //$(".ui-widget-overlay").last().css("z-index", "9999999");
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
                            //$(this).dialog("close");
                        },
                        Print: function () {
                           /* printHtml("divClientIvoiceDetail");
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
        function GetClientInvoiceDetail_Payment(elem) {
            debugger;
            var CurrentRow = $(elem).closest("tr");
            var ClientInvoiceId = $.trim(CurrentRow.find(".hdnClientinvoiceId").val());
            var CheckNo = "";//$.trim(CurrentRow.find(".hdnCheckNumber").val());
            $.post(_ResolveUrl + "ProviderPortal/Claims/CallBacks/ClientInvoiceDetail.aspx", { ClientInvoiceId: ClientInvoiceId, CheckNo: CheckNo }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###StartERAClientInvoiceDetail###") + 33;
                var end = data.indexOf("###EndERAClientInvoiceDetail###");
                debugger;
                $("#divERAClaimsPrint").html(returnHtml.substring(start, end));
                $("#divERAClaimsPrint").css("z-index", "9999999");

                $("#divERAClaimsPrint").dialog({
                    width: 1200,
                    modal: true,
                    title: "Client Invoice Detail",
                    open: function () {
                        //$(".ui-widget-overlay").last().css("z-index", "9999999");
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
                            //$(this).dialog("close");
                        },
                        Print: function () {
                            /* printHtml("divClientIvoiceDetail");
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
       
        var _IsInvoiceNoValidated = true;
        function InvoiceNoKeyPress(evt) {
            _IsInvoiceNoValidated = true;
            var isValidate = ValidateOnlyNumber(evt);
            if (!isValidate) {
                _IsInvoiceNoValidated = false;
            }

            return _IsInvoiceNoValidated;
        }
        function InvoiceAmountKeyPress(event) {
            debugger;
            if (event.which < 46|| event.which > 59) {
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

        $(".date").datepicker({
            onSelect: function () {
                SetSearch(event);
            }
        });

       
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hdnTotalRows" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
    <asp:HiddenField runat="server" ID="hdnRow" />
    <asp:HiddenField runat="server" ID="hdnPageNumber" />
    <asp:HiddenField runat="server" ID="hdnEraMasterId" />
    <asp:HiddenField runat="server" ID="hdnTotalCollection" />
    <div class="page-content">
        <div class="Widget">
            <div class="WidgetTitle invoices-title">
                <span class="widget-claims-icon"></span>Client Invoices
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
                                            <th style="width: 10%; text-align: center;" onclick="sort(this)">Invoice  No
                                            </th>
                                            <th style="width: 13%;" onclick="sort(this)">Statement Period
                                            </th>
                                            <th style="width: 10%; text-align: center;" onclick="sort(this)">Invoice Due Date
                                            </th>
                                            <th style="width: 10%; text-align: center;" onclick="sort(this)">Bill Date
                                            </th>
                                            <th style="width: 10%; text-align: center;" onclick="sort(this)">Total Charges
                                            </th>
                                            <th style="width: 10%; text-align: center;" onclick="sort(this)">Status
                                            </th>
                                            <%--<th style="width: 8%; text-align: left;" onclick="sort(this)">Pay Through(Under Construction)
                                            </th>--%>
                                            <th style="width: 5%; text-align: center;">Action</th>
                                        </tr>
                                        <tr>
                                            <th>
                                                <i class="fa fa-filter" style="color: #065172; font-size: 20px !important;" id="FilterIcon" onclick="FilterERA(0, true)"></i>
                                            </th>
                                            <th>
                                                <input type="text" id="txtInvoiceNumber" onkeypress="return InvoiceNoKeyPress(event);" onkeyup="SetSearch(event)"/></th>
                                            <th>
                                                <input type="text" id="txtStatementPeriod" class="date" onchange="FilterERA(0, true);"/></th>
                                            <th>
                                                <input type="text" id="txtInvoiceDueDate" class="date" onchange="FilterERA(0, true);"/></th>
                                            <th>
                                                <input type="text" id="txtBillDate" class="date" onchange="FilterERA(0, true);"/></th>
                                            <th>
                                                <input type="text" id="txtAmount" class="date" onkeyup="SetSearch(event)" onkeypress="return InvoiceAmountKeyPress(event);"/></th>
                                            <th> 
                                                <asp:DropDownList ID="ddlStatus" runat="server" onchange="FilterERA(0, true)">
                                                            <asp:ListItem Value="" Text="" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="Unpaid"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Paid"></asp:ListItem>
                                                        </asp:DropDownList>
                                            </th>
                                            <th></th>
                                            <%--<th></th>--%>
                                        </tr>
                                    </thead>
                                    <tbody id="tbClientInvoices">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="DataRow">
                                <td style="text-align:center">
                                    <input type="hidden" class="hdnClientinvoiceId" value='<%# Eval("ClientinvoiceId")%>' />
                                    <%--<input type="hidden" class="hdnCheckNumber" value='<%# Eval("CheckNumber")%>' />--%>
                                    <i>
                                        <%# Eval("RowNumber") %></i>
                                </td>
                                <td id="<%# Eval("InvoiceNumber") %>">
                                    <%# Eval("InvoiceNumber") %>
                                </td>
                                <td style="text-align:center">
                                    <%# Eval("StatementFrom", "{0:d}") %> - <%# Eval("StatementTo", "{0:d}") %>
                                </td>
                                <td style="text-align:center">
                                    <%# Eval("InvoiceDueDate", "{0:d}") %>
                                </td>
                                <td style="text-align:center">
                                    <%# Eval("BillDate", "{0:d}") %>
                                </td>
                                <td style="text-align:right">
                                    <%# Eval("TotalCharges","{0:c}") %>
                                </td>
                                <td> <%# Eval("PayStatus") %>
                                </td>
                             <%--   <td>
                                    <img src="../../Images/MasterCard.png" style="width: 20%;" />
                                    <img src="../../Images/Visa.png" style="width: 20%;"  />
                                    <img src="../../Images/AmericanExpress.png" style="width: 20%;"  />
                                    <img src="../../Images/Discover.png" style="width: 20%;"  />
                                </td>--%>
                                <td style="text-align:center;">
                                    <a class="payment-link" href="#" title="View" onclick="GetClientInvoiceDetail(this);" ><img src="../../Images/viewEye.png" /></a>
                                    <a class="payment-link" href="#" title="Make Payment" onclick="GetClientInvoiceDetail_Payment(this);"><img src="../../Images/payment.png" /></a>
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
    <div id="divItemCriteria" style="width: 90% !important; display: none;">
    </div>
    <div id="divItemPdf" style="display: none;">
    </div>
    <div id="divDivPayThrough" style="display: none;">
        <h1>Under Construction</h1>
    </div>
</asp:Content>
