<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaveClaimHandler.aspx.cs" Inherits="EMR_Claims_CallBacks_SaveClaimHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###StartBillingHandler###
        <asp:Repeater ID="rptClaims" runat="server" OnItemDataBound="rptClaims_ItemDataBound" >
            <ItemTemplate>
                <tr>
                    <td onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <i><%# Eval("ROWNUMBER")%></i>
                    </td>
                    <td>
                        <span onclick="loadCreateClaimForm(this);"><%# Eval("ClaimId")%></span>
                        <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                        <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                        <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                        <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                    </td>
                    <td onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <%# Eval("PatientId")%>
                    </td>
                    <td onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <%# Eval("PatientName")%>
                    </td>
                    <td style="text-align: center;cursor:pointer;" onclick="loadCreateClaimForm(this);" >
                        <%# Eval("ServiceDate", "{0:d}")%>
                    </td>
                    <td style="text-align: center;" onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <%# Eval("BillDate")%>
                    </td>
                    <td onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                    </td>
                    <td style="white-space: nowrap;cursor:pointer;" onclick="loadCreateClaimForm(this);" >
                        <%# Eval("SubmissionStatus")%>
                    </td>
                    <td align="center">
                        <a href="javascript:void(0);" onclick="printClaim(this);" title="Print Claim">
                            <img src="../../Images/invoice.png" />
                        </a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hdnClaimsCount" runat="server" />
        ###EndBillingHandler###
        
        ###StartClaimId###
        <asp:Literal runat="server" ID="ltrClaimId"></asp:Literal>
        ###EndClaimId###

        ###StartClaimServices###
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
                                <asp:CheckBox ID="CheckBox11" runat="server" Text="DX7" class="7 DX4PointerCheckbox"
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
        ###EndClaimServices###
    </form>
</body>
</html>
