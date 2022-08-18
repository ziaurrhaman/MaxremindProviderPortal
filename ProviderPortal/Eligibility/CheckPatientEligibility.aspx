<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckPatientEligibility.aspx.cs" Inherits="EMR_Eligibility_CheckPatientEligibility" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###EligibilityResponseStart###
    <div class="EligibilityR">
        <asp:HiddenField ID="hdnRowCount" runat="server" />
    </div>
            <script type="text/javascript">

               
                function showHideBenefits(elem) {
                    if ($(elem).find(".iconUp").length > 0) {
                        $(elem).find(".iconUp").removeClass("iconUp").addClass("iconDown");
                        $(elem).parent().find("div.addPatientInsurance").hide();
                        $(elem).parent().find("div.accordion-content").slideDown("fast");

                    } else {
                        $(elem).find(".iconDown").removeClass("iconDown").addClass("iconUp");
                        $(elem).parent().find("div.accordion-content").slideUp("fast");
                    }
                }

                function ShowCompleteEligibility() {
                    if ($("[id$='chkShowCompleteReport']").is(":checked")) {
                        $("#divSections input").prop("checked", false);
                    }
                    else {
                        $("#divSections input").prop("checked", true);
                    }

                    $("#divSections input").click();
                }

                function ShowSection(id, obj) {

                    if ($(obj).find("input").is(":checked"))
                        $("#" + id).show();
                    else
                        $("#" + id).hide();

                    if ($("#divSections input:checked").length == $("#divSections input").length)
                        $("#chkShowCompleteReport").prop("checked", true);
                    else
                        $("#chkShowCompleteReport").prop("checked", false);
                }

                function UpdatePatientInformation(obj, InfoToUpdate) {
                    if ($(obj).hasClass("link")) {
                        if ($("[id$='hdnEligibilityPatientId']").val() != "0") {

                            var CityStateZip = $("[id$='lblInsuranceCityStateZip']").text().split(',');

                            $.post(_ResolveUrl + "HomeHealth/Eligibility/UpdatePatientInfo.aspx",
                                {
                                    PatientId: $("[id$='hdnEligibilityPatientId']").val(),
                                    InfoToUpdate: InfoToUpdate, FirstName: $("[id$='lblInsuranceFirstName']").text(), LastName: $("[id$='lblInsuranceLastName']").text(),
                                    DOB: $("[id$='lblInsuranceDOB']").text(), Gender: $("[id$='lblInsuranceGender']").text(),
                                    PolicyNumber: $("[id$='lblInsurancePolicyNumber']").text(), Address: $("[id$='lblInsuranceAddress']").text(),
                                    City: CityStateZip[0], State: $.trim(CityStateZip[1]).split(" ")[0], Zip: $.trim(CityStateZip[1]).split(" ")[1]
                                },
                            function (data) {
                                $(obj).removeClass("link red");

                                if (InfoToUpdate == "LastName") {
                                    $("[id$='lblAgencyLastName']").text($("[id$='lblInsuranceLastName']").text());
                                }

                                if (InfoToUpdate == "FirstName") {
                                    $("[id$='lblAgencyFirstName']").text($("[id$='lblInsuranceFirstName']").text());
                                }
                                if (InfoToUpdate == "DOB") {
                                    $("[id$='lblAgencyDOB']").text($("[id$='lblInsuranceDOB']").text());
                                }
                                if (InfoToUpdate == "Gender") {
                                    $("[id$='lblAgencyGender']").text($("[id$='lblInsuranceGender']").text());
                                }
                                if (InfoToUpdate == "PolicyNumber") {
                                    $("[id$='lblAgencyPolicyNumber']").text($("[id$='lblInsurancePolicyNumber']").text());
                                }
                                if (InfoToUpdate == "Address") {
                                    $("[id$='lblAgencyAddress']").text($("[id$='lblInsuranceAddress']").text());
                                }
                                if (InfoToUpdate == "CityStateZip") {
                                    $("[id$='lblAgencyCityStateZip']").text($("[id$='lblInsuranceCityStateZip']").text());
                                }

                            });
                        }
                        else {
                            if (InfoToUpdate == "LastName") {
                                $("[id$='txtLastNamePatient']").val($("[id$='lblInsuranceLastName']").text());
                                $("[id$='lblAgencyLastName']").text($("[id$='lblInsuranceLastName']").text());
                            }

                            if (InfoToUpdate == "FirstName") {
                                $("[id$='txtFirstNamePatient']").val($("[id$='lblInsuranceFirstName']").text());
                                $("[id$='lblAgencyFirstName']").text($("[id$='lblInsuranceLastName']").text());
                            }
                            if (InfoToUpdate == "DOB") {
                                $("[id$='txtDOBPatient']").val($("[id$='lblInsuranceDOB']").text());
                                $("[id$='lblAgencyDOB']").text($("[id$='lblInsuranceDOB']").text());
                            }
                            if (InfoToUpdate == "Gender") {
                                $("[id$='txtFirstNamePatient']").val($("[id$='lblInsuranceGender']").text());
                                $("[id$='lblAgencyGender']").text($("[id$='lblInsuranceGender']").text());
                            }
                            if (InfoToUpdate == "PolicyNumber") {
                                $("[id$='txtPolicyNoPatient']").val($("[id$='lblInsurancePolicyNumber']").text());
                                $("[id$='lblAgencyPolicyNumber']").text($("[id$='lblInsurancePolicyNumber']").text());
                            }
                            if (InfoToUpdate == "Address") {
                                $("[id$='txtAddressPatient']").val($("[id$='lblInsuranceAddress']").text());
                                $("[id$='lblAgencyAddress']").text($("[id$='lblInsuranceAddress']").text());
                            }
                            if (InfoToUpdate == "CityStateZip") {

                                $("[id$='lblAgencyCityStateZip']").text($("[id$='lblInsuranceCityStateZip']").text());

                                var CityStateZip = $("[id$='lblInsuranceCityStateZip']").text().split(',');
                                $("[id$='txtCityPatient']").val(CityStateZip[0]);
                                $("[id$='ddlStatePatient']").val($.trim(CityStateZip[1]).split(' ')[0]);
                                $("[id$='txtZipPatient']").val($.trim(CityStateZip[1]).split(' ')[1]);
                            }
                        }
                    }
                }

            </script>

            <style type="text/css">
                .box-grid th {
                    background: #e3e9fe;
                    border: 2px solid #FFF;
                    font-weight: bold;
                    height: 30px;
                    line-height: 19px;
                }

                .box-heading {
                    font-size: 12px;
                    font-weight: bold;
                    text-align: left;
                    padding: 0 5px;
                    background: #d6e0e4 !important;
                    height: 30px;
                    line-height: 30px;
                }

                .box-wrapper {
                    padding: 10px;
                    border: 1px solid #dfe0e2;
                    background-color: #f9f9fa !important;
                    line-height: 22px;
                }

                .Grid {
                    border: none;
                    outline: 1px solid #dfe0e2;
                    outline-offset: -1px;
                }

                .red {
                    color: red;
                }

                #divHomehealth tr:nth-child(even) {
                    background-color: #F7F7F7 !important;
                }

                #divHomehealth tr:nth-child(odd) {
                    background-color: #FFF !important;
                }

                .accordion {
                    margin-bottom: 2px;
                    border: 1px solid #E2E2E2;
                    -webkit-border-radius: 3px;
                    -moz-border-radius: 3px;
                    border-radius: 3px;
                    -webkit-box-shadow: inset 0 1px 0 #f9f9f9;
                    -moz-box-shadow: inset 0 1px 0 #f9f9f9;
                    box-shadow: inset 0 1px 0 #f9f9f9;
                    float: left;
                    width: 100%;
                }

                    .accordion > div {
                        background-color: White;
                    }
            </style>
            <asp:Literal runat="server" ID="ltrlEligibilityResponse"></asp:Literal>
            <asp:HiddenField ID="hdnIsCMSInsurance" runat="server" />
            <asp:HiddenField runat="server" ID="hdnEligibilityPatientId" />
            <h2 style="margin-left:42%">Eligibility Report</h2>
            <div>
                <div style="float: left; width: 49.5%;margin-bottom:10px" runat="server" id="divInsuranceData">
                    <div class="box-heading">
                        Insured or Subscriber
                    </div>
                    <div class="box-wrapper">
                        <table>
                            <tr>
                                <td style="width: 25%;">Last Name:
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsuranceLastName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>First Name:                             
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsuranceFirstName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>DOB:                        
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsuranceDOB"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Gender:                               
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsuranceGender"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Policy Number:                                  
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsurancePolicyNumber"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Address:                             
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsuranceAddress"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>City, State, Zip:                                   
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsuranceCityStateZip"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="box-heading">
                        Payer
                    </div>
                    <div class="box-wrapper">
                        <table>
                            <tr>
                                <td style="width: 25%;">Payer Name:
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPayerName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%;">Payer Id:
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPayerId"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="float: right; width: 49.5%;">
                    <div style="margin-bottom: 10px">
                        <label style="color: blue; width: 20px">Eligibility or Benefits:</label>
                        <asp:Label runat="server" ID="lblEligBenifits"></asp:Label>
                    </div>
                    <div style="margin-bottom: 10px">
                        <label style="color: blue; width: 20px">Service Type:</label>
                        <asp:Label runat="server" ID="lblServiceType"></asp:Label>
                    </div>
                    <div class="box-heading">
                        Select Section

                    <asp:CheckBox runat="server" ID="chkShowCompleteReport" Text="Show Complete Report" onclick="ShowCompleteEligibility();" Style="float: right;" />
                    </div>
                    <div class="box-wrapper" style="height: 218px; overflow: auto;" id="divSections">
                        <asp:Repeater runat="server" ID="rptSections" OnItemDataBound="rptSections_ItemDataBound">
                            <ItemTemplate>
                                <label style="display: block;" onclick="ShowSection('<%#Eval("RowNumber")%>', this)">
                                    <input type="checkbox" id="chkShowSection" />
                                    <asp:Label ID="lblInsuranceType" runat="server"></asp:Label>
                                    <asp:Label ID="lblServiceType" runat="server"></asp:Label>
                                </label>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>




            <table border="0" cellpadding="0" cellspacing="0" >


                <tr>
                    <td colspan="2">



                        <asp:Repeater runat="server" ID="rptBenefitDescription" OnItemDataBound="rptBenefitDescription_ItemDataBound">
                            <ItemTemplate>
                                <div style="margin-bottom: 10px; display: none;" class="accordion" id="<%#Eval("RowNumber")%>">
                                    <div class="box-heading" onclick="showHideBenefits(this);" style="cursor: pointer;text-align:center;background-color:white !important">
                                        <span class="iconDown"></span>
                                        <asp:Label ID="lblInsuranceType" runat="server"></asp:Label>
                                        <asp:Label ID="lblServiceType" runat="server"></asp:Label>
                                    </div>
                                    <div class="Grid accordion-content">
                                        <table border="0" cellpadding="0" cellspacing="0" class="tblBenefitPlanIfo">
                                            <tr>
                                                <th style="width: 25%;">Service
                                                </th>
                                                <th style="width: 10%;">Time
                                                </th>
                                                <th style="width: 7%;">Amount
                                                </th>
                                                <th style="width: 8%;">Quantity
                                                </th>
                                                <th style="width: 11%;">Quantity Type
                                                </th>
                                                <th style="width: 14%;">Dates
                                                </th>
                                                <th style="width: 15%;">Message
                                                </th>
                                            </tr>
                                            <asp:Repeater runat="server" ID="rptBenefitPlanDetail" OnItemDataBound="rptBenefitPlanDetail_ItemDataBound">
                                                <ItemTemplate>
                                                    <asp:Literal runat="server" ID="ltrlEligibilityServices"></asp:Literal>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Repeater runat="server" ID="rptRejection" OnItemDataBound="rptRejection_ItemDataBound">
                            <HeaderTemplate>
                                <div class="Grid">
                                    <table border="0" cellpadding="0" cellspacing="0" class="tblBenefitPlanIfo">
                                        <tr>
                                            <th style="width: 60%;">Rejection Reason
                                            </th>
                                            <th style="width: 40%;">Follow-up Action
                                            </th>
                                        </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblRejectionReason"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFollowupAction"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblRejectionReason"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFollowupAction"></asp:Label>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </table> </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
            ###EligibilityResponseEnd###
    ###EpisodeEligibilityStart###
        <table border="0" cellpadding="0" cellspacing="0" style="line-height: 25px; font-size: 13px; text-align: right;" runat="server" id="Table1">
            <tr>
                <td><span style="margin-right: 5px;">Medicare Part A:</span>
                    <asp:Label runat="server" ID="Label1" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
            </tr>
            <tr>
                <td><span style="margin-right: 5px;">Home Health Care Part A:</span><asp:Label runat="server" ID="lblHomeHealthPartA" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
            </tr>
            <tr>
                <td><span style="margin-right: 5px;">Medicare Part B:</span><asp:Label runat="server" ID="Label2" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
            </tr>
            <tr>
                <td><span style="margin-right: 5px;">Home Health Care Part B:</span><asp:Label runat="server" ID="lblHomeHealthPartB" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
            </tr>
        </table>

            <table border="0" cellpadding="0" cellspacing="0" style="line-height: 25px; font-size: 13px;" runat="server" id="Table2">
                <tr>
                    <td><span style="margin-right: 5px;">General Benefits:</span>
                        <asp:Label runat="server" ID="Label3" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
                </tr>
                <tr>
                    <td><span style="margin-right: 5px;">Home Health Care:</span><asp:Label runat="server" ID="lblEpisodeHomehealth" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
                </tr>
            </table>
            ###EligibilityResponseEnd###
    ###EpisodeEligibilityStart###
   <div class="widget-box">
       <div class="widget-title">Eligibility Information</div>
       <div class="widget-content">
           <table border="0" cellpadding="0" cellspacing="0" style="line-height: 25px; font-size: 13px; text-align: right;" runat="server" id="tblMedicareEligibility">
               <tr>
                   <td><span style="margin-right: 5px;">Medicare Part A:</span>
                       <asp:Label runat="server" ID="lblMedicarePartA" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
               </tr>
               <tr>
                   <td><span style="margin-right: 5px;">Home Health Care Part A:</span><asp:Label runat="server" ID="lblEMRPartA" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
               </tr>
               <tr>
                   <td><span style="margin-right: 5px;">Medicare Part B:</span><asp:Label runat="server" ID="lblMedicarePartB" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
               </tr>
               <tr>
                   <td><span style="margin-right: 5px;">Home Health Care Part B:</span><asp:Label runat="server" ID="lblEMRPartB" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
               </tr>
           </table>

           <table border="0" cellpadding="0" cellspacing="0" style="line-height: 25px; font-size: 13px;" runat="server" id="tblOtherEligibility">
               <tr>
                   <td><span style="margin-right: 5px;">General Benefits:</span>
                       <asp:Label runat="server" ID="lblEpisodeGeneralBenefits" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
               </tr>
               <tr>
                   <td><span style="margin-right: 5px;">Home Health Care:</span><asp:Label runat="server" ID="lblEpisodeEMR" Style="font-weight: bold;" Text="No information available"></asp:Label></td>
               </tr>
           </table>
       </div>
   </div>
            ###EpisodeEligibilityEnd###
    
    ###StartEligibilityResponseStatus###
    <asp:Literal runat="server" ID="ltrEligibilityResponseStatus"></asp:Literal>
            ###EndEligibilityResponseStatus###

    ###StartEligibilityAjaxResponse###
    <asp:Literal runat="server" ID="ltrEligibilityAjaxResponse"></asp:Literal>

            ###EndEligibilityAjaxResponse###
        </div>
    </form>
</body>
</html>
