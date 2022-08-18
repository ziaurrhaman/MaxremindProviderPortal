<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketsHandler.aspx.cs" Inherits="EMR_Settings_Ticketing_AddTickets" %>

<!DOCTYPE html>
<%-- Start File Added By Rizwan kharal 16April2018 --%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###Start###
        <style>

            #btnUploadMessageAttachments
            {
                color:blue;
                text-decoration:underline;
            }

            .attachment-icon-messages{
                background: url("../../../Images/gmail-icon-bar.png") no-repeat scroll 0 -374px transparent;
                float: left;
                height: 20px;
                width: 20px;
            }
            .attachment-icon
{
    background: url("../../../Images/gmail-icon-bar.png") no-repeat scroll 0 -374px transparent;
    float: left;
    height: 20px;
    width: 20px;
}
        </style>
        <script type="text/javascript">

            //Added By:Syed Sajid Ali Date:11/30/2017 in HHA description:For Upload File And Delete File Attachment
            //Function For Attachment File

            


            $(function () {
                debugger;
                new AjaxUpload('#btnUploadMessageAttachments', {
                    action: '../Settings/Ticketing/CallBacks/AttachmentUploadHandler.ashx',
                    dataType: 'json',
                    contentType: "application/json; charset=uft-8",
                    onSubmit: function (file, ext, fileSize) {

                        if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                            showErrorMessage('Error: invalid file extension');
                            return false;
                        }

                        if (fileSize > 10) {
                            showErrorMessage("This file exceeds the 10MB attachment limit.");
                            return false;
                        }

                        var attachmentRow = '<tr class="attachments">';
                   
                        attachmentRow += '<td style="float:left;margin-left:28%;width:100%">';
                        attachmentRow += '<span class="attachment-icon-messages"></span>';
                        attachmentRow += '<span id="spnAttachmentName" class="attachment-name" style="float:left">' + file + '</span>';
                        attachmentRow += '<div id="divProgressBar"><img src="../../../Images/progressbar.gif"/> <span onclick="request.abort();">Cancel</span></div>';
                        attachmentRow += '</td>';
                        attachmentRow += '</tr>';

                        $(".tr-upload-file-messages").before(attachmentRow);
                    },
                    onComplete: function (file, response) {
                        debugger
                        var responseHTML = $(response);
                        var r = responseHTML.html();
                        var res = $.parseJSON(r);

                        $(".tr-upload-file-messages").prev().find("#divProgressBar").html('<img src="../../../Images/-delete.png" class="attachment-remove" onclick="RemoveAttachmentConfirmation(this);"/>');
                        //Changes By Syed Sajid Ali Date:11/21/20167
                        $("#spnAttachmentName").attr("id", _ResolveUrl + "PracticeDocuments/" + "TicketingDocuments/" + res.path);
                        // $("#spnAttachmentName").attr("id", _ResolveUrl + "AgencyDocuments/" + $.trim($("[id$='hdnMasterAgecyId']").val()) + "/AgencyDocumentFiles/" + res.path);
                        //End By Syed Sajid Ali
                        showSuccessMessage("Attach File Sucessfully");
                        $("#attach-link").html("Attach another file");
                        $("#btnUploadMessageAttachments").css("width", "106px");
                    }
                });
            });

         

        </script>


      <div class="TicketingFilterBox1" style="margin-bottom:10px;margin-top:10px;">

          <table style="width:100%">
              <tbody>
                  <tr>
                      <td style="font-weight:bold;float:left;width:30%;padding-top: 8px;">Title:</td>
                      <td style="float:left;width:69%;padding-top:8px;box-sizing: border-box;">
                  <asp:TextBox runat="server" CssClass="required" ID="TxtTitle" Style="width: 100%;box-sizing:border-box;margin-bottom:5px;" MaxLength="350" ToolTip="More Than 350 Character is Not Allowed"></asp:TextBox>
                          <asp:Label runat="server" ID="lblTitle" style="display:none"></asp:Label>
                     </td>
                  </tr>

                  <tr>
                       <td style="font-weight:bold;float:left;width:30%;padding-top: 8px;">Category:</td>
                       <td style="float:left;width:69%;padding-top:8px;box-sizing: border-box;">
                     <asp:DropDownList id="txtCategory" runat="server" Style="width:100% !important;margin-bottom:5px;">
                
                <asp:ListItem Value="Bug">Bug</asp:ListItem>
                <asp:ListItem Value="Suggestion">Suggestion</asp:ListItem>
                <asp:ListItem Value="Query">Query</asp:ListItem>
              </asp:DropDownList>
                              <asp:Label runat="server" ID="lblCategory" style="display:none"></asp:Label>
                     </td>
                  </tr>

                    <tr>
                       <td style="font-weight:bold;float:left;width:30%;padding-top: 8px;">Priority:</td>
                       <td style="float:left;width:69%;padding-top:8px;box-sizing: border-box;">
                     <asp:DropDownList id="txtPriority" runat="server" Style="width:100% !important;margin-bottom:5px;">
                
                <asp:ListItem Value="High">High</asp:ListItem>
                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                <asp:ListItem Value="Low">Low</asp:ListItem>
              </asp:DropDownList>
                               <asp:Label runat="server" ID="lblPriority" style="display:none"></asp:Label>
                     </td>
                  </tr>

                     <tr>
                       <td style="font-weight:bold;float:left;width:30%;padding-top: 8px;">Status:</td>
                       <td style="float:left;width:69%;padding-top:8px;box-sizing: border-box;">
                     <asp:DropDownList id="txtStatus" runat="server" Style="width:100% !important;margin-bottom:5px;">
                  
                <asp:ListItem Value="Resolved">Resolved</asp:ListItem>
                <asp:ListItem Value="Pending">Pending</asp:ListItem>
                <asp:ListItem Value="In Progress">In Progress</asp:ListItem>
                <asp:ListItem Value="Reopen">Reopen</asp:ListItem>
                <asp:ListItem Value="Not An Issue">Not An Issue</asp:ListItem>
              </asp:DropDownList>
                 <asp:Label runat="server" ID="lblStatus" style="display:none"></asp:Label>
                     </td>
                  </tr>

                  <tr>
                       <td style="font-weight:bold;float:left;width:30%;padding-top:38px;padding-top: 8px;">Description:</td>
                       <td style="float:left;width:69%;padding-top:8px;box-sizing: border-box;">
                              <asp:TextBox id="TxtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" Style="width: 100%;margin-bottom:5px;box-sizing:border-box"/>
                          <asp:Label runat="server" ID="lblDescription" style="display:none"></asp:Label>
                              </td>

                                          
                  </tr>
                  <tr class="tr-upload-file-messages" style="display:block !important;">
                       <td style="font-weight:bold;float:left;width:30%;">Attach File:</td>
                    <td style="float:left;width:69%;padding-top:8px;box-sizing: border-box;">

                    <div class="attachment-wrapper-messages" id="uploadAttachFile">
                    <div id="divUploadMessages" style="width:100%;">
                         <label  id="btnUploadMessageAttachments" size="1" > Attach file</label>
                       
                       
                        
                      
                    </div>
                </div>
                      </td>
                  </tr>

   


                  <tr id="rpt_tr"> 
                      
 
               <asp:Repeater runat="server" ID="rptAttachment" OnItemDataBound="rptTicketsDocuments_ItemDataBound" >
                 <ItemTemplate>
                     <td colspan="2" style="width:100%;float:left;">
                         <div style="width:100%;float:left;">
                          <input type="hidden" class="TicketAttachmentId" value='<%#Eval("TicketAttachmentsId") %>' />
                         <span  id="divProgressBar"> <asp:Literal runat="server" ID="ltrAttachment"></asp:Literal><img src="../../../Images/-delete.png" class="attachment-remove" onclick="RemoveAttachmentConfirmation(this);"> </span>
                     <img class="ViewEyeclass" src="../../Images/ViewEye.png"  onclick="SetPendingViewDocuments21('<%#Eval("TicketAttachmentsId") %>','<%#Eval("FileName") %>','<%#Eval("AttachmentPath") %>');" style="margin-top:5px;margin-left:10px">
                         </div>
                     </td>                                     
                 </ItemTemplate>
              
             </asp:Repeater>
                  </tr>
              </tbody>
          </table>

      </div> 
            <asp:HiddenField runat="server" ID="hdnPracticeId" />
            

        ###End###


          
           ###StartHandler### 
              <asp:Repeater runat="server" ID="RptTickets">
                                                <ItemTemplate>
                                                    <tr onclick="TicketDetails(<%# Eval("TicketId") %>)" style="cursor:pointer" >
                                                    <td><%# Eval("RowNumber") %></td>
                                                    <td><%# Eval("TicketId") %></td>
                                                     <td><%# Eval("Title") %></td>
                                                     <td><%# Eval("Description") %></td>
                                                     <td><%# Eval("Category") %></td>
                                                     <td><%# Eval("CreatedBy") %></td>
                                                     <td><%# Eval("CreatedDate") %></td>
                                                     <td><%# Eval("Priority") %></td>
                                                    <td><%# Eval("Status") %></td>
                                                    

                                                  </tr>
                                                </ItemTemplate>
                                                
                                            </asp:Repeater>
            <asp:HiddenField ID="hdnTicketsTotalRows" runat="server" />
       ###EndHandler###
     
        ###StartConformationDialog###
        <span>
            <label id="messageTciket">Do you want to delete this ticket ?</label> 
             <label id="messageAttachment">Do you want to delete this attachment ?</label> 
        </span>
        ###EndConformationDialog###

            </div>


        
     
   




    </form>
</body>
</html>
