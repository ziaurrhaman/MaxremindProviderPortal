<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewPatientPopUp.aspx.cs" Inherits="HomeHealth_Patient_AddNewPatientPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###NewPatientPopUp###
        <table id="tblPatientPopup">
            <tr>
                <td class="popup-label-td">
                    Last Name:<span class="spnError">*</span>
                </td>
                <td>
                    <input id="txtPatientPopUpLastName" name="LastName" class="required" type="text" tabindex="1" onkeypress="return ValidateCharacters(event);" />
                </td>
                <td class="popup-label-td">
                    SSN:
                </td>
                <td>
                    <input id="txtSSNNewPatientPopUp" type="text" tabindex="7" />
                </td>
            </tr>
            <tr>
                <td class="popup-label-td" style="width: 20%;">
                    First Name:<span class="spnError">*</span>
                </td>
                <td style="width: 30%;">
                    <input id="txtPatientPopUpFirstName" name="FirstName" class="required" type="text" tabindex="2" onkeypress="return ValidateCharacters(event);" />
                </td>
                <td class="popup-label-td">
                    Cell:
                </td>
                <td>
                    <input id="txtCell" type="text" tabindex="8" />
                </td>
            </tr>
            <tr>
                <td class="popup-label-td">
                    Gender:<span class="spnError">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPatientPopUpGender" runat="server" style="width: 95%;" tabindex="3">
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                        <asp:ListItem Value="Female">Female</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="popup-label-td">
                    Zip:
                </td>
                <td>
                    <asp:TextBox ID="txtZipNewPatientPopUp" runat="server" maxlength="9" onkeypress="return ValidateNumber(event);" onblur="getStateCity('txtZipNewPatientPopUp','txtCityNewPatientPopUp','ddlStatesNewPatientPopUp');" tabindex="9"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="popup-label-td">
                    Date of birth:
                </td>
                <td>
                    <input id="txtPatientPopUpDOB" name="DOB" class="DOBdate IsDate" type="text" tabindex="4" />
                </td>
                <td class="popup-label-td">
                    City:
                </td>
                <td>
                    <asp:TextBox ID="txtCityNewPatientPopUp" runat="server" tabindex="10" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="popup-label-td">
                    Primary Insurance:
                </td>
                <td>
                    <div style="float: left; width: 100%;">
                        <input id="txtNewPatientPrimaryInsurance" disabled="disabled" runat="server" type="text" style="float: left; width: 66%;" tabindex="5" />
                        <span style="float: left"><span class="spnAdd" id="AddPrimary" onclick="ShowNewPatientInsuranceSearch(this);">
                        </span>&nbsp;<span class="spnRemove" onclick="RemovePatientInsurance();"></span></span>

                        <input type="hidden" id="hdnNewPatientPrimaryInsuranceId" name="InsuranceId" value="0" />
                    </div>
                </td>
                <td class="popup-label-td">
                    State:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatesNewPatientPopUp" runat="server" tabindex="11" Enabled="false"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="popup-label-td">
                    Policy No.
                </td>
                <td>
                    <input type="text" id="txtNewPatientPrimaryPolicyNo" name="PolicyNo" maxlength="24" tabindex="6" />
                </td>
                <td class="popup-label-td">
                    Address:
                </td>
                <td>
                    <input id="txtAddressNewPatientPopUp" type="text" tabindex="12" />
                </td>
            </tr>
            <tr class="trAction">
                <td colspan="4">
                    <div style="float:right; margin: 10px 0 5px;">
                        <input type="button" class="popup-buttons popup-button-blue" value="Create" onclick="CreateNewPatientPopUp();" />
                        <input type="button" class="popup-buttons popup-button-default" value="Check Eligibility" onclick="ClickCheckEligibilityNewPatientPopUp();" />
                        <input type="button" class="popup-buttons popup-button-red" value="Cancel" onclick="ClosePatientPopUp();" />
                    </div>
                </td>
            </tr>
        </table>
    ###EndPatientPopUp###
    </div>
    </form>
</body>
</html>