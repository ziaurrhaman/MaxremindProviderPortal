<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" EnableViewState="false" EnableSessionState="true" CodeFile="BillingManager.aspx.cs" Inherits="EMR_Claims_BillingManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" />
    <script src="js/BillingManager.js"></script>
    <script src="../../Scripts/tableHeadFixer.js"></script>
    <script type="text/javascript">
        var ClaimIds = "";

        function ExportToEcxel() {
            $(".clsPrint").css("dislay", "none");
            window.open('data:application/vnd.ms-excel,' + $('#ClaimsList').html());
            e.preventDefault();

        }
        function SetSearch(event) {
            debugger;
            var a = event.which || event.keyCode;
            if (a == 13) {
                if ($("#FilterIcon").hasClass("active")) {
                    FilterClaims(0, true);
                    $("#FilterIcon").css("color", "#065172");
                }
            }
            else {
                $("#FilterIcon").addClass("active");
                $("#FilterIcon").css("color", "red");
            }

        }
        function rdoClaims_Change() {
            FilterClaims(0, true);

        }
        function CheckAllCheckBoxs() {
            debugger;
            var $allCheckbox = $('.allCheckbox :checkbox');
            var $checkboxes = $('.singleCheckbox :checkbox');
            $allCheckbox.change(function () {
                if ($allCheckbox.is(':checked')) {
                    $checkboxes.attr('checked', 'checked');
                }
                else {
                    $checkboxes.removeAttr('checked');
                }
            });
            $checkboxes.change(function () {
                if ($checkboxes.not(':checked').length) {
                    $allCheckbox.removeAttr('checked');
                }
                else {
                    $allCheckbox.attr('checked', 'checked');
                }
            });
        }

        /**** Add changes by Daniyal_Baig 10Aug2018 ****/
        var _IsPatientIdValidated = true;
        function claimIdKeyPress(evt) {
            _IsPatientIdValidated = true;
            var isValidate = ValidateOnlyNumber(evt);
            if (!isValidate) {
                _IsPatientIdValidated = false;
            }

            return _IsPatientIdValidated;
        }//End Daniyal_Baig


        function GetClaimIds() {
            //debugger;
            var AllClaimIds = "";
            ClaimIds = "";

            $(".clsContainer").each(function () {

                if ($(this).is(":checked")) {
                    ClaimIds += $(this).val() + ",";
                }

            })
            if (ClaimIds == "") {
                $("#dialog").dialog({
                    title: "Alert !!!",
                    modal: true,
                    draggable: false,
                    resizable: false,
                    show: 'blind',
                    hide: 'blind',
                    width: 400,
                    dialogClass: 'ui-dialog-osx',
                    open: function (event, ui) {
                        $(".ui-dialog-titlebar-close").text("");
                    },
                    buttons: {
                        "Close": function () {
                            $(this).dialog("close");
                        }
                    }
                });
                return;
            }


            $("[id$='hdnClaimIds']").val(ClaimIds);
        }


    </script>


    <style>
        .message {
            float: none !important;
        }

        /* .container {
            overflow-y: hidden !important;
        }

        .Grid {
            overflow-y: auto;
            max-height: 70vh;
            overflow-x: hidden;
        }*/

        .ui-widget-content {
            padding-right: 0px !important;
        }

        div#divBillingManagerContent table tr th {
            position: sticky;
            top: 0;
        }

        div#divBillingManagerContent table thead {
            position: sticky;
            top: 0;
        }

        .divBilling_Claims {
            max-height: 430px;
            overflow-y: scroll;
        }

        .reportdropdown:after {
            top: 0px;
        }

        label.lbltexthere:after {
            border: solid #242424;
            border-width: 0 2px 2px 0;
            display: inline-block;
            padding: 3px;
            transform: rotate(45deg);
            -webkit-transform: rotate(45deg);
            content: '';
            top: 10px;
            position: absolute;
            right: 6px;
            z-index: 1;
            right: 14px;
        }

        .divBilling_Claims {
            max-height: 430px;
            overflow-y: scroll;
            min-height: 430px;
        }

        .reportdropdown:after {
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdnClaimIds" runat="server" />
    <div class="page-content">
        <div id="divClaimAll" class="billing-manager-main-divs" runat="server">
            <div>
                <!--<div>
                    <span class="widget-claims-icon"></span>Claims
                </div>-->
                <%--   <h1 class="pagetitle">Claims</h1>--%>

                <div>
                    <div style="width: 100%; float: left; margin: 0 0 8px 0px;">

                        <div style="width: 50%; float: left; position: relative;">
                            <div class="" style="width: 100%; float: left;">
                                <span style="padding-right: 10px; float: left; font-weight: bold;">Locations:</span>
                                <span>
                                    <label class="lbltextherePL" style="text-align: left; box-sizing: border-box; padding-top: 6px; float: left; width: 50%; height: 25px; background-color: white; margin-left: 0%; border: 1px solid #ccc; border-radius: 2px; padding-left: 5px;" onclick="LoadLocationList()"></label>
                                    <input type="hidden" class="hdnLocationName" />
                                    <input type="hidden" class="hdnLocationsId" />
                                    <asp:HiddenField ID="hdnLocationIds" runat="server" />
                                    <span <%--class="arrowdown"--%> onclick="LoadLocationList()" style="margin-left: -24px !important; margin-top: 2px; position: relative;">
                                        <img src="../../Images/down-arrow-iconBlack.jpg" width="20px" height="20px" /></span>
                                    <div id="LoadLocationListDiv" style="z-index: 99; display: none; position: absolute; width: 100%; margin-top: 5px; overflow-y: auto; border: 1px solid grey; box-shadow: 1px 2px #d6d6d6; margin-left: 62px; overflow: unset;" class="Grid">
                                        <ul>

                                            <li>
                                                <div id="divLoadLocationList" style="max-height: 300px; min-height: 50px; overflow-y: auto; border: 2px solid #ccc;">
                                                    <table>
                                                        <thead>
                                                            <tr>
                                                                <th class="allCheckboxPL" style="text-align: center;">
                                                                    <input type="checkbox" id="chkBoxALL" onclick="Check_AllCheckBoxs();" />
                                                                </th>
                                                                <th style="text-align: center;">Location Name</th>
                                                                <th style="text-align: center;">Type</th>
                                                                <th style="text-align: center;">Total Claim</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody class="tbodyLocationList" id="tbodyLocationList">
                                                            <asp:Repeater runat="server" ID="rptLocation">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td class="singleCheckboxPL">
                                                                            <input type="checkbox" id="chkBox" class="ChkBox" /></td>
                                                                        <td style="cursor: pointer; font-size: 12px; font-weight: 300; color: black; text-align: left;" class="InsuranceName"><%#Eval("LocationName") %></td>
                                                                        <td style="display: none">
                                                                            <input type="hidden" class="hdnPracticeLocationsId" value="<%#Eval("PracticeLocationsId") %>" />
                                                                            <input type="hidden" class="hdnName" value="<%#Eval("LocationName") %>" />
                                                                        </td>
                                                                        <td><%#Eval("PlaceOfService") %></td>
                                                                        <td><%#Eval("TotalClaim") %></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </li>
                                            <li style="text-align: left; margin-top: 12px; padding-bottom: 17px; border-bottom: 1px solid #ccc; padding-left: 9px; background-color: white; margin-top: 0px; height: 10px;">
                                                <span style="float: right; width: 50px; border: 1px solid; text-align: center; border-radius: 6px; height: 22px; line-height: 22px; margin-top: 3px; cursor: pointer; margin-right: 10px;" onclick="closeddlLocation()">Cancel</span>
                                                <span style="float: right; width: 40px; border: 1px solid; text-align: center; border-radius: 6px; height: 22px; line-height: 22px; margin: 3px 6px 0px 1px; cursor: pointer;" onclick="SearchLocation()">Ok</span>
                                            </li>
                                        </ul>
                                    </div>
                                </span>
                                <span id="spnClaimSection" runat="server">

                                    <input id="rdoAllCliams" onchange="rdoClaims_Change()" name="rdoClaim" type="radio" checked="checked" />All Claims
                                 <input id="rdoRPMClaims" onchange="rdoClaims_Change()" name="rdoClaim" type="radio" />RPM Claims
                                </span>
                            </div>
                        </div>
                        <div style="width: 50%; float: left">
                            <%-- added by sahhid akzmi 1/22/2018--%>
                            <div id="divExportTo" style="float: right; margin-right: 0.5%;">
                                <span style="float: left; font-weight: bold; margin-top: 6%">Export:</span>
                                <span style="float: right; width: 62%; margin-right: -3%;" onclick="GetClaimIds();">
                                    <asp:DropDownList ID="ddlExportTo" runat="server" OnSelectedIndexChanged="ddlExportTo_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                        <%--<asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>--%>
                                        <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                    </asp:DropDownList>
                                </span>
                            </div>
                            <%--end shahid kazmi 1/22/2018--%>
                        </div>
                    </div>
                    <div id="divBillingManagerContent" class="margin_top">
                        <div id="divClaims">
                            <div class="Grid" style="overflow-y: auto">
                                <div class="divBilling_Claims">
                                    <table style="width: 100%;" id="tblClaim" class="fixTable ">
                                        <thead>
                                            <tr>
                                                <th style="width: 2%;">#
                                                
                                                </th>
                                                <th style="width: 2%;" class="allCheckbox">
                                                    <input type="checkbox" id="allCheckbox1" class="chkHeader" runat="server" onclick="CheckAllCheckBoxs();" />
                                                </th>
                                                <th style="width: 5%;" onclick="sortedbyAscDesc(this,'Claim No')">Claim No
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="width: 5%" onclick="sortedbyAscDesc(this,'Account No')">Account No
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="width: 10%" onclick="sortedbyAscDesc(this,'Patient Name')">Patient Name
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="width: 6%" onclick="sortedbyAscDesc(this,'DOS')">DOS
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="width: 6%" onclick="sortedbyAscDesc(this,'Bill Date')">Bill Date
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="" onclick="sortedbyAscDesc(this,'Location')">Location
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="width: 10%;" onclick="sortedbyAscDesc(this,'Provider')">Attending Physician
                                                                <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="" onclick="sortedbyAscDesc(this,'Insurance')">Primary Insurance
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="width: 12%" onclick="sortedbyAscDesc(this,'Status')">Primary Status
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <%--added by shahi kazmi 1/22/2018--%>
                                                <th style="width: 5%;" onclick="sortedbyAscDesc(this,'AmountPaid')">Paid Amount
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="width: 5%;" onclick="sortedbyAscDesc(this,'AmountDue')">Balance Due
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <th style="width: 5%;" onclick="sortedbyAscDesc(this,'Charges')">Charges
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                                    <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                                    <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                                </th>
                                                <%--end shahid kazmi 1/22/2018--%>
                                                <th style="width: 4%;">Action</th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <%--<span class="iconSearch"></span>--%>
                                                    <!-- Add changes by Daniyal_Baig 10Aug2018 -->
                                                    <i class="fa fa-filter" style="color: #065172; font-size: 20px !important;" id="FilterIcon" onclick="FilterClaims(0, true)"></i>

                                                </th>
                                                <th></th>
                                                <th>
                                                    <input type="text" id="txtClaimNo" onkeyup="SetSearch(event)" onkeypress="return claimIdKeyPress(event);" />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtPatientAccount" onkeyup="SetSearch(event)" onkeypress="return claimIdKeyPress(event);" />
                                                </th>
                                                <!-- End Daniyal_Baig-->
                                                <th>
                                                    <input type="text" id="txtPatientName" onkeyup="SetSearch(event)" />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtDateOfService" class="ServiceDate" onkeyup="SetSearch(event)" />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtBillDate" class="BillDate" onkeyup="SetSearch(event)" />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtLocation" class="BillDate" onkeyup="SetSearch(event)" />
                                                </th>
                                                <%--/// Modified By Irfan Mahmood 9/August/2022 : Add Provider Filter--%>

                                                <th>
                                                    <div class="col-lg-4 CustomReportServiceProvider" style="text-align: left; box-sizing: border-box; padding-top: 6px; float: left; width: 99%; height: 25px; background-color: white; margin-left: 0%; border: 1px solid #ccc; border-radius: 2px; padding-left: 5px;">
                                                        <div id="divReportServiceProvider">
                                                            <div class="divBranchName" style="">
                                                                <%--             <span class="spnBranchName" style="">Provider :</span>--%>
                                                                <div class="BranceInput">
                                                                    <div class="reportdropdown" style="">
                                                                        <a onclick="ShowMenuFilters('divServiceProvider',this);">
                                                                            <div class="selectedText">
                                                                            </div>
                                                                            <div class="dropDownIcon" style="width: 8.5%; position: absolute; top: 3px; right: 0;">
                                                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                                                            </div>
                                                                        </a>
                                                                        <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; background-color: white; width: 200px; height: 250px; border: 1px solid #ccc; overflow-y: auto; height: 255px; border: 1px solid rgb(204, 204, 204); box-shadow: rgb(214, 214, 214) 1px 2px;">
                                                                            <div class="ddlselect" style="background-color: white; width: 200px; overflow-y: auto; height: 197px; border: 1px solid rgb(204, 204, 204); box-shadow: rgb(214, 214, 214) 1px 2px;">
                                                                                <span class="drop-closebtn" onclick="CloseProviderDiv()" style="margin-top: 4px; position: absolute; margin-left: 175px;">x</span>
                                                                                <ul id="ulMultiServiceProvider">
                                                                                    <li style="/*float: left; */ width: 100%; border-bottom: 1px solid #d5cfcf;">
                                                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                                                            <input type="checkbox" id="chkServiceProviderAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                                                            <span>All Providers</span>
                                                                                            <input type="hidden" value="0" />
                                                                                        </label>
                                                                                    </li>
                                                                                    <asp:Repeater runat="server" ID="rptProviders">
                                                                                        <ItemTemplate>
                                                                                            <li style="float: left; width: 100%; border-bottom: 1px solid #d5cfcf;">
                                                                                                <label name='<%#Eval("PracticeStaffId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                                                    <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" onclick="SelectProviderName(this)" value='<%#Eval("StaffNPI") %>' />
                                                                                                    <span><%#Eval("StaffName") %></span>
                                                                                                    <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="PracticeStaffId" />
                                                                                                </label>
                                                                                            </li>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </ul>

                                                                            </div>
                                                                            <div style="text-align: center; margin-top: 5px">

                                                                                <span onclick="FilterClaims(0, true)" style="font-size: 14px; display: inline-block; background-color: #a1daff; border-radius: 5px; padding: 6px 28px; background-color: #006ebd; height: 30px; color: white">Ok</span>
                                                                                <span onclick="CancelProviders(this)" style="font-size: 14px; display: inline-block; background-color: #a1daff; border-radius: 5px; padding: 6px 28px; background-color: #006ebd; height: 30px; color: white">Cancel</span>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <asp:HiddenField ID="hdnProviderId" runat="server" />
                                                    </div>
                                                </th>
                                                <%--///End  Modified By Irfan Mahmood 9/August/2022 : Add Provider Filter--%>

                                                <th style="position: relative;">


                                                    <label class="lbltexthere" style="text-align: left; box-sizing: border-box; padding-top: 6px; float: left; width: 99%; height: 25px; background-color: white; margin-left: 0%; border: 1px solid #ccc; border-radius: 2px; padding-left: 5px;" onclick="LoadInsuranceList()"></label>
                                                    <%--<span class="arrowdown" onclick="LoadInsuranceList()">
                                                    <img src="../../Images/down-arrow-iconBlack.jpg" width="20px" height="20px" /></span>--%>
                                                    <div id="LoadInsuranceListDiv" style="margin-top: 2%; z-index: 1; display: none; position: absolute; width: 105%; margin-top: 25px; overflow-y: auto; height: 255px; border: 1px solid #ccc; box-shadow: 1px 2px #d6d6d6;" class="Grid">
                                                    </div>
                                                </th>
                                                <th>
                                                    <asp:DropDownList ID="ddlSubmissionStatus" runat="server" CssClass="select" Style="float: none; width: 100%;" onchange="RowsChange('FilterClaims');"></asp:DropDownList>
                                                </th>
                                                <%--added by shahid kazmi 1/22/2018--%>
                                                <th>
                                                    <input type="text" id="txtPaidAmount" onkeyup="SetSearch(event)" style="" />
                                                </th>
                                                <th>
                                                    <input type="text" id="txtAmountDue" onkeyup="SetSearch(event)" style="" />
                                                </th>
                                                <%--end shahid kazmi 1/22/2018--%>
                                                <th>
                                                    <input type="text" id="txtCharges" onkeyup="SetSearch(event)" style="" />
                                                </th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody id="ClaimsList">
                                            <asp:Repeater ID="rptClaims" runat="server"
                                                OnItemDataBound="rptClaims_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr <%--onclick="ClaimOpenForView(<%# Eval("ClaimId")%>,<%# Eval("PatientId")%>)"--%> <%--style="cursor: pointer;"--%>>
                                                        <td>
                                                            <i><%# Eval("ROWNUMBER")%></i>
                                                        </td>
                                                        <td class="singleCheckbox" id="tdchk" runat="server">
                                                            <input type="checkbox" class="clsContainer" value='<%# Eval("ClaimId") %>' />
                                                        </td>
                                                        <td>
                                                            <%-- claim-center is in common.css --%>
                                                            <span class="claim-center"><%# Eval("ClaimId")%></span>
                                                            <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                                                            <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                                                            <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                                                            <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                                                        </td>
                                                        <td style="cursor: pointer;" class="txtalign-cntr">
                                                            <%# Eval("PatientId")%>
                                                        </td>
                                                        <td style="cursor: pointer;">
                                                            <%# Eval("PatientName")%>
                                                        </td>
                                                        <td style="text-align: center; cursor: pointer;">
                                                            <%# Eval("ServiceDate", "{0:d}")%>
                                                        </td>
                                                        <td style="text-align: center;" style="cursor: pointer;">
                                                            <%# Eval("BillDate")%>
                                                        </td>
                                                        <td class="txtalign-left" style="cursor: pointer;">
                                                            <%# Eval("Location")%>
                                                        </td>
                                                        <%--/// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column--%>

                                                        <td>
                                                            <%# Eval("Provider")%>

                                                        </td>
                                                        <%--/// End Modified By Irfan Mahmood 9/August/2022 : Add Provider Column--%>

                                                        <td style="cursor: pointer;">
                                                            <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="white-space: nowrap; cursor: pointer;">
                                                            <%-- <%# Eval("InsuranceStatus")%>--%>
                                                            <asp:Label runat="server" ID="lblstatus" />
                                                        </td>
                                                        <%--added by shahid kazmi 1/22/2018--%>
                                                        <td style="white-space: nowrap; cursor: pointer; text-align: right;">
                                                            <%# Eval("AmountPaid","{0:c}")%>
                                                        </td>
                                                        <td style="white-space: nowrap; cursor: pointer; text-align: right">
                                                            <%# Eval("AmountDue","{0:c}")%>
                                                        </td>
                                                        <%-- end shahid kazmi 1/22/2018--%>


                                                        <%--  //Rizwan kharal 3April2018--%>
                                                        <%--Added by Khayyam adeel Added charges in table--%>
                                                        <td>
                                                            <%# Eval("ClaimTotal","{0:c}")%>
                                                        </td>
                                                        <%--  //End of change--%>
                                                        <td align="center" class="clsPrint" id="tdPrint" runat="server">
                                                            <a title="View" onclick="ClaimOpenForView(<%# Eval("ClaimId")%>,<%# Eval("PatientId")%>,'<%# Eval("SubmissionStatus")%>')">
                                                                <img src="../../Images/view1.png" />
                                                            </a>
                                                            <a href="javascript:void(0);" onclick="printClaim(this);" title="Print Claim">
                                                                <img src="../../Images/invoice.png" />
                                                            </a>
                                                        </td>


                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>

                                </div>

                                <div class="table-footer">
                                    <div class="message">
                                        <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                                    </div>
                                    <div class="pager">
                                        <div class="PageEntries">
                                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                                <select id="ddlPagingClaims" style="margin-top: 5px;" onchange="RowsChange('FilterClaims');">
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
                                <asp:HiddenField ID="hdnRows" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <script src="js/Claim.js" type="text/javascript"></script>
                <div id="divPopup" title="Patient Search"></div>
            </div>
        </div>
        <div id="divCreatClaimContent" style="display: none;" class="billing-manager-main-divs">
            <div class="Widget">
                <div class="WidgetTitle" style="position: relative;">
                    <span class="widget-claims-create-icon"></span>
                    <span id="spanHeadingClaimForm" style="color: #fff;">Create Claim
                    </span>
                    <span id="spanClaimNumberLabel" class="span-claim-heading" style="display: none; color: #fff;">Claim Number:
                    </span>
                    <span id="spanClaimNumberClaimForm" class="span-claim-heading" style="display: none; color: #fff;"></span>


                    <input type="text" placeholder="Search Claim" onkeyup="SearchClaimsFromClaimForm(this);" style="position: absolute; top: 10px; right: 10px; width: 100px; padding: 5px;" />
                    <div id="divAllClaimsDropDown" style="display: none; position: absolute; top: 37px; right: 9px; width: 180px; height: 200px; overflow-y: auto; background: #fff; border: 1px solid lightgray;">
                        <div class="Grid" style="width: 98%;">
                            <table>
                                <thead>
                                    <tr>
                                        <th>Claim Number
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="tbodyAllClaimsDropDown"></tbody>
                            </table>
                        </div>
                    </div>


                    <span onclick="ShowPatientAllClaims();" style="position: absolute; top: 15px; left: 200px; color: #fff; text-decoration: underline; cursor: pointer;">Patient All Claims</span>
                    <div id="divPatientAllClaimsDropDown" style="display: none; position: absolute; top: 32px; left: 200px; width: 350px; height: 200px; overflow-y: auto; background: #fff; border: 1px solid lightgray;">
                        <div class="Grid" style="width: 99%;">
                            <table>
                                <thead>
                                    <tr>
                                        <th style="width: 150px;">Claim Number
                                        </th>
                                        <th>DOS
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="tbodyPatientAllClaimsDropDown"></tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="WidgetMainContent"></div>
            </div>
        </div>
        <div id="divClaimsSubmissionContent" style="display: none;" class="billing-manager-main-divs">
            <div class="Widget">
                <div class="WidgetTitle">
                    <span class="widget-claim-submission-icon"></span>Claims Submission
                </div>
                <div class="WidgetMainContent"></div>
            </div>
        </div>
        <div id="divClaimsPostPayments" style="display: none;" class="billing-manager-main-divs"></div>
    </div>
    <div id="divDialogPrintCMSForm" style="display: none;">
        <div>
            <div style="float: left; width: 100%;">
                <label>
                    <input type="radio" name="rbPrintDialogCMSForm" id="rbPrintBlankCMS" checked="checked" />
                    <span>Print on a blank CMS1500 form</span>
                </label>
                <br />
                <label>
                    <input type="radio" name="rbPrintDialogCMSForm" id="rbPrintPrintedCMS" />
                    <span>Print on a pre-printed CMS1500 form</span>
                </label>
            </div>
            <div style="float: left; width: 100%; text-align: right; margin: 20px 0 0; height: 38px;">
                <a href="javascript:void(0);" target="_blank" class="themeButton" onclick="openCMSPrintPreview();" style="padding: 5px 25px;">Ok</a>
                <a href="javascript:void(0);" class="themeButton" onclick="closeCMSDialog();" style="padding: 5px 15px;">Cancel</a>
            </div>
        </div>
    </div>
    <div id="OpenClaimForm" style="height: 500px;"></div>
    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
            var isRPM = false;
            try {
                var i = parseInt(getQueryString("RPM"));
                isRPM = (i == 1) ? true : false;
            } catch {

            }
            if (isRPM) {
                $("#rdoRPMClaims").prop("checked", true)
            }
            if (!checkModuleRights("ClaimsView")) {
                $("[id$='divRightsSettings']").html(_msg_ClaimsView).show();
                $("[id$='divClaimAll']").hide();
                return false;
            }
            $("#_claims").addClass("active");


            // FilterClaims(0, true);
        });

    </script>
    <style>
        .arrowdown {
            float: right;
            position: absolute;
            margin-left: -11%;
            margin-top: 3px;
            background-color: white;
            width: 20px;
            height: 20px;
        }
    </style>
    <div id="dialog" style="display: none;">
        <p style="font-weight: bold; color: red;">Please select atleast one claim!</p>
    </div>

</asp:Content>
