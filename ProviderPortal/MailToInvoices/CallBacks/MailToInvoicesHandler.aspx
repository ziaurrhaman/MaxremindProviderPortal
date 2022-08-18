<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailToInvoicesHandler.aspx.cs" Inherits="ProviderPortal_MailToInvoices_CallBacks_MailToInvoicesHandler" %>

<!DOCTYPE html>
<%--Created By Agha Sibtain, Dated:04/10/2019--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        ###StartMailToInvoices###        
                <asp:Repeater ID="rptDetailMailToInvoice" runat="server">
                    <ItemTemplate>
                        <tr id="trMailTo2" class="MailToInvoice content" style="width: 100%;cursor: pointer" onclick="ViewFileContents(this)">
                            <td class="nametd nametdAlignCenter" style="padding: 10px;" title="<%# Eval("FileName")%>">
                                <%# Eval("FileName")%>
                            </td>
                            <td class="nametd" id="tdFileContents" style="display:none;text-align:center;padding: 5px;">
                                <%# Eval("FileContents") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
        <style>
                            .PatientInvoice {
                                width: 712px;
                                margin: 0 auto;
                                page-break-after: always;
                            }

                            .PatientInvoice {
                                font-family: arial;
                                font-size: 12px;
                            }

                            .InvoiceHeader {
                                width: 100%;
                                float: left;
                            }

                            .InvoiceHeaderCol {
                                width: 50%;
                                float: left;
                            }

                            .InvoiceHeaderUpper {
                                width: 100%;
                                float: left;
                            }

                            .ServiceProvider {
                                margin-top: 15px;
                                line-height: 18px;
                                margin-bottom: 15px;
                                margin-left: 5px;
                            }

                            .SrviceProviderName {
                                font-size: 11px;
                                font-weight: bold;
                            }

                            .divCheckBox {
                                width: 9px;
                                height: 9px;
                                border: 1px solid black;
                                float: left;
                            }

                            .PatientInfo {
                                margin-top: 44px;
                                line-height: 18px;
                            }

                            .PatientName {
                                font-weight: bold;
                                font-size: 13px;
                            }

                            .VisaCard {
                                border: 1px solid black;
                                width: 100%;
                                float: left;
                            }

                            .Col3 {
                                text-align: center;
                                font-weight: bold;
                                font-size: 11px;
                            }

                            .AmountPaid {
                                width: 50%;
                                float: right;
                                height: 45px;
                                font-size: 13px;
                                border-right: 1px solid black;
                                border-bottom: 1px solid black;
                                border-left: 1px solid black;
                                margin-right: -2px;
                                padding: 5px;
                                box-sizing: border-box;
                            }

                            .Seprator {
                                width: 100%;
                                float: left;
                                text-align: center;
                            }

                            .DetailHeading {
                                width: 100%;
                                font-size: 16px;
                                font-weight: bold;
                                text-align: center;
                                margin-top: 15px;
                                float: left;
                            }

                            .StatementTable {
                                width: 100%;
                                border: 1px solid black;
                                margin-bottom: 5px;
                                font-size: 11px;
                            }

                            .StatementTable tr {
                                height: 20px;
                            }

                            .StatementTable th {
                                border-right: 1px solid black;
                                border-bottom: 1px solid black;
                                font-size: 12px;
                                box-sizing: border-box;
                            }

                            .StatementTable td {
                                border-right: 1px solid black;
                            }

                            .BalancBox {
                                width: 30%;
                                float: left;
                                border: 1px solid black;
                                margin-top: 10px;
                            }

                            .BalanceRow {
                                width: 100%;
                                float: left;
                                font-weight: bold;
                                height: 26px;
                                border-bottom: 1px solid black;
                            }

                            .BalanceColumnL {
                                width: 60%;
                                float: left;
                                font-weight: bold;
                                border-right: 1px solid black;
                                height: 100%;
                                padding: 5px;
                                box-sizing: border-box;
                            }

                            .BalanceColumnR {
                                width: 39%;
                                float: left;
                                text-align: center;
                                margin-top: 5px;
                            }

                            .PaymentGrid {
                                width: 100%;
                                float: left;
                                border: 1px solid black;
                                margin-top: 10px;
                                margin-bottom: 10px;
                            }

                            .PaymentGridCol {
                                width: 11.1%;
                                float: left;
                                text-align: center;
                                font-weight: bold;
                            }

                            .PaymentGridRow {
                                width: 100%;
                                float: left;
                                border-bottom: 1px solid black;
                                border-right: 1px solid black;
                                height: 27px;
                            }

                            .PaymentGridRow2 {
                                width: 100%;
                                float: left;
                                border-bottom: 1px solid black;
                                border-right: 1px solid black;
                                height: 22px;
                                padding-top: 5px;
                            }

                            .backTest {
                                background: black !important;
                                -webkit-print-color-adjust: exact;
                            }
        </style>
        ###EndMailToInvoices###
    

        ###SMailBatch###
          <asp:Repeater ID="rptMailToInvoices" runat="server">
                    <ItemTemplate>
                        <tr id="trMailTo1" class="MailToInvoice content" style="width: 100%;cursor: pointer" onclick="ShowDetails(' <%# Eval("ModifiedDate") %>', this)">
                          
                            <td title="Total Invoices : <%# Eval("TotalInvoice") %>" class="nametd nametdAlignCenter" style="padding: 10px;padding-left: 25px;">
                                <%# Eval("Batch") %>
                            </td>             
                                         
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

        ###EMailBatch###

    </div>
    </form>
</body>
</html>
