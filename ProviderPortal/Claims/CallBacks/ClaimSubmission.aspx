<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimSubmission.aspx.cs"
    EnableSessionState="false" EnableViewState="false" Inherits="HomeHealth_EpisodeClaims_CallBacks_ClaimSubmission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###StartClaimsSubmission###
    <div>
        <div class="box-header">
            <ul>
                <li class="active"><a href="#" onclick="showHideClaimSubmissionTabs('divPendingSubmission','1');">Pending Submissions</a></li>
                <li><a href="#" onclick="showHideClaimSubmissionTabs('divUnProcessedClaimsOuter','2');">UnProcessed Claims</a></li>
                <li><a href="#" onclick="showHideClaimSubmissionTabs('divSubmissionLogOuter','3');">Submission Log</a></li>
                <li><a href="#" onclick="showHideClaimSubmissionTabs('divSubmissionFilesOuter','4');">Submission Files</a></li>
            </ul>
        </div>

        <div id="divPendingSubmission" class="Tab-Content">
            <asp:HiddenField runat="server" ID="hdnPendingSubmissionCount" />
            <div style="float: right; padding: 2px 0 4px">
                <input type="button" value="Generate Submission File" onclick="GeneratePendingSubmissionsFile();">
            </div>
            <div class="Grid">
                <table>
                    <thead>
                        <tr>
                            <th style="width: 2%;"></th>
                            <th style="width: 2.5%;"></th>
                            <th>Insurance Name
                            </th>
                            <th>Payer Id
                            </th>
                            <th>Pending Claims
                            </th>
                            <th style="background: #138599;">0-7
                            </th>
                            <th style="background: #981399;">8-15
                            </th>
                            <th style="background: #991346;">16-21
                            </th>
                            <th style="background: #eb0d32;">22+
                            </th>
                        </tr>
                    </thead>
                    <tbody id="PendingSubmissionsList">
                        <asp:Repeater runat="server" ID="rptPendingSubmissions">
                            <ItemTemplate>
                                <tr id="<%#Eval("InsuranceId") %>">
                                    <td>
                                        <%# Eval("RowNumber") %>
                                    </td>
                                    <td>
                                        <input type="checkbox" />
                                    </td>
                                    <td>
                                        <%# Eval("Name") %>
                                    </td>
                                    <td>
                                        <%# Eval("PayerId837") %>
                                    </td>
                                    <td>
                                        <%# Eval("TotalPendingClaims") %>
                                    </td>
                                    <td>
                                        <%# Eval("C07") %>
                                    </td>
                                    <td>
                                        <%# Eval("C815") %>
                                    </td>
                                    <td>
                                        <%# Eval("C1621") %>
                                    </td>
                                    <td>
                                        <%# Eval("C22") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                            <select id="ddlPendignSubmissions" style="margin-top: 5px;" onchange="RowsChange('FilterPendingSubmissions');">
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

        <div id="divUnProcessedClaimsParent" class="Tab-Content" style="display: none;">
            <div style="float: right; padding: 2px 0 4px">
                <input type="button" value="Generate Submission File" onclick="generateSubmissionFile();" />
            </div>
            <div class="Grid">
                <table>
                    <thead>
                        <tr>
                            <th style="width: 2%;"></th>
                            <th style="width: 2.5%;"></th>
                            <th>Patient
                            </th>

                            <th>Insurance
                            </th>
                            <th style="width: 12%; white-space: nowrap;">Claim Tracking No
                            </th>
                            <th style="width: 8%;">Amount
                            </th>
                            <th style="display: none;"></th>
                        </tr>
                        <tr>
                            <th></th>
                            <th></th>
                            <th>
                                <input type="text" id="txtUCPatientName" onkeyup="FilterUnProcessedClaims(0, true);" />
                            </th>
                            <th>
                                <input type="text" id="txtUCInsuranceName" onkeyup="FilterUnProcessedClaims(0, true);" />
                            </th>
                            <th>
                                <input type="text" id="txtUCClaimNumber" onkeyup="FilterUnProcessedClaims(0, true);" />
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="UnProcessedClaimsList">
                        <asp:Repeater ID="rptUnProcessedClaims" runat="server" OnItemDataBound="rptUnProcessedClaims_ItemDataBound">
                            <ItemTemplate>
                                <tr style="cursor: pointer">
                                    <td>
                                        <%# Eval("RowNumber") %>
                                    </td>
                                    <td>
                                        <input type="checkbox" />
                                    </td>
                                    <td>
                                        <%# Eval("PatientName")%>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("ClaimId")%>
                                    </td>
                                    <td>
                                        <%# Eval("TotalCharges")%>
                                    </td>
                                    <td style="display: none;">

                                        <span id="spnInsuranceId" runat="server">
                                            <%# Eval("InsuranceId")%></span>
                                        <span id="spnPatientId" runat="server">
                                            <%# Eval("PatientId")%></span>

                                        <span id="spnClaimId" runat="server">
                                            <%# Eval("ClaimId")%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:HiddenField runat="server" ID="hdnUnProcessedClaimsCount" />
                    </tbody>
                </table>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                            <select id="ddlPagingUnprocessedClaims" style="margin-top: 5px;" onchange="RowsChange('FilterUnProcessedClaims');">
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
            <div>
                &nbsp;
            </div>
            <div>
                &nbsp;
            </div>
        </div>
        <div id="divSubmissionFilesParent" class="Tab-Content" style="display: none;">
            <div class="Grid">
                <table>
                    <thead>
                        <tr>
                            <th style="width: 2%;"></th>
                            <th>File Name
                            </th>
                            <th>
                                Generation Date
                            </th>
                            <th>File Status
                            </th>
                            <th>Submissions Results
                            </th>
                            <th style="width: 7%">Download
                            </th>
                        </tr>
                        <tr>
                            <th></th>
                            <th>
                                <input type="text" id="txtSFFileName" onkeyup="FilterSubmissionFiles(0,true)" />
                            </th>
                            <th>
                                <input type="text" id="txtSFGenerationDate" onkeyup="FilterSubmissionFiles(0,true)" />
                            </th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="SubmissionFilesList">
                    </tbody>
                </table>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                            <select id="ddlPagingSubmissionFiles" style="margin-top: 5px;" onchange="RowsChange('FilterSubmissionFiles');">
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
        <div id="divSubmissionLogParent" class="Tab-Content" style="display: none;">
            <div class="Grid">
                <table>
                    <thead>
                        <tr>
                            <th style="width: 2%;"></th>
                            <th>Patient</th>
                            <th>Insurance</th>
                            <th>
                                File Name
                            </th>
                            <th style="width: 12%; white-space: nowrap;">Claim Tracking No
                            </th>
                            <th style="width: 12%; white-space: nowrap;">Submission Date
                            </th>
                            <th style="width: 15%; white-space: nowrap;">Submission Results
                            </th>
                        </tr>
                        <tr>
                            <th></th>
                            <th>
                                <input type="text" id="txtSLPatientName" onkeyup="FilterSubmissionLog(0, true);" />
                            </th>
                            <th>
                                <input type="text" id="txtSLInsurance" onkeyup="FilterSubmissionLog(0, true);" />
                            </th>
                            <th>
                                <input type="text" id="txtSLFileName" onkeyup="FilterSubmissionLog(0, true);" />
                            </th>
                            <th>
                                <input type="text" id="txtSLClaimId" onkeyup="FilterSubmissionLog(0, true);" />
                            </th>
                            <th>
                                <input type="text" id="txtSLSubmissionDate" onkeyup="FilterSubmissionLog(0, true);" />
                            </th>
                            <th>
                                <input type="text" id="txtSLSubmissionResults" onkeyup="FilterSubmissionLog(0, true);" />
                            </th>
                        </tr>
                    </thead>
                    <tbody id="SubmissionLogList">
                    </tbody>
                </table>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                            <select id="ddlPagingSubmissionLog" style="margin-top: 5px;" onchange="RowsChange('FilterSubmissionLog')">
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
        <div>
            &nbsp;
        </div>
    </div>
        ###EndClaimsSubmission###
    </form>
</body>
</html>
