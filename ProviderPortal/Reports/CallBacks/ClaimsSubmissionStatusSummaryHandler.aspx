<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimsSubmissionStatusSummaryHandler.aspx.cs"
    Inherits="EMR_Reports_CallBacks_ClaimsSubmissionStatusSummaryHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###Start###
        <table style="width: 100%;">
            <thead>
                <tr>
                    <th style="width: 2%;">
                        #
                    </th>
                    <th style="width: 8%;">
                        Claim No
                    </th>
                    <th>
                        Location
                    </th>
                    <th>
                        Patient Name
                    </th>
                    <th>
                        DOS
                    </th>
                    <th>
                        Bill Date
                    </th>
                    <th>
                        Primary Insurance
                    </th>
                    <th>
                        Primary Status
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptClaims" runat="server" OnItemDataBound="rptClaims_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("ROWNUMBER")%>
                            </td>
                            <td style="text-align:right;">
                                <%# Eval("ClaimId")%>
                                <input type="hidden" class="ClaimId" value='<%# Eval("ClaimId")%>' />
                                <input type="hidden" class="PatientId" value='<%# Eval("PatientId")%>' />
                                <input type="hidden" class="ServiceDate" value='<%# Eval("ServiceDate")%>' />
                            </td>
                            <td>
                                <%# Eval("PracticeLocation")%>
                            </td>
                            <td>
                                <%# Eval("PatientName")%>
                            </td>
                            <td style="text-align: right;">
                                <%# Eval("ServiceDate", "{0:d}")%>
                            </td>
                            <td style="text-align: right;">
                            </td>
                            <td>
                                <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                            </td>
                            <td style="white-space: nowrap;">
                                <%# Eval("SubmissionStatus")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="alternatingRow">
                            <td>
                                <%# Eval("ROWNUMBER")%>
                            </td>
                            <td style="text-align:right;">
                                <%# Eval("ClaimId")%>
                                <input type="hidden" class="ClaimId" value='<%# Eval("ClaimId")%>' />
                                <input type="hidden" class="PatientId" value='<%# Eval("PatientId")%>' />
                                <input type="hidden" class="ServiceDate" value='<%# Eval("ServiceDate")%>' />
                            </td>
                            <td>
                                <%# Eval("PracticeLocation")%>
                            </td>
                            <td>
                                <%# Eval("PatientName")%>
                            </td>
                            <td style="text-align: right;">
                                <%# Eval("ServiceDate", "{0:d}")%>
                            </td>
                            <td style="text-align: right;">
                            </td>
                            <td>
                                <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                            </td>
                            <td style="white-space: nowrap;">
                                <%# Eval("SubmissionStatus")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        ###End### ###StartRowsCount###
        <asp:Literal ID="ltrRowsCount" runat="server" />
        ###EndRowsCount###
    </div>
    </form>
</body>
</html>
