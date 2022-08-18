<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalInformationHandler.aspx.cs"
    Inherits="EMR_Patient_CallBacks_PersonalInformationHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartPersonalInformation###
    <script type="text/javascript">
        $(function () {
            $(".date").datepicker({ changeMonth: true,
                changeYear: true
            }).mask("99/99/9999");
        });
    </script>
    <div id="PatientInformation">
        <div id="divPatientInformationView" runat="server">
            <div id="Button" style="float: right" class="action-button-wrapper Buttons">
                <a href="javascript:void(0)" id="EditPersonalInformation" onclick="EnablePatientInformationEditing();" class="themeButton" style="padding-left: 24px;">
                    <span class="span-action-sprite span-edit-sprite"></span>Edit
                </a>
            </div>
            <div id="Content">
                <table id="tblPatientDemographicsView" class="tblPatientDemographics" width="100%">
                    <tr style="width: 100%">
                        <td style="width: 33%; vertical-align: top;">
                            <div class="header">
                                General Information
                            </div>
                            <div style="width: 100%; float: left;">
                                <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
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
                                    <tr id="trCommunicationBarrier" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Communication Barriers:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:Label ID="lblCommunicationBarrier" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width: 33%; vertical-align: top;">
                            <div class="header">
                                Address Information
                            </div>
                            <div style="width: 100%; float: left;">
                                <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
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
                        </td>
                        <td style="width: 33%; vertical-align: top;">
                            <div id="tdFinancialGuarantor" runat="server" style="width: 100%; float: left;">
                                <div class="header">
                                    Financial Guarantor
                                </div>
                                <div style="width: 100%; float: left;">
                                    <table style="width: 100%" class="tblContent">
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
                            <div id="tdEmergencyContact" runat="server" style="width: 100%; float: left;">
                                <div class="header">
                                    Emergency Contact
                                </div>
                                <div style="width: 100%; float: left;">
                                    <table style="width: 100%">
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
                            <div id="tdDisabilityDeath" runat="server" style="width: 100%; float: left;">
                                <div class="header">
                                    Disability/Death
                                </div>
                                <div style="width: 100%; float: left;">
                                    <table style="width: 100%">
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
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" colspan="2">
                            <div class="header">
                                Web Account <asp:CheckBox ID="cbIsActiveWebAccountView" Enabled="false" runat="server" style="margin-left: 88px;font-weight: 100;" Text="IsActive Web account" />
                            </div>
                            <div style="width: 50%; float: left;">
                                <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                    <tr>
                                        <td class="tdLabel" style="width: 20%;">
                                            <span class="spanTitle">User Name: </span>
                                        </td>
                                        <td class="tdDataField" style="width: 30%;">
                                            <asp:Label ID="lblPatientUserName" runat="server" CssClass="InfoLabel"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width: 33%; vertical-align: top">
                            <div class="header">
                                Pharmacy
                            </div>
                            <div style="width: 100%; float: left;">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="tdLabel" style="width: 35%;">
                                            <span class="spanTitle">Pharmacy Name:</span>
                                        </td>
                                        <td>
                                            <div style="float: left;">
                                            </div>
                                            <asp:Label ID="lblPharmacyInfo" runat="server" CssClass="InfoLabel"></asp:Label>
                                            <div style="float: left;">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="divPatientInformationEdit" style="display: none;" runat="server">
            <div class="Buttons action-button-wrapper" style="float: right" >
                <a href="javascript:void(0)" id="Button2" onclick="FinishPatientInformationEditing();" class="themeButton" style="padding-left: 24px;">
                    <span class="span-action-sprite span-cancel-sprite"> </span>Cancel 
                </a>
                <a href="javascript:void(0)" id="Button1" onclick="AddEditPatient();" class="themeButton" style="padding-left: 24px;">
                    <span class="span-action-sprite span-save-sprite"></span>Save 
                </a>
            </div>
            <div id="EditContents">
                <table id="tblPatientDemographics" class="tblPatientDemographics" width="100%">
                    <tr style="width: 100%">
                        <td style="width: 33%; vertical-align: top;">
                            <div class="header">
                                General Information
                            </div>
                            <div style="width: 100%; float: left;">
                                <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                    <tr>
                                        <td class="tdLabel">
                                            <span class="spanTitle">Last Name: </span><span class="spnError">
                                                *</span>
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
                                        <td class="tdLabel" style="width: 40%;">
                                            <span id="Span36" class="spanTitle">First Name: </span><span class="spnError">
                                                *</span>
                                        </td>
                                        <td class="tdDataField" style="width: 60%;">
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
                                            <input type="text" id="txtTimeOfBirth" runat="server" class="time" />
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
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="tr2" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Race:</span>
                                        </td>
                                        <td class="tdDataField" style="position:relative">
                                            <div style="width: 74%; float: left;">
                                                <a onclick="HideShowMenu(this);" class="drop-down-box">
                                                    <asp:Label runat="server" ID="lblRaceSelected" CssClass="selectedText" style="width: 89%;color: black;"></asp:Label>
                                                    <span class="dropDownIconMultipleCheckBox"></span>
                                                </a>
                                                <div class="dropdownMenuMultipleCheckBox" style="width: 74%;">
                                                    <div class="div-drop-down">
                                                        <asp:Repeater ID="rptRace" OnItemDataBound="rptRace_ItemDataBound" runat="server">
                                                            <ItemTemplate>
                                                                <div style="margin: 4px;" id='<%# Eval("RaceId") %>' class="divRace">
                                                                    <asp:CheckBox ID="cbRace" runat="server" Text='<%# Eval("Name") %>' class="cbRace"
                                                                        onclick="checkRace()" style="margin: 6px;" />
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                    <div class="divBottom">
                                                        <input type="button" onclick="hideDropDownDiv(this)" value="OK" style="font-size: 10px;
                                                            min-width: 65px;float: left;" />
                                                        <input type="button" onclick="ResetRace(this);" value="Cancel" style="margin-right: 5px;
                                                            font-size: 10px; min-width: 65px;" />
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="tr3" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Ethnicity:</span>
                                        </td>
                                        <td class="tdDataField" style="position:relative">
                                            <div style="width: 74%; float: left;">
                                                <a onclick="HideShowMenu(this);" class="drop-down-box">
                                                    <asp:Label runat="server" ID="lblEthnicitySelected" CssClass="selectedText" style="width: 89%;color: black;"></asp:Label>
                                                    <span class="dropDownIconMultipleCheckBox"></span>
                                                </a>
                                                <div class="dropdownMenuMultipleCheckBox" style="width: 74%;">
                                                    <div class="div-drop-down">
                                                        <asp:Repeater ID="rptEthnicity" OnItemDataBound="rptEthnicity_ItemDataBound" runat="server">
                                                            <ItemTemplate>
                                                                <div style="margin: 4px;" id='<%# Eval("EthnicityId") %>' class="divEthnicity">
                                                                    <asp:CheckBox ID="cbEthnicity" runat="server" Text='<%# Eval("Name") %>' class="cbEthnicity"
                                                                        onclick="checkEthnicity()" style="margin: 6px;" />
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                    <div class="divBottom">
                                                        <input type="button" onclick="hideDropDownDiv(this)" value="OK" style="font-size: 10px;
                                                            min-width: 65px;float: left;" />
                                                        <input type="button" onclick="ResetEthnicity(this);" value="Cancel" style="margin-right: 5px;
                                                            font-size: 10px; min-width: 65px;" />
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="tr4" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Preferred Language:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:DropDownList ID="ddlPreferredLanguage" AppendDataBoundItems="true" runat="server">
                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="tr20" runat="server">
                                        <td class="tdLabel">
                                            <span class="spanTitle">Communication Barriers:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <asp:DropDownList ID="ddlCommunicationBarriers" AppendDataBoundItems="true" runat="server">
                                                <asp:ListItem Value="" Selected="True">Select</asp:ListItem>
                                                <asp:ListItem Value="Vision">Vision</asp:ListItem>
                                                <asp:ListItem Value="Hearing">Hearing</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width: 33%; vertical-align: top;">
                            <div class="header">
                                Address Information
                            </div>
                            <div style="width: 100%; float: left;">
                                <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="tdLabel" style="width: 30%;">
                                            <span class="spanTitle">Address:</span>
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
                                            <span class="spanTitle">ZIP:</span>
                                        </td>
                                        <td class="tdDataField">
                                            <input id="txtZip" maxlength="9" onkeypress="return ValidateNumber(event)"
                                                runat="server" type="text" onblur="getStateCity('txtZip','txtCity','ddlState');"/>
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
                                            <input id="txtEmail" maxlength="50"  runat="server"
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
                        </td>
                        <td style="width: 33%; vertical-align: top;">
                            <div id="Div1" runat="server" style="width: 100%; float: left;">
                                <div class="header">
                                    Financial Guarantor
                                </div>
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
                                            <img src="../../Images/SmallSearch.gif" id="GS" onclick="FinancialGuarantorSearch()" style="margin: 5px 0 0 5px;
                                                display: none" />
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
                            <div style="width: 100%; float: left;">
                                <div class="header">
                                    Emergency Contact
                                </div>
                                <table style="width: 100%">
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
                            <div style="width: 100%; float: left;">
                                <div class="header">
                                    Disability/Death:
                                </div>
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
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" colspan="2">
                            <div class="header">
                                Web Account 
                                <asp:CheckBox ID="cbIsActiveWebAccount" runat="server" style="margin-left: 88px;font-weight: 100;" Text="IsActive Web account" />
                            </div>
                            <div style="width: 100%; float: left;">
                                <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                    <tr>
                                        <td class="tdLabel" style="width: 13%;">
                                            <span class="spanTitle">User Name: </span>
                                        </td>
                                        <td class="tdDataField" style="width: 20%;">
                                            <input id="txtPatientUserName" maxlength="20" AutoCompleteType="Disabled" runat="server" type="text" onblur="checkExistingUserName(this)" />
                                        </td>
                                        <td class="tdLabel" style="width: 10%;">
                                            <span class="spanTitle">Password: </span>
                                        </td>
                                        <td class="tdDataField" style="width: 24%;">
                                            <input id="txtPatientPassword" maxlength="20" AutoCompleteType="Disabled" runat="server" type="password" style="width: 68%;" />
                                        </td>
                                        <td class="tdLabel" style="width: 14%;">
                                            <span class="spanTitle">Confirm Password: </span>
                                        </td>
                                        <td class="tdDataField" style="width: 21%;">
                                            <input id="txtPatientConfirmPassword" maxlength="20" AutoCompleteType="Disabled" runat="server" type="password" style="width: 68%;" />
                                            <asp:HiddenField ID="hdnPassword" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width: 33%; vertical-align: top">
                            <div class="header">
                                Pharmacy
                            </div>
                            <div style="width: 100%; float: left;">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="tdLabel" style="width: 35%;">
                                            <span class="spanTitle">Pharmacy Name:</span>
                                        </td>
                                        <td>
                                            <div style="float: left;">
                                                <input id="txtPharmacyInfo" style="width: 180px" runat="server" type="text" disabled="disabled" />
                                            </div>
                                            <div style="float: left; margin-left: 7px">
                                                <span class="spnAdd" onclick="GetSearchBox();"></span>&nbsp;<span class="spnRemove" onclick="RemovePharmacy();"></span>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
    <asp:HiddenField ID="hdnPatientNCPDP" runat="server" />
    <div id="EditConfirmation" style="display:none">Do you want to cancel editing?</div>
    <div id="FinancialGuarantorSearch" style="display: none;"></div>
    <div id="divFinancialGuarantorAdd" style="display: none;"></div>
    <asp:HiddenField ID="hdnFinancialGuarantorId" runat="server" Value="0" />
    
    <script type="text/javascript">
        $(document).ready(function () {
            $(".phone").mask("(999) 999-9999");
            $(".txtSSN").mask("999-99-9999");
            
            $(".date").datepicker({ changeMonth: true,
                changeYear: true,
                maxDate: new Date()
            }).mask("99/99/9999");
            
            $(".time").timeEntry();
        });
    </script>
    <div id="divPatientInsurance" style="float: left; width: 100%;margin-top:15px">
        <div runat="server" class="accordion">
            <h3 style="position: relative; padding-left: 10px; font-weight: bold;">
                <span class="iconUp"></span>Primary Insurance
            </h3>
            <div style="padding: 10px;display: none;"">
                <div id="divPrimaryInsuranceEdit" style="display: none;">
                    <div class="Buttons action-button-wrapper" style="float: right">
                        <a href="javascript:void(0)" id="btnPatientPrimaryInsuranceEditingCancel" onclick="DisablePatientInsuranceEditing(this);" class="themeButton btnPatientInsuranceEditingCancel" style="padding-left: 24px;">
                            <span class="span-action-sprite span-cancel-sprite"></span>Cancel 
                        </a>
                        <a href="javascript:void(0)" id="btnPatientPrimaryInsuranceEditing" onclick="AddEditInsurance(this);" class="themeButton btnPatientInsuranceEditing" style="padding-left: 24px;">
                            <span class="span-action-sprite span-save-sprite"></span>Save
                        </a>
                    </div>
                    <div class="Content">
                        <table id="tblPrimaryInsurance" runat="server" class="tblPatientDemographics" width="100%">
                            <tr>
                                <td style="width: 33%;">
                                    <div class="header">
                                        General Information</div>
                                    <div style="width: 100%; float: left;">
                                        <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Name: </span><span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <div style="float: left; width: 100%;">
                                                        <input type="text" runat="server" id="txtPrimaryInsurance" class="txtInsuranceName" disabled="disabled" style="float: left;" />
                                                        
                                                        <input type="hidden" runat="server" id="hdnPrimaryInsuranceId" class="hdnInsuranceId" value="0" />
                                                        
                                                        <span style="float: left" class="spnAdd" onclick="LoadInsuranceDialog(this);"></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Policy No:</span><span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtPrimaryPolicyNo" maxlength="24" class="required" runat="server" type="text" onkeypress="return allowCharacterGroup(event,'abc123', '_-', false);" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group No: </span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtPrimaryGroupNo" maxlength="24" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtPrimaryGroupName" maxlength="48" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Effective Date:
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtPrimaryEffectiveDate" class="date IsDate" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Termination Date:
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtPrimaryTerminationDate" class="date IsDate" runat="server" type="text" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Financial Information</div>
                                    <div style="width: 100%; float: left;">
                                        <table cellpadding="0" cellspacing="0" class="tblContent" style="width: 100%;">
                                            <tr>
                                                <td class="tdLabel" style="width: 35%;">
                                                    <span class="spanTitle">Copay:</span>
                                                </td>
                                                <td class="tdDataField" style="width: 65%;">
                                                    <input id="txtPrimaryCopay" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Copay Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlPrimaryCoPayType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtPrimaryCoInsurance" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlPrimaryCoInsuranceType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtPrimaryDeductable" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlPrimaryDeductableType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td id="PrimarySubscribertd" style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Subscriber</div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Relationship:</span> <span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlPrimaryRelationship" onchange="SubscriberChange(this)" runat="server">
                                                        <asp:ListItem Value="Self">Self</asp:ListItem>
                                                        <asp:ListItem Value="Spouse">Spouse</asp:ListItem>
                                                        <asp:ListItem Value="Children">Children</asp:ListItem>
                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel" style="width: 30%;">
                                                    <span class="spanTitle">First Name:</span>
                                                </td>
                                                <td class="tdDataField" style="width: 70%;">
                                                    <input type="text" runat="server" id="txtPrimarySubscriberFirstName" class="txtSubscriberFirstName PrimarySubscriber" disabled="disabled" style="float:left;" />
                                                    
                                                    <input type="hidden" runat="server" id="hdnPrimarySubscriberId" class="hdnSubscriberId" value="0" />
                                                    
                                                    <span class="iconSearchSmall" style="display: none;" onclick="ClickSubscriberIcon(this);"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Last Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input type="text" runat="server" id="txtPrimarySubscriberLastName" class="txtSubscriberLastName PrimarySubscriber" disabled="disabled" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="divPrimaryInsuranceView" runat="server" style="display: none;">
                    <div class="Buttons action-button-wrapper" style="float: right">
                            <a href="javascript:void(0)" id="btnDeletePrimaryInsurance" onclick="DeletePatientInsurance(this);" class="themeButton btnDeletePrimaryInsurance" style="padding-left: 24px;">
                                <span class="span-action-sprite span-delete-sprite"></span>Delete 
                            </a>
                            <a href="javascript:void(0)" id="btnShowPatientPrimaryInsuranceEditing" onclick="EnablePatientInsuranceEditing(this);" class="themeButton btnPatientInsuranceEditing" style="padding-left: 24px;">
                                <span class="span-action-sprite span-edit-sprite"></span>Edit
                            </a>
                    </div>
                    <div class="Content">
                        <table id="tblViewPrimaryInsurance" runat="server" class="tblPatientDemographics"
                            width="100%">
                            <tr>
                                <td style="width: 33%;">
                                    <div class="header">
                                        General Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Name: </span>
                                                </td>
                                                <td class="tdDataField" id="Td2">
                                                    <div style="float: left; width: 100%;">
                                                        <asp:Label ID="lblPrimaryInsurance" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Policy No:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryPolicyNo" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group No: </span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryGroupNo" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryGroupName" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Effective Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryEffectiveDate" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Termination Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryTerminationDate" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Financial Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table cellpadding="0" cellspacing="0" class="tblContent" style="width: 100%;">
                                            <tr>
                                                <td class="tdLabel" style="width: 35%;">
                                                    <span class="spanTitle">Copay:</span>
                                                </td>
                                                <td class="tdDataField" style="width: 65%;">
                                                    <asp:Label ID="lblPrimaryCoPay" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Copay Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryCoPayType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryCoInsurance" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryCoInsuranceType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryDeductable" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryDeductableType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td id="PrimaryViewSubscribertd" style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Subscriber
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Relationship:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimaryRelationship" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel" style="width: 30%;">
                                                    <span class="spanTitle">First Name:</span>
                                                </td>
                                                <td class="tdDataField" style="width: 70%;">
                                                    <asp:Label ID="lblPrimarySubscriberFirstName" CssClass="Insurancelbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Last Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblPrimarySubscriberLastName" CssClass="Insurancelbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="divPrimaryInsuranceAdd" style="margin-left: 550px" runat="server">
                    <input id="btnAddNewPrimaryInsurance" runat="server" onclick="ShowAddNewInsurance(this)"
                        type="button" value="Add New Insurance" />
                </div>
            </div>
        </div>
        <div class="accordion">
            <h3 style="padding-left: 10px; font-weight: bold;">
                <span class="iconUp"></span>Secondary Insurance
            </h3>
            <div style="padding: 10px; display: none;">
                <div id="divSecondaryInsuranceEdit" style="display: none">
                    <div class="Buttons action-button-wrapper" style="float: right">
                        <a href="javascript:void(0)" id="btnPatientSecondaryInsuranceEditingCancel" onclick="DisablePatientInsuranceEditing(this);" class="themeButton btnPatientInsuranceEditingCancel" style="padding-left: 24px;">
                            <span class="span-action-sprite span-cancel-sprite"></span>Cancel 
                        </a>
                        <a href="javascript:void(0)" id="btnPatientSecondaryInsuranceEditing" onclick="AddEditInsurance(this);" class="themeButton btnPatientInsuranceEditing" style="padding-left: 24px;">
                            <span class="span-action-sprite span-save-sprite"></span>Save
                        </a>
                    </div>
                    <div class="Content">
                        <table id="tblSecondaryInsurance" runat="server" class="tblPatientDemographics Hide"
                            style="width: 100%;">
                            <tr>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        General Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Name: </span><span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField" id="ddlSecondaryInsuranceTd">
                                                    <div style="float: left; width: 100%;">
                                                        <input type="text" runat="server" id="txtSecondaryInsurance" class="txtInsuranceName" disabled="disabled" style="float: left;" />
                                                            
                                                        <input type="hidden" runat="server" id="hdnSecondaryInsuranceId" class="hdnInsuranceId" value="0" />
                                                            
                                                        <span style="float: left" class="spnAdd" onclick="LoadInsuranceDialog(this);"></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Policy No:</span><span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtSecondaryPolicyNo" class="required" maxlength="24" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group No: </span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtSecondaryGroupNo" maxlength="24" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtSecondaryGroupName" maxlength="48" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Effective Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtSecondaryEffectiveDate" class="date IsDate" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Termination Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtSecondaryTerminationDate" class="date IsDate" runat="server" type="text" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Financial Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent">
                                            <tr>
                                                <td class="tdLabel" style="width: 35%;">
                                                    <span class="spanTitle">Copay:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtSecondaryCopay" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Copay Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlSecondaryCoPayType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtSecondaryCoInsurance" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlSecondaryCoInsuranceType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtSecondaryDeductable" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlSecondaryDeductableType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td id="SecondarySubscribertd" runat="server" style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Subscriber
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Relationship:</span> <span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlSecondaryRelationship" onchange="SubscriberChange(this)"
                                                        runat="server">
                                                        <asp:ListItem Value="Self">Self</asp:ListItem>
                                                        <asp:ListItem Value="Spouse">Spouse</asp:ListItem>
                                                        <asp:ListItem Value="Children">Children</asp:ListItem>
                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel" style="width: 30%;">
                                                    <span class="spanTitle">First Name:</span>
                                                </td>
                                                <td class="tdDataField" style="width: 70%;">
                                                    <input type="text" runat="server" id="txtSecondarySubscriberFirstName" class="txtSubscriberFirstName SecondarySubscriber" disabled="disabled" style="float:left;" />
                                                    
                                                    <input type="hidden" runat="server" id="hdnSecondarySubscriberId" class="hdnSubscriberId" value="0" />
                                                    
                                                    <span class="iconSearchSmall" style="display: none;" onclick="ClickSubscriberIcon(this);"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Last Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input type="text" runat="server" id="txtSecondarySubscriberLastName" class="txtSubscriberLastName SecondarySubscriber" disabled="disabled" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="divSecondaryInsuranceView" runat="server" style="display: none;">
                    <div class="Buttons action-button-wrapper" style="float: right">
                        <a href="javascript:void(0)" id="btnDeleteSecondaryInsurance" onclick="DeletePatientInsurance(this);" class="themeButton btnDeletePrimaryInsurance" style="padding-left: 24px;">
                            <span class="span-action-sprite span-delete-sprite"></span>Delete 
                        </a>
                        <a href="javascript:void(0)" id="btnShowPatientSecondaryInsuranceEditing" onclick="EnablePatientInsuranceEditing(this);" class="themeButton btnPatientInsuranceEditing" style="padding-left: 24px;">
                            <span class="span-action-sprite span-edit-sprite"></span>Edit
                        </a>
                    </div>
                    <div class="Content">
                        <table id="tblViewSecondaryInsurance" runat="server" class="tblPatientDemographics"
                            style="width: 100%;">
                            <tr>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        General Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Name: </span>
                                                </td>
                                                <td class="tdDataField" id="Td3">
                                                    <div style="float: left; width: 100%;">
                                                        <asp:Label ID="lblSecondaryInsurance" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Policy No:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryPolicyNo" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group No: </span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryGroupNo" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group Name:</span> <span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryGroupName" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Effective Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryEffectiveDate" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Termination Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryTerminationDate" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Financial Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent">
                                            <tr>
                                                <td class="tdLabel" style="width: 35%;">
                                                    <span class="spanTitle">Copay:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondarycopay" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Copay Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryCoPayType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryCoInsurance" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryCoInsuranceType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryDeductable" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryDeductableType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Subscriber
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Relationship:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondaryRelationship" CssClass="Insurancelbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel" style="width: 30%;">
                                                    <span class="spanTitle">First Name:</span>
                                                </td>
                                                <td class="tdDataField" style="width: 70%;">
                                                    <asp:Label ID="lblSecondarySubscriberFirstName" CssClass="Insurancelbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Last Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblSecondarySubscriberLastName" CssClass="Insurancelbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="divSecondaryInsuranceAdd" style="margin-left: 550px" runat="server">
                    <input id="btnAddNewSecondaryInsurance" runat="server" onclick="ShowAddNewInsurance(this)"
                        type="button" value="Add New Insurance" />
                </div>
            </div>
        </div>
        <div class="accordion">
            <h3 style="padding-left: 10px; font-weight: bold;">
                <span class="iconUp"></span>Other Insurance
            </h3>
            <div style="padding: 10px; display: none;">
                <div id="divOtherInsuranceEdit" style="display: none;">
                    <div class="Buttons action-button-wrapper" style="float: right">
                        <a href="javascript:void(0)" id="btnPatientOtherInsuranceEditingCancel" onclick="DisablePatientInsuranceEditing(this);" class="themeButton btnPatientInsuranceEditingCancel" style="padding-left: 24px;">
                            <span class="span-action-sprite span-cancel-sprite"></span>Cancel 
                        </a>
                        <a href="javascript:void(0)" id="btnPatientOtherInsuranceEditing" onclick="AddEditInsurance(this);" class="themeButton btnPatientInsuranceEditing" style="padding-left: 24px;">
                            <span class="span-action-sprite span-save-sprite"></span>Save
                        </a>
                    </div>
                   
                    <div class="Content">
                        <table id="tblOtherInsurance" runat="server" class="tblPatientDemographics Hide">
                            <tr>
                                <td style="width: 33%;">
                                    <div class="header">
                                        General Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Name: </span><span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField" id="Td1">
                                                    <div style="float: left; width: 100%;">
                                                        <input type="text" runat="server" id="txtOtherInsurance" class="txtInsuranceName" disabled="disabled" style="float: left;" />
                                                            
                                                        <input type="hidden" runat="server" id="hdnOtherInsuranceId" class="hdnInsuranceId" value="0" />
                                                            
                                                        <span style="float: left" class="spnAdd" onclick="LoadInsuranceDialog(this);"></span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Policy No:</span><span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtOtherPolicyNo" runat="server" maxlength="24" class="required" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group No: </span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtOtherGroupNo" maxlength="24" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtOtherGroupName" maxlength="48" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Effective Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtOtherEffectiveDate" class="date IsDate" runat="server" type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Termination Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtOtherTerminationDate" class="date IsDate" runat="server" type="text" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Financial Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent">
                                            <tr>
                                                <td class="tdLabel" style="width: 35%;">
                                                    <span class="spanTitle">Copay:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtOtherCopay" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Copay Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlOtherCoPayType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtOtherCoInsurance" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlOtherCoInsuranceType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input id="txtOtherDeductable" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                                        type="text" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlOtherDeductableType" runat="server">
                                                        <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                                        <asp:ListItem Value="Amount">Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td id="OtherSubscribertd" runat="server" style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Subscriber
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Relationship:</span> <span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:DropDownList ID="ddlOtherRelationship" onchange="SubscriberChange(this)" runat="server">
                                                        <asp:ListItem Value="Self">Self</asp:ListItem>
                                                        <asp:ListItem Value="Spouse">Spouse</asp:ListItem>
                                                        <asp:ListItem Value="Children">Children</asp:ListItem>
                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel" style="width: 30%;">
                                                    <span class="spanTitle">First Name:</span>
                                                </td>
                                                <td class="tdDataField" style="width: 70%;">
                                                    <input type="text" runat="server" id="txtOtherSubscriberFirstName" class="txtSubscriberFirstName OtherSubscriber" disabled="disabled" style="float:left;" />
                                                    
                                                    <input type="hidden" runat="server" id="hdnOtherSubscriberId" class="hdnSubscriberId" value="0" />
                                                    
                                                    <span class="iconSearchSmall" style="display: none;" onclick="ClickSubscriberIcon(this);"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Last Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <input type="text" runat="server" id="txtOtherSubscriberLastName" class="txtSubscriberLastName OtherSubscriber" disabled="disabled" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="divOtherInsuranceView" runat="server" style="display: none;">
                    <div class="Buttons action-button-wrapper" style="float: right">
                        <a href="javascript:void(0)" id="btnDeleteOtherInsurance" onclick="DeletePatientInsurance(this);" class="themeButton btnDeletePrimaryInsurance" style="padding-left: 24px;">
                            <span class="span-action-sprite span-delete-sprite"></span>Delete 
                        </a>
                         <a href="javascript:void(0)" id="btnShowPatientOtherInsuranceEditing" onclick="EnablePatientInsuranceEditing(this);" class="themeButton btnPatientInsuranceEditing" style="padding-left: 24px;">
                            <span class="span-action-sprite span-edit-sprite"></span>Edit
                        </a>
                    </div>
                    <div class="Content">
                        <table id="tblViewOtherInsurance" runat="server" class="tblPatientDemographics">
                            <tr>
                                <td style="width: 33%;">
                                    <div class="header">
                                        General Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Name: </span><span class="spnError">*</span>
                                                </td>
                                                <td class="tdDataField" id="Td5">
                                                    <div style="float: left; width: 100%;">
                                                        <asp:Label ID="lblOtherInsurance" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Policy No:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherPolicyNo" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group No: </span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherGroupNo" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Group Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherGroupName" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Effective Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherEffectiveDate" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Termination Date:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherTerminationDate" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Financial Information
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent">
                                            <tr>
                                                <td class="tdLabel" style="width: 35%;">
                                                    <span class="spanTitle">Copay:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOthercopay" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Copay Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherCoPayType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherCoInsurance" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Coinsurance Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherCoInsuranceType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherDeductable" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Deductable Type:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblotherDeductableType" runat="server" CssClass="Insurancelbl"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td id="Td6" runat="server" style="width: 33%; vertical-align: top;">
                                    <div class="header">
                                        Subscriber
                                    </div>
                                    <div style="width: 100%; float: left;">
                                        <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Relationship:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherRelationship" CssClass="Insurancelbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel" style="width: 30%;">
                                                    <span class="spanTitle">First Name:</span>
                                                </td>
                                                <td class="tdDataField" style="width: 70%;">
                                                    <asp:Label ID="lblOtherSubscriberFirstName" CssClass="Insurancelbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdLabel">
                                                    <span class="spanTitle">Last Name:</span>
                                                </td>
                                                <td class="tdDataField">
                                                    <asp:Label ID="lblOtherSubscriberLastName" CssClass="Insurancelbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="divOtherInsuranceAdd" style="margin-left: 550px" runat="server">
                    <input id="btnAddNewOtherInsurance" onclick="ShowAddNewInsurance(this)" runat="server"
                        class="Hide" type="button" value="Add New Insurance" />
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdnPatientPrimaryInsuranceId" runat="server" Value="0" />
    <asp:HiddenField ID="hdnPatientSecondaryInsuranceId" runat="server" Value="0" />
    <asp:HiddenField ID="hdnPatientOtherInsuranceId" runat="server" Value="0" />
    
    <input id="hdnAddNew" type="hidden" />

    ###EndPersonalInformation###
    </form>
</body>
</html>
