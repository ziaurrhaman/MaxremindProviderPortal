<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EncounterSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_EncounterSummaryReport" %>

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
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="lblTimeSpan"></asp:Label>
        </div>
          <asp:Repeater ID="rptDenialsDetail" runat="server">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimId');">
                                                        <span class="report-column-title">Encounters</span><span class="filterIcon asc"></span>
                                                    </th>
                                              <th class="asc" onclick="SortReportList(this,'RenderProvider');">
                                                        <span class="report-column-title">Render Provider</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Procedures');">
                                                        <span class="report-column-title">Procedures</span><span></span>
                                                    </th>
                                                  
                                                    <th class="asc" onclick="SortReportList(this,'Charges');">
                                                        <span class="report-column-title">Charges</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Adjustment');">
                                                        <span class="report-column-title">Adjustment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Receipts');">
                                                        <span class="report-column-title">Receipts</span><span></span>
                                                    </th>
                                                        <th class="asc" onclick="SortReportList(this,'Balance');">
                                                        <span class="report-column-title">Total Balance</span><span></span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td style="width:7%;">
                                            <%# Eval("Encounters")%>
                                        </td>                                      
                                        <td>
                                            <%# Eval("[Rend Provider]")%>
                                        </td>
                                      
                                        <td>
                                            <%# Eval("[Procedures]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Charges")%>
                                        </td>
                                        <td>
                                            <%# Eval("Adjustments")%>
                                        </td>
                                         <td>
                                            <%# Eval("Receipts")%>
                                        </td>
                                        <td>
                                            <%# Eval("TotalBalance")%>
                                        </td>
                                       <%-- <td>
                                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDenied" runat="server"></asp:Label>
                                        </td>--%>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>

  <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
    <asp:HiddenField runat="server" ID="hdnProviderId" />
    <asp:HiddenField runat="server" ID="hdnDateType" />
    <asp:HiddenField runat="server" ID="hdnPayerId" />
    <asp:HiddenField runat="server" ID="hdnSubmissionStatus" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
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
                        ProviderId: $("[id$='hdnProviderId']").val(),
                        PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                        Payer: $("[id$='hdnPayerId']").val(),
                        SubmissionStatus: $("[id$='hdnSubmissionStatus']").val(),
                        DateType: $("[id$='hdnDateType']").val(),
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
