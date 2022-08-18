<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterARAgingSummaryReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterARAgingSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartFilter###
                        <asp:Repeater ID="rptARAgingSummary" runat="server" OnItemDataBound="rptARAgingSummary_ItemDataBound">
                            <ItemTemplate>
                                   <tr class="cpa-trfont">
                                    <td class="HyperlinkClass" onclick="ARSummaryDetails('<%# Eval("ARType") %>')" style="text-align: center;"><%# Eval("ARType") %></td>
                                    <td style="text-align: right;"  onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','030')">
                                        <asp:Label  id="current" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','3160')">
                                         <asp:Label  id="p31" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','6190')">
                                          <asp:Label id="p61" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','91120')">
                                        <asp:Label  id="p91" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','120+')">
                                         <asp:Label  id="p120" runat="server" class="HyperlinkClass"></asp:Label></td>
                                    <td style="text-align: right;" onclick="ARInsuranceBilledAs('<%# Eval("ARType") %>','')">
                                        <asp:Label id="TotalOutStanding" runat="server" class="HyperlinkClass"></asp:Label></td>
                                </tr>


                            </ItemTemplate>
                        </asp:Repeater>

            <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
                <td style="text-align: center;">
                    <label>Grand Total</label></td>

                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txtCurrent"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txt3160"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txt6190"></asp:Label></td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txt91120"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txt120"></asp:Label>
                </td>

                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txtTotalOutStanding"></asp:Label></td>
            </tr>

            <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
                <td style="text-align: center;">
                    <label>Total %</label></td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txtCurrentP"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txt3160P"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txt6190P"></asp:Label></td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txt91120P"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txt120P"></asp:Label>
                </td>

                <td style="text-align: right;">
                    <asp:Label runat="server" ID="txtTotalOutStandingP"></asp:Label></td>
            </tr>


        </div>

        <input type="hidden" id="hdnTotalRows" runat="server" value="0" />

        <input type="hidden" id="hdnAgingType" runat="server" value="0" />
        <input type="hidden" id="hdnPracticeLocationId" runat="server" value="0" />
        <input type="hidden" id="hdnProviderId" runat="server" value="0" />
        <input type="hidden" id="hdnPayerId" runat="server" value="0" />
        <input type="hidden" id="hdnAsof" runat="server" value="0" />
        ###END###


        ###TimeSpan###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
        ###End###

        ###S2IPart###
        <asp:Repeater ID="rpt_InsuranceDetail" runat="server">
            <ItemTemplate>
                <tr class="cpa-trfont">
                    <td><%# Eval("ROWNUMBER") %></td>
                    <td style="text-align: center"><%# Eval("ClaimId") %></td>
                    <td style="text-align: left"><%# Eval("Patient") %></td>
                    <td style="text-align: center"><%# Eval("DOS","{0:d}") %></td>
                    <td class="FBD" style="text-align: center;"><%# Eval("FirstBillDate","{0:d}") %></td>
                    <td class="LBD" style="text-align: center;"><%# Eval("LastBillDate","{0:d}") %></td>
                    <td class="PPD" style="text-align: center;"><%# Eval("ProcPostDate","{0:d}") %></td>
                    <td style="text-align: left"><%# Eval("Payer") %></td>

                    <td style="text-align: center"><%# Eval("Aging") %></td>
                    <td style="text-align: center"><%# Eval("ProcedureCode") %></td>

                    <td style="text-align: right"><%# Eval("TotalCharges","{0:c}") %></td>
                    <td style="text-align: right"><%# Eval("PatientPayment","{0:c}") %></td>
                    <td style="text-align: right"><%# Eval("InsurancePayment","{0:c}") %></td>
                    <td style="text-align: right"><%# Eval("Adjustments","{0:c}") %></td>
                    <td style="text-align: right"><%# Eval("TotalOutStanding","{0:c}") %></td>
                    <td class="dllPatient_Class Ins_TdAction" style="display: none"><%# Eval("PatientName") %></td>
                </tr>


            </ItemTemplate>
        </asp:Repeater>



        <tr class="cpa-trfont" style="background-color: #e8e8e8cc !important;">
            <td>
                <label>Grand Total</label></td>

            <td class="FLP"></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            
            <td style="text-align: right" id="TotalCharges">
                <asp:Label runat="server" ID="txtTotalCharges"></asp:Label>
            </td>
            <td style="text-align: right" id="PatientPayment">
                <asp:Label runat="server" ID="txtPatientPayment"></asp:Label>
            </td>
            <td style="text-align: right" id="InsurancePayment">
                <asp:Label runat="server" ID="txtInsurancePayment"></asp:Label></td>
         <%--   <td></td>--%>
             <td style="text-align: right" id="Adjustments">
                 <asp:label runat="server" ID="txtAdjustments"></asp:label> </td> 
            <td style="text-align: right" id="TotalOutStanding">
                <asp:Label runat="server" ID="txtTotalOutStanding1">100.00%</asp:Label>
            </td>


        </tr>

        <tr class="cpa-trfont" style="background-color: #e8e8e8cc !important;">
            <td>
                <label>Total %</label></td>

            <td class="FLP"></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
         
            <td style="text-align: right" id="TotalChargesP">
                <asp:Label runat="server" ID="txtTotalChargesP"></asp:Label>
            </td>
            <td style="text-align: right" id="PatientPaymentP">
                <asp:Label runat="server" ID="txtPatientPaymentP"></asp:Label>
            </td>
            <td style="text-align: right" id="InsurancePaymentP">
                <asp:Label runat="server" ID="txtInsurancePaymentP"></asp:Label></td>
            <%--   <td></td>--%>
          <td style="text-align: right" id="AdjustmentsP">
             <asp:label runat="server" ID="txtAdjustmentsP"></asp:label> </td>
            <td style="text-align: right" id="TotalOutStanding1P">
                <asp:Label runat="server" ID="txtTotalOutStanding1P">100.00%</asp:Label>
            </td>
        </tr>
        <input type="hidden" id="hdnInsRows" runat="server" value="" />
        ###E2IPart###
        ###SPPart###
        <asp:Repeater ID="rpt_Patient" runat="server">
            <ItemTemplate>
                <tr class="cpa-trfont">
                    <td style="text-align: center;"><%# Eval("ROWNUMBER") %></td>
                    <td style="text-align: left;"><%# Eval("Patient") %></td>
                    <td style="text-align: center;"><%# Eval("LastPaidDate","{0:d}") %></td>
                    <td class="" style="text-align: right;"><%# Eval("Current","{0:c}") %></td>
                    <td class="" style="text-align: right;"><%# Eval("31-60","{0:c}") %></td>
                    <td class="" style="text-align: right;"><%# Eval("61-90","{0:c}") %></td>
                    <td class="" style="text-align: right;"><%# Eval("91-120","{0:c}") %></td>
                    <td class="" style="text-align: right;"><%# Eval("120+","{0:c}") %></td>
                    <td style="text-align: right;"><%# Eval("TotalOutStanding","{0:c}") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
            <td style="text-align: center;">
                <label>Grand Total</label></td>
            <td></td>
            <td></td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label7"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label8"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label9"></asp:Label></td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label10"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label11"></asp:Label>
            </td>

            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label12"></asp:Label></td>
        </tr>
        <tr class="cpa-trfont" style="background-color: #e8e8e8cc;">
            <td style="text-align: center;">
                <label>Total %</label></td>
            <td></td>
            <td></td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label13"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label14"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label15"></asp:Label></td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label16"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label17"></asp:Label>
            </td>

            <td style="text-align: right;">
                <asp:Label runat="server" ID="Label18"></asp:Label></td>
        </tr>


        ###EPPart###

         ###S2PPart###
            <asp:Repeater ID="rptPatClm" runat="server">
                <ItemTemplate>
                    <tr class="cpa-trfont">
                        <td style="text-align: center"><%# Eval("ClaimId") %></td>
                        <td style="text-align: left"><%# Eval("Patient") %></td>
                        <td style="text-align: center"><%# Eval("DOS","{0:d}") %></td>
                        <td class="FBD" style="text-align: center;"><%# Eval("FirstBillDate","{0:d}") %></td>
                        <td class="LBD" style="text-align: center;"><%# Eval("LastBillDate","{0:d}") %></td>
                        <td class="PPD" style="text-align: center;"><%# Eval("ProcPostDate","{0:d}") %></td>
                        <td style="text-align: center"><%# Eval("Aging") %></td>
                        <td style="text-align: center"><%# Eval("ProcedureCode") %></td>

                        <td style="text-align: right"><%# Eval("TotalCharges","{0:c}") %></td>
                        <td style="text-align: right"><%# Eval("PatientPayment","{0:c}") %></td>
                        <td style="text-align: right"><%# Eval("InsurancePayment","{0:c}") %></td>
                        <td style="text-align: right"><%# Eval("TotalOutStanding","{0:c}") %></td>
                        <td class="dllPatient_Class" style="display: none"><%# Eval("PatientName") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        <tr class="cpa-trfont" style="background-color: #e8e8e8cc !important;">
            <td>
                <label>Grand Total</label></td>

            <td class="FLP" style="display: none"></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>


            <td style="text-align: right">
                <asp:Label runat="server" ID="txtTotalCharges1"></asp:Label>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" ID="PatientPayment1"></asp:Label>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" ID="InsurancePayment1"></asp:Label></td>
             <td  style="text-align: right">
                 <asp:label runat="server" ID="TxtAdjustments1"></asp:label> </td> 
            <td style="text-align: right">
                <asp:Label runat="server" ID="TotalOutStanding1">100.00%</asp:Label>
            </td>


        </tr>

        <tr class="cpa-trfont" style="background-color: #e8e8e8cc !important;">
            <td>
                <label>Total %</label></td>

            <td class="FLP" style="display: none"></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>

            <td></td>
            <td></td>
            <td></td>


            <td style="text-align: right">
                <asp:Label runat="server" ID="txtTotalChargesP1"></asp:Label>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" ID="txtPatientPaymentP1"></asp:Label>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" ID="txtInsurancePaymentP1"></asp:Label></td>
               <td><asp:label runat="server" ID="txtAdjustmentsP1"></asp:label> </td>
            <td style="text-align: right">
                <asp:Label runat="server" ID="txtTotalOutStandingP1">100.00%</asp:Label>
            </td>
        </tr>

        ###E2PPart###
    </form>
</body>
</html>
