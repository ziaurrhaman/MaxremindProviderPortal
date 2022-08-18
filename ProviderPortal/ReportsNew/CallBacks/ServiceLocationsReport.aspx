<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceLocationsReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ServiceLocationsReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###startReport###

         <asp:Repeater ID="rptServiceLocations" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Name');">
                                                        <span class="report-column-title">Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'BillingName');">
                                                        <span class="report-column-title">Billing Name</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PlaceOfService');">
                                                        <span class="report-column-title">Place Of Service</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Address');">
                                                        <span class="report-column-title">Address</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'City');">
                                                        <span class="report-column-title">City</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'StateCode');">
                                                        <span class="report-column-title">State</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Zip');">
                                                        <span class="report-column-title">Zip</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Phone');">
                                                        <span class="report-column-title">Phone</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'FaxNo');">
                                                        <span class="report-column-title">Fax</span><span></span>
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
                                        <td>
                                            <%# Eval("Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("BillingName")%>
                                        </td>
                                        <td>
                                            <%# Eval("PlaceOfService")%>
                                        </td>
                                        <td>
                                            <%# Eval("Address")%>
                                        </td>
                                        <td>
                                            <%# Eval("City")%>
                                        </td>
                                        <td>
                                            <%# Eval("StateCode")%>
                                        </td>
                                        <td>
                                            <%# Eval("Zip")%>
                                        </td>
                                        <td>
                                            <%# Eval("Phone")%>
                                        </td>
                                        <td>
                                            <%# Eval("FaxNo")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>
  <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
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
