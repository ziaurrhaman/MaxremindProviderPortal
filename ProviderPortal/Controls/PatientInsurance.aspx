<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientInsurance.aspx.cs" Inherits="ProviderPortal_Controls_PatientInsurance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartForm###
    <asp:HiddenField runat="server" ID="hdnPatientInsuranceIdWalkoutEdit" Value="0" />
    
    <div style="width: 1000px;">
        <div class="float-left-100">
            <table class="tblPatientDemographics">
                <tr>
                    <td style="width: 35%;">
                        <div class="header">
                            General Information
                        </div>
                        <div class="float-left-100">
                            <table cellspacing="0" cellpadding="0" class="tblContent">
                                <tr>
                                    <td class="tdLabel" style="width: 105px;">
                                        <span class="spanTitle">Name:</span><span class="spnError">*</span>
                                    </td>
                                    <td class="tdDataField">
                                        <div class="float-left-100">
                                            <input type="text" runat="server" id="txtPatientInsuranceWalkout" class="txtInsuranceName" disabled="disabled" style="float: left;" />
                                            
                                            <input type="hidden" runat="server" id="hdnInsuranceIdWalkoutEdit" class="hdnInsuranceId" value="0" />
                                            
                                            <span style="float: left;" class="spnAdd" onclick="LoadInsuranceDialog(this);"></span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Policy No:</span><span class="spnError">*</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtPolicyNoWalkout" maxlength="24" class="required" runat="server" type="text" onkeypress="return allowCharacterGroup(event,'abc123', '_-', false);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Group No:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtGroupNoWalkout" maxlength="24" runat="server" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Group Name:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtGroupNameWalkout" maxlength="48" runat="server" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Effective Date:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtEffectiveDateWalkout" class="date IsDate" runat="server" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Termination Date:
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtTerminationDateWalkout" class="date IsDate" runat="server" type="text" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td style="width: 33%; vertical-align: top;">
                        <div class="header">
                            Financial Information</div>
                        <div class="float-left-100">
                            <table cellpadding="0" cellspacing="0" class="tblContent">
                                <tr>
                                    <td class="tdLabel" style="width: 111px;">
                                        <span class="spanTitle">Copay:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtCopayWalkout" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                            type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Copay Type:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <asp:DropDownList ID="ddlCoPayTypeWalkout" runat="server">
                                            <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                            <asp:ListItem Value="Amont">Amount</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Coinsurance:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtCoInsuranceWalkout" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                            type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Coinsurance Type:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <asp:DropDownList ID="ddlCoInsuranceTypeWalkout" runat="server">
                                            <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                            <asp:ListItem Value="Amont">Amount</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Deductable:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtDeductableWalkout" onkeypress="return ValidateNumber(event)" maxlength="8" runat="server"
                                            type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Deductable Type:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <asp:DropDownList ID="ddlDeductableTypeWalkout" runat="server">
                                            <asp:ListItem Value="Percentage">Percentage</asp:ListItem>
                                            <asp:ListItem Value="Amont">Amount</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td style="vertical-align: top;">
                        <div class="header">
                            Subscriber
                        </div>
                        <div class="float-left-100">
                            <table cellpadding="0" cellspacing="0" class="tblContent">
                                <tr>
                                    <td class="tdLabel" style="width: 88px;">
                                        <span class="spanTitle">Relationship:</span> <span class="spnError">*</span>
                                    </td>
                                    <td class="tdDataField">
                                        <asp:DropDownList ID="ddlRelationshipWalkout" onchange="Walkout_SubscriberChange(this)" runat="server">
                                            <asp:ListItem Value="Self">Self</asp:ListItem>
                                            <asp:ListItem Value="Spouse">Spouse</asp:ListItem>
                                            <asp:ListItem Value="Children">Children</asp:ListItem>
                                            <asp:ListItem Value="Other">Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">First Name:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input type="text" runat="server" id="txtSubscriberFirstNameWalkout" class="txtSubscriberFirstName" disabled="disabled" style="float:left;" />
                                        
                                        <input type="hidden" runat="server" id="hdnSubscriberIdWalkoutEdit" class="hdnSubscriberId" value="0" />
                                        
                                        <span class="iconSearchSmall" style="display: none;" onclick="LoadSubscriberDialog(this);"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span class="spanTitle">Last Name:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input type="text" runat="server" id="txtSubscriberLastNameWalkout" class="txtSubscriberLastName" disabled="disabled" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="action-button-wrapper">
            <input type="button" class="popup-buttons popup-button-red" value="Cancel" onclick="Walkout_ClosePatientInsuraceForm();" />
            <input type="button" class="popup-buttons popup-button-blue" value="Save" onclick="Walkout_SavePatientInsurace();" style="margin-right: 5px;" />
        </div>
    </div>
    ###EndForm###

    ###StartPatientInsuranceId###
    <asp:Literal runat="server" ID="ltrPatientInsuranceId"></asp:Literal>
    ###EndPatientInsuranceId###
    </form>
</body>
</html>
