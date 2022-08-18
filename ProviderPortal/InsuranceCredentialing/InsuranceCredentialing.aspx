<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsuranceCredentialing.aspx.cs" Inherits="ProviderPortal_InsuranceCredentialing_InsuranceCredentialing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

          ###StartInsuCredential###
      <script src="../../../Scripts/InsuranceCredentialing.js" type="text/javascript"></script>
         <script src="../../Scripts/InsuranceDocuments.js" type="text/javascript"></script>
            <script type="text/javascript">
                $(document).ready(function () {

                    var dateOfBirthMin = new Date();
                    dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);
                    $(".date").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        maxDate: new Date(),
                        yearRange: "-110:+0",
                        onSelect: function (date, obj) {
                            FilterPostClaimGrid(0, true);
                        }
                    }).mask("99/99/9999");


                    $("#txtEffectiveDate, #txtStartDate").datepicker({
                        changeMonth: true,
                        changeYear: true,

                        //maxDate: new Date(),
                        //yearRange: "-110:+0",
                        onSelect: function (date, obj) {
                            FilterInsuranceCredentialingGrid(0, true);
                        }
                    }).mask("99/99/9999");

                    GeneratePaging($("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val(), $("#ddlInsuranceCredentialingGrid").val(), "divContainer", "FilterInsuranceCredentialingGrid");
                    if ($("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val() > 0) {

                        $("#divContainer .spanInfo").html("Showing " + $("#tbodyGrid tr:first").children().first().html() + " to "
                           + $("#tbodyGrid tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val() + " entries");
                    }

                });

        </script>
      
    
         
      

             <div class="widget">
       <div class="widgettitle">
        Insurance Credentialling
        <span style="display:none" class="spnButton spnButtonTopRight" title="Add New" onclick="AddEditInsuranceCredentialing('Add')">Add New <i class="fa fa-user-plus"></i></span>
    </div>
           </div>

           
        

       
          <div  class="Grid" id="divContainer">
          <table class="table">
                                           <thead>
                                                <tr>
                                                    <th style="width:2%">
                                                        <span class="report-column-title" style="width:2%">#</span><span></span>
                                                    </th>
                                                 
                                                    <th style="width:11%">
                                                        <span class="report-column-title">Insurance Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th style="width:6%;">
                                                        <span class="report-column-title">Type</span><span></span>
                                                    </th>
                                                    <th style="width:5%;">
                                                        <span class="report-column-title">Source</span><span></span>
                                                    </th>
                                                    <th style="width:8%;">
                                                        <span class="report-column-title">NPI</span><span></span>
                                                    </th>
                                                    <th style="width:8%;">
                                                        <span class="report-column-title">Tax Id</span><span></span>
                                                    </th>
                                                    <th style="width:6%;">
                                                        <span class="report-column-title">Provider</span><span></span>
                                                    </th>
                                                    <th style="width:8%;">
                                                        <span class="report-column-title">Start<br />Date</span><span></span>
                                                    </th>
                                                    <th style="width:8%;">
                                                        <span class="report-column-title">Effective<br />Date</span><span></span>
                                                    </th>                                                    
                                                     
                                                     <th style="width:12.5%;">
                                                        <span class="report-column-title">Group PTAN</span><span></span>
                                                    </th>
                                                    <th style="width:12.5%;">
                                                        <span class="report-column-title">Provider PTAN</span><span></span>
                                                    </th>
                                                    <th style="width:10%;">
                                                        <span class="report-column-title">SSN</span><span></span>
                                                    </th>
                                                    <th style="width:10.5%;">
                                                        <span class="report-column-title">Remarks</span><span></span>
                                                    </th>
                                           
                                              
                                                </tr>
                                               <tr>
                                                   <th>
                                                     <i class="fa fa-filter" style="color: #065172 ; font-size: 20px !important;" id="FilterIconbtn" onclick="FilterInsuranceCredentialingGrid(0, true)"></i>
                                                    </th>
                                                    <th> 
                                                       
                                                        <input type="text" id="txtInsuranceNameSearch"  onkeyup="InsuranceCredentialingSetSearch(event)"/>
                                                    </th>
                                                    <th>
                                                       <select id="ddlStatusSearch" onchange="FilterInsuranceCredentialingGrid(0,true)">
                                                           <option value="">All</option>
                                                            <option value="Enrolled">Enrolled</option>
                                                            <%--<option value="Not Enrolled">Not Enrolled</option>--%>
                                                            <option value="Out of Network">Out of Network</option>
                                                          <%--  <option value="In network">In Network</option>--%>
                                                            <option value="In Process">In Process</option>
                                                            <option value="Pending With Insurance">Pending With Insurance</option>
                                                            <option value="Pending Response from Practice">Pending Response from Practice</option>
                                                        </select>                                               
                                                    </th>
                                                    <th>  
                                                        <select id="ddlSourceSearch" onchange="FilterInsuranceCredentialingGrid(0,true)">
                                                            <option value="">All</option>
                                                            <option value="Group">Group</option>
                                                            <option value="Solo">Solo</option>                                                            
                                                        </select>                                                    
                                                        <%--<input  type="text" id="txtSourceSearch"  onkeyup="InsuranceCredentialingSetSearch(event)"/>--%>
                                                    </th>
                                                    <th>
                                                         <input  type="text" id="txtNipIdSearch" onkeyup="InsuranceCredentialingSetSearch(event)" />
                                                    </th>
                                                    <th>
                                                        <input  type="text" id="txtTaxIdSearch" onkeyup="InsuranceCredentialingSetSearch(event)" />
                                                    </th>
                                                   <th>
                                                         <input  type="text" id="txtProviderSearch" onkeyup="InsuranceCredentialingSetSearch(event)" />
                                                    </th>
                                                   <th>
                                                        <input  type="text" id="txtStartDate" onkeyup="InsuranceCredentialingSetSearch(event)" />
                                                    </th>
                                                    <th>
                                                        <input  type="text" id="txtEffectiveDate" onkeyup="InsuranceCredentialingSetSearch(event)" />
                                                    </th>                                                                                                    
                                                   <th><input  type="text" id="txtGroupId" onkeyup="InsuranceCredentialingSetSearch(event)" /></th>
                                                   <th><input  type="text" id="txtProviderPTAN" onkeyup="InsuranceCredentialingSetSearch(event)" /></th>
                                                   <th></th>
                                                   <th> <input  type="text" id="txtRemarksSearch" onkeyup="InsuranceCredentialingSetSearch(event)" /></th>
                                                   
                                               </tr>
                                            </thead>
                                            <tbody id="tbodyGrid">
                                 <asp:Repeater ID="rptInsuranceCredentialing" runat="server">
                                <ItemTemplate>
                                    <tr class="Insurance">
                                       
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td style="font-size:11px">
                                            <%# Eval("Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Status")%>
                                        </td>
                                        <td style="word-wrap:break-word">
                                           <%# Eval("Source")%>
                                        </td>
                                      
                                        <td>
                                           <%# Eval("NPI")%>
                                        </td>
                                        <td>
                                           <%# Eval("TaxId")%>
                                        </td>
                                        <td>
                                           <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                           <%# Eval("StartDate")%>
                                        </td>
                                        <td>
                                           <%# Eval("TargetDate")%>
                                        </td>                                                                             
                                         <td>
                                           <%# Eval("GroupId")%>
                                        </td>
                                         <td>
                                           <%# Eval("ProviderPTAN")%>
                                        </td>
                                         <td>
                                           <input type="password" class="Password" value="<%# Eval("SSN")%>" style="background: none !important;border: none;box-shadow: none;font-size:10px;font-weight:bold" disabled="disabled"> 
                                             <span style="margin-left: 73px;margin-top: -16px;float: left;"><i  id="pass-status" class="fa fa-eye" title="View SSN" onclick="viewSSN(this)"></i></span>                                        
                                        </td>
                                         <td>
                                           <%# Eval("Remarks")%>
                                        </td>
                                       

                                    </tr>
                                </ItemTemplate>
                                 </asp:Repeater>
                                    </tbody>
                                </table>
          <div class="message">
                                        <span class="iconInfo" style="margin: 7px;"></span>
                                        <span class="spanInfo"></span>
                                    </div>
          <div class="pager">
                                        <div class="PageEntries">
                                            <span style="float: left;">
                                                <select id="ddlInsuranceCredentialingGrid" style="margin-top: 5px;" onchange="RowsChange('FilterInsuranceCredentialingGrid');">
                                                    <option value="10">10</option>
                                                    <option value="25">25</option>
                                                    <option value="50">50</option>
                                                    <option value="75">75</option>
                                                    <option value="100">100</option>
                                                     <option value="100000">All</option>
                                                </select>
                                            </span><span style="float: left;">&nbsp;Entries per page</span>
                                        </div>
                                        <div class="PageButtons">
                                            <ul style="float: right; margin-right: 15px;">
                                            </ul>
                                        </div>
                                    </div>
    </div>
        <asp:HiddenField runat="server" ID="hdnTotalRowsInsuranceCredentialingGrid" />

    <div id="divAddEditInsurCred"></div>

  
   ###EndInsuCredential###

    </form>
</body>
</html>
