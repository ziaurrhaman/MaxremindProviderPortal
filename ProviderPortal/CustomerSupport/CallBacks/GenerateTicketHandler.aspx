<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateTicketHandler.aspx.cs" Inherits="ProviderPortal_CustomerSupport_CallBacks_GenerateTicketHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        

    ###Start###
        <div>
                                 <asp:Repeater runat="server" ID="rpt_MainGrid" OnItemDataBound="rpt_MainGrid_ItemDataBound">
                                     <ItemTemplate>
                                           <tr class="searchTR">
                                             <td><%# Eval("RowNumber") %></td>
                                               <td class="text-center"><%# Eval("CustomerSupportQuryId") %></td>
                                             <td class="text-center"><%# Eval("Subject") %></td>
                                               <td class="text-center" title="">
                                                  <asp:Label runat="server" ID="Descriptions"></asp:Label>
                                             </td>
                                               
                                               <td class="text-center"><%# Eval("RequestDate","{0:d}") %></td>
                                             <td class="text-center"><%# Eval("StatusName") %></td>
                                             
                                               
                                             <%--<td class="text-center" title="<%# Eval("Response") %>">
                                                    <asp:Label runat="server" ID="lblAnswer"></asp:Label>
                                             </td>--%>
                                             
<%--                                               <td><%# Eval("ModifiedDate","{0:d}") %></td>--%>
                                            
                                              <td class="text-center removespace">
<%--              <span onclick="ViewQueryData(this,' <%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer" title="View Ticket"><span><img src="../../Images/view1.png"/></span></span>&nbsp;--%>
               <span onclick="GenerateTicket(' <%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer" title="Update Ticket"><span><i class="far fa-edit"></i></span></span>
               <span onclick="DeleteThisTicket('<%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer;"><i class="far fa-trash-alt"></i></span>
                                              </td>
                                         </tr>
                                     </ItemTemplate>
                                 </asp:Repeater>

                                
                            
                         

        <asp:HiddenField ID="hdnrows" runat="server" />
</div>
        ###End###


        ###StartAtt###
             <%-- OnItemDataBound="rptTicketsDocuments_ItemDataBound" --%>
               
                             <asp:Repeater runat="server" ID="rptAttachment"  >
                 <ItemTemplate>
                     <tr class="attachments">
                     <td colspan="2" style="width:100%;float:left;">
                         <div>
                          <input type="hidden" class="TicketAttachmentId" value='<%#Eval("CSAttachmentsId") %>' />
                            <span id='<%#Eval("AttachmentPath") %>' class="attachment-name" style="float:left"><%#Eval("FileName") %></span>
                         <span  id="divProgressBar">
                             <img src="../../Images/-delete.png" class="attachment-remove" onclick="RemoveAttachmentConfirmation(this);"> 
                              <img class="ViewEyeclass" src="../../Images/ViewEye.png"  onclick="SetPendingViewDocuments21('<%#Eval("CSAttachmentsId") %>','<%#Eval("FileName") %>','<%#Eval("AttachmentPath") %>');" style="margin-top:5px;margin-left:10px">
                         </span>
                           
                 
                         </div>
                     </td>  
                         </tr>      
                         
                 </ItemTemplate>
              
             </asp:Repeater>
                  
             
        ###EndAtt###


         ###StartPat###
         <asp:Repeater runat="server" ID="rptPatient"  >
                                           <ItemTemplate>
                     <tr onclick="selectPatientName('<%#Eval("PatientName") %>','<%#Eval("PatientId") %>')">
                     <td style="text-align:left" ><%#Eval("PatientName") %> </td>  
                         </tr>                                   
                 </ItemTemplate>
              
                                            </asp:Repeater>
         ###EndPat###


            ###StartConformationDialog###
        <span>
            <label id="messageTciket">Do you want to delete this ticket ?</label> 
             <label id="messageAttachment">Do you want to delete this attachment ?</label> 
        </span>
        ###EndConformationDialog###

            </div>


    </div>
    </form>
</body>
</html>
