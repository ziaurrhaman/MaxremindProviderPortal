<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PendingTransitionClaims.aspx.cs" Inherits="ProviderPortal_PendingTransitions_PendingTransitionClaims" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <script type="text/javascript" src="../../Scripts/Rizwan/PendingTransition.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="cover">  </div> 
<h1 class="pagetitle">Claims Pending Transitions</h1> 

    <div id="divMesg" style="background-color:rgba(112, 255, 0, 0.56); margin-left:410px; width:20%; height:33px; border-radius:5px; text-align:left;display:none">
       <label style="font-size:15px;"><span>Record Updated succesfully</span></label> 
    </div>


    <div id="leftbar">

    </div>
        
                    
     <div class="Grid" id="divClaims" style="height:300px;">
                     
                                    <table>
                                        <thead>
                                            <tr>
                                                <th style="width: 2%;">
                                                    #
                                                </th>
                                                <th style="width: 10%;">
                                                    Claim No
                                                </th>
                                                <th style="width: 10%;">
                                                    Account No
                                                </th>
                                                <th style="width: 10%;">
                                                    Patient Name
                                                </th>                                                                                                                        
                                                <th style="width: 10%;">
                                                    DOS
                                                </th>
                                                <th style="width: 10%;">
                                                    Bill Date
                                                </th>
                                                <th style="width: 10%;">
                                                    Primary Insurance
                                                </th>
                                                <th style="width: 10%;">
                                                    Status
                                                </th>
                                                <th style="width: 28%;">
                                                    Reasons
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <span class="iconSearch"></span>
                                                </th>
                                                <th>
                                                    <input type="text" id="txtClaimNoFilterClaim" onkeyup="RowsChange('FilterClaims');" />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtPatientAccountFilterClaim" onkeyup="RowsChange('FilterClaims');" />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtPatientNameFilterClaim" onkeyup="RowsChange('FilterClaims');" />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtDateOfServiceFilterClaim" class="ServiceDate" onkeyup="RowsChange('FilterClaims');"  />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtBillDateFilterClaim" class="BillDate" onkeyup="RowsChange('FilterClaims');"  />
                                                </th>
                                                <th align="center">
                                                    <asp:DropDownList ID="ddlInsuranceFilterClaim" runat="server" CssClass="select" style="float: none;" onchange="RowsChange('FilterClaims');"></asp:DropDownList>
                                                </th>
                                                <th>
                                                    <asp:DropDownList ID="ddlSubmissionStatusFilterClaim" runat="server" CssClass="select" style="float: none;" onchange="RowsChange('FilterClaims');"></asp:DropDownList>
                                                </th>
                                                   <th>
                                                    <div class="dropdownMenuMultiCheckMainWrapper">
                                                        <select></select>
                                                        <div class="div-dropdown-label-wrapper" onclick="HideShowPTLReasonDropDown(this);">
                                                            <span class="custom-drop-down-label"></span>
                                                        </div>
                                                        <div class="dropdownMenuMultiCheck" style="top: 25px; width: 100%;">
                                                            <div class="div-drop-down" style="height: 150px;">
                                                                <ul id="ulPTLReasonFilterListClaim" style="text-align: left; overflow-x: hidden;">
                                                                    <li>
                                                                        <label>
                                                                            <input type="checkbox" class="chkPTLReasonsAll" onclick="SelectUnselectPTLReasons_All(this);" />
                                                                            All
                                                                        </label>
                                                                    </li>
                                                                    <asp:Repeater runat="server" ID="rptPTLReasonsClaim">
                                                                        <ItemTemplate>
                                                                            <li>
                                                                                <label>
                                                                                    <input type="checkbox" id='chkClaimPTLReasonsId<%#Eval("PTLReasonsId") %>' class="chkReason CheckReasons_RemoveingChk" onclick="SelectUnselectPTLReasons(this);" />
                                                                                    <span class="spnReason"><%#Eval("Reason")%></span>
                                                                                    
                                                                                    <input type="hidden" class="hdnPTLReasonsId" value='<%#Eval("PTLReasonsId") %>' />
                                                                                </label>
                                                                            </li>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </ul>
                                                            </div>
                                                            <div class="divBottom">
                                                                <input type="button" onclick="OkMultiCheckDropDownPTLReason(this, 'Claim');" value="OK" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbodyPTLClaim">
                                            <asp:Repeater ID="rptClaims" runat="server">  <%-- OnItemDataBound="rptClaims_ItemDataBound" --%>
                                              
                                                <ItemTemplate>
                                                    <tr <%-- onclick="PTLClaimDialog(' <%# Eval("ClaimId") %>');"--%> style="cursor: pointer;">
                                                        <td>
                                                            <i><%# Eval("ROWNUMBER")%></i>
                                                        </td>
                                                        <td>
                                                            <span><%# Eval("ClaimId")%></span>
                                                            <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                                                            <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                                                            <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                                                            <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                                                        </td>
                                                        <td>
                                                            <%# Eval("PatientId")%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Name")%>
                                                        </td>
                                                        <td style="text-align: center;" >
                                                            <%# Eval("ServiceDate", "{0:d}")%>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <%# Eval("BillDate")%>
                                                        </td>
                                                        <td>
                                                          
                                                            <%# Eval("InsName")%>
                                                        </td>
                                                        <td style="white-space: nowrap;" >
                                                            <%# Eval("SubmissionStatus")%>
                                                        </td>
                                                        <td class="tdPTLReasons">
                                                            <span><%# Eval("Reason")%></span>
                                                          <%--  <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />--%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>                                                                                   
                                        </tbody>
                                    </table>
                            
                                <div class="message">
                                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                                    <asp:HiddenField ID="hdnTotalRowsClaim" runat="server" />
                                </div>
                                <div class="pager">
                                    <div class="PageEntries">
                                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                            <select id="ddlPagingClaims" style="margin-top: 5px;" onchange="RowsChange('FilterClaims');">
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
                            </div>
                   
                
           
       
   <style>
       #cover{
    position:fixed;
    top:0;
    left:0;
    background:rgba(0,0,0,0.6);
    z-index:5;
    width:100%;
    height:100%;
    display:none;
}
   </style>

    <script type="text/javascript">

        $(document).ready(function () {
            debugger
            $("[id$='txtDateOfServiceFilterClaim'], [id$='txtBillDateFilterClaim']").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1950:2050",
                onSelect: function () {
                    RowsChange('FilterClaims');
                }
            }).mask("99/99/9999");

            GeneratePaging($("[id$='hdnTotalRowsClaim']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");

            if ($("[id$='hdnTotalRowsClaim']").val() > 0) {
                $("#divClaims .spanInfo").html("Showing " + $("#tbodyPTLClaim tr:first").children().first().html() + " to " + $("#tbodyPTLClaim tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsClaim']").val() + " entries");
            }
        });

</script>
</asp:Content>

