<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProvidersReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ProvidersReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###startReport###

        <div id="divReportListing">

                            <asp:Repeater ID="rptProviders" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'LastName');">
                                                        <span class="report-column-title">Last Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'FirstName');">
                                                        <span class="report-column-title">First Name</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'FirstName');">
                                                        <span class="report-column-title">Degree</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'FirstName');">
                                                        <span class="report-column-title">Speciality</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Address');">
                                                        <span class="report-column-title">Address</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'cell');">
                                                        <span class="report-column-title">Phone No.</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Email');">
                                                        <span class="report-column-title">Email</span><span></span>
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
                                            <%# Eval("LastName")%>
                                        </td>
                                        <td>
                                            <%# Eval("FirstName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Degree")%>
                                        </td>
                                        <td>
                                            <%# Eval("Speciality")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Address]")%>
                                        </td>
                                        <td>
                                            <%# Eval("PhoneNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("Email")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
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
