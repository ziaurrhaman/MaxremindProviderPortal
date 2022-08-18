<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="ProviderPortal_CustomerSupport_Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link type="text/css" href="css/bootstrap.min.css" rel="stylesheet" />
     <link type="text/css" href="css/Support.css" rel="stylesheet" />
     <script type="text/javascript" src="js/bootstrap.min.js"></script>
     <script type="text/javascript" src="js/Support.js"></script>
        <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
     <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.js"></script>
    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.12.0-1/css/all.min.css" />
    <script src="../../Scripts/ajaxupload.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <div>
         <asp:HiddenField ID="hdnusername" runat="server" />
         <asp:HiddenField ID="hdnuserid" runat="server" />
         <div class="row mt-3 maindiv">
              

            <%-- <div class="col-1 pl-3 ml-4 bg-white shadow-lg borderradius">
             <div class="row pt-2 bg-1" style="height:40px;"><span class="spantoptext">Happy To Help</span></div>
                    <div class="row pb-5 mt-4">
                     <div class="col-12">
                         <span onclick="GenerateTicket()" class="cursorpointer">
                             
                            <img src="img/256 x 256 ticket.PNG" class="imgsize1"/>
                             <b class="bold-text pl-0 mt-2  border-bottom">Generate Ticket</b>
                      </span>
                     </div>
                 </div>

                 
               <div class="row pb-5">
                     <div class="col-12">
                         <span onclick="email()" class="cursorpointer">
                              <img src="img/256 x 256 email.png" class="imgsize"/><br/>
                              <b class="bold-text pl-3 pr-3 border-bottom">email us</b>
                        </span>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-12">
                            <img src="img/256 x 256 msg.PNG" class="imgsize"/><br/>
                            <b class="bold-text pl-3 pr-3 border-bottom">Live Chat</b>
                     </div>
                 </div>
              
             </div>--%>


          <div class="col-9 pl-3 ml-3 masterdiv w-100 borderradius"> 
              <div class="col-12 mr-3 bg-white w-100" id="maindiv1" style="max-width:100%; ">
                 <div class="row pt-2 bg-1">
                    <div class="col-md-2 ">
                
                                <asp:Label ID="Label1"  CssClass="label" runat="server" Text="Total Tickets"></asp:Label>
                    </div>
                     <%--<div class="col-2">
                          <label class="label1 mt-1">Select Dates</label>
                         </div>--%><div class="col-1"></div>
                       <div class="col-9 px-0">
                           <div class="row justify-content-end">
                              <%-- <div class="col-md-3 textbox px-0">
                                   <asp:TextBox ID="Date1" class="h-100 border-0  fontall calendericon" runat="server" placeholder="Date From"></asp:TextBox>
                     
                               </div>
                                 <div class="col-md-3 textbox px-0">
                         <asp:TextBox ID="Date2" CssClass="h-100 border-0 calendericon " placeholder="Date To"  runat="server"></asp:TextBox>
                    </div>

                     <div class="col-md-1 px-0 mr-1">
                    <input type="button" id="RefreshDates" onclick="RefreshTabs()" value="Search" style=""/>
                           
                    </div>--%>
                            <div class="col-2 px-0 mr-1">
                         <input type="button" id="RefreshDates1" onclick="GenerateTicket()" value="Generate Ticket" style=""/>

                     </div>
                           </div>
                        
                   
                          
                     </div>
                    
                 </div>
                 <div class="row mt-1" id="paggingdiv">
                   
                     <div class="col-12 px-0" style="height:350px;overflow:hidden !important;" >
                         <table class="table table-striped fixTable" style="overflow:hidden;">
                             <thead>
                                   <tr >
                                 <th>#</th>
                                <th>Ticket#</th>
                                 <th class="removespace">Subject</th>
                                 <th>Description</th>
                                 <th>Ticket Date</th>
                                  <th>Status</th>
                                 <%--<th class="removespace">Response</th>--%>
                                       
                                 <th>Action</th>
                               </tr>
                                                 <tr class="tbborder">
                    <th >
                        <i class="fa fa-filter" style="color: #065172; font-size: 20px !important;" id="FilterIcon" onclick="FilterGenTickets(0, true)"></i>
                    </th>
                   <th>
                        <input type="text" id="tktnumber" onkeyup="SetSearch(event)" />
                    </th>
                    <th>
                        <input type="text" id="txtsubject" onkeyup="SetSearch(event)"  />
                    </th>
                    <th>
                        <input type="text" id="txtdescription" onkeyup="SetSearch(event)" />
                    </th>
                    <th>
                        <input type="text" id="tktdate"/>
                    </th>
                    <th>
                        <select id="ddlstatussearch" runat="server" style="width: 100%;" onchange="FilterGenTickets(0,true)" class="select">
                            <option value=""> </option>
                        </select>
                    </th>
                   <%-- <th>
                        <asp:TextBox runat="server" ID="txtresponse" onkeyup="SetSearch(event)"></asp:TextBox>

                    </th>--%>
                   <th></th>
                <!-- End changes-->
                </tr>
                             </thead>
                             <tbody id="TbodySupport">
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

                                
                            
                             </tbody>
                         </table></div>
                         <div class="message">
            <span class="iconInfo" style="margin: 7px;"></span>
            <span class="spanInfo"></span>
          
        </div>
                         <div class="pager">
            <div class="PageEntries">
                <span style="float: left;">
                    <select id="ddlPagingTickets" style="margin-top: 5px;" onchange="RowsChange('FilterGenTickets');">
                        
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
                    <asp:HiddenField runat="server" ID="hdnTotalRows" />  
                 </div>
             </div>
              
             
             </div>
             
             <div class="masterclass1 borderradius  col-2  bg-white  shadow-lg">

             <div class="anotherclass col-12  bg-white  shadow-lg">
                 <div class="row marginclass mt-2">
                     <div class="col-5 bg-inf ml-3 cursorpointer" onclick="TotalTicket();">
                         <div class="row pb-2">
                             <div class="col-12">
                                 <small style=" font-size:11px !important;">Total Tickets</small>
                             </div>
                         </div>
                         <div class="row pb-2">
                             <div class="col-8">
                                 <img src="../../Images/ticket1.png" />
                             </div>
                             <div class="col-4">
                                 <small><asp:Label runat="server" ID="TotalTicketsCount"></asp:Label></small>
                             </div>
                         </div>
                     </div>
                     <div class="col-5 ml-2 bg-inf  cursorpointer" onclick="CloseTicket();">
                           <div class="row pb-2">
                             <div class="col-12">
                                 <small style=" font-size:11px !important;">Close Tickets</small>
                             </div>
                         </div>
                         <div class="row pb-2">
                             <div class="col-9">
                                 <img src="../../Images/ticket1.png" />
                             </div>
                             <div class="col-2">
                                 <small><asp:Label runat="server" ID="TotalTicketsClose"></asp:Label></small>
                             </div>
                         </div>
                     </div>
                 </div>
                 <div class="row marginclass mt-2">
                     <div class="col-5 bg-inf ml-3 cursorpointer" onclick="OpenTicket();">
                         <div class="row  pb-2">
                             <div class="col-12">
                                 <small style=" font-size:11px !important;">Open Tickets</small>
                             </div>
                         </div>
                         <div class="row">
                             <div class="col-8">
                                 <img src="../../Images/ticket1.png" />
                             </div>
                             <div class="col-4">
                                 <small><asp:Label runat="server" ID="TotalTicketsOpen"></asp:Label></small>
                             </div>
                         </div>
                     </div>
                     <div class="col-5 bg-inf ml-2 cursorpointer" onclick="InProcess();">
                         <div class="row  pb-2">
                             <div class="col-12">
                                 <small style="white-space:nowrap; font-size:11px !important;">InProcess Tickets</small>
                             </div>
                         </div>
                         <div class="row pb-2">
                             <div class="col-9">
                                 <img src="../../Images/ticket1.png" />
                             </div>
                             <div class="col-3">
                                 <small><asp:Label runat="server" ID="TotalTicketsInProcess"></asp:Label></small>
                             </div>
                         </div>
                     </div>
                      <div class="col-5 bg-inf ml-3 mt-2 cursorpointer" onclick="ProviderReview();">
                         <div class="row  pb-2">
                             <div class="col-12">
                                 <small style="white-space:nowrap; font-size:11px !important;">Provider Review Tickets</small>
                             </div>
                         </div>
                         <div class="row pb-2">
                             <div class="col-9">
                                 <img src="../../Images/ticket1.png" />
                             </div>
                             <div class="col-3">
                                 <small><asp:Label runat="server" ID="TotalTicketsProviderreview"></asp:Label></small>
                             </div>
                         </div>
                     </div>
                 </div>
                 <div class="row mt-4 pb-3">
                    <div class="col-md pl-3">
                    <div id="chart1">
                   
                           <canvas id="pie-chart1"></canvas>  
                  
                 
                        </div>
                    </div>
                    <div class="col-3"></div>
                 </div>
                 <div class="row removespace" >
                     <div class="col-3 mr-3">
                         <i id="circle-icon" class="fa fa-circle"></i>
                         <label class="ticket-label">Open Tickets</label>
                     </div>
                     <div class="col-4">
                         <i id="circle-icon1" class="fa fa-circle"></i>
                         <label class="ticket-label">Close Tickets</label>
                     </div>
                     <div class="col-4">
                         <i id="circle-icon2" class="fa fa-circle"></i>
                         <label class="ticket-label">InProcess</label>
                     </div>
                     <div class="col-4">
                         <i id="circle-icon3" class="fa fa-circle"></i>
                         <label class="ticket-label">Provider Review</label>
                     </div>
                 </div>
             </div>
             <div id="embdiv" style="display:none; height:470px; width:600px;margin-left:-300PX; background:white;" ></div>
         </div>
    </div>
         <div class="row mt-3 hidediv" style="display:none;"></div>
       
</div>
    <script src="../../Scripts/tableHeadFixer.js"></script>
     <script>
         $(document).ready(function () {
             $(".fixTable").tableHeadFixer();
             debugger
             var opent = $("[id$='TotalTicketsOpen']").text();
             var closet = $("[id$='TotalTicketsClose']").text();
             var InProcess = $("[id$='TotalTicketsInProcess']").text();
             var ProviderReview = $("[id$='TotalTicketsProviderreview']").text();
             var ctx1 = document.getElementById("pie-chart1").getContext("2d");
            
             new Chart(ctx1, {
                 type: 'pie',

                 data: {
                     responsive: false,

                     labels: ["Opne", "Close", "InProcess","Provider Review"],
                     datasets: [{
                         label: "Population (millions)",
                         backgroundColor: ['#006291', '#ff8200', 'red','green'],
                         data: [opent, closet, InProcess, ProviderReview]
                     }]
                 },
                 options: {
                     legend: {
                         display: false
                     },


                 },

             });


         });
         debugger
        
         $(function () {
             $("[id$='Date1']").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 yearRange: "-5 : +5",
             }).mask("99/99/9999");

             $("[id$='Date2']").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 yearRange: "-5 : +5",

             }).mask("99/99/9999");
         });
         $("[id$='tktdate']").datepicker({
             changeMonth: true,
             changeYear: true,
             maxDate: new Date(),
             yearRange: "-110:+0",
             onSelect: function (date, obj) {
                 FilterGenTickets(0, true);
             }
         }).mask("99/99/9999");

           </script>
    <script src="js/CSQChat.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


