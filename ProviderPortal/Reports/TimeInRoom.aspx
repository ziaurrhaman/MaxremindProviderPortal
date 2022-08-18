<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="TimeInRoom.aspx.cs" Inherits="ProviderPortal_Reports_TimeInRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
        <div class="Widget" style="margin-top: 10px;">
        <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Practice Room Average Waiting Time</span>
        </div>
        <div class="WidgetContent">
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="pagingReportDiv">
                    <div class="pagerReport">
                        <div class="PageEntries">
                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                <select id="ddlPagingTherapyTask" style="margin-top: 5px;" onchange="RowsChange('getTherapyTask');">
                                    <option value="10">10</option>
                                    <option value="25">25</option>
                                    <option value="50">50</option>
                                    <option value="75">75</option>
                                    <option value="100">100</option>
                                </select>
                            </span><span style="float: left;">&nbsp;entries</span>
                        </div>
                        <div class="PageButtonsReports">
                            <ul style="float: right; margin-right: 15px;">
                            </ul>
                        </div>
                        <div class="report-tools">
                            <table>
                                <tr>
                                    <td>
                                        <div class="report-export-wrapper">
                                            <asp:DropDownList ID="ddlExportTo" runat="server" CssClass="custom-export-drop-down"
                                                OnSelectedIndexChanged="ddlExportTo_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                            </asp:DropDownList>
                                            <a href="javascript:void(0)" class="custom-export-icon">
                                                <img src="../../Images/exportIconLeft.gif" style="border-style: None; height: 16px;
                                                    width: 16px;">
                                                <span style="width: 5px; text-decoration: none;"></span>
                                                <img src="../../Images/exportIconRight.gif" style="border-style: None; height: 6px;
                                                    width: 7px; margin-bottom: 5px;">
                                            </a>
                                        </div>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="printReport('TherapyTaskContainer');">
                                            <img src="../../Images/print.png" /></a>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" class="report-tool-icon" onclick="getTherapyTask(0,true);">
                                            <img src="../../Images/ReportRefresh.gif" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>                        
                    </div>
                </div>
                <div class="WidgetReportContent">
                    <div style="width: 100%; float: left;">
                        <div id="TherapyTaskContainer">
                            <asp:Repeater ID="rptTherapyTask" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th id="RowNumber" class="asc" onclick="filterTherapyTask(this,'PatientId');">
                                                        <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th id="PatientId" class="asc" onclick="filterTherapyTask(this,'PatientId');">
                                                        <span class="report-column-title">Room No</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th id="PatientName" onclick="filterTherapyTask(this,'PatientName');">
                                                        <span class="report-column-title">Room Name</span> <span></span>
                                                    </th>
                                                      <th id="BranchName" onclick="filterTherapyTask(this,'BranchName');">
                                                        <span class="report-column-title">Room Type</span> <span></span>
                                                    </th>                                                    
                                                      <th id="EpisodeId" onclick="filterTherapyTask(this,'EpisodeId');">
                                                        <span class="report-column-title">Location</span> <span></span>
                                                    </th>
                                                   <th id="EpisodeDate" onclick="filterTherapyTask(this,'EpisodeDate');">
                                                        <span class="report-column-title">Average Waiting Time (Minutes)</span><span></span>
                                                    </th>
                                                    <th id="TaskName" onclick="filterTherapyTask(this,'TaskName');">
                                                        <span class="report-column-title">Patients Served</span><span></span>
                                                    </th>
                                                                                                        
                                                </tr>
                                            </thead>
                                            <tbody id="TherapyTaskList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr >
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("RoomNo")%>
                                        </td>
                                        <td>
                                            <%# Eval("RoomName")%>
                                        </td>
                                        <td>
                                            <%# Eval("RoomType")%>
                                        </td>
                                       <td>
                                            <%# Eval("PracticeLocation")%>
                                        </td>   
                                         <td>
                                            <%# Eval("AverageWaitingTime")%>
                                        </td>   
                                        <td>
                                            <%# Eval("PatientsServed")%>
                                        </td>                                      
                                                                   
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody></table> </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <asp:HiddenField ID="inpHide" runat="server" />
    <input type="hidden" id="hdnTotalRowsTherapyTask" runat="server" value="0"/>
    
    <script type="text/javascript">
        var _sortByTherapyTask = 'Patient Id';
        var _sortValueTherapyTask = 'asc';

        $(document).ready(function () {
            SetHtml('TherapyTaskContainer', 'ReportGrid', 'inpHide');
            GenerateReportPaging($("[id$='hdnTotalRowsTherapyTask']").val(), $("#ddlPagingTherapyTask").val(), "pagingReportDiv", "getTherapyTask");
            $(".report-list-container").find("#therapyTaskSequence").addClass("report-active");
        });
        function filterTherapyTask(elem, sortBy) {
            _sortByTherapyTask = sortBy;
            var filterValue = $(elem).attr("class");
            if (filterValue == "asc" || filterValue == "") {
                filterValue = "desc";
                $(elem).find("span").removeClass("asc").addClass("desc");
            } else {
                filterValue = "asc";
                $(elem).find("span").removeClass("desc").addClass("asc");
            }
            _sortValueTherapyTask = filterValue;
            getTherapyTask(0, true);
        }
        function getTherapyTask(pageNumber, paging) {
            var sortBy = _sortByTherapyTask + " " + _sortValueTherapyTask;
            $.post("CallBacks/FilterTherapyTaskSequency.aspx", { Rows: $("#ddlPagingTherapyTask").val(), PageNumber: pageNumber, SortBy: sortBy },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("#StartFilter#") + 13;
                var end = data.indexOf("#EndFilter#");
                $("#TherapyTaskContainer").html(returnHtml.substring(start, end));


                var trId = _sortByTherapyTask;
                $("#TherapyTaskContainer thead").find("th[id$='" + trId + "'] span:last").addClass("filterIcon " + _sortValueTherapyTask);
                $("#TherapyTaskContainer thead").find("th[id$='" + trId + "']").addClass(_sortValueTherapyTask);

                SetHtml('TherapyTaskContainer', 'ReportGrid', 'inpHide');

                if (paging == true) {
                    GenerateReportPaging($("[id$='hdnTotalRowsTherapyTask']").val(), $("#ddlPagingTherapyTask").val(), "pagingReportDiv", "getTherapyTask");
                }

            });
        }
        function printReport(divToPrint) {
            var headstr = "<html><head><title></title></head><body>";
            var footstr = "</body></html>";
            var newstr = $("[id$='" + divToPrint + "']").html();

            var popupWin = window.open('', '_blank');
            popupWin.document.write(headstr + newstr + footstr);
            popupWin.print();
            return false;
        }

    </script>

</asp:Content>

