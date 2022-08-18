<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientBalanceReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterPatientBalanceReport" %>

<!DOCTYPE html>
<%--Created by Faiza Bilal 2-7-2022--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartPatDet###
        <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
            <script>
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                });
            </script>
            <div class="parent">

                <div class="exportSummary">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                    <span style="float: left; padding-top: 2px; margin-left: 7px">
                        <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('Procedure Detail',this,'printableAreaRDC');">
                            <option></option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>
                    </span>


                    <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaRDC')">
                        <img src="../../Images/PrintView1.png" alt="img" /></span>

                </div>

                <div class="Grid GridReports" id="printableAreaRDC" style="height: 400px; overflow-y: auto; width: 100% !important; padding-top: 0 !important;">

                    <table class="fixTable">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th class="center">
                                    <span class="report-column-title">Patient Acct</span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Patient Last Name
                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Patient First Name
                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">DOB
                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Phone Number
                                    </span>
                                </th>

                                <th class="center">
                                    <span class="report-column-title">Patient Address
                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim Pri Insurance
                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim Pri Insurance ID
                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim Sec Insurance
                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim Sec Insurance ID

                                    </span>
                                </th>

                                <th class="center">
                                    <span class="report-column-title">Claim ID

                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim DOS

                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Service Location

                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim Physician

                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Billed As

                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim Status


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim Charges


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Total Allowed


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Insurance Paid


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Patient Paid


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Total Paid


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">WriteOffAdjustment


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Total Adjustments


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Balance Due


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Claim Post Date


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">First Submission Date


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Last Submission Date


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Pri Status


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Sec Status


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Pat Status


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">EDI Notes Remarks


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">Current



                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">31-60


                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">61-90

                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">91-120

                                    </span>
                                </th>
                                <th class="center">
                                    <span class="report-column-title">>120


                                    </span>
                                </th>
                            </tr>
                        </thead>
                        <tbody id="tbodyChargedProcedure">
                            <asp:Repeater ID="rptPatBal" runat="server">
                                <ItemTemplate>
                                    <tr>
                                                              <td><%# Container.ItemIndex +1 %></td>
                                        <td class="AlignString"><%#Eval ("Patient Acct") %></td>
                                        <td class="AlignString"><%#Eval ("Patient Last Name") %></td>
                                        <td class="AlignString"><%#Eval ("Patient First Name") %></td>
                                        <td class="AlignDate"><%#Eval ("DOB") %></td>
                                        <td class="AlignDate"><%#Eval ("Phone Number") %></td>
                                        <td class="" title="<%#Eval ("Patient Address") %>">
                                            <%#(Eval("Patient Address").ToString().Length > 11) ? Eval("Patient Address").ToString().Substring(0, 11) : Eval("Patient Address") %>...
                                        </td>
                                        <td class="AlignDate"><%#Eval ("Claim Pri Insurance") %></td>
                                        <td class="AlignDate"><%#Eval ("Claim Pri Insurance ID") %></td>
                                        <td class="AlignDate"><%#Eval ("Claim Sec Insurance") %></td>
                                        <td class="AlignDate"><%#Eval ("Claim Sec Insurance ID") %></td>

                                        <td class="AlignDate"><%#Eval ("Claim ID") %></td>

                                        <td class="AlignDate"><%#Eval ("Claim DOS") %></td>
                                        <td class="AlignDate"><%#Eval ("Service Location") %></td>
                                        <td class="AlignDate"><%#Eval ("Claim Physician") %></td>
                                        <td class="AlignDate"><%#Eval ("Billed As") %></td>
                                        <td class="AlignDate"><%#Eval ("Claim Status") %></td>
                                        <td class=" AlignPayment"><%#Eval ("claim Charges", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("Total Allowed", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("Insurance Paid", "{0:C}") %></td>

                                        <td class=" AlignPayment"><%#Eval ("Patient Paid", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("Total Paid", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("WriteOffAdjustment", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("Total Adjustments", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("Balance Due", "{0:C}") %></td>
                                        <td class="AlignDate"><%#Eval ("Claim Post Date") %></td>
                                        <td class="AlignDate"><%#Eval ("First Submission Date") %></td>
                                        <td class="AlignDate"><%#Eval ("Last Submission Date") %></td>
                                        <td class="AlignDate"><%#Eval ("Pri Status") %></td>
                                        <td class="AlignDate"><%#Eval ("Sec Status") %></td>
                                        <td class="AlignString"><%#Eval ("Pat Status") %></td>
                                        <td class="AlignString" title="<%#Eval ("EDINotes") %>">
                                            <%#(Eval("EDINotes").ToString().Length > 25) ? Eval("EDINotes").ToString().Substring(0, 25) : Eval("EDINotes") %>...
                                        </td>
                                        <td class=" AlignPayment"><%#Eval ("current", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("31-60", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("61-90", "{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval ("91-120","{0:C}") %></td>
                                        <td class=" AlignPayment"><%#Eval (">120", "{0:C}") %></td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

            </div>

            

        </div>
        ###EndPatDet###
        
        ###Start###
                            
                                <asp:Repeater runat="server" ID="rptFilter">
                                    <ItemTemplate>
                                        <tr>
                                                          <td><%#Eval("RowNumber") %></td>
                                            <td class="AlignDate">
                                                <%#Eval ("Patient Id")%>
                                            </td>
                                            <td class="AlignDate ">
                                                <%#Eval ("Patient Last Name")%>
                                            </td>
                                            <td class="AlignDate">
                                                <%#Eval ("Patient First Name")%>
                                            </td>
                                            <td class="AlignDate">
                                                <%#Eval ("DOB")%>
                                            </td>
                                            <td class="AlignDate">
                                                <%#Eval ("LastDOS")%>
                                            </td>
                                            <td class="AlignPayment">
                                                <%#Eval ("Balance", "{0:C}")%>
                                            </td>
                                            <td class="AlignDate linkClass" onclick="GetPatBalReport('<%#Eval("Patient Id") %>')">
                                                <%#Eval ("TotalCount")%>
                                            </td>

                                        </tr>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                       
                                        <tfooter>
                                            <tr class="BtmToatlTr" id="notificationFooter">

                                        <td></td>

                                                <td style="border-left: none; border-top: 1px solid #C4C4C4; font-weight: bold; width: 10%">
                                                    <asp:Label ID="lblGrand" runat="server" Style="font-weight: bold; color: #000 !important;">Grand Total</asp:Label></td>
                                                <td style="border-top: 1px solid #C4C4C4; width: 10%">
                                                    <asp:Label ID="Label1" runat="server" Style="font-weight: bold"></asp:Label></td>
                                                <td style="border-top: 1px solid #C4C4C4; width: 10%" class="linkClass">
                                                    <asp:Label ID="lbl1" runat="server" Style="font-weight: bold"></asp:Label></td>
                                                <td style="border-top: 1px solid #C4C4C4; width: 20%" class="linkClass">
                                                    <asp:Label ID="lbl2" runat="server" Style="font-weight: bold"></asp:Label></td>
                                                <td style="border-top: 1px solid #C4C4C4; width: 20%" class="linkClass">
                                                    <asp:Label ID="lbl3" runat="server" Style="font-weight: bold"></asp:Label></td>
                                                <td style="border-top: 1px solid #C4C4C4; width: 20%" class="linkClass">
                                                    <asp:Label ID="Label2" runat="server" Style="font-weight: bold"></asp:Label></td>
                                                <td style="border-top: 1px solid #C4C4C4; border-left: none; width: 20%;" class="linkClass" onclick="GetPatBalReport('')">
                                                    <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight: bold; color: blue !important;"></asp:Label></td>
                                            </tr>


                                        </tfooter>
                              
                            
                                    </FooterTemplate>
                                </asp:Repeater>

             <input type="hidden" id="hdnDateType" runat="server" value="" />
            <input type="hidden" id="hdnStartDate" runat="server" value="" />
            <input type="hidden" id="hdnEndDate" runat="server" value="" />
            <input type="hidden" id="hdnPracticeLocationId" runat="server" value="" />
            <input type="hidden" id="hdnProviderId" runat="server" value=""/>
        
        ###End###
        ###StartTotal###
          <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
        ###EndTotal###
    </form>
</body>
</html>
