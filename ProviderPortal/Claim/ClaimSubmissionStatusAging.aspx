<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimSubmissionStatusAging.aspx.cs" Inherits="ProviderPortal_Claim_ClaimSubmissionStatusAging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
       <form id="form1" runat="server">
     <div>
 
                <div>
            ###StartERAClaims###

    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <%--<link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />--%>

          <script src="../../Scripts/Rizwan/DashboardCharts.js"></script>


                    <div class="WidgetContent">
          
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">
                        <div class="PageEntries">
                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                <select id="ddlPagingClaimChecks" style="margin-top: 5px;" onchange="RowsChange('FilterClaimSubmissionAging');">
                                    <option value="10">10</option>
                                    <option value="25">25</option>
                                    <option value="50">50</option>
                                    <option value="75">75</option>
                                    <option value="100">100</option>
                                </select>
                            </span><span style="float: left;">&nbsp;entries</span>
                        </div>
                        <div class="PageButtonsReports">
                            <ul style="float: right; margin-right: 15px;">
                            </ul>
                        </div>
                        <div class="report-tools">
                            <table>
                                <tr>
                                    <td>
                                       <%-- <div class="report-export-wrapper">
                                            <asp:DropDownList ID="ddlExportTo" runat="server" CssClass="custom-export-drop-down"
                                                OnSelectedIndexChanged="ddlExportTo_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                            </asp:DropDownList>
                                            <a href="javascript:void(0)" class="custom-export-icon">
                                                <img src="../../Images/exportIconLeft.gif" style="border-style: None; height: 16px;
                                                    width: 16px;">
                                                <span style="width: 5px; text-decoration: none;"></span>
                                                <img src="../../Images/exportIconRight.gif" style="border-style: None; height: 6px;
                                                    width: 7px; margin-bottom: 5px;">
                                            </a>
                                        </div>--%>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="PrintReports();">
                                            <img src="../../Images/print.png" />
                                        </a>
                                    </td>
                                    <td>
                                        <span onclick="  setrowid();   FilterClaimSubmissionAging(0,true);" id="refreshbtn">
                                            <img src="../../Images/ReportRefresh.gif" />
                                        </span>
                                    </td>
                                    

                                </tr>
                            </table>
                        </div>       
                        <div id="Filter Criteria">
                            <span style="margin-left:39%; color:#393333; cursor:pointer" onclick="FilterCriteriaCharts('SCA');">  <img src="../../Images/edit.png" /> Filter Criteria </span>
                        </div>                  
                    </div>
                </div>
                <div class="WidgetReportContent">
                    <div style="width: 100%; float: left;">
                        <div id="divReportListing">
                            <div class="ReportGrid" style="max-height:367px;overflow-y:scroll;overflow-x:hidden; " id="Print" >
                                <table style="text-align:center">
                                    <thead>
                                  <tr>

                       <th>
                           #
                       </th>
                         <th>
                           Claim ID
                       </th>
                       <th>
                           Patient Name
                       </th>
                         <th>
                         Date Of Service
                       </th>
                         <th>
                         Post Date
                       </th>
                           
                       <th>
                           Location
                       </th>
                         <th>
                           Billing Physicion
                       </th>
                       <th>
                           Submission Status
                       </th>
                         <th>
                         Aging
                       </th>
                       <th>
                          Days
                       </th>
                     
                   </tr>  
                                    </thead>
                                    <tbody id="claimChecksList">
                                        <asp:Repeater ID="rptClaimSS" runat="server">
                                            <ItemTemplate>
                                                   <tr style="text-align:center">
                                     
                                    <td class="">
                                        <%# Eval("RowNumber")%>
                                    </td>
                                    <td class="">
                                        <%# Eval("ClaimId")%>
                                    </td>
                                     <td class="">
                                        <%# Eval("Patient")%>
                                    </td>
                                    <td class="tdCheckDate">
                                        <%# Eval("DOS", "{0:d}")%>
                                    </td>
                                     <td class="tdCheckDate">
                                        <%# Eval("PostDate", "{0:d}")%>
                                    </td>
                                       <td class="tdCheckAmount">
                                        <%# Eval("Location")%>
                                    </td>
                                    <td class="tdCheckAmount">
                                        <%# Eval("BillingPhysician")%>
                                    </td>
                                    <td class="tdCheckAmount">
                                        <%# Eval("SubmissionStatus")%>
                                    </td>
                                      <td class="tdCheckAmount">
                                        <%# Eval("Aging")%>
                                    </td>
                                    <td class="tdCheckAmount">
                                        <%# Eval("Days")%>
                                    </td>
                               
                                  
                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

        <div id="FilterCriteria"></div>
          <div id="PrintAll"></div>
    <asp:HiddenField ID="hdnStatusFiled" runat="server" />
    <asp:HiddenField ID="hdnAging" runat="server" />
    <asp:HiddenField ID="hdnReportHtml" runat="server" />
   <asp:HiddenField runat="server" ID="hdnPracticeId" />
  <asp:HiddenField runat="server" ID="hdnTotalRows" />
  
    <script type="text/javascript">
        function JumpToPageNo(event) {
            debugger;
            var a = event.which || event.keyCode;
            if (a == 13) {
                location.reload();
            }
            var pageNumber = $("[id$='txtReportPageNumber']").val();
            //pageNumber;
            FilterClaimSubmissionAging(pageNumber);
        }
        $(document).ready(function () {
            //_SortBy = 'InsuranceName';
            //_SortByValue = 'ASC';

            //   SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingClaimChecks").val(), "divReportPaging", "FilterClaimSubmissionAging");
        });





    </script>
            ###EndERAClaims###
        </div>
   
    </form>
</body>
</html>
