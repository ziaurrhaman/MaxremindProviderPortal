<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PatientInvoices.aspx.cs" Inherits="ProviderPortal_PatientInvoice_PatientInvoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../../Scripts/PatientInvoices.js"></script>
    <style type="text/css">
        #ddlPatientInvoices1{
            margin-top:5px;
        }
    </style>
    <h3 style="text-align: center;background: #006291;color: white;padding: 6px 0px 6px 0px;border-radius: 6px;">Patient Invoices</h3>
    <div id="divPendingInvoices" class="Tab-Content">
           <div id="chkdiv" style="float: left; padding: 2px 0 4px">
               <div>
                   <%--<asp:CheckBox id="CheckBox1" runat="server" CssClass="ChkBox"/>--%>
                   <input type="checkbox" id="CkBox" name="checkbox_1"class="ChkBox" value="RBR" onclick="FilterInvoice_RBR(0, true,this)" checked="checked"/>
                   <span>Cases Billed To Patient</span>
               </div>
              <div>
                  <%--<asp:CheckBox id="CheckBox2" runat="server" CssClass="ChkBox"/>--%>
                  <input type="checkbox" id="CkBox1" name="checkbox_1" class="ChkBox" value="RBRR" onclick="FilterInvoice(0, true, this)"/>
                   <span>All Cases</span> 
              </div>
           </div>
            <div style="float: right; padding: 2px 0 4px">
                <input type="button" value="Generate Invoices File" onclick="generateInvoiceFile(this);" style="background:#006291;border:1px solid #006291;color:white;"/>
            </div>
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
                                  <i class="fa fa-filter" style="color: #065172 ; font-size: 20px !important;" id="FilterIcon_InvoiceFiles" onclick="FilterPatientinVoice(0,true)"></i>
                            </th>
                            <th ><input type="checkbox" id="thChkHeader" class="thChk" onclick="CheckAllChk();" /></th>
                            <th><input type="text" id="txtpayerID" onkeyup="SetSearch(event,'RBR')"/> </th>                           
                            <th><input type="text" id="txtpatientName" onkeyup="SetSearch(event,'RBR')"/></th>                         
                            <th><input type="text" id="txttotalPendingAmount" onkeyup="SetSearch(event,'RBR')" /></th>
                            <%--<th><input type="text" id="txt0-30" onkeyup="SetSearch_ForInvoice(event)" /></th>
                            <th><input type="text" id="txt31-60" onkeyup="SetSearch_ForInvoice(event)" /></th>
                            <th><input type="text" id="txt61-90" onkeyup="SetSearch_ForInvoice(event)" /></th>
                            <th><input type="text" id="txt90+" onkeyup="SetSearch_ForInvoice(event)" /></th>--%>
                        </tr>
                        <tr style="display:none;" id="header_2">
                            <th>
                                  <i class="fa fa-filter" style="color: #065172 ; font-size: 20px !important;" id="FilterIconInvoiceFiles" onclick="FilterPatientinVoice(0,true)"></i>
                            </th>
                            <th ><input type="checkbox" id="thChk_Header" class="thChk" onclick="Check_AllChk();" /></th>
                            <th><input type="text" id="txtpayer_ID" onkeyup="SetSearch(event,'')"/> </th>
                            <th><input type="text" id="txtpatient_Name" onkeyup="SetSearch(event,'')" /></th>
                            <th><input type="text" id="txttotalPending_Amount" onkeyup="SetSearch(event,'')" /></th>
                        </tr>
                    </thead>
                    <tbody id="PatientInvoicesList">
                         <asp:HiddenField runat="server" ID="hdnPendingSubmissionCount" />
                        <asp:Repeater runat="server" ID="rptPatientInvoices">
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
                                    <td class="PendingAmount">
                                        <%# Eval("TotalPendingAmount") %>
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
                            <select id="ddlPatientInvoices" style="margin-top: 5px;" onchange="FilterInvoice_RBR(0,true);">
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
         <div id="divInvoiceDLG"></div>
        </div>
    <script type="text/javascript">
        //For Uncheck CheckBox if one Checkbox is checked then other checkbox is unCheck
        $('input.ChkBox').on('change', function () {
            debugger;
            $('input.ChkBox').not(this).prop('checked', false);
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

