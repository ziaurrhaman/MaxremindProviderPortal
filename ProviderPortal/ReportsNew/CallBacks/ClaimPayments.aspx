<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimPayments.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ClaimPayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
              ###startReport###
    <div class="GridReports" id="printableArea">
        <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'DOS');">
                                                <span class="report-column-title">DOS</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'ClaimsId');">
                                                <span class="report-column-title">Claim ID</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                <span class="report-column-title">Patient Name</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'PrimaryInsurance');">
                                                <span class="report-column-title">Primary Insurance</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'SecondaryInsurance');">
                                                <span class="report-column-title">Secondary Insurance</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PrimaryPayment');">
                                                <span class="report-column-title">Primary Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'SecondaryPayment');">
                                                <span class="report-column-title">Secondary Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Adjustment');">
                                                <span class="report-column-title">Adjustment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientPayment');">
                                                <span class="report-column-title">Patient Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'BalanceDue');">
                                                <span class="report-column-title">Balance Due</span><span></span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyReportList">
                                        <asp:Repeater id="rptReportData"  runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DOS")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("ClaimId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PrimaryInsurance")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("SecondaryInsurance")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PrimaryPayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("SecondaryPayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Adjustment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientPayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("BalanceDue")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
    </div>
         <input type="hidden" id="hdnTotalRows" runat="server" value="0"/>

        <script>
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();
              
                var paging = true;
                
                if (_selectedReport_Filter != "") {
                    params = {
                      
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
    </form>
</body>
</html>
