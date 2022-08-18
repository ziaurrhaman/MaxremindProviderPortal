<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrontDesk.aspx.cs" MasterPageFile="~/ProviderPortal/BillingMaster.master" Inherits="ProviderPortal_FrontDesk" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
      <div class="main" id="main">


    <div style="clear: both;"></div>
           
    <div style="float: left;width: 75%;padding-right: 10px;box-sizing: border-box;">
        <div style="float: left;width: 21%; box-sizing: border-box;padding-right: 10px;">
            <ul class="dashboardmenu">
                <li class="border_li" onclick="NavigateTo('Pat')" style="">
                    <div >
                         <div class="home_icon" style="    ">
                        <span class="patients"></span>
                    </div>
                    <div class="home_icon_name" style="">
                         
                        Patients
                    </div>

                    </div>
                   
                  
                </li>
                <li class="border_li" onclick="NavigateTo('Claim')">
                    
                      <div class="" >
                         <div class="home_icon">
                        <span class="claims"></span>
                    </div>
                    <div class="home_icon_name" style="">
          
                   Claims
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
                <li class="border_li"  onclick="NavigateTo('Msg')">
                    
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
        <div style="float: left; width: 79%;">

          <div class="widget" style="">

                  <div class=" widgettitle" style="margin-bottom: 2px ! important;"> Pending Transaction List 
                       <span style="font-size:12px !important;margin-left:5px;">
                           <input type="radio" id="radiopatient" name="Ptl" checked="checked" /><a href="PendingTransitions/PendingTranstionPatients.aspx" style="text-decoration:none;color:#444"> <label style="cursor:pointer ;color:white;" >Patients</label></a>
          <input type="radio" id="radioclaim" name="Ptl" /><a href="PendingTransitions/PendingTransitionClaims.aspx" style="text-decoration:none;color:#444"><label style="cursor:pointer;color:white;">Claims</label></a> 
                       </span>  
                    <%--  <div style="float:right;margin-bottom:3px">
          <input type="radio" id="radiopatient" name="Ptl" checked="checked" /><a href="PendingTransitions/PendingTranstionPatients.aspx" style="text-decoration:none;color:#444"> <label style="cursor:pointer">Patients</label></a>
          <input type="radio" id="radioclaim" name="Ptl" /><a href="PendingTransitions/PendingTransitionClaims.aspx" style="text-decoration:none;color:#444"><label style="cursor:pointer">Claims</label></a> 
       
        </div>--%>
                  </div>
                  <div class="widgetcontent" style="max-height: 212px;padding: 5px;box-sizing: border-box;">
                     <%-- Header--%>
                
              

                    <div class="Grid" id="patientgrid" style="height: 186px; overflow-y: scroll";>
                        <div class="grid">
                            <table >
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>First Name</th>
                                        <th>Last Name</th>
                                         <th style="display:none"> 
    
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



                   <div class="Grid" id="claimgrid" style="display:none; height: 186px; overflow-y: scroll;">
                        <div class="grid">
                            <table >
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Patient Name</th>
                                        <th>DOS</th>
                                            <th style="display:none"> 
    
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
                                <tbody id="tbodyPTLClaim" >
                                    <asp:Repeater runat="server" ID="rptclaim">
                                        <ItemTemplate>
                                            <tr style="cursor: pointer" class="DataRow">
                                                <td>
                                                    <%# Eval("Row#")%>
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




        </div>
   
    </div>
    <div style="float: left;width: 25%;box-sizing: border-box;margin-right: 0px;">

           <div class=" widget" style="margin-bottom:5px !important">
            <div class="widgettitle"> Last 30 Days </div>
              
               <div class="Payment_box_home" style="">
    <div class="Payment_box_charges" style="border: 2px solid #006291;border-radius:3px;background: #f7f7f7;">

         <div class="amount_home" style="float:right !important; width:auto !important" >
                

                <asp:Label runat="server" ID="spnPatients" CssClass="" style="font-size:19px;color: #006291;font-weight: 600;">15</asp:Label>
            </div>

         <div class="amount_label_home" style="">
       <span class="label" style="font-size: 15px; color: #333333;text-align: right;">Patients</span>
         </div>
              
         
               </div>
  
       
        <div class="Payment_box_charges" style="margin-top: 4%;border: 2px solid #138d82; border-radius: 3px;background: #f7f7f7;">

             <div class="amount_home"  style="float:right !important; width:auto !important"  >
               <asp:Label runat="server" ID="spnClaims" CssClass="" style="font-size:19px;color:#138d82;font-weight: 600;">25</asp:Label>
            </div>

         <div class="amount_label_home" style="">
              <span class="label" style="font-size: 15px; color: #333333;text-align: right;">Claims</span>
         </div>
              
           
          
         
               </div>
           
        </div>


        </div>


        <div class="uploadfiles" id="uploadfiles" style="margin-bottom:5px !important;">
            <div class="" style="margin-left:20px">
                 <span></span>
            </div>
           <div class="" style="font-size: large;">
            Upload File
           </div>   
        </div>

  
  
      

      



    </div>

     <div style="width: 100%; float: left;">
            <div class="widget">
                <div class="widgettitle">Daily Work Confirmation</div>
                  <div class="home_navigation_icon" style="float:Right;margin-top: -24px; margin-right: 5px;" id="UploadFile_navigation_icon"></div>
                <div class="widgetcontent" style="height: 201px; overflow-y:scroll;">
                    <div class="Grid">
                        <div class="grid-overflow-x" style="padding: 2px 7px 0px 7px;">
                            <table>
                                <thead >
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

          <div id="drop-down-file-div-logo"style="display:none;">
                         <ul class="drop-down-file-logo">

                         <li id="" class="icon_li_cross">  <span class="icon-cross"></span> </li>
                             
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
                           
                            
                              <li id="" class="Claims li_setting" onclick="SideNavigation('claims')">
                                  <span class="nav_logo nav_Claims"></span>
                              <span class="nav_label ">Claims</span> 
                              </li>
                              <li id="" class="Payer li_setting" onclick="SideNavigation('payers')">
                              <span class="nav_logo nav_Payer"></span>
                              <span class="nav_label ">Payer</span> 
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
 
        <script type="text/javascript">
            $(document).ready(function () {
                debugger;
                $("#_FrontDesk").addClass("active");
                $(".HomeTab").addClass("active");
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
                if (link == "Claim") {
                    window.location.href = "../../ProviderPortal/Claims/BillingManager.aspx";
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

      #navigation,#Uploadnavigation
      {
          /*background-image:url(Images/ArrowNavigation.png);*/
          width:20px;
          height:10px;
              }

        .Payment_box_charges {
        height:55px;
        }
   
    </style>




</asp:Content>

