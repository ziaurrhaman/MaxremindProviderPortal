<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="GenerateTicket.aspx.cs" Inherits="ProviderPortal_CustomerSupport_GenerateTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link type="text/css" href="css/bootstrap.min.css" rel="stylesheet" />
     <link type="text/css" href="css/Support.css" rel="stylesheet" />
     <script type="text/javascript" src="js/bootstrap.min.js"></script>
     <script type="text/javascript" src="js/Support.js"></script>
    
    <link href="../../StyleSheets/BillingManagerTheme.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    
     <script type="text/javascript">

        
       
         $(function () {
            
             uploadfilenew();
         });



        </script>
    <div class="MiangenerateTicketing">

        <div class="LeftgenerateTicketing">

          <div class="divgenerateTicket" id="divgenerateTicket" >
         
             <div id="FormMaindiv">

                 <div id="FormTitle" class="FormMarginTop"> 
                     <span> Generate Ticket </span>
                 </div>

                   <div id="FormTitleNo" class="FormMarginTop">
                     <span class="FormTitleNoLS"> Ticket No. </span>
                     <span class="FormTitleNoRS"> <asp:Label runat="server" ID="lblTitleNo"></asp:Label> </span>
                 </div>

                  <div id="FormDDlSide" class="FormMarginTop">

                  <div id="FormDDlSideLS">
                      <table>
                          <tbody>
                              <tr>
                                  <td class="lblFontSetting">Ticket Type</td>
                              </tr>
                               <tr>
                                  <td>
                                      <asp:DropDownList id="ddlTyp" runat="server" CssClass="required">
                             <asp:ListItem></asp:ListItem>
                             <asp:ListItem Value="Complaint">Complaint</asp:ListItem>
                             <asp:ListItem Value="Suggestion">Suggestion</asp:ListItem>
                             <asp:ListItem Value="General">General</asp:ListItem>
                             <asp:ListItem Value="Other">Other</asp:ListItem>
                       </asp:DropDownList>
                                  </td>
                              </tr>
                               <tr >
                                  <td class="lblFontSetting">Patient</td>
                              </tr>
                               <tr>
                                  <td>
                <input type="text" id="txtPatientId" placeholder="Search Patient" class="searchicon required" onkeyup="setSearchePatient(event)" />
                                      <div class="divpatientsearch Grid">
                                          <table>
                                              <thead style="text-align:center">
                                                  <tr>
                                                         <th> Patient Name <span id="closeiconxbutton" onclick="closeiconxbuttonFunc()">X</span>  </th>
                                                  </tr>
                                                 
                                              </thead>
                                              <tbody class="" id="searchpatientdiv">
                                                   
                                              </tbody>
                                          </table>
                                        
                                      </div>
                                 

                                  </td>
                              </tr>
                              <tr>
                                  <td class="lblFontSetting">
                                      Priority
                                  </td>
                              </tr>
                              <tr>
                                  <td>

                                  
                               <asp:DropDownList id="ddlpri" runat="server" CssClass="required">
                               <asp:ListItem></asp:ListItem>
                               <asp:ListItem>High</asp:ListItem>
                               <asp:ListItem>Medium</asp:ListItem>
                               <asp:ListItem>Low</asp:ListItem>
                        </asp:DropDownList>
                                      </td>
                              </tr>
                          </tbody>
                      </table>
                  </div>

                  <div id="FormDDlSideRS">
                      <table>
                          <tbody>
                              <tr>
                                  <td class="lblFontSetting">Problem Related To</td>
                              </tr>
                               <tr>
                                  <td>
                                    <asp:DropDownList id="ddlTRTo" runat="server" onchange="SelectTRT()" CssClass="required"> 
                                 <asp:ListItem></asp:ListItem>
                                 <asp:ListItem Value="Patient">Patient</asp:ListItem>
                                 <asp:ListItem Value="Claim">Claim</asp:ListItem>
                                 <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                                 <asp:ListItem Value="Eligibility">Eligibility</asp:ListItem>
                          </asp:DropDownList>
                                  </td>
                              </tr>
                               <tr>
                                  <td class="lblFontSetting">DOS</td>
                              </tr>
                               <tr>
                                  <td>
                <input type="text" id="txtDOS" class="searchicon required"/>
                                  </td>
                              </tr>
                              <tr>
                                  <td class="lblFontSetting">
                                      Status
                                  </td>
                              </tr>
                              <tr>
                                  <td>
                                         <input type="text" id="txtStatus"  value="New" disabled="disabled"/>
                                      </td>
                              </tr>
                          </tbody>
                      </table>
                  </div>

              </div>


              <div id="FormNotes" class="FormMarginTop">
                  <textarea id="txtFormNotesNote" cols="8" rows="6" placeholder="Write your comment"></textarea>
              </div>

                 <div id="FormAttach" class="FormMarginTop"> 
                     <div class="FormUploadMessageAttachments" id="btnUploadMessageAttachments">
                         <span class="FormUploadLS"><img src="img/25662upload.png" width="128px" height="30px" /></span>
                         
                         
                         </div>


                     <div class="attachmentdivside">

                         <table>
                             <tbody id="attachmentdivsidetbody">
                                 
                             </tbody>
                         </table>
                             <table>
                             <tbody>
                                   <tr class="tr-upload-file-messages" style="display:block !important;">
                 
                    <td style="float:left;width:69%;padding-top:8px;box-sizing: border-box;">

                    <div class="attachment-wrapper-messages" id="uploadAttachFile">
                    <div id="divUploadMessages" style="width:100%;">
                         
                    </div>
                </div>
                      </td>
              </tr>
                             </tbody>
                         </table>
                     </div>

                 </div>
                 <div id="btndiv" class="FormMarginTop">
                    <span> <input type="button" id="btnCancelticket" value="Cancel" onclick="clearform()" /></span> 
                     <span> <input type="button" value="Save" id="btnSaveticket" onclick="AddNewTickets()" /></span> 
                 </div>
             </div>

        
       </div>

        </div>

        <div class="RightgenerateTicketing">

          

              <div id="generateTicketing">

                 
    
       <div class="Body_Section tablebox" id="maindiv">

            <div id="FormGridTitle" class="FormMarginTop1">
                     <span> Track Ticket </span>
                 </div>

           <div class="leftrightmargin">

           <div id="FilterTicketMain" class="FormMarginTop1">

                  <div id="FilterTicket">

                      <div id="FilterTicketLS">
                          <table>
                          <tbody>
                              <tr>
                                  <td class="lblFontSetting">Ticket No.</td>
                              </tr>
                               <tr>
                                  <td>
                                       <input type="text" id="txtTicketNo" placeholder="Enter Ticket No." maxlength="10" onkeyup="setSearcheFilter(event)"/>
                                  </td>
                              </tr>
                             
                            
                          </tbody>
                      </table>
                      </div>
                       <div id="FilterTicketMS">
                           <table>
                          <tbody>
                            
                               <tr >
                                  <td class="lblFontSetting">Date From</td>
                              </tr>
                               <tr>
                                  <td>
                                  <input type="text" id="txtDateForm" placeholder="Select Date"/>
                                  </td>
                              </tr>
                            
                          </tbody>
                      </table>

                           <div class="NoRecordFound"> No Record Found </div> 

                       </div>
                       <div id="FilterTicketRS">
                           <table>
                          <tbody>
                              
                              <tr>
                                  <td class="lblFontSetting">
                                
                                      DateTo
                                  </td>
                              </tr>
                              <tr>
                                  <td>
                                        <input type="text" id="txtDateTo" placeholder="Select Date"/>
                                      </td>
                              </tr>
                          </tbody>
                      </table>
                       </div>

                  </div>
               </div>
            <div id="FilterTicketSearchBtn" class="FormMarginTop1">
                <input type="button" value="Search" id="btnSearch" onclick="FilterGenTickets(0, true);" />
            </div>
               <script src="../../Scripts/tableHeadFixer.js" type="text/javascript"></script>
               <script>
                   $(document).ready(function () {

                       $(".fixTable").tableHeadFixer();
                   });
               </script>
               <div>
           <table class="fixTable table table-responsive tableHeight">
            <thead class="theadclass">
             <tr>
                      
                        <th style="width:10%">
                           Ticket No.
                         </th>
                  <th style="width:38%">
                          Description
                        </th>
                        <th style="width:12%">
                           Ticket Type
                        </th>
                        
                        <th style="width:10%">
                         Status
                        </th>
                      <th style="width:13%">
                         Generated Date
                        </th>
                      
                    
                        
                        <th style="width:8%">
                         Priority
                        </th>
                     <th style="width:11%">
                         Action
                        </th>
                </tr>
          
            </thead>
            <tbody id="tbodyGT" class="tbodyclass">
            <asp:Repeater runat="server" ID="rpt_GenTic">
                <ItemTemplate>
                 <tr>
                 
                      <td> <%# Eval("CSTicketsId") %></td>
                     <td class="ClassTextLeft"><%# Eval("Description") %></td>
                      <td class="ClassTextLeft"><%# Eval("TicketType") %></td>
                     
                     
                     
                      <td class="ClassTextLeft"><%# Eval("Status") %></td>
                      <td><%# Eval("DOS","{0:d}") %></td>
                      
                      <td class="ClassTextLeft"><%# Eval("Priority") %></td>
                    <td>
                     <span class="spnedit" title="Edit" onclick="UpdateTickets(this);"></span>
                   <span class="spndelete" title="Delete" onclick="DeleteTicket(<%# Eval("CSTicketsId") %>);" style="margin-left: 5px;"></span>
                                   <%--  <span class="spneview24" title="View" onclick="UpdateTickets(this);"></span>--%>
                                    
                                 
                   </td>
                    <td style="display:none"><%# Eval("ProblemRelatedTo") %></td>
                    <td style="display:none"><%# Eval("PatientName") %></td>
                     <td style="display:none"><%# Eval("PatientId") %></td>
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
   
   
    <asp:HiddenField ID="hdnTotalRows" runat="server" />
    <div id="divDialogDocuments_Viewer"></div>
    <div id="Conformationdialog"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

