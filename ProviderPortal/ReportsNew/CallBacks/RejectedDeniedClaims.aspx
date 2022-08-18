<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RejectedDeniedClaims.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_RejectedDeniedClaims" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      ###startReport###
        <div class="TimeSpan" >
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="TimeSpan"></asp:Label>

         
               
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                 <span>Total Claims:</span>
                <asp:Label runat="server" ID="lblTotalClaims"></asp:Label>

                 &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                 <span>Total Patients:</span>
                <asp:Label runat="server" ID="lblTotalPatients"></asp:Label>
            </div>


          <asp:Repeater ID="rptRDC" runat="server" >
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th style="width:3%"class="AlignPayment">
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc center" onclick="SortReportList(this,'PatientId');" style="width:7%">
                                                        <span class="report-column-title">Patient Id</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc center" onclick="SortReportList(this,'PatientName');" style="width:12%">
                                                        <span class="report-column-title">Patient Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc center" onclick="SortReportList(this,'Claimid');" style="width:7%">
                                                        <span class="report-column-title">Claim Id</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc center" onclick="SortReportList(this,'DOS');" style="width:8%">
                                                        <span class="report-column-title">DOS</span><span class="filterIcon asc"></span>
                                                    </th>
                                                   
                                                    <th class="asc center" onclick="SortReportList(this,'CPTCode');" style="width:8%">
                                                        <span class="report-column-title">CPTCode</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc center" onclick="SortReportList(this,'Charges');" style="width:8%">
                                                        <span class="report-column-title">Charges</span><span class="filterIcon asc"></span>
                                                    </th>
                                                     <th class="asc center" onclick="SortReportList(this,'BilledAs');" style="width:8%">
                                                        <span class="report-column-title">Billed As</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc center" onclick="SortReportList(this,'Payer');">
                                                        <span class="report-column-title">Payer</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc center" onclick="SortReportList(this,'CheckNumber');" style="width:10%">
                                                        <span class="report-column-title">Check No.</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc center" onclick="SortReportList(this,'PaymentType');" style="width:8%">
                                                        <span class="report-column-title">Payment Type</span><span class="filterIcon asc"></span>
                                                    </th>
                                                     <th class="asc center" onclick="SortReportList(this,'SubmissionStatus');" style="width:8%">
                                                        <span class="report-column-title">Submission Status</span><span class="filterIcon asc" ></span>
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
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td class="AlignString">
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td class="AlignString"> 
                                            <%# Eval("Claimid")%>
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
                                          <td class="AlignDate">
                                            <%# Eval("[BilledAs]")%>
                                        </td>
                                        

                                        <td class="AlignString">
                                            <%# Eval("Payer")%>
                                        </td>
                                        <td class="AlignString">
                                            <%# Eval("CheckNumber")%>
                                         
                                        </td>
                                        <td class="AlignString"> 
                                            <%# Eval("PaymentType")%>
                                       
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

        <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
   
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
     <asp:HiddenField runat="server" ID="hdnPayer" />
     <asp:HiddenField runat="server" ID="hdnBilledAs" />
     <asp:HiddenField runat="server" ID="hdnCptCode" />
     <asp:HiddenField runat="server" ID="hdnClaimStatus" />
     <asp:HiddenField runat="server" ID="hdnDateType" />
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
                        Rows: $("#ddlPagingReport").val(),
                        Insurance: $("[id$='hdnPayer']").val(),
                        DateType: $("[id$='hdnDateType']").val(),
                        BilledAs: $("[id$='hdnBilledAs']").val(),
                        POSCode: $("[id$='hdnCptCode']").val(),
                        ClaimStatus: $("[id$='hdnClaimStatus']").val(),
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
