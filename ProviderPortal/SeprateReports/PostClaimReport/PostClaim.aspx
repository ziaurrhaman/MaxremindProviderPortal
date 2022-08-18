<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProviderPortal/BillingMaster.master" CodeFile="PostClaim.aspx.cs" Inherits="ProviderPortal_SeprateReports_PostClaimReport_PostClaim" %>


<asp:Content runat="server"  ContentPlaceHolderID="head">
    <link href="postclaim.css" rel="stylesheet" />

    <script src="postclaim.js"></script>
    <link href="../commonReports.css" rel="stylesheet" />
    <script src="../commonReports.js"></script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <div class="PostClaimFilter" style="display:none">
      <table>
          <tr>
              <td>Date Type</td>
              <td><asp:DropDownList runat="server" ID="ddlDateType">
                  <asp:ListItem>Select Date Type</asp:ListItem>
                  <asp:ListItem Value="DOS">Servie Date</asp:ListItem>
                  <asp:ListItem Value="PostDate">Post Date</asp:ListItem>
                  <asp:ListItem Value="SubmissionDate">Submission Date</asp:ListItem>
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td>Location</td>
              <td>
                  <input id="txtlocation" type="text" onclick="locationtoggle(this)" />
                  <span onclick="hideCustomeddl(this)">x</span>  
                    <div id="divPracticeLocation" class="customddl div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                <div class="ddlselect">
                                    <ul id="ulMultiPracticeLocation" onchange="GetServiceProviderDropDown();">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkPracticeLocationAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptLocation">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("PracticeLocationsId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                        <span><%#Eval("Name") %></span>
                                                        <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' id="PatientId"/>
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                
                            </div>
              </td>
          </tr>
          <tr>
              <td>Place of Service</td>
              <td>
                  <input type="text" onclick="" />
                     <div id="divPlaceOfService" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                <div style="float: left; max-height: 170px; overflow-y: auto; overflow-x: hidden; width: 100%; margin-top: 1%; background: white; border: 1px solid #ccc; z-index:100;position:relative">
                                    <ul id="ulMultiPlaceOfService">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkPlaceOfServiceAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptPlaceOfService">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("POSCode") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkPlaceOfService chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                        <span><%#Eval("PlaceOfService") %></span>
                                                        <input type="hidden" value='<%#Eval("POSCode") %>' id="PatientId"/>
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                
                            </div>
              </td>
          </tr>
          <tr>
              <td>Provider</td>
              <td>
                   <div id="divReportServiceProvider" runat="server" style="padding-bottom:45px; display:none">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Provider :</span>
                     <div class="BranceInput">
                           <div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divServiceProvider');">
                                <div class="selectedText">
                                    All Providers
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;" onclick="Provider_multifunction"/></div>
                            </a>
                         <div id="divServiceProvider" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                  <div class="ddlselect maindivofddl" style="margin-top:7px !important">
                                      <ul id="ulMultiServiceProvider">
                                          <li style="float: left; width: 100%;">
                                              <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                  <input type="checkbox" id="chkServiceProviderAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                  <span>All Providers</span>
                                                  <input type="hidden" value="0" />
                                              </label>
                                          </li>
                                          <asp:Repeater runat="server" ID="rptProviders">
                                              <ItemTemplate>
                                                 
                                                  <li style="float: left; width: 100%;"  class="rpt_li">
                                                      <label name='<%#Eval("PracticeStaffId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;" class="li_label" >
                                                          <input type="checkbox" class="chkProviders chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                          <%-- changed by Asad Mehmood change Provider to Name 3/3/2020--%>
                                                          <span class="checkBoxName"><%#Eval("Name") %></span>
                                                          <%-- changed by Asad Mehmood change Provider to Name --%>
                                                          <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="ProviderId" />

                                                           <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="hdnProviderIds" />
                                                      </label>
                                                  </li>
                                              </ItemTemplate>
                                          </asp:Repeater>
                                      </ul>
                                  </div>
                              </div>
                         </div>
                     </div>
                   
                    </div>
                </div>
              </td>
          </tr>
          <tr>
              <td>Payer</td>
              <td> <div id="div1" runat="server" style="padding-bottom:45px; display:none">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Provider :</span>
                     <div class="BranceInput">
                           <div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divServiceProvider');">
                                <div class="selectedText">
                                    All Providers
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;" onclick="Provider_multifunction"/></div>
                            </a>
                         <div id="divServiceProvider" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                  <div class="ddlselect maindivofddl" style="margin-top:7px !important">
                                      <ul id="ulMultiServiceProvider">
                                          <li style="float: left; width: 100%;">
                                              <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                  <input type="checkbox" id="chkServiceProviderAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                  <span>All Providers</span>
                                                  <input type="hidden" value="0" />
                                              </label>
                                          </li>
                                          <asp:Repeater runat="server" ID="rptDenailPayerName">
                                              <ItemTemplate>
                                                 
                                                  <li style="float: left; width: 100%;"  class="rpt_li">
                                                      <label name='<%#Eval("PracticeStaffId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;" class="li_label" >
                                                          <input type="checkbox" class="chkProviders chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                          <%-- changed by Asad Mehmood change Provider to Name 3/3/2020--%>
                                                          <span class="checkBoxName"><%#Eval("Name") %></span>
                                                          <%-- changed by Asad Mehmood change Provider to Name --%>
                                                          <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="ProviderId" />

                                                           <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="hdnProviderIds" />
                                                      </label>
                                                  </li>
                                              </ItemTemplate>
                                          </asp:Repeater>
                                      </ul>
                                  </div>
                              </div>
                         </div>
                     </div>
                   
                    </div>
                </div></td>
          </tr>
          <tr>
              <td>Claim Status</td>
              <td></td>
          </tr>
          <tr>
              <td>Report Type</td>
              <td></td>
          </tr>
          <tr>
              <td>CPT</td>
              <td></td>
          </tr>
          <tr>
              <td>Files</td>
              <td></td>
          </tr>
          <tr>
              <td>Bill Dates</td>
              <td></td>
          </tr>
      </table>
  </div>
</asp:Content>