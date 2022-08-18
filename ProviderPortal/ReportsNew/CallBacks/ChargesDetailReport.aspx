<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargesDetailReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ChargesDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###startReport###

        <div class="TimeSpan">
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="TimeSpan"></asp:Label>
        </div>
         <asp:Repeater ID="rptChargesDetail" runat="server" OnItemDataBound="rptChargesDetail_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PostDate');">
                                                        <span class="report-column-title">Post Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'servicedate');">
                                                        <span class="report-column-title">Service Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                        <span class="report-column-title">PatientId</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                        <span class="report-column-title">Patient Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Code');">
                                                        <span class="report-column-title">Code</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Description');">
                                                        <span class="report-column-title">Description</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'RendProvider');">
                                                        <span class="report-column-title">Rend Provider</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Location');">
                                                        <span class="report-column-title">Location</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ServiceUnits');">
                                                        <span class="report-column-title">Units</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'TotalCharges');">
                                                        <span class="report-column-title">Total Charges</span><span></span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList" style="">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center; width:5%">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td style="text-align: center; width:5%">
                                            <%# Eval("PostDate")%>
                                        </td>
                                        <td style="text-align: center; width:5%">
                                            <%# Eval("servicedate")%>
                                        </td>
                                        <td style="text-align: center; width:5%">
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td style="width: 10%;">
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td style="text-align: center; width:5%">
                                            <%# Eval("Code")%>
                                        </td>
                                        <td style="width: 40%; text-align:left">
                                            <%# Eval("[Description]")%>
                                        </td>
                                        <td style="width: 5%; text-align:right">
                                            <%# Eval("RendProvider")%>
                                        </td>
                                        <td style="width: 5%; text-align:center">
                                            <%# Eval("Location")%>
                                        </td>
                                        <td style="text-align: left; width:10%">
                                            <%--<%# Eval("ServiceUnits")%>--%>
                                            <asp:Label ID="lblServiceUnits" runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: right; width:5%">
                                            <%--<%# Eval("TotalCharges")%>--%>
                                            <asp:Label ID="lblTotalCharges" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                      <tfooter>
                                        <tr>
                                            <td style="border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-top:1px solid #C4C4C4;font-weight:bold; float:right; width:98%;"><asp:Label ID="lblGrandTotal" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalUnits" runat="server"></asp:Label></td>
                                            <%--<td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalUnitCharges" runat="server"></asp:Label></td>--%>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalCharges" runat="server"></asp:Label></td>
                                           <%-- <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalRVU" runat="server"></asp:Label></td>--%>
                                            </tr>
                                            </tfooter>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>
  <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
         <asp:HiddenField runat="server" ID="hdnPatId" />
    <div id="divDialogReportFilters" style="display: none;"></div>


        <script type="text/javascript">
            debugger;
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();

                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
                        Rows: Rows1,
                        PageNumber: pageNumber,
                        SortBy: sortValue,
                        action: "Filter"
                    };

                    debugger
                    Report_ReloadData(_selectedReport_Filter, params, paging);
                }


            }

        </script>


         ###endReport###
    </div>
    </form>
</body>
</html>
