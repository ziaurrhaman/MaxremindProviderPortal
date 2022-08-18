<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashboardColumnChartDetail.aspx.cs" Inherits="ProviderPortal_Claim_DashboardColumnChartDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
</head>
<body>
    <form id="form1" runat="server">


             ###StartCharges###
        <div id="Charges">
               <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <%--<link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />--%>

          <script src="../../Scripts/Rizwan/DashboardCharts.js"></script>


             <div class="WidgetContent">
        <div class="WidgetReport">
            <div class="WidgetReportContent">
                <div class="ReportGrid" style="max-height:367px;overflow-y:scroll;overflow-x:hidden;">
                    <table>
                        <thead>
                            <tr>
                                  <th>#</th>
                                <th>Date</th>
                                <th>Charges</th>
                            </tr>
                          

                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptcharges" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>  <%# Container.ItemIndex + 1 %>

                                        </td>
                                          <td>
                                                 <%# Eval("ServiceDate" ,"{0:d}")%>
                                          </td>
                                          <td>
                                                 <%# Eval("TotalCharges")%>
                                          </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
             

            </div>

        </div>
        </div>

               <div>
                    <table>
                        <tbody>
                            <tr style="width:100%">
                                 <td style="width:33.33%"></td>
                                <td style="width:33.33%"></td>
                                <td style="width:33.33%"><asp:Label ID="SumCharges" runat="server"></asp:Label></td>
                            </tr>
                           
                        </tbody>
                    </table>
                </div>
        </div>

             ###EndCharges###



         ###StartPayments###
        <div id="Payments">
               <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <%--<link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />--%>

          <script src="../../Scripts/Rizwan/DashboardCharts.js"></script>


             <div class="WidgetContent">
        <div class="WidgetReport">
            <div class="WidgetReportContent">
                <div class="ReportGrid" style="max-height:367px;overflow-y:scroll;overflow-x:hidden;">
                    <table>
                        <thead>
                            <tr>
                                  <th>#</th>
                                <th>Date</th>
                                <th>Payments</th>
                            </tr>
                          

                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptPayments" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>  <%# Container.ItemIndex + 1 %>

                                        </td>
                                          <td>
                                                 <%# Eval("ServiceDate" ,"{0:d}")%>
                                          </td>
                                          <td>
                                                 <%# Eval("PaidAmount")%>
                                          </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
             

            </div>

        </div>
        </div>

               <div>
                    <table>
                        <tbody>
                            <tr style="width:100%">
                                 <td style="width:33.33%"></td>
                                <td style="width:33.33%"></td>
                                <td style="width:33.33%"><asp:Label ID="SumPayment" runat="server"></asp:Label></td>
                            </tr>
                           
                        </tbody>
                    </table>
                </div>
        </div>

             ###EndPayments###

        ###StartAdjustment###
        <div id="Adjustment">
               <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <%--<link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />--%>

          <script src="../../Scripts/Rizwan/DashboardCharts.js"></script>


             <div class="WidgetContent">
        <div class="WidgetReport">
            <div class="WidgetReportContent">
                <div class="ReportGrid" style="max-height:367px;overflow-y:scroll;overflow-x:hidden;">
                    <table>
                        <thead>
                            <tr>
                                  <th>#</th>
                                <th>Date</th>
                                <th>Adjustments</th>
                            </tr>
                          

                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptAdjustment" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>  <%# Container.ItemIndex + 1 %>

                                        </td>
                                          <td>
                                                 <%# Eval("ServiceDate" ,"{0:d}")%>
                                          </td>
                                          <td>
                                                 <%# Eval("AdjustedAmount")%>
                                          </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
             

            </div>

        </div>
        </div>

               <div>
                    <table>
                        <tbody>
                            <tr style="width:100%">
                                 <td style="width:33.33%"></td>
                                <td style="width:33.33%"></td>
                                <td style="width:33.33%"><asp:Label ID="SumAdjustment" runat="server"></asp:Label></td>
                            </tr>
                           
                        </tbody>
                    </table>
                </div>
        </div>

             ###EndAdjustment###
    </form>
</body>
</html>
