<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Demographics.aspx.cs" Inherits="BillingManager_Patient_Demographics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../Scripts/Rizwan/Demographics.js"></script>
    <script src="../../Scripts/Eligibility.js"></script>
    <script src="../../Scripts/Demographics.js"></script>
    <script src="../../Scripts/Rizwan/PendingTransition.js"></script>
    <script src="../../Scripts/PatientInvoices.js"></script>
    <link href="../../StyleSheets/Demographics.css" media="print" rel="stylesheet" />
    <script src="../../jQueryPlugins/PrintThis/printThis.js"></script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hdnPatientId" />
    <asp:HiddenField runat="server" ID="hdnInsuranceId" />
    <div class="RBGDialogue" style="display: none"></div>



    <style type="text/css">
        .classtextblue {
            text-decoration: underline;
            color: blue;
            cursor: pointer
        }
    </style>

    <%-- Rizwan kharal --%>
    <%-- 3 oct 2017 --%>
    <%-- Created a Pop up for Add insurance --%>
    <div id="AddInsuranceDiv" class="border" style="height: 400px;">


        <div id="header" style="width: 100%; height: 34px; background-color: #439abf;" class="border">

            <div style="float: left; margin-left: 8px; margin-top: 7px">
                <label id="title" style="color: white; font-size: 19px;">
                    Add Insurance(<span>
                        <label id="patient" style="color: white; font-size: 17px;"></label>
                    </span>)
                </label>
            </div>
            <div>
                <input type="button" value="X" id="close" style="min-width: 19px !important; height: 24px !important; float: right; margin-right: 5px; margin-top: 6px" />
            </div>

        </div>



        <div id="callbackDiv"></div>

        <div id="footer" style="width: 100%; height: 34px; background-color: #439abf; margin-top: 29.7%;" class="border">

            <div style="float: left; margin-left: 39%; margin-top: 4px;">
                <%--   <asp:Button runat="server" Text="Save" ID="Inssave" OnClick="SaveInsurance();" />--%>
                <input type="button" value="Save" id="Inssave" style="" onclick="SaveInsurance(); ValidateInsurance();" />
            </div>
            <div>
                <input type="button" value="Cancel" id="Addcancel" style="margin-top: 4px; margin-left: 5px;" />
                <%-- <asp:Button runat="server" Text="Cancel" ID="Addcancel" />--%>
            </div>

        </div>

    </div>
    <%-- End AddInsuranceDiv  --%>
    <%-- Start UpdateInsuranceDiv  --%>
    <div id="UpdateInsuranceDiv" style="height: 400px;">



        <div id="Upheader" style="width: 100%; height: 34px; background-color: #439abf;">

            <div style="float: left; margin-left: 8px; margin-top: 7px">
                <label id="Uptitle" style="color: white; font-size: 19px;">
                    Update Insurance(<span>
                        <label id="Upatient" style="color: white; font-size: 17px;"></label>
                    </span>)
                </label>
            </div>
            <div>
                <input type="button" value="X" id="Uclose" style="min-width: 19px !important; height: 24px !important; float: right; margin-right: 5px; margin-top: 6px" />
            </div>

        </div>



        <div id="UcallbackDiv"></div>

        <div id="Ufooter" style="width: 100%; height: 34px; background-color: #439abf; margin-top: 12%;">

            <div style="float: left; margin-left: 39%; margin-top: 4px;">
                <input type="button" value="Update" id="InsUpdate" style="" onclick="UpdateInsuranceData(); ValidateInsurance();" />
            </div>
            <div>
                <input type="button" value="Cancel" id="Upcancel" style="margin-top: 4px; margin-left: 4px;" />
            </div>

        </div>

    </div>
    <%-- End UpdateInsuranceDiv  --%>

    <%-- Cover Div  --%>
    <div id="cover">
    </div>

    <%-- Start FinancialGuarantorSearch  --%>

    <%--Added By Syed Sajid Ali 4-23-2018--%>
    <div id="divInvoice_DLG" style="display: none;">
        <div id="chkdiv" style="float: left; padding: 2px 0 4px">
            <div>
                <%--<asp:CheckBox id="CheckBox1" runat="server" CssClass="ChkBox"/>--%>
                <input type="checkbox" id="_CkBox" name="checkbox_1" class="_ChkBox" value="RBR" checked="checked" />
                <span>Cases Billed To Patient</span>
            </div>
            <div>
                <%--<asp:CheckBox id="CheckBox2" runat="server" CssClass="ChkBox"/>--%>
                <input type="checkbox" id="_CkBox1" name="checkbox_1" class="_ChkBox" value="RBRR" />
                <span>All Cases</span>
            </div>
        </div>
    </div>
    <div id="divPopupPatientInvoice" style="display: none" class="divPopupPatientInvoice"></div>
    <div id="divInvoiceDLG"></div>
    <%--Added By Syed Sajid Ali--%>

    <div id="FinancialGuarantorSearch"></div>






    <div style="float: left; width: 100%;" id="Demographics">
        <div class="row">
            <div class="col-lg-3">
                <div class="demosidebar" style="width: 23%; position: fixed;">
                    <%-- FaceProfile --%>
                    <div style="float: left; width: 100%; line-height: 20px; background: white; border: 1px solid #d3d4d4; border-radius: 5px; /*margin-top: 91px*/">
                        <div style="width: 100%; float: left; margin-top: 5px; padding-left: 5px; height: 80px;">
                            <asp:Image runat="server" ID="imgPatientImage" Style="height: 50px; width: 50px; border-radius: 50%; float: left; margin-right: 5px;" />

                            <asp:Label Style="font-weight: bold; display: block; padding: 6px 0px 0px 10px" ID="lblPatientId" runat="server">Account# 1002311</asp:Label>
                            <asp:HiddenField runat="server" ID="hdnPatId" />
                            <div id="ProfileName">
                                <asp:Label Style="font-weight: bold;" ID="lblName" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div style="width: 100%; float: left;">
                            <%--//change added by Ali Imran 11/15/2017--%>
                            <input type="button" value="Check Eligibilty" onclick="CheckPatientEligibility('Demographics');" style="float: right; margin: 6px 5px 6px 0px; width: 115px; display: none" />
                            <div id="EligibilityResponse" style="display: none;"></div>
                            <%--//change ended by Ali Imran 11/15/2017--%>
                            <%--Added By Syed Sajid Ali--%>
                            <input type="button" value="Patient Statement" onclick="showPatInvoices()" style="float: right; margin: 6px 12px 0px 0px; display: none" />
                            <%--Added By Syed Sajid Ali 4-24-2018--%>
                        </div>
                    </div>

                    <%-- style="float: left; width: 23%; margin-right: 1%; position: fixed; margin-top: 90px" --%>
                    <div class="clear"></div>
                    <div id="slidebar">
                        <div class="top-button-demographic">
                            <div onclick="showPatInvoices()" class="divPatientStatement"><span>Patient Statement</span></div>
                        <div onclick="CheckPatientEligibility('Demographics');" class="divCheckEligibility"><span>Check Eligibility</span></div>
                        </div>
                        
                        <ul class="dashboardmenu">
                            <li id="liDemographics">
                                <a href="#divDemographics">Demographic</a>
                            </li>
                            <li id="liInsurance">
                                <a href="#divInsurances">Insurance</a>
                            </li>
                            <li id="liClaims">
                                <a href="#divPatientClaim">Claim</a>
                            </li>
                            <li id="liDocuments">
                                <a href="#PatientAllDocument">Documents</a>
                            </li>
                            <li id="liPatientPayments">
                                <a href="#divPatientPayments">Patient Payments</a>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>
            <div class="col-lg-9 pl-0">


                <div style="float: right; width: 100%;">
                    <div class="widget" id="divDemographics" style="margin-top: 2px">
                        <div class="widgettitle">
                            Demographic
                   
                     
                 <%--   <div style="float:right ; cursor:pointer "> <img src="../../Images/edit.png" id="EditPatientData"  /> </div>
                     <div style="float:right;cursor:pointer"> <input type="button" class="UpdateButtonClose" id="CancelPatientUpdate" />   </div>
                     <div style="float:right;cursor:pointer;margin-right:5px;">
                          <input type="button" class="UpdateButton" id="UpdatePatient" onclick="ValidateForm();"/>  
                         <%--<input type="button" id="updatebtn" style="display: inline-block;" class="UpdateButton" title="ADD/Update" onclick="AddEditPatient1();"/>  </div> --%>
                        </div>


                        <div class="widgetcontent" id="DemographicsUpdate" style="padding: 1%; width: 100%;">
                            <div class="row">
                                <div class="col-lg-8">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div style="">
                                                <div class="patient-widget">
                                                    <div class="patient-widget-title">
                                                        GENERAL INFORMATION                                 
                                                    </div>
                                                    <div class="patient-widget-content">
                                                        <table>
                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 55%;">First Name:<span style="margin-bottom: 1px; color: red">*</span></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblFirstName" Style="margin-left: 5px" CssClass="textDesign" ReadOnly="true"></asp:TextBox>


                                                                    <%-- <asp:TextBox runat="server" ID="txtFirstName"  CssClass="txtDesign stringonly required"></asp:TextBox>--%>
                                                                    <input type="text" runat="server" id="txtFirstName" class="txtDesign stringonly required" onblur="focusout();" />
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">Middle Name:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblMiddleName" Style="margin-left: 5px" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <asp:TextBox runat="server" ID="txtMiddleName" CssClass="txtDesign stringonly"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">Last Name:<span style="margin-bottom: 1px; color: red">*</span></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblLastName" Style="margin-left: 5px" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <%-- <asp:TextBox runat="server" ID="txtLastName" CssClass="txtDesign stringonly required"></asp:TextBox>--%>
                                                                    <input type="text" runat="server" id="txtLastName" class="txtDesign stringonly required" onblur="focusout();" />
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">Date of Birth:<span style="margin-bottom: 1px; color: red">*</span></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblDOB" Style="margin-left: 5px" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <%--  <asp:TextBox runat="server" ID="txtDOB"  CssClass="txtDesign datepicker required"></asp:TextBox>--%>
                                                                    <input type="text" runat="server" id="txtDOB" class="txtDesign datepicker required" onchange="focusout();" />
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">SSN:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblSSN" Style="margin-left: 5px" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <asp:TextBox runat="server" ID="txtSSN" CssClass="txtDesign"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">Gender:</td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblGender" CssClass="ddl" Style="margin-left: 5px;"></asp:Label>

                                                                    <asp:DropDownList ID="ddlGender" runat="server" Style="margin-left: 5px; display: none;">
                                                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">Marital Status:</td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblMaritalStatus" Style="margin-left: 5px;"></asp:Label>
                                                                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" Style="margin-left: 5px; display: none;">
                                                                        <asp:ListItem Value="Single">Single</asp:ListItem>
                                                                        <asp:ListItem Value="Married">Married</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">Race:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblRACE" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>

                                                                    <asp:DropDownList runat="server" ID="ddlRace" Style="margin-left: 5px; display: none;"></asp:DropDownList>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">Ethnicity:</td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblEthnicity" Style="margin-left: 1px;"></asp:Label>
                                                                    <asp:DropDownList runat="server" ID="ddlEthnicity" Style="margin-left: 5px; display: none;">
                                                                        <asp:ListItem Value="0">Please Select</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right;">Preferred Language:</td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblPreferredLanguage" Style="margin-left: 5px;"></asp:Label>
                                                                    <asp:DropDownList runat="server" ID="ddlPreferredLanguage" Style="margin-left: 5px; display: none;"></asp:DropDownList>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div style="position: relative;">
                                                <div class="patient-widget">
                                                    <div class="patient-widget-title">
                                                        ADDRESS INFORMATION
                                                    </div>
                                                    <div class="patient-widget-content">
                                                        <table>
                                                            <tr>

                                                                <td style="font-weight: bold; text-align: right; width: 35%;">Address:<span style="margin-bottom: 1px; color: red">*</span></td>
                                                                <td>
                                                                    <asp:Label ID="lblAddress" runat="server" Style="margin-left: 5%" CssClass="textDesign"></asp:Label>
                                                                    <%--   <asp:TextBox runat="server" ID="" style="display:none; width: 51%;margin-left: 43%" ReadOnly="false" CssClass="required"></asp:TextBox>--%>
                                                                    <input type="text" runat="server" id="txtAddress" style="display: none; width: 51%; margin-left: 43% !important;" class="txtDesign  required" onblur="focusout();" />
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">Address Type:</td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblAddressType" Style="margin-left: 5%;"></asp:Label>
                                                                    <asp:DropDownList ID="ddlAddressType" runat="server" Style="display: none; margin-left: 43%; width: 55.8%">
                                                                        <asp:ListItem Value="Residential">Residential</asp:ListItem>
                                                                        <asp:ListItem Value="Business">Business</asp:ListItem>
                                                                        <asp:ListItem Value="Mailing">Mailing</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">City:<span style="margin-bottom: 1px; color: red">*</span></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblCity" Style="margin-left: 5%" CssClass="textDesign" ReadOnly="true"></asp:TextBox>

                                                                    <input id="txtCity" maxlength="25" class="required" runat="server" type="text" onkeyup="getZipCityState(this,'txtZipCode','txtCity','ddlState');"
                                                                        style="display: none; width: 51% !important; margin-left: 43% !important;" onblur="focusout();" />

                                                                    <div class="inline-search-wrapper" style="top: 35px; width: 230px;">
                                                                        <div class="divZipCityResult" style="width: 14%; position: absolute; margin-left: 9%; z-index: 10; max-height: 152px; overflow-x: hidden; overflow-y: scroll">
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">State:</td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblState" Style="margin-left: 5%;"></asp:Label>
                                                                    <asp:DropDownList ID="ddlState" runat="server" Enabled="False" Style="display: none; margin-left: 43%; width: 55.8%">
                                                                    </asp:DropDownList>

                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">Zip Code:<span style="margin-bottom: 1px; color: red">*</span></td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblZipCode" Style="margin-left: 5%;" CssClass="textDesign" ReadOnly="true"> </asp:TextBox>

                                                                    <input id="txtZipCode" onkeyup="getZipCityState(this,'txtZipCode','txtCity','ddlState');"
                                                                        onblur="focusout();" class="required zip txtDesign" runat="server" type="text" style="width: 51% !important; margin-left: 43% !important; position: relative;" />
                                                                    <div class="inline-search-wrapper" style="top: 595px; width: 230px;">
                                                                        <div class="divZipCityResult" style="width: 13%; position: absolute; margin-left: 9%; z-index: 10; max-height: 152px; overflow-x: hidden; overflow-y: scroll">
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">Home Phone:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblHomePhone" Style="margin-left: 5%;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <asp:TextBox runat="server" ID="txtHomePhone" CssClass="txtDesign phone" Style="width: 51% !important; margin-left: 43% !important"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">Cell Phone:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblCellPhone" Style="margin-left: 5%;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <asp:TextBox runat="server" ID="txtCellPhone" CssClass="txtDesign phone" Style="width: 51% !important; margin-left: 43% !important"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">Work Phone:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblWorkPhone" Style="margin-left: 5%;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <asp:TextBox runat="server" ID="txtWorkPhone" CssClass="txtDesign phone" Style="width: 50% !important; margin-left: 43% !important"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">Ext:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblExt" Style="margin-left: 5%;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <asp:TextBox runat="server" ID="txtExt" CssClass="txtDesign" Style="width: 50% !important; margin-left: 43% !important;" MaxLength="5"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">Email:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="lblEmail" Style="margin-left: 5%;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="txtDesign Email" Style="width: 50% !important; margin-left: 43% !important;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-weight: bold; text-align: right; width: 35%;">CCP:</td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblCCP" Style="margin-left: 7%;"></asp:Label>
                                                                    <asp:DropDownList ID="ddlCCP" runat="server" Style="margin-left: 5%; width: 56%; display: none;">
                                                                        <asp:ListItem Value=""></asp:ListItem>
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
                                        </div>
                                        <div class="col-lg-12">
                                            <div style="" id="notes">
                                                <div class="patient-widget">
                                                    <div class="patient-widget-title">
                                                        Notes
                                                    </div>
                                                    <div class="patient-widget-content">
                                                        <textarea runat="server" id="txtNotes" disabled="disabled" style="height: 61px; width: 99%;"></textarea>
                                                        <textarea runat="server" id="txtNotes2" style="height: 61px; width: 99%; display: none"></textarea>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>




                                </div>
                                <div class="col-lg-4">
                                    <div style="">
                                        <div class="patient-widget">
                                            <div class="patient-widget-title">
                                                <div style="">FINANCIAL GUARANTOR</div>
                                                <div style="">
                                                    <input type="button" id="searchGUARANTOR" style="display: none" onclick="FinancialGuarantorSearch();" />
                                                </div>
                                            </div>

                                            <div class="patient-widget-content">
                                                <table>

                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right;">Relationship:</td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblRelationship" Style="margin-left: 2px;"></asp:Label>

                                                            <asp:DropDownList ID="ddlRelationship" AppendDataBoundItems="true" runat="server" Style="margin-left: 5px; display: none;" onchange="FGRelationshipddl();">
                                                                <asp:ListItem Value="0">Self</asp:ListItem>

                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>


                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right; width: 45%;">First Name:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="lblFirstGuarantorName" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                            <asp:TextBox runat="server" ID="txtFirstGuarantorName" Style="background-color: #dbdbdb" CssClass="txtDesign stringonly" Enabled="false"></asp:TextBox>


                                                        </td>
                                                    </tr>
                                                    <tr style="display: none">
                                                        <td style="font-weight: bold; text-align: right; width: 45%;">Middle Name</td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="lblMiddleGuarantorName" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                            <asp:TextBox runat="server" ID="txtMiddleGuarantorName" Style="background-color: #dbdbdb" CssClass="txtDesign stringonly"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right; width: 45%;">Last Name:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="lblLastGuarantorName" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                            <asp:TextBox runat="server" ID="txtLastGuarantorName" Style="background-color: #dbdbdb" CssClass="txtDesign stringonly" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>


                                                </table>
                                            </div>
                                        </div>

                                        <div class="patient-widget">
                                            <div class="patient-widget-title">
                                                EMERGENCY CONTACT
                                            </div>
                                            <div class="patient-widget-content">
                                                <table>
                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right; width: 45%;">Name:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="lblEmergencyName" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                            <asp:TextBox runat="server" ID="txtEmergencyName" CssClass="txtDesign stringonly"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right;">Realtionship:</td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblEmergencyRelationship" Style="margin-left: 5px;"></asp:Label>
                                                            <asp:DropDownList ID="ddlEmergencyRelationship" AppendDataBoundItems="true" runat="server" Style="margin-left: 5px; display: none;">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right;">Contact:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="lblEmergencyContact" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>

                                                            <asp:TextBox runat="server" ID="txtEmergencyContact" CssClass="txtDesign phone"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>

                                        <div class="patient-widget">
                                            <div class="patient-widget-title">
                                                DISABILITY/DEATH
                                            </div>
                                            <div class="patient-widget-content">
                                                <table>
                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right; width: 45%;">Date of Disability:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="lblDateOfDisability" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                            <asp:TextBox runat="server" ID="txtDateOfDisability" CssClass="txtDesign datepicker"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right;">Date of Death:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="lblDateOfDeath" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                            <asp:TextBox runat="server" ID="txtDateOfDeath" CssClass="txtDesign datepicker"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="font-weight: bold; text-align: right;">Cause of Death:</td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="lblCauseOfDeath" Style="margin-left: 5px;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                            <asp:TextBox runat="server" ID="txtCauseOfDeath" CssClass="txtDesign stringonly"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>

                                        <div class="patient-widget">
                                            <div class="patient-widget-title">
                                                Pharmacy
                                            </div>
                                            <div class="patient-widget-content">
                                                <table>
                                                    <tr>
                                                        <td style="font-weight: bold;">Pharmacy Name: </td>
                                                        <%--edited by shahid kazmi 2/9/2018--%>
                                                        <td>
                                                            <div style="float: left;">
                                                                <asp:TextBox runat="server" ID="lblPharmacyName" Style="margin-left: 57%;" CssClass="textDesign" ReadOnly="true"></asp:TextBox>
                                                                <asp:TextBox runat="server" ID="txtPharmacyName" CssClass="txtDesign" Style="width: 56% !important; margin-left: 55% !important;" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="float: left; margin-left: 30px">
                                                                <span class="spnAdd" style="display: none; cursor: pointer;" onclick="GetSearchBox();"></span>&nbsp;<span class="spnRemove" style="display: none; cursor: pointer;" onclick="RemovePharmacy();"></span>
                                                            </div>
                                                        </td>

                                                        <%--end shahid kazmi 2/9/3018--%>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>











                        </div>




                    </div>

                    <div class="widget" id="divInsurances">

                        <div class="widgettitle">

                            <%-- Rizwan  --%>
                    Insurance Information     
                     
                  
                     <div style="float: right">
                         <%--<input type="button"   class="UpdateButton" onclick="InsurancePopUp();"  id="InsurancePopUpBtn" style="margin-right:2px"/>--%>   <%--id=""--%>

                         <%--  <a href="#AddInsuranceDiv" class="popup">Click</a>--%>
                     </div>


                        </div>


                        <div class="widgetcontent">
                            <div id="InsuranceInformation"></div>
                            <div id="refresh" style="padding: 7px 7px 7px 7px;">
                                <div class="Grid">
                                    <table class="data-table" id="TblInsurance">
                                        <thead>
                                            <tr>

                                                <th>Payer Type
                                                </th>
                                                <th>Payer Name
                                                </th>
                                                <th>Policy No
                                                </th>
                                                <th>Group No
                                                </th>
                                                <th>Group Name
                                                </th>
                                                <th>Copay
                                                </th>
                                                <th>Co-Insurance
                                                </th>
                                                <th>Relationship
                                                </th>
                                                <th>Subscriber Name
                                                </th>
                                                <th>Effective Date
                                                </th>
                                                <th>Termination Date
                                                </th>
                                                <%-- <th >
                                    Edit
                                </th>--%>
                                            </tr>
                                        </thead>
                                        <tbody id="InsuranceTable">

                                            <asp:Repeater ID="RptInsurance" runat="server" OnItemDataBound="RptInsurance_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="display: none">

                                                            <%# Eval("PatientInsuranceId") %>
                                                        </td>
                                                        <td style="display: none">

                                                            <%# Eval("PriSecOthType") %>
                                                        </td>
                                                        <td>
                                                            <%--<%# Eval("InsuranceType") %>--%>
                                                            <asp:Label ID="lblInsuranceType" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Name") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("PolicyNumber") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("GroupName") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("GroupNumber") %>

                                                        </td>

                                                        <td>
                                                            <%# Eval("CoPay") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("CoInsurance") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Relationship")%>
                                                        </td>

                                                        <td>
                                                            <%-- <%# Eval("SubscriberName") %>--%>
                                                            <asp:Label ID="lblSubscriberName" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%# Eval("EffectiveDate","{0:d}") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("TerminationDate","{0:d}")%>
                                                        </td>
                                                        <%--  <td onclick="InsuranceUpdatePopUp('<%# Eval("PatientInsuranceId") %>','<%# Eval("FirstName") %>','<%# Eval("LastName") %>');">
                              <input type="button" id="InsEdit" class="Edit"/> 
                            </td>--%>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>

                                </div>
                            </div>
                        </div>
                        <div>
                            <asp:Label ID="InsuranceInfoLabel" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="widget" id="divPatientClaim">
                        <div class="widgettitle">
                            Claims

                    
                        </div>
                        <div class="widgetcontent" style="padding: 7px 7px 7px 7px;">
                            <div class="Grid" id="divClaims" style="width: 100%; margin: 0px; box-sizing: border-box;">
                                <table style="width: 100%;">
                                    <thead>



                                        <tr>
                                            <th style="width: 2%;">#
                                            </th>
                                            <th style="width: 8%;">Claim No
                                            </th>
                                            <th>DOS</th>
                                            <th>Total Charges</th>
                                            <th>Amount Paid</th>
                                            <%--<th>Patient Paid</th>--%>
                                            <th>Adjusted</th>
                                            <th>Balance Due</th>
                                            <th>Primary Insurance</th>
                                            <th>Submission Status</th>
                                            <th style="width: 20%;">PTL Reason</th>
                                            <th>Claim View</th>
                                        </tr>


                                        <tr>
                                            <th>
                                                <span class="iconSearch"></span>
                                            </th>
                                            <th>
                                                <input type="text" id="txtClaimNo" onkeyup="RowsChange('FilterClaims');" />
                                            </th>
                                            <th>
                                                <input type="text" id="txtDateOfService" class="ServiceDate" onkeyup="RowsChange('FilterClaims');" />
                                            </th>
                                            <th>
                                                <input type="text" id="txtTotalCharges" class="TotalCharges" onkeyup="RowsChange('FilterClaims');" />
                                            </th>
                                            <th>
                                                <input type="text" id="txtAmountPaid" class="AmountPaid" onkeyup="RowsChange('FilterClaims');" />
                                            </th>
                                            <%-- <th>
                                        <input type="text" id="txtPatientPaid" class="PatientPaid" onkeyup="RowsChange('FilterClaims');" />
                                    </th>--%>
                                            <th>
                                                <input type="text" id="txtAdjusted" class="Adjusted" onkeyup="RowsChange('FilterClaims');" />
                                            </th>
                                            <th>
                                                <input type="text" id="txtBalanceDue" class="BalanceDue" onkeyup="RowsChange('FilterClaims');" />
                                            </th>
                                            <th>
                                                <%-- <asp:DropDownList ID="ddlInsurance" runat="server" CssClass="select" Style="float: none;" onchange="RowsChange('FilterClaims');"></asp:DropDownList>--%>
                                                <asp:DropDownList ID="ddlInsurancesNames" runat="server" CssClass="select" Style="float: none;" onchange="RowsChange('FilterClaims');"></asp:DropDownList>

                                            </th>
                                            <th>
                                                <asp:DropDownList ID="ddlSubmissionStatus" runat="server" CssClass="select" Style="float: none;" onchange="RowsChange('FilterClaims');"></asp:DropDownList>


                                            </th>
                                            <th>
                                                <%--<asp:DropDownList ID="ddlPtlReasons" runat="server" CssClass="select" Style="float: none;" onchange="RowsChange('FilterClaims');">   </asp:DropDownList>--%>

                                                <div class="dropdownMenuMultiCheckMainWrapper">
                                                    <select></select>
                                                    <div class="div-dropdown-label-wrapper" onclick="HideShowPTLReasonDropDown(this);">
                                                        <span class="custom-drop-down-label"></span>
                                                    </div>
                                                    <div class="dropdownMenuMultiCheck" style="top: 25px; width: 228px;">
                                                        <div class="div-drop-down" style="height: 150px;">
                                                            <ul id="ulPTLReasonFilterListClaim" style="text-align: left; overflow-x: hidden;">
                                                                <li>
                                                                    <label>
                                                                        <input type="checkbox" class="chkPTLReasonsAll" onclick="SelectUnselectPTLReasons_All(this);" />
                                                                        All
                                                                    </label>
                                                                </li>
                                                                <asp:Repeater runat="server" ID="rptPTLReasons">
                                                                    <ItemTemplate>
                                                                        <li>
                                                                            <label>
                                                                                <input type="checkbox" id='chkClaimsListPTLReasonsId<%#Eval("PTLReasonsId") %>' class="chkReason" onclick="SelectUnselectPTLReasons(this);" />
                                                                                <span class="spnReason"><%#Eval("Reason")%></span>

                                                                                <input type="hidden" class="hdnPTLReasonsId" value='<%#Eval("PTLReasonsId") %>' />
                                                                            </label>
                                                                        </li>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </ul>
                                                        </div>
                                                        <div class="divBottom">
                                                            <input type="button" onclick="OkMultiCheckDropDownPTLReason(this, 'Claim');" value="OK" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </th>
                                            <th>
                                                <input type="checkbox" id="chkPTL" onclick="RowsChange('FilterClaims');" style="display: none;" />
                                            </th>
                                        </tr>
                                    </thead>

                                    <tbody id="ClaimsList">
                                        <asp:Repeater ID="rptClaims" runat="server" OnItemDataBound="rptClaims_ItemDataBound">
                                            <ItemTemplate>
                                                <%-- rizwan kharal start --%>
                                                <%-- 21 sep 2017 --%>
                                                <%-- Showing the record from claim table of patient --%>
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
                                                        <%# Eval("ClaimTotal","{0:c}") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("AmountPaid","{0:c}") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Adjustment","{0:c}") %>

                                                    </td>

                                                    <td>
                                                        <%# Eval("AmountDue","{0:c}") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("SubmissionStatus")%>
                                                    </td>

                                                    <td class="tdPTLReasons">
                                                        <span><%# Eval("PTLReasons") %></span>
                                                        <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />
                                                    </td>

                                                    <td style="text-align: center;">
                                                        <a title="View" onclick="ClaimOpenForView(<%# Eval("ClaimId")%>,<%# Eval("PatientId")%>,'<%# Eval("SubmissionStatus")%>')">
                                                            <img src="../../Images/view1.png" />
                                                        </a>
                                                        <asp:CheckBox runat="server" ID="chkPTL" Enabled="false" Style="display: none;" />
                                                    </td>
                                                </tr>

                                                <%-- rizwan end --%>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>

                                <asp:Label ID="ClaimLabel" runat="server"></asp:Label>
                                <div class="table-footer">
                                    <div class="message">
                                        <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                                    </div>
                                    <div class="pager" style="box-sizing: border-box;">
                                        <div class="PageEntries">
                                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                                <select id="ddlPagingClaims" style="margin-top: 5px;" onchange="RowsChange('FilterClaims');">
                                                    <option value="5">5</option>
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
                                </div>
                                <asp:HiddenField ID="hdnClaimsCount" runat="server" />
                            </div>
                        </div>


                    </div>

                    <div class="widget contentWrapper" id="PatientAllDocument">
                        <div class="widgettitle" id="" style="margin-bottom: 10px;">
                            <span style="color: white">Documents</span>
                        </div>
                        <div class="box-content" style="background: #fff;">
                            <div class="patient-main-divs" id="divDocumentsMain">
                            </div>
                        </div>
                    </div>

                    <div class="widget " id="divPatientPayments">
                        <div class="widgettitle">Patient Payments</div>
                        <div class="widgetcontent" style="padding: 7px 7px 7px 7px;">
                            <div class="PatientPayments-bar">
                                <span>Total Patient Responsibility:</span><span class="spntpr" style="font-weight: bold">
                                    <asp:Label runat="server" ID="lblpr" />
                                </span>
                                <span style="margin-left: 25%">Total Patient Paid:</span>
                                <span style="font-weight: bold" class="spntpaid">
                                    <asp:Label runat="server" ID="lblpaid" />
                                </span>
                                <span class="BalanceSheet-btn" style="float: right; cursor: pointer" onclick="ViewPaymentDetails()">Balance Sheet</span>
                                <span class="spnbalance" onclick="OpenBalanceReport()" style="float: right; font-weight: bold; margin-right: 30px;">
                                    <asp:Label runat="server" ID="lblBalanceDue" />
                                </span>
                                <span style="float: right;">Remaining Balance:</span>
                                <span style="font-weight: bold" class="spntpaid">
                                    <asp:Label runat="server" ID="Label1" />
                                </span>

                                
                                <span style="font-weight: bold" class="spntpaid">
                                    <asp:Label runat="server" ID="Label2" />
                                </span>
                                
                            </div>
                            <div class="Grid">
                                <table class="tblpatientpayments">

                                    <thead>
                                        <tr>

                                            <th>Payment Date</th>
                                            <th>Check No.</th>
                                            <th>Check Amount</th>
                                            <th>Applied Amount</th>
                                            <th>Un-Applied Amount</th>
                                        </tr>
                                    </thead>
                                    <tbody class="trpatientpayments">
                                        <asp:Repeater runat="server" ID="rptPatientPayment">
                                            <ItemTemplate>
                                                <tr onclick="getCheckDetail(this);" style="cursor: pointer; text-align: right">
                                                    <td style="text-align: center !important"><%# Eval("checkdate")%></td>
                                                    <td style="text-align: center !important" class="tdchecknumber"><%# Eval("checknumber")%></td>
                                                    <td>$<%# Eval("checkAmount")%></td>
                                                    <td>$<%# Eval("PaymentPosted")%></td>
                                                    <td>$<%# Eval("UnAppliedAmount")%></td>
                                                   </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>

                                </table>
                            </div>
                        </div>


                    </div>
                    <div id="dialogueBody" class="printable" style="display: none;">
                       <%-- <div class="bSheet-header">
                            <div class="row">

                                <div class="col-lg-3">
                                    <h2>Patient Payment</h2>
                                </div>
                                <div class="col-lg-3">Patient Date: <span></span></div>
                                <div class="col-lg-3">Check#: <span></span></div>
                                <div class="col-lg-2">Check Amount: <span></span></div>
                                <div class="col-lg-1">
                                    <button type="button" class="ui-dialog-titlebar-close"></button>
                                </div>
                            </div>


                        </div>--%>
                        <div class="BalanceSheet">
                             <%--<div class="row">--%>
                                 
                                 <div class="row">
                           
                                         
                                     <div class="col-lg-3 bsheet-left">
                                         <div class="patient-info">
                                             <p><b>Account #:</b>
                                             <label id="AccountNo"></label></p>
                                             <p><b>Name:</b>  
                                             <label id="FullName"></label></p> 
                                         </div>

                                         <div class="payment-history">
                                             <asp:Repeater runat="server" ID="RptBalanceSheet_Trn" OnItemDataBound="RptBalanceSheet_Trn_ItemDataBound">
                                                 <ItemTemplate>
                                                     <ul>
                                                         <li><b>Payment Date: <span>
                                                             <asp:Label runat="server" ID="checkDate" Text='<%# Eval("checkdate")%>'></asp:Label></span></b></li>
                                                         <li><b>Check Number:</b><asp:Label runat="server" ID="CheckNumber" Text='<%# Eval("checknumber")%>'></asp:Label></li>
                                                         <li><b>Check Amount:</b>$<%# Eval("checkAmount")%></li>
                                                         <asp:HiddenField runat="server" ID="hdnCheckAmount" Value='<%# Eval("checkAmount")%>' />
                                                     </ul>
                                                 </ItemTemplate>
                                             </asp:Repeater>
                                         </div>

                                         <div class="balance-info">
                                             <ul>
                                                 <li>Patient Resp: 
                                                     <label id="dialogue_PR"></label>
                                                 </li>
                                                 <li>Paid: 
                                                     <label id="dialogue_Paid"></label>
                                                 </li>
                                                 <li>Balance Amount: <label id="dialogue_BalanceAmount"> </label>
                                                 </li>
                                             </ul>
                                         </div>
                                     </div>
                                       
                                     
                                 
                                   
                                <div class="col-lg-9 bsheet-right" id="lvl2Grid" >
                                    
                                    
                                    </div>
                                  


                                
                           


                        <%--     </div>--%>







                        </div>
                        </div>
                    </div>

                    <asp:HiddenField ID="Pid" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnPracticeId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="CurrentDate" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="Insuranceid" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnFinancialGuranterId" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnNCPDP" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnCheckNos" runat="server" />
                    <div id="PharmacySearch" style="display: none;"></div>


                    <div id="PopUpPatientInsuranceDetail" style="display: none;"></div>
                    <div id="OpenClaimForm" style="display: none;"></div>
                </div>

            </div>
        </div>
        <div class="printableView" style="display:none;"></div>
        <script type="text/javascript">
            var _html = "";
            var _Counter = 0;
            //Added by Khayyam Adeel dated 12/20/2021
            function ViewPaymentDetails() {
                debugger
                //var a = $("[id$=ContentPlaceHolder1_lblBalanceDue]").html();
                //var b = $("[id$=ContentPlaceHolder1_lblpaid]").html();
                //var c = $("[id$=ContentPlaceHolder1_lblpr]").html();
                //var e = $("[id$=ContentPlaceHolder1_lblName]").html();
                var patid = $("[id$=ContentPlaceHolder1_hdnPatId]").val();
                $(".balance-info").find("#dialogue_BalanceAmount").html($("[id$=ContentPlaceHolder1_lblBalanceDue]").html());
                $(".balance-info").find("#dialogue_Paid").html($("[id$=ContentPlaceHolder1_lblpaid]").html());
                $(".balance-info").find("#dialogue_PR").html($("[id$=ContentPlaceHolder1_lblpr]").html());
                $(".patient-info").find("#AccountNo").html($("[id$=ContentPlaceHolder1_hdnPatientId]").val()); 
                $(".patient-info").find("#FullName").html($("[id$=ContentPlaceHolder1_lblName]").html());
                var a=""
                $(".tdchecknumber").each(function () {
                    a += $(this).html()+",";
                });
                //a = "1001,1002,1003,1004";
                var oldArray = a.split(',');
                var arr = oldArray.filter(function (v) { return v !== '' });
                
                $.each(arr, function (i, val) {
                    $.post("../Patient/callbacks/DemographicsEditandViewHandler.aspx", { action: "getLevel2Detail", PatientId: patid, Checknumber: val }, function (data) {
                        debugger
                        var start = data.indexOf("###StartPatientPaymentDeatils_Dialogue###") + 41;
                        var end = data.indexOf("###EndPatientPaymentDeatils_Dialogue###");
                        var result = data.substring(start, end);

                        _html += result;
                       
                    }).done(function () {
                        _Counter++;
                        if (_Counter == arr.length) {
                            debugger;
                            loadDialog();
                        }
                    });
                    
                });
                //Asyc logic
                
                
            }
            /**********added by shahid kazmi 02/06/2018 for bug 7200*************/

            function loadDialog() {
                debugger
                var a = $("#lvl2Grid").html();
                $("#lvl2Grid").html("");
                $("#lvl2Grid").html(_html);

                $("#dialogueBody").dialog({
                    resizable: false,
                    dialogClass: 'BlanceSheet-ui-widget',
                    title: 'Balance Sheet',
                    width: '1200',
                    modal: true,
                    buttons: {
                        "OK": function () {
                            $(this).dialog("close");
                            _Counter = 0;
                            _html = "";
                        },
                        "Print": function () {
                            debugger
                            $(".printableView").html($("#dialogueBody").html());
                            $(".printableView .bsheet-left").remove();
                            //$("#dialogueBody").css('display', '');
                            //$("#dialogueBody").printThis({
                            //    debug: true,               // show the iframe for debugging
                            //    importCSS: true,            // import parent page css
                            //    importStyle: true,         // import style tags
                            //    printContainer: true,       // print outer container/$.selector
                            //    loadCSS:"../../StyleSheets/BillingManagerTheme.css",                // path to additional css file - use an array [] for multiple
                            //    pageTitle: "",              // add title to print page
                            //    removeInline: false,        // remove inline styles from print elements
                            //    removeInlineSelector: "*",  // custom selectors to filter inline styles. removeInline must be true
                            //    printDelay: 10,            // variable print delay
                            //    header: null,               // prefix to html
                            //    footer: null,               // postfix to html
                            //    base: false,                // preserve the BASE tag or accept a string for the URL
                            //    formValues: true,           // preserve input/form values
                            //    canvas: false,              // copy canvas content
                            //    doctypeString: '...',       // enter a different doctype for older markup
                            //    removeScripts: false,       // remove script tags from print content
                            //    copyTagClasses: false,      // copy classes from the html & body tag
                            //    beforePrintEvent: null,     // function for printEvent in iframe
                            //    beforePrint: null,          // function called before iframe is filled
                            //    afterPrint: null            // function called before iframe is removed
                            //});
                            var contents = $(".printableView").html();
                            var frame1 = $('<iframe />');
                            frame1[0].name = "frame1";
                            frame1.css({ "position": "absolute", "top": "-1000000px" });
                            $("body").append(frame1);
                            var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
                            frameDoc.document.open();
                            //Create a new HTML document.
                            frameDoc.document.write('<html><head><title>Balance Sheet</title>');
                            frameDoc.document.write('</head><body>');
                            //Append the external CSS file.
                            frameDoc.document.write('<link href="../../StyleSheets/BillingManagerTheme.css" rel="stylesheet" type="text/css" />');
                            //Append the DIV contents.
                            frameDoc.document.write(contents);
                            frameDoc.document.write('</body></html>');
                            frameDoc.document.close();
                            setTimeout(function () {
                                window.frames["frame1"].focus();
                                window.frames["frame1"].print();
                                frame1.remove();
                            }, 500);
                            
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                            _Counter = 0;
                            _html = "";
                        }
                        
                    }
                });
                _Counter = 0;

            }
            function printBalanceSheet() {
                window.print();
            }
            function LoadDocuments() {
                debugger;
                var PatientId = $("[id$=hdnPatientId]").val();
                $.post(_EMRPath + "/PatientDocument/PatientDocument.aspx", { PatientId: _PatientId }, function (data) {
                    var start = data.indexOf("###StartDocument###") + 19;
                    var end = data.indexOf("###EndDocument###");
                    var returnHtml = $.trim(data.substring(start, end));

                    $("[id$='divDocumentsMain']")
                        .html(returnHtml)
                        .promise()
                        .done(function () {
                            $("[id$='divDocumentsMain']").show();
                        });
                });
            }

            function DeleteMultipleDocuments() {
                debugger;
                var allDocumentsCheckedCheckBoxes = $("#PatientDocumentsList input[class='CheckUncheckDoc']:checked").length;

                if (allDocumentsCheckedCheckBoxes == 0) {
                    showErrorMessage("Please select some documents to delete!");
                    return false;
                }

                $("#divMainDialogWrapper").attr("title", "Notification");

                ShowConfirmation("Do you realy want to delete the document(s)?").done(function () {
                    var listDocumentId = new Array();
                    var documentId;
                    var postURL = "";
                    var ClickFrom = ($("#txtPatientNameDoc").length == 0 ? "PatientDocument" : "SettingDocument");

                    $("#PatientDocumentsList input[class='CheckUncheckDoc']:checked").each(function () {
                        documentId = $(this).parent().find(".DocumentId").val();
                        listDocumentId.push(documentId);
                    });

                    if (ClickFrom = "PatientDocument") {
                        postURL = "../PatientDocument/CallBacks/AddEditPatientDocumentHandler.aspx";
                    }
                    else {
                        postURL = "CallBacks/AddEditDocumentHandler.aspx";
                    }

                    $.post(postURL, {
                        PatientId: $("[id$='hdnPatientId']").val(),
                        Edit: false,
                        Delete: true,
                        ClickFrom: ClickFrom,
                        listDocumentId: JSON.stringify(listDocumentId)
                    }, function (data) {
                        showSuccessMessage("Success: Document(s) deleted.");
                        var returnHtml = data;
                        var start = data.indexOf("###Start###") + 11;
                        var end = data.indexOf("###End###");
                        $("#PatientDocumentsList").html(returnHtml.substring(start, end));
                        var startRowsCount = data.indexOf("###StartPatientDocumentRowsCount###") + 35;
                        var endRowsCount = data.indexOf("###EndPatientDocumentRowsCount###");
                        $("[id$='hdnTotalDocRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
                        GeneratePaging($("[id$='hdnTotalDocRows']").val(), $("#ddlPagingPatientDocument").val(), "divPatientDocumentContainer", "FilterPatientDocuments");

                        if ($("[id$='hdnTotalDocRows']").val() > 0)
                            $("#divPatientDocumentContainer .spanInfo").html("Showing " + $("#PatientDocumentsList tr:first").children().first().html() + " to " + $("#PatientDocumentsList tr:last").children().first().html() + " of " + $("[id$='hdnTotalDocRows']").val() + " entries");

                        $("#divMainDialogWrapper").attr("title", "");
                    });
                });
            }
            function UploadPatientDocument() {
                debugger;
                ActionDocument = "Upload";
                OpenDocumentForm(0);
                $("[id$='hdnPatientIdDoc']").val(0);
            }
            function ScanPatientDocument(CallFrom) {
                debugger;
                ActionDocument = "Scan";
                OpenDocumentForm(0);
                $("[id$='hdnPatientIdDoc']").val(0);
            }
            function OpenDocumentForm(DocumentId) {
                debugger;
                $.post(_EMRPath + "/PatientDocument/CallBacks/PatientDocumentForm.aspx", { DocumentId: DocumentId }, function (data) {
                    var start = data.indexOf("###Start###") + 11;
                    var end = data.indexOf("###End###");

                    var returnHtml = $.trim(data.substring(start, end));

                    $("#divDialogDocumentForm").html(returnHtml)
                        .promise()
                        .done(function () {
                            PatientDocumentFormReady();
                            PatientDocumentFormReadyCommon();

                            if (DocumentId != 0) {
                                $("[id$='txtPatientNameDoc']").val(_DocumentPatientName);
                            }

                            $("#divDialogDocumentForm").dialog({
                                resizable: false,
                                title: 'Add Document',
                                width: 800,
                                //height: (window.innerHeight - 10),
                                modal: true,
                                buttons: {
                                    "Save": function () {
                                        SavePatientDocument();
                                    },
                                    "Cancel": function () {
                                        $(this).dialog("close");
                                    }
                                },
                                beforeClose: function () {
                                    ResetDivEditFields();
                                },
                                close: function () {
                                    showDocuments();
                                    $(this).dialog("destroy");
                                }
                            });
                        });
                });
            }
            function PatientDocumentFormReadyCommon() {
                if (ActionDocument == "Upload") {
                    $(".scan-link").hide();
                    $("[id$='linkUploadFiles']").show();
                }
                else if (ActionDocument == "Scan") {
                    $("[id$='linkUploadFiles']").hide();
                    $(".scan-link").show();
                    onPageLoad();
                }

                $(".Date").datepicker({
                    changeMonth: true,
                    changeYear: true
                }).mask("99/99/9999");

                new AjaxUpload('#linkUploadFiles', {
                    action: _PatientDocumentPath + '/PatientDocumentHandler.ashx',
                    dataType: 'json',
                    contentType: "application/json; charset=uft-8",
                    data: {
                        PatientId: (($("[id$='hdnPatientId']").val() == undefined) ? $("#hdnPatientIdDoc").val() : $("[id$='hdnPatientId']").val())
                    },
                    onSubmit: function (file, ext, fileSize) {
                        if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                            callDialog("Sorry! the file is invalid.", "Invalid File");
                            return false;
                        }

                        if (fileSize > 25) {
                            callDialog("This file exceeds the 5MB attachment limit.", "Attachment Limit");
                            return false;
                        }
                    },
                    onComplete: function (file, response) {
                        var responseHTML = $.parseJSON($(response).html());

                        AppendUploadedFile(responseHTML.fileName, responseHTML.path, file);
                    }
                });
            }
            function PatientDocumentFormReady() {
                $("[id$='trPatientDocumentPatientInfo']").show();
            }
            function DeletePatientDocument(elem) {
                debugger;
                var message = "Are you sure to delete the record?";

                $("[id$='divMainDialogWrapper']").html(message);

                $("[id$='divMainDialogWrapper']").dialog({
                    title: "Confirmation",
                    modal: true,
                    buttons: {
                        "Yes": function () {
                            ConfirmDeletePatientDocument(elem);
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    },
                    close: function () {
                        $(this).dialog("destroy");
                    }
                });
            }

            function ConfirmDeletePatientDocument(elem) {
                var DocumentId = $(elem).closest("tr").find(".hdnDocumentId").val();

                var params = {
                    DocumentId: DocumentId,
                    PatientId: 0,
                    action: "Delete"
                };

                $.post(_SettingsPath + "/Callbacks/DocumentsActionHandler.aspx", params, function (data) {
                    var start = data.indexOf("###Start###") + 11;
                    var end = data.indexOf("###End###");
                    var returnHtml = $.trim(data.substring(start, end));

                    $("#PatientDocumentsList").html(returnHtml);

                    start = data.indexOf("###StartPatientDocumentRowsCount###") + 35;
                    end = data.indexOf("###EndPatientDocumentRowsCount###");
                    returnHtml = $.trim(data.substring(start, end));

                    $("[id$='hdnTotalDocRows']").val(returnHtml);

                    GeneratePaging($("[id$='hdnTotalDocRows']").val(), $("#ddlPagingPatientDocument").val(), "divPatientDocumentContainer", "FilterPatientDocuments");

                    if ($("[id$='hdnTotalDocRows']").val() > 0) {
                        $("#divPatientDocumentContainer .spanInfo").html("Showing " + $("#PatientDocumentsList tr:first").children().first().html() + " to " + $("#PatientDocumentsList tr:last").children().first().html() + " of " + $("[id$='hdnTotalDocRows']").val() + " entries");
                    }

                    $("[id$='divMainDialogWrapper']").dialog("close");

                    showSuccessMessage(_msg_Deleted);

                    $(".CheckUncheckDoc").on("change", function () {
                        if ($(".CheckUncheckDoc:checked").length == $(".CheckUncheckDoc").length) {
                            $("#cbDocumentsAll").prop("checked", true);
                        }
                        else {
                            $("#cbDocumentsAll").prop("checked", false);
                        }
                    });
                });
            }
            //$("#liDocuments").click(function (e) {
            //    debugger;
            //    e.preventDefault();
            //    $(".container").animate({ scrollTop: ($("#PatientAllDocument").offset().top - $("header").height()) - 210 }, 500);

            //});
            //$("#liClaims").click(function (e) {
            //    debugger;
            //    $(".container").animate({ scrollTop: ($("#divPatientClaim").offset().top - $("header").height()) - 80 }, 600);
            //    e.preventDefault();
            //});

            //$("#liInsurance").click(function (e) {
            //    debugger;
            //    $(".container").animate({ scrollTop: ($("#divInsurances").offset().top - $("header").height()) - 80 }, 600);
            //    e.preventDefault();
            //});

            //$("#liDemographics").click(function (e) {
            //    debugger;
            //    $(".container").animate({ scrollTop: ($("#divDemographics").offset().top - $("header").height()) - 80 }, 600);
            //    e.preventDefault();
            //});
            //$("#liPatientPayments").click(function (e) {
            //    debugger;
            //    $(".container").animate({ scrollTop: ($("#divPatientPayments").offset().top - $("header").height()) - 10 }, 1);
            //    e.preventDefault();
            //});

            /**********end shahid kazmi 02/06/2018************/
            $(document).ready(function () {
                debugger
                LoadDocuments();
                var _PatientId = $("[id$=hdnPatientId]").val();


                //Hidding the Demographics page Update button
                $("[id$=UpdatePatient]").hide();

                $("[id$=CancelPatientUpdate]").hide();

                debugger


                var DateOfService = new Date();
                DateOfService.setYear(DateOfService.getFullYear() + 1);
                $("[id$='txtDateOfService']").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    maxDate: new Date(),
                    yearRange: "-110:+0",
                    onSelect: function (date, obj) {
                        FilterClaims(0, true);
                    }
                }).mask("99/99/9999");

                GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");
                if ($("[id$='hdnClaimsCount']").val() > 0)
                    $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");







                // Rizwan kharal 
                // 27 Sep 2017
                //hiding and showing update icon and save button for updating the Patient Info

                $("#EditPatientData").click(function () {
                    debugger;
                    //Rizwan kharal
                    //28 Nov,2017
                    //Rights setting
                    if (!checkModuleRights("PatientCreate")) {
                        alert("You have no rights");
                    }
                    else {
                        $("[id$=UpdatePatient]").show();
                        $("[id$=CancelPatientUpdate]").show();
                        $("#EditPatientData").hide();

                        textboxhideshow();
                    }

                });



                // Rizwan kharal 
                // 27 Sep 2017
                //hide and showing textboxes For Update Patient info on demographics page
                var textboxhideshow = function () {





                    var v = $("[id$=lblFirstName]").val();

                    $("[id$=lblFirstName]").hide();

                    $("[id$=txtFirstName]").val(v); $("[id$=txtFirstName]").css("display", "block");



                    var v = $("[id$=lblMiddleName]").val();

                    $("[id$=lblMiddleName]").hide(); $("[id$=txtMiddleName]").val(v); $("[id$=txtMiddleName]").css("display", "block");



                    var v = $("[id$=lblLastName]").val();

                    $("[id$=lblLastName]").hide(); $("[id$=txtLastName]").val(v); $("[id$=txtLastName]").css("display", "block");



                    var v = $("[id$=lblDOB]").val();
                    $("[id$=lblDOB]").hide(); $("[id$=txtDOB]").val(v); $("[id$=txtDOB]").css("display", "block");

                    /************added by shahid kazmi 2/7/2018**********/
                    $("[id$=txtDOB]").datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                    $("[id$=txtDateOfDisability]").datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                    $("[id$=txtDateOfDeath]").datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                    $(".phone").mask("(999) 999-9999");
                    $("[id$=txtSSN]").mask("(999) 99-9999");
                    /********end shahid kazmi 2/7/2018*************/

                    var v = $("[id$=lblSSN]").val();
                    $("[id$=lblSSN]").hide(); $("[id$=txtSSN]").val(v); $("[id$=txtSSN]").css("display", "block");



                    var v = $("[id$=lblAddress]").text();
                    $("[id$=lblAddress]").hide(); $("[id$=txtAddress]").val(v); $("[id$=txtAddress]").css("display", "block");
                    var v = $("[id$=lblAddress]").text();
                    $("[id$=lblAddress]").hide(); $("[id$=txtAddress1]").val(v); $("[id$=txtAddress1]").css("display", "none");



                    var v = $("[id$=lblCity]").val();
                    $("[id$=lblCity]").hide(); $("[id$=txtCity]").val(v); $("[id$=txtCity]").css("display", "block");



                    var v = $("[id$=lblZipCode]").val();
                    $("[id$=lblZipCode]").hide(); $("[id$=txtZipCode]").val(v); $("[id$=txtZipCode]").css("display", "block");



                    var v = $("[id$=lblHomePhone]").val();
                    $("[id$=lblHomePhone]").hide(); $("[id$=txtHomePhone]").val(v); $("[id$=txtHomePhone]").css("display", "block");



                    var v = $("[id$=lblCellPhone]").val();
                    $("[id$=lblCellPhone]").hide(); $("[id$=txtCellPhone]").val(v); $("[id$=txtCellPhone]").css("display", "block");



                    var v = $("[id$=lblWorkPhone]").val();
                    $("[id$=lblWorkPhone]").hide(); $("[id$=txtWorkPhone]").val(v); $("[id$=txtWorkPhone]").css("display", "block");



                    var v = $("[id$=lblExt]").val();
                    $("[id$=lblExt]").hide(); $("[id$=txtExt]").val(v); $("[id$=txtExt]").css("display", "block");


                    debugger;
                    var v = $("[id$=lblEmail]").val();
                    $("[id$=lblEmail]").hide();
                    $("[id$=txtEmail]").val(v); $("[id$=txtEmail]").css("display", "block");


                    var v = $("[id$=lblFirstGuarantorName]").val();
                    $("[id$=lblFirstGuarantorName]").hide(); $("[id$=txtFirstGuarantorName]").val(v); $("[id$=txtFirstGuarantorName]").css("display", "block");

                    var v = $("[id$=lblMiddleGuarantorName]").val();
                    $("[id$=lblMiddleGuarantorName]").hide(); $("[id$=txtMiddleGuarantorName]").val(v); $("[id$=txtMiddleGuarantorName]").css("display", "block");

                    var v = $("[id$=lblLastGuarantorName]").val();
                    $("[id$=lblLastGuarantorName]").hide(); $("[id$=txtLastGuarantorName]").val(v); $("[id$=txtLastGuarantorName]").css("display", "block");



                    var v = $("[id$=lblEmergencyName]").val();
                    $("[id$=lblEmergencyName]").hide(); $("[id$=txtEmergencyName]").val(v); $("[id$=txtEmergencyName]").css("display", "block");



                    var v = $("[id$=lblEmergencyContact]").val();
                    $("[id$=lblEmergencyContact]").hide(); $("[id$=txtEmergencyContact]").val(v); $("[id$=txtEmergencyContact]").css("display", "block");



                    var v = $("[id$=lblDateOfDisability]").val();

                    $("[id$=lblDateOfDisability]").hide(); $("[id$=txtDateOfDisability]").val(v); $("[id$=txtDateOfDisability]").css("display", "block");


                    var v = $("[id$=lblDateOfDeath]").val();
                    $("[id$=lblDateOfDeath]").hide(); $("[id$=txtDateOfDeath]").val(v); $("[id$=txtDateOfDeath]").css("display", "block");



                    var v = $("[id$=lblCauseOfDeath]").val();
                    $("[id$=lblCauseOfDeath]").hide(); $("[id$=txtCauseOfDeath]").val(v); $("[id$=txtCauseOfDeath]").css("display", "block");





                    var v = $("[id$=lblPharmacyName]").val();
                    $("[id$=lblPharmacyName]").hide(); $("[id$=txtPharmacyName]").val(v); $("[id$=txtPharmacyName]").css("display", "block");
                    $(".spnAdd").css("display", "block");
                    $(".spnRemove").css("display", "block");


                    var v = $("[id$=txtNotes]").val();
                    $("[id$=txtNotes]").hide(); $("[id$=txtNotes2]").val(v); $("[id$=txtNotes2]").css("display", "block");





                    $("[id$=lblGender]").hide();

                    $("[id$=ddlGender]").css("display", "block");
                    $("[id$= lblMaritalStatus]").hide();

                    $("[id$=ddlMaritalStatus]").css("display", "block");

                    $("[id$= lblRACE]").hide();

                    $("[id$=ddlRace]").css("display", "block");

                    $("[id$=lblEthnicity]").hide();

                    $("[id$=ddlEthnicity]").css("display", "block");

                    $("[id$=lblPreferredLanguage]").hide();

                    $("[id$=ddlPreferredLanguage]").css("display", "block");



                    $("[id$=lblState]").hide();
                    $("[id$=ddlState]").css("display", "block");


                    $("[id$=lblAddressType]").hide();
                    $("[id$=ddlAddressType]").css("display", "block");

                    $("[id$=lblCCP]").hide();
                    $("[id$=ddlCCP]").css("display", "block");

                    $("[id$=lblRelationship]").hide();
                    $("[id$=ddlRelationship]").css("display", "block");

                    $("[id$=lblEmergencyRelationship]").hide();
                    $("[id$=ddlEmergencyRelationship]").css("display", "block");
                    $("[id$= txtNotes]").removeAttr('disabled');

                }


                //Rizwan kharal 
                // 29 sep to 6 oct 




                var hdnInsType = $("[id$=InsuranceType]").val();












                //PatientUpdate
                $("#UpdatePatient").click(function () {
                    debugger
                    if ($("[id$=txtFirstName]").val() == "" || $("[id$=txtLastName]").val() == "" || $("[id$=txtDOB]").val() == "" || $("[id$=txtAddress]").val() == "" || $("[id$=txtCity]").val() == "" || $("[id$=txtZipCode]").val() == "") {
                        debugger

                        var mesg = "Please review the form carefully and provide required information.";
                        showErrorMessage(mesg);


                    }
                    else {
                        debugger;
                        $("#searchGUARANTOR").hide();
                        var message = "Patient Updated Successfully ";
                        showSuccessMessage(message);
                        UpdatePatientOnDemographics();
                        $("#UpdatePatient").hide();
                        $("#CancelPatientUpdate").hide();
                        $(".spnAdd").css("display", "none");
                        $(".spnRemove").css("display", "none");

                    }


                });


                SetPTLReasons("ClaimsList");

            });

            var FinancialGuraId; var FGuranterId;



            var Pid = $("[id$=hdnPatientId]").val();

            function UpdatePatientOnDemographics() {
                debugger

                if (FGuranterId != null) {
                    debugger
                    FinancialGuraId = FGuranterId;
                }
                else {
                    FinancialGuraId = $("[id$=hdnFinancialGuranterId]").val();
                }

                debugger;
                var a = $("[id$= ddlPreferredLanguage]").val();
                var UpdateData = {



                    PatientId: $("[id$=hdnPatientId]").val(),
                    FinancialGuarantorId: FinancialGuraId,
                    FirstName: $("[id$=txtFirstName]").val(),
                    LastName: $("[id$=txtLastName]").val(),
                    MiddleName: $("[id$=txtMiddleName]").val(),
                    uDateOfBirth: $("[id$=txtDOB]").val(),
                    SSN: $("[id$=txtSSN]").val(),
                    Gender: $("[id$=ddlGender]").val(),
                    MaritalStatus: $("[id$=ddlMaritalStatus]").val(),
                    RaceId: $("[id$=ddlRace] option:selected").val(),
                    EthnicityId: $("[id$=ddlEthnicity]").val(),
                    PreferredLanguageId: $("[id$= ddlPreferredLanguage]").val(),



                    Address: $("[id$=txtAddress]").val(),
                    AddressType: $("[id$=ddlAddressType] option:selected").val(),
                    City: $("[id$=txtCity]").val(),
                    State: $("[id$=ddlState]").val(),

                    Zip: $("[id$=txtZipCode]").val(),
                    HomePhone: $("[id$=txtHomePhone]").val(),
                    Cell: $("[id$=txtCellPhone]").val(),
                    WorkPhone: $("[id$=txtWorkPhone]").val(),
                    Ext: $("[id$= txtExt]").val(),
                    Email: $("[id$=txtEmail]").val(),
                    CCP: $("[id$= ddlCCP]").val(),
                    GuarantorRelationship: $("[id$=ddlRelationship] option:selected").val(),


                    EmergencyContactName: $("[id$=txtEmergencyName]").val(),
                    Relationship: $("[id$=ddlEmergencyRelationship] option:selected").val(),
                    Phone: $("[id$=txtEmergencyContact]").val(),
                    uDisabilityDate: $("[id$=txtDateOfDisability]").val(),
                    uDeathDate: $("[id$=txtDateOfDeath]").val(),
                    CauseOfDeath: $("[id$=txtCauseOfDeath]").val(),
                    Notes: $("[id$=txtNotes2]").val(),
                    NCPDP: $("[id$='hdnNCPDP']").val(),
                };
                $.post("Demographics.aspx", { UpdateData: JSON.stringify(UpdateData), PatientIdaction: Pid, action: "update", FinancialGuranterId: FinancialGuraId })
                    .fail(function (xhr, status, error) { alert("Error" + error); })
                    .done(function () {
                        $("#ProfileName").load(location.href + " #ProfileName");
                        $("#DemographicsUpdate").load(location.href + " #DemographicsUpdate");

                        $("#EditPatientData").show();
                        $("#CancelPatientUpdate").hide();
                        $("#searchGUARANTOR").hide();

                    });

            }

            function PopulateFinancialGuarantorDetails(elem) {
                debugger
                var FirstName = $.trim($(elem).find("td").eq(2).html());
                var LastName = $.trim($(elem).find("td").eq(1).html());
                var FinancialGuarantorId = $.trim($(elem).attr("id"));
                $("[id$='txtFirstGuarantorName']").val(FirstName);
                $("[id$='txtLastGuarantorName']").val(LastName);
                //  $("[id$='hdnFinancialGuranterId']").val(FinancialGuarantorId);
                FGuranterId = FinancialGuarantorId;
                $("#FinancialGuarantorSearch").hide();
                $("#cover").css("display", "none");
                $("body").css("overflow", "visible");
            }

            //11 oct 2017      

            $("#CancelPatientUpdate").click(function () {
                $("#DemographicsUpdate").load(location.href + " #DemographicsUpdate");
                $("#CancelPatientUpdate").hide();
                $("#UpdatePatient").hide();
                $("#EditPatientData").show();


            });

            //Jump
            function FilterClaims(pageNumber, paging) {

                debugger;


                var PatientId = $.trim($("[id$='Pid']").val());
                var PractiseId = $.trim($("[id$='hdnPracticeId']").val());
                var ClaimId = $.trim($("#txtClaimNo").val()) == "" ? 0 : $.trim($("#txtClaimNo").val());
                var DOS = $.trim($("[id$='txtDateOfService']").val());

                var TotalCharges = $.trim($("#txtTotalCharges").val());
                var AmountPaid = $.trim($("#txtAmountPaid").val());
                var Adjusted = $.trim($("#txtAdjusted").val());

                var BalanceDue = $.trim($("#txtBalanceDue").val());
                var InsurancesNamesddl = $.trim($("[id$=ddlInsurancesNames]").val());

                var SubmissionStatusddl = $.trim($("[id$='ddlSubmissionStatus']  option:selected").text());
                //var PtlReasonsddl = $.trim($("[id$='ddlPtlReasons']  option:selected").text());  _ResolveUrl + 
                var PtlReasonsddl = GetPTLReasons("ulPTLReasonFilterListClaim");
                $.post("../../ProviderPortal/Patient/PatientClaimFilterHandler.aspx", { PatientId: PatientId, PractiseId: PractiseId, ClaimId: ClaimId, DOS: DOS, TotalCharges: TotalCharges, AmountPaid: AmountPaid, Adjusted: Adjusted, BalanceDue: BalanceDue, InsurancesNamesddl: InsurancesNamesddl, SubmissionStatusddl: SubmissionStatusddl, PtlReasonsddl: PtlReasonsddl, Rows: $("#ddlPagingClaims").val(), PageNumber: pageNumber, SortBy: $("#txtClaimNo").val() }, function (data) {
                    var returnHtml = data;
                    var start = data.indexOf("###Start###") + 11;
                    var end = data.indexOf("###End###");
                    $("#ClaimsList").html(returnHtml.substring(start, end));

                    var startRowsCount = data.indexOf("###StartPatientRowsCount###") + 30;
                    var endRowsCount = data.indexOf("###EndPatientRowsCount###");
                    $("[id$='hdnClaimsCount']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

                    if (paging == true) {
                        GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");
                    }

                    if ($("[id$='hdnClaimsCount']").val() > 0)
                        $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
                });
            }


            $(function () {

                $(".stringonly").keydown(function (e) {
                    if (e.ctrlKey || e.altKey) {
                        e.preventDefault();
                    } else {
                        var key = e.keyCode;
                        if (!((key == 8) || (key == 9) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                            e.preventDefault();
                        }
                    }
                });
            });

            $(".phone").mask("(999) 999-9999");
            $("[id$=txtSSN]").mask("(999) 99-9999");



            //$("[id$=txtDOB]").click(function () {

            $("[id$=txtDOB]").datepicker({
                changeMonth: true,
                changeYear: true
            });
            $("[id$=txtDateOfDisability]").datepicker({
                changeMonth: true,
                changeYear: true
            });
            $("[id$=txtDateOfDeath]").datepicker({
                changeMonth: true,
                changeYear: true
            });


            function getZipCityState(elem, zipId, cityId, stateId, callFrom) {

                debugger;
                var zipCode = "", city = "";
                if (callFrom == "Table") {
                    if ($(elem).hasClass("zip"))
                        zipCode = $.trim($(zipId).val());
                    else
                        city = $.trim($(cityId).val());

                    _zipId = $(elem).closest("tr").find(".zip");
                    _cityId = $(elem).closest("tr").find(".city");
                    _stateId = $(elem).closest("tr").find(".state");

                }
                else {
                    //Changed By Zia(06/08/2017)
                    _zipId = $("[id$='" + zipId + "']");
                    _cityId = $("[id$='" + cityId + "']");
                    _stateId = $("[id$='" + stateId + "']");
                    if ($(elem).hasClass("zip")) {
                        zipCode = $.trim($("[id$='" + zipId + "']").val());
                        //below lines are added by amin ahmed for bug id 5235
                        _cityId.val("");
                        _stateId.val("");
                        //end addition
                    }
                    else {
                        //below lines are added by amin ahmed for bug id 5235
                        _zipId.val("");
                        _stateId.val("");
                        //end addition
                        city = $.trim($("[id$='" + cityId + "']").val());
                    }
                    //End Changed By Zia(06/08/2017)
                }
                if (zipCode != "" || city != "") {
                    $.post(_ResolveUrl + "Providerportal/Controls/GetZipCityState.aspx", { ZipCode: zipCode, City: city },
                        function (data) {
                            debugger;
                            var returnHtml = data;
                            var start = data.indexOf("#StartZipCityState#") + 19;
                            var end = data.indexOf("#EndZipCityState#");
                            $(elem).next().find(".divZipCityResult").html($.trim(returnHtml.substring(start, end)));
                            $(elem).next().show();
                            $(".divZipCityResult").show();

                            if ($(elem).next().find(".divZipCityResult table tr").length == 0) {
                                $(elem).next().find(".divZipCityResult").html("<span style='color: red;font-style: italic;font-weight: bold;'>No Record Found</span>").css({ 'text-align': 'center', 'line-height': '27px' });
                            }
                        });
                }
                else {
                    $(elem).next().hide();
                }
            }
            function selectZipCityState(zip, city, state) {
                debugger;
                $(_zipId).val(zip);
                $(_cityId).val(city);
                $(_stateId).val(state);
                $(".divZipCityResult").hide();
            }

            $('form,#txtZipCode').attr("autocomplete", "off");
            $('form,#txtCity').attr("autocomplete", "off");





            // Checking Email

            function showSuccessMessage(message) {

                $(".divMesg").css("display", "block");
                $(".divMesg").html(message).removeClass("warning").addClass("success").fadeIn(2000).fadeOut(10000);
            }

            function showErrorMessage(mesg) {

                $(".divMesg").css("display", "block");
                $(".divMesg").html(mesg).removeClass("success").addClass("warning").fadeIn(2000).fadeOut(10000);
            }
            //For Uncheck CheckBox if one Checkbox is checked then other checkbox is unCheck
            $('input._ChkBox').on('change', function () {
                debugger;
                $('input._ChkBox').not(this).prop('checked', false);
            });
            //Added By Syed Sajid Ali Date:8/30/2011
            function ClaimOpenForView(Claimid, PatientId, status) {
                debugger;
                var params = {
                    ClaimId: Claimid,
                    PatientId: PatientId,
                    Status: status
                };
                $.post("../Claims/CallBacks/OpenClaimForm.aspx", params, function (data) {
                    debugger;
                    var start = data.indexOf("###StartAllClaims###") + 20;
                    var end = data.indexOf("###EndAllClaims###");
                    var returnHtml = $.trim(data.substring(start, end));
                    $("#OpenClaimForm").html(returnHtml);

                    $("#OpenClaimForm").dialog({
                        width: 1060,
                        // height:auto,
                        modal: true,
                        title: "Claim Details",
                        open: function () {
                            $(".ui-widget-overlay").last().css("z-index", "9999999");
                            $(".ui-dialog").last().css("z-index", "99999999");
                        },
                        close: function () {
                            $(this).dialog("destroy");
                            $("#OpenClaimForm").hide();
                        }
                    });
                });

            }
            // Showing the PtlReason of patient to change the PTLReasons Id to reasons 
            //var PTLType = "ClaimsList"
            function SetPTLReasons(PTLType) {
                debugger;
                var PTLReason, strPTLReasons = "", arrPTLReasons;

                $("#" + PTLType + " .tdPTLReasons").each(function () {
                    debugger;
                    strPTLReasons = $.trim($(this).find("span").html());

                    if (strPTLReasons != "") {
                        arrPTLReasons = strPTLReasons.split(',');

                        strPTLReasons = "";

                        for (var i = 0; i < arrPTLReasons.length; i++) {
                            PTLReason = $.trim($("[id$='chk" + PTLType + "PTLReasonsId" + arrPTLReasons[i] + "']").parent().find(".spnReason").html());

                            strPTLReasons += PTLReason + ", ";
                        }

                        if (strPTLReasons.length > 1) {
                            strPTLReasons = strPTLReasons.slice(0, -2);
                        }
                    }
                    else {
                        strPTLReasons = $.trim($(this).find(".hdnPTLNotes").val());
                    }

                    $(this).html(strPTLReasons);
                });
            }
        //Added By Syed Sajid Ali Date:8/30/2011
        </script>
        <style type="text/css">
            .Grid {
                margin-top: 1%;
            }

            .success {
                background: url("../../Images/success.png") no-repeat scroll 10px center #EAF7D9;
                border: 1px solid #BBDF8D;
                border-radius: 5px;
                -moz-border-radius: 5px;
                -o-border-radius: 5px;
                -webkit-border-radius: 5px;
                color: #3c763d;
                font-size: 12px;
                margin-bottom: 15px;
                padding: 10px 10px 10px 33px;
            }

            .warning {
                background: url("../../Images/warning.png") no-repeat scroll 10px center #FFD1D1;
                border: 1px solid #F8ACAC;
                border-radius: 5px;
                -moz-border-radius: 5px;
                -o-border-radius: 5px;
                -webkit-border-radius: 5px;
                color: #a94442;
                font-size: 12px;
                margin-bottom: 15px;
                padding: 10px 10px 10px 33px;
            }

            .ui-dialog {
                margin-top: 2% !important;
                top: 0 !important;
            }

            .ui-widget-content {
                padding-right: 0px !important;
            }

            #searchGUARANTOR {
                background-image: url("../../Images/SmallSearch.gif");
                min-width: 24px !important;
                height: 24px;
                background-repeat: no-repeat;
                border-bottom: white !important;
                float: right;
                margin-top: -26px;
                background-color: white;
            }


            .patient-widget {
                float: left;
                width: 100%;
                border: 1px solid #dbdbdb;
                border-bottom: 1px solid #949494;
                line-height: 25px;
                margin-bottom: 10px;
            }

                .patient-widget .patient-widget-title {
                    margin: 5px;
                    border-bottom: 1px solid #000000;
                    font-weight: bold;
                }

                .patient-widget .patient-widget-content {
                    padding: 5px;
                }

            .UpdateButton {
                background-image: url("../../Images/success.png") !important;
                background-repeat: no-repeat;
                border: none;
                box-shadow: none;
                height: 18px;
                min-width: 19px !important;
                background-color: transparent !important;
            }

            .UpdateButtonClose {
                background-image: url("../../Images/cross.png") !important;
                background-repeat: no-repeat;
                border: none;
                box-shadow: none;
                height: 18px;
                min-width: 19px !important;
                background-color: white !important;
            }

            #InsEdit {
                background-image: url("../../Images/edit.png") !important;
                background-repeat: no-repeat;
                border: none;
                box-shadow: none;
                height: 18px;
                min-width: 19px !important;
            }

            .txtDesign {
                margin-left: 5px !important;
                display: none;
            }

            .textDesign {
                border: none !important;
                box-shadow: none !important;
                background-color: transparent !important;
            }

            #AddInsuranceDiv {
                height: 326px;
                width: 70%;
                border: 2px solid white;
                margin-top: 5.5%;
                margin-left: 15%;
                z-index: 10;
                display: none;
                background-color: white;
                opacity: 2;
                border-radius: 4px;
                position: fixed;
            }




            #UpdateInsuranceDiv {
                height: 326px;
                width: 70%;
                border: 2px solid white;
                margin-top: 5.5%;
                margin-left: 15%;
                border-radius: 4px;
                z-index: 10;
                display: none;
                background-color: white;
                opacity: 2;
                position: fixed;
            }


            #cover {
                position: fixed;
                top: 0;
                left: 0;
                background: rgba(0,0,0,0.6);
                z-index: 5;
                width: 100%;
                height: 100%;
                display: none;
            }

            /*#AddInsuranceDiv:target, #AddInsuranceDiv:target + #cover{
    display:block;
    opacity:2;
}*/


            .alert {
                background-color: rgba(255, 44, 44, 0.63);
                display: none;
            }

            ddl {
                background: #ffffff;
                border-top: solid 1px #c4c4c4;
                border-left: solid 1px #c4c4c4;
                border-bottom: solid 1px #c4c4c4;
                border-right: solid 1px #c4c4c4;
                border-top: solid 1px #c4c4c4;
                border-left: solid 1px #c4c4c4;
                border-bottom: solid 1px #c4c4c4;
                border-right: solid 1px #c4c4c4;
                box-shadow: inset 0 1px 1px rgba(0,0,0,0.075);
                transition: border linear .2s,box-shadow linear .2s;
                width: 92%;
            }

            #FinancialGuarantorSearch {
                height: 410px;
                width: 70%;
                border: 2px solid white;
                margin-top: 0.5%;
                margin-left: 15%;
                z-index: 10;
                display: none;
                background-color: white;
                opacity: 2;
                border-radius: 4px;
                position: fixed;
            }

            .spnAdd {
                background: url('../../Images/btnAdd.png') no-repeat;
                height: 21px;
                width: 21px;
                float: left;
                margin: 5px 3px 0px 10px;
                cursor: pointer;
            }

            .spnRemove {
                background: url('../../Images/btnRemove.png') no-repeat;
                height: 21px;
                width: 21px;
                float: left;
                margin: 5px 5px 0px 0px;
                cursor: pointer;
            }
        </style>





    </div>

</asp:Content>

