<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientCollectionSummary.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientCollectionSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###startReport###


            <div id="divReportListing" runat="server">
                            <asp:Repeater ID="rptPatientCollectionSummary" runat="server" OnItemDataBound="rptPatientCollectionSummary_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea" >
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">Collection Category</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">No Of Patients</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Unbilled</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Current</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">31-60</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">61-90</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">91-120</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">120+</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Total</span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCollectionCategory" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                           <%# Eval("NoOfPatients") %>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUnbilled" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCurrent" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl3160" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl6190" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl91120" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl120" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalBal" runat="server"></asp:Label>
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
