<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillingManagerHandler.aspx.cs"
    EnableSessionState="true" EnableViewState="false" Inherits="EMR_Claims_CallBacks_BillingManagerHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartBillingHandler###
        <asp:Repeater ID="rptClaims" runat="server" OnItemDataBound="rptClaims_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td style="cursor: pointer;">
                        <i><%# Eval("ROWNUMBER")%></i>
                    </td>

                    <td class="singleCheckbox">
                        <input type="checkbox" class="clsContainer" value='<%# Eval("ClaimId") %>' />
                    </td>
                    <td>
                        <%-- claim-center class in common.css --%>
                        <span class=""><%# Eval("ClaimId")%></span>
                        <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                        <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                        <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                        <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                    </td>
                    <td style="cursor: pointer;" class="txtalign-cntr">
                        <%# Eval("PatientId")%>
                    </td>
                    <td style="cursor: pointer;">
                        <%# Eval("PatientName")%>
                    </td>
                    <td style="text-align: center; cursor: pointer;">
                        <%# Eval("ServiceDate", "{0:d}")%>
                    </td>
                    <td style="text-align: center;" style="cursor: pointer;">
                        <%# Eval("BillDate")%>
                    </td>
                    <td class="txtalgn-left" style="cursor: pointer;">
                        <%# Eval("Location")%>
                    </td>
                    <%--/// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column--%>
                    <td>
                        <%# Eval("Provider")%>
                    </td>
                    <%--/// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column--%>
                    <td style="cursor: pointer;">
                        <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                    </td>
                    <td style="white-space: nowrap; cursor: pointer;">
                        <%--<%# Eval("InsuranceStatus")%>--%>
                        <asp:Label runat="server" ID="lblstatus" />
                    </td>
                    <%--added by shahid kazmi 1/22/2018--%>
                    <td style="white-space: nowrap; cursor: pointer;" class="txtalign-right">
                        <%# Eval("AmountPaid","{0:c}")%>
                    </td>
                    <td style="white-space: nowrap; cursor: pointer;" class="txtalign-right">
                        <%# Eval("AmountDue","{0:c}")%>
                    </td>
                    <%-- end shahid kazmi 1/22/2018--%>
                    <td style="white-space: nowrap; cursor: pointer;" class="txtalign-right">
                        <%# Eval("ClaimTotal","{0:c}")%>
                    </td>
                    <td align="center" class="clsPrint" id="tdPrint" runat="server">
                        <a title="View" onclick="ClaimOpenForView(<%# Eval("ClaimId")%>,<%# Eval("PatientId")%>,'<%# Eval("SubmissionStatus")%>')">
                            <img src="../../Images/view1.png" />
                        </a>
                        <a href="javascript:void(0);" onclick="printClaim(this);" title="Print Claim">
                            <img src="../../Images/invoice.png" />
                        </a>
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
            <asp:HiddenField ID="hdnClaimsCount" runat="server" />
            ###EndBillingHandler###
           
            
                   <div class="tbodyLocationList">
                       ###StartClaimRPMHandler###
                     
                       ###EndClaimRPMHandler###
                   </div>


            ###StartulMulti###
              <div>
                  <ul id="ulMultiInsurances">

                      <li style="border-bottom: 1px solid #d5cfcf; margin-bottom: 3px">
                          <input type="text" id="searchMultiInsurances" placeholder="Search Insurance" onkeyup="SearchInsuranceOnEnter(event)" />
                      </li>

                      <li style="border-bottom: 1px solid #d5cfcf" id="AllChkli"><span style="margin-left: 14px;">
                          <input type="checkbox" class="AllCheckBox" onclick="ALLCheckBox()" /></span>
                          <span style="margin-left: 21px;">ALL</span>

                      </li>
                      <asp:Repeater runat="server" ID="rptInsurances" OnItemDataBound="rptInsurances_ItemDataBound">
                          <ItemTemplate>

                              <li style="float: left; width: 100%; border-bottom: 1px solid #d5cfcf;" runat="server" id="InsList">
                                  <label name='<%#Eval("InsuranceName") %>' style="float: left; width: 100%">
                                      <input type="checkbox" class="MultiCheckBox" style="float: left; width: 8%" onclick="checkAllCheckBoxISCheked(this)" />
                                      <span class="checkBoxName" style="float: right; width: 88%"><%#Eval("InsuranceName") %></span>
                                      <input type="hidden" value='<%#Eval("InsuranceId") %>' class="InsuranceId" />


                                  </label>
                              </li>

                          </ItemTemplate>
                      </asp:Repeater>

                  </ul>
              </div>
            ###EndulMulti###

            ###StartulMultiReports###
              <div>
                  <ul id="ulMultiInsurances">

                      <li style="border-bottom: 1px solid #d5cfcf; margin-bottom: 3px">
                          <input type="text" id="searchMultiInsurances" placeholder="Search Insurance" onkeyup="SearchInsuranceOnEnter(event)" />
                      </li>

                      <li style="border-bottom: 1px solid #d5cfcf" id="AllChkli"><span style="margin-left: 14px;">
                          <input type="checkbox" class="AllCheckBox" onclick="ALLCheckBox()" /></span>
                          <span style="margin-left: 21px;">ALL</span>

                      </li>
                      <asp:Repeater runat="server" ID="rptInsurances_Reports">
                          <ItemTemplate>

                              <li style="float: left; width: 100%; border-bottom: 1px solid #d5cfcf;" runat="server" id="InsList">
                                  <label name='<%#Eval("name") %>' style="float: left; width: 100%">
                                      <input type="checkbox" class="MultiCheckBox" style="float: left; width: 8%" onclick="checkAllCheckBoxISCheked(this)" />
                                      <span class="checkBoxName" style="float: right; width: 88%"><%#Eval("name") %></span>
                                      <input type="hidden" value='<%#Eval("InsuranceId") %>' class="InsuranceId" />


                                  </label>
                              </li>

                          </ItemTemplate>
                      </asp:Repeater>

                  </ul>
              </div>
            ###EndulMultiReports###

            ###StartInsu###
             <script src="js/BillingManager.js"></script>
            <ul>
                <li style="text-align: left; margin-top: 12px; padding-bottom: 17px; border-bottom: 1px solid #ccc; padding-left: 9px;">
                    <span onclick="selectinsurance(this)" style="cursor: pointer; text-align: left; float: left">
                        <span class="InsuranceName">All</span>

                    </span>
                    <span class="drop-closebtn" onclick="closeddl()">x</span>
                </li>
                <li style="text-align: left; margin-top: 8px; padding-bottom: 6px; border-bottom: 1px solid #ccc; padding-left: 9px;">
                    <span onclick="selectinsurance(this)" style="cursor: pointer">
                        <span class="InsuranceName" style="cursor: pointer; font-size: 12px; font-weight: 300; color: black;">Self Pay</span> </span>
                </li>
                <li>

                    <table>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptinsurance">
                                <ItemTemplate>

                                    <tr onclick="selectinsurance(this)">
                                        <td style="cursor: pointer; font-size: 12px; font-weight: 300; color: black; text-align: left;" class="InsuranceName"><%#Eval("InsuranceName") %></td>
                                        <td style="display: none" class="InsuranceId"><%#Eval("InsuranceId") %></td>
                                    </tr>


                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                </li>
            </ul>

            ###EndInsu###

        </div>
    </form>
</body>
</html>
