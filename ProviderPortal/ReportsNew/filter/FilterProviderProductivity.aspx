<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterProviderProductivity.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterProviderProductivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
                     <div class="exportSummary">
                         <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                         <span style="float: left; padding-top: 2px; margin-left: 7px">
                             <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('ProviderCollectionReport',this,'ProviderCollectionPrint');">
                                 <option></option>
                                 <option value="Excel">Excel</option>
                                 <option value="PDF">PDF</option>
                                 <option value="Word">Word</option>
                             </select>
                         </span>


                         <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('ProviderCollectionPrint')">
                             <img src="../../Images/PrintView1.png" alt="img" /></span>

                     </div>
            <div class="GridReports" id="ProviderCollectionPrint" style="overflow-y: scroll; height: 430px;">
                <table class="fixTable">
                    <thead>
                        <tr>
                            <th style="text-align: center !important; background-color: rgb(79, 175, 216); position: relative; top: 0px;">#</t>
                                        <th style="text-align: center !important; background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                            <span class="report-column-title">Patient Name</span>
                                        </th>

                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">ClaimId</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Attending Physician</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">DOS</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Charged Procedure</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Paid Procedure</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Total charges</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Paid Amount</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Check Date</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Check Number</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Location</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Payer Name</span>
                                </th>
                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                    <span class="report-column-title">Post Date</span>
                                </th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="rptProviderCollectionReport" runat="server">
                        <ItemTemplate>
                            <tbody id="tbodyReportList">
                                <tr>
                                    <td class="center"><%# Container.ItemIndex + 1 %></td>
                                    <td style="text-align: center;"><%# Eval("PatientName")%></td>
                                    <td style="text-align: center;"><%# Eval("claimId")%></td>
                                    <td style="text-align: center;"><%# Eval("AttendingPhysician")%></td>
                                    <td style="text-align: center;"><%# Eval("DOS")%></td>
                                    <td style="text-align: center;"><%# Eval("ChargedProcedure")%></td>
                                    <td style="text-align: center;"><%# Eval("PaidProcedure")%></td>
                                    <td style="text-align: center;"><%# Eval("Totalcharges")%></td>
                                    <td style="text-align: center;"><%# Eval("PaidAmount")%></td>
                                    <td style="text-align: center;"><%# Eval("checkDate")%></td>
                                    <td style="text-align: center;"><%# Eval("CheckNumber")%></td>
                                    <td style="text-align: center;"><%# Eval("Location")%></td>
                                    <td style="text-align: center;"><%# Eval("PayerName")%></td>
                                    <td style="text-align: center;"><%# Eval("PostDate")%></td>

                                </tr>
                            </tbody>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        ###End###
        ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
    </form>
</body>
</html>
