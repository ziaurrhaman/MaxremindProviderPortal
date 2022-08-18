<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterDialoguePaymentsHandler.aspx.cs" Inherits="ProviderPortal_ReportsNew_FilterDialoguePaymentsHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartPatSearch###
        <div class="maindivofddl">
         <div class="ddlselect">
         <ul id="ulMultiPatientName">
             <li style="float: left; width: 100%;">
            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkPatientNameAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All Patients</span>
                                                <input type="hidden" value="0" />
                                            </label>
               </li>
           <asp:Repeater runat="server" ID="rptPatientName">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("PatientId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkPatientName chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                        <span class="ddltextname"><%#Eval("PatientName") %></span>
                                                        <input type="hidden" value='<%#Eval("PatientId") %>' id="PatientId"/>
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
          </ul>

             <input type="hidden"  class="SplitIds" />
           </div>
            <div class="okclosebtnforrpt" >
                
                     <input type="button" class="Okbtnrpt" value="Ok" onclick="Okfunc(this)" style="min-width: 12%;height: 25px;" />
                     <input type="button" class="Closebtnrpt" value="Close" onclick="Closefunc(this)" style="min-width: 12%;height: 25px;" />
                
             </div>
            </div>
    ###EndPatSearch###

    </div>

        <div>
        ###StartInsSearch###
        <div class="maindivofddl">

            <div class="Searchtxtforddlls">
                <input type="text" runat="server" class="SearchRecord" style="width: 94.5%;" placeholder="Seacrh Record" onkeyup = "SetSearch(event,'divPayerScenario',this)" />
                 <div class="dropDownIconNewSearch"  onclick="FilterReportddlRecord(this);">
                <img src="../../Images/SmallSearch.gif" style="width:40%;"/></div>
            </div>
          <div class="<%--ddlselect--%>" id="ulMultiDenailPayerNameID" style="float: left;max-height: 170px;overflow-y: auto; margin-bottom: -2px;">
               <ul id="ulMultiDenailPayerName">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkDenailPayerNameAll" class="chk-multi-checkboxes-all"  checked="checked"/>
                                                <span>All</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                       
                                        <asp:Repeater runat="server" ID="rptDenailPayerName">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("Name") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkDenailPayerName chk-multi-checkboxes"  onclick="ReportAlert(this)" checked="checked"/>
                                                        <span class="ddltextname"><%#Eval("Name") %></span>
                                                        <input type="hidden" value='<%#Eval("InsuranceId") %>' id="PatientId"/>
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                 
                                    </ul>
               <input type="hidden" class="SplitIds" />
               
                                </div>
             <div class="okclosebtnforrpt" >
                
                     <input type="button" class="Okbtnrpt" value="Ok" onclick="Okfunc(this)" style="min-width: 12%;height: 25px;" />
                     <input type="button" class="Closebtnrpt" value="Close" onclick="Closefunc(this)" style="min-width: 12%;height: 25px;" />
                
             </div>
            </div>
        ###EndInsSearch###
        </div>
    </form>
</body>
</html>
