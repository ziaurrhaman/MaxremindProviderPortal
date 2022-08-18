<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterClaimsDetail.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterClaimsDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <div>
      ###StartProcedureDetail###
        <div class="parent">
         <%--  <div style="text-align:center"> <span style="background-color: #aadeff;padding: 5px;">Procedure Detail</span></div>--%>
               <div class="exportSummary">
                   <span style="float: left; margin-left: 5px;padding-top: 7px;box-sizing: border-box;">Export To: &nbsp;</span>                         

             <span style="float: left;padding-top:2px;margin-left:7px">
                  <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('Procedure Detail',this,'printableAreaRDC');">
                       <option></option>
                       <option value="Excel">Excel</option>
                       <option value="PDF" >PDF</option>
                       <option value="Word">Word</option>
                  </select>
             </span>         
                   
                   
                      <span style="margin-left:10px;cursor:pointer;margin-top:5px;position:absolute;" onclick="PrintReoprt('printableAreaRDC')"><img src="../../Images/PrintView1.png" alt="img" /></span>
                        
     </div> 
    
      <div class="Grid GridReports" id="printableAreaRDC"  style="height:400px;overflow-y:auto">
      
        <table id="fixTable">
                                    <thead>
                                        <tr>
                                            <th class="center" style="width:2%">
                                                <span class="report-column-title">#</span>
                                            </th>
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">Claim Id</span>
                                            </th>
                                              <th class="center"  style="width:12%">
                                                <span class="report-column-title">Patient</span>
                                            </th> 
                                            <th class="center" style="width:5%">
                                                <span class="report-column-title">DOS</span>
                                            </th> 
                                            <th class="center" style="width:4%">
                                                <span class="report-column-title">CPT</span>
                                            </th>                                                   
                                             <th class="center" style="width:2%">
                                                <span class="report-column-title">Charges</span>
                                            </th>
                                             <th class="center"  style="width:2%">
                                                <span class="report-column-title">Allowed Amt</span>
                                            </th>
                                            <th class="center" style="width:2%">
                                                <span class="report-column-title">Paid Amt</span>
                                            </th>
                                             <th class="center" style="width:2%">
                                                <span class="report-column-title">Due Amt</span>
                                            </th>
                                            <th class="center" style="width:15%">
                                                <span class="report-column-title">Provider</span>
                                             </th>
                                            <th class="center" style="width:15%">
                                                <span class="report-column-title">Location</span>
                                             </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyChargedProcedure">
                                        <asp:Repeater id="rptReportData"  runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                   <td class="center">
                                                        <%# Eval("RN")%>
                                                    </td>
                                                     <td class="center">
                                                        <%# Eval("ClaimId")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Patient")%>
                                                    </td>
                                                   
                                                    <td class="AlignDate">
                                                        <%# Eval("DOS")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("CPTCode")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("charges" ,"{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("allowedamt", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("PaidAmt", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("DueAmt", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignString">
                                                        <%# Eval("Provider")%>
                                                    </td>
                                                     <td class="AlignString">
                                                        <%# Eval("location")%>
                                                    </td> 
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
    </div>

            </div>
       <script>
           $(document).ready(function () { $("#fixTable").tableHeadFixer(); });
            </script>
     ###EndProcedureDetail###
    
    
   
      ###StartCLMDetail###
        <div class="parent">
         <%-- <div style="text-align:center"> <span style="background-color: #aadeff;padding: 5px;">Claim  Detail</span></div>--%>
               <div class="exportSummary">
                   <span style="float: left; margin-left: 5px;padding-top: 7px;box-sizing: border-box;">Export To: &nbsp;</span>                         

             <span style="float: left;padding-top:2px;margin-left:7px">
                  <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('Claim Detail',this,'printableAreaRDC');">
                       <option></option>
                       <option value="Excel">Excel</option>
                       <option value="PDF" >PDF</option>
                       <option value="Word">Word</option>
                  </select>
             </span>         
                   
                   
                      <span style="margin-left:10px;cursor:pointer;margin-top:5px;position:absolute;" onclick="PrintReoprt('printableAreaRDC')"><img src="../../Images/PrintView1.png" alt="img" /></span>
                        
     </div> 
    
      <div class="Grid GridReports" id="printableAreaRDC"  style="height:400px;overflow-y:auto">
      
        <table id="fixTable2">
                                    <thead>
                                        <tr>
                                            <th class="center" style="width:2%">
                                                <span class="report-column-title">#</span>
                                            </th>
                                            <th class="center" style="width:6%">
                                                <span class="report-column-title">Claim Id</span>
                                            </th>
                                              <th class="center"  style="width:12%">
                                                <span class="report-column-title">Patient</span>
                                            </th> 
                                            <th class="center" style="width:8%">
                                                <span class="report-column-title">DOS</span>
                                            </th> 
                                                                                              
                                             <th class="center" style="width:2%">
                                                <span class="report-column-title">Charges</span>
                                            </th>
                                             <th class="center"  style="width:2%">
                                                <span class="report-column-title">Paid Amt</span>
                                            </th>
                                            <th class="center" style="width:2%">
                                                <span class="report-column-title">Due Amt</span>
                                            </th>
                                            <th class="center" style="width:12%">
                                                <span class="report-column-title">Provider</span>
                                             </th>
                                            <th class="center" style="width:10%">
                                                <span class="report-column-title">Location</span>
                                             </th>
                                             <th class="center" style="width:15%">
                                                <span class="report-column-title">Claim Status</span>
                                             </th>

                                        </tr>
                                    </thead>
                                    <tbody id="tbodyChargedClm">
                                        <asp:Repeater id="rptclmdetail"  runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                   <td class="AlignDate">
                                                        <%# Eval("RN")%>
                                                    </td>
                                                    <td class="AlignDate">
                                                        <%# Eval("claimid")%>
                                                    </td>
                                                   
                                                    <td class="AlignString">
                                                        <%# Eval("Patient")%>
                                                    </td>
                                                    <td class="center">
                                                        <%# Eval("Dos")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("Charges", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("paidamt", "{0:0.00}")%>
                                                    </td>
                                                    <td class="AlignPayment">
                                                        $<%# Eval("dueamt", "{0:0.00}")%>
                                                    </td>
                                                  
                                                    <td class="AlignString">
                                                        <%# Eval("Provider")%>
                                                    </td>
                                                     <td class="AlignString">
                                                        <%# Eval("location")%>
                                                    </td>
                                                     <td class="AlignString">
                                                        <%# Eval("claimstatus")%>
                                                    </td> 
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
    </div>
            </div>
       <script>
           $(document).ready(function () { $("#fixTable2").tableHeadFixer(); });
            </script>
    ###EndCLMDetail###
    </div>
    </form>
</body>
</html>
