<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThirtyPlusDaysAfterSubmission.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ThirtyPlusDaysAfterSubmission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###startReport###
        <div class="TimeSpan">
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="TimeSpan"></asp:Label>
        </div>

   <asp:Repeater ID="rptTPDAS" runat="server" >
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                        <span class="report-column-title">PatientId</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                        <span class="report-column-title">Patient Name</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Claimid');">
                                                        <span class="report-column-title">Claim Id</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'DateOfService');">
                                                        <span class="report-column-title">DOS</span><span class="filterIcon asc"></span>
                                                    </th>
                                                   
                                                    <th class="asc" onclick="SortReportList(this,'[Procedure]');" style="width:30%">
                                                        <span class="report-column-title">Procedure</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Charges');">
                                                        <span class="report-column-title">Charges</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Insurance');"style="width:17%">
                                                        <span class="report-column-title">Insurance</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Aging');">
                                                        <span class="report-column-title">Aging</span><span></span>
                                                    </th>
                                                 
                                                     <th class="asc" onclick="SortReportList(this,'CreatedDate');">
                                                        <span class="report-column-title">Post Date</span><span class="filterIcon asc"></span>
                                                    </th>
                                                     <th class="asc" onclick="SortReportList(this,'CreatedDate');">
                                                        <span class="report-column-title">Submission Date</span><span class="filterIcon asc"></span>
                                                    </th>
                                                  <%--   <th class="asc" onclick="SortReportList(this,'CreatedDate');">
                                                        <span class="report-column-title">FU DOC</span><span class="filterIcon asc"></span>
                                                    </th>
                                                     <th class="asc" onclick="SortReportList(this,'CreatedDate');">
                                                        <span class="report-column-title">Notes</span><span class="filterIcon asc"></span>
                                                    </th>
                                                </tr>--%>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Claimid")%>
                                        </td>
                                        <td>
                                            <%# Eval("DateOfService","{0:d}")%>  
                                        </td>
                                         
                                        <td>
                                            <%# Eval("[Procedure]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Charges")%>
                                        </td>
                                        <td>
                                            <%# Eval("Insurance")%>
                                        </td>
                                        <td>
                                            <%# Eval("Aging")%>
                                          <%--  <asp:Label ID="lblCharges" runat="server"></asp:Label>--%>
                                        </td>
                                     
                                           <td>
                                            <%# Eval("PostDate","{0:d}")%>  
                                        </td>
                                            <td>
                                            <%# Eval("Submissiondate","{0:d}")%>  
                                        </td>

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
     <asp:HiddenField runat="server" ID="hdnInsurance" />
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
                        Insurance: $("[id$='hdnInsurance']").val(),
                        DateType: $("[id$='hdnDateType']").val(),
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
