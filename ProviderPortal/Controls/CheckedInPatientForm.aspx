<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckedInPatientForm.aspx.cs" Inherits="EMR_Controls_CheckedInPatientForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Scripts/jquery-1.9.0.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartForm###
    <style type="text/css">
        #dwtcontrolContainerCheckInForm_NonInstallCID
        {
            display:none;
        }
        #dwtcontrolContainerCheckInForm_NonInstallCID > div{
            display: none;
            border: none !important;
            text-align: center !important;
            width: 321px !important;
            height: 199px !important;
            position: absolute !important;
            right: 34px !important;
            top: 237px !important;
            background: #fff !important;
            z-index: 99999 !important;
        }
        #dwtcontrolContainerCheckInForm_NonInstallCID a{
            text-decoration: underline;
            color: blue;
        }
        #dwtcontrolContainerCheckInForm_Obj
        {
            width: 0 !important;
            height: 0 !important;
        }
        #dwtcontrolContainerCheckInForm_CID
        {
            width: 0 !important;
            height: 0 !important;
        }
        
        
        
        .table-with-row-height tbody tr
        {
            line-height: 24px;
        }
        
        
        .insurance-cards
        {
            height: 270px; background: #fff; border: 1px solid;
        }
        .insurance-cards img
        {
            width: 100%;
            height: 100%;
        }
        .div-insurance-cards-inner
        {
            position: relative;
            width: 100%;
            height: 100%;
        }
        .insurance-card-scan-header
        {
            position: absolute;
            top: 10px;
            right: 6px;
            width: 330px;
        }
        .insurance-cards-front-back-wrapper
        {
            height: 26px;
            margin: 33px 0 5px;
        }
        .insurance-edit-icon
        {
            position: absolute;
            right: 8px;
            top: 0;
        }
    </style>

    <asp:HiddenField runat="server" ID="hdnPatientIdCheckInForm" Value="0" />

    <div id="divCheckInFormInner" style="width: 740px; overflow-y: auto;">
        <div class="widget-sections" style="width: 95%;">
            <div class="float-left-100">
                <table>
                    <tr>
                        <td valign="top" style="width: 50%;">
                            <div class="patient-info-wrapper float-left-100" style="height: 120px;">
                                <div class="patient-photo-wrapper">
                                    <img runat="server" id="imgPatientPhoto" alt="" src="" />
                                </div>
                                <div class="patient-information">
                                    <ul>
                                        <li>
                                            <span class="gray Bold">Account No:</span>
                                            <span runat="server" id="spnAccountNo"></span>
                                        </li>
                                        <li>
                                            <span runat="server" id="spnPatientName" class="Bold"></span>
                                        </li>
                                        <li>
                                            <span runat="server" id="spnPatientDOB"></span>
                                            <span runat="server" id="spnPatientGenderMaritalStatus"></span>
                                        </li>
                                        <li>
                                            <span runat="server" id="spnPatientPhone"></span>
                                        </li>
                                        <li>
                                            <span runat="server" id="spnPatientAddress"></span>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>
                                        Check In Room:<span class="spnError">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPracticeRoomsCheckInForm" CssClass="required"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Check In Time:
                                    </td>
                                    <td>
                                        <input type="text" name="txtCheckInTimeCheckInForm" id="txtCheckInTimeCheckInForm" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="float-left-100">
                <div class="box">
                    <div class="box-header-patient">
                        <ul>
                            <li class="active" onclick="ShowHideTabsCheckInForm(this, 'P');">
                                <a href="#">Primary Insurance</a>
                            </li>
                            <li onclick="ShowHideTabsCheckInForm(this, 'S');">
                                <a href="#">Secondary Insurance</a>
                            </li>
                        </ul>
                    </div>
                    <div class="box-content" style="position: relative;">
                        <div class="header insurance-card-scan-header">
                            Insurance Card
                            <div style="float:right;">
                                <a href="javascript:void(0);" onclick="acquireImageCheckInForm();" class="scan-link" style="color: #1155CC; padding: 0 7px;">Scan</a>
                                                    
                                <div id="dwtcontrolContainerCheckInForm" class="DWTContainer" style="width: 0; height: 0;"></div>
                            </div>
                        </div>
                        <div id="divPatientPrimaryInsuranceCheckInForm" class="patient-insurances-forms">
                            <table>
                                <tr>
                                    <td valign="top" style="width: 50%;">
                                        <table class="table-with-row-height">
                                            <tr>
                                                <td style="width: 120px;">
                                                    Insurance Name:
                                                </td>
                                                <td style="position: relative;">
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceNameCheckInForm"></asp:Label>

                                                    <asp:HiddenField runat="server" ID="hdnPrimaryInsuranceIdCheckInForm" Value="0" />
                                                    <asp:HiddenField runat="server" ID="hdnPatientPrimaryInsuranceIdCheckInForm" Value="0" />

                                                    <span class="spanedit insurance-edit-icon" title="Edit" onclick="EditPatientInsuraceCheckInForm(this, 'P');"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Policy Number:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsurancePolicyNumberCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Group Name:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceGroupNameCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Group Number:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceGroupNumberCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Copay:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceCopayCheckInForm"></asp:Label>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceCopayTypeCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Coinsurance:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceCoinsuranceCheckInForm"></asp:Label>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceCoinsuranceTypeCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Deductable:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceDeductableCheckInForm"></asp:Label>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceDeductableTypeCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding: 10px 0 0;">
                                                    <span class="header">
                                                        Subscriber
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Relationship:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceRelationshipCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Last Name:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceSubscriberLastNameCheckInForm"></asp:Label>

                                                    <asp:HiddenField runat="server" ID="hdnPrimaryInsuranceSubscriberIdCheckInForm" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    First Name:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrimaryInsuranceSubscriberFirstNameCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <div class="insurance-cards-main-wrapper">
                                            <div class="float-left-100 insurance-cards-front-back-wrapper">
                                                <input type="button" value="Front" onclick="ShowHideInsuranceCardFrontBack(this, 'F');" />
                                                <input type="button" value="Back" onclick="ShowHideInsuranceCardFrontBack(this, 'B');" />
                                            </div>
                                            <div class="float-left-100">
                                                <div class="float-left-100 insurance-cards insurance-cards-front">
                                                    <div class="div-insurance-cards-inner">
                                                        <asp:Image runat="server" ID="imgPrimaryInsuranceCardFront" CssClass="image-insurance-cards" />
                                                        
                                                        <div class="hover-action-div">
                                                            <span class="spndelete" onclick="DeleteInsuranceCard(this)" style="margin-left: 4px;" title="Delete"></span>
                                                            <span class="spndownload" onclick="DownloadInsuranceCard(this)" style="margin-left: 4px;" title="Download"></span>
                                                        </div>
                                                        
                                                        <input type="hidden" runat="server" id="hdnPrimaryInsuranceCardFrontFilePath" class="hdnInsuranceCardFilePath" />
                                                    </div>
                                                </div>
                                                <div class="float-left-100 insurance-cards insurance-cards-back" style="display:none;"">
                                                    <div class="div-insurance-cards-inner">
                                                        <asp:Image runat="server" ID="imgPrimaryInsuranceCardBack" CssClass="image-insurance-cards" />
                                                        
                                                        <div class="hover-action-div">
                                                            <span class="spndelete" onclick="DeleteInsuranceCard(this)" style="margin-left: 4px;" title="Delete"></span>
                                                            <span class="spndownload" onclick="DownloadInsuranceCard(this)" style="margin-left: 4px;" title="Download"></span>
                                                        </div>
                                                        
                                                        <input type="hidden" runat="server" id="hdnPrimaryInsuranceCardBackFilePath" class="hdnInsuranceCardFilePath" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divPatientSecondaryInsuranceCheckInForm" class="patient-insurances-forms" style="display:none;">
                            <table>
                                <tr>
                                    <td valign="top" style="width: 50%;">
                                        <table class="table-with-row-height">
                                            <tr>
                                                <td style="width: 120px;">
                                                    Insurance Name:
                                                </td>
                                                <td style="position: relative;">
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceNameCheckInForm"></asp:Label>

                                                    <asp:HiddenField runat="server" ID="hdnSecondaryInsuranceIdCheckInForm" Value="0" />
                                                    <asp:HiddenField runat="server" ID="hdnPatientSecondaryInsuranceIdCheckInForm" Value="0" />

                                                    <span class="spanedit insurance-edit-icon" title="Edit" onclick="EditPatientInsuraceCheckInForm(this, 'S');"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Policy Number:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsurancePolicyNumberCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Group Name:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceGroupNameCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Group Number:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceGroupNumberCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Copay:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceCopayCheckInForm"></asp:Label>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceCopayTypeCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Coinsurance:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceCoinsuranceCheckInForm"></asp:Label>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceCoinsuranceTypeCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Deductable:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceDeductableCheckInForm"></asp:Label>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceDeductableTypeCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding: 10px 0 0;">
                                                    <span class="header">
                                                        Subscriber
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Relationship:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceRelationshipCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Last Name:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceSubscriberLastNameCheckInForm"></asp:Label>

                                                    <asp:HiddenField runat="server" ID="hdnSecondaryInsuranceSubscriberIdCheckInForm" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    First Name:
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblSecondaryInsuranceSubscriberFirstNameCheckInForm"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <div class="insurance-cards-main-wrapper">
                                            <div class="float-left-100 insurance-cards-front-back-wrapper">
                                                <input type="button" value="Front" onclick="ShowHideInsuranceCardFrontBack(this, 'F');" />
                                                <input type="button" value="Back" onclick="ShowHideInsuranceCardFrontBack(this, 'B');" />
                                            </div>
                                            <div class="float-left-100">
                                                <div class="float-left-100 insurance-cards insurance-cards-front">
                                                    <div class="div-insurance-cards-inner">
                                                        <asp:Image runat="server" ID="imgSecondaryInsuranceCardFront" CssClass="image-insurance-cards" />
                                                        
                                                        <div class="hover-action-div">
                                                            <span class="spndelete" onclick="DeleteInsuranceCard(this)" style="margin-left: 4px;" title="Delete"></span>
                                                            <span class="spndownload" onclick="DownloadInsuranceCard(this)" style="margin-left: 4px;" title="Download"></span>
                                                        </div>
                                                        
                                                        <input type="hidden" runat="server" id="hdnSecondaryInsuranceCardFrontFilePath" class="hdnInsuranceCardFilePath" />
                                                    </div>
                                                </div>
                                                <div class="float-left-100 insurance-cards insurance-cards-back" style="display:none;"">
                                                    <div class="div-insurance-cards-inner">
                                                        <asp:Image runat="server" ID="imgSecondaryInsuranceCardBack" CssClass="image-insurance-cards" />
                                                        
                                                        <div class="hover-action-div">
                                                            <span class="spndelete" onclick="DeleteInsuranceCard(this)" style="margin-left: 4px;" title="Delete"></span>
                                                            <span class="spndownload" onclick="DownloadInsuranceCard(this)" style="margin-left: 4px;" title="Download"></span>
                                                        </div>
                                                        
                                                        <input type="hidden" runat="server" id="hdnSecondaryInsuranceCardBackFilePath" class="hdnInsuranceCardFilePath" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="action-button-wrapper">
        <input type="button" value="Cancel" onclick="CloseCheckInForm();">
        <input type="button" value="Save" onclick="SaveCheckInForm();">
    </div>
    
    <script type="text/javascript" src="../Scripts/CheckInFormScan.js"></script>
    ###EndForm###
    </div>
    </form>
</body>
</html>
