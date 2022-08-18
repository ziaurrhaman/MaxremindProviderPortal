<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tickets.aspx.cs" Inherits="EMR_Settings_Ticketing_Tickets" %>

<!DOCTYPE html>
<%-- File Added By Rizwan kharal 13April2018 --%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    ###StartTicketForm###
        <div id="MainTicketing">
     <script src="../../../Scripts/Tickets.js" type="text/javascript"></script>
     <%--<link href="../../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />--%>
     <%--<script src="../../../Scripts/Reports.js" type="text/javascript"></script>--%>


         <style type="text/css">
         .filterIcon {
            background-image: url('../../Images/filter-Icon.png');
            background-repeat: no-repeat;
            height: 6px;
            width: 11px;
            cursor: pointer;
            float: left;
            margin-left: 2px;
        }

        .asc {
            background-position: 0 0;
            margin-top: 7px;
        }

        .desc {
            background-position: 0 -5px;
            margin-top: 7px;
        }
    </style>
    
    <div class="Widget">
        <div class="WidgetTitle">
           <%-- <span id="spnTitle" style="font-size: 15px;">Tickets</span>--%>
               <span id="" style="font-size: 15px; float:right;cursor:pointer" onclick="OpenSaveTicketsForm();" title="Add New Ticket">
                   <img src="../../../Images/add.jpg" style="width: 20px;border-radius: 0px;padding-top: 7px;padding-right:5px" /></span>
        </div>
        <div class="reportsCriteriabar" style="background:#dfe3e5;height: 36px;">
            <div class="report-criteria-wraper" style="width:50% !important;font-weight: bold;margin-left:5px">
                <br />
                            <span>Total Records:</span><asp:label runat="server" ID="lblTotalRecord"></asp:label>
                         
            </div>
            
        </div>
        <div class="WidgetContent">
            <div class="WidgetReport" style="margin-top: 10px; margin-bottom:15px">
                <div id="divReportPaging"> </div>
                <div class="WidgetReportContent">
                    <div style="width: 100%; float: left;">
                        <div id="divReportListing">
                            <div class="Grid" id="divTicketing">
                                    <table id="myTable">
                                <thead>
                                     <tr>
                                                    <th style="width:5%">
                                                       Sr #
                                                    </th>
                                                    <th id="TicketId" class="asc" onclick="SortReportList(this,'TicketId');"style="width:5%">
                                                        <span class="report-column-title">Ticket Id</span> <span class="icon" style="margin-top:12px;"></span>
                                                    </th>
                                                    <th id="Title" onclick="SortReportList(this,'Title');" style="">
                                                        <strong class="report-column-title">Title</strong> <span></span>
                                                    </th>
                                                  <th id="description" onclick="SortReportList(this,'Title');" style="">
                                                        <strong class="report-column-title">Description</strong> <span></span>
                                                    </th>

                                                    <th id="Catagery"  onclick="SortReportList(this,'Catagery');" style="width:9%">
                                                        <span class="report-column-title">Category</span> <span></span>
                                                    </th>
                                                    <th id="ReportedBy" onclick="SortReportList(this,'ReportedBy');" style="width:13%">
                                                        <span class="report-column-title">Reported By</span> <span></span>
                                                    </th>
                                                    <th id="CreatedDate" onclick="SortReportList(this,'CreatedDate');" style="width:8%;">
                                                        <span class="report-column-title">Reported On</span> <span></span>
                                                    </th>
                                                    <th id="Priority"  onclick="SortReportList(this,'Priority');" style="width:9%">
                                                        <span class="report-column-title">Priority</span><span class="asc" style="margin-top:6px;"></span>
                                                    </th>
                                                    <th id="Status"  onclick="SortReportList(this,'Status');" style="width:11%">
                                                        <span class="report-column-title">Status</span> <span></span>
                                                    </th>
                                                </tr>
                                                <tr class="Search">
                                                    <th><i class="fa fa-filter" style="color: #065172 ; font-size: 20px !important;cursor:pointer;" id="FilterIcon" onclick="FilterReportList(0, true)"></i></th>
                                                   
                                                     <th style="width:70px;"><asp:TextBox Class="txtTicketIdclass" id="txtTicketId" runat="server" onkeyup="SetSearch(event)" onkeypress="return ValidateNumber(event);"/></th>

                                                    <th style="width:70px;"> <asp:TextBox id="TxtTitleSearch" runat="server" onkeyup="SetSearch(event)"></asp:TextBox> </th>

                                                         <th style="width:70px;"> <asp:TextBox id="TxtDescriptionSearch" runat="server" onkeyup="SetSearch(event)"></asp:TextBox> </th>
                                                       
                                                                                         
                                                    <th>  
                                                        <asp:DropDownList id="txtCategory" runat="server"  onchange="FilterReportList(0,true)">
                                                             <asp:ListItem></asp:ListItem>
                                                               <asp:ListItem Value="Enhancement">Enhancement</asp:ListItem>
                                                             <asp:ListItem Value="New Feature">New Feature</asp:ListItem>
                                                             <asp:ListItem Value="User Interface">User Interface</asp:ListItem>
                                                            <asp:ListItem Value="Bug">Bug</asp:ListItem>
                                                            <asp:ListItem Value="Suggestion">Suggestion</asp:ListItem>
                                                            <asp:ListItem Value="Query">Query</asp:ListItem>
                                                          </asp:DropDownList>
                                                    </th>
                                                    <th style="width:70px;"><asp:TextBox id="TxtReportedBy" runat="server"  onkeyup="SetSearch(event)" onchange="SetSearch(event);"/></th>

                                                    <th style="width:70px;"><asp:TextBox id="TxtReportedOn" runat="server"  onchange="FilterReportList(0,true)"/></th>
                                                   
                                                     <th>  <asp:DropDownList id="txtPiriority" runat="server"  onchange="FilterReportList(0,true)">
                                                              <asp:ListItem></asp:ListItem>
                                                              <asp:ListItem>High</asp:ListItem>
                                                              <asp:ListItem>Medium</asp:ListItem>
                                                              <asp:ListItem>Low</asp:ListItem>
                                                          </asp:DropDownList>
                                                   
                                                          </th>

                                                    <th>  <asp:DropDownList id="txtStatus" runat="server"  onchange="FilterReportList(0,true)">
                                                         <asp:ListItem></asp:ListItem>
                                                              <asp:ListItem Value="New">New</asp:ListItem>
                                                                <asp:ListItem Value="Resolved">Resolved</asp:ListItem>
                                                                <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                                                <asp:ListItem Value="In Progress">In Progress</asp:ListItem>
                                                                <asp:ListItem Value="Reopen">Reopen</asp:ListItem>
                                                                <asp:ListItem Value="Not An Issue">Not An Issue</asp:ListItem>
                                                                <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                                          </asp:DropDownList>
                                                    </th>
                                                </tr>
                                </thead>
                                        <tbody id="tbody" class="TicketBody">
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
                                           
                                            
                                        </tbody>
                            </table>
                    <div class="message" style="width:100%;">
                        <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                    </div>
                    <div class="pager">
                        <div class="PageEntries">
                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                <select id="ddlPagingTickets" style="margin-top: 5px;" onchange="FilterReportList(0,true);">
                                    <option value="10">10</option>
                                    <option value="25">25</option>
                                    <option value="50">50</option>
                                    <option value="75">75</option>
                                    <option value="100">100</option>
                                </select>
                            </span><span style="float: left;">&nbsp;entries</span>
                        </div>
                        <div class="PageButtons">
                            <ul style="float: right; margin-right: 15px;"></ul>
                        </div>
            </div>
                            </div>
                       <span id="message" style="display:none;font-size:14px;font-weight:bold;font-style:italic;color:red;float:left;padding:10px"> <img src="../../Images/Information.png" /> No Record Found</span>
                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <input type="hidden" id="hdnTicketsTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnPracticeId" />
    <asp:HiddenField runat="server" ID="hdnTicketId" />
    <asp:HiddenField runat="server" ID="hdnCatagory" />
    <asp:HiddenField runat="server" ID="hdnReportedOn" />
    <asp:HiddenField runat="server" ID="hdnPriority" />
    <asp:HiddenField runat="server" ID="hdnStatus" />
              <div id="divDialogDocuments_Viewer"></div>
        
    <div id="divDialogReportFilters" style="display: none;"></div>
     <div id="divAddTickets" style="display: none;"></div>
       <div id="Conformationdialog" style="display: none;"></div>
    <script type="text/javascript"> 
    
        $(document).ready(function () {
            debugger;

            GeneratePaging($("[id$='hdnTicketsTotalRows']").val(), $("#ddlPagingTickets").val(), "divTicketing", "FilterReportList");
            if ($("[id$='hdnTicketsTotalRows']").val() > 0) {
                $("#divTicketing .spanInfo").html("Showing " + $(".TicketBody tr:first").children().first().html() + " to " + $(".TicketBody tr:last").children().first().html() + " of " + $("[id$='hdnTicketsTotalRows']").val() + " entries");
            }


          
        });



    </script>

    ###EndTicketForm###
    </div>
    </form>
</body>
</html>
