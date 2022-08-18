<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubscriberSearch.aspx.cs" Inherits="ProviderPortal_Controls_SubscriberSearch" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###StartSubscriberSearch###
        <asp:HiddenField runat="server" ID="hdnSubscriberTotalRows" />
        <div class="action-button-wrapper" style="margin-top: 15px; float: right;">
            <a href="javascript:void(0)" onclick="AddSubscriber();" style="min-width: 50px;padding-left: 4px;" class="themeButton">
                <span style="background-image: url('../../Images/add.png');background-repeat: no-repeat;padding-left: 22px;"></span>Add New Subscriber</a>
        </div>
        <div class="Grid" id="divSubscriber" style="margin-top:20px;">
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
                        <th><asp:TextBox runat="server" ID="txtSubscriberLastName" onkeyup="SubscriberSearchResult(0,true);"></asp:TextBox></th>
                        <th><asp:TextBox runat="server" ID="txtSubscriberFirstName" onkeyup="SubscriberSearchResult(0,true);"></asp:TextBox></th>
                        <th>
                            <asp:DropDownList runat="server" ID="ddlSubscriberGender" onchange="SubscriberSearchResult(0,true);">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            </asp:DropDownList>
                        </th>
                        <th><asp:TextBox runat="server" ID="txtSubscriberDOB" onkeyup="SubscriberSearchResult(0,true);"></asp:TextBox></th>
                        <th><asp:TextBox runat="server" ID="txtSubscriberAddress" style="width: 95%;" onkeyup="SubscriberSearchResult(0,true);"></asp:TextBox></th>
                    </tr>
                </thead>
                <tbody id="subscriberList">
                    <asp:Repeater ID="rptSubscriber" runat="server">
                        <ItemTemplate>
                            <tr onclick="PopulateSubscriberDetails(this);">
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
                                    <%# Eval("Address") %>,
                                    <%# Eval("City") %>
                                    <%# Eval("State") %>,
                                    <%# Eval("Zip") %>
                                    
                                    <input type="hidden" class="hdnSubscriberId" value='<%# Eval("SubscriberId") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>              
                </tbody>
            </table>
            <div class="message">
                <span class="iconInfo" style="margin: 7px;"></span>
                <span class="spanInfo"></span>
            </div>
            <div class="pager">
                <div class="PageEntries">
                    <span style="float: left; margin-left: 1px;">Show&nbsp;</span><span style="float: left;">
                        <select id="ddlPagingSubscriber" style="margin-top: 5px;" onchange="RowsChange('SubscriberSearchResult');">
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
        ###EndSubscriberSearch###
    </div>
    </form>
</body>
</html>
