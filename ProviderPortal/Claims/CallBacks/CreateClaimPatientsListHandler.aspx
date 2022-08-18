<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateClaimPatientsListHandler.aspx.cs" Inherits="EMR_Claims_CallBacks_CreateClaimPatientsListHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      ###StartCreateClaimHandler###
    <div id="divPatients">
        <asp:Repeater ID="rptPatients" runat="server" >
            <HeaderTemplate>
                <div class="Grid">
                    <table>
                        <thead>
                            <tr>
                                <th style="width: 2%;">
                                </th>
                                <th>
                                    Patient Name
                                </th>                                             
                                <th>
                                    Insurance
                                </th>
                                <th style="width: 15%; white-space: nowrap;">
                                    Appointment
                                </th>                               
                                <th style="width:8%;">
                                    Create Claim
                                </th>
                            </tr>
                        </thead>
                        <tbody id="PatientsList">
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="cursor: pointer">
                    <td>                      
                        <%# Eval("RowNumber")%>
                    </td>                    
                    <td>
                        <%# Eval("PatientName")%>
                    </td>                   
                    <td>
                        <%# Eval("InsuranceName")%>
                    </td>
                    <td style="text-align: center; white-space: nowrap;">
                        <%# Eval("AppointmentDate")%>                    
                    </td>                  
                    <td>
                        <span style="color: blue; text-align: center;" onclick="createClaim('<%# Eval("PatientId")%>','<%# Eval("InsuranceId")%>')">
                            Create</span>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                            <select id="ddlPagingCreateClaim" style="margin-top: 5px;" onchange="RowsChange('filterPatients');">
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
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hdnPatientsCount" runat="server" />
        <div>
            &nbsp;</div>
    </div>
    ###EndCreateClaimHandler###
    </form>
</body>
</html>
