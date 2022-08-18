<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPaymentApplicationSummaryReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterPaymentApplicationSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
            
                            <asp:Repeater ID="rptPaymentApplicationSummary" runat="server" OnItemDataBound="rptPaymentApplicationSummary_ItemDataBound">
<%-- Edited by Faiza Bilal 6-8-2022 to change layout according to instr--%>
                                 <HeaderTemplate>
                        <div class="GridReports" id="printableArea">
                            <table>
                                <thead>
                                    <tr>
                                        <th colspan="2" style="background: #d1cec2; font-weight: bold;">Payment Method</th>
                                    </tr>
                                    <tr>
                                     
                                        <th>
                                            <span class="report-column-title">Payment Method</span>
                                        </th>
                                        <th>
                                            <span class="report-column-title">Total</span>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="tbodyReportList">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="RenderingProvider" runat="server">
                            <td id="rowren" colspan="2" style="font-weight: bold;"><%# Eval("RenderingProvider") %> </td>
                        </tr>
                        <tr>
                            <td>
                               
                                <asp:Label style="margin-left:2%" ID="lblPaymentMethod" runat="server"></asp:Label>
                                <asp:Label ID="lblSubTotal" runat="server" Style="font-weight: bold;"></asp:Label>
                                <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight: bold;"></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lblTotalSummary" runat="server" Style="font-weight: bold;"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                        </div>
                                            </FooterTemplate>
                            
                                  <%--End Edited by Faiza Bilal 6-8-2022 to change layout according to instr--%>
                            </asp:Repeater>
            <asp:Repeater ID="rptPaymentApplicationSummary1" runat="server" OnItemDataBound="rptPaymentApplicationSummary1_ItemDataBound">

                <HeaderTemplate>
                    <div class="GridReports">
                        <table>
                            <thead>
                                <tr>
                                    <th colspan="2" style="background: #d1cec2; font-weight: bold; border-top: 1px solid #CCC">Unapplied Analysis</th>
                                </tr>
                                <tr>
                                    <th style="border-top: 1px solid #CCC">
                                        <span class="report-column-title">Unapplied Analysis</span>
                                    </th>
                                    <%--<th>
                                                        <span class="report-column-title">Payment Method</span>
                                                    </th>--%>
                                    <th style="border-top: 1px solid #CCC">
                                        <span class="report-column-title">Total</span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="font-weight: bold;">
                            <%# Eval("UnAppliedAnalysis")%>,
                        </td>
                        <%--   <td>
                                            <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label>
                                            <asp:Label ID="lblSubTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                                            <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                                        </td>--%>
                        <td>
                            <%--$<%# Eval("Total")%>--%>
                            <asp:Label ID="lblTotalUnappliedAnalysis" runat="server"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                            </div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptPaymentApplicationSummary2" runat="server" OnItemDataBound="rptPaymentApplicationSummary2_ItemDataBound">

                <HeaderTemplate>
                    <div class="GridReports">
                        <table>
                            <thead>
                                <tr>
                                    <th colspan="2" style="background: #d1cec2; font-weight: bold; border-top: 1px solid #CCC">All Rendering Providers</th>
                                </tr>
                                <tr>
                                    <th>
                                        <span class="report-column-title">Payment Method</span>
                                    </th>
                                    <th style="border-top: 1px solid #CCC">
                                        <span class="report-column-title">Total</span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblPaymentMethod3" runat="server"></asp:Label>
                            <%--<asp:Label ID="lblSubTotal" runat="server" Style="font-weight:bold;"></asp:Label>--%>
                            <asp:Label ID="lblGrandTotal3" runat="server" Style="font-weight: bold;"></asp:Label>
                        </td>
                        <td>
                            <%-- $<%# Eval("Total")%></td>--%>
                            <asp:Label ID="lblTotalAllRenderingProviders" runat="server" Style="font-weight: bold;"></asp:Label>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                            </div>
                </FooterTemplate>
            </asp:Repeater>

            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            ###End###
                                    ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
