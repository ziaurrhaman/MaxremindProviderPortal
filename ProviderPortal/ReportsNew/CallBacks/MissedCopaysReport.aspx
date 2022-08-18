<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MissedCopaysReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_MissedCopaysReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###startReport###
               <asp:Repeater ID="rptMissedCopays" runat="server">
                               
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table style="text-align:center;">
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'EncounterId');">
                                                        <span class="report-column-title">Encounter Id</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'servicedate');">
                                                        <span class="report-column-title">Service Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PostDate');">
                                                        <span class="report-column-title">Post Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                        <span class="report-column-title">Patient Id</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                        <span class="report-column-title">Patient Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PrimaryInsurance');">
                                                        <span class="report-column-title">Primary Insurance</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Copay');">
                                                        <span class="report-column-title">Copay</span><span></span>
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
                                            <%# Eval("EncounterId")%>
                                        </td>
                                        <td>
                                            <%# Eval("ServiceDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("PostDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                            <%# Eval("PrimaryInsurance")%>
                                        </td>
                                        <td>
                                            <%# Eval("Copay")%>
                                        </td>
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


         <script type="text/javascript">
             var Rows1 = "";
             function RowsChange(PageNumber) {
                 debugger;
                 var params;
                 pageNumber = PageNumber;
                 Rows1 = $("#ddlPaging").val();
                 var DateFrom = $("[id$='hdnDateFrom']").val();
                 var DateTo = $("[id$='hdnDateTo']").val();
              
                 var paging = true;

                 if (_selectedReport_Filter != "") {
                     params = {
                         DateFrom: DateFrom,
                         DateTo: DateTo,
                       
                         Rows: Rows1,
                         PageNumber: pageNumber,
                         //SortBy: _SortBy + " " + _SortByValue,
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
