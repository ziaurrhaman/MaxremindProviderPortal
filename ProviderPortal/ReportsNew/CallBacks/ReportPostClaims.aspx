<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportPostClaims.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ReportPostClaims" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###

          <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
          

            <div id="dialogue">

                <div class="exportSummary">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                    <span style="float: left; padding-top: 2px; margin-left: 7px">
                        <select id="ddlPS" class="custom-export-drop-down" onchange="ExportReportForSummary('Post CLaim Detail',this,'printableAreaPS');">
                            <option></option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>
                    </span>


                    <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaPS')">
                        <img src="../../Images/PrintView1.png" alt="img" /></span>

                </div>

                <%-- <div style="float:right;margin:5px;font-size:14px" >
                   <span style="float:left">
                     Total Posted Payment:
                  </span>
                  <span style="float:right;margin:0px 10px;font-weight:600">
                     <asp:Label runat="server" ID="totalcheckAmount"></asp:Label>
                    
                  </span>
              </div>
                --%>
                <div class="Grid" style="height: 400px; overflow-y: auto">
                    <div class="GridReportsSummary" id="printableAreaPS">
                        <table class="fixTable">
                            <thead>
                                <tr>
                                    <th>
                                        <span style="padding: 4px;">#</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Claim Id</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Acc No.</span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Pat Name</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">DOB</span><span></span>
                                    </th>
                                    <th class="asc HDOS">
                                        <span class="report-column-title">DOS</span><span></span>
                                    </th>
                                    <th class="asc ClmChrges">
                                        <span class="report-column-title">Charges</span><span></span>
                                    </th>
                                    <th class="asc CptCharges">
                                        <span class="report-column-title">Payments</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Amount Due</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Pri Status</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">File Name</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Insurance</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Policy Number</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title" title="Place of services">POS</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Post Date</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Sub Date</span><span></span>
                                    </th>


                                    <th class="asc">
                                        <span class="report-column-title">Location</span><span></span>
                                    </th>

                                    <th class="asc">
                                        <span class="report-column-title">Claim Status</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">CPT</span><span></span>
                                    </th>
                                </tr>

                            </thead>
                            <tbody class="checkdetailTbody DetailPostClaim">
                                <asp:Repeater runat="server" ID="rptpostlciam" OnItemDataBound="rptpostlciam_ItemDataBound">
                                    <ItemTemplate>
                                        <tr style="width: 140% !important">
                                            <td style="padding: 5px;">
                                                <%# Container.ItemIndex+1 %>
                                            </td>
                                            <td>
                                                <%# Eval("ClaimId")%>
                                            </td>
                                            <td>
                                                <%# Eval("AccountNo")%>
                                            </td>
                                            <td>
                                                <%# Eval("PatientName")%>
                                            </td>
                                            <td>
                                                <%# Eval("DateOfBirth")%>
                                            </td>
                                            <td class="DOS">
                                                <%# Eval("DOS")%>
                                            </td>

                                            <td style="text-align: right">
                                                <%# Eval("Charges", "{0:c}")%>
                                            </td>
                                            <td style="text-align: right">
                                                <%# Eval("Payments", "{0:c}")%>
                                            </td>
                                            <td style="text-align: right">
                                                <%# Eval("AmountDue", "{0:c}")%>
                                            </td>
                                            <td>
                                                <%# Eval("PrimarySubmissionStatus")%>
                                            </td>
                                            <td>
                                                <%# Eval("FileName")%>
                                            </td>
                                            <td>
                                                <%# Eval("Insurance")%>
                                            </td>
                                            <td>
                                                <%# Eval("PolicyNumber")%>
                                            </td>
                                            <td>
                                                <%# Eval("PlaceOfService")%>
                                            </td>
                                            <td>
                                                <%# Eval("PostDate")%>
                                            </td>
                                            <td><%# Eval("SubmissionDate","{0:d}")%></td>
                                            <td>
                                                <%# Eval("Location")%>
                                            </td>

                                            <td><%# Eval("ClaimStatus")%></td>

                                            <td class="proCode">
                                                <asp:Label ID="lblProcedureCode" runat="server">"<%# Eval("ProcedureCode")%>"</asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="Report_Footer rpt_footer PostClaimPagination">
                <div class="Pagination_div rpt_pagination message_box">
                    <span class="iconInfo" style="margin: 4px;"></span>
                    <label class="totalRows" style="float: left; padding-left: 10px; padding-top: 4px;"></label>
                </div>
                <div class="Reports_Rows_Per_Page PostClaimPagination" style="margin-top: 2px; float: left;">
                    <span style="float: left; margin-left: 5px; font-size: 12px; font-weight: 600; padding-top: 7px; box-sizing: border-box;">Show&nbsp;</span>
                    <span style="float: left; padding-top: 2px; margin-left: 7px; margin-right: 5px;">
                        <select id="ddlPagingPostClaimsDetail" onchange="RowsChange();">
                            <option value="10">10</option>
                            <option value="25">25</option>
                            <option value="50">50</option>
                            <option value="75">75</option>
                            <option value="100">100</option>
                            <option value="1000000">All</option>

                        </select>
                    </span><span style="float: left; padding-top: 7px; box-sizing: border-box;">&nbsp;Entries</span>
                </div>
                <div class="Pagination_div rpt_pagination PostClaimPagination">


                    <div class="PageButton">
                        <span class="Report_Footer_child btn_report" onclick="LastPage()" title="Last"><i onclick="LastPage()" class="fas fa-angle-right"></i></span>
                        <span class="Report_Footer_child" id="Next" onclick="NextPage()"><i id="filtersubmitright" class="fas fa-angle-double-right"></i></span>

                        <label class="lblTotalPages" id="TotalPages"></label>
                        <label class="rpt-of-pagination">of</label>
                        <input class="txt_page_Number" type="text" value="1" onkeyup="PageNumOnTxt()" />
                        <span class="Report_Footer_child" onclick="PreviousPage()"><i id="filtersubmitleft" class="fas fa-angle-double-left"></i></span>
                        <span class="Report_Footer_child btn_report" onclick="FirstPage()" title="First" style="margin-top: -5px;"><i onclick="FirstPage()" class="fas fa-angle-left"></i></span>
                    </div>
                </div>
            </div>
              <input type="hidden" id="ltrTotalRows" runat="server" value="0" /> 
            <script type="text/javascript">
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                    $(".PostClaimPagination").css("display","")
                });

                function RowsChange(PageNumber, sortValue) {
                    debugger
                    if (PageNumber == undefined) {
                        PageNumber = 0
                    }

                    var paging = true;

                    FilterDetailPostClaim($("#ddlPagingPostClaimsDetail").val(), PageNumber)
                }
            </script>
           


            ###endReport###

             ###StartFilter###
        <asp:Repeater runat="server" ID="rptFilterPostlciam" OnItemDataBound="rptpostlciam_ItemDataBoundFilter">
            <ItemTemplate>



                <tr runat="server" id="ProviderNameTr" style="display: none;">
                    <td></td>
                    <td></td>
                    <td style="color: blue; cursor: pointer; font-size: 14px; width: 100%; text-decoration: underline; padding-left: 28px;" onclick="OpenDialoguePostClaim(this)">
                        <asp:Label runat="server" ID="LBLProviderName" CssClass="ProviderName"></asp:Label></td>
                    <td></td>
                    <td></td>

                </tr>
                <tr runat="server" id="ColumnsTr" style="display: none; border: 1px solid; background-color: #c9e6f3; line-height: 1.5;">
                    <td style="font-weight: 600; text-align: center; width: 20%">Procedure Code</td>
                    <td style="font-weight: 600; text-align: center; width: 20%">Frequency</td>
                    <td style="font-weight: 600; text-align: center; width: 20%">Charges</td>
                    <td style="font-weight: 600; text-align: center; width: 20%">Payments</td>
                    <td style="font-weight: 600; text-align: center; width: 20%">AR</td>
                </tr>
                <tr runat="server" id="DataRowTr" style="display: none; border: 1px solid #ccc">

                    <td style="text-align: center; width: 20%; border-right: 1px solid #ccc"><%# Eval("ProcedureCode")%></td>
                    <td style="text-align: center; width: 20%; border-right: 1px solid #ccc"><%# Eval("Frequency")%></td>
                    <td style="text-align: right; width: 20%; border-right: 1px solid #ccc"><%# Eval("Charges","{0:c}")%></td>
                    <td style="text-align: right; width: 20%; border-right: 1px solid #ccc"><%# Eval("Payments","{0:c}")%></td>
                    <td style="text-align: right; width: 20%"><%# Eval("AR","{0:c}")%></td>
                </tr>
                <tr runat="server" id="ProviderSummaryTr" style="border: 1px solid; width: 100%; background-color: #ecebeb; display: none">
                    <td style="font-weight: 600; font-size: 14px; text-align: center; width: 20%">Total</td>

                    <td style="text-align: center; width: 20%">
                        <asp:Label runat="server" ID="lblFrequency"></asp:Label></td>
                    <td style="text-align: right; width: 20%">
                        <asp:Label
                            runat="server" ID="lblCharges"></asp:Label></td>
                    <td style="text-align: right; width: 20%">
                        <asp:Label runat="server" ID="lblPayments"></asp:Label></td>
                    <td style="text-align: right; width: 20%">
                        <asp:Label
                            runat="server" ID="lblAR"></asp:Label></td>
                </tr>

            </ItemTemplate>
        </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
            <asp:HiddenField runat="server" ID="hdnPlaceOfService" />
            <asp:HiddenField runat="server" ID="hdnproviders" />
            <asp:HiddenField runat="server" ID="hdnpayer" />
            <asp:HiddenField runat="server" ID="hdnClaimStatus" />
            <asp:HiddenField runat="server" ID="hdnReportTypeLevel" />
            <asp:HiddenField runat="server" ID="hdnPOSCode" />
            <asp:HiddenField runat="server" ID="hdnFileSearchId" />
            <asp:HiddenField runat="server" ID="hdnStartDate" />
            <asp:HiddenField runat="server" ID="hdnEndDate" />
            ###END###


        </div>
    </form>
</body>
</html>
