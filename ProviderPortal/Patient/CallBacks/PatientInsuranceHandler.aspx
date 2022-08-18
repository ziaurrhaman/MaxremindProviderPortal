<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientInsuranceHandler.aspx.cs"
    Inherits="EMR_Patient_CallBacks_PatientInsuranceHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartPatientInsurance###
    <div id="divPatientInsurance" style="float: left; width: 100%;">
        <div id="Div1" runat="server" class="accordion">
            <h3 style="position: relative; margin-left: 10px; font-weight: bold;">
                <span class="iconDown"></span>Primary Insurance
            </h3>
            <div style="padding: 10px;">
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
                                                    <span class="spanTitle">Effective Date:</span>
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
            <h3 style="margin-left: 10px; font-weight: bold;">
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
            <h3 style="margin-left: 10px; font-weight: bold;">
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
    ###EndPatientInsurance###
    </form>
</body>
</html>
