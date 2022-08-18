<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateTicketForm.aspx.cs" Inherits="ProviderPortal_CustomerSupport_newwebform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       ###StartModel###
      
    <div id="GenticketDialogue" class="BodyDivHeight1 row no-gutters" style="display:none;width:100% !important">
         <div class="col-12 bg-white  Hg450px">
               <span onclick="closeEmbedOpenmainPage()" id="mainpagecross"  style="float: right;color: black;font-size: 11px;margin-right: 3px;cursor:pointer; mar">
                   <i class="fa fa-window-close" aria-hidden="true"></i>
                     </span>
                           <div class="maindiv">
                             <div class="px-3 mt-3">
                               <div class="col-md-12 ContactUs1">
                                <div class="CU">
                                       <h5>
                                           <asp:Label ID="ticket" runat="server" Text="Ticket"></asp:Label></h5>
                                 </div>
                                </div></div>

                               <div class="row no-gutters w-100 ml-3">
                                  <div class="col-6">
                                       <asp:Label ID="Label12"  CssClass="d-block  font-weight-bold mt-3 ml-3 py-2"  runat="server" >Type<sup class="star">*</sup></asp:Label>

                                        <asp:DropDownList runat="server" ID="txtCustomerSupportModuleTypeId" class="ml-3 requester1 required textbox-be">
                                               <asp:ListItem Value="" Text=""></asp:ListItem>
                                       </asp:DropDownList>
                                       
                                   </div>
                                    
                                     <div class="col-6">
                                       <asp:Label ID="Label8"  CssClass="d-block  font-weight-bold mt-3 ml-3 py-2"  runat="server" Text="Status"></asp:Label>
                                          <span class="statusSpan">Open</span> 
                                   </div>

                               
                               </div>

                            <div class="row no-gutters w-100 ml-3">
                                <div class="col-12">
                                    <asp:Label ID="tquery" CssClass="d-block  font-weight-bold ml-3 mt-3 pb-3 pt-2" runat="server" >Query<sup class="star">*</sup></asp:Label>
                                   
                                    <textarea name="txtQueryQuestion" rows="120" cols="120" id="txtQueryQuestion" class="ml-3 tquery required "></textarea>

                                </div>



                                 

                            </div>

                                <div class="row no-gutters w-100 ml-3">
                               <div class="col-12">
                                     <%--  Editedby QasimSaeed 04/02/2020    //required  <sup class="star">*</sup> --%>
                                     <asp:Label ID="tanswer" CssClass="d-block  font-weight-bold ml-3  mt-3 pb-3 pt-2" runat="server" >Answer</asp:Label>
                                   <textarea name="txtQueryAnswer" rows="60" cols="50" id="txtQueryAnswer" class="ml-3 tquery required size" disabled="disabled"></textarea>

                                 
                                </div>
                       
                            </div>
                              <div class="row no-gutters w-100 mt-2">
                               <div class="col-11">
                                   <div class="row">
                                       <div class="col-6"></div>
                                       <div class="col-6">
                                           <input type="button" id="RefreshDates2" onclick="closeEmbedOpenmainPage()" value="Cancal" style=""/>
                                     <input type="button" id="RefreshDates3" onclick="AddQuery()" value="Save" style=""/>
                                       </div>
                                   </div>
                                    

                                 
                                </div>

                                  
                           </div>
                        </div>
          
    </div>
    ###EndModel###

    </div>
    </form>
</body>
</html>
