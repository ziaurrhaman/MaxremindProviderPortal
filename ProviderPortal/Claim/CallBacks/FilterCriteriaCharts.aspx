<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterCriteriaCharts.aspx.cs" Inherits="ProviderPortal_Claim_CallBacks_FilterCriteriaCharts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       ###StartERAClaims###

     
        
     <script src="../../Scripts/jquery-1.9.0.js"></script>
    <script src="../../Scripts/jquery-ui/jquery.ui.widget.js"></script>
        <script src="../../Scripts/jquery-ui/jquery.ui.dialog.js"></script>
     
    <%--    <script src="../../Scripts/jquery-ui/jquery.ui.datepicker.min.js"></script>--%>
            
          <div class="searchbox" style="display:block; float:left">
        <div class="title">
            Enter Criteria
        </div>
        <div class="content">
            <asp:CheckBox runat="server" ID="chkMonthToDate"  Text="Month to Date" onclick="CheckBoxClick(this);" />
             
            <asp:CheckBox runat="server" ID="chkLastMonth" Text="Last Month" onclick="CheckBoxClick(this);" />
            <asp:CheckBox runat="server" ID="chkYearToDate" Text="Year to Date" onclick="CheckBoxClick(this);" />
            <asp:CheckBox runat="server" ID="chkSelectDate" Text="Select Dates" onclick="CheckBoxClick(this);" />
               
            <table>
                <tr>
                    <td style="width: 10%;">From:</td>
                    <td style="width: 40%;">
                        <asp:TextBox runat="server" ID="txtFromDate" CssClass="datepicker" Enabled="false"></asp:TextBox>
                    </td>

                    <td style="width: 10%;">To:</td>
                    <td style="width: 40%;">
                        <asp:TextBox runat="server" ID="txtToDate" CssClass="datepicker" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td style="width: 35%;">Location:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlLocation" AppendDataBoundItems="true">
                            <asp:ListItem Value="All" Text="All"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>Billing Provider:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlBillingProvider" AppendDataBoundItems="true">
                            <asp:ListItem Value="All" Text="All"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td style="text-align:left">
                       <asp:RadioButton runat="server" ID="DOSRb" GroupName="radio"  Checked="true" />DOS
                      
                        
                    </td>
                    <td>
                     <asp:RadioButton runat="server" ID="PostRb" GroupName="radio" />Post Date
                    </td>
                   
                </tr>
                <tr>
                     <td style="text-align: right;" colspan="2">
                        <input type="button" value="Filter Result" onclick="FilterResult();" />
                   

                    </td>
                </tr>
            </table>
             
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
                  //rizwan kharal start
                  //13 oct 2017
                  //filtering the graph value according to check box
                  if ($("[id$='PostRb']").is(":checked")) {
                      Radiobtn = "Post";
                  }
                  else if (($("[id$='DOSRb']").is(":checked"))) {
                      Radiobtn = "DOS";
                  }
                  //end
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



                //  window.location = "Dashboard.aspx?Location=" + Location + "&Provider=" + Provider + "&DateType=" + DateType + "&StartDate=" + StartDate + "&EndDate=" + EndDate + "&Radiobtn=" + Radiobtn;

              }


              function CheckBoxClick(obj) {
                  $(obj).siblings().prop("checked", false);

                  if ($(obj).attr("id").indexOf("chkSelectDate") > 0) {
                      $("[id$='txtFromDate']").prop("disabled", false);
                      $("[id$='txtToDate']").prop("disabled", false);
                  }
                  else {
                      $("[id$='txtFromDate']").prop("disabled", true).val('');
                      $("[id$='txtToDate']").prop("disabled", true).val('');
                  }
              }



    </script>

       ###EndERAClaims###


    </div>
    </form>
</body>
</html>
