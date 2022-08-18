<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateClaimForm.aspx.cs" Inherits="EMR_Claims_CallBacks_CreateClaimForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###StartClaim###
        <div id="divSaveClaim">
            <div class="float-left-100">
                <div style="float: left; width: 100%; margin: 0 0 10px;">
                    <div style="float:right;">
                        <input type="button" value="Save" onclick="SaveClaim();" />
                        <input type="button" value="Cancel" onclick="backSaveClaim();" id="btnbackSaveClaim" />
                    </div>
                    <div style="float:right; margin: 6px 0 0;">
                        <asp:CheckBox runat="server" ID="chkIsPTL" ToolTip="Move Claim to Pending Transaction List" onclick="PTL_Click_CheckBox_Claim(this, 'Claim');" style="float: left; margin: 0;" />
                        <a href="javascript:void(0);" title="Move Claim to Pending Transaction List" onclick="PTL_Click_Claim(this, 'Claim');" class="underline-link" style="float: left; margin: 3px 25px 0 0;">PTL</a>
                    </div>
                </div>
                <div style="float: left; width: 50%">
                    <asp:HiddenField ID="hdnPhotoFileTempPathPatient" runat="server" />
                    <asp:HiddenField ID="hfImageFileNamePatient" runat="server" />
                    
                    <div id="divPatientSummaryWrapper" style="width: 100%; font-family: Verdana; float: left; padding: 5px;">
                        <div style="width: 100%; float: left;">
                            <div id="PersonPhoto" style="float: left">
                                <asp:Image ID="imgPatientPhoto" runat="server" Width="100px" Height="100px" />
                            </div>
                            <div id="divPatientInfo" runat="server" style="float: left; margin-left: 10px; line-height: 1.5; display: none">
                                <div class="Bold">
                                    <asp:Label ID="lblPatientId" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="Bold">
                                    <asp:Label ID="lblNamePatient" runat="server"></asp:Label>
                                </div>
                                <div class="Bold">
                                    <asp:Label ID="lblDOBPatient" runat="server"></asp:Label>
                                </div>
                                <div class="Bold">
                                    <asp:Label ID="lblGenderPatient" runat="server"></asp:Label>
                                    <asp:Label ID="lblMaritalStatusPatient" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <img style="width: 16px; height: 16px;" id="imgPhone" src="" />
                                    <asp:Label ID="lblCellPatient" runat="server"></asp:Label>
                                    <asp:Label ID="lblHomePhonePatient" runat="server"></asp:Label>
                                    <asp:Label ID="lblWorkPhonePatient" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblAddressPatient" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <input type="button" id="btnAddPatient" value="Add Patient" onclick="openPatiantSearch();" />
                    </div>
                </div>
                <div style="float: right; width: 50%">
                    <table>
                        <tr>
                            <td style="width: 25%;">
                                Primary Insurance: <span class="spnError">*</span>
                            </td>
                            <td style="width: 25%;">
                                <asp:DropDownList ID="ddlPrimaryInsurance" runat="server" CssClass="required"></asp:DropDownList>
                            </td>
                            <td style="width: 25%;">
                                Primary Status: <span class="spnError">*</span>
                            </td>
                            <td style="width: 25%;">
                                <asp:DropDownList ID="ddlPrimaryStatus" runat="server" CssClass="claim-status-combo required" onchange="changeClaimStatus(this);"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Secondary Insurance:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSecondaryInsurance" runat="server"></asp:DropDownList>
                            </td>
                            <td>
                                Secondary Status:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSecondaryStatus" runat="server" CssClass="claim-status-combo" onchange="changeClaimStatus(this);"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Other Insurance:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlOtherInsurance" runat="server"></asp:DropDownList>
                            </td>
                            <td>
                                Other Status:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlOtherStatus" runat="server" CssClass="claim-status-combo" onchange="changeClaimStatus(this);"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <span style="float:right;margin-right:10px;"><input type="checkbox" onclick="showHideAdvanceOption()" class="chkAdvance" /> Show Advance Options</span>
                </div>
            </div>
            <div class="float-left-100">
                <div class="box">
                    <div class="box-header-patient">
                        <ul>
                            <li class="active" onclick="ShowHideTabsClaimForm(this, 'General');">
                                <a href="#">General</a>
                            </li>
                            <li onclick="ShowHideTabsClaimForm(this, 'Payment');">
                                <a href="#">Payment</a>
                            </li>
                            <li onclick="ShowHideTabsClaimForm(this, 'Notes');">
                                <a href="#">Notes</a>
                            </li>
                        </ul>
                    </div>
                    <div class="box-content" style="background: #fff;">
                        <div id="divClaimGeneralMain" class="divs-claim-form-tabs">
                            <div class="claim-top" id="divClaimTop" style="margin-bottom:10px;">
                                <table>
                                    <tr>
                                        <td style="width: 6%;">
                                            DOS: <span class="spnError">*</span>
                                        </td>
                                        <td style="width: 19%;">
                                            <asp:TextBox ID="txtDos" runat="server" class="required"></asp:TextBox>
                                           <%-- <asp:DropDownList ID="ddlDos" runat="server" class="required">
                                            </asp:DropDownList>--%>
                                        </td>
                                        <td style="width: 6%;">
                                            POS:
                                        </td>
                                        <td style="width: 19%;">
                                            <asp:DropDownList runat="server" ID="ddlPOS">
                                                <asp:ListItem Value="" Text=""></asp:ListItem>
                                                <asp:ListItem Value="11" Text="Office"></asp:ListItem>
                                                <asp:ListItem Value="12" Text="Home"></asp:ListItem>
                                                <asp:ListItem Value="21" Text="Inpatient Hospital"></asp:ListItem>
                                                <asp:ListItem Value="22" Text="Outpatient Hospital"></asp:ListItem>
                                                <asp:ListItem Value="23" Text="Emergency Room - Hospital"></asp:ListItem>
                                                <asp:ListItem Value="24" Text="Ambulatory Surgical Center"></asp:ListItem>
                                                <asp:ListItem Value="25" Text="Birthing Center"></asp:ListItem>
                                                <asp:ListItem Value="26" Text="Military Treatment Facility"></asp:ListItem>
                                                <asp:ListItem Value="31" Text="Skilled Nursing Facility"></asp:ListItem>
                                                <asp:ListItem Value="32" Text="Nursing Facility"></asp:ListItem>
                                                <asp:ListItem Value="33" Text="Custodial Care Facility"></asp:ListItem>
                                                <asp:ListItem Value="34" Text="Hospice"></asp:ListItem>
                                                <asp:ListItem Value="41" Text="Ambulance - Land"></asp:ListItem>
                                                <asp:ListItem Value="42" Text="Ambulance - Air or Water"></asp:ListItem>
                                                <asp:ListItem Value="50" Text="Federally Qualified Health Center"></asp:ListItem>
                                                <asp:ListItem Value="51" Text="Inpatient Psychiatric Facility"></asp:ListItem>
                                                <asp:ListItem Value="52" Text="Psychiatric Facility Partial Hospitalization"></asp:ListItem>
                                                <asp:ListItem Value="53" Text="Community Mental Health Center"></asp:ListItem>
                                                <asp:ListItem Value="54" Text="Intermediate Care Facility/Mentally Retarded"></asp:ListItem>
                                                <asp:ListItem Value="55" Text="Residential Substance Abuse Treatment Facility"></asp:ListItem>
                                                <asp:ListItem Value="56" Text="Psychiatric Residential Treatment Center"></asp:ListItem>
                                                <asp:ListItem Value="60" Text="Mass Immunization Center"></asp:ListItem>
                                                <asp:ListItem Value="61" Text="Comprehensive Inpatient Rehabilitation Facility"></asp:ListItem>
                                                <asp:ListItem Value="62" Text="Comprehensive Outpatient Rehabilitation Facility"></asp:ListItem>
                                                <asp:ListItem Value="65" Text="End Stage Renal Disease Treatment Facility"></asp:ListItem>
                                                <asp:ListItem Value="71" Text="State or Local Public Health Clinic"></asp:ListItem>
                                                <asp:ListItem Value="72" Text="Rural Health Clinic"></asp:ListItem>
                                                <asp:ListItem Value="81" Text="Independent Laboratory"></asp:ListItem>
                                                <asp:ListItem Value="99" Text="Other Unlisted Facility"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 6%;">
                                            Referral #:
                                        </td>
                                        <td style="width: 19%;">
                                            <asp:TextBox ID="txtReferralNo" runat="server" MaxLength="15" onkeypress="return allowCharacterGroup(event,'abc123', '_', false);"></asp:TextBox>
                                        </td>
                                        <td style="width: 6%;">
                                            PA #:
                                        </td>
                                        <td style="width: 19%;">
                                            <asp:TextBox ID="txtPANo" runat="server" MaxLength="12" onkeypress="return allowCharacterGroup(event,'abc123', '_', false);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Location: <span class="spnError">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocation" class="required" runat="server" onchange="changeLocationClaim(this);"></asp:DropDownList>
                                        </td>
                                        <td>
                                            Attending Physician: <span class="spnError">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlAttendingPhy" runat="server" class="required"></asp:DropDownList>
                                        </td>
                                        <td>
                                            Billing Physician:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBillingPhy" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            Referring Physician:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlReferringPhy" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="Widget" style="width: 100%; margin-bottom:10px;">
                                <div class="WidgetTitle">
                                    <span class="widget-diagnosis-icon"></span>Diagnoses
                                </div>
                                <div class="WidgetContent">
                                    <table cellpadding="0" cellspacing="0" style="width: 100%; margin-bottom: 5px;">
                                        <tr>
                                            <td>
                                                <div id="divdiagnoseCode">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 4%; text-align: center;">
                                                                DX1
                                                            </td>
                                                            <td style="width: 11%;" class="leftTd">
                                                                <input type="text" id="txtIcdCode1" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc1');" style="width: 90%;" />
                                                            </td>
                                                            <td style="width: 35%;" class="leftTd">
                                                                <input type="text" id="txtIcdDesc1" runat="server" class="upperCase" onkeyup="searchIcDs('D','', this.value, this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode1');" style="width: 78%; float: left; margin-right: 2%;" />
                                                                <span class="spnRemove" onclick="emptyICDVal(this, 1);"></span>
                                                                <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'DX', 'ClaimForm');" style="margin: 7px 0 0;"></span>
                                                            </td>
                                                            <td style="text-align: center; width: 4%;">
                                                                DX2
                                                            </td>
                                                            <td style="width: 11%;" class="rightTd">
                                                                <input type="text" id="txtIcdCode2" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc2');" style="width: 90%;" />
                                                            </td>
                                                            <td style="width: 35%;" class="rightTd">
                                                                <input type="text" id="txtIcdDesc2" runat="server" class="upperCase" onkeyup="searchIcDs('D','', this.value, this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode2');" style="width: 78%; float: left; margin-right: 2%;" />
                                                                <span class="spnRemove" onclick="emptyICDVal(this, 2);"></span>
                                                                <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'DX', 'ClaimForm');" style="margin: 7px 0 0;"></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center; width: 4%;">
                                                                DX3
                                                            </td>
                                                            <td style="width: 11%; vertical-align:top;" class="leftTd">
                                                                <input type="text" id="txtIcdCode3" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc3');" style="width: 90%;" />
                                                            </td>
                                                            <td style="width: 35%; vertical-align:top;" class="leftTd">
                                                                <input type="text" id="txtIcdDesc3" runat="server" class="upperCase" onkeyup="searchIcDs('D','', this.value, this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode3');" style="width: 78%; float: left; margin-right: 2%;" />
                                                                <span class="spnRemove" onclick="emptyICDVal(this, 3);"></span>
                                                                <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'DX', 'ClaimForm');" style="margin: 7px 0 0;"></span>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                DX4
                                                            </td>
                                                            <td class="rightTd" style="vertical-align:top;">
                                                                <input type="text" id="txtIcdCode4" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc4');" style="width: 90%;" />
                                                            </td>
                                                            <td class="rightTd" style="vertical-align:top;">
                                                                <input type="text" id="txtIcdDesc4" runat="server" class="upperCase" onkeyup="searchIcDs('D','', this.value, this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode4');" style="width: 78%; float: left; margin-right: 2%;" />
                                                                <span class="spnRemove" onclick="emptyICDVal(this, 4);"></span>
                                                                <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'DX', 'ClaimForm');" style="margin: 7px 0 0;"></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center; width: 4%;">
                                                                DX5
                                                            </td>
                                                            <td style="width: 11%; vertical-align:top;" class="leftTd">
                                                                <input type="text" id="txtIcdCode5" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc5');" style="width: 90%;" />
                                                            </td>
                                                            <td style="width: 35%; vertical-align:top;" class="leftTd">
                                                                <input type="text" id="txtIcdDesc5" runat="server" class="upperCase" onkeyup="searchIcDs('D','', this.value, this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode5');" style="width: 78%; float: left; margin-right: 2%;" />
                                                                <span class="spnRemove" onclick="emptyICDVal(this, 5);"></span>
                                                                <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'DX', 'ClaimForm');" style="margin: 7px 0 0;"></span>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                DX6
                                                            </td>
                                                            <td class="rightTd" style="vertical-align:top;">
                                                                <input type="text" id="txtIcdCode6" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc6');" style="width: 90%;" />
                                                            </td>
                                                            <td class="rightTd" style="vertical-align:top;">
                                                                <input type="text" id="txtIcdDesc6" runat="server" class="upperCase" onkeyup="searchIcDs('D','', this.value, this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode6');" style="width: 78%; float: left; margin-right: 2%;" />
                                                                <span class="spnRemove" onclick="emptyICDVal(this, 6);"></span>
                                                                <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'DX', 'ClaimForm');" style="margin: 7px 0 0;"></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center; width: 4%;">
                                                                DX7
                                                            </td>
                                                            <td style="width: 11%; vertical-align:top;" class="leftTd">
                                                                <input type="text" id="txtIcdCode7" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc7');" style="width: 90%;" />
                                                            </td>
                                                            <td style="width: 35%; vertical-align:top;" class="leftTd">
                                                                <input type="text" id="txtIcdDesc7" runat="server" class="upperCase" onkeyup="searchIcDs('D','', this.value, this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode7');" style="width: 78%; float: left; margin-right: 2%;" />
                                                                <span class="spnRemove" onclick="emptyICDVal(this, 7);"></span>
                                                                <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'DX', 'ClaimForm');" style="margin: 7px 0 0;"></span>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                DX8
                                                            </td>
                                                            <td class="rightTd" style="vertical-align:top;">
                                                                <input type="text" id="txtIcdCode8" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc8');" style="width: 90%;" />
                                                            </td>
                                                            <td class="rightTd" style="vertical-align:top;">
                                                                <input type="text" id="txtIcdDesc8" runat="server" class="upperCase" onkeyup="searchIcDs('D','', this.value, this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode8');" style="width: 78%; float: left; margin-right: 2%;" />
                                                                <span class="spnRemove" onclick="emptyICDVal(this, 8);"></span>
                                                                <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'DX', 'ClaimForm');" style="margin: 7px 0 0;"></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div id="divICDsSearched" style="width: 500px; height: 305px; position: absolute; display: none; background-color: #fff; z-index: 999;border: 1px solid rgb(211, 211, 211);padding-bottom:31px;overflow-y: auto;">
                                                        <div class="Grid" style="width: 99%;height: 300px;">
                                                            <table>
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            Code
                                                                        </th>
                                                                        <th>
                                                                            Description
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody id="IcdsSearchedList">
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="Widget" style="width: 100%; margin-bottom: 10px;">
                                <div class="WidgetTitle">
                                    <span class="widget-services-icon"></span>Services
                                </div>
                                <div class="WidgetContent">
                                    <div class="Grid" style="overflow:visible;">
                                        <table id="tblClaimServices">
                                            <thead>
                                                <tr>
                                                    <th style="width: 1%;">
                                                        Include in submission
                                                    </th>
                                                    <th style="width: 20%;">
                                                        Procedure
                                                    </th>
                                                    <th style="width:15%">
                                                        Drug
                                                    </th>
                                                    <th style="width: 5%;">
                                                        Unit Code
                                                    </th>
                                                    <th style="width: 8%;">
                                                        Pointers
                                                    </th>
                                                    <th style="width: 6%;">
                                                        Units
                                                    </th>
                                                    <th style="width: 25%;">
                                                        Modifiers
                                                    </th>
                                                    <th style="width: 6%;">
                                                        Charges
                                                    </th>
                                                    <th style="width: 8%;">
                                                        Billing Status
                                                    </th>
                                                    <th style="width: 8%;">
                                                        Action
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyClaimServices">
                                                <asp:Repeater ID="rptPatientServices" runat="server" OnItemDataBound="rptPatientServices_ItemDataBound">
                                                    <ItemTemplate>
                                                        <tr class="row-claim-services">
                                                            <td align="center">
                                                                <asp:CheckBox runat="server" ID="cbIncludeInSubmission" CssClass="cbIncludeInSubmission" />
                                                            </td>
                                                            <td style="position: relative;">
                                                                <input type="text" class="txtProcedures" autocomplete="off" onkeyup="searchCPTs(this, event);" value='<%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %>' title='<%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %>' />
                                                                <input type="hidden" class="hdnProceduresCode" value='<%#Eval("CPTCode") %>' />
                                                            </td>
                                                            <td style="position: relative;">
                                                                <input type="text" class="txtDrug" autocomplete="off" onkeyup="SearchDrugs(this)" value='<%#Eval("DrugName") %>' title='<%#Eval("DrugName") %>' />
                                                                <input type="hidden" class="hdnDrug" value='<%#Eval("Drug") %>' />
                                                                
                                                                <div class="Grid divDrugSearchList" style="width: 560px; display: none; position: absolute; max-height: 400px; overflow-y: auto; overflow-x: hidden; z-index: 1000;">
                                                                    <table style="width: 100%;">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>
                                                                                    HCPCS Code
                                                                                </th>
                                                                                <th>
                                                                                    Drug Name
                                                                                </th>
                                                                                <th>
                                                                                    Description
                                                                                </th>
                                                                                <th>
                                                                                    Labeler Name
                                                                                </th>
                                                                                <th>
                                                                                    NDC
                                                                                </th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody class="tbodyClaimDrugs"></tbody>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td style="position: relative;">
                                                                <asp:DropDownList runat="server" ID="ddlUnitCode" CssClass="ddlUnitCode">
                                                                    <asp:ListItem Value="" Text=""></asp:ListItem>
                                                                    <asp:ListItem Value="F2" Text="International Unit"></asp:ListItem>
                                                                    <asp:ListItem Value="GR" Text="Gram"></asp:ListItem>
                                                                    <asp:ListItem Value="ME" Text="Milligram"></asp:ListItem>
                                                                    <asp:ListItem Value="ML" Text="Milliliter"></asp:ListItem>
                                                                    <asp:ListItem Value="UN" Text="Unit"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="position: relative;">
                                                                <div style="width: 100%; float: left;">
                                                                    <a onclick="HideShowMenuPointer(this);" class="drop-down-box">
                                                                        <asp:Label runat="server" ID="lblPointers" CssClass="selectedText" style="width: 62px;"></asp:Label>
                                                                        <span class="dropDownIconMultipleCheckBox"></span>
                                                                    </a>
                                                                    <div class="dropdownMenuMultipleCheckBox">
                                                                        <div class="div-drop-down">
                                                                            <div>
                                                                                <asp:CheckBox ID="cbDXPointer1" runat="server" Text="DX1" class="1 DX1PointerCheckbox"
                                                                                    onclick="return DxPointer1Check(event, this);" style="margin: 6px;" />
                                                                            </div>
                                                                            <div>
                                                                                <asp:CheckBox ID="cbDXPointer2" runat="server" Text="DX2" class="2 DX2PointerCheckbox"
                                                                                    onclick="return DxPointer2Check(event, this);" style="margin: 6px;" />
                                                                            </div>
                                                                            <div>
                                                                                <asp:CheckBox ID="cbDXPointer3" runat="server" Text="DX3" class="3 DX3PointerCheckbox"
                                                                                    onclick="return DxPointer3Check(event, this);" style="margin: 6px;" />
                                                                            </div>
                                                                            <div>
                                                                                <asp:CheckBox ID="cbDXPointer4" runat="server" Text="DX4" class="4 DX4PointerCheckbox"
                                                                                    onclick="return DxPointer4Check(event, this);" style="margin: 6px;" />
                                                                            </div>
                                                                            <div>
                                                                                <asp:CheckBox ID="cbDXPointer5" runat="server" Text="DX5" class="5 DX4PointerCheckbox"
                                                                                    onclick="return DxPointer5Check(event, this);" style="margin: 6px;" />
                                                                            </div>
                                                                            <div>
                                                                                <asp:CheckBox ID="cbDXPointer6" runat="server" Text="DX6" class="6 DX4PointerCheckbox"
                                                                                    onclick="return DxPointer6Check(event, this);" style="margin: 6px;" />
                                                                            </div>
                                                                            <div>
                                                                                <asp:CheckBox ID="cbDXPointer7" runat="server" Text="DX7" class="7 DX4PointerCheckbox"
                                                                                    onclick="return DxPointer7Check(event, this);" style="margin: 6px;" />
                                                                            </div>
                                                                            <div>
                                                                                <asp:CheckBox ID="cbDXPointer8" runat="server" Text="DX8" class="8 DX4PointerCheckbox"
                                                                                    onclick="return DxPointer8Check(event, this);" style="margin: 6px;" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="divBottom">
                                                                            <input type="button" onclick="PopulatePointers(this)" value="OK" style="font-size: 10px;
                                                                                min-width: 65px;float:left" />
                                                                            <input type="button" onclick="ResetPointers(this);" value="Cancel" style="margin-right: 5px;
                                                                                font-size: 10px; min-width: 65px;" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <input type="text" value='<%#Eval("ServiceUnits") %>' title='<%#Eval("ServiceUnits") %>' class="txtUnits" onchange="addServiceRow(this);" onkeypress="return ValidateOnlyNumber(event);" />
                                                            </td>
                                                            <td align="center">
                                                                <input type="text" class="txtModifier1 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" value='<%#Eval("Modifier1") %>' title='<%#Eval("Modifier1") %>' onchange="addServiceRow(this);" />
                                                                <input type="text" class="txtModifier2 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" value='<%#Eval("Modifier2") %>' title='<%#Eval("Modifier2") %>' onchange="addServiceRow(this);" />
                                                                <input type="text" class="txtModifier3 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" value='<%#Eval("Modifier3") %>' title='<%#Eval("Modifier3") %>' onchange="addServiceRow(this);" />
                                                                <input type="text" class="txtModifier4 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" value='<%#Eval("Modifier4") %>' title='<%#Eval("Modifier4") %>' onchange="addServiceRow(this);" />
                                                            </td>
                                                            <td>
                                                                <input type="text" value='<%#Eval("TotalCharges") %>' title='<%#Eval("TotalCharges") %>' class="txtCharges" onchange="addServiceRow(this);" onkeypress="return ValidateDecimalLimitedDigitBeforeDecimalPoint(event, this,8,2);" />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList runat="server" ID="ddlBillingStatus" CssClass="ddlBillingStatus" onchange="addServiceRow(this);">
                                                                    <asp:ListItem Value="N" Text="New"></asp:ListItem>
                                                                    <asp:ListItem Value="B" Text="Billed"></asp:ListItem>
                                                                    <asp:ListItem Value="R" Text="Rebilled"></asp:ListItem>
                                                                    <asp:ListItem Value="P" Text="Paidup"></asp:ListItem>
                                                                    <asp:ListItem Value="D" Text="Rejected"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="action">
                                                                <div>
                                                                    <span class="spndelete" title="Delete" onclick="deleteServiceRow(this);"></span>

                                                                    <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'Procedure', 'ClaimForm');"></span>
                                                    
                                                                    <input type="hidden" class="hdnCPTCode" value='<%#Eval("CPTCode")%>' />
                                                                </div>
                                                                <input type="hidden" class="hdnClaimChargesId" value='<%#Eval("ClaimChargesId") %>' />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr class="lastServiceRow">
                                                    <td align="center">
                                                        <asp:CheckBox ID="CheckBox11" runat="server" CssClass="cbIncludeInSubmission" />
                                                    </td>
                                                    <td style="position: relative;">
                                                        <input type="text" class="txtProcedures" autocomplete="off" onkeyup="searchCPTs(this, event);" />
                                                        <input type="hidden" class="hdnProceduresCode" />
                                                    </td>
                                                    <td style="position: relative;">
                                                        <input type="text" class="txtDrug" autocomplete="off" onkeyup="SearchDrugs(this)" />
                                                        <input type="hidden" class="hdnDrug"  />

                                                        <div class="Grid divDrugSearchList" style="width: 560px; display: none; position: absolute; max-height: 400px; overflow-y: auto;overflow-x: hidden; z-index: 1000;">
                                                            <table style="width: 100%;">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            HCPCS Code
                                                                        </th>
                                                                        <th>
                                                                            Drug Name
                                                                        </th>
                                                                        <th>
                                                                            Description
                                                                        </th>
                                                                        <th>
                                                                            Labeler Name
                                                                        </th>
                                                                        <th>
                                                                            NDC
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody class="tbodyClaimDrugs"></tbody>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td style="position: relative;">
                                                        <select class="ddlUnitCode">
                                                            <option value=""></option>
                                                            <option value="F2">International Unit</option>
                                                            <option value="GR">Gram</option>
                                                            <option value="ME">Milligram</option>
                                                            <option value="ML">Milliliter</option>
                                                            <option value="UN">Unit</option>
                                                        </select>
                                                    </td>
                                                    <td style="position: relative;">
                                                        <div style="width: 100%; float: left;">
                                                            <a onclick="HideShowMenuPointer(this);" class="drop-down-box">
                                                                <asp:Label ID="Label1" runat="server" CssClass="selectedText" style="width: 62px;"></asp:Label>
                                                                <span class="dropDownIconMultipleCheckBox"></span>
                                                            </a>
                                                            <div class="dropdownMenuMultipleCheckBox">
                                                                <div class="div-drop-down">
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox5" runat="server" Text="DX1" class="1 DX1PointerCheckbox"
                                                                            onclick="return DxPointer1Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox6" runat="server" Text="DX2" class="2 DX2PointerCheckbox"
                                                                            onclick="return DxPointer2Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox7" runat="server" Text="DX3" class="3 DX3PointerCheckbox"
                                                                            onclick="return DxPointer3Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox8" runat="server" Text="DX4" class="4 DX4PointerCheckbox"
                                                                            onclick="return DxPointer4Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox9" runat="server" Text="DX5" class="5 DX4PointerCheckbox"
                                                                            onclick="return DxPointer5Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox10" runat="server" Text="DX6" class="6 DX4PointerCheckbox"
                                                                            onclick="return DxPointer6Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox111" runat="server" Text="DX7" class="7 DX4PointerCheckbox"
                                                                            onclick="return DxPointer7Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox12" runat="server" Text="DX8" class="8 DX4PointerCheckbox"
                                                                            onclick="return DxPointer8Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                </div>
                                                                <div class="divBottom">
                                                                    <input type="button" onclick="PopulatePointers(this)" value="OK" style="font-size: 10px;
                                                                        min-width: 65px;float: left;" />
                                                                    <input type="button" onclick="ResetPointers(this);" value="Cancel" style="margin-right: 5px;
                                                                        font-size: 10px; min-width: 65px;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <input type="text" class="txtUnits" onchange="addServiceRow(this);" onkeypress="return ValidateOnlyNumber(event);" />
                                                    </td>
                                                    <td align="center">
                                                        <input type="text" class="txtModifier1 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" onchange="addServiceRow(this);" />
                                                        <input type="text" class="txtModifier2 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" onchange="addServiceRow(this);" />
                                                        <input type="text" class="txtModifier3 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" onchange="addServiceRow(this);" />
                                                        <input type="text" class="txtModifier4 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" onchange="addServiceRow(this);" />
                                                    </td>
                                                    <td>
                                                        <input type="text" class="txtCharges" onchange="addServiceRow(this);" onkeypress="return ValidateDecimalLimitedDigitBeforeDecimalPoint(event, this,8,2);" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="DropDownList2" CssClass="ddlBillingStatus" onchange="addServiceRow(this);">
                                                            <asp:ListItem Value="N" Text="New"></asp:ListItem>
                                                            <asp:ListItem Value="B" Text="Billed"></asp:ListItem>
                                                            <asp:ListItem Value="R" Text="Rebilled"></asp:ListItem>
                                                            <asp:ListItem Value="P" Text="Paidup"></asp:ListItem>
                                                            <asp:ListItem Value="D" Text="Rejected"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="action">
                                                        <div>
                                                            <span class="spndelete" title="Delete" onclick="deleteServiceRow(this);"></span>

                                                            <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'Procedure', 'ClaimForm');"></span>
                                                    
                                                            <input type="hidden" class="hdnCPTCode" value="" />
                                                        </div>
                                                        <input type="hidden" class="hdnClaimChargesId" value='0' />
                                                        <input type="hidden" class="hdnClaimCPTCharges" value='0' />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div id="divCPTSearched" style="width: 500px; height: 305px; position: absolute; display: none; background-color: #fff; z-index: 999;border: 1px solid rgb(211, 211, 211); padding-bottom:31px;">
                                        <div class="Grid" style="width: 99%; height: 300px;overflow-y: auto;">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            Code
                                                        </th>
                                                        <th>
                                                            Description
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="CPTSearchedList"></tbody>
                                            </table>
                                        </div>
                                    </div>

                                    <div style="display: none;">
                                        <table>
                                            <tbody id="tbodySampleServiceRow">
                                                <tr class="lastServiceRow">
                                                    <td align="center">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="cbIncludeInSubmission" />
                                                    </td>
                                                    <td style="position: relative;">
                                                        <input type="text" class="txtProcedures" autocomplete="off" onkeyup="searchCPTs(this, event);" />
                                                        <input type="hidden" class="hdnProceduresCode" />
                                                    </td>
                                                    <td style="position: relative;">
                                                        <input type="text" class="txtDrug" autocomplete="off" onkeyup="SearchDrugs(this)" />
                                                        <input type="hidden" class="hdnDrug"  />
                                                        
                                                        <div class="Grid divDrugSearchList" style="width: 560px; display: none; position: absolute; max-height: 400px; overflow-y: auto;overflow-x: hidden; z-index: 1000;">
                                                            <table style="width: 100%;">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            HCPCS Code
                                                                        </th>
                                                                        <th>
                                                                            Drug Name
                                                                        </th>
                                                                        <th>
                                                                            Description
                                                                        </th>
                                                                        <th>
                                                                            Labeler Name
                                                                        </th>
                                                                        <th>
                                                                            NDC
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody class="tbodyClaimDrugs"></tbody>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td style="position: relative;">
                                                        <select class="ddlUnitCode">
                                                            <option value=""></option>
                                                            <option value="F2">International Unit</option>
                                                            <option value="GR">Gram</option>
                                                            <option value="ME">Milligram</option>
                                                            <option value="ML">Milliliter</option>
                                                            <option value="UN">Unit</option>
                                                        </select>
                                                    </td>
                                                    <td style="position: relative;">
                                                        <div style="width: 100%; float: left;">
                                                            <a onclick="HideShowMenuPointer(this);" class="drop-down-box">
                                                                <asp:Label ID="Label2" runat="server" CssClass="selectedText" style="width: 62px;"></asp:Label>
                                                                <span class="dropDownIconMultipleCheckBox"></span>
                                                            </a>
                                                            <div class="dropdownMenuMultipleCheckBox">
                                                                <div class="div-drop-down">
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text="DX1" class="1 DX1PointerCheckbox"
                                                                            onclick="return DxPointer1Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text="DX2" class="2 DX2PointerCheckbox"
                                                                            onclick="return DxPointer2Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox4" runat="server" Text="DX3" class="3 DX3PointerCheckbox"
                                                                            onclick="return DxPointer3Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox13" runat="server" Text="DX4" class="4 DX4PointerCheckbox"
                                                                            onclick="return DxPointer4Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox14" runat="server" Text="DX5" class="5 DX4PointerCheckbox"
                                                                            onclick="return DxPointer5Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox15" runat="server" Text="DX6" class="6 DX4PointerCheckbox"
                                                                            onclick="return DxPointer6Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox16" runat="server" Text="DX7" class="7 DX4PointerCheckbox"
                                                                            onclick="return DxPointer7Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                    <div>
                                                                        <asp:CheckBox ID="CheckBox17" runat="server" Text="DX8" class="8 DX4PointerCheckbox"
                                                                            onclick="return DxPointer8Check(event, this);" style="margin: 6px;" />
                                                                    </div>
                                                                </div>
                                                                <div class="divBottom">
                                                                    <input type="button" onclick="PopulatePointers(this)" value="OK" style="font-size: 10px;
                                                                        min-width: 65px;float: left;" />
                                                                    <input type="button" onclick="ResetPointers(this);" value="Cancel" style="margin-right: 5px;
                                                                        font-size: 10px; min-width: 65px;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <input type="text" class="txtUnits" onchange="addServiceRow(this);" onkeypress="return ValidateOnlyNumber(event);" />
                                                    </td>
                                                    <td align="center">
                                                        <input type="text" class="txtModifier1 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" onchange="addServiceRow(this);" />
                                                        <input type="text" class="txtModifier2 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" onchange="addServiceRow(this);" />
                                                        <input type="text" class="txtModifier3 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" onchange="addServiceRow(this);" />
                                                        <input type="text" class="txtModifier4 modifiers" autocomplete="off" onkeyup="searchModifiers(this);" onchange="addServiceRow(this);" />
                                                    </td>
                                                    <td>
                                                        <input type="text" class="txtCharges" onchange="addServiceRow(this);" onkeypress="return ValidateDecimalLimitedDigitBeforeDecimalPoint(event, this,8,2);" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="DropDownList1" CssClass="ddlBillingStatus" onchange="addServiceRow(this);">
                                                            <asp:ListItem Value="N" Text="New"></asp:ListItem>
                                                            <asp:ListItem Value="B" Text="Billed"></asp:ListItem>
                                                            <asp:ListItem Value="R" Text="Rebilled"></asp:ListItem>
                                                            <asp:ListItem Value="P" Text="Paidup"></asp:ListItem>
                                                            <asp:ListItem Value="D" Text="Rejected"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="action">
                                                        <div>
                                                            <span class="spndelete" title="Delete" onclick="deleteServiceRow(this);"></span>

                                                            <span class="spnview" title="View" onclick="LCD_OpenForm(this, 'Procedure', 'ClaimForm');"></span>
                                                    
                                                            <input type="hidden" class="hdnCPTCode" value="" />
                                                        </div>
                                                        <input type="hidden" class="hdnClaimChargesId" value='0' />
                                                        <input type="hidden" class="hdnClaimCPTCharges" value='0' />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>

                            <div class="Widget divAdvanceOption" style="width: 100%; margin-bottom: 5px; display:none;">
                                <div class="WidgetTitle">
                                    <span class="widget-services-icon"></span>Advance Options
                                </div>
                                <div class="WidgetContent">
                                    <h2>Patient's Condition</h2>
                                    <div class="claim-top">
                                        <table style="width:70%">
                                            <tr>
                               
                                                <td style="width:20%">
                                                    <asp:CheckBox ID="chkEmployment" runat="server" onchange="uncheckOtherAccident()" Text="Employment" />
                                                </td>
                                                <td style="width:20%">
                                                    <asp:CheckBox ID="chkAutoAccident" runat="server" onchange="uncheckOtherAccident()" Text="Auto Accident" />
                                                </td>
                                                <td style="width:10%">
                                                    Auto Accident State
                                                </td>
                                                <td style="width:20%">
                                                    <asp:DropDownList ID="ddlAutoAccidentState" runat="server" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width:20%">
                                                    <asp:CheckBox ID="chkOtherAccident" runat="server" onchange="checkOtherAccident()" Text="Other Accident" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <h2>Dates</h2>
                                    <div class="claim-top">
                                        <table>
                                            <tr>
                                                <td style="width:6%">
                                                    Admission Date:
                                                </td>
                                                <td style="width:14%">
                                                    <asp:TextBox ID="txtAdmissionDate" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="width:6%">
                                                    Discharge Date:
                                                </td>
                                                <td style="width:14%">
                                                    <asp:TextBox ID="txtDischargeDate" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="width:6%">
                                                    Onset of Current Illness:
                                                </td>
                                                <td style="width:14%">
                                                    <asp:TextBox ID="txtCurrentIllness" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="width:6%">
                                                    Xray Date:
                                                </td>
                                                <td style="width:14%">
                                                    <asp:TextBox ID="txtXryDate" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="width:6%">
                                                    Acute Manifestation:
                                                </td>
                                                <td style="width:14%">
                                                    <asp:TextBox ID="txtAcuteManifestation" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date of Accident:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDateOfAccident" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="tdFemale" style="display:none;">
                                                    LMP:
                                                </td>
                                                <td class="tdFemale" style="display:none;">
                                                    <asp:TextBox ID="txtLMP" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Initial treatment Date:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtInitialTreatmentDate" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Last Seen Date:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLastSeenDate" CssClass="Date" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="margin-top:12px; float:left">
                                        <h2>Patient Payment</h2>
                                        <div class="claim-top">
                                            <table>
                                                <tr>
                                                    <td style="width:9%">
                                                        Patient Paid Amount:
                                                    </td>
                                                    <td style="width:10%">
                                                        <asp:TextBox ID="txtPatientPaidAmmount" onkeypress="return ValidateDecimalLimitedDigitBeforeDecimalPoint(event, this,8,2);"  runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width:14%">
                                                        Service Authorization Exception:
                                                    </td>
                                                    <td style="width:10%">
                                                        <asp:TextBox ID="txtServiceAuthorizationException" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width:16%">
                                                        Mammography Certification Number:
                                                    </td>
                                                    <td style="width:10%">
                                                        <asp:TextBox ID="txtMammographyCertificationNumber" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width:7%">
                                                        CLIA Number:
                                                    </td>
                                                    <td style="width:9%">
                                                        <asp:TextBox ID="txtCLIANumber" runat="server" MaxLength="10"></asp:TextBox>
                                                    </td>
                                                    <td style="width:8%">
                                                        ICN/DCN Number:
                                                    </td>
                                                    <td style="width:7%">
                                                        <asp:TextBox ID="txtICNDCN" runat="server" MaxLength="20"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div style="margin-top:12px; float:left">
                                        <h2 >Ambulance</h2>
                                        <div class="claim-top">
                                            <div style="width:49%;float:left;margin-right:1%">
                                                <fieldset>
                                                    <legend style="font-size: 14px;font-weight: bold;">Ambulance Pickup Location</legend>
                                                    <table>
                                                        <tr>
                                                            <td style="width:15%">
                                                                Address:
                                                            </td>
                                                            <td style="width:50%">
                                                                <asp:TextBox ID="txtAmbulancePickUpLocationAddress" style="resize:none;" TextMode="MultiLine" runat="server" Rows="2" Columns="29"></asp:TextBox>
                                                            </td>
                                                            <td style="width:9%">
                                                                Zip:
                                                            </td>
                                                            <td style="width:37%">
                                                                <asp:TextBox ID="txtAmbulancePickUpLocationZip" onkeypress="return ValidateNumber(event)"
                                                                    runat="server" onblur="getStateCity('txtAmbulancePickUpLocationZip','txtAmbulancePickUpLocationCity','ddlAmbulancePickUpLocationState');"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                City:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAmbulancePickUpLocationCity" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                State:
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlAmbulancePickUpLocationState" runat="server" Enabled="false">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </div>
                                            <div style="width:49%;float:left;margin-right:1%">
                                                <fieldset>
                                                    <legend style="font-size: 14px;font-weight: bold;">Ambulance Drop-Off Location</legend>
                                                    <table>
                                                        <tr>
                                                            <td style="width:15%">
                                                                Address:
                                                            </td>
                                                            <td style="width:50%">
                                                                <asp:TextBox ID="txtAmbulanceDropLocationAddress" style="resize:none;" TextMode="MultiLine" runat="server" Rows="2" Columns="29"></asp:TextBox>
                                                            </td>
                                                            <td style="width:9%">
                                                                Zip:
                                                            </td>
                                                            <td style="width:39%">
                                                                <asp:TextBox ID="txtAmbulanceDropLocationZip" onkeypress="return ValidateNumber(event)"
                                                                    runat="server" onblur="getStateCity('txtAmbulanceDropLocationZip','txtAmbulanceDropLocationCity','ddlAmbulanceDropLocationState');"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                City:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAmbulanceDropLocationCity" runat="server" Enabled="false"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                State:
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlAmbulanceDropLocationState" runat="server" Enabled="false">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </div>
                                            <table style=" margin-top: 11px; float: left; ">
                                                <tr>
                                                    <td style="width:14%">
                                                        Transportation Reason Code:
                                                    </td>
                                                    <td style="width:38%">
                                                        <asp:DropDownList ID="ddlTransportationReasonCode" runat="server">
                                                        <asp:ListItem Text="Patient was transported to nearest facility for care of symptoms, complaints, or both" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="Patient was transported for the benefit of a preferred physician" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Patient was transported for the nearness of family members" Value="C"></asp:ListItem>
                                                        <asp:ListItem Text="Patient was transported for the care of a specialist or for availability of specialized equipment" Value="D"></asp:ListItem>
                                                        <asp:ListItem Text="Patient Transferred to Rehabilitation Facility" Value="E"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width:8%">
                                                        Patient Weight:
                                                    </td>
                                                    <td style="width:10%">
                                                        <asp:TextBox ID="txtPatientWeight" onkeypress="return validateDecimal(event, this);" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style=" width: 5%; ">
                                                        <asp:DropDownList ID="ddlPatientWeightUnit" runat="server">
                                                            <asp:ListItem Value="kg" Text="kg"></asp:ListItem>
                                                            <asp:ListItem Value="lbs" Text="lbs"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width:9%">
                                                        Patient Condition:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPatientCondition" runat="server">
                                                            <asp:ListItem Value="A" Text="Acute Condition"></asp:ListItem>
                                                            <asp:ListItem Value="C" Text="Chronic Condition"></asp:ListItem>
                                                            <asp:ListItem Value="D" Text="Non-acute"></asp:ListItem>
                                                            <asp:ListItem Value="E" Text="Non-Life Threatening"></asp:ListItem>
                                                            <asp:ListItem Value="F" Text="Routine"></asp:ListItem>
                                                            <asp:ListItem Value="G" Text="Symptomatic"></asp:ListItem>
                                                            <asp:ListItem Value="M" Text="Acute Manifestation of a Chronic Condition"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div style="margin-top:12px; float:left">
                                        <h2>EPSDT  Services</h2>
                                        <div class="claim-top">
                                            <table>
                                                <tr>
                                                    <td style="width:14%">
                                                        Epsdt Condition Code:
                                                    </td>
                                                    <td style="width:38%">
                                                        <asp:DropDownList ID="ddlEpsdtCode" runat="server">
                                                            <asp:ListItem Text="Available - Not Used" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="Not Used" Value="NU"></asp:ListItem>
                                                            <asp:ListItem Text="Under Treatment" Value="S2"></asp:ListItem>
                                                            <asp:ListItem Text="New Services Requested" Value="ST"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width:8%">
                                                        Rendering Provider:
                                                    </td>
                                                    <td style="width:14%">
                                                        <asp:DropDownList ID="ddlRenderingPhysician" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width:9%">
                                                        Supervising Physician:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSupervisingPhysician" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div style="margin-top:12px; float:left">
                                        <h2>Service Facility Location</h2>
                                        <div class="claim-top">
                                            <table>
                                                <tr>
                                                    <td style="width:7%">
                                                        Location Name:
                                                    </td>
                                                    <td style="width:13%">
                                                        <asp:TextBox ID="txtServiceFacilityLocationName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width:3%">
                                                        NPI:
                                                    </td>
                                                    <td style="width:10%">
                                                        <asp:TextBox ID="txtServiceFacilityNPI" runat="server" MaxLength="10"></asp:TextBox>
                                                    </td>
                                                    <td style="width:5%">
                                                        Address:
                                                    </td>
                                                    <td style="width:16%">
                                                        <asp:TextBox ID="txtServiceFacilityAddress" style="resize:none;" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width:3%">
                                                        Zip:
                                                    </td>
                                                    <td style="width:8%">
                                                        <asp:TextBox ID="txtServiceFacilityZip" onkeypress="return ValidateNumber(event)"
                                                                    runat="server" onblur="getStateCity('txtServiceFacilityZip','txtServiceFacilityCity','ddlServiceFacilityState');"></asp:TextBox>
                                                    </td>
                                                    <td style="width:3%">
                                                        City:
                                                    </td>
                                                    <td style="width:14%">
                                                        <asp:TextBox ID="txtServiceFacilityCity"  runat="server" Enabled="false"></asp:TextBox>
                                                    </td>
                                                    <td style="width:3%">
                                                        State:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlServiceFacilityState" runat="server" Enabled="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divClaimPaymentMain" class="divs-claim-form-tabs" style="display:none;">
                            <div id="divPatientPaymentView">
                                <div class="block-clear" style="height: 25px;">
                                    <span class="blue-link" onclick="PatientPayment_ClickAddNewPayment();" style="float: right;">Add Payment</span>
                                </div>
                                <div class="block-clear">
                                    <div style="float:left; width: 19%;">
                                        <div class="small-box">
                                            <div class="box-head">
                                                <span class="heading">Claim Summary</span>
                                            </div>
                                            <div id="divClaimSummaryClaimForm" class="box-body">
                                                <table class="table-row-height-medium">
                                                    <tr>
                                                        <td style="width: 135px;">
                                                            <span class="label-medium-bold">Total Charges:</span>
                                                        </td>
                                                        <td align="right">
                                                            <span>$</span><span id="spnTotalChargesClaimSummary" runat="server" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Paid Amount:</span>
                                                        </td>
                                                        <td align="right">
                                                            <span>$</span><span id="spnPaidAmountClaimSummary" runat="server" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Adjusted Amount:</span>
                                                        </td>
                                                        <td align="right">
                                                            <span>$</span><span id="spnAdjustedAmountClaimSummary" runat="server" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Balance Due:</span>
                                                        </td>
                                                        <td align="right">
                                                            <span>$</span><span id="spnBalanceDueClaimSummary" runat="server" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float:left; width: 81%;">
                                        <div class="block-clear" style="height: 23px;">
                                            <span class="Grid-heading">Payment Summary</span>
                                        </div>
                                        <div class="block-clear">
                                            <div class="Grid-Simple">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th style="width: 8%;">
                                                                DOS
                                                            </th>
                                                            <th style="width: 19%;">
                                                                Service
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Charges
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Allowed Amount
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Paid Amount
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Pri Paid Amt
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Sec Paid Amt
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Oth Paid Amt
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Pat Paid Amt
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Adj Amt
                                                            </th>
                                                            <th style="width: 8%;">
                                                                Balance Due
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="tbodyPaymentSummaryClaimForm">
                                                        <asp:Repeater runat="server" ID="rptPaymentSummaryView">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <span class="spnDOS"><%# Eval("DOS")%></span>
                                                                    </td>
                                                                    <td title='<%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %>'>
                                                                        <span class="spnService"><%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnTotalCharges"><%# Eval("TotalCharges")%></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnAllowedAmount"><%# Eval("AllowedAmount")%></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnPaidAmount"><%# Eval("PaidAmount")%></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnPriInsPaidAmount"><%# Eval("PriInsPaidAmount")%></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnSecInsPaidAmount"><%# Eval("SecInsPaidAmount")%></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnOTHInsPaidAmount"><%# Eval("OTHInsPaidAmount")%></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnPatPaidAmount"><%# Eval("PatPaidAmount")%></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnAdjustedAmount"><%# Eval("AdjustedAmount")%></span>
                                                                    </td>
                                                                    <td>
                                                                        <span class="spnBalanceDue"><%# Eval("BalanceDue")%></span>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="block-clear" style="height: 20px;"></div>
                                <div class="block-clear">
                                    <div class="block-clear" style="height: 23px;">
                                        <span class="Grid-heading">Payment Detail</span>
                                    </div>
                                    <div class="block-clear">
                                        <div class="Grid-Simple">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th style="width: 8%;">
                                                            DOS
                                                        </th>
                                                        <th style="width: 19%;">
                                                            Service
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Insurance
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Payment Source
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Payment Method
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Check/Ref #
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Check Date
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Allowed Amt
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Paid Amt
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Adj Amt
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Action
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="tbodyPaymentDetailClaimForm">
                                                    <asp:Repeater runat="server" ID="rptPaymentDetailView" onitemdatabound="rptPaymentDetailView_ItemDataBound">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <span class="spnDOS"><%# Eval("DOS")%></span>
                                                                </td>
                                                                <td title='<%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %>'>
                                                                    <span class="spnService"><%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnInsuranceName"><%#Eval("InsuranceName")%></span>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="spnPaymentSource" CssClass="spnPaymentSource"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <span class="spnPaymentMethod"><%# Eval("PaymentMethod")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnCheckNumber"><%# Eval("CheckNumber")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnCheckIssueDate"><%# Eval("CheckIssueDate")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnAllowedAmount"><%# Eval("AllowedAmount")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnPaidAmount"><%# Eval("PaidAmount")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnAdjustedAmount"><%# Eval("AdjustedAmount")%></span>
                                                                </td>
                                                                <td class="action">
                                                                    <div>
                                                                        <span title="Edit" class="spnedit" onclick="Click_Edit_ClaimDetail_ClaimForm(this);"></span>
                                                                        <span title="Delete" class="spndelete" onclick="Click_Delete_ClaimDetail_ClaimForm(this);"></span>

                                                                        <input type="hidden" class="hdnProcedurePaymentsId" value='<%#Eval("ProcedurePaymentsId") %>' />

                                                                        <input type="hidden" class="hdnERAMasterId" value='<%#Eval("ERAMasterId") %>' />
                                                                        <input type="hidden" class="hdnClaimId" value='<%#Eval("ClaimId") %>' />
                                                                        <input type="hidden" class="hdnChargedProcedure" value='<%#Eval("ChargedProcedure") %>' />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="divPatientPaymentAddPayment" style="display:none;">
                                <div class="block-clear">
                                    <div class="widget-sections" style="width: 72%; height: 210px; padding-left: 7px; padding-right: 7px;">
                                        <div name="divEFTTopFilterClaimForm" class="float-left-100" style="height: 25px;">
                                            <span class="Bold" style="float: left;">
                                                Check/EFT List
                                            </span>
                                            <span style="float: right; font-size: 12px; margin-left: 15px;">
                                                <label>
                                                    <input type="checkbox" name="chkUnsettledTransactions" checked="checked" onclick="PatientPayment_FilterERA(0, true);" />
                                                    Only Unsettled Transactions
                                                </label>
                                            </span>
                                            <span style="float: right; font-size: 12px; margin-left: 15px;">
                                                <label>
                                                    <input type="checkbox" name="chkPaymentPatient" onclick="PatientPayment_FilterERA(0, true);" />
                                                    Patient
                                                </label>
                                            </span>
                                            <span style="float: right; font-size: 12px; margin-left: 15px;">
                                                <label>
                                                    <input type="checkbox" name="chkPaymentOther" onclick="PatientPayment_FilterERA(0, true);" />
                                                    Other
                                                </label>
                                            </span>
                                            <span style="float: right; font-size: 12px; margin-left: 15px;">
                                                <label>
                                                    <input type="checkbox" name="chkPaymentSecondary" onclick="PatientPayment_FilterERA(0, true);" />
                                                    Secondary
                                                </label>
                                            </span>
                                            <span style="float: right; font-size: 12px; margin-left: 15px;">
                                                <label>
                                                    <input type="checkbox" name="chkPaymentPrimary" checked="checked" onclick="PatientPayment_FilterERA(0, true);" />
                                                    Primary
                                                </label>
                                            </span>
                                        </div>
                                        <div class="float-left-100">
                                            <div name="divGridERAList" id="divGridERAList" class="Grid-Simple">
                                                <div style="height: 155px; overflow-y: auto;">
                                                    <table>
                                                        <thead>
                                                            <tr>
                                                                <th style="display:none;"></th>
                                                                <th style="width: 10%;">
                                                                    Check Date
                                                                </th>
                                                                <th style="width: 20%;">
                                                                    Check/Ref No
                                                                </th>
                                                                <th style="width: 30%;">
                                                                    Payer Name
                                                                </th>
                                                                <th style="width: 10%;">
                                                                    Check Amount
                                                                </th>
                                                                <th style="width: 10%;">
                                                                    Posted Amount
                                                                </th>
                                                                <th style="width: 10%;">
                                                                    Left To Allocate
                                                                </th>
                                                                <th style="width: 10%;">
                                                                    Allocate
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <th style="display:none;"></th>
                                                                <th>
                                                                    <input type="text" name="txtDateFilterERA" class="date-era-filter" onkeyup="PatientPayment_FilterERA(0, true);" />
                                                                </th>
                                                                <th>
                                                                    <input type="text" name="txtReferenceNoFilterERA" onkeyup="PatientPayment_FilterERA(0, true);" />
                                                                </th>
                                                                <th>
                                                                    <input type="text" name="txtPayerNameFilterERA" onkeyup="PatientPayment_FilterERA(0, true);" />
                                                                </th>
                                                                <th>
                                                                    <input type="text" name="txtTotalAmountFilterERA" onkeyup="PatientPayment_FilterERA(0, true);" />
                                                                </th>
                                                                <th>
                                                                    <input type="text" name="txtPaymentPostedFilterERA" onkeyup="PatientPayment_FilterERA(0, true);" />
                                                                </th>
                                                                <th>
                                                                </th>
                                                                <th>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody name="tbodyERAList">
                                                            <asp:Repeater runat="server" ID="rptERA">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td style="display:none;">
                                                                            <i><%# Eval("RowNumber")%></i>
                                                                        </td>
                                                                        <td>
                                                                            <span class="spnCheckIssueDate"><%# Eval("CheckIssueDate")%></span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="spnCheckNumber"><%# Eval("CheckNumber")%></span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="spnPayerName"><%# Eval("PayerName")%></span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="spnPaymentAmount"><%# Eval("PaymentAmount")%></span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="spnPostedAmount"><%# Eval("PaymentPosted")%></span>
                                                                        </td>
                                                                        <td>
                                                                            <span class="spnLeftToAllocate"><%# Eval("LeftToAllocate")%></span>
                                                                        </td>
                                                                        <td class="action">
                                                                            <div>
                                                                                <span class="spnallocate" title="Allocate" onclick="PatientPayment_ClickAllocate(this);"></span>
                                                                            </div>
                                                        
                                                        
                                                                            <input type="hidden" class="hdnERAMasterId" value='<%# Eval("ERAMasterId")%>' />
                                                                            <input type="hidden" class="hdnPaymentPosted" value='<%# Eval("PaymentPosted")%>' />
                                                                            <input type="hidden" class="hdnPaymentMethodCode" value='<%# Eval("PaymentMethodCode")%>' />
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            
                                                <div class="message">
                                                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>

                                                    <div class="PageButtons">
                                                        <ul style="float: right; margin-right: 15px;">
                                                        </ul>
                                                    </div>
                                                </div>                    
                                                <asp:HiddenField ID="hdnPatientPaymentsCount" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widget-sections" style="float: right; width: 24%; height: 210px; padding-left: 7px; padding-right: 7px;">
                                        <div name="divAddPayment">
                                            <div class="float-left-100">
                                                <table>
                                                    <tr>
                                                        <td colspan="2">
                                                            <span class="Bold" style="float: left; width: 100%; border-bottom: 1px solid; padding: 0 0 6px; margin: 0 0 5px;">
                                                                New Payment
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 115px;">
                                                            <span class="label-medium-bold">Payer:</span>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="ddlPayerPatientPayment" CssClass="ddlPayerPatientPayment"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Payment Method:</span>
                                                        </td>
                                                        <td>
                                                            <select name="ddlPaymentMethod">
                                                                <option value="ACH">Automated Clearing House</option>
                                                                <option value="BOP">Financial Institution Option</option>
                                                                <option value="Check">Check</option>
                                                                <option value="Federal Reserve Funds">Federal Reserve Funds</option>
                                                                <option value="NON">Non-Payment Data</option>
                                                                <option value="American Express">American Express</option>
                                                                <option value="Cash">Cash</option>
                                                                <option value="Discover">Discover</option>
                                                                <option value="Master Card">Master Card</option>
                                                                <option value="Money Order">Money Order</option>
                                                                <option value="Visa Card">Visa Card</option>
                                                            </select>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Date:</span>
                                                        </td>
                                                        <td>
                                                            <input type="text" name="txtPaymentDateNewPayment" class="date" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Check/Reference No:</span>
                                                        </td>
                                                        <td>
                                                            <input type="text" name="txtReferenceNumber" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Paid Amount:</span>
                                                        </td>
                                                        <td>
                                                            <input type="text" name="txtPaidAmount" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="action-button-wrapper" style="margin: 5px 0 0;">
                                                <input type="button" value="Save & Allocate" onclick="PatientPayment_SaveAndAllocate(true);" />
                                                <input type="button" value="Save" onclick="PatientPayment_SaveAndAllocate(false);" style="margin-right: 5px;" />
                                            </div>
                                        </div>
                                        <div name="divPaymentDetail" style="display:none;">
                                            <div class="float-left-100">
                                                <table class="table-row-height-medium">
                                                    <tr>
                                                        <td colspan="2" style="border-bottom: 1px solid;">
                                                            <span class="Bold" style="float: left; padding: 0 0 6px;">
                                                                Check/Ref No:
                                                            </span>
                                                            <span name="spnReferenceNo" style="float: left; margin: 0 0 0 5px;"></span>

                                                            <a href="javascript:void(0);" style="color: Blue; text-decoration: underline; float: right; font-size: 11px; font-weight: bold;" onclick="PatientPayment_HideShowNewPaymentForm(true);">
                                                                New Payment
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="padding-top: 10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 135px;">
                                                            <span class="label-medium-bold">Payer:</span>
                                                        </td>
                                                        <td>
                                                            <span name="spnPayerPatientPayment" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Payment Method:</span>
                                                        </td>
                                                        <td>
                                                            <span name="spnPaymentMethod" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Payment Date:</span>
                                                        </td>
                                                        <td>
                                                            <span name="spnPaymentDate" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Allocated Amount:</span>
                                                        </td>
                                                        <td>
                                                            <span name="spnPaymentAllocated" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <span class="label-medium-bold">Left to Allocate:</span>
                                                        </td>
                                                        <td>
                                                            <span name="spnPaymentLeftToAllocate" class="font-size-medium"></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="block-clear">
                                    <div class="widget-sections" style="padding-left: 1%; padding-right: 1%; width: 98%; height: 200px;">
                                        <div class="float-left-100" style="height: 35px;">
                                            <div style="float: left;">
                                                <span class="Bold">
                                                    Services
                                                </span>
                                            </div>
                                            <div style="float: right;">
                                                <input type="button" value="Save" onclick="PatientPayment_SavePaymentAllocation(false);" />
                                                <input type="button" value="Cancel" onclick="PatientPayment_ResetServicesGrid();" />
                                                <input type="button" value="Done" onclick="PatientPayment_DonePayment();" />
                                            </div>
                                            <div style="float: right; display:none;">
                                                <input type="button" value="Save Allocation" onclick="PatientPayment_SavePaymentAllocation(false);" />
                                                <input type="button" value="Save & Print" onclick="PatientPayment_SavePaymentAllocation(true);" />
                                            </div>
                                        </div>
                                        <div class="Grid-Simple" style="height: 165px; overflow-y: auto;">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th style="width: 10%;">
                                                            DOS
                                                        </th>
                                                        <th style="width: 20%;">
                                                            Service
                                                        </th>
                                                        <th style="width: 10%;">
                                                            Payment Source
                                                        </th>
                                                        <th style="width: 10%;">
                                                            Charges
                                                        </th>
                                                        <th style="width: 10%;">
                                                            Paid (Total)
                                                        </th>
                                                        <th style="width: 10%;">
                                                            Adjusted (Total)
                                                        </th>
                                                        <th style="width: 10%;">
                                                            Allowed Amt
                                                        </th>
                                                        <th style="width: 10%;">
                                                            Payment
                                                        </th>
                                                        <th style="width: 10%;">
                                                            Adjustment
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody name="tbodyPatientServices">
                                                    <asp:Repeater ID="rptPatientServicesPayments" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <span class="spnDOS"><%# Eval("DOS")%></span>
                                                                </td>
                                                                <td title='<%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %>'>
                                                                    <span class="spnService"><%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %></span>
                                                                </td>
                                                                <td>
                                                                    <select class="ddlPaymentSourceServicesPayment">
                                                                        <option value="PRI">Primary</option>
                                                                        <option value="SEC">Secondary</option>
                                                                        <option value="OTH">Other</option>
                                                                        <option value="PAT">Patient</option>
                                                                    </select>
                                                                </td>
                                                                <td>
                                                                    <span class="spnTotalCharges"><%# Eval("TotalCharges")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnPaidAmount"><%# Eval("PaidAmount")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnAdjustedAmount"><%# Eval("AdjustedAmount")%></span>
                                                                </td>
                                                                <td>
                                                                    <input type="text" class="txtAllowedAmount" value="0.00" />
                                                                </td>
                                                                <td>
                                                                    <input type="text" class="txtPaidAmountThisAllocation" onkeyup="PatientPayment_CalculateDueAmount(this);" />
                                                                </td>
                                                                <td align="center">
                                                                    <span class="blue-link underline" onclick="PatientPayment_ClickAddEditAdjustment(this, 'PatientServices');">
                                                                        <span>$</span><span class="spnAdjustedAmount">0</span>
                                                                    </span>

                                                                    <input type="hidden" class="hdnClaimId" value='<%#Eval("ClaimId") %>' />
                                                                    <input type="hidden" class="hdnClaimChargesId" value='<%#Eval("ClaimChargesId") %>' />
                                        
                                                                    <input type="hidden" class="hdnPaidAmount" value='<%#Eval("PaidAmount") %>' />
                                                                    <input type="hidden" class="hdnAdjustedAmount" value='<%#Eval("AdjustedAmount") %>' />
                                                                    <input type="hidden" class="hdnAllowedAmount" value='<%#Eval("AllowedAmount") %>' />
                                                                
                                                                    <input type="hidden" class="hdnBalanceDue" value='<%#Eval("BalanceDue") %>' />
                                                                    <input type="hidden" class="hdnServiceUnits" value='<%#Eval("ServiceUnits") %>' />

                                                                    <input type="hidden" class="hdnCPTCode" value='<%#Eval("CPTCode") %>' />

                                                                    <div class="divDialogProcedureAdjustments" style="display:none;">
                                                                        <div class="Grid-Simple">
                                                                            <div class="grid-table-wrapper">
                                                                                <table>
                                                                                    <thead>
                                                                                        <tr>
                                                                                            <th>
                                                                                                Reason Code Group
                                                                                            </th>
                                                                                            <th>
                                                                                                Reason Code
                                                                                            </th>
                                                                                            <th>
                                                                                                Adjusted Amount
                                                                                            </th>
                                                                                            <th>
                                                                                                Action
                                                                                            </th>
                                                                                        </tr>
                                                                                    </thead>
                                                                                    <tbody class="tbodyProcedureAdjustments"></tbody>
                                                                                </table>
                                                                            </div>
                                                                            <div class="add-new-row-wrapper">
                                                                                <span class="spanAdd" onclick="PatientPayment_AddNewAdjustmentRow(this);">Add Adjustment</span>
                                                                            </div>
                                                                        </div>
                                                                        <div class="action-button-wrapper">
                                                                            <input type="button" value="Cancel" onclick="PatientPayment_Click_CancelAddProcedureAdjustments(this);" />
                                                                            <input type="button" value="Ok" onclick="PatientPayment_Click_OkAddProcedureAdjustments(this);" />
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div style="display:none;">
                                            <table>
                                                <tbody id="tbodySampleNewAdjustmentRowThisAllocation">
                                                    <tr>
                                                        <td>
                                                            <select class="ddlReasonCodeGroup">
                                                                <option value="CO">Contractual Obligations</option>
                                                                <option value="OA">Other adjustments</option>
                                                                <option value="PI">Payor Initiated Reductions</option>
                                                                <option value="PR">Patient Responsibility</option>
                                                            </select>
                                                        </td>
                                                        <td style="position: relative;">
                                                            <input type="text" class="txtReasonCode" onkeyup="PatientPayment_FilterReasonCodes(this);" />

                                                            <input type="hidden" class="hdnAdjustmentCode" value="" />
                                                            
                                                            <div class="divDropDownReasonCodeSearch" style="display: none; position: absolute; top: 33px; left: 4px; background: #fff; border: 1px solid lightgray; height: 155px; overflow-y: auto;">
                                                                <table>
                                                                    <tbody class="tbodyReasonCodesFilter"></tbody>
                                                                </table>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <input type="text" class="txtAdjustmentAmount" onkeypress="return validateDecimal(event, this);" />
                                                        </td>
                                                        <td class="action">
                                                            <div>
                                                                <span class="spandelete" title="Delete" onclick="PatientPayment_DeleteAdjustmentRow(this);"></span>

                                                                <input type="hidden" class="hdnProcedureAdjustmentId" value="0" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="block-clear">
                                    <div class="widget-sections" style="padding-left: 1%; padding-right: 1%; width: 98%; height: 200px;">
                                        <div class="float-left-100" style="height: 35px;">
                                            <div style="float: left;">
                                                <span class="Bold">
                                                    Payment History
                                                </span>
                                            </div>
                                        </div>
                                        <div class="Grid-Simple" style="height: 165px; overflow-y: auto;">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th style="width: 8%;">
                                                            DOS
                                                        </th>
                                                        <th style="width: 20%;">
                                                            Service
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Insurance
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Payment Source
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Payment Method
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Check/Ref #
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Check Date
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Allowed Amt
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Paid Amt
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Adjusted Amt
                                                        </th>
                                                        <th style="width: 8%;">
                                                            Action
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody name="tbodyPaymentHistory">
                                                    <asp:Repeater ID="rptPaymentHistory" runat="server" onitemdatabound="rptPaymentHistory_ItemDataBound">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <span class="spnDOS"><%# Eval("DOS")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnService"><%#Eval("CPTCode") %> - <%#Eval("CPTdescription") %></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnInsuranceName"><%# Eval("InsuranceName")%></span>
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="spnPaymentSource" CssClass="spnPaymentSource"></asp:Label>
                                                                    
                                                                    <select class="ddlPaymentSource" style="display:none;">
                                                                        <option value="PRI">Primary</option>
                                                                        <option value="SEC">Secondary</option>
                                                                        <option value="OTH">Other</option>
                                                                        <option value="PAT">Patient</option>
                                                                    </select>
                                                                </td>
                                                                <td>
                                                                    <span class="spnPaymentMethod"><%# Eval("PaymentMethod")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnCheckNumber"><%# Eval("CheckNumber")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnCheckIssueDate"><%# Eval("CheckIssueDate")%></span>
                                                                </td>
                                                                <td>
                                                                    <span class="spnAllowedAmount"><%# Eval("AllowedAmount")%></span>
                                                                    <input type="text" class="txtAllowedAmount" value='<%# Eval("AllowedAmount")%>' style="display:none;" />
                                                                </td>
                                                                <td>
                                                                    <span class="spnPaidAmount"><%# Eval("PaidAmount")%></span>
                                                                    <input type="text" class="txtPaidAmount" value='<%# Eval("PaidAmount")%>' style="display:none;" />
                                                                </td>
                                                                <td>
                                                                    <span class="spnAdjustedAmountView"><%# Eval("AdjustedAmount")%></span>

                                                                    <span style="display:none;" class="blue-link underline blue-link-spnAdjustedAmount" onclick="PatientPayment_ClickAddEditAdjustment(this, 'PaymentHistory');">
                                                                        <span>$</span><span class="spnAdjustedAmount"><%# Eval("AdjustedAmount")%></span>
                                                                    </span>
                                                                </td>
                                                                <td class="action">
                                                                    <div>
                                                                        <div class="divEditDelete">
                                                                            <span class="spnedit" title="Edit" onclick="PatientPayment_EditPaymentHistory(this);"></span>
                                                                        </div>
                                                                        <div class="divSaveCancel" style="display: none;">
                                                                            <span class="iconSave" title="Save" onclick="PatientPayment_SavePaymentHistory(this);"></span>
                                                                            <span class="spaneditcancel" title="Cancel" onclick="PatientPayment_EditCancelPaymentHistory(this);"></span>
                                                                        </div>
                                                                        
                                                                        <input type="hidden" class="hdnProcedurePaymentsId" value='<%#Eval("ProcedurePaymentsId") %>' />

                                                                        <input type="hidden" class="hdnERAMasterId" value='<%#Eval("ERAMasterId") %>' />
                                                                        <input type="hidden" class="hdnClaimId" value='<%#Eval("ClaimId") %>' />
                                                                        <input type="hidden" class="hdnChargedProcedure" value='<%#Eval("ChargedProcedure") %>' />
                                                                        
                                                                        <div class="divDialogProcedureAdjustments" style="display:none;">
                                                                            <div class="Grid-Simple">
                                                                                <div class="grid-table-wrapper">
                                                                                    <table>
                                                                                        <thead>
                                                                                            <tr>
                                                                                                <th>
                                                                                                    Reason Code Group
                                                                                                </th>
                                                                                                <th>
                                                                                                    Reason Code
                                                                                                </th>
                                                                                                <th>
                                                                                                    Adjusted Amount
                                                                                                </th>
                                                                                                <th>
                                                                                                    Action
                                                                                                </th>
                                                                                            </tr>
                                                                                        </thead>
                                                                                        <tbody class="tbodyProcedureAdjustments"></tbody>
                                                                                    </table>
                                                                                </div>
                                                                                <div class="add-new-row-wrapper">
                                                                                    <span class="spanAdd" onclick="PatientPayment_AddNewAdjustmentRow(this);">Add Adjustment</span>
                                                                                </div>
                                                                            </div>
                                                                            <div class="action-button-wrapper">
                                                                                <input type="button" value="Cancel" onclick="PatientPayment_Click_CancelAddProcedureAdjustments(this);" />
                                                                                <input type="button" value="Ok" onclick="PatientPayment_Click_OkAddProcedureAdjustments(this);" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divClaimNotesMain" class="divs-claim-form-tabs" style="display:none;"></div>
                    </div>
                </div>
            </div>
            
            
            <input type="hidden" id="hdninsuranceId" />
            <asp:Literal runat="server" ID="ltrProvidersByLocation"></asp:Literal>
            
            <script type="text/javascript">
                $(document).ready(function () {
                    hideClaimInfoForUpdateClaim();

                    $("[id$='txtDos'], .Date").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "1950:2050"
                    }).mask("99/99/9999");

                    //PatientPayment_InitializeForm();
                });

                function hideClaimInfoForUpdateClaim() {
                    var PatientId = $.trim($("[id$='lblPatientId']").html());
                    if (PatientId == "") {
                        return;
                    }
                    
                    $("#btnAddPatient").hide();
                }

                function ShowHideTabsClaimForm(elem, tab) {
                    $(elem).siblings().removeClass("active");
                    $(elem).addClass("active");

                    $(".divs-claim-form-tabs").hide();

                    if (tab == "General") {
                        $("[id$='divClaimGeneralMain']").show();
                    }
                    else if (tab == "Payment") {
                        $("[id$='divClaimPaymentMain']").show();
                    }
                    else if (tab == "Notes") {
                        if ($.trim($("[id$='divClaimNotesMain']").html()).length == 0) {
                            ClaimNotes_LoadNotes();
                        }
                        else {
                            $("[id$='divClaimNotesMain']").show();
                        }
                    }
                }
            </script>
            <style type="text/css">
                .claim-top
                {
                    width: 99%;
                    border: solid 1px #ccc;
                    border-radius: 2px;
                    padding: 4px;
                    float: left;
                    margin-top: 10px;
                    white-space: nowrap;
                }
                .claim-top input[type='text']
                {
                    width: 85%;
                }
                .claim-top select
                {
                    width: 93%;
                }
            </style>
            <style type="text/css">
                .grid-table-wrapper {
                    height: 250px;
                    overflow-y: auto;
                }
                .add-new-row-wrapper {
                    float: left;
                    padding: 10px 0 10px 1%;
                    border-top: 1px solid lightgray;
                    width: 99%;
                    margin: 15px 0 0;
                    background: #E7F1F8;
                }
            </style>
        </div>
        
        <div id="ServiceCharges" style="display:none;"></div>
        <div id="divDialogLCD" style="display:none;"></div>

        <script src="../../Scripts/LCD.js" type="text/javascript"></script>
        <script src="../../Scripts/PatientPayment.js" type="text/javascript"></script>
        <script src="../../Scripts/ClaimNotes.js" type="text/javascript"></script>
        
        ###EndClaim###
    </div>
    </form>
</body>
</html>
