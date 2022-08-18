<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="CustomerTicketsForm.aspx.cs" Inherits="ProviderPortal_CustomerSupport_CustomerTicketsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link type="text/css" href="css/bootstrap.min.css" rel="stylesheet" />
     <link type="text/css" href="css/Support.css" rel="stylesheet" />
     <script type="text/javascript" src="js/bootstrap.min.js"></script>
     <script type="text/javascript" src="js/Support.js"></script>
    
    <link href="../../StyleSheets/BillingManagerTheme.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.12.0-1/css/all.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                    <div><div class="row no-gutters w-100 div1r1 px-3" id="TicketAddForm">
                

            <!--line-->
             <div class="row no-gutters w-100 mt-2">
                <div class="col-12 px-4">
                    <div class="row no-gutters  div1r2">
                        <div class="col-11 div1r21">
                       
                        </div>
                        <div class="col-1">
                         <span onclick="closeEmbedOpenmainPage()" id="mainpagecross" style="float: right;color: black;font-size: 11px;margin-right: 3px;cursor:pointer;">
                   <i class="fa fa-window-close" aria-hidden="true"></i>
                     </span>
                    </div>
                        </div>
                   
            </div>
                      <span class="titlesaveUpdate"></span>
            </div>
            

            <!--line end--->
            <div class="row no-gutters px-4 w-100">
                <div class="col-5 divtext">
                    <asp:Label ID="TicketNo" runat="server" CssClass=" font-weight-bold ml-4 d-inline-block mt-1"></asp:Label>
                 
                </div>
                 <div class="col-7 divtext">
                   <span class="titlesaveUpdate " id="titleupdate" style="display:none;text-align:unset;margin-left:10%">Update Ticket</span>
                </div>
            </div>
            <div class="BodyDivHeight row no-gutters">

                        <div class="col-6 bg-white  Hg450px">
                           <div class="maindiv">
                             
                             

                               <div class="row no-gutters w-100">
                                  <div class="col-6">
                                       <asp:Label ID="Label6"  CssClass="d-block  font-weight-bold mt-3 ml-3 py-2"  runat="server" >Type<sup class="star">*</sup></asp:Label>

                                        <asp:DropDownList runat="server" ID="txtCustomerSupportModuleTypeId" class="ml-3 requester1 required textbox-be">
                                               <asp:ListItem Value="" Text=""></asp:ListItem>
                                       </asp:DropDownList>
                                       
                                   </div>
                                    
                                     <div class="col-6">
                                       <asp:Label ID="Label8"  CssClass="d-block  font-weight-bold mt-3 ml-3 py-2"  runat="server" Text="Status"></asp:Label>
                                          <span class="statusSpan">Open</span> 
                                   </div>

                               
                               </div>

                            <div class="row no-gutters w-100">
                                <div class="col-12">
                                    <asp:Label ID="tquery" CssClass="d-block  font-weight-bold ml-3 mt-3 pb-3 pt-2" runat="server" >Query<sup class="star">*</sup></asp:Label>
                                   
                                    <textarea name="txtQueryQuestion" rows="2" cols="20" id="txtQueryQuestion" class="ml-3 tquery required size"></textarea>

                                </div>


                                 

                            </div>

                                <div class="row no-gutters w-100">
                               <div class="col-12">
                                     <%--  Editedby QasimSaeed 04/02/2020    //required  <sup class="star">*</sup> --%>
                                     <asp:Label ID="tanswer" CssClass="d-block  font-weight-bold ml-3  mt-3 pb-3 pt-2" runat="server" >Answer</asp:Label>
                                   <textarea name="txtQueryAnswer" rows="2" cols="20" id="txtQueryAnswer" class="ml-3 tquery required size" disabled="disabled"></textarea>

                                 
                                </div>
                            <div class="col-12">
                                       <%--<button type="button" class="float-right NewBtnDesign" data-dismiss="modal" style="margin-right: 7%;">Close</button>--%>
                                  <button type="button" class="float-right NewBtnDesign"  onclick="CancelQuery()">Cancel</button>         
                                <button type="button" class="float-right NewBtnDesign"  onclick="AddQuery()">Submit</button>   
                                
                               
                                   </div>
                            </div>

                                  
                           </div>
                        </div>

                        <div class="col-6  bg-white" style="height:450px;">
                        
                         <table class="custom-support-table fixTable" style="width:99.5%;">
                             <thead>
                               <tr>
                                 <th>#</th>
                                 <th>Ticket Type</th>
                                 <th>Status</th>
                                 <th>Query</th>
                                  <th>Answer</th>
                                 <th>Requested on</th>
                                 <th>Action</th>
                               </tr>
                             </thead>
                             <tbody id="GridTbody">
                                 <asp:Repeater runat="server" ID="rpt_MainGrid" OnItemDataBound="rpt_MainGrid_ItemDataBound">
                                     <ItemTemplate>
                                         <tr>
                                             <td><%# Eval("RowNumber") %></td>
                                             <td><%# Eval("ModuleTypeName") %></td>
                                             <td><asp:Label runat="server" ID="lblStatusId"></asp:Label></td>
                                             <td title="<%# Eval("QueryQuestion") %>">
                                                  <asp:Label runat="server" ID="lblQuestion"></asp:Label>
                                             </td>
                                             <td title="<%# Eval("QueryAnswer") %>">
                                                    <asp:Label runat="server" ID="lblAnswer"></asp:Label>
                                             </td>
                                             <td><%# Eval("RequestDate","{0:d}") %></td>
                                            
                                              <td>
               <span onclick="loadQueryData(this,' <%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer" title="Update Ticket"><span><i class="far fa-edit"></i></span></span>
              <%-- <span onclick="DeleteQuery(this,' <%# Eval("CustomerSupportQuryId") %>')"><i class="far fa-trash-alt"></i></span>--%>
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
      <script src="../../Scripts/tableHeadFixer.js"></script>
      <script>
         $(document).ready(function () {
             $(".fixTable").tableHeadFixer();
         });
          </script>
    

</asp:Content>


