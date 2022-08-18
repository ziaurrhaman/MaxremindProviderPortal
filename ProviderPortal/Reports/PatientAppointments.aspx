<%@ Page Title="Patient Appointments" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true"
    CodeFile="PatientAppointments.aspx.cs" Inherits="EMR_Reports_PatientAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            
            if (!checkModuleRights("ReportsView")) {
                showErrorMessage(_msg_ReportsView);
                return false;
            }
            SetHtml('ReportContainer', 'ReportGrid', 'inpHide');
            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "pagingReportDiv", "getPatientAppoinmentReport");
            putSelectedColumnsInArray("dialogReportAppointment");
            $(".txtAppointmentDate").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-110:+2"
            }).mask("99/99/9999");

        });

        function changeLocationAppointments(elem) {
            var PracticeLocationsId = $(elem).val();

            var providers = $.grep(_arrProvidersByLocation, function (v, i) {
                if (PracticeLocationsId != 0) {
                    return (v.PracticeLocationsId == PracticeLocationsId);
                }
                else {
                    return _arrProvidersByLocation;
                }
            });

            var providerHtml = '<option value="0">All</option>';

            for (var i = 0; i < providers.length; i++) {
                providerHtml += '<option value="' + providers[i].PracticeStaffId + '">' + providers[i].Name + '</option>';
            }

            $("[id$='ddlProviders']").html(providerHtml);
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
       

        function getPatientAppoinmentReport(pageNumber, paging) {
            
            var LocationId = $.trim($("[id$='ddlLocations']").val());
            var ResourceId = $.trim($("[id$='ddlProviders']").val());
            var PatientId = $.trim($("#txtPatientId").val()) == "" ? 0 : $.trim($("#txtPatientId").val());
            var _PatientName = $.trim($("#txtPatientName").val());
            var _AppointmentDate = $.trim($("#txtAppointmentDate").val());
            var _StartTime = $.trim($("[id$='ddlStartTime']").val());
            var _EndTime = $.trim($("[id$='ddlEndTime']").val());
            var _StatusId = $.trim($("#ddlStatus").val());
            $.post(_ReportsPath + "/CallBacks/PatientAppointmentReportHandler.aspx", { LocationId: LocationId, ResourceId: ResourceId, PatientId: PatientId, PatientName: _PatientName, AppointmentDate: (isDate(_AppointmentDate) ? _AppointmentDate : ""), StartTime: _StartTime, EndTime: _EndTime, StatusId: _StatusId, Rows: $("#ddlPagingReport").val(), PageNumber: pageNumber },
                function (data) {
                    var returnHtml = data;
                    var start = data.indexOf("###Start###") + 11;
                    var end = data.indexOf("###End###");
                    $(".ReportGrid").html(returnHtml.substring(start, end));

                    var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
                    var endRowsCount = data.indexOf("###EndRowsCount###");
                    $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

                    if (_arrSelectedColumn.length != 0) {
                        hideColum('ReportGrid');
                    }
                    SetHtml('ReportContainer', 'ReportGrid', 'inpHide');

                    if (paging == true) {
                        GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "pagingReportDiv", "getPatientAppoinmentReport");
                        setPageNextAfterEnterPageNumber("pagingReportDiv", pageNumber);
                    }

                });
        }


        function PatientAppointmentsReportEdit() {
            

            $("#dialogReportAppointment").dialog({
                title: "Modify Report",
                modal: true,
                buttons: {
                    "Ok": function () {
                        getPatientAppoinmentReport(0, true, true);
                        putSelectedColumnsInArray("dialogReportAppointment");
                        $("#dialogReportAppointment").dialog("close");
                    },
                    "Cancel": function () {
                        CancelEditReport("dialogReportAppointment");
                        $("#dialogReportAppointment").dialog("close");
                    }
                },
                close: function () {
                    CancelEditReport("dialogReportAppointment");
                    $("#dialogReportAppointment").dialog("destroy");
                }
            });
        }

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<QL:QuickLaunchBar ID="QuickLaunchBar1" runat="server" />--%>
    <div id="divReports" runat="server">
    <div class="Widget" style="margin-top: 10px;">
        <div class="ReportHeader">
            <span id="spnTitle" style="font-size: 15px;">Patient Appointments Report</span>
        </div>
        <div class="ReportContents" style="padding-bottom:3%;">
        
            <asp:HiddenField ID="inpHide" runat="server" />
            <asp:HiddenField runat="server" ID="hdnTotalRows" />
            <fieldset>
                <legend>Search Criteria</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align:right">
                                Account No:
                            </td>
                            <td>
                                <input type="text" id="txtPatientId" validate="numeric" />
                            </td>
                            <td style="text-align:right">
                                Patient Name:
                            </td>
                            <td>
                                <input type="text" id="txtPatientName" />
                            </td>
                            <td style="text-align:right">
                              Appointment Date:
                            </td>
                            <td>
                                <input type="text" id="txtAppointmentDate" class="txtAppointmentDate" />
                            </td>
                            <td style="text-align:right">
                                Start Time:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStartTime" runat="server">
                                    <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="12:00AM">12:00 AM</asp:ListItem>
                                    <asp:ListItem Value="12:15AM">12:15 AM</asp:ListItem>
                                    <asp:ListItem Value="12:30AM">12:30 AM</asp:ListItem>
                                    <asp:ListItem Value="12:45AM">12:45 AM</asp:ListItem>
                                    <asp:ListItem Value="1:00AM">01:00 AM</asp:ListItem>
                                    <asp:ListItem Value="1:15AM">01:15 AM</asp:ListItem>
                                    <asp:ListItem Value="1:30AM">01:30 AM</asp:ListItem>
                                    <asp:ListItem Value="1:45AM">01:45 AM</asp:ListItem>
                                    <asp:ListItem Value="2:00AM">02:00 AM</asp:ListItem>
                                    <asp:ListItem Value="2:15AM">02:15 AM</asp:ListItem>
                                    <asp:ListItem Value="2:30AM">02:30 AM</asp:ListItem>
                                    <asp:ListItem Value="2:45AM">02:45 AM</asp:ListItem>
                                    <asp:ListItem Value="3:00AM">03:00 AM</asp:ListItem>
                                    <asp:ListItem Value="3:15AM">03:15 AM</asp:ListItem>
                                    <asp:ListItem Value="3:30AM">03:30 AM</asp:ListItem>
                                    <asp:ListItem Value="3:45AM">03:45 AM</asp:ListItem>
                                    <asp:ListItem Value="4:00AM">04:00 AM</asp:ListItem>
                                    <asp:ListItem Value="4:15AM">04:15 AM</asp:ListItem>
                                    <asp:ListItem Value="4:30AM">04:30 AM</asp:ListItem>
                                    <asp:ListItem Value="4:45AM">04:45 AM</asp:ListItem>
                                    <asp:ListItem Value="5:00AM">05:00 AM</asp:ListItem>
                                    <asp:ListItem Value="5:15AM">05:15 AM</asp:ListItem>
                                    <asp:ListItem Value="5:30AM">05:30 AM</asp:ListItem>
                                    <asp:ListItem Value="5:45AM">05:45 AM</asp:ListItem>
                                    <asp:ListItem Value="6:00AM">06:00 AM</asp:ListItem>
                                    <asp:ListItem Value="6:15AM">06:15 AM</asp:ListItem>
                                    <asp:ListItem Value="6:30AM">06:30 AM</asp:ListItem>
                                    <asp:ListItem Value="6:45AM">06:45 AM</asp:ListItem>
                                    <asp:ListItem Value="7:00AM">07:00 AM</asp:ListItem>
                                    <asp:ListItem Value="7:15AM">07:15 AM</asp:ListItem>
                                    <asp:ListItem Value="7:30AM">07:30 AM</asp:ListItem>
                                    <asp:ListItem Value="7:45AM">07:45 AM</asp:ListItem>
                                    <asp:ListItem Value="8:00AM">08:00 AM</asp:ListItem>
                                    <asp:ListItem Value="8:15AM">08:15 AM</asp:ListItem>
                                    <asp:ListItem Value="8:30AM">08:30 AM</asp:ListItem>
                                    <asp:ListItem Value="8:45AM">08:45 AM</asp:ListItem>
                                    <asp:ListItem Value="9:00AM">09:00 AM</asp:ListItem>
                                    <asp:ListItem Value="9:15AM">09:15 AM</asp:ListItem>
                                    <asp:ListItem Value="9:30AM">09:30 AM</asp:ListItem>
                                    <asp:ListItem Value="9:45AM">09:45 AM</asp:ListItem>
                                    <asp:ListItem Value="10:00AM">10:00 AM</asp:ListItem>
                                    <asp:ListItem Value="10:15AM">10:15 AM</asp:ListItem>
                                    <asp:ListItem Value="10:30AM">10:30 AM</asp:ListItem>
                                    <asp:ListItem Value="10:45AM">10:45 AM</asp:ListItem>
                                    <asp:ListItem Value="11:00AM">11:00 AM</asp:ListItem>
                                    <asp:ListItem Value="11:15AM">11:15 AM</asp:ListItem>
                                    <asp:ListItem Value="11:30AM">11:30 AM</asp:ListItem>
                                    <asp:ListItem Value="11:45AM">11:45 AM</asp:ListItem>
                                    <asp:ListItem Value="12:00PM">12:00 PM</asp:ListItem>
                                    <asp:ListItem Value="12:00PM">12:00 PM</asp:ListItem>
                                    <asp:ListItem Value="12:15PM">12:15 PM</asp:ListItem>
                                    <asp:ListItem Value="12:30PM">12:30 PM</asp:ListItem>
                                    <asp:ListItem Value="12:45PM">12:45 PM</asp:ListItem>
                                    <asp:ListItem Value="1:00PM">01:00 PM</asp:ListItem>
                                    <asp:ListItem Value="1:15PM">01:15 PM</asp:ListItem>
                                    <asp:ListItem Value="1:30PM">01:30 PM</asp:ListItem>
                                    <asp:ListItem Value="1:45PM">01:45 PM</asp:ListItem>
                                    <asp:ListItem Value="2:00PM">02:00 PM</asp:ListItem>
                                    <asp:ListItem Value="2:15PM">02:15 PM</asp:ListItem>
                                    <asp:ListItem Value="2:30PM">02:30 PM</asp:ListItem>
                                    <asp:ListItem Value="2:45PM">02:45 PM</asp:ListItem>
                                    <asp:ListItem Value="3:00PM">03:00 PM</asp:ListItem>
                                    <asp:ListItem Value="3:15PM">03:15 PM</asp:ListItem>
                                    <asp:ListItem Value="3:30PM">03:30 PM</asp:ListItem>
                                    <asp:ListItem Value="3:45PM">03:45 PM</asp:ListItem>
                                    <asp:ListItem Value="4:00PM">04:00 PM</asp:ListItem>
                                    <asp:ListItem Value="4:15PM">04:15 PM</asp:ListItem>
                                    <asp:ListItem Value="4:30PM">04:30 PM</asp:ListItem>
                                    <asp:ListItem Value="4:45PM">04:45 PM</asp:ListItem>
                                    <asp:ListItem Value="5:00PM">05:00 PM</asp:ListItem>
                                    <asp:ListItem Value="5:15PM">05:15 PM</asp:ListItem>
                                    <asp:ListItem Value="5:30PM">05:30 PM</asp:ListItem>
                                    <asp:ListItem Value="5:45PM">05:45 PM</asp:ListItem>
                                    <asp:ListItem Value="6:00PM">06:00 PM</asp:ListItem>
                                    <asp:ListItem Value="6:15PM">06:15 PM</asp:ListItem>
                                    <asp:ListItem Value="6:30PM">06:30 PM</asp:ListItem>
                                    <asp:ListItem Value="6:45PM">06:45 PM</asp:ListItem>
                                    <asp:ListItem Value="7:00PM">07:00 PM</asp:ListItem>
                                    <asp:ListItem Value="7:15PM">07:15 PM</asp:ListItem>
                                    <asp:ListItem Value="7:30PM">07:30 PM</asp:ListItem>
                                    <asp:ListItem Value="7:45PM">07:45 PM</asp:ListItem>
                                    <asp:ListItem Value="8:00PM">08:00 PM</asp:ListItem>
                                    <asp:ListItem Value="8:15PM">08:15 PM</asp:ListItem>
                                    <asp:ListItem Value="8:30PM">08:30 PM</asp:ListItem>
                                    <asp:ListItem Value="8:45PM">08:45 PM</asp:ListItem>
                                    <asp:ListItem Value="9:00PM">09:00 PM</asp:ListItem>
                                    <asp:ListItem Value="9:15PM">09:15 PM</asp:ListItem>
                                    <asp:ListItem Value="9:30PM">09:30 PM</asp:ListItem>
                                    <asp:ListItem Value="9:45PM">09:45 PM</asp:ListItem>
                                    <asp:ListItem Value="10:00PM">10:00 PM</asp:ListItem>
                                    <asp:ListItem Value="10:15PM">10:15 PM</asp:ListItem>
                                    <asp:ListItem Value="10:30PM">10:30 PM</asp:ListItem>
                                    <asp:ListItem Value="10:45PM">10:45 PM</asp:ListItem>
                                    <asp:ListItem Value="11:00PM">11:00 PM</asp:ListItem>
                                    <asp:ListItem Value="11:15PM">11:15 PM</asp:ListItem>
                                    <asp:ListItem Value="11:30PM">11:30 PM</asp:ListItem>
                                    <asp:ListItem Value="11:45PM">11:45 PM</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right">
                                End Time:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEndTime" runat="server">
                                    <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="12:00AM">12:00 AM</asp:ListItem>
                                    <asp:ListItem Value="12:15AM">12:15 AM</asp:ListItem>
                                    <asp:ListItem Value="12:30AM">12:30 AM</asp:ListItem>
                                    <asp:ListItem Value="12:45AM">12:45 AM</asp:ListItem>
                                    <asp:ListItem Value="1:00AM">01:00 AM</asp:ListItem>
                                    <asp:ListItem Value="1:15AM">01:15 AM</asp:ListItem>
                                    <asp:ListItem Value="1:30AM">01:30 AM</asp:ListItem>
                                    <asp:ListItem Value="1:45AM">01:45 AM</asp:ListItem>
                                    <asp:ListItem Value="2:00AM">02:00 AM</asp:ListItem>
                                    <asp:ListItem Value="2:15AM">02:15 AM</asp:ListItem>
                                    <asp:ListItem Value="2:30AM">02:30 AM</asp:ListItem>
                                    <asp:ListItem Value="2:45AM">02:45 AM</asp:ListItem>
                                    <asp:ListItem Value="3:00AM">03:00 AM</asp:ListItem>
                                    <asp:ListItem Value="3:15AM">03:15 AM</asp:ListItem>
                                    <asp:ListItem Value="3:30AM">03:30 AM</asp:ListItem>
                                    <asp:ListItem Value="3:45AM">03:45 AM</asp:ListItem>
                                    <asp:ListItem Value="4:00AM">04:00 AM</asp:ListItem>
                                    <asp:ListItem Value="4:15AM">04:15 AM</asp:ListItem>
                                    <asp:ListItem Value="4:30AM">04:30 AM</asp:ListItem>
                                    <asp:ListItem Value="4:45AM">04:45 AM</asp:ListItem>
                                    <asp:ListItem Value="5:00AM">05:00 AM</asp:ListItem>
                                    <asp:ListItem Value="5:15AM">05:15 AM</asp:ListItem>
                                    <asp:ListItem Value="5:30AM">05:30 AM</asp:ListItem>
                                    <asp:ListItem Value="5:45AM">05:45 AM</asp:ListItem>
                                    <asp:ListItem Value="6:00AM">06:00 AM</asp:ListItem>
                                    <asp:ListItem Value="6:15AM">06:15 AM</asp:ListItem>
                                    <asp:ListItem Value="6:30AM">06:30 AM</asp:ListItem>
                                    <asp:ListItem Value="6:45AM">06:45 AM</asp:ListItem>
                                    <asp:ListItem Value="7:00AM">07:00 AM</asp:ListItem>
                                    <asp:ListItem Value="7:15AM">07:15 AM</asp:ListItem>
                                    <asp:ListItem Value="7:30AM">07:30 AM</asp:ListItem>
                                    <asp:ListItem Value="7:45AM">07:45 AM</asp:ListItem>
                                    <asp:ListItem Value="8:00AM">08:00 AM</asp:ListItem>
                                    <asp:ListItem Value="8:15AM">08:15 AM</asp:ListItem>
                                    <asp:ListItem Value="8:30AM">08:30 AM</asp:ListItem>
                                    <asp:ListItem Value="8:45AM">08:45 AM</asp:ListItem>
                                    <asp:ListItem Value="9:00AM">09:00 AM</asp:ListItem>
                                    <asp:ListItem Value="9:15AM">09:15 AM</asp:ListItem>
                                    <asp:ListItem Value="9:30AM">09:30 AM</asp:ListItem>
                                    <asp:ListItem Value="9:45AM">09:45 AM</asp:ListItem>
                                    <asp:ListItem Value="10:00AM">10:00 AM</asp:ListItem>
                                    <asp:ListItem Value="10:15AM">10:15 AM</asp:ListItem>
                                    <asp:ListItem Value="10:30AM">10:30 AM</asp:ListItem>
                                    <asp:ListItem Value="10:45AM">10:45 AM</asp:ListItem>
                                    <asp:ListItem Value="11:00AM">11:00 AM</asp:ListItem>
                                    <asp:ListItem Value="11:15AM">11:15 AM</asp:ListItem>
                                    <asp:ListItem Value="11:30AM">11:30 AM</asp:ListItem>
                                    <asp:ListItem Value="11:45AM">11:45 am</asp:ListItem>
                                    <asp:ListItem Value="12:00PM">12:00 pm</asp:ListItem>
                                    <asp:ListItem Value="12:00PM">12:00 PM</asp:ListItem>
                                    <asp:ListItem Value="12:15PM">12:15 PM</asp:ListItem>
                                    <asp:ListItem Value="12:30PM">12:30 PM</asp:ListItem>
                                    <asp:ListItem Value="12:45PM">12:45 PM</asp:ListItem>
                                    <asp:ListItem Value="1:00PM">01:00 PM</asp:ListItem>
                                    <asp:ListItem Value="1:15PM">01:15 PM</asp:ListItem>
                                    <asp:ListItem Value="1:30PM">01:30 PM</asp:ListItem>
                                    <asp:ListItem Value="1:45PM">01:45 PM</asp:ListItem>
                                    <asp:ListItem Value="2:00PM">02:00 PM</asp:ListItem>
                                    <asp:ListItem Value="2:15PM">02:15 PM</asp:ListItem>
                                    <asp:ListItem Value="2:30PM">02:30 PM</asp:ListItem>
                                    <asp:ListItem Value="2:45PM">02:45 PM</asp:ListItem>
                                    <asp:ListItem Value="3:00PM">03:00 PM</asp:ListItem>
                                    <asp:ListItem Value="3:15PM">03:15 PM</asp:ListItem>
                                    <asp:ListItem Value="3:30PM">03:30 PM</asp:ListItem>
                                    <asp:ListItem Value="3:45PM">03:45 PM</asp:ListItem>
                                    <asp:ListItem Value="4:00PM">04:00 PM</asp:ListItem>
                                    <asp:ListItem Value="4:15PM">04:15 PM</asp:ListItem>
                                    <asp:ListItem Value="4:30PM">04:30 PM</asp:ListItem>
                                    <asp:ListItem Value="4:45PM">04:45 PM</asp:ListItem>
                                    <asp:ListItem Value="5:00PM">05:00 PM</asp:ListItem>
                                    <asp:ListItem Value="5:15PM">05:15 PM</asp:ListItem>
                                    <asp:ListItem Value="5:30PM">05:30 PM</asp:ListItem>
                                    <asp:ListItem Value="5:45PM">05:45 PM</asp:ListItem>
                                    <asp:ListItem Value="6:00PM">06:00 PM</asp:ListItem>
                                    <asp:ListItem Value="6:15PM">06:15 PM</asp:ListItem>
                                    <asp:ListItem Value="6:30PM">06:30 PM</asp:ListItem>
                                    <asp:ListItem Value="6:45PM">06:45 PM</asp:ListItem>
                                    <asp:ListItem Value="7:00PM">07:00 PM</asp:ListItem>
                                    <asp:ListItem Value="7:15PM">07:15 PM</asp:ListItem>
                                    <asp:ListItem Value="7:30PM">07:30 PM</asp:ListItem>
                                    <asp:ListItem Value="7:45PM">07:45 PM</asp:ListItem>
                                    <asp:ListItem Value="8:00PM">08:00 PM</asp:ListItem>
                                    <asp:ListItem Value="8:15PM">08:15 PM</asp:ListItem>
                                    <asp:ListItem Value="8:30PM">08:30 PM</asp:ListItem>
                                    <asp:ListItem Value="8:45PM">08:45 PM</asp:ListItem>
                                    <asp:ListItem Value="9:00PM">09:00 PM</asp:ListItem>
                                    <asp:ListItem Value="9:15PM">09:15 PM</asp:ListItem>
                                    <asp:ListItem Value="9:30PM">09:30 PM</asp:ListItem>
                                    <asp:ListItem Value="9:45PM">09:45 PM</asp:ListItem>
                                    <asp:ListItem Value="10:00PM">10:00 PM</asp:ListItem>
                                    <asp:ListItem Value="10:15PM">10:15 PM</asp:ListItem>
                                    <asp:ListItem Value="10:30PM">10:30 PM</asp:ListItem>
                                    <asp:ListItem Value="10:45PM">10:45 PM</asp:ListItem>
                                    <asp:ListItem Value="11:00PM">11:00 PM</asp:ListItem>
                                    <asp:ListItem Value="11:15PM">11:15 PM</asp:ListItem>
                                    <asp:ListItem Value="11:30PM">11:30 PM</asp:ListItem>
                                    <asp:ListItem Value="11:45PM">11:45 PM</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align:right">
                                Location:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlLocations" onchange="changeLocationAppointments(this);"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Value="0" Selected="True">All</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align:right">
                                Provider:
                            </td>
                            <td>
                                <asp:Literal ID="ltrProvidersByLocation" runat="server"></asp:Literal>
                                <asp:DropDownList runat="server" ID="ddlProviders" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0" Selected="True">All</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align:right">
                                Status:
                            </td>
                            <td>
                                <select id="ddlStatus">
                                    <option value=""></option>
                                    <option value="1">Pending</option>
                                    <option value="2">Confirmed</option>
                                    <option value="3">Cancelled</option>
                                    <option value="4">Arrived</option>
                                    <option value="5">Completed</option>
                                    <option value="6">No Show</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="text-align: right">
                    <input id="txtSearch" type="button" value="Search" onclick="getPatientAppoinmentReport(0,true);" />
                </div>
            </fieldset>
            <div class="WidgetReport" style="margin-top: 20px;">
                <div id="pagingReportDiv">
                    <div class="pagerReport">
                        <div class="PageEntries">
                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                <select id="ddlPagingReport" style="margin-top: 5px;" onchange="RowsChange('getPatientAppoinmentReport');">
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
                                        <div class="report-export-wrapper" title="Export">
                                            <asp:DropDownList ID="ddlExportTo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExportTo_SelectedIndexChanged"
                                                CssClass="custom-export-drop-down">
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
                                        <a href="javascript:void(0)" class="report-print-icon report-tool-icon" title="Print" onclick="printReport('ReportContainer');">
                                            <img src="../../Images/print.png" /></a>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" class="report-tool-icon" title="Refresh" onclick="getPatientAppoinmentReport(0,true);">
                                            <img src="../../Images/ReportRefresh.gif" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="report-edit-wrapper" onclick="PatientAppointmentsReportEdit();">
                            <span class="spanedit">Show | Hide Columns</span>
                        </div>
                    </div>
                </div>
                <div class="WidgetReportContent">
                    <div class="float-left-100">
                        <div id="ReportContainer">
                            <div class="ReportGrid">
                                <table style="width: 100%;">
                                    <thead>
                                        <tr>
                                            <th style="width: 2%;">
                                            </th>
                                            <th style="width: 5%;">
                                                Account Number
                                            </th>
                                            <th style="width: 13%;">
                                                Patient Name
                                            </th>
                                            <th style="width: 10%;">
                                                Appointment Date
                                            </th>
                                            <th style="width: 7%;">
                                                Start Time
                                            </th>
                                            <th style="width: 7%;">
                                                End Time
                                            </th>
                                            <th style="width: 10%;">
                                                Location
                                            </th>
                                            <th style="width: 10%;">
                                                Provider
                                            </th>
                                            <th style="width: 10%;">
                                                Status
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody class="tbodyReports">
                                        <asp:Repeater ID="rptAppointment" runat="server">
                                            <ItemTemplate>
                                                <tr id='<%# Eval("AppointmentsId") %>'>
                                                    <td>
                                                        <i>
                                                            <%# Eval("RowNumber") %></i>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientId") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("AppointmentDate", "{0:d}") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("StartTime") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("EndTime") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PracticeLocation")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("ResouurceProviderName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("StatusName")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr id='<%# Eval("AppointmentsId") %>' class="alternatingRow">
                                                    <td>
                                                        <i>
                                                            <%# Eval("RowNumber") %></i>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientId") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("AppointmentDate", "{0:d}") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("StartTime") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("EndTime") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PracticeLocation")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("ResouurceProviderName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("StatusName")%>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>
    <div id="dialogReportAppointment" style="display: none;">
        <div class="report-dialog-inner">
            <h3>
                Information</h3>
            <div class="report-dialog-content">
                <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCheckbox1" CssClass="cbCheckbox1" runat="server" Text="Account Number"
                                Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCheckbox2" CssClass="cbCheckbox2" runat="server" Text="Patient Name"
                                Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCheckbox3" CssClass="cbCheckbox3" runat="server" Text="Appointment Date"
                                Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCheckbox4" CssClass="cbCheckbox4" runat="server" Text="Start Time"
                                Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCheckbox5" CssClass="cbCheckbox5" runat="server" Text="End Time"
                                Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCheckbox6" CssClass="cbCheckbox6" runat="server" Text="Location"
                                Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCheckbox7" CssClass="cbCheckbox7" runat="server" Text="Provider"
                                Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbCheckbox8" CssClass="cbCheckbox8" runat="server" Text="Status"
                                Checked="true" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
