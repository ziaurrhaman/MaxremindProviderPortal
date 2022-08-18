<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterRejectedDeniedSummaryAndDetail.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterRejectedDeniedClaims" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###Start###




        <div class="parent">

            <div class="exportSummary">
                <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                <span style="float: left; padding-top: 2px; margin-left: 7px">
                    <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('Rejected Denied Summary & Detail',this,'printableAreaRDC');">
                        <option></option>
                        <option value="Excel">Excel</option>
                        <option value="PDF">PDF</option>
                        <option value="Word">Word</option>
                    </select>
                </span>


                <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaRDC')">
                    <img src="../../Images/PrintView1.png" alt="img" /></span>

            </div>

            <div class="Grid" style="max-height: 400px; overflow-y: scroll;">
                <asp:Repeater ID="rptRDC" runat="server">
                    <HeaderTemplate>
                        <div class="GridReportsSummary" id="printableAreaRDC">

                            <table id="fixTable">
                                <thead>
                                    <tr>
                                        <th style="width: 3%" class="center">
                                            <span class="report-column-title">#</span><span></span>
                                        </th>
                                        <th class="asc center" onclick="SortReportList(this,'Claimid');" style="width: 7%">
                                            <span class="report-column-title">Claim Id</span><span></span>
                                        </th>
                                        <th class="asc center" onclick="SortReportList(this,'PatientName');" style="width: 12%">
                                            <span class="report-column-title">Patient</span><span></span>
                                        </th>

                                        <th class="asc center" onclick="SortReportList(this,'DOS');" style="width: 8%">
                                            <span class="report-column-title">DOS</span><span></span>
                                        </th>

                                        <th class="asc center" onclick="SortReportList(this,'CPTCode');" style="width: 8%">
                                            <span class="report-column-title">CPT</span><span></span>
                                        </th>
                                        <th class="asc center" onclick="SortReportList(this,'Charges');" style="width: 8%">
                                            <span class="report-column-title">Charges</span><span></span>
                                        </th>
                                        <th class="asc center" onclick="SortReportList(this,'BilledAs');" style="width: 8%">
                                            <span class="report-column-title">Billed As</span><span></span>
                                        </th>
                                        <th class="asc center" onclick="SortReportList(this,'Payer');">
                                            <span class="report-column-title">Insurance</span><span></span>
                                        </th>


                                        <th class="asc center" onclick="SortReportList(this,'SubmissionStatus');" style="width: 8%">
                                            <span class="report-column-title">Claim Status</span><span></span>
                                        </th>

                                    </tr>
                                </thead>
                                <tbody id="tbodyReportList">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="center">
                                <%# Eval("RowNumber")%>
                            </td>
                            <td class="AlignString">
                                <%# Eval("Claimid")%>
                            </td>
                            <td class="AlignString">
                                <%# Eval("PatientName")%>
                            </td>

                            <td class="AlignDate">
                                <%# Eval("DOS","{0:d}")%>  
                            </td>
                            <td class="AlignDate">
                                <%# Eval("[CPTCode]")%>
                            </td>


                            <td class="AlignPayment">
                                <%# Eval("Charges")%>
                            </td>
                            <td class="AlignString">
                                <%# Eval("[BilledAs]")%>
                            </td>


                            <td class="AlignString">
                                <%# Eval("Payer")%>
                            </td>


                            <td class="AlignString">
                                <%# Eval("SubmissionStatus")%>  
                            </td>


                        </tr>

                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                    
                                        </tfooter>
                                </table>
                            </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>


            <script>
                $(document).ready(function () { $("#fixTable").tableHeadFixer(); });
            </script>
        </div>



        ###End###

        ###StartFilter###
        <asp:Repeater ID="rptSummary" runat="server" OnItemDataBound="rptSummary_ItemDataBound">
            <HeaderTemplate>
                <div class="GridReports" id="printableArea">
                    <table style="width: 100%">
                        <thead>
                            <tr>
                                <th style="width: 3%" class="center">
                                    <span class="report-column-title">#</span><span></span>
                                </th>
                                <th class="asc center" onclick="SortReportList(this,'PatientId');" style="width: 7%">
                                    <span class="report-column-title">Insurance</span>
                                    <%-- <span class="filterIcon asc"></span>--%>
                                </th>
                                <th class="asc center" onclick="SortReportList(this,'PatientName');" style="width: 12%">
                                    <span class="report-column-title">Rejected</span><span></span>
                                </th>
                                <th class="asc center" onclick="SortReportList(this,'Claimid');" style="width: 7%">
                                    <span class="report-column-title">Denied</span><span></span>
                                </th>
                                <th class="asc center" onclick="SortReportList(this,'DOS');" style="width: 8%">
                                    <span class="report-column-title">Paid Up</span><span></span>
                                </th>
                                <th class="asc center" onclick="SortReportList(this,'DOS');" style="width: 8%">
                                    <span class="report-column-title">Total</span><span></span>
                                </th>


                            </tr>
                        </thead>
                        <tbody id="tbodyReportList">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="center">
                        <%# Container.ItemIndex+1 %>
                    </td>
                    <td class="AlignString">
                        <%# Eval("Payer")%>
                    </td>
                    <td class="center linkClass" onclick="RejDenSummary('<%# Eval("InsNameId")%>','Rejected')" style="cursor: pointer" id="lblrejcted">

                        <asp:Label ID="lblrejected" runat="server" Text=' <%# Eval("Rejected")%>'></asp:Label>
                    </td>
                    <td class="center linkClass" onclick="RejDenSummary('<%# Eval("InsNameId")%>','Denied')" style="cursor: pointer">
                        <%# Eval("Denied")%>
                    </td>
                    <td class="center linkClass" onclick="RejDenSummary('<%# Eval("InsNameId")%>','Paid Up')" style="cursor: pointer">
                        <%# Eval("PaidUp")%>  
                    </td>

                    <td class="center linkClass" onclick="RejDenSummary('<%# Eval("InsNameId")%>','')">
                        <%# Eval("[Total]")%>
                                           
                    </td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                                       <tfooter>
                                           <tr class="BtmToatlTr">

                                               <td style="border-top: 1px solid #C4C4C4;">
                                                   <asp:Label ID="Label1" runat="server" Style="font-weight: bold"></asp:Label></td>
                                               <td style="border-left: none; border-top: 1px solid #C4C4C4; font-weight: bold; float: right; width: 98%;">
                                                   <asp:Label ID="lblGrand" runat="server" Style="font-weight: bold">Grand Total</asp:Label></td>
                                               <td style="border-top: 1px solid #C4C4C4;" class="linkClass" onclick="RejDenSummary('','Rejected')">
                                                   <asp:Label ID="lblRejectedTotal" runat="server" Style="font-weight: bold"></asp:Label></td>
                                               <td style="border-top: 1px solid #C4C4C4;" class="linkClass" onclick="RejDenSummary('','Denied')">
                                                   <asp:Label ID="lblDeniedTotal" runat="server" Style="font-weight: bold"></asp:Label></td>
                                               <td style="border-top: 1px solid #C4C4C4;" class="linkClass" onclick="RejDenSummary('','Paid Up')">
                                                   <asp:Label ID="lblPPaidTotal" runat="server" Style="font-weight: bold"></asp:Label></td>
                                               <td style="border-top: 1px solid #C4C4C4;" class="linkClass" onclick="RejDenSummary('','')">
                                                   <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight: bold"></asp:Label></td>
                                           </tr>

                                       </tfooter>
                </table> 
                            </div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hdnBilledAs" runat="server" />
        <asp:HiddenField ID="hdnPayer" runat="server" />
        <asp:HiddenField ID="hdnAging" runat="server" />
        <asp:HiddenField ID="hdnProviderId" runat="server" />
        <asp:HiddenField ID="hdnLocation" runat="server" />

        <input type="hidden" id="hdnTotalRows" runat="server" />
        ###EndFilter###
    
   

   
    </form>
</body>
</html>
