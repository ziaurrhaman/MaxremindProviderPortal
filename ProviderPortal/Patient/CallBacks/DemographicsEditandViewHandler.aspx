<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemographicsEditandViewHandler.aspx.cs" Inherits="ProviderPortal_Patient_CallBacks_DemographicsEditandViewHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        ###startPatientSearch###
           <asp:Repeater ID="rptPatientSearch" runat="server">
           <ItemTemplate>

                  <tr onclick="clickPatient(this);" >
                             <td>
                               <%#Eval("PatientId") %>
                            </td>
                            <td>
                               <%# Eval("FullName") %>
                            </td>
                            
                        </tr>

           </ItemTemplate>
          
        </asp:Repeater>
        ###endPatientSearch###

        ###startViewDemographics###
        <asp:HiddenField ID="hdnFinancialGuarantorIdView" runat="server"  />  
         <div class="box-content" id="viewDemographics" style="background: #fff">
                         
<%--uploaded file name Div--%>
                                 <div class="patient-widget-double-outer">
                               <div class="patient-widget">
                                <%-- <div class="patient-widget-title">
                                 Uploaded File Name:

                                     </div>--%>
                                 <div class="patient-widget-content">
                                 
                                     <span> Uploaded File Name:</span>
                                             
                                     
                                    
                                            <asp:Label ID="lbluploadedfileName" runat="server" CssClass="InfoLabel"></asp:Label>
                                           
                                
                                      </div>
                             </div>
                                  </div>
                                                          
<%--General Information Div--%>

                                 <div  class="patient-widget-outer" style="clear:left">
                             <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 General Information

                                     </div>
                                 <div class="patient-widget-content">
                                      <table ">
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">Last Name: </span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblLastName" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trMiddleName" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Middle Name:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblMiddleName" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" style="width: 40%;">
                                            <span class="spanTitle">First Name: </span>
                                        </td>
                                        <td class="tdDataField" style="width: 60%;">
                                            <asp:Label ID="lblFirstName" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">Date of Birth:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblDOBPatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">Time of Birth:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblTimeOfBirthPatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">SSN:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblSSN" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">Gender:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblGenderPatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">Marital Status:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblMaritalStatusPatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trRace" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Race:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblRace" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trEthnicity" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Ethnicity:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblEthnicity" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trPreferredLanguage" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Preferred Language:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblLanguage" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                  <%--  <tr id="trCommunicationBarrier" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Communication Barriers:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblCommunicationBarrier" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                                </div>
                             </div>
                                 </div>
 <%--Address Information Div--%>                           
                               <div class="patient-widget-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 Address Information

                                     </div>
                                 <div class="patient-widget-content">
                                     <table >
                                    <tr>
                                        <td class="tdLabel" style="width: 30%;">
                                            <span class="spanTitle">Address:</span>
                                        </td>
                                        <td class="tdDataField" style="width: 70%;">
                                            <asp:Label ID="lblAddressPatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">Address Type:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblAddressType" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">City:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblCityPatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trState" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">State:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblStatePatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">ZIP:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblZipPatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trHomePhone" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Home Phone:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblHomePhonePatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trCell" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Cell:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblCellPatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trWorkPhone" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Work Phone:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblWorkPhonePatient" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trExt" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Ext:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblExt" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trEmail" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">E-mail:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblEmail" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trCCP" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">CCP:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblCCP" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                             </div>
                                  </div>
 <%-- Financial Gurantor Div--%> 
                              <div class="patient-widget-outer" style="margin-top:-55px;">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 Financial Gurantor

                                     </div>
                                 <div class="patient-widget-content">
                                        <table>
                                        <tr id="trRelationship" runat="server">
                                            <td class="tdLabel">
                                                <span class="spanTitle">Relationship:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblRelationship" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trGuarantor" runat="server">
                                            <td class="tdLabel" style="width: 35%;">
                                                <span class="spanTitle">First Name:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblGuarantorFirstName" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr12" runat="server">
                                            <td class="tdLabel" style="width: 35%;">
                                                <span class="spanTitle">Last Name:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblGuarantorLastName" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                             </div>
                                  </div>
<%-- Emergency Contact Div--%>
                             <div class="patient-widget-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                Emergency Contact

                                     </div>
                                 <div class="patient-widget-content">
                                           <table>
                                        <tr id="trEmergencyContact" runat="server">
                                            <td class="tdLabel" style="width: 35%;">
                                                <span class="spanTitle">Name:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblEmergencyContactName" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trEmergencyRelationship" runat="server">
                                            <td class="tdLabel">
                                                <span class="spanTitle">Relationship:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblEmergencyRelationship" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trEmergencyContactNo" runat="server">
                                            <td class="tdLabel">
                                                <span class="spanTitle">Contact No:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblEmergencyContactNo" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                             </div>
                                  </div>
<%-- Disability Death Div--%>
                             <div class="patient-widget-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                  Disability/Death:

                                     </div>
                                 <div class="patient-widget-content">
                                           <table >
                                        <tr id="trDisabilityDate" runat="server">
                                            <td class="tdLabel" style="width: 35%;">
                                                <span class="spanTitle">Disability Date:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblDisabilityDate" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trDeathDate" runat="server">
                                            <td class="tdLabel">
                                                <span class="spanTitle">Death Date:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblDeathDate" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trCauseOfDeath" runat="server">
                                            <td class="tdLabel">
                                                <span class="spanTitle">Cause Of Death:</span>
                                            </td>
                                            <td class="tdDataField">
                                                <asp:Label ID="lblCauseOfDeath" runat="server" CssClass="InfoLabel"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                             </div>
                                  </div>

<%-- WebAccount Div--%>
                             <div class="patient-widget-double-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 Web Account
                                      <asp:CheckBox ID="CheckBox1" runat="server" Style="margin-left: 88px; font-weight: 100;" Text="IsActive Web account" enabled="false"/>
                                     </div>
                                 <div class="patient-widget-content">
                                             
                                                        
                                                            
                                                                <span class="spanTitle">User Name: </span>
                                                            
                                                                     <asp:Label ID="lblPatientUserName" runat="server" CssClass="InfoLabel"></asp:Label>
                                                            
                                                                                                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            
                                </div>
                             </div>
                                  </div>
                              
 <%-- Pharmacy Div--%>
                             <div class="patient-widget-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 Pharmacy

                                     </div>
                                 <div class="patient-widget-content">
        <table style="width: 100%">
                                    <tr>
                                        <td class="tdLabel" style="width: 35%;">
                                            <span class="spanTitle">Pharmacy Name:</span>
                                        </td>
                                        <td>
                                            <div class="PharmacynameScroll-x">
                                            <asp:Label ID="lblPharmacyInfo"  runat="server" CssClass="InfoLabel"></asp:Label>
                                            </div>
                                                <div style="float: left;">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                             </div>
                                  </div>

</div>
        
        ###endViewDemographics###
        

        ###startEditDemographics###
        <script>
            $(".phone").mask("(999) 999-9999")
        </script>
          <input id="hdnNCPDP" runat="server" type="hidden" />
        
         <asp:HiddenField ID="hdnPatientNCPDP" runat="server"  />
        <asp:HiddenField ID="hdnFinancialGuarantorIdEdit" runat="server"  />
         <div class="box-content" id="EditDemographics" style="background: #fff; ">
                         
<%--uploaded file name Div--%>
                                 <div class="patient-widget-double-outer">
                               <div class="patient-widget">
                                 
                                 <div class="patient-widget-content">
                                 
                                 <div style="float:left;width:100%;margin-bottom:8px;">
                                    <span style="margin-bottom:10px"><b>Uploaded File:</b></span><input id="chkIsfile" type="checkbox" />
                                    <input id="txtFilename" style="width:70% ; " runat="server" type="text" />
                                       <asp:HiddenField ID="hdnUploadedFilesID" runat="server" />  
                                </div>
                              

                                  <div id="divSearchFile"  style="width: 464px;margin-left:105px; top:100px; height: 203px; position: absolute ;display: none; background-color: #fff; z-index: 999; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto;">
                                                        <div class="Grid" style="width: 99%; height: 300px;">
                                                            <div id="FileNameSearchedList"></div>
                                                             
                                                        </div>
                                                    </div>
                                
                                      </div>
                             </div>
                                  </div>
                                                          
<%--General Information Div--%>

                                 <div  class="patient-widget-outer" style="clear:left">
                             <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 General Information

                                     </div>
                                 <div class="patient-widget-content">
                                     <table >
                                                      
                                         <tr>
                                                            <td class="tdLabel" style="width:28%">
                                                                <span class="spanTitle">Last Name: </span><span class="spnError">*</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtLastName" maxlength="25" onkeypress="return ValidateCharacters(event)"
                                                                    class="required" runat="server" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr1" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Middle Name:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtMiddleName" maxlength="25" onkeypress="return ValidateCharacters(event)"
                                                                    runat="server" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel" ">
                                                                <span id="Span36" class="spanTitle">First Name: </span><span class="spnError">*</span>
                                                            </td>
                                                            <td class="tdDataField" ">
                                                                <input id="txtFirstName" maxlength="25" onkeypress="return ValidateCharacters(event)"
                                                                    class="required" runat="server" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Date of Birth:</span><span class="spnError">*</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtDOB" runat="server" class="DOBdate required IsDate" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Birth Time:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                               <div>
                                                                 <input type="text" id="txtTimeOfBirth" class="time" runat="server"  />
                                                                   </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">SSN:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtSSN" onkeypress="return ValidateNumber(event)" maxlength="9"
                                                                    runat="server" type="text" class="txtSSN" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Gender:</span><span class="spnError">*</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="required">
                                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Marital Status:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <asp:DropDownList ID="ddlMaritalStatus" runat="server">
                                                                    <asp:ListItem Value="Single">Single</asp:ListItem>
                                                                    <asp:ListItem Value="Married">Married</asp:ListItem>
                                                                       <asp:ListItem Value="widowed">widowed</asp:ListItem>
                                                                    <asp:ListItem Value="Divorced">Divorced</asp:ListItem>
                                                                    <asp:ListItem Value="other">other</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr2" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Race:</span>
                                                            </td>
                                                           <td><asp:DropDownList id="ddlRace" runat="server"/></td>
                                                        </tr>
                                                        <tr id="tr3" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Ethnicity:</span>
                                                            </td>
                                                            <td class="tdDataField" style="">
                                                             
                                                                <asp:DropDownList id="ddlEthnicity" runat="server"/>

                                                            </td>
                                                        </tr>
                                                        <tr id="tr4" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle"> Language :</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <asp:DropDownList ID="ddlPreferredLanguage" AppendDataBoundItems="true" runat="server">
                                                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Urdu</asp:ListItem>
                                                                    <asp:ListItem Value="2">English</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                </div>
                             </div>
                                 </div>
 <%--Address Information Div--%>                           
                               <div class="patient-widget-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 Address Information

                                     </div>
                                 <div class="patient-widget-content">
                                    <table >
                                                        <tr>
                                                            <td class="tdLabel" style="width: 30%;">
                                                                <span class="spanTitle">Address:</span><span class="spnError">*</span>
                                                            </td>
                                                            <td class="tdDataField" style="width: 70%;">
                                                                <input id="txtAddress" maxlength="100" runat="server" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Address Type:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <asp:DropDownList ID="ddlAddressType" runat="server">
                                                                    <asp:ListItem Value="Residential">Residential</asp:ListItem>
                                                                    <asp:ListItem Value="Business">Business</asp:ListItem>
                                                                    <asp:ListItem Value="Mailing">Mailing</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Zip:</span><span class="spnError">*</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtZip" maxlength="9" onkeypress="return ValidateNumber(event)"
                                                                    runat="server" type="text" onkeyup="getZipCityState(this,'txtZip','txtCity','ddlState');" class="zip" />
                                                                <div class="inline-search-wrapper" style="top: 75px; width: 230px;">
                                                                    <div class="divZipCityResult" style="width: 99%;">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span id="Span13" class="spanTitle">City:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtCity" maxlength="25" runat="server" type="text" disabled="disabled" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr5" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">State:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <asp:DropDownList ID="ddlState" runat="server" Enabled="false">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr6" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Home Phone:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtHomePhone" maxlength="16" runat="server" type="text" class="phone" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr7" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Cell:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtCell" maxlength="16" runat="server" type="text" class="phone" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr8" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Work Phone:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtWorkPhone" maxlength="16" runat="server" type="text" class="phone" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr9" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Ext:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtExt" runat="server" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr10" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">E-mail:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtEmail" maxlength="50" runat="server"
                                                                    type="text" class="validateEmail" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr11" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">CCP:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <asp:DropDownList ID="ddlCCP" runat="server" onchange="OnCCPChange();">
                                                                    <asp:ListItem Enabled="false" Value=""></asp:ListItem>
                                                                    <asp:ListItem Value="NotSpecified">Not Specified</asp:ListItem>
                                                                    <asp:ListItem Value="Email">Email</asp:ListItem>
                                                                    <asp:ListItem Value="Phone">Phone</asp:ListItem>
                                                                    <asp:ListItem Value="Letter">Letter</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                </div>
                             </div>
                                  </div>
 <%-- Financial Gurantor Div--%> 
                              <div class="patient-widget-outer" style="margin-top:-55px;">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 Financial Gurantor

                                     </div>
                                 <div class="patient-widget-content">
                                       <table style="width: 100%" class="tblContent">
                                                        <tr id="tr13" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Relationship:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <asp:DropDownList ID="ddlRelationship" AppendDataBoundItems="true" runat="server" onchange="FinancialGuarantorChange()">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="Self">Self</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel" style="width: 30%;">
                                                                <span class="spanTitle">First Name:</span>
                                                            </td>
                                                            <td class="tdDataField" style="width: 70%;">
                                                                <input id="txtGuarantorFirstName" disabled="disabled" class="Guarantor" runat="server" type="text" />
                                                                <img src="../../Images/SmallSearch.gif" id="GS" onclick="FinancialGuarantorSearch()" style="margin: 5px 0 0 5px; display: none" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Last Name:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtGuarantorLastName" class="Guarantor" disabled="disabled" runat="server" type="text" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                </div>
                             </div>
                                  </div>
<%-- Emergency Contact Div--%>
                             <div class="patient-widget-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                Emergency Contact

                                     </div>
                                 <div class="patient-widget-content">
                                      <table>
                                                        <tr id="tr14" runat="server">
                                                            <td class="tdLabel" style="width: 35%;">
                                                                <span class="spanTitle">Name:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtEmergencyContactName" onkeypress="return ValidateCharacters(event)"
                                                                    maxlength="25" runat="server" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr15" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Relationship:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <asp:DropDownList ID="ddlEmergencyRelationship" onchange="setRequiredValidation(this, 'txtEmergencyContactName')" AppendDataBoundItems="true" runat="server">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr16" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Contact No:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtEmergencyContact" maxlength="16" runat="server" type="text" class="phone" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                </div>
                             </div>
                                  </div>
<%-- Disability Death Div--%>
                             <div class="patient-widget-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                  Disability/Death:

                                     </div>
                                 <div class="patient-widget-content">
                                       <table style="width: 100%">
                                                        <tr id="tr17" runat="server">
                                                            <td class="tdLabel" style="width: 35%;">
                                                                <span class="spanTitle">Disability Date:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtDisabilityDate" class="date IsDate" runat="server" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr18" runat="server">
                                                            <td class="tdLabel">
                                                                <span class="spanTitle">Death Date:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtDeathDate" runat="server" class="date IsDate" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr19" runat="server">
                                                            <td class="tdLabel">
                                                                <span id="titCauseOfDeath" class="spanTitle">Cause Of Death:</span>
                                                            </td>
                                                            <td class="tdDataField">
                                                                <input id="txtCauseOfDeath" maxlength="15" runat="server" type="text" onblur="setRequiredValidation(this, 'txtDeathDate')" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                </div>
                             </div>
                                  </div>

<%-- WebAccount Div--%>
                             <div class="patient-widget-double-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 Web Account
                                      <asp:CheckBox ID="cbIsActiveWebAccount" runat="server" Style="margin-left: 88px; font-weight: 100;" Text="IsActive Web account" />
                                     </div>
                                 <div class="patient-widget-content">
                                             
                                                        
                                                            
                                                                <span class="spanTitle">User Name: </span>
                                                            
                                                            
                                                               <input id="txtPatientUserName"  style="width:15%" maxlength="20" autocompletetype="Disabled" runat="server" type="text" onblur="checkExistingUserName(this)" />
                                                            
                                                                <span class="spanTitle">Password: </span>
                                                            
                                                                <input style="width:15%" id="txtPatientPassword" maxlength="20" autocompletetype="Disabled" runat="server" type="password"  />
                                                            
                                                                <span class="spanTitle">Confirm Password: </span>
                                                            
                                                                <input style="width:15%" id="txtPatientConfirmPassword" maxlength="20" autocompletetype="Disabled" runat="server" type="password"  />
                                                                <asp:HiddenField ID="hdnPassword" runat="server" />
                                                            
                                </div>
                             </div>
                                  </div>
                              
 <%-- Pharmacy Div--%>
                             <div class="patient-widget-outer">
                               <div class="patient-widget">
                                 <div class="patient-widget-title">
                                 Pharmacy

                                     </div>
                                 <div class="patient-widget-content">
  <table style="width: 100%">
                                                        <tr>
                                                            <td class="tdLabel" style="width: 35%;">
                                                                <span class="spanTitle">Pharmacy Name:</span>
                                                            </td>
                                                            <td>
                                                                <div style="float: left;">
                                                                    <input id="txtPharmacyInfo" style="width: 120px" runat="server" type="text" disabled="disabled" />
                                                                </div>
                                                                <div style="float: left; margin-left: 7px">
                                                                    <span class="spnAdd" onclick="GetSearchBox();"></span>&nbsp;<span class="spnRemove" onclick="RemovePharmacy();"></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                </div>
                             </div>
                                  </div>

</div>
        
        ###endEditDemographics###

        ###startDemographicsClaims###
        
        <asp:Repeater ID="rptclaims" runat="server">
           <ItemTemplate>

                  <tr>
                                             <td>
                                     <%#Eval("RowNumber") %>
                            </td>
                            <td>
                               <%# Eval("ClaimId") %>
                            </td>
                            <td>
                                <%# Eval("DOS","{0:d}") %>
                            </td>
                            <td>
                                <%# Eval("ClaimTotal") %>
                            </td>
                            <td>
                                <%# Eval("AmountPaid") %>
                            </td>
                            <td>
                                <%# Eval("Adjustment") %>

                            </td>

                             <td>
                                <%# Eval("AmountDue") %>
                            </td>
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("SubmissionStatus")%>
                            </td>

                             <td>
                                <%# Eval("PTLReasons") %>
                            </td>
                           
                            
                        </tr>

           </ItemTemplate>
          
        </asp:Repeater>

        ###endDemographicsClaims###


        ###startPatientPaymentDetail###
        <table style="border:2px solid #439abf">
            <thead>
                <tr>
                    <th>DOS</th>
                    <th>CPT</th>
                    <th>Charges</th>
                    <th>Pat. Resp</th>
                    <th>Applied Amount</th>
                    <th>Rem. Balance </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptlevel2detail" >
                    <ItemTemplate>
                <tr style="text-align:right">
                    <td  style="text-align:center !important"><%# Eval("DOS","{0:d}")%></td>
                    <td  style="text-align:center !important"><%# Eval("CPTCode")%></td>
                    <td >$<%# Eval("totalcharges")%></td>
                    <td >$<%# Eval("PR")%></td>
                    <td>$<%# Eval("PaidAmount")%></td>
                    <td>$<%# Eval("RemainingBalance")%></td>
                </tr>
                  </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        ###endPatientPaymentDetail###

        ###StartPatientPaymentDeatils_Dialogue###
        <div class="Grid"  id="lvl2Grid" runat="server">
                                        <div class="gridbottom-payDetails">
                                        <div class="col-lg-3">Payment Date: <span><asp:label runat="server" ID="PDate"></asp:label></span></div>
                                        <div class="col-lg-3">Check#: <span><asp:label runat="server" ID="Check"></asp:label></span></div>
                                        <div class="col-lg-3">Check Amount: <span><asp:label runat="server" ID="CheckAmt"></asp:label></span></div>
                                    </div>
                                        <table class="data-tables">
                                            <thead>
                                                <tr>
                                                    <th>DOS</th>
                                                    <th>CPT</th>
                                                    <th>Charges</th>
                                                    <th>Patient Resp</th>
                                                    <th>Applied Amount</th>
                                                    <th>Rem. Balance</th>
                                                </tr>
                                            </thead>
                                            <tbody id="rptLevel2Details">
                                                <asp:Repeater runat="server" ID="rptlevel2detail_dialogue">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Eval("DOS","{0:d}")%></td>
                                                            <td><%# Eval("CPTCode")%></td>
                                                            <td><%# Eval("TotalCharges","{0:F2}")%></td>
                                                            <td><%# Eval("PR","{0:F2}")%></td>
                                                            <td><%# Eval("PaidAmount","{0:F2}")%></td>
                                                            <td><%# Eval("RemainingBalance","{0:F2}")%></td>
                                                        </tr>
                                                         
                                                        
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                
                                            </tbody>
                                        </table>
                                    </div>
        ###EndPatientPaymentDeatils_Dialogue###
        ###StartRightRptDialogue###
        <div id="tbody">
        <asp:Repeater runat="server" ID="RptBalanceSheet_Trn" >
                                                 <ItemTemplate>
                                                     <ul>
                                                         <li><b>Payment Date: <span>
                                                             <asp:Label runat="server" ID="checkDate" Text='<%# Eval("checkDate","{0:d}")%>'></asp:Label></span></b></li>
                                                         <li><b>Check Number:</b><asp:Label runat="server" class="CheckNumber" ID="CheckNumber" Text='<%# Eval("CheckNumber")%>'></asp:Label></li>
                                                         <li><b>Check Amount:</b>$<%# Eval("PaymentAmount")%></li>
                                                         <asp:HiddenField runat="server" ID="hdnCheckAmount" Value='<%# Eval("PaymentAmount")%>' />
                                                     </ul>
                                                 </ItemTemplate>
                                             </asp:Repeater>
            </div>
        ###EndRightRptDialogue###

           ###SRBG###


        <style>

            .fontsizechanges
            {
             
                margin: 7px;
                font-size: 12px;
                font-weight: 600;
            }
          .FRightClass{
               float: right;
               margin:5px 0px;
          }
            </style>

        <div class="Grid">

           <div class="FRightClass"><span class="fontsizechanges">Total Balance:</span> 
               <asp:Label runat="server" ID="TotalBalanceDue" CssClass="fontsizechanges"></asp:Label>

           </div>

        <table style="border:2px solid #439abf">
            <thead>
                <tr>
                    <th>Claim No</th>
                    <th>DOS</th>
                    <th>Total Charges</th>
                    <th>Amount Paid</th>
                    <th>Balance Due</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="RepBGrid" >
                    <ItemTemplate>
                <tr style="text-align:right">
                      <td  style="text-align:center !important"><%# Eval("ClaimId")%></td>
                    <td  style="text-align:center !important"><%# Eval("DOS")%></td>
  
                    <td ><%# Eval("Totalcharges","{0:C}" )%></td>
                    <td><%# Eval("AmountPaid","{0:C}")%></td>
                    <td><%# Eval("Balance","{0:C}")%></td>
                </tr>
                  </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
            </div>
        ###ERBG###

    </div>
    </form>
</body>
</html>

