<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="FilterCriteriaChart.aspx.cs" Inherits="ProviderPortal_Claim_CallBacks_FilterCriteriaChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div>
       ###StartERAClaims###
           <script src="../../Scripts/Rizwan/DashboardCharts.js"></script>
         <style>

             .widthsetting{

                 width:83% !important;
             }
              .widthsetting1{

                 width:93% !important;
             }
         </style>
     
        
     
          <div class="searchbox" style="display:block; float:left; width:100% !important">
        <%--<div class="title">
        Search Criteria
        </div>--%>
        <div class="content">
            <div>
           <asp:CheckBox runat="server" ID="chkMonthToDate1"  Text="Month to Date" onclick="CheckBoxClick(this);" />
             
            <asp:CheckBox runat="server" ID="chkLastMonth1" Text="Last Month" onclick="CheckBoxClick(this);" />
            <asp:CheckBox runat="server" ID="chkYearToDate1" Text="Year to Date" onclick="CheckBoxClick(this);" />
            </div>
           <div>
                 <asp:CheckBox runat="server" ID="chkSelectDate1" Text="Select Dates" onclick="CheckBoxClick(this);" />
           </div>
          
               
            <table>
                <tr>
                    <td style="width: 10%;">From:</td>
                    <td style="width: 40%;">
                        <asp:TextBox runat="server" ID="txtFromDate1" CssClass="datepicker widthsetting" Enabled="false" ></asp:TextBox>
                    </td>

                    <td style="width: 10%;">To:</td>
                    <td style="width: 40%;">
                        <asp:TextBox runat="server" ID="txtToDate1" CssClass="datepicker widthsetting" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td style="width: 35%;">Location:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlLocation2" AppendDataBoundItems="true" CssClass="widthsetting1">
                            <asp:ListItem Value="All" Text="All"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>Billing Provider:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlBillingProvider2" AppendDataBoundItems="true" CssClass="widthsetting1">
                            <asp:ListItem Value="All" Text="All"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td style="text-align:left">
                       <asp:RadioButton runat="server" ID="DOSRb1" GroupName="radio"  Checked="true" />DOS
                      
                        
                    </td>
                    <td>
                     <asp:RadioButton runat="server" ID="PostRb1" GroupName="radio" />Post Date
                    </td>
                   
                </tr>
                <tr>
                    
                </tr>
            </table>
             
        </div>
       
        
    </div>

      

          <script type="text/javascript">
              $(function () {
                  $(".datepicker").datepicker({
                      changeMonth: true,
                      changeYear: true
                  }).mask("99/99/9999");
              });
             


              function CheckBoxClick(obj) {
                  $(obj).siblings().prop("checked", false);

                  if ($(obj).attr("id").indexOf("chkSelectDate") > 0) {
                      $("[id$='txtFromDate1']").prop("disabled", false);
                      $("[id$='txtToDate1']").prop("disabled", false);
                  }
                  else {
                      $("[id$='txtFromDate1']").prop("disabled", true).val('');
                      $("[id$='txtToDate1']").prop("disabled", true).val('');
                  }
              }



    </script>

       ###EndERAClaims###


    </div>


</asp:Content>


