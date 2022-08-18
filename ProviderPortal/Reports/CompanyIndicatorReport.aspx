<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="CompanyIndicatorReport.aspx.cs" Inherits="CompanyIndicatorReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     ###StartReport###
    <div class="Widget" style="margin-top: 10px;">
        <%--<div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Company Indicator</span>
        </div>--%>

          <div class="reportsCriteriabar" style="background:#dfe3e5;height: 36px;">
            <div class="report-criteria-wraper" style="width:50% !important;font-weight: bold;">
                <br />
                            <span>Time Span:</span>
                            <asp:Label runat="server" ID="Label"></asp:Label>
                           
            </div>
           
        </div>

        <div class="WidgetContent">
            <div class="WidgetFilterBox">
                   <div id="div_Table" style="width: 90%; float: left">
                        <div id="div_checkboxis" style="padding: 10px 0px 10px 10px; box-sizing: border-box;">
                            <span class="margin_R10">
                                <asp:CheckBox runat="server" ID="chkMonthToDate" Text="Month to Date" onclick="CheckBoxClick(this);" /></span>
                           
                                <span class="margin_R10"><asp:CheckBox runat="server" ID="chkLastMonth" Text="Last Month" onclick="CheckBoxClick(this);" /></span>
                            <span class="margin_R10">
                                <asp:CheckBox runat="server" ID="chkYearToDate" Text="Year to Date" onclick="CheckBoxClick(this);" /></span>
                            <span class="margin_R10">
                                <asp:CheckBox runat="server" ID="chkSelectDate" Text="Select Dates" onclick="CheckBoxClick(this);" /></span>
                               <span style="margin-left: 19px;" class="margin_R10">

                                <asp:RadioButton runat="server" ID="PostRb" GroupName="radio" Checked="true"/>Post Date</span>
                            <span class="margin_R10">
                                <asp:RadioButton runat="server" ID="DOSRb" GroupName="radio"  />DOS</span>
                         
                        </div>
                        <div id="div_TxtDDl" style="padding: 10px 0px 10px 17px; box-sizing: border-box;">
                            <span>From:   
                                <asp:TextBox runat="server" ID="txtFromDate" CssClass="datepicker margin_R10 margin_L10" Enabled="false" Style="width: 80px !important"></asp:TextBox>
                            </span>

                            <span>To:   
                                <asp:TextBox runat="server" ID="txtToDate" CssClass="datepicker margin_R10 margin_L10" Enabled="false" Style="width: 80px !important"></asp:TextBox>
                            </span>


                            

     
                            <span style="margin-left:55px">
                                <input type="button" value="Filter Result" class="btn_filter " onclick="FilterResult();" />
                            </span>



                        </div>




                    </div>
            </div>
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">
                    
                        <div class="PageButtonsReports">
                            <ul style="float: right; margin-right: 15px;">
                            </ul>
                        </div>
                        <div id="divEport">
                            <div style="float: left; font-weight: bold;">Export To </div>
                            <div class="report-export-wrapper" style="float: right; width: 58%; margin-top: 3%;">
                                <asp:DropDownList ID="ddlExportTo" runat="server" OnSelectedIndexChanged="ddlExportTo_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                    <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                    <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="report-tools">
                            <table>
                                <tr>
                                    <td>
                                        <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="PrintReport('divReportListing');">
                                            <img src="../../Images/print.png" />
                                        </a>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" class="report-tool-icon" onclick="FilterReportList(0,true);">
                                            <img src="../../Images/ReportRefresh.gif" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </div>                        
                    </div>
                </div>
                <div class="WidgetReportContent">
                    <div style="width: 100%; float: left;">
                        <div id="divReportListing" runat="server">
                              <div class="ReportGrid">
                                     <table>
                                         <thead>
                                             <tr>
                                                 <th>
                                                     Practice
                                                 </th>
                                                  <th>
                                                     Procedures
                                                 </th>
                                                  <th>
                                                     Charges
                                                 </th>
                                                  <th>
                                                     Adjustments
                                                 </th>
                                                  <th>
                                                     Receipts
                                                 </th>
                                                  <th>
                                                    Balance
                                                 </th>
                                             </tr>
                                         </thead>
                                         <tbody style="text-align:center">
                                                <tr style="border-bottom:1px solid #ccc">
                                                  <td>
                                                 <asp:Label ID="Practice" runat="server"></asp:Label>  
                                                  </td>  
                                                  <td>
                                                 <asp:Label ID="Procedures" runat="server"></asp:Label>  
                                                  </td>  
                                                  <td>
                                                 <asp:Label ID="lblCharges" runat="server"></asp:Label>  
                                                  </td> 
                                                  <td>
                                                 <asp:Label ID="lblAdjustments" runat="server"></asp:Label>  
                                                  </td> 
                                                  <td>
                                                 <asp:Label ID="lblPayments" runat="server"></asp:Label>  
                                                  </td> 
                                                  <td>
                                                 <asp:Label ID="lblBalanceDue" runat="server"></asp:Label>  
                                                  </td> 
                                             </tr>
                                                                <tr>
                                                  <td>
                                                <b>Total</b>
                                                  </td>  
                                                  <td>
                                                 <asp:Label ID="Procedures1" runat="server"></asp:Label>  
                                                  </td>  
                                                  <td>
                                                 <asp:Label ID="lblCharges1" runat="server"></asp:Label>  
                                                  </td> 
                                                  <td>
                                                 <asp:Label ID="lblAdjustments1" runat="server"></asp:Label>  
                                                  </td> 
                                                  <td>
                                                 <asp:Label ID="lblPayments1" runat="server"></asp:Label>  
                                                  </td> 
                                                  <td>
                                                 <asp:Label ID="lblBalanceDue1" runat="server"></asp:Label>  
                                                  </td> 
                                             </tr>                       
                                         </tbody>
                               </table>
                                 
                              </div>
                    
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    

      <script type="text/javascript">
          //$(function () {
          //    $(".datepicker").datepicker({
          //        changeMonth: true,
          //        changeYear: true
          //    }).mask("99/99/9999");
          //});
          function FilterResult() {


              debugger;
              var DateType;
              var Radiobtn = '';
              var StartDate = '';
              var EndDate = '';
              var Location = $("[id$='ddlLocation']").val();
              var Provider = $("[id$='ddlBillingProvider']").val();
        
              if ($("[id$='PostRb']").is(":checked")) {
                  Radiobtn = "Post";
              }
              else if (($("[id$='DOSRb']").is(":checked"))) {
                  Radiobtn = "DOS";
              }
     
              if ($("[id$='chkMonthToDate']").is(":checked")) {
                  DateType = "MonthToDate";
              }
              else if ($("[id$='chkLastMonth']").is(":checked")) {
                  DateType = "LastMonth";
              }
              else if ($("[id$='chkYearToDate']").is(":checked")) {
                  DateType = "YearToDate";
              }
              else if ($("[id$='chkSelectDate']").is(":checked")) {
                  DateType = "Select";
                  StartDate = $("[id$='txtFromDate']").val();
                  EndDate = $("[id$='txtToDate']").val();
              }



              window.location = "CompanyIndicatorReport.aspx?&DateType=" + DateType + "&StartDate=" + StartDate + "&EndDate=" + EndDate + "&Radiobtn=" + Radiobtn;

          }


          function CheckBoxClick(obj) {

              ;
              $(obj).parent().siblings().find("input[type = 'checkbox']").prop("checked", false);


              if ($(obj).attr("id").indexOf("chkSelectDate") > 0) {

                  //$("[id$='txtFromDate']").prop("disabled", false);
                  //$("[id$='txtToDate']").prop("disabled", false);

                  if ($("[id$='chkSelectDate']").is(":checked")) {
                      $("[id$='txtFromDate']").prop("disabled", false);
                      $("[id$='txtToDate']").prop("disabled", false);
                  }
                  else {
                      $("[id$='txtFromDate']").prop("disabled", true);
                      $("[id$='txtToDate']").prop("disabled", true);
                      $("[id$='txtToDate']").val(" ");
                      $("[id$='txtFromDate']").val(" ");
                  }

              }

              else {
                  $("[id$='txtFromDate']").prop("disabled", true).val('');
                  $("[id$='txtToDate']").prop("disabled", true).val('');

              }
          }



    </script>
    
    ###EndReport###
  
</asp:Content>

