<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetInvoiceForSinglePatient.aspx.cs" Inherits="ProviderPortal_PatientInvoice_CallBacks_GetInvoiceForSinglePatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         ###Start###
        <span style="float:left;font-weight:bold;color:teal;margin-top:10px;margin-left:10px"><asp:Label runat="server" ID="lbltype"/></span>
       <div style="float: right; padding: 2px 0 4px">
           
         <input type="button" value="Generate Invoices File" onclick="generateInvoiceFile();" style="background:#439abf;border:1px solid #439abf;color:white;"/>
       </div>
       <div id="divPendingInvoices" class="Tab-Content">         
            <asp:HiddenField runat="server" ID="hdnPatientInvoicesCount" />
           <div class="Grid">
              
                <table>
                    <thead>
                        <tr>
                            <th style="width: 2%;"></th>
                            <th style="width: 2.5%;"></th>
                            <th>Patient Id
                            </th>
                            <th>Patient Name
                            </th>
                            <%--<th>Last Invoice Submitted
                            </th>--%>
                            <th>Total Pending Amount
                            </th>
                            <%--<th style="background: #138599;">0-30
                            </th>
                            <th style="background: #981399;">31-60
                            </th>
                            <th style="background: #991346;">61-90
                            </th>
                            <th style="background: #eb0d32;">90+
                            </th>--%>
                            
                        </tr>
                        <tr id="header_1">
                            <th>
                                  <%--<i class="fa fa-filter" style="color: #065172 ; font-size: 20px !important;" id="FilterIcon_InvoiceFiles" onclick="FilterPatientinVoice(0,true)"></i>--%>
                            </th>
                            <th ><input type="checkbox" id="thChkHeader" class="thChk" onclick="CheckAllChk();" /></th>
                            <th><%--<input type="text" id="txtpayerID" onkeyup="FilterSinglePatientDetail_RBR(0,true)"/> --%></th>                           
                            <th><%--<input type="text" id="txtpatientName" onkeyup="FilterSinglePatientDetail_RBR(0,true)" />--%></th>
                            <%--<th><%--<input type="text" id="txtlastInvoice" onkeyup="FilterSinglePatientDetail_RBR(0,true)" /></th>--%>
                            <th><%--<input type="text" id="txttotalPendingAmount" onkeyup="FilterSinglePatientDetail_RBR(0,true)" />--%></th>
                            <%--<th><input type="text" id="txt0-30" onkeyup="SetSearch_ForInvoice(event)" /></th>
                            <th><input type="text" id="txt31-60" onkeyup="SetSearch_ForInvoice(event)" /></th>
                            <th><input type="text" id="txt61-90" onkeyup="SetSearch_ForInvoice(event)" /></th>
                            <th><input type="text" id="txt90+" onkeyup="SetSearch_ForInvoice(event)" /></th>--%>
                        </tr>
                        <tr style="display:none;" id="header_2">
                            <th>
                                  <%--<i class="fa fa-filter" style="color: #065172 ; font-size: 20px !important;" id="FilterIconInvoiceFiles" onclick="FilterPatientinVoice(0,true)"></i>--%>
                            </th>
                            <th ><input type="checkbox" id="thChk_Header" class="thChk" onclick="Check_AllChk();" /></th>
                            <th><%--<input type="text" id="txtpayer_ID" onkeyup="FilterInvoice(0,true)"/>--%> </th>
                             <th><%--<input type="text" id="txtpatient_Name" onkeyup="FilterInvoice(0,true)" />--%></th>
                            <th><%--<input type="text" id="txtlast_Invoice" onkeyup="FilterInvoice(0,true)" />--%></th>
                            <th><%--<input type="text" id="txttotalPending_Amount" onkeyup="FilterInvoice(0,true)" />--%></th>
                            
                        </tr>
                    </thead>
                    <tbody id="PatientInvoicesList">
                         <asp:HiddenField runat="server" ID="hdnPendingSubmissionCount" />
                        <asp:Repeater runat="server" ID="rptPatientInvoices" >
                            <ItemTemplate>
                                <tr class="trPatientInvoice" id="<%#Eval("PatientId") %>">
                                    <td>
                                        <%# Eval("RowNumber") %>
                                    </td>
                                    <td id="chkbox">
                                        <input type="checkbox" class="singleCheckbox" onclick="chkSingleCheckBox();"/>
                                    </td>
                                    <td>
                                        <%# Eval("PatientId") %>
                                    </td>
                                    <td>                                        
                                        <%# Eval("PatientName") %>
                                    </td>
                                   <%-- <td>                                        
                                       
                                    </td>--%>
                                    <td class="PendingAmount">
                                        <%# Eval("TotalPendingAmount","{0:c}") %>
                                    </td>
                                    <%--<td>
                                        <%# Eval("C07") %>
                                    </td>
                                    <td>
                                        <%# Eval("C815") %>
                                    </td>
                                    <td>
                                        <%# Eval("C1621") %>
                                    </td>
                                    <td>
                                        <%# Eval("C22") %>
                                    </td>--%>
                                   
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
                            <select id="ddlPatientInvoices" style="margin-top: 5px;" onchange="OpenPatientInvoice_RBR(0,true);">
                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                            </select>
                            <select id="ddlPatientInvoices1" style="display:none;" onchange="FilterInvoice(0,true);">
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
            </div> <%--end Grid--%>
            <script>
               $(document).ready(function () {
                   //if (paging == true) {
                       //GeneratePaging($("[id$='hdnPatientInvoicesCount']").val(), $("#ddlPatientInvoices").val(), "divPendingInvoices", "FilterInvoice");
                   //}

                   //if ($("[id$='hdnPatientInvoicesCount']").val() > 0)
                   //    $("#divPendingInvoices .spanInfo").html("Showing " + $("#PatientInvoicesList tr:first").children().first().html() + " to " + $("#PatientInvoicesList tr:last").children().first().html() + " of " + $("[id$='hdnPatientInvoicesCount']").val() + " entries");
               });              
           </script>       
       </div>
        ###End###
    </div>
    </form>
</body>
</html>
