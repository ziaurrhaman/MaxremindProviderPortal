<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimFormView.aspx.cs" Inherits="EMR_Claims_ClaimFormView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Health Insurance Claim Form</title>
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.9.0.js" type="text/javascript"></script>
    <style type="text/css" media="all">
        .cms-form {
            position: relative;
            height: 1350px;
            width: 1050px;
            background: #ffffff;
            margin: 6px auto;
        }

        #divCMS img {
            width: 1050px;
            background: white;
        }

        .absolute {
            position: absolute;
        }

        .bold {
            font-size: 11px;
        }

        .insurance-company {
            top: 80px;
            right: 0px;
            width: 358px;
            height: 59px;
        }

        .insurance-number {
            top: 165px;
            right: 325px;
        }

        /*Start Other Coverage*/
        .policy-holder-other-coverage {
            top: 385px;
            left: 34px;
        }

        .policy-holder-other-coverage-group {
            top: 422px;
            left: 34px;
        }

        .insurance-company-other-coverage {
            top: 400px;
            left: 62px;
            width: 355px;
        }
        /*End Other Coverage*/



        .policy-holder {
            top: 208px;
            left: 660px;
        }

        .policy-holder-address {
            top: 256px;
            left: 660px;
            width: 295px;
        }

        .policy-holder-city {
            top: 295px;
            left: 660px;
        }

        .policy-holder-state {
            top: 297px;
            right: 60px;
        }

        .policy-holder-zip {
            top: 340px;
            left: 660px;
        }

        .policy-holder-phone-areaCode {
            top: 340px;
            right: 180px;
        }

        .policy-holder-phone {
            top: 340px;
            right: 88px;
        }

        .policy-holder-dob-dd {
            top: 430px;
            right: 304px;
        }

        .policy-holder-dob-yy {
            top: 430px;
            right: 257px;
        }

        .policy-holder-dob-mm {
            top: 430px;
            right: 342px;
        }

        .policy-holder-gender-M {
            top: 427px;
            right: 162px;
        }

        .policy-holder-gender-F {
            top: 427px;
            right: 72px;
        }

        .policy-holder-group {
            top: 383px;
            left: 670px;
        }

        .pri-insurance-plan {
            top: 513px;
            left: 670px;
        }

        .other-insurance-plan-yes {
            top: 558px;
            left: 676px;
        }

        .other-insurance-plan-no {
            top: 558px;
            left: 741px;
        }

        .other-insurance-plan {
            top: 555px;
            left: 34px;
        }

        .ref-no {
            top: 818px;
            left: 815px;
        }

        .resubmission-code {
            top: 818px;
            left: 672px;
        }

        .insured-signature {
            top: 642px;
            left: 744px;
        }

        .patient-signature {
            top: 642px;
            left: 109px;
        }

        .patient-information {
            top: 208px;
            left: 31px;
            width: 283px;
        }

        .patient-information-address {
            top: 254px;
            left: 31px;
            width: 283px;
        }

        .patient-information-city {
            top: 292px;
            left: 31px;
        }

        .patient-information-state {
            top: 294px;
            left: 356px;
        }

        .patient-information-zip {
            top: 340px;
            left: 31px;
        }

        .patient-information-relationship-self {
            top: 254px;
            left: 434px;
        }

        .patient-information-relationship-spouse {
            top: 254px;
            left: 500px;
        }

        .patient-information-relationship-dependent {
            top: 211px;
            left: 550px;
        }

        .patient-information-relationship-other {
            top: 254px;
            left: 613px;
        }

        .patient-condition-employment-yes {
            top: 428px;
            left: 462px;
        }

        .patient-condition-employment-no {
            top: 428px;
            left: 538px;
        }

        .patient-condition-autoAccident-yes {
            top: 471px;
            left: 462px;
        }

        .patient-condition-autoAccident-no {
            top: 471px;
            left: 538px;
        }

        .patient-condition-autoAccident-State {
            top: 475px;
            left: 592px;
        }

        .patient-condition-otherAccident-yes {
            top: 514px;
            left: 462px;
        }

        .patient-condition-otherAccident-no {
            top: 514px;
            left: 538px;
        }

        .patient-information-dob-dd {
            top: 215px;
            left: 454px;
        }

        .patient-information-dob-yy {
            top: 215px;
            left: 503px;
        }

        .patient-information-dob-mm {
            top: 215px;
            left: 416px;
        }

        .patient-information-gender-M {
            top: 213px;
            left: 549px;
        }

        .patient-information-gender-F {
            top: 213px;
            left: 613px;
        }

        .patient-information-phone-areaCode {
            top: 342px;
            left: 211px;
        }

        .patient-information-phone {
            top: 342px;
            left: 268px;
        }

        .patient-information-single {
            top: 265px;
            left: 379px;
        }

        .patient-information-otherStatus {
            top: 265px;
            left: 504px;
        }


        .patient-information-claimid {
            top: 390px;
            left: 567px;
        }

        .practice-taxId {
            bottom: 139px;
            left: 37px;
        }

        .practice-taxId-CheckBox {
            bottom: 135px;
            left: 259px;
        }

        .patient-information-PatientId {
            bottom: 138px;
            left: 328px;
        }

        .patient-information-AcceptAssignment {
            bottom: 135px;
            left: 501px;
        }

        .patient-Illness-dd {
            top: 689px;
            left: 85px;
        }

        .patient-Illness-mm {
            top: 689px;
            left: 46px;
        }

        .patient-Illness-yy {
            top: 689px;
            left: 133px;
        }

        .patient-Illness-QUAL {
            top: 689px;
            left: 218px;
        }

        .patient-other-dd {
            top: 689px;
            left: 532px;
        }

        .patient-other-mm {
            top: 689px;
            left: 493px;
        }

        .patient-other-yy {
            top: 689px;
            left: 575px;
        }

        .patient-other-QUAL {
            top: 689px;
            left: 413px;
        }

        .billing-Physician-information {
            bottom: 50px;
            right: 87px;
            width: 302px;
            height: 46px;
        }

        .billing-Physician-information-npi {
            bottom: 28px;
            left: 678px;
        }

        .billing-Physician-information-license {
            bottom: 13px;
            left: 673px;
        }

        .billing-Physician-information-tin {
            bottom: 82px;
            left: 314px;
        }

        .billing-Physician-information-phone-ext {
            bottom: 111px;
            right: 168px;
        }

        .billing-Physician-information-phone-number {
            bottom: 111px;
            right: 86px;
        }

        .billing-Physician-information-additional-provider-id {
            bottom: 61px;
            left: 327px;
        }


        .treating-Physician-information-npi {
            bottom: 127px;
            left: 473px;
        }

        .treating-Physician-information-license {
            bottom: 127px;
            left: 719px;
        }

        .treating-Physician-information-address {
            bottom: 82px;
            left: 440px;
            line-height: 10px;
        }

        .treating-Physician-information-speciality-code {
            bottom: 110px;
            left: 700px;
        }

        .treating-Physician-information-phone-ext {
            bottom: 61px;
            left: 500px;
        }

        .treating-Physician-information-phone-number {
            bottom: 61px;
            left: 534px;
        }

        .treating-Physician-information-additional-provider-id {
            bottom: 61px;
            right: 168px;
        }

        .referring-Physician-Qual {
            top: 730px;
            left: 30px;
        }

        .referring-Physician {
            top: 730px;
            left: 68px;
        }

        .Additional-Information {
            top: 763px;
            left: 45px;
        }

        .referring-Physician-upin-qual {
            top: 708px;
            left: 403px;
        }

        .referring-Physician-upin {
            top: 708px;
            left: 218px;
        }

        .referring-Physician-npi {
            top: 731px;
            left: 429px;
        }

        .patient-admissoin-dd {
            top: 732px;
            left: 745px;
        }

        .patient-admissoin-mm {
            top: 732px;
            left: 706px;
        }

        .patient-admissoin-yy {
            top: 732px;
            left: 795px;
        }

        .patient-discharge-dd {
            top: 732px;
            left: 884px;
        }

        .patient-discharge-mm {
            top: 732px;
            left: 924px;
        }

        .patient-discharge-yy {
            top: 732px;
            left: 971px;
        }

        .paNumber {
            top: 709px;
            left: 551px;
        }

        .ancillary-claim-place-of-treatment {
            bottom: 350px;
            right: 339px;
        }

        .ancillary-claim-enclosures {
            bottom: 334px;
            right: 140px;
        }

        .ancillary-claim-orthodontics-no {
            bottom: 303px;
            right: 409px;
        }

        .ancillary-claim-orthodontics-yes {
            bottom: 303px;
            right: 323px;
        }

        .ancillary-claim-date-appliance {
            bottom: 305px;
            right: 143px;
        }

        .ancillary-claim-month-of-treatment-remainig {
            bottom: 273px;
            right: 370px;
        }

        .ancillary-claim-replacement-of-prosthesis-no {
            bottom: 269px;
            right: 323px;
        }

        .ancillary-claim-replacement-of-prosthesis-yes {
            bottom: 269px;
            right: 294px;
        }

        .ancillary-claim-date-of-prior-placement {
            bottom: 272px;
            right: 142px;
        }

        .ancillary-claim-treatment-resulting-from-injury {
            bottom: 238px;
            right: 409px;
        }

        .ancillary-claim-treatment-resulting-from-auto-accident {
            bottom: 238px;
            right: 265px;
        }

        .ancillary-claim-treatment-resulting-from-other-accident {
            bottom: 237px;
            right: 169px;
        }

        .ancillary-claim-date-of-accident {
            bottom: 222px;
            right: 242px;
        }

        .ancillary-claim-auto-accident-state {
            bottom: 222px;
            right: 63px;
        }


        .claim-services {
            top: 924px;
            left: 32px;
            width: 1004px;
        }

        .tbodyClaimService td {
            line-height: 25px;
            padding-top: 18px;
        }

        .claim-total-fee {
            bottom: 134px;
            right: 310px;
        }

        .TotalCharges {
            bottom: 103px;
            right: 145px;
        }

        .TotalCharges1 {
            bottom: 103px;
            right: 135px;
        }

        .AmmountPaid {
            bottom: 133px;
            left: 823px;
        }

        .AmmountPaid1 {
            bottom: 133px;
            right: 146px;
        }

        .claim-DxCode {
            bottom: 538px;
            left: 554px;
        }

        .claim-DxCode1 {
            bottom: 517px;
            left: 53px;
        }

        .claim-DxCode2 {
            bottom: 517px;
            left: 218px;
        }

        .claim-DxCode3 {
            bottom: 517px;
            left: 385px;
        }

        .claim-DxCode4 {
            bottom: 517px;
            left: 550px;
        }

        .claim-DxCode5 {
            bottom: 497px;
            left: 53px;
        }

        .claim-DxCode6 {
            bottom: 497px;
            left: 218px;
        }

        .claim-DxCode7 {
            bottom: 497px;
            left: 385px;
        }

        .claim-DxCode8 {
            bottom: 497px;
            left: 550px;
        }

        .service-locationInformation {
            bottom: 68px;
            left: 319px;
            width: 270px;
        }

        .service-location-NPI {
            bottom: 27px;
            left: 345px;
        }

        .physician-sig {
            bottom: 3px;
            left: 78px;
            width: 138px;
            height: 32px;
        }

        .physician-sig-date {
            bottom: 22px;
            left: 253px;
        }

        .physician-sig-date2 {
            left: 485px;
            margin-top: -712px;
        }
    </style>

    <script type="text/javascript">
        function printCMSForm() {

            var url = window.location.href.slice(window.location.href.indexOf('?') + 1);
            var url2 = window.location.href.slice(window.location.href.indexOf('&') + 1).split('&')[0];
            var PatientId = url2.split("=")[1];

            var claimid = $("[id$='lblPatientId']").text();
            $.post("../Claims/CallBacks/SaveClaimHandler.aspx", { ClaimId: claimid, PatientId: PatientId, Action: "PaperClaim" });
            $("#btnPrintCMSForm").hide();
            window.print();

            //$("#btnPrintCMSForm").show();
        }

        $(document).ready(function () {
            debugger;
            var ServiceDateMM, ServiceDateDD, ServiceDateYY, POS, Code, EPSDT, ServiceUnits, Modifier1, Modifier2, Modifier3, Modifier4, TotalCharges, ProviderNPI, TotalFee = 0.00, isTenComplete, ServiceRowHtml;

            for (var i = 0; i < _arrClaimsServices.length; i++) {
                ServiceDateMM = _arrClaimsServices[i].ServiceDateMM;
                ServiceDateDD = _arrClaimsServices[i].ServiceDateDD;
                ServiceDateYY = _arrClaimsServices[i].ServiceDateYY;
                POS = _arrClaimsServices[i].POS;
                Code = _arrClaimsServices[i].Code;
                EPSDT = _arrClaimsServices[i].EPSDT;
                ServiceUnits = _arrClaimsServices[i].ServiceUnits;
                Pointers = _arrClaimsServices[i].Pointers;
                Modifier1 = _arrClaimsServices[i].Modifier1;
                Modifier2 = _arrClaimsServices[i].Modifier2;
                Modifier3 = _arrClaimsServices[i].Modifier3;
                Modifier4 = _arrClaimsServices[i].Modifier4;
                TotalCharges = _arrClaimsServices[i].TotalCharges;
                ProviderNPI = _arrClaimsServices[i].ProviderNPI;
                ServiceRowHtml = '' +
                '<tr>' +
                    '<td style="width: 90px;">' +
                        '<span class="bold" style=" margin-right: 20px;padding-left:7px; ">' +
                            ServiceDateMM +
                        '</span>' +
                        '<span class="bold" style=" margin-right: 19px; ">' +
                            ServiceDateDD +
                        '</span>' +
                        '<span class="bold">' +
                            ServiceDateYY +
                        '</span>' +
                    '</td>' +
                    '<td style="width: 92px;">' +
                        '<span class="bold" style=" margin-right: 20px;padding-left:7px; ">' +
                            ServiceDateMM +
                        '</span>' +
                        '<span class="bold" style=" margin-right: 25px; ">' +
                            ServiceDateDD +
                        '</span>' +
                        '<span class="bold">' +
                            ServiceDateYY +
                        '</span>' +
                    '</td>' +
                    '<td style="width:33px;text-align: center;">' +
                        '<span class="bold">' +
                            POS +
                        '</span>' +
                    '</td>' +
                    '<td style="width:30px">' +
                        '<span class="bold">' +
                        '</span>' +
                    '</td>' +
                    '<td style="width: 75px;">' +
                        '<span class="bold">' +
                            Code +
                        '</span>' +
                    '</td>' +
                    '<td style=" width: 33px; ">' +
                        '<span class="bold">' +
                            Modifier1 +
                        '</span>' +
                    '</td>' +
                    '<td style=" width: 32px; ">' +
                        '<span class="bold">' +
                            Modifier2 +
                        '</span>' +
                    '</td>' +
                    '<td style=" width: 32px; ">' +
                        '<span class="bold">' +
                            Modifier3 +
                        '</span>' +
                    '</td>' +
                    '<td style=" width: 33px; ">' +
                        '<span class="bold">' +
                            Modifier4 +
                        '</span>' +
                    '</td>' +
                    '<td style=" width: 46px; ">' +
                        '<span class="bold">' +
                            Pointers +
                        '</span>' +
                    '</td>' +
                    '<td style="width: 91px;position:relative">' +
                        '<span class="bold" style="position: absolute;right: 74px;top: 19px;" class="TotalCharges">' +
                            TotalCharges.split(".")[0] +
                        '</span>' +
                        '<span class="bold" style="position: absolute;right: 17px;top: 19px;" class="TotalCharges">' +
                            TotalCharges.split(".")[1] +
                        '</span>' +
                    '</td>' +
                    '<td style="width: 43px;text-align:center">' +
                        '<span class="bold" class="ServiceUnits">' +
                            ServiceUnits +
                        '</span>' +
                    '</td>' +
                    '<td style="width:18px">' +
                        '<span class="bold">' +
                            EPSDT +
                        '</span>' +
                    '</td>' +
                    '<td style="width:30px">' +
                        '<span class="bold">' +
                        '</span>' +
                    '</td>' +
                    '<td style="width:125px">' +
                        '<span class="bold">' +
                            ProviderNPI +
                        '</span>' +
                    '</td>' +
                '</tr>';
                isTenComplete = i % 6
                if (isTenComplete == 0 && i > 0) {
                    var divCMS = $("#divCMS").clone();

                    $(divCMS).find("tbody.tbodyClaimService").html("");
                    divCMS.find(".claim-total-fee").html("");

                    $(divCMS).find("tbody.tbodyClaimService").append(ServiceRowHtml);
                    divCMS.find(".claim-total-fee").html(TotalCharges);
                    $("#divCMSContainer").append(divCMS);
                }

                else if (i > 6) {
                    $(divCMS).find("tbody.tbodyClaimService").append(ServiceRowHtml);

                    //TotalCharges = (parseFloat(TotalCharges) * parseFloat(ServiceUnits)) + parseFloat($.trim(divCMS.find(".claim-total-fee").html()));
                    TotalCharges = (parseFloat(TotalCharges)) + parseFloat($.trim(divCMS.find(".claim-total-fee").html()));
                    divCMS.find(".claim-total-fee").html(TotalCharges);
                }
                else if (i < 6) {
                    if (ServiceUnits == "") {
                        ServiceUnits = 0.00;
                    }
                    //TotalFee = parseFloat(TotalFee) + (parseFloat(TotalCharges) * parseFloat(ServiceUnits));
                    TotalFee = parseFloat(TotalFee) + (parseFloat(TotalCharges));

                    $("tbody.tbodyClaimService").append(ServiceRowHtml);

                    $(".claim-total-fee").html(TotalFee.toFixed(2));
                }
            }

        });
    </script>

</head>
<body style="overflow-y: scroll;">
    <form id="form1" runat="server">
        <div style="width: 874px; margin: 15px auto; text-align: right;">
            <input type="button" value="Print" id="btnPrintCMSForm" onclick="printCMSForm();" />
        </div>
        <div id="divCMSContainer">
            <div id="divCMS" class="cms-form">
                <asp:Image ID="imgCMSBG" runat="server" ImageUrl="~/Images/CMS-1500.png" />
                <div class="absolute insurance-company">
                    <asp:Label ID="lblPrimaryInsurance" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute insurance-number">
                    <asp:Label ID="lblPrimaryPolicyNumber" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-other-coverage">
                    <asp:Label ID="lblOtherInsuranceSubscriberName" runat="server" CssClass="bold" Text=""></asp:Label><br />
                </div>
                <div class="absolute policy-holder-other-coverage-group">
                    <asp:Label ID="lblOtherInsuranceSubscriberGroupNumber" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>

                <div class="absolute patient-information-relationship-self">
                    <asp:Label ID="lblPatientRelationshipToSubscriberSelf" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-relationship-spouse">
                    <asp:Label ID="lblPatientRelationshipToSubscriberSpouse" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-relationship-dependent">
                    <asp:Label ID="lblPatientRelationshipToSubscriberDependentChild" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-relationship-other">
                    <asp:Label ID="lblPatientRelationshipToSubscriberOther" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-condition-employment-yes">
                    <asp:Label ID="lblEmploymentYes" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-condition-employment-no">
                    <asp:Label ID="lblEmploymentNo" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-condition-autoAccident-yes">
                    <asp:Label ID="lblAutoAccidentYes" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-condition-autoAccident-no">
                    <asp:Label ID="lblAutoAccidentNo" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-condition-autoAccident-State">
                    <asp:Label ID="lblAutoAccidentState" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-condition-otherAccident-yes">
                    <asp:Label ID="lblOtherAccidentYes" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-condition-otherAccident-no">
                    <asp:Label ID="lblOtherAccidentNo" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder">
                    <asp:Label ID="lblInsuranceSubscriberName" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>

                <div class="absolute policy-holder-address">
                    <asp:Label ID="lblInsuranceSubscriberAddress" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-city">
                    <asp:Label ID="lblInsuranceSubscriberCity" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-state">
                    <asp:Label ID="lblInsuranceSubscriberState" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-zip">
                    <asp:Label ID="lblInsuranceSubscriberZip" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-phone-areaCode">
                    <asp:Label ID="lblInsuranceSubscriberAreaCode" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-phone">
                    <asp:Label ID="lblInsuranceSubscriberPhone" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-dob-dd">
                    <asp:Label ID="lblInsuranceSubscriberDOBdd" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-dob-mm">
                    <asp:Label ID="lblInsuranceSubscriberDOBmm" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-dob-yy">
                    <asp:Label ID="lblInsuranceSubscriberDOByy" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-gender-M">
                    <asp:Label ID="lblInsuranceSubscriberGenderM" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-gender-F">
                    <asp:Label ID="lblInsuranceSubscriberGenderF" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute policy-holder-group">
                    <asp:Label ID="lblInsuranceSubscriberGroupNumber" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute pri-insurance-plan">
                    <asp:Label ID="lblPriInsurancePlanName" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute other-insurance-plan-yes">
                    <asp:Label ID="lblIsOtherInsurancePlanYes" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute other-insurance-plan-no">
                    <asp:Label ID="lblIsOtherInsurancePlanNo" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute other-insurance-plan">
                    <asp:Label ID="lblOtherInsurancePlan" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute resubmission-code">
                    <asp:Label ID="lblResubmissionCode" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute ref-no">
                    <asp:Label ID="lblRefNo" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <%--<div class="absolute insurance-company-other-coverage">
                    <asp:Label ID="lblOtherInsuranceCompanyName" runat="server" CssClass="bold" Text=""></asp:Label>
                    <asp:Label ID="lblOtherInsuranceCompanyAddress" runat="server" CssClass="bold" Text=""></asp:Label>
                    <asp:Label ID="lblOtherInsuranceCompanyCity" runat="server" CssClass="bold" Text=""></asp:Label>
                    <asp:Label ID="lblOtherInsuranceCompanyState" runat="server" CssClass="bold" Text=""></asp:Label>
                    <asp:Label ID="lblOtherInsuranceCompanyZip" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>--%>
                <div class="absolute patient-signature">
                    <asp:Label ID="lblPatientSignature" runat="server" CssClass="bold" Text="Signature On File"></asp:Label>
                </div>
                <div class="absolute insured-signature">
                    <asp:Label ID="lblInsuredSignature" runat="server" CssClass="bold" Text="Signature On File"></asp:Label>
                </div>

                <div class="absolute patient-information">
                    <asp:Label ID="lblPatientName" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-address">
                    <asp:Label ID="lblPatientAddress" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-city">
                    <asp:Label ID="lblPatientCity" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-state">
                    <asp:Label ID="lblPatientState" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-zip">
                    <asp:Label ID="lblPatientZip" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-dob-dd">
                    <asp:Label ID="lblPatientDOBdd" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-dob-mm">
                    <asp:Label ID="lblPatientDOBmm" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-dob-yy">
                    <asp:Label ID="lblPatientDOByy" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-gender-M">
                    <asp:Label ID="lblPatientGenderM" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-gender-F">
                    <asp:Label ID="lblPatientGenderF" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-phone-areaCode">
                    <asp:Label ID="lblPhoneAreaCode" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-phone">
                    <asp:Label ID="lblPhoneNumber" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>

                <div class="absolute patient-information-single">
                    <asp:Label ID="lblPatientMaritalStatusSignle" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>

                <div class="absolute patient-information-otherStatus">
                    <asp:Label ID="lblPatientMaritalStatusOther" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-claimid">
                    <asp:Label ID="lblClaimId" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute practice-taxId">
                    <asp:Label ID="lblPracticeTaxId" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute practice-taxId-CheckBox">
                    <asp:Label ID="lblTaxIdCheckBox" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-PatientId">
                    <asp:Label ID="lblPatientId" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-information-AcceptAssignment">
                    <asp:Label ID="lblAcceptAssignment" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-Illness-dd">
                    <asp:Label ID="lblCurrentIllnessDD" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-Illness-mm">
                    <asp:Label ID="lblCurrentIllnessMM" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-Illness-yy">
                    <asp:Label ID="lblCurrentIllnessYY" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-Illness-QUAL">
                    <asp:Label ID="lblCurrentIllnessQual" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-other-dd">
                    <asp:Label ID="lblPatientOtherDD" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-other-mm">
                    <asp:Label ID="lblPatientOtherMM" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-other-yy">
                    <asp:Label ID="lblPatientOtherYY" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-other-QUAL">
                    <asp:Label ID="lblPatientOtherQual" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute referring-Physician-Qual">
                    <asp:Label ID="lblReferringPhysicianQual" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute referring-Physician">
                    <asp:Label ID="lblReferringPhysician" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute referring-Physician-upin-qual">
                    <asp:Label ID="lblReferringPhysicianUPINQual" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute referring-Physician-upin">
                    <asp:Label ID="lblReferringPhysicianUPIN" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute referring-Physician-npi">
                    <asp:Label ID="lblReferringPhysicianNPI" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-admissoin-dd">
                    <asp:Label ID="lblPatientAdmissionDD" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-admissoin-mm">
                    <asp:Label ID="lblPatientAdmissionMM" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-admissoin-yy">
                    <asp:Label ID="lblPatientAdmissionYY" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-discharge-dd">
                    <asp:Label ID="lblPatientDischageDD" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-discharge-mm">
                    <asp:Label ID="lblPatientDischageMM" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute patient-discharge-yy">
                    <asp:Label ID="lblPatientDischageYY" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute Additional-Information">
                    <asp:Label ID="lblAdditionalInformation" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute paNumber">
                    <asp:Label ID="lblpaNumber" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute billing-Physician-information">
                    <asp:Label ID="lblBillingPhysicianName" runat="server" CssClass="bold" Text=""></asp:Label><br />
                    <asp:Label ID="lblBillingPhysicianAddress" runat="server" CssClass="bold" Text=""></asp:Label><br />
                    <asp:Label ID="lblBillingPhysicianCity" runat="server" CssClass="bold" Text=""></asp:Label>
                    <asp:Label ID="lblBillingPhysicianState" runat="server" CssClass="bold" Text=""></asp:Label>
                    <asp:Label ID="lblBillingPhysicianZip" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute billing-Physician-information-npi">
                    <asp:Label ID="lblBillingPhysicianNPI" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute billing-Physician-information-license">
                    <asp:Label ID="lblBillingPhysicianLicense" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute billing-Physician-information-tin">
                    <asp:Label ID="lblBillingPhysicianTaxId" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute billing-Physician-information-phone-ext">
                    <asp:Label ID="lblBillingPhysicianPhoneExt" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute billing-Physician-information-phone-number">
                    <asp:Label ID="lblBillingPhysicianPhone" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <%--<div class="absolute billing-Physician-information-additional-provider-id">
                    <asp:Label ID="lblReferringPhysicianId" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>--%>

                <%--<div class="absolute treating-Physician-information-npi">
                    <asp:Label ID="lblTreatingPhysicianNPI" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute treating-Physician-information-license">
                    <asp:Label ID="lblTreatingPhysicianLicense" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute treating-Physician-information-address">
                    <asp:Label ID="lblTreatingPhysicianAddress" runat="server" CssClass="bold" Text=""></asp:Label><br />
                    <asp:Label ID="lblTreatingPhysicianCity" runat="server" CssClass="bold" Text=""></asp:Label>
                    <asp:Label ID="lblTreatingPhysicianState" runat="server" CssClass="bold" Text=""></asp:Label>
                    <asp:Label ID="lblTreatingPhysicianZip" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute treating-Physician-information-speciality-code">
                    <asp:Label ID="lblTreatingPhysicianTaxonomyCode" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute treating-Physician-information-phone-ext">
                    <asp:Label ID="lblTreatingPhysicianPhoneExt" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute treating-Physician-information-phone-number">
                    <asp:Label ID="lblTreatingPhysicianPhoneNumber" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>--%>
                <%--<div class="absolute treating-Physician-information-additional-provider-id">
                    <asp:Label ID="lblTreatingPhysicianReferringId" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>--%>
                <div class="absolute service-locationInformation">
                    <asp:Label ID="lblLocationInformation" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute service-location-NPI">
                    <asp:Label ID="lblLocationNPI" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute physician-sig">
                    <asp:Label ID="lblTreatingPhysician" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute physician-sig-date">
                    <asp:Label ID="lblTreatingPhysicianSigDate" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <div class="absolute physician-sig-date2">
                    <asp:Label ID="lblTreatingPhysicianSigDate2" runat="server" CssClass="bold" Text=""></asp:Label>
                </div>
                <span class="absolute  claim-DxCode">9</span>
                <asp:Label ID="lblDxCode1" runat="server" CssClass="absolute bold claim-DxCode1" Text=""></asp:Label>
                <asp:Label ID="lblDxCode2" runat="server" CssClass="absolute bold claim-DxCode2" Text=""></asp:Label>
                <asp:Label ID="lblDxCode3" runat="server" CssClass="absolute bold claim-DxCode3" Text=""></asp:Label>
                <asp:Label ID="lblDxCode4" runat="server" CssClass="absolute bold claim-DxCode4" Text=""></asp:Label>
                <asp:Label ID="lblDxCode5" runat="server" CssClass="absolute bold claim-DxCode5" Text=""></asp:Label>
                <asp:Label ID="lblDxCode6" runat="server" CssClass="absolute bold claim-DxCode6" Text=""></asp:Label>
                <asp:Label ID="lblDxCode7" runat="server" CssClass="absolute bold claim-DxCode7" Text=""></asp:Label>
                <asp:Label ID="lblDxCode8" runat="server" CssClass="absolute bold claim-DxCode8" Text=""></asp:Label>

                <span class="absolute  claim-total-fee"></span>
                <div class="absolute  TotalCharges">
                    <asp:Label ID="lblPatientTotalCharges" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                <div class="absolute  TotalCharges1">
                    <asp:Label ID="lblPatientTotalCharges1" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                <div class="absolute  AmmountPaid">
                    <asp:Label ID="lblPatientPaidAmmount" runat="server" Text=""></asp:Label>
                </div>
                <div class="absolute  AmmountPaid1">
                    <asp:Label ID="lblPatientPaidAmmount1" runat="server" Text=""></asp:Label>
                </div>
                <div class="absolute claim-services">
                    <table>
                        <tbody class="tbodyClaimService">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <asp:Literal ID="ltrClaimServices" runat="server"></asp:Literal>
    </form>
</body>
</html>
