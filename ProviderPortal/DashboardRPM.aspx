<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="DashboardRPM.aspx.cs" Inherits="ProviderPortal_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!-- jQuery library -->
    <script src="js/jquery.min.js"></script>
    <script src="js/MainReport.js" type="text/javascript"></script>
    <script src="ReportsNew/js/FilterReports.js"></script>
    <script src="../Scripts/Reports.js"></script>

    <!-- jsPDF library -->
    <script src="js/jsPDF/dist/jspdf.min.js"></script>
    <%-- Added by Khayyam Adeel:desc
  ALL data is showing on page load just div are hidden and when there is need for them to be visible, then we are showing them.--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      
    <%-- Created by Faiza Bilal 8/6/2021--%>
      
    <script src="ReportsNew/js/FilterReports.js"></script>
    <script src="../Scripts/Reports.js"></script>
    <script src="ReportsNew/js/MainReport.js"></script>

    <script src="../../Scripts/Rizwan/DashboardCharts.js"></script>
    <script src="../../Scripts/Exporting.js"></script>
    <script src="../../Scripts/HighCharts.js"></script>
    <script src="../Scripts/DashboardRPM.js"></script>

    <script src="../Scripts/Common.js"></script>
    <link href="../packages/Font.Awesome.5.15.3/Content/Content/fontawesome.css" rel="stylesheet" />
    <link href="../StyleSheets/DashboardRPM.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.2/jspdf.debug.js"></script>
    <style>
        .home_icon_name {
            font-size: 12px !important;
        }

        .selected {
            background-color: #EEEFEF;
        }
        .radio_li {
                padding-bottom: 5px;
            }
        .btn{
            float:right;
        }
        .BtnDateFilterRPM {
        background: #006291;
        color:white;
    }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            debugger;
            
            $("[id$='txtReportDateFrom']").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date()
            }).mask("99/99/9999");
            $("[id$='txtReportDateTo']").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date()
            }).mask("99/99/9999");
          
           

        });
 
       
        
    </script>



    <%--  Edit Israr Ahmed--%>
  
    <div id="FilterData" style="display:none"></div>
    <div class="outer">
        <div class="dashboardManu">
            <div style="padding-right: 10px; box-sizing: border-box;">
                <div>
                    <ul class="dashboardmenu rpm-sidenav">
                        <li class="border_li" id="div-DashBoard" onclick="getData('DashBoard')">

                            <div class="">
                                <div class="home_icon">
                                    <span class="payers"></span>
                                </div>
                                <div class="home_icon_name" style="" onclick="getData('DashBoard','','')">
                                    DashBoard
                                </div>

                            </div>
                        </li>
                        <li class="border_li" id="div-Pat" onclick="getData('Pat','','')">
                            <div>
                                <div class="home_icon">
                                    <span class="patients"></span>
                                </div>
                                <div class="home_icon_name" style="">
                                    Patients
                                </div>

                            </div>
                        </li>

                        <li id="liRPMPatient" runat="server" class="border_li" style="display: none;">
                            <div>
                                <div class="home_icon">
                                    <span class="patients"></span>
                                </div>
                                <div class="home_icon_name" style="">
                                    RPM Patients
                                </div>

                            </div>
                        </li>
                        <li class="border_li" id="div-Claim" onclick="getData('Claim','','')">
                            <div class="">
                                <div class="home_icon">
                                    <span class="claims"></span>
                                </div>
                                <div class="home_icon_name" style="" >
                                    Claims
                                </div>
                            </div>
                        </li>

                        <li id="liRPMClaim" runat="server" class="border_li" style="display: none;">
                            <div class="">
                                <div class="home_icon">
                                    <span class="claims"></span>
                                </div>
                                <div class="home_icon_name" style="">
                                    RPM Claims
                                </div>

                            </div>
                        </li>


                        <li class="border_li" id="div-Reports" onclick="getData('Reports','','')">

                            <div class="">
                                <div class="home_icon">
                                    <span class="messages"></span>
                                </div>
                                <div class="home_icon_name" style="">
                                    Reports
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

            </div>
        </div>
        <div class="col-left">
                

        </div>
        <div id="dashboard" style="width: 100%">
            <div class="col-left">
                <div class="main">
                    <%--Added by Khayyam Adeel desc:--%>
                   <div  id="divTimeSpan" class="Payment_box_1 P20 " style="height:30px; margin-bottom:5px; padding:5px;min-height:80px" >
              
               
                    
                
                           <div class="row" id="divRowRdo" runat="server" >
                                <%--<div class="col-4" id="divCellBeginning" style="width:40%" runat="server">
                                    <ul style="margin-top:10px;">
                                    <li class="radio_li"> <asp:RadioButton runat="server" ID="rbReportTimeSpanToday" Text="Today" Checked="true" CssClass="Today"  GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    <li class="radio_li"> <asp:RadioButton runat="server" ID="rbReportTimeSpanFromTheBeginning" Text="From the Beginning"  CssClass="Beginning" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    <li class="radio_li"> <asp:RadioButton runat="server" ID="rbReportTimeSpanLastMonth" Text="Last Month" CssClass="LastMonth" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    <li class="radio_li"> <asp:RadioButton runat="server" ID="rbReportTimeSpanMonthToDate" Text="Month to Date" CssClass="MonthToDate" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    <li class="radio_li"> <asp:RadioButton runat="server" ID="rbReportTimeSpanYearToDate" Text="Year to Date" CssClass="YearToDate" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    </ul>
                                       
                                </div>--%>
                                <div class="col-12">
                                        <asp:Label runat="server" ID="rbReportTimeSpanSpecificDates" Text="Select Date" CssClass="SpecificDates" GroupName="rbReportTimeSpan" onclick="EnableDates(true);"  Style="font-weight:bold;"/>
                                    <br />
                                        <div class="">
                                            <table id="timeDurationAgencyReportFilterBox" style="table-layout: auto;">
                                                <tr>
                                                    <td style="width: 45px; text-align: right;">
                                                        <span>From:</span>
                                                    </td>
                                                    <td style="width: 120px;">
                                                        <asp:TextBox runat="server" ID="txtReportDateFrom" CssClass="required"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40px; text-align: right;" id="spnTo" runat="server">
                                                        <span">To:</span>
                                                    </td>
                                                    <td style="width: 120px;" id="tdDateTo" runat="server">
                                                        <asp:TextBox runat="server" ID="txtReportDateTo" CssClass="required"></asp:TextBox>
                                                    </td>
                                                    <td>

                                                    </td>
                                                    <td>
                                                        <div class="button" style="">
                                                           <asp:Button runat="server" ID="btnUploadFiles"  UseSubmitBehavior="false"  onclick="BtnDateFilterRPM_Click"  Style="float: right;background-image: linear-gradient(to bottom, #006291, #006291) !important;background-image: linear-gradient(to bottom, #b9e4ff, #a1daff); margin: 5px; color:white;text-shadow:none" Text="Filter " />
                                                        </div>
                                                        
                                                    </td>
                                                </tr>
                                        </table>
                                    </div>
                                </div>
                           </div>
                 
              
            </div>
                   <%-- END OF Change--%>
                   <div id="dahboardRPM_Graphs"> </div>
                    <div>
                        <%-- Patients Record--%>
                        <div style="" id="div-payment" class="div_payment_box_left">
                            <div class="Payment_box_1 P20" style="">
                                <div style="width: 50%; float: left">
                                    <div style="">
                                        <span class="label" style="font-size: 20px; color: #3266fe; text-align: left; line-height: 24px;">Patients</span>
                                    </div>
                                    <div class="amount" onclick="getData('Pat','','DateFilter')" style="cursor: pointer">
                                        <asp:Label runat="server" ID="lblpatients" CssClass="" Style="font-size: 35px; text-align: left; border-bottom: 1px solid red"></asp:Label>
                                    </div>
                                </div>
                                <div width="50%" style="float: right">
                                    <div class="icon-box">
                                        <i class="fa fa-user-md"></i>
                                    </div>
                                </div>

                            </div>

                        </div>


                        <%--  Claims Record --%>
                        <div style="" class="div_payment_box_right">
                            <div class="Payment_box_1 P20" style="">
                                <div width="100%">
                                    <div width="50%" style="float: left">
                                        <div style="">
                                            <span class="label" style="font-size: 20px; color: #0dcd94; text-align: left; line-height: 24px;">Claims</span>
                                        </div>
                                        <div class="amount" style="cursor: pointer" onclick="getData('Claim', '', 'DateFilter');">
                                            <asp:Label runat="server" ID="lblClaims" CssClass="" Style="font-size: 35px; text-align: left; border-bottom: 1px solid red"></asp:Label>
                                        </div>
                                    </div>
                                    <div width="50%" style="float: right">
                                        <div class="icon-box-2">
                                            <i class="fa fa-newspaper-o "></i>
                                        </div>
                                    </div>
                                </div>
                                <div width="100%" style="margin-top: 70px">
                                    <div style="float: left; width: 50%; font-size: 15px">
                                        <span style="color: #0dcd94">Paid    </span>
                                        <asp:Label ID="lblpaidclaims" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div style="float: right; width: 49%; font-size: 15px">
                                        <span style="color: #0dcd94">In Process    </span>
                                        <asp:Label ID="lblinprocessclaims" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both"></div>
                    <div class="rpm-graph-outer">
                        <div style="margin-left: 1%" class="div_payment_box_1 Pl_0 graph-box">


                            <div style="float: left">
                                <div class="content" style="width: 500px; height: 500px;" id="RecordRPM"></div>
                                <div id="DivChartsDetailsReport"></div>
                                <asp:Literal runat="server" ID="ltrlScript"></asp:Literal>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
            <div class="col-right">
                <div class="cptDivs">


                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div style="width: 100%;">

                                <div style="" class="div_payment_right_box Pl_0">
                                    <div class="Payment_box_left P20" style="">
                                        <div class="cptst">
                                            <div class="cptfre" onclick="getData('Reports','<%#Eval("CPTCode")%>','CPTCode')" style="cursor: pointer">
                                                <%--"onclick="CPTWise_Record('<%#Eval("CPTCode")%>')--%>
                                                <h2>
                                                    <asp:Label ID="lblCPTCode" runat="server" Text='<%#Eval("CPTCode")%>'></asp:Label></h2>
                                            </div>
                                            <div>
                                                Frequency <span>
                                                    <asp:Label ID="lblFrequency" runat="server" Text='<%#Eval("Frequency")%>'></asp:Label></span>
                                            </div>

                                        </div>
                                        <br />
                                        <div width="100%">
                                            <div width="50%" style="float: left">Charges</div>
                                            <div width="50%" style="text-align: right; float: right">
                                                <asp:Label ID="lblSubmitCharges" runat="server" Text='<%#Eval("SubmitCharges", "{0:C}")%>'></asp:Label>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div width="100%">
                                            <div width="50%" style="float: left">Payments</div>
                                            <div width="50%" style="text-align: right; float: right">
                                                <asp:Label ID="lblPayments" runat="server" Text='<%#Eval("Payments", "{0:C}")%>'></asp:Label>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div width="100%">
                                            <div width="50%" style="float: left">Pending Insurances</div>
                                            <div width="50%" style="text-align: right; float: right">
                                                <asp:Label ID="lblPendingInsurance" runat="server" Text='<%#Eval("PendingInsurance", "{0:C}")%>'></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>


            </div>
        </div>
        <div id="ClaimRPM" class="ClaimRPM" style="display: none;">
            <div id="divBillingManagerContent" class="">
                <div id="divClaims">
                    <div class="Grid">
                        <table style="width: 100%;" id="tblClaim">
                            <thead>
                                <tr>
                                    <th style="width: 2%;">#
                                                
                                    </th>
                                    <th style="width: 2%;" class="allCheckbox">
                                        <%--<input type="checkbox" id="allCheckbox1" class="chkHeader" runat="server" onclick="CheckAllCheckBoxs();" />--%>
                                    </th>
                                    <th style="width: 5%;" onclick="sortedbyAscDescCLaimRPM(this,'Claim No')">Claim No
                                                <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 5%" onclick="sortedbyAscDescCLaimRPM(this,'Account No')">Account No
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 10%" onclick="sortedbyAscDescCLaimRPM(this,'Patient Name')">Patient Name
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 6%" onclick="sortedbyAscDescCLaimRPM(this,'DOS')">DOS
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 6%" onclick="sortedbyAscDescCLaimRPM(this,'Bill Date')">Bill Date
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 15%" onclick="sortedbyAscDescCLaimRPM(this,'Location')">Location
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 18%" onclick="sortedbyAscDescCLaimRPM(this,'Insurance')">Primary Insurance
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 12%" onclick="sortedbyAscDescCLaimRPM(this,'Status')">Primary Status
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <%--added by shahi kazmi 1/22/2018--%>
                                    <th style="width: 5%;" onclick="sortedbyAscDescCLaimRPM(this,'AmountPaid')">Paid Amount
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 5%;" onclick="sortedbyAscDescCLaimRPM(this,'AmountDue')">Balance Due
                                                 <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                                    </th>
                                    <th style="width: 5%;" onclick="sortedbyAscDescCLaimRPM(this,'Charges')">Charges
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
                                        <i class="fa fa-filter" style="color: #065172; font-size: 20px !important;" id="FilterIcon1" onclick="FilterClaimsRPM(0, true)"></i>

                                    </th>
                                    <th></th>
                                    <th>
                                        <input type="text" id="txtClaimNo" onkeyup="SetSearchClaims(event)" onkeypress="return claimIdKeyPress(event);" />
                                    </th>
                                    <th>
                                        <input type="text" id="txtPatientAccount" onkeyup="SetSearchClaims(event)" onkeypress="return claimIdKeyPress(event);" />
                                    </th>
                                    <!-- End Daniyal_Baig-->
                                    <th>
                                        <input type="text" id="txtPatientName" onkeyup="SetSearchClaims(event)" />
                                    </th>
                                    <th>
                                        <input type="text" id="txtDateOfService" class="ServiceDate" onkeyup="SetSearchClaims(event)" />
                                    </th>
                                    <th>
                                        <input type="text" id="txtBillDate" class="BillDate hasDatepicker" onkeyup="SetSearchClaims(event)" />
                                    </th>
                                    <th>
                                        <input type="text" id="txtLocation" class="BillDate hasDatepicker" onkeyup="SetSearchClaims(event)" />
                                    </th>
                                    <th style="position: relative; padding-right: 20px;">

                                        <asp:HiddenField ID="hdnLocationIds" runat="server" />
                                        <label class="lbltexthere" style="text-align: left; box-sizing: border-box; padding-top: 6px; float: left; width: 99%; height: 25px; background-color: white; margin-left: 0%; border: 1px solid #ccc; border-radius: 2px; padding-left: 5px;" onclick="LoadInsuranceList()"></label>
                                        <span class="arrowdown" onclick="LoadInsuranceList()">
                                            <img src="../../Images/down-arrow-iconBlack.jpg" width="20px" height="20px" /></span>
                                        <div id="LoadInsuranceListDiv" style="margin-top: 2%; z-index: 1; display: none; position: absolute; width: 105%; margin-top: 25px; overflow-y: auto; height: 255px; border: 1px solid #ccc; box-shadow: 1px 2px #d6d6d6;" class="Grid">
                                        </div>
                                    </th>
                                    <th>
                                        <asp:DropDownList ID="ddlSubmissionStatus" runat="server" CssClass="select" Style="float: none; width: 100%;" onchange="RowsChange('FilterClaimsRPM');"></asp:DropDownList>
                                    </th>
                                    <%--added by shahid kazmi 1/22/2018--%>
                                    <th>
                                        <input type="text" id="txtPaidAmount" onkeyup="SetSearchClaims(event)" style="width: 83%;" />
                                    </th>
                                    <th>
                                        <input type="text" id="txtAmountDue" onkeyup="SetSearchClaims(event)" style="width: 83%;" />
                                    </th>
                                    <th>
                                        <input type="text" id="txtCharges" onkeyup="SetSearchClaims(event)" style="width: 83%;" />
                                    </th>
                                    <%--end shahid kazmi 1/22/2018--%>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="ClaimsList">
                                <asp:Repeater ID="rptClaims" runat="server" OnItemDataBound="rptClaims_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="cursor: pointer;">
                                                <i><%# Eval("ROWNUMBER")%></i>
                                            </td>

                                            <td class="singleCheckbox">
                                                <input type="checkbox" class="clsContainer" value='<%# Eval("ClaimId") %>' />
                                            </td>
                                            <td>
                                                <%-- claim-center class in common.css --%>
                                                <span class=""><%# Eval("ClaimId")%></span>
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
                                            <td class="txtalgn-left" style="cursor: pointer;">
                                                <%# Eval("Location")%>
                                            </td>
                                            <td style="cursor: pointer;">
                                                <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                                            </td>
                                            <td style="white-space: nowrap; cursor: pointer;">
                                                <%--<%# Eval("InsuranceStatus")%>--%>
                                                <asp:Label runat="server" ID="lblstatus" />
                                            </td>
                                            <%--added by shahid kazmi 1/22/2018--%>
                                            <td style="white-space: nowrap; cursor: pointer;" class="txtalign-right">
                                                <%# Eval("AmountPaid","{0:c}")%>
                                            </td>
                                            <td style="white-space: nowrap; cursor: pointer;" class="txtalign-right">
                                                <%# Eval("AmountDue","{0:c}")%>
                                            </td>
                                            <td style="white-space: nowrap; cursor: pointer;" class="txtalign-right">
                                                <%# Eval("ClaimTotal","{0:c}")%>
                                            </td>
                                            <%-- end shahid kazmi 1/22/2018--%>

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
                        <div class="message">
                            <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                        </div>
                        <div class="pager">
                            <div class="PageEntries">
                                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                    <select id="ddlPagingClaims" style="margin-top: 5px;" onchange="RowsChange('FilterClaimsRPM');">
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
                        <asp:HiddenField ID="hdnClaimsCount" runat="server" />
                        <asp:HiddenField ID="hdnRows" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <div id="PatientRPM" class="PatientRPM" style="display: none;">
            <div class="Grid PatientRPM" id="PatientContainer">
                <asp:HiddenField ID="hdnPracticeId" runat="server" />
                <asp:HiddenField runat="server" ID="hdnTotalRows" />
                <table id="mytable">
                    <thead style="position">
                        <tr>
                            <th style="width: 2%;">#
                            </th>
                            <th style="width: 8%;" onclick="sortedbyAscDescPatientRPM(this,'Account Number')">Account Number
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                            </th>
                            <th style="width: 10%;" onclick="sortedbyAscDescPatientRPM(this,'Last Name')">Last Name
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                            </th>
                            <th style="width: 10%;" onclick="sortedbyAscDescPatientRPM(this,'First Name')">First Name
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                            </th>
                            <th style="width: 6%;" onclick="sortedbyAscDescPatientRPM(this,'Gender')">Gender
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                            </th>
                            <th style="width: 7%;" onclick="sortedbyAscDescPatientRPM(this,'DOB')">DOB
                         <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                            </th>
                            <th style="width: 25%;" onclick="sortedbyAscDescPatientRPM(this,'Pri Ins')">Pri Insurance
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                            </th>
                            <th style="width: 9%;" onclick="sortedbyAscDescPatientRPM(this,'Phone')">Phone
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                            </th>
                            <th style="width: 26%;" onclick="sortedbyAscDescPatientRPM(this,'Address')">Address
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                                <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                                <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                            </th>

                        </tr>
                        <!-- Add changes by DaniyalBaig 10Aug2018 -->
                        <tr>
                            <th>
                                <i class="fa fa-filter" style="color: #065172; font-size: 20px !important;" id="FilterIcon" onclick="FilterPatientRPM(0, true)"></i>
                            </th>
                            <th>
                                <input type="text" id="txtPatientId" onkeyup="SetSearchPatients(event)" onkeypress="return patientIdKeyPress(event);" />
                            </th>
                            <th>
                                <input type="text" id="txtLastName" onkeyup="SetSearchPatients(event)" />
                            </th>
                            <th>
                                <input type="text" id="txtFirstName" onkeyup="SetSearchPatients(event)" />
                            </th>
                            <th>
                                <select id="ddlGender" style="width: 100%;" onchange="FilterPatientRPM(0,true)">
                                    <option value=""></option>
                                    <option value="Male">Male</option>
                                    <option value="Female">Female</option>
                                </select>
                            </th>
                            <th>
                                <asp:TextBox runat="server" ID="txtDateOfBirth" onkeyup="SetSearchPatients(event)"></asp:TextBox>

                            </th>
                            <th>
                                <input type="text" id="txtPriInsurance" onkeyup="SetSearchPatients(event)" />
                            </th>
                            <th>
                                <input type="text" id="txtPhone" onkeyup="SetSearchPatients(event)" />
                            </th>
                            <th style="width: 23%;">
                                <input type="text" id="txtAddress" onkeyup="SetSearchPatients(event)" />
                            </th>
                            <!-- End changes-->
                        </tr>
                    </thead>
                    <tbody id="patientList">
                        <asp:Repeater ID="rptPatients" runat="server">
                            <ItemTemplate>
                                <tr style="cursor: pointer" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                    <td>
                                        <i><%# Eval("RowNumber") %></i>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("PatientId") %>
                                    </td>
                                    <td>
                                        <%# Eval("LastName") %>
                                    </td>
                                    <td>
                                        <%# Eval("FirstName") %>
                                    </td>
                                    <td>
                                        <%# Eval("Gender") %>
                                    </td>
                                    <td class="txtalign-cntr">
                                        <%# Eval("DateOfBirth", "{0:d}") %>
                                    </td>
                                    <td>
                                        <%# Eval("Name") %>
                                    </td>
                                    <td class="txtalign-cntr">
                                        <%# Eval("Cell") %>
                                    </td>
                                    <td>
                                        <%# Eval("Address") %>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span>
                    <span class="spanInfo"></span>
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left;">
                            <select id="ddlPagingPatient" style="margin-top: 5px;" onchange="RowsChange('FilterPatientRPM');">

                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                            </select>
                        </span><span style="float: left;">&nbsp;Entries per page</span>
                    </div>
                    <div class="PageButtons">
                        <ul style="float: right; margin-right: 15px;">
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div id="ReportsRPM" class="ReportsRPM" style="display: none;">
            <div class="">
                <div id="divReports" style="display: none">
                    <div id="RPMDashBoard_ClaimAndPatientDetailWise"></div>
                </div>
            </div>
        </div>
        <%-- when Clicked on Reports this module is displyed--%>
        <div id="AllReportsRPM" class="AllReportsRPM" style="display: none;">
            <div id="divAllReportsRPM" style="display: none">
                <div id="RPMDashBoard_ClaimPatientCPTReports">
                    <span class="btnAllReportsRPM" id="btnClaimReportsRPM" onclick="OpenAllClaimReports(this)">Claim Reports</span>
                    <span class="btnAllReportsRPM" id="btnPatietReportsRPM" onclick="OpenAllPatientReports(this)">Patient   Reports</span>
                    <span class="btnAllReportsRPM" id="btnProcedureReportsRPM" onclick="OpenAllCPTReports(this)">Procedure Reports</span>
                </div>
            </div>
        </div>
        <div id="Reports" class="Reports"></div>
    </div>
    <div id="div-ReportsRPM"></div>

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


    <%--  End Edit Israr Ahmed--%>



    <div id="OpenClaimForm" style="height: 500px;"></div>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });
            debugger;
            DashboardRPMPieChart();

            $(".highcharts-title").remove();
            $(".highcharts-button").remove();
            $(".highcharts-credits").remove();


        });

        function DashboardRPMPieChart() {

            // var data = google.visualization.arrayToDataTable(GETRPMDashBoard);
            var css = GETRPMDashBoard;//
            css.splice(0, 1);
            var mycss = css;

            var chart = {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie',

            };

            var tooltip = {
                pointFormat: '$ {point.y} '
            };

            var plotOptions = {
                pie: {
                    colors: ['#3366fd', '#ff7e00', '#0dcd94', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
                    allowPointSelect: false,

                    size: '40%',
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {

                                debugger;
                                var status = this.name;
                                CLAIMSUBMISSIONSTATUSCLAIMSUBMISSIONSTATUSPIECHARTDetail(status);
                            }

                        },

                    },
                    dataLabels: {

                        enabled: true,
                        connectorWidth: 1.5,
                        format: '<b>{point.name}</b> ${point.y:,.of}',
                        style: {
                            fontSize: 11,
                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) ||
                                'black'

                        }
                    },
                    showInLegend: true

                },

            };
            var series = [{
                type: 'pie',
                animation: false,

                data: mycss,
            }];
            Highcharts.getOptions().colors = Highcharts.map(
                Highcharts.getOptions().colors, function (color) {
                    return {
                        radialGradient: { cx: 0.5, cy: 0.3, r: 0.7 },
                        stops: [
                            [0, color],

                        ]
                    };
                }
            );
            var json = {};
            json.chart = chart;
            json.tooltip = tooltip;
            json.series = series;
            json.plotOptions = plotOptions;
            $('#RecordRPM').highcharts(json);
        }


    </script>
</asp:Content>
