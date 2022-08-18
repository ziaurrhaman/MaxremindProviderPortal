<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientCollectionDetail.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientCollectionDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###startReport###

            <asp:Repeater ID="rptPatientCollectionDetail" runat="server" OnItemDataBound="rptPatientCollectionDetail_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                        <span class="report-column-title">PatientId</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'LastName');">
                                                        <span class="report-column-title">Last Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'FirstName');">
                                                        <span class="report-column-title">First Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Address');">
                                                        <span class="report-column-title">Address</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Mobile');">
                                                        <span class="report-column-title">Mobile No.</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Email');">
                                                        <span class="report-column-title">Email</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'BalanceOver90Days');">
                                                        <span class="report-column-title">Balance Over 90 Days</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'TotalBalance');">
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
                                        <td>
                                           <%# Eval("PatientId") %>
                                        </td>
                                        <td>
                                            <%# Eval("LastName") %>
                                        </td>
                                        <td>
                                            <%# Eval("FirstName") %>
                                        </td>
                                        <td style="width:40%">
                                            <%# Eval("[Address]") %>
                                        </td>
                                        <td>
                                            <%# Eval("Mobile") %>
                                        </td>
                                        <td>
                                            <%# Eval("Email") %>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBalanceOver90" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalBalance" runat="server"></asp:Label>
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
    <asp:HiddenField runat="server" ID="hdnAgingDate" />
    <asp:HiddenField runat="server" ID="hdnAgingType" />
    <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
    <asp:HiddenField runat="server" ID="hdnProviderId" />
    <asp:HiddenField runat="server" ID="hdnPatientId" />

        <script>
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();
                var DateFrom = $("[id$='hdnDateFrom']").val();
                var DateTo = $("[id$='hdnDateTo']").val();
                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {
                        AgingDate: $("[id$='hdnAgingDate']").val(),
                        AgingType: $("[id$='hdnAgingType']").val(),
                        PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                        ProviderId: $("[id$='hdnProviderId']").val(),
                        PatientId: $("[id$='hdnPatientId']").val(),
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
