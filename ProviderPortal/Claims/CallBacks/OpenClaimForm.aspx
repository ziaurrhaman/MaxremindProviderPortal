<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenClaimForm.aspx.cs" Inherits="ProviderPortal_Claims_CallBacks_OpenClaimForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###StartAllClaims###
    <div class="parentDiv">
        <style>
            .parentDiv {
                font-size: 12px;
                overflow-y: auto !important;
                max-height: 80vh;
                overflow-x: hidden;
            }

            .Patient_Claim_Info {
                padding-bottom: 10px;
                padding-top: 10px;
            }

            .td_Pat_Claim_info {
                width: 33.33%;
            }

            fieldset {
                height: 100px;
                padding: 3px 0px 3px 8px;
                border: 1px solid #439abf;
            }

            .Grid {
                width: 100%;
            }

            .DX_Code_Info {
                float: left;
                width: 100%;
                padding-bottom: 10px;
            }

            .Service_Location_Info {
                float: left;
                width: 100%;
                padding-bottom: 10px;
            }

            .CPT_Code_Info {
                float: left;
                width: 100%;
                padding-bottom: 10px;
            }

            .fontColor {
                color: #195cc5;
            }

            .fontWeight {
                font-weight: bold;
            }

            .id_setting {
                display: block;
                margin: auto;
                background-color: #439abf;
                width: 50%;
                height: 17px;
                text-align: center;
                border-radius: 15px;
                padding-top: 1px;
                box-sizing: border-box;
                color: white;
            }

            .pad_bottom5 {
                width: 100%;
                float: left;
                padding-bottom: 5px;
            }

            .borderbottom {
                border-bottom: none !important;
                background-color: white !important;
            }

            .cptTable thead th {
                background-color: #439abf !important;
                color: white !important;
            }

            .Paymentslbl {
                float: left;
                margin-top: 10px;
                margin-bottom: 10px;
                font-size: 13px;
                font-weight: 600;
                margin-left: 10px;
            }

            .ClaimNoteslbl {
                float: left;
                /*margin-top: 10px;*/
                margin-bottom: 10px;
                font-size: 13px;
                font-weight: 600;
                margin-left: 10px;
            }

            .ClaimNotesTable thead th {
                background-color: #439abf !important;
                color: white !important;
            }

            .ClaimNotes {
                width: 100%;
                float: left;
                margin-bottom: 10px;
            }

            .ClaimNotesMessage {
                color: red;
                font-weight: bold;
                font-style: oblique;
            }

            .txtalign-right {
                text-align: right;
            }

            .txtalign-cntr {
                text-align: center;
            }
        </style>
        <div class="Patient_Claim_Info">
            <table>
                <tr>
                    <td style="width: 33.33%">
                        <fieldset>
                            <legend>Patient Info</legend>


                            <span class="pad_bottom5">
                                <asp:Label ID="lblName" runat="server">  </asp:Label>
                                <asp:Label ID="lblPatientId" runat="server"> </asp:Label>
                            </span>
                            <br />
                            <span class="pad_bottom5">
                                <asp:Label ID="lblGender" runat="server"> </asp:Label>
                                <asp:Label ID="lblDOB" runat="server">  </asp:Label>
                            </span>
                            <br />
                            <span class="pad_bottom5">
                                <asp:Label ID="lblPhone" runat="server"> </asp:Label>
                            </span>
                            <br />
                            <span class="pad_bottom5 AddressDetails">
                                <asp:Label ID="lblAddress" runat="server">  </asp:Label>,
                              <asp:Label ID="lblCity" runat="server">  </asp:Label>
                                ,
                              <asp:Label ID="lblState" runat="server">  </asp:Label>,
                              <asp:Label ID="lblZip" runat="server">   </asp:Label>
                            </span>
                        </fieldset>
                    </td>
                    <td style="width: 33.33%">
                        <fieldset>
                            <legend>Claim Info</legend>
                            <table>
                                <tr style="width: 100%">

                                    <td style="width: 10%">Claim Id:</td>
                                    <td style="width: 30px; float: left;"><span class="pad_bottom5">
                                        <asp:Label ID="lblClaimId" runat="server" CssClass="fontColor" Style="width: 30px">  </asp:Label></span></td>
                                    <td style="width: 15%; float: left; padding-left: 36px; box-sizing: border-box;">Status:</td>
                                    <td style="float: left; padding-left: 36px; box-sizing: border-box;"><span class="pad_bottom5">
                                        <asp:Label ID="lblStatus" runat="server" CssClass="fontColor">  </asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td style="width: 20px">DOS:</td>
                                    <td><span class="pad_bottom5">
                                        <asp:Label ID="lblDos" runat="server" CssClass="fontColor">  </asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td>Primary:</td>
                                    <td><span class="pad_bottom5">
                                        <asp:Label ID="lblPriIns" runat="server" CssClass="fontColor">  </asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td>Secoundary:</td>
                                    <td>
                                        <asp:Label ID="lblSecIns" runat="server" CssClass="fontColor"></asp:Label></td>
                                </tr>
                                <%--/// Modified By Irfan Mahmood 9/August/2022 : Add Provider --%>

                                <tr>
                                    <td>Attending Physician</td>
                                    <td>
                                        <asp:Label runat="server" ID="ProvderName" CssClass="fontColor"></asp:Label></td>
                                </tr>
                                <%--/// Modified By Irfan Mahmood 9/August/2022 : Add Provider --%>
                            </table>


                        </fieldset>
                    </td>
                    <td style="width: 33.33%">
                        <fieldset>
                            <legend>Payment Info</legend>
                            <table>
                                <tr>
                                    <td>Total Charges:</td>
                                    <td>
                                        <asp:Label ID="lblTotalCharges" runat="server" CssClass="fontColor fontWeight">$0.00</asp:Label></td>
                                    <td>Total Payment:</td>
                                    <td>
                                        <asp:Label ID="lblTotalPaid" runat="server" CssClass="fontColor fontWeight">$0.00</asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Primary Paid:</td>
                                    <td>
                                        <asp:Label ID="lblPriPaid" runat="server" CssClass="fontColor">$0.00</asp:Label>
                                    </td>
                                    <td>Secondary Paid: </td>
                                    <td>
                                        <asp:Label ID="lblSecPaid" runat="server" CssClass="fontColor">$0.00</asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Other paid:</td>
                                    <td>
                                        <asp:Label ID="lblOthPaid" runat="server" CssClass="fontColor">$0.00</asp:Label>
                                    </td>
                                    <td>Patient Paid :</td>
                                    <td>
                                        <asp:Label ID="lblPatPaid" runat="server" CssClass="fontColor">$0.00</asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Balance Due: </td>
                                    <td>
                                        <asp:Label ID="lblBalanceDue" runat="server" CssClass="fontColor fontWeight">$0.00</asp:Label></td>
                                    <td>Adjusted: </td>
                                    <td>
                                        <asp:Label ID="lblAdjusted" runat="server" CssClass="fontColor">$0.00</asp:Label></td>
                                </tr>
                            </table>


                        </fieldset>
                    </td>
                </tr>
            </table>
        </div>
        <div class="DX_Code_Info">
            <div class="Grid">
                <table class="cptTable">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Code</th>
                            <th>Diagnosis</th>
                            <th>#</th>
                            <th>Code</th>
                            <th>Diagnosis</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="width: 5%"><span class="id_setting">1</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode1"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode1Desc"></asp:Label></td>

                            <td style="width: 5%"><span class="id_setting">7</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode7"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode7Desc"></asp:Label></td>




                        </tr>
                        <tr>

                            <td><span class="id_setting">2</span></td>
                            <td>
                                <asp:Label runat="server" ID="dxcode2"></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="dxcode2Desc"></asp:Label></td>


                            <td style="width: 5%"><span class="id_setting">8</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode8"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode8Desc"></asp:Label></td>


                        </tr>
                        <tr>

                            <td style="width: 5%"><span class="id_setting">3</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode3"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode3Desc"></asp:Label></td>

                            <td style="width: 5%"><span class="id_setting">9</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode9"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode9Desc"></asp:Label></td>


                        </tr>
                        <tr>
                            <td style="width: 5%"><span class="id_setting">4</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode4"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode4Desc"></asp:Label></td>

                            <td style="width: 5%"><span class="id_setting">10</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode10"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode10Desc"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5%"><span class="id_setting">5</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode5"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode5Desc"></asp:Label></td>

                            <td style="width: 5%"><span class="id_setting">11</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode11"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode11Desc"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 5%"><span class="id_setting">6</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode6"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode6Desc"></asp:Label></td>

                            <td style="width: 5%"><span class="id_setting">12</span></td>
                            <td style="width: 5%">
                                <asp:Label runat="server" ID="dxcode12"></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:Label runat="server" ID="dxcode12Desc"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="Service_Location_Info">
            <table>
                <tr>
                    <td>Service Location :
                        <asp:Label runat="server" ID="lblserviceLocation" CssClass="fontColor" /></td>
                    <td>Admission Date :
                        <asp:Label runat="server" ID="lblAdmissionDate" CssClass="fontColor" /></td>
                    <td>Discharge Date :
                        <asp:Label runat="server" ID="lblDischargeDate" CssClass="fontColor" /></td>

                </tr>
            </table>
        </div>
        <span class="Paymentslbl">Payment Summary</span>
        <div class="ClaimSummary">

            <div class="Grid">
                <table class="cptTable">

                    <thead>
                        <tr runat="server" id="cpttr_head">

                            <th>DOS</th>
                            <th>Service</th>
                            <th>Unit</th>
                            <th>Charges</th>
                            <th>Allowed Amount</th>
                            <th>Paid Amount</th>
                            <th>Primary-Paid</th>
                            <th>Secondary-Paid</th>
                            <th>Patient-Paid</th>
                            <th>Adjusted</th>
                            <th>Balance Due</th>

                        </tr>

                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="RepeaterSummary">
                            <ItemTemplate>



                                <tr runat="server" id="cpttr_data">

                                    <td runat="server" id="tdClaimChargesId" style="display: none">
                                        <%# Eval("ClaimChargesId")%>
                                    </td>
                                    <td runat="server" id="CptCodetd">
                                        <%# Eval("DOS")%>
                                    </td>

                                    <td style="width: 30%">
                                        <%# Eval("CPTdescription")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("ServiceUnits")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("TotalCharges")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("AllowedAmount")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("PaidAmount")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("PriInsPaidAmount")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("SecInsPaidAmount")%>
                                    </td>

                                    <td class="txtalign-right">
                                        <%# Eval("PatPaidAmount")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("AdjustedAmount")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("BalanceDue")%>
                                    </td>


                                </tr>





                            </ItemTemplate>


                        </asp:Repeater>
                    </tbody>



                </table>
            </div>
        </div>


        <span class="Paymentslbl">Payment Detail</span>

        <div class="CPT_Code_Info">

            <div class="Grid">
                <table class="cptTable">



                    <asp:Repeater runat="server" ID="rptClaim" OnItemDataBound="rptClaim_ItemDataBound">
                        <ItemTemplate>
                            <thead>
                                <tr runat="server" id="cpttr_head">

                                    <th>DOS</th>
                                    <th>Service</th>

                                    <th>Charges</th>
                                    <th>Payment Source</th>
                                    <th>Check #</th>
                                    <th>CheckDate</th>
                                    <th>Allowed Amount</th>
                                    <th>Paid Amount</th>

                                </tr>

                            </thead>

                            <tbody>
                                <tr runat="server" id="cpttr_data">

                                    <td runat="server" id="tdClaimChargesId" style="display: none">
                                        <%# Eval("ProcedurePaymentsId")%>
                                    </td>
                                    <td runat="server" id="CptCodetd" class="txtalign-cntr">
                                        <%# Eval("DOS")%>
                                    </td>

                                    <td style="width: 30%">
                                        <%# Eval("CPTdescription")%>
                                    </td>
                                    <td class="txtalign-right">
                                        <%# Eval("TotalCharges")%>
                                    </td>
                                    <td>
                                        <%# Eval("PaymentSource")%>
                                    </td>

                                    <td>
                                        <%# Eval("CheckNumber")%>
                                    </td>
                                    <td class="txtalign-cntr">
                                        <%# Eval("CheckDate")%>
                                    </td>

                                    <td class="txtalign-right">
                                        <%# Eval("AllowedAmount")%>
                                    </td>

                                    <td class="txtalign-right">
                                        <%# Eval("PaidAmount")%>
                                    </td>

                                </tr>

                                <tr runat="server" id="trReasons" class="fontColor">

                                    <td colspan="10" class="borderbottom">
                                        <asp:Label ID="lblReasons" runat="server"></asp:Label></td>
                                </tr>
                                <%--   <tr runat="server" id="trCoInsuranc" class="fontColor">
                              
                               <td colspan="10" class="borderbottom"><asp:Label ID="lblCoInsurance" runat="server"></asp:Label></td>
                           </tr>
                            <tr runat="server" id="trcpay" class="fontColor">
                              
                               <td colspan="10" class="borderbottom"><asp:Label ID="lblCopay" runat="server"></asp:Label></td>
                           </tr>--%>
                            </tbody>


                        </ItemTemplate>


                    </asp:Repeater>


                </table>
            </div>
        </div>

        <span class="ClaimNoteslbl">Claim Notes</span>
        <div class="ClaimNotes">

            <div class="Grid">
                <table class="ClaimNotesTable">
                    <thead>
                        <tr runat="server" id="Tr1">
                            <th style="width: 5%; display: none;">Notes Id</th>
                            <th style="width: 2%;" class="desc sortable-header">Notes Date
                                 <span style="cursor: pointer" onclick="FilterSortingNotes(this,'CheckNoteDate')">
                                     <img src="../../Images/Down-Sort.png" class="imgGrayDown" style="width: 6px; display: inline;">
                                     <img src="../../Images/Up-Sort.png" class="imgGreenUp" style="width: 6px; display: inline; display: none">
                                     <img src="../../Images/Down-GreenSort.png" class="imgGreenDown" style="width: 6px; display: inline; display: none">
                                 </span>
                            </th>
                            <th class="desc sortable-header">Notes
                                 <span style="cursor: pointer" onclick="FilterSortingNotes(this,'CheckNote')">
                                     <img src="../../Images/Down-Sort.png" class="imgGrayDown" style="width: 6px; display: inline;">
                                     <img src="../../Images/Up-Sort.png" class="imgGreenUp" style="width: 6px; display: inline; display: none">
                                     <img src="../../Images/Down-GreenSort.png" class="imgGreenDown" style="width: 6px; display: inline; display: none">
                                 </span>
                            </th>
                            <th style="width: 10%;" class="desc sortable-header">Category
                                 <span style="cursor: pointer" onclick="FilterSortingNotes(this,'CheckNotesCategory')">
                                     <img src="../../Images/Down-Sort.png" class="imgGrayDown" style="width: 6px; display: inline;">
                                     <img src="../../Images/Up-Sort.png" class="imgGreenUp" style="width: 6px; display: inline; display: none">
                                     <img src="../../Images/Down-GreenSort.png" class="imgGreenDown" style="width: 6px; display: inline; display: none">
                                 </span>
                            </th>
                            <th style="width: 10%; display: none;">User Name</th>
                        </tr>

                    </thead>
                    <tbody id="tbodyClaimNotes">
                        <asp:Repeater runat="server" ID="rptClaimNotes">
                            <ItemTemplate>
                                <tr runat="server" id="cpttr_data">
                                    <td runat="server" id="tdClaimNotesId" style="display: none;">
                                        <%# Eval("ClaimNotesId")%>
                                    </td>
                                    <td style="width: 5%; text-align: center;" id="tdNoteDate">
                                        <%# Eval("NoteDate")%>
                                    </td>
                                    <td class="txtalign-left">
                                        <%# Eval("Notes")%>
                                    </td>
                                    <td class="txtalign-left">
                                        <%# Eval("CategoryName")%>
                                    </td>
                                    <td class="txtalign-right" style="display: none;">
                                        <%# Eval("UserName")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

    </div>
        <script type="text/javascript">          
            $(document).ready(function () {
                debugger;
                var Address = $("[id$='lblAddress']").text();
                var Zip = $("[id$='lblZip']").text();
                if (Address == "" || Zip == "") {
                    $(".AddressDetails").html("");
                }
            });
            var rowCount = $('#tbodyClaimNotes tr').length;
            if (rowCount == 0) {
                $("#tbodyClaimNotes").append("<tr><td colspan='5' class='ClaimNotesMessage'>No Record Found!</td></tr>");
            }
        </script>
        ###EndAllClaims###
        <%--start added by Arslan satti on 04-20-2022--%>
        ###StartClaimNotes###
        <asp:Repeater runat="server" ID="rptFilterClaimNotes">
            <ItemTemplate>
                <tr runat="server" id="cpttr_data">
                    <td runat="server" id="tdClaimNotesId" style="display: none;">
                        <%# Eval("ClaimNotesId")%>
                    </td>
                    <td style="width: 5%; text-align: center;" id="tdNoteDate">
                        <%# Eval("NoteDate")%>
                    </td>
                    <td class="txtalign-left">
                        <%# Eval("Notes")%>
                    </td>
                    <td class="txtalign-left">
                        <%# Eval("CategoryName")%>
                    </td>
                    <td class="txtalign-right" style="display: none;">
                        <%# Eval("UserName")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        ###EndClaimNotes###
        <%--end added by Arslan satti on 04-20-2022--%>
    </form>
</body>
</html>
