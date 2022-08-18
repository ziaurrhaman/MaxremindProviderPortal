<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="BillingManager_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <style>
        .warning {
            background: url(../../Images/warning.png) no-repeat scroll 10px center #FFD1D1;
            border: 1px solid #F8ACAC;
            border-radius: 5px;
            -moz-border-radius: 5px;
            -o-border-radius: 5px;
            -webkit-border-radius: 5px;
            color: #a94442;
            font-size: 12px;
            padding: 10px 10px 10px 33px;
        }

        .home_icon_name {
            font-size: 12px !important;
        }
    </style>
    <style id="RPMStyle" runat="server">
        .border_li {
            max-height: 26px !important;
            min-height: 36.4px !important;
            line-height: 20px !important;
        }

        .home_icon {
            margin-top: -9px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">





    <%-- Rizwan kharal --%>
    <%-- 21 Sep 2017 --%>
    <%-- margin-top to main class --%>

    <div class="main" id="main">
        <%-- div main class start--%>
        <%--<h1 class="pagetitle">Home</h1>--%>

        <div style="clear: both;"></div>

        <div class="recent-pay">
            <div class="dashboard-side-nav">
                <ul class="dashboardmenu">

                    <li class="border_li" onclick="NavigateTo('Pat')">

                        <div>
                            <div class="home_icon">
                                <span class="patients"></span>
                            </div>
                            <div class="home_icon_name" style="">
                                Patients
                            </div>

                        </div>


                    </li>

                    <li id="liRPMPatient" runat="server" class="border_li" onclick="NavigateTo('PatRPM')">

                        <div>
                            <div class="home_icon">
                                <span class="patients"></span>
                            </div>
                            <div class="home_icon_name" style="">
                                RPM Patients
                            </div>

                        </div>


                    </li>

                    <li class="border_li" onclick="NavigateTo('Claim')">

                        <div class="">
                            <div class="home_icon">
                                <span class="claims"></span>
                            </div>
                            <div class="home_icon_name" style="">
                                Claims
                            </div>

                        </div>
                    </li>

                    <li id="liRPMClaim" runat="server" class="border_li" onclick="NavigateTo('ClaimRPM')">

                        <div class="">
                            <div class="home_icon">
                                <span class="claims"></span>
                            </div>
                            <div class="home_icon_name" style="">
                                RPM Claims
                            </div>

                        </div>
                    </li>

                    <li class="border_li">

                        <div class="" onclick="NavigateTo('Pay')">
                            <div class="home_icon">
                                <span class="payers"></span>
                            </div>
                            <div class="home_icon_name" style="">
                                Payers
                            </div>

                        </div>
                    </li>
                    <li class="border_li" onclick="NavigateTo('Msg')">

                        <div class="">
                            <div class="home_icon">
                                <span class="messages"></span>
                            </div>
                            <div class="home_icon_name" style="">
                                Messages
                            </div>

                        </div>
                    </li>
                </ul>
                <div id="side_nav_div">
                    <div id="mySidenav" class="sidenav">

                        <a href="#" id="Navigation">Navigation Bar</a>

                    </div>
                </div>


            </div>
            <div class="widget-recent">

                <div class="widget" style="margin-bottom: 16px;">
                    <div class="widgettitle" style="float: left">Recent Payments</div>
                    <div class="home_navigation_icon" style="float: right; margin-top: -24px" id="payements_navigation_icon"></div>
                    <%--  <div class="" style="float:Right;margin-top: -30px; margin-right: 5px;"></div>--%>
                    <div class="widgetcontent" style="height: 222px; overflow-y: scroll;">

                        <div id="divClaimCheckParent">
                            <div class="Grid" style="height: auto !important;">
                                <div class="grid-overflow-x" style="padding: 2px 7px 0px 7px;">
                                    <table>
                                        <thead>
                                            <tr>
                                                <th style=""></th>
                                                <th style="">Check No.
                                                </th>
                                                <th style="">Check Date
                                                </th>
                                                <th style="">Check Amount
                                                </th>
                                                <th style="">Post Date
                                                </th>
                                                <th style="">Post Amount
                                                </th>
                                                <th style="">Insurance
                                                </th>
                                                <th style="">Detail
                                                </th>

                                            </tr>

                                        </thead>
                                        <tbody id="claimChecksList">
                                            <asp:Repeater ID="rptClaimCheck" runat="server">
                                                <ItemTemplate>
                                                    <tr id="<%# Eval("ERAMasterId") %>" class="DataRow">
                                                        <td style="text-align: center">
                                                            <i>
                                                                <%# Eval("RowNumber") %></i>
                                                        </td>
                                                        <td class="tdCheckNumber align_left">
                                                            <%# Eval("CheckNumber")%>
                                                        </td>
                                                        <td class="tdCheckDate align_center">
                                                            <%# Eval("CheckDate", "{0:d}")%>
                                                        </td>
                                                        <td class="tdCheckAmount align_right">
                                                            <%# Eval("CheckAmount", "{0:c}")%>
                                                        </td>
                                                        <td class="tdCheckDate align_center">
                                                            <%# Eval("CreatedDate", "{0:d}")%>
                                                        </td>
                                                        <td class="tdCheckDate align_right">
                                                            <%# Eval("PostedAmount", "{0:c}")%>
                                                        </td>

                                                        <td id="<%# Eval("InsuranceId") %>" class="tdInsurance align_left">
                                                            <%# Eval("Insurance")%>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <span class="fa fa-print" title="Print" onclick="PrintCheckInfo(this);"
                                                                style="cursor: pointer; font-size: 16px; color: #006a99; margin-left: 7px; display: inline-block;"></span>
                                                            <span class="spanview" style="display: none;" title="View" onclick="ViewCheckInfo(this);"></span>
                                                            <span class="spanedit" title="Edit" onclick="EditClaimCheck(this);"></span>
                                                            <span class="spandelete" title="Delete" onclick="DeleteClaimCheck(this);" style="margin-left: 5px;"></span>

                                                            <input type="hidden" class="hdnClaimCheckId" value='<%# Eval("ERAMasterId")%>' />
                                                            <input type="hidden" class="hdnInsuranceId" value='<%# Eval("InsuranceId")%>' />
                                                            <input type="hidden" class="hdnCheckAmount" value='<%#DataBinder.Eval(Container.DataItem, "CheckAmount","{0:0.00}")%>' />
                                                            <input type="hidden" class="hdnPostedAmount" value='<%#DataBinder.Eval(Container.DataItem, "PostedAmount","{0:0.00}")%>' />

                                                            <input type="hidden" class="hdnPatientId" value="<%#Eval("PatientId") %>" />
                                                            <input type="hidden" class="hdnPatient" value="<%#Eval("Patient") %>" />
                                                            <input type="hidden" class="hdnPaymentType" value="<%#Eval("PaymentType") %>" />
                                                            <%--<input type="hidden" class="hdnProcedurePaymentsId" value='<%# Eval("ProcedurePaymentsId")%>' />--%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <tr id="<%# Eval("ERAMasterId") %>" class="alternatingRow DataRow">
                                                        <td>
                                                            <i>
                                                                <%# Eval("RowNumber") %></i>
                                                        </td>
                                                        <td class="tdCheckNumber align_left">
                                                            <%# Eval("CheckNumber")%>
                                                        </td>
                                                        <td class="tdCheckDate align_center">
                                                            <%# Eval("CheckDate", "{0:d}")%>
                                                        </td>
                                                        <td class="tdCheckAmount align_right">
                                                            <%# Eval("CheckAmount", "{0:c}")%>
                                                        </td>
                                                        <td class="tdCheckDate align_center">
                                                            <%# Eval("CreatedDate", "{0:d}")%>
                                                        </td>
                                                        <td class="tdCheckDate align_right">
                                                            <%# Eval("PostedAmount", "{0:c}")%>
                                                        </td>

                                                        <td id="<%# Eval("InsuranceId") %>" class="tdInsurance align_left">
                                                            <%# Eval("Insurance")%>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <span class="fa fa-print" title="Print" onclick="PrintCheckInfo(this);"
                                                                style="cursor: pointer; font-size: 16px; color: #006a99; margin-left: 7px; display: inline-block;"></span>
                                                            <span class="spanview" style="display: none;" title="View" onclick="ViewCheckInfo(this);"></span>
                                                            <span class="spanedit" title="Edit" onclick="EditClaimCheck(this);"></span>
                                                            <span class="spandelete" title="Delete" onclick="DeleteClaimCheck(this);" style="margin-left: 5px;"></span>

                                                            <input type="hidden" class="hdnClaimCheckId" value='<%# Eval("ERAMasterId")%>' />
                                                            <input type="hidden" class="hdnInsuranceId" value='<%# Eval("InsuranceId")%>' />
                                                            <input type="hidden" class="hdnCheckAmount" value='<%#DataBinder.Eval(Container.DataItem, "CheckAmount","{0:0.00}")%>' />
                                                            <input type="hidden" class="hdnPostedAmount" value='<%#DataBinder.Eval(Container.DataItem, "PostedAmount","{0:0.00}")%>' />

                                                            <input type="hidden" class="hdnPatientId" value="<%#Eval("PatientId") %>" />
                                                            <input type="hidden" class="hdnPatient" value="<%#Eval("Patient") %>" />
                                                            <input type="hidden" class="hdnPaymentType" value="<%#Eval("PaymentType") %>" />
                                                            <%--<input type="hidden" class="hdnProcedurePaymentsId" value='<%# Eval("ProcedurePaymentsId")%>' />--%>
                                                        </td>
                                                    </tr>
                                                </AlternatingItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>




            </div>
            <div style="width: 100%; float: left;">
                <div class="widget">
                    <div class="widgettitle">Daily Work Confirmation</div>
                    <div class="home_navigation_icon" style="float: Right; margin-top: -24px; margin-right: 5px;" id="UploadFile_navigation_icon"></div>
                    <div class="widgetcontent" style="height: 198px; overflow-y: scroll;">
                        <div class="Grid" style="height: auto !important;">
                            <div class="grid-overflow-x" style="padding: 2px 7px 0px 7px;">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>File Date</th>
                                            <th>Uploaded Files</th>
                                            <th>File Status</th>
                                            <th>File Type</th>
                                            <th>Patients</th>
                                            <th>Claims</th>

                                        </tr>

                                        <asp:Repeater runat="server" ID="rptUploadedFiles">
                                            <ItemTemplate>


                                                <tr class="DataRow">

                                                    <td class="align_center">
                                                        <%# Eval("RowNumber") %>
                                                    </td>
                                                    <td class="align_center">
                                                        <%# Eval("CreatedDate","{0:d}")%>
                                               
                                                    </td>
                                                    <td class="align_left">
                                                        <%# Eval("FileName")%>
                                                    </td>
                                                    <td class="align_left">
                                                        <%# Eval("FileStatus")%>
                                                    </td>
                                                    <td class="align_left">
                                                        <%# Eval("FileType")%>
                                                    </td>
                                                    <td class="align_center">
                                                        <%# Eval("Patients")%>
                                                    </td>
                                                    <td class="align_center">
                                                        <%# Eval("Claims")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <%--  <AlternatingItemTemplate>
                                            <tr class="alternatingRow DataRow">
                                             <td>
                                                   <%# Eval("UploadDate", "{0:d}")%>
                                                </td>
                                                <td>
                                                    <%# Eval("FileName")%>
                                                </td>
                                                <td>
                                                    <%# Eval("FileStatus")%>
                                                </td>
                                                <td>
                                                    <%# Eval("SubmissionMethod")%>
                                                </td>
                                                <td>
                                                    <%# Eval("Patients")%>
                                                </td>
                                                <td>
                                                    <%# Eval("Claims")%>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>--%>
                                        </asp:Repeater>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="widget-record">

            <div class=" widget" style="margin-bottom: 3.5% !important">
                <div class="widgettitle">Last 30 Days  <span id="spnHomedates" runat="server"></span></div>

                <div class="Payment_box_home" style="padding: 15px !important">
                    <div class="Payment_box_charges" style="border: 2px solid #006291; border-radius: 3px; background: #f7f7f7; padding: 5px 10px;">

                        <div class="amount_home">


                            <asp:Label runat="server" ID="spnMTDCharges" CssClass="" Style="font-size: 19px; color: #006291; font-weight: 600;">$ 12,225</asp:Label>
                        </div>

                        <div class="amount_label_home" style="">
                            <span class="label" style="font-size: 15px; color: #333333; text-align: right;">Charges</span>
                        </div>




                    </div>


                    <div class="Payment_box_charges" style="margin-top: 4%; border: 2px solid #138d82; border-radius: 3px; background: #f7f7f7; padding: 5px 10px;">

                        <div class="amount_home">
                            <asp:Label runat="server" ID="spnMTDPayments" CssClass="" Style="font-size: 19px; color: #138d82; font-weight: 600;">$ 12,225</asp:Label>
                        </div>

                        <div class="amount_label_home" style="">
                            <span class="label" style="font-size: 15px; color: #333333; text-align: right;">Payments</span>
                        </div>




                    </div>

                </div>


            </div>


            <div class="uploadfiles" id="uploadfiles" style="display: none">
                <div class="" style="margin-left: 20px">
                    <span></span>
                </div>
                <div class="" style="font-size: large;">
                    Upload File
                </div>
            </div>




            <%-- 
    //rizwan kharal start
    //6 oct 2017
    //  Showing the Patient Ptl on Home page of patient on BillingManager --%>


            <div class="widget" style="">



                <div class=" widgettitle" style="margin-bottom: 2px ! important;">
                    Pending Transaction List 
                       <span class="pendingTranList" style="font-size: 12px !important; margin-left: 5px;">
                           <input type="radio" id="radiopatient" name="Ptl" checked="checked" /><a href="PendingTransitions/PendingTranstionPatients.aspx" style="text-decoration: none; color: #444">
                               <label style="cursor: pointer; color: white;">Patients</label></a>
                           <input type="radio" id="radioclaim" name="Ptl" /><a href="PendingTransitions/PendingTransitionClaims.aspx" style="text-decoration: none; color: #444"><label style="cursor: pointer; color: white;">Claims</label></a>
                       </span>
                    <%--  <div style="float:right;margin-bottom:3px">
          <input type="radio" id="radiopatient" name="Ptl" checked="checked" /><a href="PendingTransitions/PendingTranstionPatients.aspx" style="text-decoration:none;color:#444"> <label style="cursor:pointer">Patients</label></a>
          <input type="radio" id="radioclaim" name="Ptl" /><a href="PendingTransitions/PendingTransitionClaims.aspx" style="text-decoration:none;color:#444"><label style="cursor:pointer">Claims</label></a> 
       
        </div>--%>
                </div>
                <div class="widgetcontent" style="max-height: 212px; padding: 5px; box-sizing: border-box;">
                    <%-- Header--%>
                    <div class="Grid" id="patientgrid" style="height: 186px !important; overflow-y: scroll;">
                        <div class="grid">
                            <table>
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>First Name</th>
                                        <th>Last Name</th>
                                        <th style="display: none">

                                            <div class="dropdownMenuMultiCheckMainWrapper" style="width: 100%">
                                                <select></select>
                                                <div class="div-dropdown-label-wrapper">
                                                    <span class="custom-drop-down-label"></span>
                                                </div>
                                                <div class="dropdownMenuMultiCheck" style="top: 25px; width: 100%;">
                                                    <div class="div-drop-down" style="height: 150px;">
                                                        <ul id="ulPTLReasonFilterListPatient" style="text-align: left; overflow-x: hidden;">
                                                            <asp:Repeater runat="server" ID="rptPTLReasonsPatient">
                                                                <ItemTemplate>
                                                                    <li>
                                                                        <label>
                                                                            <input type="checkbox" id='chkPatientPTLReasonsId<%#Eval("PTLReasonsId") %>' class="chkReason CheckReasons_RemoveingChk" />
                                                                            <span class="spnReason"><%#Eval("Reason")%></span>

                                                                            <input type="hidden" class="hdnPTLReasonsId" value='<%#Eval("PTLReasonsId") %>' />
                                                                        </label>
                                                                    </li>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </div>

                                                </div>
                                            </div>

                                        </th>

                                        <th>PTL Reasons</th>



                                    </tr>
                                </thead>
                                <tbody id="tbodyPTLPatient">
                                    <asp:Repeater runat="server" ID="rptpatient">
                                        <ItemTemplate>
                                            <tr style="cursor: pointer" class="DataRow">
                                                <td>
                                                    <%# Eval("Row#")%>
                                                </td>
                                                <td>
                                                    <%# Eval("FirstName")%>
                                                </td>
                                                <td>
                                                    <%# Eval("LastName")%>
                                                </td>

                                                <%-- <%# Eval("Reason")%>--%>
                                                <td class="tdPTLReasons">
                                                    <span><%# Eval("Reason")%></span>
                                                    <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>


                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <%--//rizwan kharal start
    //9 oct 2017
    //  Showing the claim ptl reasons on Home page of patient on BillingManager --%>

                    <div class="Grid" id="claimgrid" style="display: none; height: 186px; overflow-y: scroll;">
                        <div class="grid">
                            <table>
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Patient Name</th>
                                        <th>DOS</th>
                                        <th style="display: none">

                                            <div class="dropdownMenuMultiCheckMainWrapper" style="width: 100%">
                                                <select></select>
                                                <div class="div-dropdown-label-wrapper">
                                                    <span class="custom-drop-down-label"></span>
                                                </div>
                                                <div class="dropdownMenuMultiCheck" style="top: 25px; width: 100%;">
                                                    <div class="div-drop-down" style="height: 150px;">
                                                        <ul id="ulPTLReasonFilterListClaim" style="text-align: left; overflow-x: hidden;">
                                                            <asp:Repeater runat="server" ID="rptPTLReasonsClaim">
                                                                <ItemTemplate>
                                                                    <li>
                                                                        <label>
                                                                            <input type="checkbox" id='chkClaimPTLReasonsId<%#Eval("PTLReasonsId") %>' class="chkReason CheckReasons_RemoveingChk" />
                                                                            <span class="spnReason"><%#Eval("Reason")%></span>

                                                                            <input type="hidden" class="hdnPTLReasonsId" value='<%#Eval("PTLReasonsId") %>' />
                                                                        </label>
                                                                    </li>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </div>

                                                </div>
                                            </div>

                                        </th>
                                        <th>PTL Reasons</th>


                                    </tr>
                                </thead>
                                <tbody id="tbodyPTLClaim">
                                    <asp:Repeater runat="server" ID="rptclaim">
                                        <ItemTemplate>
                                            <tr style="cursor: pointer" class="DataRow">
                                                <td>
                                                    <%# Eval("ROWNUMBER")%>
                                                </td>
                                                <td>
                                                    <%# Eval("Name")%>
                                                </td>
                                                <td>
                                                    <%# Eval("Dos", "{0:d}")%>
                                                </td>

                                                <td class="tdPTLReasons">
                                                    <span><%# Eval("Reason")%></span>
                                                    <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />
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

            <%--End  Pending Transition Div --%>
        </div>



        <div id="drop-down-file-div-logo" style="display: none;">
            <ul class="drop-down-file-logo">

                <li id="" class="icon_li_cross"><span class="icon-cross"></span></li>

                <li id="" style="margin-top: 25px" class="home li_setting" onclick="SideNavigation('home')">
                    <span class="nav_logo nav_home"></span>
                    <span class="nav_label">Home</span>
                </li>
                <li id="" class="patient li_setting" onclick="SideNavigation('patient')">
                    <span class="nav_logo nav_patient"></span>
                    <span class="nav_label ">Patient</span>

                </li>
                <li id="" class="scheduler li_setting" onclick="SideNavigation('scheduler')">

                    <span class="nav_logo nav_scheduler"></span>
                    <span class="nav_label ">Scheduler</span>

                </li>
                <li id="" class="dashboard li_setting" onclick="SideNavigation('dashboard')">
                    <span class="nav_logo nav_dashboard"></span>
                    <span class="nav_label ">Dashboard</span>

                </li>
                <li id="" class="Reports li_setting" onclick="SideNavigation('reports')">
                    <span class="nav_logo nav_Reports"></span>
                    <span class="nav_label ">Reports</span>
                </li>
                <li id="" class="Claims li_setting" onclick="SideNavigation('claims')">
                    <span class="nav_logo nav_Claims"></span>
                    <span class="nav_label ">Claims</span>
                </li>
                <li id="" class="Payer li_setting" onclick="SideNavigation('payers')">
                    <span class="nav_logo nav_Payer"></span>
                    <span class="nav_label ">Payer</span>
                </li>
                <li id="" class="payments li_setting" onclick="SideNavigation('Payments')">
                    <span class="nav_logo nav_payments"></span>
                    <span class="nav_label ">Payments</span>
                </li>
                <li id="" class="Messages li_setting" onclick="SideNavigation('message')">
                    <span class="nav_logo nav_Messages"></span>
                    <span class="nav_label ">Messages</span>
                </li>
                <li id="" class="settings li_setting" onclick="SideNavigation('settings')">
                    <span class="nav_logo nav_Settings"></span>
                    <span class="nav_label ">Settings</span>
                </li>

            </ul>
        </div>
    </div>
    <%--End  div main class--%>
    <script type="text/javascript">
        //debugger;
        $(document).ready(function () {
            //debugger;
            var userType = $.trim($('#User_Type').val());
            if (userType == 'Front Desk') {
                window.location.href = "../ProviderPortal/FrontDesk.aspx";
                $("#_home").hide();
                $("#_FrontDesk").show();
            } else {
                $("#_home").show();
                $("#_FrontDesk").hide();
            }
            $("#_home").addClass("active");

            $("#payements_navigation_icon").click(function () {
                window.location.href = "../../ProviderPortal/Payment/Payments.aspx";

            });

            $("#UploadFile_navigation_icon").click(function () {
                window.location.href = "../../ProviderPortal/UploadFiles/UploadFiles.aspx";

            });

            $("#Navigation").click(function () {

                debugger;
                $("#drop-down-file-div-logo").css("display", "block");

                $("#main").css("background-color", "gray");
                $("#main").prop('disabled', true);
            });

            $(".icon-cross").click(function () {


                $("#drop-down-file-div-logo").css("display", "none");

            });

            SetPTLReasons("Patient");
            SetPTLReasons("Claim");

            //Rizwan kharal start
            //9 oct 2017
            //with the radio button showing patient ptl or claim ptl and ptl reasons if radio button is checked

            $("#radioclaim").click(function () {

                $("#patientgrid").css("display", "none");

                $("#claimgrid").css("display", "block");

            });

            $("#radiopatient").click(function () {

                $("#patientgrid").css("display", "block");
                $("#claimgrid").css("display", "none");

            });

            //Rizwan kharal End

            new AjaxUpload('#uploadfiles', {
                action: _ResolveUrl + "ProviderPortal/UploadFile.ashx",
                dataType: 'json',
                contentType: "application/json; charset=uft-8",
                data: {
                    Directory: "Billing"
                },
                onSubmit: function (file, ext, fileSize) {
                    debugger;
                    if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                        showErrorMessage('Error: invalid file extension');
                        return false;
                    }
                    if (fileSize > 5) {
                        showErrorMessage("This file exceeds the 5MB attachment limit.");
                        return false;
                    }
                },
                onComplete: function (file, response) {

                    window.location.reload('');
                    alert('File uploaded Successfully');
                }
            });
        });



        //rizwan kharal start
        //24 oct 2017
        // Showing the PtlReason of patient to change the PTLReasons Id to reasons 
        function SetPTLReasons(PTLType) {
            debugger;
            var PTLReason, strPTLReasons = "", arrPTLReasons;

            $("#tbodyPTL" + PTLType + " .tdPTLReasons").each(function () {
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

        //rizwan kharal End

        /////////////////////



        function NavigateTo(link) {
            debugger

            if (link == "Pat") {
                window.location.href = "../../ProviderPortal/Patient/PatientSearch.aspx";
            }
            if (link == "PatRPM") {
                window.location.href = "../../ProviderPortal/Patient/PatientSearch.aspx?RPM=1";
            }
            if (link == "Claim") {
                window.location.href = "../../ProviderPortal/Claims/BillingManager.aspx";
            }
            if (link == "ClaimRPM") {
                window.location.href = "../../ProviderPortal/Claims/BillingManager.aspx?RPM=1";
            }
            if (link == "Pay") {
                window.location.href = "../../ProviderPortal/Insurances/InsurancesList.aspx";
            }
            if (link == "Msg") {
                window.location.href = "../../ProviderPortal/Messages/Messages.aspx";
            }
        }


        function SideNavigation(link) {
            debugger
            if (link == "home") {
                window.location.href = "../../ProviderPortal/Home.aspx";
            }
            if (link == "patient") {
                window.location.href = "../../ProviderPortal/Patient/PatientSearch.aspx";
            }
            if (link == "scheduler") {
                window.location.href = "../../ProviderPortal/Scheduler/Scheduler.aspx";
            }
            if (link == "dashboard") {
                window.location.href = "../../ProviderPortal/Dashboard.aspx";
            }
            if (link == "reports") {
                window.location.href = "../../ProviderPortal/Reports/Report.aspx";
            }
            if (link == "claims") {
                window.location.href = "../../ProviderPortal/Claims/BillingManager.aspx";
            }
            if (link == "payers") {
                window.location.href = "../../ProviderPortal/Insurances/InsurancesList.aspx";
            }
            if (link == "Payments") {
                window.location.href = "../../ProviderPortal/Payment/Payments.aspx";
            }
            if (link == "message") {
                window.location.href = "../../ProviderPortal/Messages/Messages.aspx";
            }
            if (link == "settings") {
                window.location.href = "../../ProviderPortal/Settings/Settings.aspx";
            }
        }



    </script>








    <style>
        #navigation, #Uploadnavigation {
            /*background-image:url(Images/ArrowNavigation.png);*/
            width: 20px;
            height: 10px;
        }
    </style>




</asp:Content>

