<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsuranceEnrollment.aspx.cs" Inherits="ProviderPortal_InsuranceEnrollment_InsuranceEnrollment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         ###StartInsuEnrollment###
         <script type="text/javascript">
             $(document).ready(function () {
         
                 GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingenrollment").val(), "divEnrolllment", "FilterInsuranceEnrollment");
                 if ($("[id$='hdnTotalRows']").val() > 0) {
                     $("#divEnrolllment .spanInfo").html("Showing " + $("#tbInsuranceEnrollment tr:first").children().first().html() + " to " + $("#tbInsuranceEnrollment tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
                 }
             });

        </script>
    <div>
   <div class="WidgetMainContent"> 
    <div class="widget">
      <div class="widgettitle">
        EDI/ERA User      
      </div>
   </div>
   <div id="divEnrolllment">
    <div class="Grid">
        <table >
            <thead>
                <tr>
                    <th>#</th>
                    <th>PayerId</th>
                    <th>Insurance Name</th>
                    <th>Claims</th>
                    <th>Eligibility</th>
                    <th>ERAs</th>
                    <%--<th class="tdaction">Action</th>--%>
                </tr>
                <tr>
                    <th><i class="fa fa-filter" style="color: #065172 ; font-size: 20px !important;" id="FilterIcon" onclick="FilterInsuranceEnrollment(0, true)"></i></th>
                    <th><input type='text' class='txtpayerid' onkeyup="SetSearchIE(event)" /></th>
                    <th><input type='text' class='txtinsurancename' onkeyup="SetSearchIE(event)"/></th>
                    <th><%--<input type='text' class='txtclaims' />       --%></th>
                    <th><%--<input type='text' class='txtEligibililty' /> --%></th>
                    <th><%--<input type='text' class='txtEras' />         --%></th>
                    <%--<th class="tdaction"></th>--%>
                </tr>
            </thead>
            <tbody id="tbInsuranceEnrollment" class="tbInsuranceEnrollment">
                <asp:Repeater runat="server" ID="rptInsuranceEnrollment" OnItemDataBound="rptInsuranceEnrollment_ItemDataBound">
                   <ItemTemplate>
                    <tr>
                        <td><%#Eval("RowNumber")%></td>
                        <td><%#Eval("PayerId")%></td>
                        <td class="tdInsuranceName"><%#Eval("InsuranceName")%></td>
                         <td title="<%#Eval("notes") %>"><span runat="server" id="spnclaimstatus" class="spnstatus"><%#Eval("ClaimStatus")%></span></td>
                        <td title="<%#Eval("notes") %>"><span runat="server" id="spnEligibilitystatus" class="spnstatus"><%#Eval("EligibilityStatus")%></span></td>
                        <td title="<%#Eval("notes") %>"><span runat="server" id="spnErastatus" class="spnstatus"><%#Eval("ERAStatus")%></span></td>
                        <%--<td class="tdaction">
                            <img src="../../Images/edit.png" style="cursor: pointer"  title="Edit" onclick="btnEditClick(this)"   alt="" />
                            <img src="../../Images/delete.png" style="cursor:pointer;" title="Delete" onclick="btnDeleteClick(this)" alt="" />
                        </td>--%>
                                 
                           <div style="display:none">
                              <span class="spnInsuranceEnrollmentId"> <%#Eval("InsuranceEnrollmentId")%></span>
                              <span class="spnInsuranceId"> <%#Eval("InsuranceId")%></span>
                              <span class="spnClaimStatusId"> <%#Eval("ClaimStatusId")%></span>
                              <span class="spnEligibilityStatusId"> <%#Eval("EligibilityStatusId")%></span>
                              <span class="spnERAStatusId"> <%#Eval("ERAStatusId")%></span>
                              <span class="spnnotes"> <%#Eval("notes")%></span>
                          </div>

                        
                    </tr>
                       </ItemTemplate> 
                </asp:Repeater>
                
            </tbody>
              
        </table>
         <div class="message">
                                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                                </div>
         <div class="pager">
                                    <div class="PageEntries">
                                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                            <select id="ddlPagingenrollment" style="margin-top: 5px;" onchange="RowsChange('FilterInsuranceEnrollment');">
                                                <option value="10">10</option>
                                                <option value="25">25</option>
                                                <option value="50">50</option>
                                                <option value="75">75</option>
                                                <option value="100">100</option>
                                            </select>
                                        </span><span style="float: left;">&nbsp;entries</span>
                                    </div>
                                    <div class="PageButtons">
                                        <ul style="float: right; margin-right: 15px;">
                                        </ul>
                                    </div>
                                </div>

        <div class="divtotalrows">
        <asp:HiddenField runat="server" ID="hdnTotalRows" />
            </div>
    </div>
         </div>
                    </div>
    </div>
        ###EndInsuEnrollment###
    </form>
</body>
</html>
