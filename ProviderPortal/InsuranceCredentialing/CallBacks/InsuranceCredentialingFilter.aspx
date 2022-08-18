<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsuranceCredentialingFilter.aspx.cs" Inherits="ProviderPortal_InsuranceCredentialing_InsuranceCredentialingFilter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###StartInsuFilter###
        <%--  //Comment --%>
    <div class="Grid" style="width:43.1%">
         <table style="table-layout:fixed;width:100%"> 
                                           <thead>     
                                                <tr>  
                                                
                                                    <th style="width:25%;word-wrap:break-word">
                                                        <span class="report-column-title">Payer Ids</span><span></span>
                                                    </th>
                                                    <th style="width:75%;word-wrap:break-word">
                                                        <span class="report-column-title">Insurance Name</span><span class="filterIcon asc" style="float:right;margin-right:5px;margin-top:1px;cursor:pointer" onclick="CloseInsuranceFilterdiv()"><img src="../../../Images/crossA.png" style="height: 14px;width: 14px;background: white;border-radius: 6px;" /></span>
                                                    </th>
                                                    
                                                 
                                              
                                              
                                                </tr>
                                    
                                            </thead>
                                            <tbody id="tbodyReportList">
                                 <asp:Repeater ID="rptInsuranceFilter" runat="server">
                                <ItemTemplate>
                                    <tr onclick="SelectInsuName('<%# Eval("Name")%>','<%# Eval("InsuranceId")%>')" style="cursor:pointer">
                                        
                                        <td>
                                            <%# Eval("PayerId")%>
                                        </td>
                                        <td>
                                            <%# Eval("Name")%>
                                        </td>
                                       
                                  
                                    </tr>
                                </ItemTemplate>
                                 </asp:Repeater>
                                    </tbody>
                                </table>
    </div>

        ###EndInsuFilter###

        ###StartInsuCredGrid###

           <asp:Repeater ID="rptInsuranceCredentialing" runat="server">
                                 <ItemTemplate>
                                    <tr class="Insurance">
                                       
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td style="font-size:11px">
                                            <%# Eval("Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("Status")%>
                                        </td>
                                        <td style="word-wrap:break-word">
                                           <%# Eval("Source")%>
                                        </td>
                                      
                                        <td>
                                           <%# Eval("NPI")%>
                                        </td>
                                        <td>
                                           <%# Eval("TaxId")%>
                                        </td>
                                        <td>
                                           <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                           <%# Eval("StartDate")%>
                                        </td>
                                        <td>
                                           <%# Eval("TargetDate")%>
                                        </td>                                                                                
                                         <td>
                                           <%# Eval("GroupId")%>
                                        </td>
                                         <td>
                                           <%# Eval("ProviderPTAN")%>
                                        </td>
                                         <td>
                                             <input type="password" class="Password" value="<%# Eval("SSN")%>" style="background: none !important;border: none;box-shadow: none;font-size:10px;font-weight:bold" disabled="disabled"> 
                                             <span style="margin-left: 73px;margin-top: -16px;float: left;"><i  id="pass-status" class="fa fa-eye" title="View SSN" onclick="viewSSN(this)"></i></span>                                              </td>
                                        <td>
                                           <%# Eval("Remarks")%>
                                        </td>
                                  

                                    </tr>
                                </ItemTemplate>
                                 </asp:Repeater>
          <asp:HiddenField runat="server" ID="hdnTotalRowsInsuranceCredentialingGrid" />
        ###EndInsuCredGrid###
        <div>
            ###StartNpiTax###               
            <asp:HiddenField runat="server" ID="NPITXT" />
            <asp:HiddenField runat="server" ID="TAXTXT" />
            ###EndNpiTax###
        </div>
    </form>
</body>
</html>
