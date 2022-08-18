<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsuranceCredentialingHandler.aspx.cs" Inherits="ProviderPortal_InsuranceCredentialing_CallBacks_InsuranceCredentialingHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   

       <form id="form1" runat="server">
    <div>

        ###StartInsuranceCredentialing###
        <style>
            #insuFilterDiv{ 
                    float: left;
                    margin-left: 92px;
                    position: absolute;
                    margin-top: 3%;
                    z-index: 1;
            }

            .divDocumentDetail {
   width: auto; 
}
            .uploadfileboxDiv {
     margin-top: 0; 
}
        </style>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".targetDate").datepicker({
                changeMonth: true,
                changeYear: true,

            }).mask("99/99/9999");

            $("#txtSSN").mask("(999)-99-9999");
        });
    </script>

     <div class="Widget" id="AddEditInsuCred" style="width:56%">
             
            <div class="box-content" style="background: #fff;">


                <%--General Information Div--%>

                <div class="patient-widget-outer">
                    <div class="patient-widget">
                    
                        <div class="patient-widget-content">
                          
                            <div class="floatL mb-10x width-100p">
                                <span>
                                    <span class="floatL">Insurance: </span><span class="spnError floatL">*</span>
                                </span>
                            
                                    <span class="floatL" style="width:43.8%;margin-left:26px">
                                       
                                        <input type="text" id="txtInsurance" onkeyup ="SetSearch()" class="required1" />
                                        <input type="hidden" id="inusranceid" />
                                        </span>
                                <span class="floatL"style="width:9%">Type:</span><span class="spnError floatL" style="position:absolute;margin-left:-15px">*</span>
                                <span class="floatL " style="width:30%">
                                    <select id="ddlStatus" class="required1">                                       
                                         <option value="Enrolled">Enrolled</option>
                                         <%--<option value="Not Enrolled">Not Enrolled</option>--%>
                                         <option value="Out of Network">Out of Network</option>
                                         <option value="In network">In Network</option>
                                         <option value="In Process">In Process</option>
                                         <option value="Pending With Insurance">Pending With Insurance</option>
                                         <option value="Pending Response from Practice">Pending Response from Practice</option>
                                    </select>
                                   
                                  
                                </span>
                              
                            </div>
                            
                            
                            <%--<div class="floatL mb-10x width-100p">
                                <span class="floatL"style="width:14%">Group:</span>
                                    <span style="width:15%;float:left"><asp:TextBox runat="server" ID="TxtGrouPCode"></asp:TextBox>
                                  
                                </span>
                               <span class="floatR" style="width:70%">
                                   
                                    <asp:TextBox runat="server" ID="TxtGrouPCodeDesc" PlaceHolder="Description"></asp:TextBox>
                                </span>
                            </div>--%>
                         
                             <div class="floatL mb-10x width-100p">
                                <span class="floatL"style="width:14%">Provider:</span>
                                <span class="floatL " style="width:30%">
                                      
                                  <asp:DropDownList id="ddlProciders" runat="server">  
                                            
                                  </asp:DropDownList>  
                                </span>
                                  <span class="floatL"style="margin-left:14%">Source:</span>
                               <span class="floatR" style="width:30%; margin-right:3%">
                                   <select id="ddlSource" onchange="getNpiTaxId()">
                                        <option value="" selected></option>
                                        <option value="Group">Group</option>
                                        <option value="Solo">Solo</option>                                                                                
                                   </select>                              
                                </span>
                            </div>
                             <div class="floatL mb-10x width-100p">
                                <span class="floatL"style="width:14%"><b>NPI:</b></span>
                                   <span class="floatL " style="width:30%">
                                       
                                             <label Id="lblNpi"></label>                            
                                   </span>
                               <span class="floatL"style="margin-left:14%"><b>Tax:</b></span>
                                   <span class="floatR" style="width:30%;margin-right:3%">                                      
                                       <lable Id="lblTax"></lable>
                                   </span>
                             </div>
                            <div class="floatL mb-10x width-100p">                                        
                                     <span class="floatL"style="width:14%">Group PTAN:</span>
                                   <span class="floatL" style="width:30%;margin-right:3%">                                      
                                       <input type="text" id="txtGroupid" class="mb-2p" autocomplete="off" maxlength="15" />
                                   </span>   
                                <span class="floatL"style="margin-left:4.5%">Provider PTAN:</span>
                                   <span class="floatR" style="width:30%;margin-right:3%">                                      
                                       <input type="text" id="txtProvider" class="mb-2p" autocomplete="off" maxlength="15" />
                                   </span>                                        
                                 </div>

                                 <div class="floatL mb-10x width-100p">
                                     <span class="floatL"style="width:14%">Effective Date:</span><span class="spnError floatL" style="position:absolute;margin-left:-8px">*</span>
                                     <span class="floatL" style="width:30%; margin-right:3%">
                                         <input type="text" id="targetDate" class="targetDate required1 mb-2p" autocomplete="off" />
                                     </span>
                                     
                                     <span class="floatL"style="margin-left:4.5%">SSN:</span>
                                   <span class="floatR" style="width:30%;margin-right:3%">                                      
                                       <input type="text" id="txtSSN" class="mb-2p" autocomplete="off" />
                                   </span>                                                                              
                                 </div>

                             <%--<div class="floatL mb-10x width-100p">
                                <span class="floatL"style="width:14%">Notes:</span>
                                    <span class="floatL " style="width:15%">                                  
                                                                         
                                    </span>                             
                             </div>--%>
                            <div class="floatL mb-10x width-100p">
                                     <span class="floatL"style="width:14%">Remarks:</span><span class="spnError floatL" style="position:absolute;margin-left:-34px">*</span>
                                     <span class="floatL" style="width:45%; margin-right:3%">
                                         <textarea id="txtRemarks" cols="70" rows="4" class="required1"></textarea>
                                         <%--<input type="text" id="txtRemarks" class="required1 mb-2p" autocomplete="off" />--%></span>                                          
                                 </div>
                            <div>
                            </div>

                        </div>
                    </div>
                </div> 
 </div>
         <input type="hidden" id="InsuCredentialId" />
         <div id="insuFilterDiv" style="display:none"></div>
            <div class="divDialogDocumentForm" style="display:none"></div>
        </div>
        <div id="divNpiTax" style="display:none"></div>
        ###EndInsuranceCredentialing###
    </div>
       
    </form>

</body>
</html>
