<%@ page title="" language="C#" masterpagefile="~/ProviderPortal/BillingMaster.master" autoeventwireup="true" codefile="Payments.aspx.cs" inherits="BillingManager_Payment_Payments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hdnTotalRowsClaimList" />
    <asp:HiddenField runat="server" ID="hdnTotalRows" />

    <style type="text/css">
        body {
            overflow: visible !important;
        }

        .box {
            margin-bottom: 20px;
            text-align: right;
            width: 24%;
            float: left;
            margin-right: 1%;
            min-height: 150px;
        }

            .box .amount {
                font-size: 30px;
                font-family: Calibri;
                font-weight: bold;
                color: #FFF;
                display: block;
                margin: 40px 30px 0;
            }

            .box .label {
                font-size: 24px;
                font-family: Calibri;
                font-weight: bold;
                color: #FFF;
                margin: 5px 30px 0;
            }


        .claimwidget {
            float: left;
            width: 32%;
            margin-right: 1%;
            border: 1px solid #d9dada;
        }

            .claimwidget .header {
                background-color: #3c78b5;
                color: #FFF;
                padding: 10px;
                font-size: 14px;
            }

            .claimwidget .content {
                background-color: #FFF;
                min-height: 250px;
            }

        .searchbox {
            width: 24%;
            float: left;
            margin-right: 1%;
            clear: left;
            margin-bottom: 25px;
            height: 300px;
            background-color: #e9eaea;
        }

            .searchbox .title {
                background-color: #439AC7;
                padding: 10px;
                font-weight: bold;
                color: white;
                font-size: 14px;
            }

            .searchbox .content {
                padding: 10px;
                line-height: 35px;
                font-weight: bold;
            }

        .ui-dialog {
            /*top: 611px !important;*/
        }


        .amount {
            line-height: 30px;
            font-weight: 600;
            width: 100%;
            text-align: right;
        }

        .amount_label {
            float: right;
        }

        .columnchart {
            width: 85%;
            float: left;
            height: 210px;
            padding-left: 150px;
            box-sizing: border-box;
        }

        .btn_filter {
            background-color: #439abf !important;
            color: white !important;
            border-bottom: none !important;
            background-image: none !important;
        }

        .Payment_box {
            border-radius: 5px;
            width: 100%;
            background-color: white;
            height: 100px;
            border: 1px solid #ccc;
            box-shadow: 0px 0px 2px 0 rgba(0,0,0,.125);
        }

        .div_payment_box {
            width: 25%;
            float: left;
            padding-right: 10px;
            padding-left: 10px;
            box-sizing: border-box;
        }

        .div_pie_charts {
            width: 33.33%;
            float: left;
            padding-right: 10px;
            padding-left: 10px;
            box-sizing: border-box;
        }

        .Pr_0 {
            padding-right: 0px !important;
        }

        .Pl_0 {
            padding-left: 0px !important;
        }

        .Pt_0 {
            padding-top: 0px !important;
        }

        .Pb_0 {
            padding-bottom: 0px !important;
        }

        .P10 {
            padding: 10px;
            box-sizing: border-box;
        }

        .P20 {
            padding: 20px;
            box-sizing: border-box;
        }

        .margin_R10 {
            margin-right: 10px;
        }

        .margin_L10 {
            margin-left: 5px;
        }

        .chart {
            border: 3px solid yellow;
            width: 100% !important;
        }

        .chart-wrapper {
            border: 3px solid orangered;
            width: 100% !important;
        }

        #divAgingReport {
            min-height: 250px;
            padding-top: 15px;
            box-sizing: border-box;
        }

        #divClaimDistribution {
            min-height: 250px;
        }

        #divClaimSubmission {
            min-height: 250px;
        }

        .highcharts-root {
            margin-top: -40px !important;
        }

        #divClaimDistribution .highcharts-root {
            margin-top: -10px !important;
        }

        .container {
            overflow-y: hidden !important;
            max-height: none !important;
        }

        .grid-overflow-x {
            /* height: 350px;*/
            overflow-y: auto;
        }

        .align-center {
            display: flex;
            justify-content: center;
            width: 100%;
        }

        .error-fonts {
            color: red;
            font-weight: bold;
            font-style: italic;
            font-size: 14px;
        }

        .hide {
            display: none;
        }
    </style>
    <script>
        //$(document).ready(function (e) {

        //    if (!checkModuleRights('PaymentView')) {
        //        $('#errordiv').show();
        //        $('#paymentwrapper').hide();
        //    }
        //})
    </script>
    <div runat="server" id="errordiv" class="align-center hide">
        <span class="error-fonts">You don't have rights to View Payment Information</span>
    </div>
    <div runat="server" id="paymentwrapper">
        <div id="cover">
            <div class="widget" style="width: 100%; background-color: white; /*height: 125px*/">
                <div class="widgettitle payment-search-filter" style="float: left">
                    Search Criteria
                
                    <div class="payment-search-right pull-right">
                        <span style="">Check Amount:
                    <asp:Label runat="server" ID="lblchkamount"></asp:Label>
                        </span>

                        <span style="">Post Amount:
                        <asp:Label runat="server" ID="lblPostamount"></asp:Label>
                        </span>
                        <input type="button" value="Payment Summary" class="PaymentSummary" style="float: right; font-size: 12px; margin-right: 15px; font-weight: bold; text-decoration: none; background: #006291; color: white; padding: 2px 5px; line-height: 19px; margin-top: 2px; border: 1px solid #439abf;" onclick="PaymentSummary();" />

                    </div>




                    <div id="divLast90Days" style="float: right; width: 25%; text-align: right; padding-right: 10px; box-sizing: border-box;">
                        <%--<h3>--%><asp:Label runat="server" ID="Label"></asp:Label>
                        <span id="spndate" runat="server"></span>
                    </div>
                </div>
                <div class="widgetcontent dashboard-search" id="divwidgetcontent">
                    <div style="float: left; width: 100%;">
                        <div id="div_Table" style="width: 100%; float: left">
                            <%-- <div id="div_checkboxis" style="padding: 10px 0px 10px 10px; box-sizing: border-box;">
                            

                               

                            <span class="margin_R10">

                                <asp:CheckBox runat="server" ID="chkMonthToDate" Text="Month to Date" onclick="CheckBoxClick(this);" /></span>
                           
                                <span class="margin_R10"><asp:CheckBox runat="server" ID="chkLastMonth" Text="Last Month" onclick="CheckBoxClick(this);" /></span>
                            <span class="margin_R10">
                                <asp:CheckBox runat="server" ID="chkYearToDate" Text="Year to Date" onclick="CheckBoxClick(this);" /></span>
                            <span class="margin_R10">
                                <asp:CheckBox runat="server" ID="chkSelectDate" Text="Select Dates" onclick="CheckBoxClick(this);" /></span>
                               
                         
                        </div>--%>
                            <div id="div_TxtDDl" style="padding: 10px; box-sizing: border-box; position: relative;">
                                <div class="row filter-row">
                                    <div class="col-auto outer-col">
                                        <asp:DropDownList runat="server" ID="ddldate" CssClass="" Style="width: 100%;">
                                            <asp:ListItem Value="last3month" Text="Last 90 Days"></asp:ListItem>
                                            <asp:ListItem Value="selectdate" Text="Select Dates"></asp:ListItem>
                                            <asp:ListItem Value="MonthToDate" Text="Month to Date"></asp:ListItem>
                                            <asp:ListItem Value="LastMonth" Text="Last Month"></asp:ListItem>
                                            <asp:ListItem Value="YearToDate" Text="Year to Date"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-auto outer-col">
                                        <div class="row">
                                            <div class="col-auto">
                                                From:
                                            </div>
                                            <div class="col-auto">
                                                <asp:TextBox runat="server" ID="txtFromDate" CssClass="datepicker" Enabled="false" Style="width: 100%;"></asp:TextBox>

                                            </div>
                                        </div>




                                    </div>
                                    <div class="col-auto outer-col">
                                        <div class="row">
                                            <div class="col-auto">
                                                To: 
                                            </div>
                                            <div class="col-auto">
                                                <asp:TextBox runat="server" ID="txtToDate" CssClass="datepicker" Enabled="false" Style="width: 100%;"></asp:TextBox>

                                            </div>
                                        </div>





                                    </div>

                                    <div class="col-auto outer-col">

                                        <div class="row">
                                            <div class="col-auto">
                                                Insurance:
                                            </div>
                                            <div class="col-auto">
                                                <asp:DropDownList runat="server" ID="ddlinsurance" AppendDataBoundItems="true" CssClass="" Style="width: 100%;">
                                                    <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-auto outer-col">


                                        <div class="row">
                                            <div class="col-auto">
                                                Billing Provider:
                                            </div>
                                            <div class="col-auto">
                                                <asp:DropDownList runat="server" ID="ddlBillingProvider" AppendDataBoundItems="true" CssClass="" Style="width: 100%;">
                                                    <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-auto">
                                        <span class="filter-checkbox">



                                            <span class="">
                                                <asp:RadioButton runat="server" ID="PostRb" GroupName="radio" Checked="true" />Post Date</span>
                                            <asp:RadioButton runat="server" ID="DOSRb" GroupName="radio" />DOS
                                        </span>



                                    </div>
                                    <div class="col-auto">
                                        <input type="button" value="Filter" style="min-width: 50px !important" class="btn_filter " onclick="FilterResult();" />

                                    </div>
                                    <div class="col-auto file-convert-btn">
                                        <select id="ddlPS" class="custom-export-drop-down" onchange="ExportReportPayments('Payments Detail',this,'printableAreaPS');" style="">
                                            <option>Export</option>
                                            <option value="Excel">Excel</option>
                                            <option value="PDF">PDF</option>
                                            <option value="Word">Word</option>
                                        </select>
                                    </div>

                                </div>




                            </div>
                        </div>

                    </div>

                </div>

            </div>



        </div>


        <%-- Payment Summary Dialog div --%>
        <div id="PaymentSummarydiv">
        </div>

        <div id="MessagePopUp">
        </div>

        <div id="divClaimCheckParent">
            <div class="Grid">
                <div class="grid-overflow-x" id="printableAreaPS">
                    <asp:Repeater ID="rptClaimCheck" runat="server" OnItemDataBound="rptClaimCheck_ItemDataBound">
                        <HeaderTemplate>
                            <table id="container">
                                <thead>
                                    <tr id="Maintr">
                                        <th style="width: 2%;">#</th>

                                        <th id="CheckNumber" style="width: 10%; cursor: pointer;" class="desc sortable-header" onclick="FilterSorting(this,'CheckNumber');">Check No<span class="fa fa-sort-desc" style="margin-left: 5px"></span>
                                        </th>
                                        <th id="CheckIssueDate" style="width: 10%; cursor: pointer;" class="desc sortable-header" onclick="FilterSorting(this,'CheckIssueDate');">Check Date<span class="fa fa-sort-desc" style="margin-left: 5px"></span>
                                        </th>
                                        <th id="CheckAmount" style="width: 10%; cursor: pointer" class="desc sortable-header" onclick="FilterSorting(this,'CheckAmount');">Check Amount<span class="fa fa-sort-desc" style="margin-left: 5px"></span>
                                        </th>
                                        <th id="CheckPostDate" style="width: 10%; cursor: pointer" class="desc sortable-header" onclick="FilterSorting(this,'CheckPostDate');">Post Date<span class="fa fa-sort-desc" style="margin-left: 5px"></span>
                                        </th>
                                        <th id="CheckPostAmount" style="width: 10%; cursor: pointer" class="desc sortable-header" onclick="FilterSorting(this,'CheckPostDate');">Post Amount<span class="fa fa-sort-desc" style="margin-left: 5px"></span>
                                        </th>

                                        <th id="Insurance" style="cursor: pointer" class="desc sortable-header" onclick="FilterSorting(this,'Insurance');">Insurance<span class="fa fa-sort-desc" style="margin-left: 5px;"></span>
                                        </th>
                                        <th runat="server" id="thVerify" style="width: 10%;">Verify                                        

                                        </th>
                                        <th style="width: 10%;">Action
                                        </th>

                                    </tr>

                                    <tr id="printtr" style="display: none">
                                        <th>#</th>

                                        <th>Check No
                                        </th>
                                        <th>Check Date
                                        </th>
                                        <th>Check Amount
                                        </th>
                                        <th>Post Date
                                        </th>
                                        <th>Post Amount
                                        </th>

                                        <th>Insurance
                                        </th>
                                        <th></th>


                                    </tr>

                                    <tr class="Search">
                                        <th>
                                            <span class="iconSearch" onclick="FilterClaimChecks(0,true)"></span>
                                        </th>
                                        <%--<th></th>--%>
                                        <th>
                                            <input type="text" onkeyup="FilterPaymentsOnEnter(event)" validate="" id="txtCheckNumber" />
                                        </th>
                                        <th>
                                            <input type="text" onkeyup="FilterPaymentsOnEnter(event)" id="txtCheckDate" />
                                        </th>


                                        <th>
                                            <input type="text" id="txtCheckAmount" />
                                        </th>
                                        <th>
                                            <input type="text" onkeyup="FilterPaymentsOnEnter(event)" id="txtPostDate" />
                                        </th>

                                        <th>
                                            <input type="text" id="txtPostedAmount" />
                                        </th>
                                        <th>
                                            <input onkeyup="FilterPaymentsOnEnter(event)" type="text" id="txtInsurance" /></th>

                                        <th>
                                            <select id="ddlVerified" onchange="FilterClaimChecks(0,true)">
                                                <option value="">All</option>
                                                <option value="true">Verified</option>
                                                <option value="false">UnVerified</option>

                                            </select>
                                        </th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody id="claimChecksList">
                        </HeaderTemplate>


                        <ItemTemplate>
                            <tr id="<%# Eval("ERAMasterId") %>" class="DataRow">
                                <td>
                                    <i>
                                        <%# Eval("RowNumber") %></i>
                                </td>
                                <%--<td align="center">
                                        <asp:CheckBox ID="cbClaimChecks" runat="server" CssClass="cbClaimChecks" onclick="change_ClaimCheck();" />
                                    </td>--%>
                                <td class="tdCheckNumber">
                                    <%# Eval("CheckNumber")%>
                                </td>
                                <td class="tdCheckDate DateCenter">
                                    <%# Eval("CheckDate", "{0:d}")%>
                                </td>
                                <td class="tdCheckAmount AmtRight">
                                    <%# Eval("CheckAmount", "{0:c}")%>
                                </td>
                                <td class="tdCheckDate DateCenter">
                                    <%# Eval("CreatedDate", "{0:d}")%>
                                </td>
                                <td class="tdCheckDate AmtRight">
                                    <%# Eval("PostedAmount", "{0:c}")%>
                                </td>



                                <td id="<%# Eval("InsuranceId") %>" class="tdInsurance">
                                    <%# Eval("Insurance")%>
                                </td>
                                <td style="text-align: center; cursor: pointer" class="hidetdclass" onclick="CheckVerifyPopup( <%# Eval("ERAMasterId") %>);" id="tdVerify">

                                    <asp:Label ID="lblVerify" runat="server" Style="">.</asp:Label>

                                </td>
                                <td style="text-align: center;" class="hidetdclass">
                                    <span class="fa fa-print" title="Print" onclick="PrintCheckInfo(this);"
                                        style="cursor: pointer; font-size: 16px; color: #006a99; margin-left: 7px; display: inline-block;"></span>
                                    <span class="spanview" style="display: none;" title="View" onclick="ViewCheckInfo(this);"></span>
                                    <span class="spanedit" title="Edit" onclick="EditClaimCheck(this);"></span>
                                    <span class="spandelete" title="Delete" onclick="DeleteClaimCheck(this);" style="margin-left: 5px;"></span>

                                    <input type="hidden" class="hdnClaimCheckId" value='<%# Eval("ERAMasterId")%>' />
                                    <input type="hidden" class="hdnInsuranceId" value='<%# Eval("InsuranceId")%>' />
                                    <input type="hidden" class="hdnCheckAmount" value='<%#DataBinder.Eval(Container.DataItem, "CheckAmount","{0:0.00}")%>' />
                                    <input type="hidden" class="hdnPostedAmount" value='<%#DataBinder.Eval(Container.DataItem, "PostedAmount","{0:0.00}")%>' />

                                    <input type="hidden" class="hdnPatientId" value="<%#Eval("PatientId") %>" />
                                    <input type="hidden" class="hdnPatient" value="<%#Eval("Patient") %>" />
                                    <%--<input type="hidden" class="hdnProcedurePaymentsId" value='<%# Eval("ProcedurePaymentsId")%>' />--%>
                                    <%-- Added by Rizwan kharal 3August2018 --%>
                                    <input type="hidden" class="hdnPaymentType" value='<%#Eval("PaymentType") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>

                    </asp:Repeater>
                    </tbody>
                </table>
                </div>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left; width: 80px">
                            <select id="ddlPagingClaimChecks" style="margin-top: 5px;" onchange="RowsChange('FilterClaimChecks');">
                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                            </select>
                        </span><span style="float: left;">&nbsp;entries</span>
                    </div>
                    <div class="PageButtons">
                        <ul style="float: right; margin-right: 15px;"></ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="ForPrintDiv"></div>
    </div>
    <style>
        .filterIcon {
            background-image: url(../../Images/filter-Icon.png);
            background-repeat: no-repeat;
            height: 6px;
            width: 11px;
            cursor: pointer;
            float: left;
            margin-left: 2px;
        }

        .container {
            /*padding: 4px 0px 0px 0px;*/
        }

        .asc {
            background-position: 0 0;
            margin-top: 7px;
        }

        .desc {
            background-position: 0 -5px;
            margin-top: 7px;
        }

        .warning {
            background: url("../../Images/warning.png") no-repeat scroll 10px center #FFD1D1;
            border: 1px solid #F8ACAC;
            border-radius: 5px;
            -moz-border-radius: 5px;
            -o-border-radius: 5px;
            -webkit-border-radius: 5px;
            color: #a94442;
            font-size: 12px;
            padding: 10px 10px 10px 33px;
        }

        .cross {
            background: url(../../Images/Cross.png) top no-repeat;
            text-indent: -9999px;
            display: block;
            width: 100%;
            height: 16px;
            -webkit-transition: all .3s;
            float: left;
            margin: 0px 2px 0px 2px;
        }

        .tick {
            background: url(../../Images/tick2.png) top no-repeat;
            text-indent: -9999px;
            display: block;
            width: 100%;
            height: 16px;
            -webkit-transition: all .3s;
            float: left;
            margin: 0px 2px 0px 2px;
        }

        .DateCenter {
            text-align: center;
        }

        .AmtRight {
            text-align: right;
        }

        /*.ui-dialog
{

width:25% !important;
top: 247.5px !important;
left: 460.5px !important;*/
        /*}*/
    </style>

    <script>

        $(document).ready(function () {

            $("[id$='txtFromDate']").datepicker({
                changeMonth: true,
                changeYear: true,

            }).mask("99/99/9999");

            $("[id$='txtToDate']").datepicker({
                changeMonth: true,
                changeYear: true,

            }).mask("99/99/9999");

            $("[id$='ddldate']").change(function () {

                debugger
                if ($("[id$='ddldate']").val() == "selectdate") {
                    $("[id$='txtFromDate']").prop("disabled", false);
                    $("[id$='txtFromDate']").css("background", "none")
                    $("[id$='txtToDate']").prop("disabled", false);
                    $("[id$='txtToDate']").css("background", "none")
                }
                else {
                    $("[id$='txtFromDate']").prop("disabled", true);
                    $("[id$='txtFromDate']").css("background", "#eaeaea");
                    $("[id$='txtToDate']").prop("disabled", true);
                    $("[id$='txtToDate']").css("background", "#eaeaea");
                    $("[id$='txtToDate']").val("");
                    $("[id$='txtFromDate']").val("");
                    $("[id$='txtFromDate']").css("border-color", "#c4c4c4");
                    $("[id$='txtToDate']").css("border-color", "#c4c4c4");
                }

            });
        });
        function PaymentSummary() {




            debugger;
            $.post(_ResolveUrl + "ProviderPortal/Payment/CallBacks/PaymentSummaryPrint.aspx", {}, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###StartERAClaims###") + 20;
                var end = data.indexOf("###EndERAClaims###");
                $("#PaymentSummarydiv").html(returnHtml.substring(start, end));

                $("#PaymentSummarydiv").dialog({
                    width: 960,
                    modal: true,
                    title: "Payment Summary",
                    open: function () {
                        //$(".ui-widget-overlay").last().css("z-index", "9999999");
                        //$(".ui-dialog").last().css("z-index", "99999999");
                    },
                    buttons: {
                        Print: function () {
                            debugger



                            printHtml("PaymentSummaryPrint");



                            $(this).dialog("destroy");
                            $("#PaymentSummarydiv").hide();
                            $("#divERAClaimsPrint").css("display", "none");
                        },
                        Close: function () {
                            $(this).dialog("destroy");
                            $("#PaymentSummarydiv").hide();
                            $("#divERAClaimsPrint").css("display", "none");
                        }
                    }
                });
            })
        }


        function PaymentSummarySearch() {
            $(".refresh-red").hide();
            $(".refresh-blue").show();
            var ddldatesoption = $("[id$=ddldates]").val();
            var startDate = null; var Enddate = null;
            startDate = $("[id$=StartDate]").val();
            Enddate = $("[id$=EndDate]").val();

            console.log(startDate + ' - ' + Enddate);
            if (startDate != "" && Enddate != "") {
                if (new Date(Enddate) <= new Date(startDate)) {
                    $("<div style='margin-top:8px'></div>").html("<span>To Date cannot be less then From Date.</span>").dialog({
                        width: 360,
                        modal: true,
                        title: "Information!",
                        buttons: {
                            Ok: function () {
                                $("[id$=StartDate]").val("");
                                $("[id$=EndDate]").val("");
                                $(this).dialog("destroy");
                            }
                        }
                    });
                    return
                }
            }
            if (ddldatesoption == "Select") {

                var mesg = "Please Select Date Type.";
                showErrorMessage(mesg);

            }
            else if (ddldatesoption == "SelectDates") {
                debugger
                if (startDate == "" || Enddate == "") {
                    var mesg = "Please Select Dates.";
                    showErrorMessage(mesg);
                }
                else {



                    $.post(_ResolveUrl + "ProviderPortal/Payment/CallBacks/PaymentSummaryPrintHandler.aspx", { ddldates: ddldatesoption, action: "action", startDate: startDate, Enddate: Enddate }, function (data) {
                        debugger;
                        $("summaryhide").hide();
                        var returnHtml = data;
                        var start = data.indexOf("###StartERAClaims###") + 20;
                        var end = data.indexOf("###EndERAClaims###");
                        $("#PaymentSummary").html(returnHtml.substring(start, end));

                    });
                }

            }
            else {

                $.post(_ResolveUrl + "ProviderPortal/Payment/CallBacks/PaymentSummaryPrintHandler.aspx", { ddldates: ddldatesoption, action: "action" }, function (data) {
                    $("summaryhide").hide();
                    var returnHtml = data;
                    var start = data.indexOf("###StartERAClaims###") + 20;
                    var end = data.indexOf("###EndERAClaims###");
                    $("#PaymentSummary").html(returnHtml.substring(start, end));
                });

            }
        }




    </script>

</asp:Content>

