<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="ReportsMasterPage.aspx.cs" Inherits="BillingManager_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" type="text/javascript"></script>
    <script src="js/MainReport.js" type="text/javascript"></script>
    <script src="js/SummaryReports.js" type="text/javascript"></script>
    <script src="js/ReportDropdownSearch.js" type="text/javascript"></script>
    <link href="style/MainReportStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.0.272/jspdf.debug.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.js" type="text/javascript"></script>
    <script src="js/FilterReports.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.12/css/all.css" type="text/css" />
    <script src="js/CustomizeFiltersModal.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>

        <div class="div_leftReportList" style="height: 488px; overflow-y: scroll;">
            <span id="ReportsTag">REPORTS</span>
            <table>
                <thead>
                </thead>
                <tbody id="reportdropdown">
                    <asp:Repeater runat="server" ID="rptReportMenu" OnItemDataBound="Unnamed_ItemDataBound">

                        <ItemTemplate>

                            <tr>
                                <td runat="server" id="Categorytd" style="display: none">
                                    <asp:Label class="ReportsCategoryHeader" runat="server" ID="lblCategory" onclick="hideShowDiv(this)" />
                                    <span class="rptNavDropIcon" style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class='fas fa-angle-down'></i></span>

                                </td>


                            </tr>

                            <tr id="trsubRow" runat="server" class="ReportName" style="width: 100%; display: none">

                                <td class="nametd">

                                    <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">></span>
                                    <asp:Label runat="server" CssClass="lblReportName" ID="lblname" onclick="loadReport(this)" Style="cursor: pointer; border: none !important" />
                                    <span>
                                        <asp:Label runat="server" CssClass="lblReportName" ID="lblbeta" Style="color: red !important; margin-top: 2px; cursor: none !important" /></span>
                                    <div style="display: none">
                                        <asp:Label ID="lblReportfileName" class="lblReportfileName" runat="server" />
                                        <asp:Label ID="lblReportFilterName" class="lblReportFilterName" runat="server" />
                                    </div>
                                    <asp:Label ID="hdnReportType" class="ReportType" runat="server" Style="display: none" />

                                </td>

                            </tr>



                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <%--<!--section for report having collection--!>--%>
        <asp:HiddenField runat="server" ID="script"></asp:HiddenField>

        <div class="ReportTiles">
        </div>
        <div class="div_RightReportShow">

            <div id="Maindiv">
                <div class="Report_Header" style="display: none;">

                    <%-- <div class="Reports_Rows_Per_Page">
                        <span style="float: left; margin-left: 5px; font-size: 12px; font-weight: 600; padding-top: 7px; box-sizing: border-box;">Show&nbsp;</span>
                        <span style="float: left; padding-top: 2px; margin-left: 7px; margin-right: 5px;">
                            <select id="ddlPaging" onchange="RowsChange(0);" onclick="CheckifALLClick()">
                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>

                            </select>
                        </span><span style="float: left; padding-top: 7px; box-sizing: border-box;">&nbsp;Entries</span>
                    </div>--%>

                    <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute; display: none" onclick="PrintReoprt('PDF')">
                        <img src="../../Images/PrintView1.png" alt="img" /></span>
                    <div id="ReportFilterId">
                        <%--<span onclick="openReportFilterDialogue()" id="DialogueFilter" class="DialogueFilter removed" title="Report Filter"><span><img src="../../Images/filter-icon-report.png" style="width:20px;height:20px" /></span> </span>--%>
                        <span onclick="ShowHideMenu(this)" id="Embeded_Filter" class="Embeded_Filter Hide" title="Report Filter"><span>
                            <img src="../../Images/filter-icon-report.png" style="width: 20px; height: 20px" /></span> </span>
                    </div>
                </div>


                <%--  <div class="Report_Body">
               
        </div>--%>
                <div class="Report_Body">
                    <div class="Sub_Report_Body1 common_Report" id="id_Sub_Report_Body1" style="display: none"></div>
                    <div class="Sub_Report_Body2 common_Report" id="id_Sub_Report_Body2" style="display: none"></div>
                    <div class="Sub_Report_Body3 common_Report" id="id_Sub_Report_Body3" style="display: none"></div>
                    <div class="Sub_Report_Body4 common_Report" id="id_Sub_Report_Body4" style="display: none"></div>
                    <div class="Sub_Report_Body5 common_Report" id="id_Sub_Report_Body5" style="display: none"></div>
                    <div class="InitialMsg" style="display: none"><span style="font-style: italic; font-size: 16px">Please Select Report From Report Menu!</span></div>
                    <div class="SelectFilterMessage" style="display: none"><span style="font-style: italic; font-size: 16px">Please Select Patient to display a report!</span></div>
                    <label class="message"></label>
                </div>
                <div class="Report_Footer rpt_footer">
                    <div class="Pagination_div rpt_pagination message_box">
                        <span class="iconInfo" style="margin: 4px;"></span>
                        <label class="totalRows" style="float: left; padding-left: 10px; padding-top: 4px;"></label>
                    </div>
                    <div class="Reports_Rows_Per_Page" style="margin-top: 2px; float: left;">
                        <span style="float: left; margin-left: 5px; font-size: 12px; font-weight: 600; padding-top: 7px; box-sizing: border-box;">Show&nbsp;</span>
                        <span style="float: left; padding-top: 2px; margin-left: 7px; margin-right: 5px;">
                            <select id="ddlPaging" onchange="RowsChange(0);" onclick="CheckifALLClick()">
                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                                <option value="1000000">All</option>

                            </select>
                        </span><span style="float: left; padding-top: 7px; box-sizing: border-box;">&nbsp;Entries</span>
                    </div>
                    <div class="Pagination_div rpt_pagination">

                        <%--<label class="totalRows" style="float: left; padding-left:10px;padding-top:7px;"></label>--%>

                        <div class="PageButton">
                            <span class="Report_Footer_child btn_report" onclick="LastPage()" title="Last"><i onclick="LastPage()" class="fas fa-angle-right"></i></span>
                            <%-- <input class="Report_Footer_child btn_report" type="button" value="Last" onclick="LastPage()" />--%>
                            <span class="Report_Footer_child" id="Next" onclick="NextPage()"><i id="filtersubmitright" class="fas fa-angle-double-right"></i></span>

                            <label class="lblTotalPages" id="TotalPages"></label>
                            <label class="rpt-of-pagination">of</label>
                            <input class="txt_page_Number" type="text" value="1" onkeyup="PageNumOnTxt()" />
                            <span class="Report_Footer_child" onclick="PreviousPage()"><i id="filtersubmitleft" class="fas fa-angle-double-left"></i></span>

                            <%-- NextPage("divReportPaging"); --%>
                            <%-- <input class="Report_Footer_child btn_report" type="button" onclick="FirstPage()" value="First" />--%>
                            <span class="Report_Footer_child btn_report" onclick="FirstPage()" title="First" style="margin-top: -5px;"><i onclick="FirstPage()" class="fas fa-angle-left"></i></span>
                        </div>
                    </div>

                </div>
                <div class="clear"></div>
                <div class="report-export" style="padding: 3px 0; background: #f7f7f7; margin-top: -4px; border-radius: 0px 0px 5px 5px; border: 1px solid #b7b4b4;">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box; display: none;">Export To: &nbsp;</span>

                   <%-- <span style="float: left; padding-top: 2px; margin-left: 7px; display: block;">
                        <select id="ddlExportTo" class="custom-export-drop-down" onchange="ExportReport();">
                            <option></option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>

                    </span>--%>
                     <div class="export-icons" id="ddlExportTo">




                        <span style="float: left; margin-left: 5px; box-sizing: border-box; font-weight: bold;">Export To: &nbsp;</span>
                        <span class="report-excel" title="Excel" onclick="ExportReport('Excel');"><i class="fa fa-file-excel-o" aria-hidden="true"></i><span>Excel</span></span>
                        <span class="report-pdf" title="PDF" onclick="ExportReport('PDF');"><i class="fa fa-file-pdf-o" aria-hidden="true"></i><span>PDF</span></span>
                        <span class="report-word" title="Word" onclick="ExportReport('Word');"><i class="fa fa-file-word-o" aria-hidden="true"></i><span>Word</span></span>
                        <span class="report-print" title="Print" onclick="ExportReport('Print');"><i class="fa fa-print" aria-hidden="true"></i><span>Print</span></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divDialogReportFilters" style="display: none;"></div>
    <div id="divDialogReportFilters_Unique" style="display: none" />
    <div class="DivForPrintExcel" style="display: none"></div>


    <script type="text/javascript">
        $(document).ready(function () {
            debugger;

            if (!checkModuleRights("ReportsView")) {

                $("[id$='divRightsSettings']").html(_msg_ReportsView).show();
                $("#ContentMaindiv").hide();
                return false;
            }


            $("#ReportFilterId").hide();
            $(".report-export, .Reports_Rows_Per_Page, .PageButton").hide();
            $("#_reports").addClass("active");
            $("#reportdropdown").prepend($("[id$='script']").val())
        });
    </script>
    <script type="text/javascript">
        $("#ReportsTag").click(function () {
            if ($('#reportdropdown:visible').length)
                $('#reportdropdown').hide(1000);
            else
                $('#reportdropdown').show(1000);
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.lblReportName').hover(function (event) {
                var titleText = $(this).attr('title');
                $(this)
                    .data('tipText', titleText)
                    .removeAttr('title');

                $('<p class="tooltip"></p>')
                    .text(titleText)
                    .appendTo('body')
                    .css('top', (event.pageY - 5) + 'px')
                    .css('left', (event.pageX + 20) + 'px')
                    .fadeIn('slow');
            }, function () {
                $(this).attr('title', $(this).data('tipText'));
                $('.tooltip').remove();

            }).mousemove(function (event) {
                $('.tooltip')
                    .css('top', (event.pageY - 5) + 'px')
                    .css('left', (event.pageX + 20) + 'px');
            });
        });
    </script>
</asp:Content>

