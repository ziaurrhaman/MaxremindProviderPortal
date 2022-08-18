<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PatientSearch.aspx.cs" Inherits="BillingManager_Patient_PatientSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Demographics.css" media="print" rel="stylesheet" />
    <link href="../../StyleSheets/BillingManagerTheme.css" rel="stylesheet" />
    <script src="../../jQueryPlugins/PrintThis/printThis.js"></script>
    <style>
        /* .container{
            overflow-y:hidden !important;
        }
        .Grid{
            overflow-y:auto;
            max-height:70vh;
            overflow-x:hidden;
        }*/
        .Check{
            pointer-events:none;
            background-color: #f3f0f0 !important;
        }
        .spndelete {
    width: 18px;
    height: 18px;
    float: left;
    background: url(../../../Images/recycleBin.png);
    cursor: pointer;
    background-repeat: no-repeat;
    background-position: left;
}
        .spndownload
{
    width: 18px;
    height: 18px;
    float: left;
    background: url('../../Images/download.png');
    cursor: pointer;
    background-repeat: no-repeat;
    background-position: left;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../ReportsNew/js/FilterReports.js"></script>
    <script src="js/Patients.js"></script>
    <asp:HiddenField ID="hdnPracticeId" runat="server" />
    <asp:HiddenField runat="server" ID="hdnTotalRows" />

    <h1 class="pagetitle" style="margin-top: -5px">Patients</h1>
    <span id="spnPatientSection" runat="server">
        <input id="rdoAllPatient" onchange="rdoPatient_Change()" name="rdoPatient" type="radio" checked="checked" />All Patients
        <input id="rdoRPMPatients" onchange="rdoPatient_Change()" name="rdoPatient" type="radio" />RPM Patients
    </span>
    <div class="PatientInvoice" style="float: right; margin-right: 17px; margin-top: 6px;">
        <%--Created By Agha Sibtain, Dated:04/10/2019--%>
        <a href="/ProviderPortal/MailToInvoices/MailToInvoices.aspx" class="PatInvoice" style="font-size: 18px; font-weight: bold; text-decoration: none; background: #006291; color: white; padding: 5px 5px 5px 5px;">Mail-To Invoices</a>
        <a href="/ProviderPortal/PatientInvoice/PatientInvoices.aspx" class="PatInvoice" style="font-size: 18px; font-weight: bold; text-decoration: none; background: #006291; color: white; padding: 5px 5px 5px 5px;">Patient Invoices</a>
    </div>
    <div class="Grid" id="PatientContainer">
        <table id="mytable" class="table">
            <thead style="">
                <tr>
                    <th style="width: 2%;">#
                    </th>
                    <th style="width: 8%;" onclick="sortedbyAscDesc(this,'Account Number')">Account Number
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                    </th>
                    <th style="width: 10%;" onclick="sortedbyAscDesc(this,'Last Name')">Last Name
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                    </th>
                    <th style="width: 10%;" onclick="sortedbyAscDesc(this,'First Name')">First Name
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                    </th>
                    <th style="width: 6%;" onclick="sortedbyAscDesc(this,'Gender')">Gender
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                    </th>
                    <th style="width: 7%;" onclick="sortedbyAscDesc(this,'DOB')">DOB
                         <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                    </th>
                    <th style="width: 20%;" onclick="sortedbyAscDesc(this,'Pri Ins')">Pri Insurance
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                    </th>
                    <th style="width: 9%;" onclick="sortedbyAscDesc(this,'Phone')">Phone
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                    </th>
                    <th style="width: 20%;" onclick="sortedbyAscDesc(this,'Address')">Address
                        <img src='../../Images/Down-Sort.png' class="imgGrayDown" style='width: 6px; display: inline;' />
                        <img src='../../Images/Up-Sort.png' class="imgGreenUp" style='width: 6px; display: inline; display: none' />
                        <img src='../../Images/Down-GreenSort.png' class="imgGreenDown" style='width: 6px; display: inline; display: none' />
                    </th>
                    <th style="width: 12%;" >Patient Responsibility
                        
                    </th>
                    <th style="width: 12%;" >Patient Payment
                        
                    </th>
                    <th style="width: 12%;" >Patient Balance
                        
                    </th>
                    <th style="width: 26%;">Post Payment
                        
                    </th>

                </tr>
                <!-- Add changes by DaniyalBaig 10Aug2018 -->
                <tr>
                    <th>
                        <i class="fa fa-filter" style="color: #065172; font-size: 20px !important;" id="FilterIcon" onclick="FilterPatient(0, true)"></i>
                    </th>
                    <th>
                        <input type="text" id="txtPatientId" onkeyup="SetSearch(event)" onkeypress="return patientIdKeyPress(event);" />
                    </th>
                    <th>
                        <input type="text" id="txtLastName" onkeyup="SetSearch(event)" />
                    </th>
                    <th>
                        <input type="text" id="txtFirstName" onkeyup="SetSearch(event)" />
                    </th>
                    <th>
                        <select id="ddlGender" style="width: 100%;" onchange="FilterPatient(0,true)">
                            <option value=""></option>
                            <option value="Male">Male</option>
                            <option value="Female">Female</option>
                        </select>
                    </th>
                    <th>
                        <asp:TextBox runat="server" ID="txtDateOfBirth" onkeyup="SetSearch(event)"></asp:TextBox>

                    </th>
                    <th>
                        <input type="text" id="txtPriInsurance" onkeyup="SetSearch(event)"  />
                    </th>
                    <th>
                        <input type="text" id="txtPhone" onkeyup="SetSearch(event)" />
                    </th>
                    <th style="width: 10%;">
                        <input type="text" id="txtAddress" onkeyup="SetSearch(event)" />
                    </th>
                    <th>
                        <input type="text" id="txtPatientResponsibility" onkeyup="" />
                    </th>
                    <th>
                        <input type="text" id="txtPatientPayment" onkeyup="" />
                    </th>
                    <th>
                        <input type="text" id="txtPatientBalance" onkeyup="" />
                    </th>
                    <th></th>
                    <!-- End changes-->
                </tr>
            </thead>
            <tbody id="patientList">
                <asp:Repeater ID="rptPatients" runat="server" OnItemDataBound="rptPatients_ItemDataBound">
                    <ItemTemplate>
                        <tr style="cursor: pointer" >
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <i><%# Eval("RowNumber") %></i>
                            </td>
                            <td class="PatId" style="text-align: center;" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("PatientId") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("LastName") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("FirstName") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("Gender") %>
                            </td>
                            <td class="txtalign-cntr" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("DateOfBirth", "{0:d}") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("Name") %>
                            </td>
                            <td class="txtalign-cntr" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("Cell") %>
                            </td>
                            <td onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <%# Eval("Address") %>
                            </td>
                            <td style="text-align:right" id="PatientResposibilty hidetd" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                <asp:Literal ID="ltrPatientResposibilty" runat="server"></asp:Literal>
                            </td>
                            <td style="text-align:right" class="PatientPayments hidetd" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                 <asp:Literal ID="ltrPatientPayment" runat="server"></asp:Literal>
                            </td>
                            <td style="text-align:right" class="PatientBalence hidetd" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                 <asp:Literal ID="ltrPatientBalence" runat="server"></asp:Literal>
                            </td>
                            <td style="text-align: center; width:100%" class="hidetd">
                                <a class="payment-link" href="#" title="View Patient" onclick="ViewDetails('<%# Eval("PatientId") %>')">
                                    <img src="../../Images/viewEye.png" /></a>
                                <a class="payment-link" href="#" id="openPostpayment" title="Post Payment" onclick="PostEOBPayment(this)">
                                    <img src="../../Images/payment.png" /></a>
                                <a class="payment-link" href="#" id="openBalanceSheet" title="Balance Sheet" onclick="ViewPaymentDetails(this)">
                                    <img src="../../Images/balance-sheet.png" / style="height:15px;width:15px"></a>
                                <asp:HiddenField   id="hdnPatientId" value='<%#Eval("PatientId")%>'  runat="server"/> 
                               
                                <input type="hidden" class="PatientName" id="PatientName" text='<%#Eval("FullName")%>'  runat="server"/>
                              
                            </td>
                            <td style="display:none" class="hdnPatientid"><%#Eval("PatientId")%></td>
                            <td style="display:none" class="hdnFullName"><%#Eval("FullName")%></td>
                            <td style="display:none" class="hdnCheckNos1"><asp:HiddenField   id="hdnCheckNos"   runat="server"/></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="table-footer">
            <div class="message">
                <span class="iconInfo" style="margin: 7px;"></span>
                <span class="spanInfo"></span>
            </div>
            <div class="pager">
                <div class="PageEntries">
                    <span style="float: left;">
                        <select id="ddlPagingPatient" style="margin-top: 5px;" onchange="RowsChange('FilterPatient');">
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
    <div id="postpayment" title="Add Post Payment" style="display:none;">
        <div class="postpayment-inner">
            <div class="row">
                <div class="col-lg-6">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label">Payment Method</label>
                        <div class="col-sm-7">
                           
                             <select id="ddlEOBPaymentMethod" onchange="ddlEOBPaymentMethod_Change(this)">
                                <option value="ACH">Automated Clearing House</option>
                                <option value="BOP">Financial Institution Option</option>
                                <option value="Check">Check</option>
                                <option value="Federal Reserve Funds">Federal Reserve Funds</option>
                                <option value="Non-Payment Data">Non-Payment Data</option>
                                <option value="American Express">American Express</option>
                                <option value="Cash">Cash</option>
                                <option value="Discover">Discover</option>
                                <option value="Master Card">Master Card</option>
                                <option value="Money Order">Money Order</option>
                                <option value="Visa Card">Visa Card</option>
                            </select>
                            
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label">Attach File</label>
                        <div class="col-sm-7" style="height:auto">
                            <div class="divUploadfilesDropDown">
                                 <a href="javascript:void(0);" id="linkUploadFiles" onclick="UploadFileFormReadyCommon()" style="color: #1155CC;">Upload file(s)</a>
                                <div class="Right_FileAssignment" style="float: right;border: 1px solid gray;">
                                </div>
                                <input type="hidden" id="FileFormate" />
                                <input type="hidden" id="FileId" />
                                <%--<div class="attachfile_div">
                                    
                                    <input style="float: left; " type="text" runat="server" id="txtFilename" />
                                    <input type="hidden" id="NewEob" value="NewEob" />
                                    <input type="hidden" runat="server" id="hdnUploadedFilesID" />
                                    <span style="float: left; margin-top: 5px; margin-left: 7px;" onclick="AttachmentDeleteConformationDialog()">
                                        <img src="../../Images/delete.png" style="cursor: pointer; display: none;" title="Delete attachment" alt="" />
                                    </span>
                                </div>
                                <div class="search_div">
                                    <div id="divSearchFile" style="width: 430px; height: 149px; position: absolute; display: none; background-color: #fff; z-index: 999; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px">
                                        <div class="Grid" style="width: 99%; height: auto;">
                                            <div id="FileNameSearchedList"></div>

                                        </div>
                                    </div>
                                </div>--%>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                
                <div class="col-lg-6">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label">Payment Date<span class="req">*</span></label>
                        <div class="col-sm-7">
                            
                            <input type="text" id="PaymentDate" class="form-control1" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 ChkNO">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label" id="lblCheckNumber">Check Number<span class="info"></span> </label>
                        <div class="col-sm-7">
                            
                            <input id="txtEOBRefNo" maxlength="20" class="required" oninput="ValidateAlphaNumericES6(this)" type="text" />
                        </div>
                    </div>
                </div>

                <div class="col-lg-6 SrNo" style="display:none">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label" id="lblSrNo">Sr #<span class="iconInfo " style="float:right !important; margin-right:80px !important" title="Patient-Account+CurrentDate(mm/yy)"></span> </label>
                        <div class="col-sm-7">
                            <input id="txtSrNo" maxlength="20" class="required" oninput="ValidateAlphaNumericES6(this)" type="text" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label">Amount<span class="req">*</span></label>
                        <div class="col-sm-7">
                           <input  id="txtEOBAmount" maxlength="10" oninput="validate(this)" class="required" 
                                type="text" /><%--onkeypress="return validateDecimal(event,this)--%>
                        </div>

                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label">Check Date</label>
                        <div class="col-sm-7">
                            <input type="text" class="form-control"  id="CheckDate" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label">Payment For</label>
                        <div class="col-sm-7">
                            <select  id="PaymentFor" class=""> 
                                <option value="Deductable">Deductable</option>
                                <option value="Co_Pay">Co Pay</option>
                                <option value="PR">Patient Responsibilty</option>
                                <option value="SelfPay">SelfPay</option>
                                <option value="SelfPayOthers">SelfPay Others</option>
                               
                                
                            </select>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="row mb-3">
                        <label class="col-sm-5 col-form-label">Payment Reason</label>
                        <div class="col-sm-7">
                            <input type="text" class="form-control" id="PaymentReason" />
                        </div>
                    </div>
                </div>
                <input type="hidden" id="DialogPatientName"/>
                    <input type="hidden" id="DialogPatientId" />
            </div>

            
        </div>
    </div>
    <div id="dialogueBody" class="printable" style="display: none;">   
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

                                         <div class="payment-history tbodyIndividualChecks">
                                             <asp:Repeater runat="server" ID="RptBalanceSheet_Trn" >
                                                 <ItemTemplate>
                                                     <ul>
                                                         <li><b>Payment Date: <span>
                                                             <asp:Label runat="server" ID="checkDate" Text='<%# Eval("checkdate")%>'></asp:Label></span></b></li>
                                                         <li><b>Check Number:</b><asp:Label runat="server" class="CheckNumber" ID="CheckNumber" Text='<%# Eval("checknumber")%>'></asp:Label></li>
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
                                <div class="col-lg-9 bsheet-right" id="lvl2Grid" > </div>             
                        </div>
                        </div>
                    </div>
    <div class="printableView" style="display:none;"></div>
     <div id="divPopupChkPaymentDetails" class="warnIcon" style="display:none"></div>
    <div id="divReport" style="float: left; display: none">EOB Updated Successfully</div>
    
    <script type="text/javascript">
        $("[id$='txtFilename']").keyup(function (e) {
            debugger;
            if (window.event)
                code = e.keyCode;
            else code = e.which;

            if (code == 32 || (code >= 97 && code <= 122) || (code >= 65 && code <= 90) || code >= 48 && code <= 57) {
                debugger
                var search = $("[id$='txtFilename']").val();
                $("[id$='hdnuploadfilesid']").val("0");
                fileSearch(search);

            }

            if ($("[id$='txtFilename']").val() == "") { $("#divSearchFile").hide(); }
        });

        $(document).ready(function () {

            var isRPM = false;
            try {
                var i = parseInt(getQueryString("RPM"));
                isRPM = (i == 1) ? true : false;
            } catch {

            }
            if (isRPM) {
                $("#rdoRPMPatients").prop("checked", true)
            }
            if (!checkModuleRights("PatientView")) {

                $("[id$='divRightsSettings']").html(_msg_PatientView).show();
                $("#ContentMaindiv").hide();
                return false;
            }

            $("#Patients").addClass("active");
            var dateOfBirthMin = new Date();
            dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);
            $("[id$='txtDateOfBirth']").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date(),
                yearRange: "-110:+0",
                onSelect: function (date, obj) {
                    FilterPatient(0, true);
                }
            }).mask("99/99/9999");


            $("[id$='CheckDate']").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date()
                
            }).mask("99/99/9999");
            
            //FilterPatient(0, true);
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
            if ($("[id$='hdnTotalRows']").val() > 0)
                $("#PatientContainer .spanInfo").html("Showing " + $("#patientList tr:first").children().first().html() + " to " + $("#patientList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");



        });
        //Added by Khayyam Adeel 
        
        //End
        function rdoPatient_Change() {
            FilterPatient(0, true);

        }
        function ViewDetails(PatientId) {
            window.location = "Demographics.aspx?PatientId=" + PatientId;
        }
        /**** Add by DaniyalBaig 10Aug2018 ****/
        function SetSearch(event) {
            debugger;
            var a = event.which || event.keyCode;
            if (a == 13) {
                if ($("#FilterIcon").hasClass("active")) {
                    FilterPatient(0, true);
                    $("#FilterIcon").css("color", "#065172");
                }
            }
            else {
                $("#FilterIcon").addClass("active");
                $("#FilterIcon").css("color", "red");
            }

        }

        var _IsPatientIdValidated = true;
        function patientIdKeyPress(evt) {
            _IsPatientIdValidated = true;
            var isValidate = ValidateOnlyNumber(evt);
            if (!isValidate) {
                _IsPatientIdValidated = false;
            }

            return _IsPatientIdValidated;
        }
        //End DaniyalBaig
        //Added by Syed Sajid Ali Date:11-21-2019 Des:For Sorting
        var SORTBY = "";
        function sortedbyAscDesc(elem, type) {
            debugger
            SORTBY = $(".ClaimSearch option:selected").val();
            $("[id$='sortBy']").val(SORTBY);

            $(".imgGreenUp").hide();
            $(".imgGreenDown").hide();
            $(".imgGrayDown").show();

            $(elem).find("img").toggle();

            var chkImg = $(elem).find("img").attr("class");
            if (chkImg == "imgGrayDown SortBy") {
                $(".imgGreenUp").hide();
            }
            if (chkImg == "imgGreenDown") {
                $(".imgGreenDown").hide();
            }
            if (chkImg == "imgGrayDown") {
                $(".imgGreenDown").hide();
            }
            if (chkImg == "imgGreenDown SortBy") {
                $(".imgGreenUp").hide();
            }

            $(elem).find("img").toggleClass('SortBy');
            var sortBy = $(elem).find("img").hasClass('SortBy');
            if (sortBy) {
                SORTBY = $.trim(type) + ' ASC';
            }
            else {
                SORTBY = $.trim(type) + ' DESC';
            }
            $("[id$='sortBy']").val(SORTBY);
            FilterPatient(0, true);
        }
        //End by Syed Sajid Ali

        function FilterPatient(pageNumber, paging) {
            debugger;
            if (SORTBY == null || SORTBY == undefined || SORTBY == '') SORTBY = 'Account Number DESC';

            var PatientId = $.trim($("#txtPatientId").val()) == "" ? 0 : $.trim($("#txtPatientId").val());

            var LastName = $.trim($("#txtLastName").val());
            var FirstName = $.trim($("#txtFirstName").val());
            var Gender = $.trim($("#ddlGender").val());
            var DOB = $.trim($("[id$='txtDateOfBirth']").val());
            var Phone = $.trim($("#txtPhone").val());
            var Address = $.trim($("#txtAddress").val());
            var PatientCondition = $.trim($("[id$='ddlPatientCondition']").val());
            var PriInsurance = $.trim($("#txtPriInsurance").val());

            var isRPM = false;
            if ($("#rdoAllPatient").is(":checked") || $("[id$='spnPatientSection']").is(':visible') == false) {
                isRPM = false;
            }
            else {
                isRPM = true;
            }
            debugger;
            $.post(_ResolveUrl + "../../ProviderPortal/Patient/CallBacks/PatientFilterHandler.aspx", { PriInsurance: PriInsurance, PatientId: PatientId, FirstName: FirstName, LastName: LastName, Gender: Gender, Phone: Phone, Address: Address, isRPM: isRPM, PatientCondition: PatientCondition, DOB: (isDate(DOB) ? DOB : ""), Rows: $("#ddlPagingPatient").val(), PageNumber: pageNumber, SortBy: SORTBY }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#patientList").html(returnHtml.substring(start, end));
                debugger;
                var startRowsCount = data.indexOf("###StartPatientRowsCount###") + 30;
                var endRowsCount = data.indexOf("###EndPatientRowsCount###");
                $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

                if (paging == true) {
                    GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
                }

                if ($("[id$='hdnTotalRows']").val() > 0)
                    $("#PatientContainer .spanInfo").html("Showing " + $("#patientList tr:first").children().first().html() + " to " + $("#patientList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
            });
        }
        function PostEOBPayment(elem) {
            debugger
            var Patname = $(elem).closest("tr").find("td:eq(14)").html();
            var PatId = $(elem).closest("tr").find("td:eq(13)").html(); 
            $("#DialogPatientName").val(Patname);
            $("#DialogPatientId").val(PatId);
            if ($("#ddlEOBPaymentMethod option:selected").val() != "Check") {
                debugger
                $(".ChkNO").css("display", "none");
                $(".SrNo").css("display", "");
                $("#txtSrNo").val($("#DialogPatientId").val() + formatDate(new Date().toLocaleDateString()));

            }
            else {
                $(".ChkNO").css("display", "");
                $(".SrNo").css("display", "none");
            }
           
            $('#postpayment').dialog({

                dialogClass: 'payment-ui-widget',
                resizable: false,
                title: 'Post Payment',
                width: '600',
                modal: true,
                buttons: {
                    "Save": function () {
                        SaveEOB('', 'Save');
                       // $(this).dialog("close");

                    },
                    Cancel: function () {
                        $(this).dialog("destroy");
                        ResetForm();
                    }
                }
            });

        }
        var validate = function (e) {
            var t = e.value;
            e.value = (t.indexOf(".") >= 0) ? (t.substr(0, t.indexOf(".")) + t.substr(t.indexOf("."), 3)) : t;
        }
        var ValidateAlphaNumericES6 = function (e) {
            debugger;
            var f = /^[a-zA-Z0-9]+$/;
           
            var t = e.value;
            var a = t.substr(0, t.indexOf(t));
            e.value = (f.test(t) ? t : t.substr(0,t.length-1));
        
        }
    </script>
   
</asp:Content>

