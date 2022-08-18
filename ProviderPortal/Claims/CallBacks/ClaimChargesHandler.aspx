<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimChargesHandler.aspx.cs" Inherits="HomeHealth_EpisodeClaims_CallBacks_ClaimChargesHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartEpisodeClaims###
    <div class="Widget">
        <asp:Repeater ID="rptEpisodeClaims" runat="server">
            <ItemTemplate>
                <table class="Grid" style="margin: 10px; width: 98%">
                    <tr>
                        <th>
                            Invoice
                        </th>
                        <th>
                            Patient Name
                        </th>
                        <th>
                            Date
                        </th>
                        <th>
                            MR#
                        </th>
                        <th>
                        </th>
                        <th>
                        </th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                    <tr>
                        <td>
                            <%# Eval("EpisodeClaimsId") %>
                        </td>
                        <td>
                            <%# Eval("PatientName") %>
                        </td>
                        <td>
                            <%# Eval("Date","{0:d}") %>
                        </td>
                        <td>
                            <%# Eval("PatientId") %>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                         <td>
                        </td>
                        <td>
                        </td>
                         <td>
                        </td>
                        
                        <asp:Repeater ID="rptClaimCharges" DataSource='<%# Eval("EpisodeClaimsRelations") %>'
                            runat="server">
                            <HeaderTemplate>
                                <tr>
                                    <th>
                                        Date
                                    </th>
                                    <th>
                                        Task/Supply
                                    </th>
                                    <th>
                                        Unit
                                    </th>
                                    <th>
                                        Charges
                                    </th>
                                   
                                   <th>Allowed</th>
                                   <th>Amount</th>
                                   <th>Balance</th>
                                    <th>
                                        Status
                                    </th>
                                    <th>
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="<%# Eval("ClaimChargesId") %>">
                                    <td>
                                        <%# Eval("ServiceDate","{0:d}") %>
                                    </td>
                                    <td>
                                        <%# Eval("CategoryName") %>
                                    </td>
                                    <td>
                                        <%# Eval("ServiceUnits") %>
                                    </td>
                                  
                                    <td>
                                        <%# Eval("TotalCharges","{0:c}") %>
                                    </td>
                                    <td>
                                        <%# Eval("TotalCharges","{0:c}") %> 
                                    </td>
                                     <td><input type="text"/></td>
                                    <td>
                                       <%# Eval("TotalCharges","{0:c}") %>  
                                    </td>
                                   
                                    <td>
                                        Pending
                                    </td>
                                    <td>
                                        <input id="chkSelect" type="checkbox" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        <div style="float: right">
         <input type="button" value="Apply Payments"/>   
        </div>
    </div>
    ###EndEpisodeClaims###
    </form>
</body>
</html>
