<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinancialGuarantorSearch.aspx.cs" Inherits="ProviderPortal_Patient_CallBacks_FinancialGuarantorSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
        
            <script src="../../Scripts/jquery-1.9.0.js"></script>
        
           
    <title></title>

    <style>
        #divFinancialGuarantor
        {
            border:none !important;
            -webkit-box-shadow:none;
        }
    </style>

    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartFinancialGuarantorSearch###
       <script src="../../Scripts/Rizwan/Demographics.js"></script>
        <asp:HiddenField runat="server" ID="hdnFinancialGuarantorTotalRows" />
       <div id="main">
           <div id="header" style="width:100%; height:34px;background-color:#439abf;" class="border">

           <div style="float:left; margin-left:8px; margin-top:7px">
               <label id="title" style="color:white;font-size:19px ;">FinancialGuarantor Search</label>
           </div>
            <div >
               <input type="button" value="X" id="FinancialGuarantorclose"  onclick="FinancialGuarantordivclose();" style="min-width:19px !important ; height: 24px !important; float:right; margin-right:5px; margin-top:6px" />
            
           </div>

       </div>
        <div class="Grid" id="divFinancialGuarantor" style="margin-bottom: 10px;"><%--divFinancialGuarantor--%>
            <table border="0" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th style="width:2%;"></th>
                        <th style="width: 15%;">Last Name</th>
                        <th style="width: 15%;">First Name</th>
                        <th style="width: 10%;">Gender</th>
                        <th style="width: 12%;">DOB</th>
                        <th style="width: 46%;">Address</th>
                    </tr>
                    <tr>
                        <th></th>
                        <th><asp:TextBox runat="server" ID="txtFinancialGuarantorLastName" onkeyup="FinancialGuarantorSearchResult(0,true);"></asp:TextBox></th>
                        <th><asp:TextBox runat="server" ID="txtFinancialGuarantorFirstName" onkeyup="FinancialGuarantorSearchResult(0,true);"></asp:TextBox></th>
                        <th>
                            <asp:DropDownList runat="server" ID="ddlFinancialGuarantorGender" onchange="FinancialGuarantorSearchResult(0,true);">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:DropDownList>
                        </th>
                        <th><asp:TextBox runat="server" ID="txtFinancialGuarantorDOB" onkeyup="FinancialGuarantorSearchResult(0,true);"></asp:TextBox></th>
                        <th><asp:TextBox runat="server" ID="txtFinancialGuarantorAddress" style="width: 95%;" onkeyup="FinancialGuarantorSearchResult(0,true);"></asp:TextBox></th>
                    </tr>
                </thead>
                <tbody id="financialGuarantorList">
                    <asp:Repeater ID="rptFinancialGuarantor" runat="server">
                        <ItemTemplate>
                            <tr onclick="PopulateFinancialGuarantorDetails(this);" id="<%# Eval("FinancialGuarantorId") %>">
                                <td>
                                    <%# Eval("RowNumber") %>
                                </td>
                                <td>
                                    <%# Eval("LastName") %>
                                </td>
                                <td>
                                    <%# Eval("FirstName") %>
                                </td>
                                <td>
                                    <%# Eval("Gender") %>
                                </td>
                                <td>
                                    <%# Eval("DateOfBirth", "{0:d}") %>
                                </td>
                                <td>
                                    <%# Eval("Address") %>, <%# Eval("City") %> <%# Eval("State") %>, <%# Eval("Zip") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    
                       
                    </asp:Repeater>              
                </tbody>
            </table>
            <div class="message">
                <span class="iconInfo" style="margin: 7px;"></span>
                <span class="spanInfo">
            </div>
            <div class="pager">
                <div class="PageEntries">
                    <span style="float: left; margin-left: 1px;">Show&nbsp;</span><span style="float: left;">
                        <select id="ddlPagingFinancialGuarantor" style="margin-top: 5px;" onchange="RowsChange('FinancialGuarantorSearchResult');">
                            <option value="10">10</option>
                            <option value="25">25</option>
                            <option value="50">50</option>
                            <option value="75">75</option>
                            <option value="100">100</option>
                        </select>
                    </span><span style="float: left;">&nbsp;entries</span>
                </div>
                <div class="PageButtons">
                    <ul style="float: right; margin-right: 15px;">
                    </ul>
                </div>
            </div>
        </div>
           </div>
        ###EndFinancialGuarantorSearch###
    </div>
    </form>
</body>
</html>
