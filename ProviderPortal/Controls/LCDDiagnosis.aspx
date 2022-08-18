<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCDDiagnosis.aspx.cs" Inherits="ProviderPortal_Controls_LCDDiagnosis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartForm###
    <div class="theme-1-form" style="height: 515px; border: 1px solid lightgray;">
        <div class="left-side-bar">
            <div class="box-height-1 box-coloured-0">
                <span class="heading-1 bold">CMS Coverage Description for Diagnosis:</span>
            </div>
            <div class="box-height-1 box-coloured-1">
                <span class="center bold heading-1">Policies</span>
            </div>
            <div class="ul-wrapper">
                <input type="text" onkeyup="LCD_FilterPolicies_Dx(this);" style="margin: 6px auto; display: inherit;" />
                <ul id="ulPolicies">
                    <asp:Repeater runat="server" ID="rptLcds">
                        <ItemTemplate>
                            <li onclick="LCD_ClickLCD_DX(this);">
                                <%#Eval("title")%>

                                <input type="hidden" class="hdnLcdId" value='<%#Eval("lcd_id")%>' />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div id="divLcdDxDetailMainWrapper" class="right-contents">
            <div class="box-height-1 box-coloured-1">
                <span runat="server" id="spnTopDescription" class="heading-1"></span>
            </div>
            <div class="box-height-1 box-coloured-2" style="position: relative; height: 15px;">
                <div style="position: absolute; width: 100%; top: 9px;">
                    <span runat="server" id="spnLcdTitle" class="center bold heading-1"></span>
                    <span runat="server" id="spnLcdDates" class="center heading-0"></span>
                </div>
            </div>
            <div class="float-left-100">
                <div class="content-box-1">
                    <div runat="server" id="divPolicyDescription"></div>
                </div>
                <div class="right-bar-0">
                    <div class="box-height-0 box-coloured-3">
                        <span class="center bold heading-1">Bill Codes</span>
                    </div>
                    <div class="content-box-0">
                        
                    </div>
                    <div class="box-height-0 box-coloured-3">
                        <span class="center bold heading-1">Articles</span>
                    </div>
                    <div class="content-box-0">
                        
                    </div>
                </div>
            </div>
            <div class="float-left-100">
                <div class="box-height-0 box-coloured-3">
                    <span class="center bold heading-1">Procedure Supported</span>
                </div>
                <div style="height: 50px;">
                    <span style="color: red; font-weight: bold; font-size: 28px; margin: 5px;">*</span>
                </div>
                <div style="height: 147px; overflow-y: auto;">
                    <div class="Grid-Simple">
                        <table>
                            <thead>
                                <tr>
                                    <th style="width: 285px;">
                                        Procedure
                                    </th>
                                    <th style="width: 100px;">
                                        Charges
                                    </th>
                                    <th>
                                        Notes
                                    </th>
                                </tr>
                                <tr>
                                    <th>
                                        <input type="text" onkeyup="LCD_FilterProcedure(this);" />
                                    </th>
                                    <th>
                                        
                                    </th>
                                    <th>
                                        
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyProcedureSupported">
                                <asp:Repeater runat="server" ID="rptProcedureSupported">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("ProcedureSupported")%>
                                            </td>
                                            <td>
                                                <%#Eval("Charges")%>
                                            </td>
                                            <td>
                                                <%#Eval("paragraph")%>
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
    </div>
    ###EndForm###
    
    ###StartLCDCount###
    <asp:Literal runat="server" ID="ltrLCDCount"></asp:Literal>
    ###EndLCDCount###
    </div>
    </form>
</body>
</html>
