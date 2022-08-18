<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="BillingManager_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Scripts/Rizwan/DashboardCharts.js"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>

    <style type="text/css">
        .box {
            margin-bottom: 20px;
            text-align: right;
            width: 24%;
            float: left;
            margin-right: 1%;
            min-height: 150px;
        }
         
            .box .amount {
                font-size: 30px;
                font-family: Calibri;
                font-weight: bold;
                color: #FFF;
                display: block;
                margin: 40px 30px 0;
            }

            .box .label {
                font-size: 24px;
                font-family: Calibri;
                font-weight: bold;
                color: #FFF;
                margin: 5px 30px 0;
            }


        .claimwidget {
            float: left;
            width: 32%;
            margin-right: 1%;
            border: 1px solid #d9dada;
        }

            .claimwidget .header {
                background-color: #3c78b5;
                color: #FFF;
                padding: 10px;
                font-size: 14px;
            }

            .claimwidget .content {
                background-color: #FFF;
                min-height: 250px;
            }

        .searchbox {
            width: 24%;
            float: left;
            margin-right: 1%;
            clear: left;
            margin-bottom: 25px;
            height: 300px;
            background-color: #e9eaea;
        }

            .searchbox .title {
                background-color: #439AC7;
                padding: 10px;
                font-weight: bold;
                color: white;
                font-size: 14px;
            }

            .searchbox .content {
                padding: 10px;
                line-height: 35px;
                font-weight: bold;
            }

        .ui-dialog {
            /*top: 611px !important;*/
        }


        .amount{
            
   line-height: 30px;
    font-weight: 600;
    width: 100%;
    text-align: right;
        }
       .amount_label{
          float: right;
        } 
      .columnchart{
     width: 85%;
    float: left;
    height: 210px;
    padding-left: 150px;
    box-sizing: border-box;
      }

      .btn_filter{
                 background-color: #439abf !important;                     
                 color: white !important;
                 border-bottom: none !important;
                background-image: none !important;                
                            }
      .Payment_box
      {
      border-radius: 5px;
    width: 100%;
    background-color: white;
    height: 100px;
    border: 1px solid #ccc;
    box-shadow: 0px 0px 2px 0 rgba(0,0,0,.125);

      }

      .div_payment_box{
     width: 25%;
    float: left;
    padding-right: 10px;
    padding-left: 10px;
    box-sizing: border-box;
      }
      .div_pie_charts
      {
           width: 33.33%;
    float: left;
    padding-right: 10px;
    padding-left: 10px;
    box-sizing: border-box;
      }
      .Pr_0{
          padding-right:0px !important;
      }
      .Pl_0{
           padding-left:0px !important;
      }
     .Pt_0{
          padding-top:0px !important;
      }
      .Pb_0{
           padding-bottom:0px !important;
      }

      .P10{

     padding: 10px;
    box-sizing: border-box;
      }
       .P20{

     padding: 20px;
    box-sizing: border-box;
      }
       .margin_R10
       {
           margin-right:10px;
       }
       .margin_L10
       {
           margin-left:5px;
       }
        .chart {
    border: 3px solid yellow;
    width: 100% !important;
}

.chart-wrapper {
    border: 3px solid orangered;
    width: 100% !important;
}

#divAgingReport{
    min-height: 250px;
    padding-top: 15px;
    box-sizing: border-box;
}
#divClaimDistribution {
    min-height:250px;
}
#divClaimSubmission
{
min-height:250px;
}
.highcharts-root
{
    margin-top:-40px !important;
}

#divClaimDistribution .highcharts-root
{
    margin-top:-10px !important;
}
    </style>
    <div id="cover">
        <div class="widget" style="width: 100%; background-color: white; /*height: 125px*/">
            <div class="widgettitle" style="float: left">Search Criteria
                 <div id="divLast90Days" style="float: right; width: 25%; text-align: right; padding-right: 10px; box-sizing: border-box; ">
                        <%--<h3>--%><asp:Label runat="server" ID="Label"></asp:Label> 
                     <span id="spndate" runat="server"></span>
                    </div>
            </div>
            <div class="widgetcontent" id="divwidgetcontent">
                <div style="float: left; width: 100%;">
                    <div id="div_Table" style="width: 100%; float: left">
                       <%-- <div id="div_checkboxis" style="padding: 10px 0px 10px 10px; box-sizing: border-box;">
                            

                               

                            <span class="margin_R10">

                                <asp:CheckBox runat="server" ID="chkMonthToDate" Text="Month to Date" onclick="CheckBoxClick(this);" /></span>
                           
                                <span class="margin_R10"><asp:CheckBox runat="server" ID="chkLastMonth" Text="Last Month" onclick="CheckBoxClick(this);" /></span>
                            <span class="margin_R10">
                                <asp:CheckBox runat="server" ID="chkYearToDate" Text="Year to Date" onclick="CheckBoxClick(this);" /></span>
                            <span class="margin_R10">
                                <asp:CheckBox runat="server" ID="chkSelectDate" Text="Select Dates" onclick="CheckBoxClick(this);" /></span>
                               
                         
                        </div>--%>
                        <div id="div_TxtDDl" style="padding: 10px 0px 10px 17px; box-sizing: border-box;">
                            <asp:DropDownList runat="server" ID="ddldate"  CssClass="margin_R10 margin_L10" Style="width: 170px !important; float: none !important;margin-left:10px;">
                                   <asp:ListItem Value="last3month"  Text="Last 90 Days" ></asp:ListItem> 
                                   <asp:ListItem Value="selectdate"   Text="Select Dates" ></asp:ListItem>
                                   <asp:ListItem Value="MonthToDate" Text="Month to Date"></asp:ListItem>
                                   <asp:ListItem Value="LastMonth" Text="Last Month"></asp:ListItem>
                                   <asp:ListItem Value="YearToDate" Text="Year to Date"></asp:ListItem>
                                </asp:DropDownList>
                            <span>From:   
                                <asp:TextBox runat="server" ID="txtFromDate" CssClass="datepicker margin_R10 margin_L10" Enabled="false" Style="width: 90px !important;padding:5px !important;"></asp:TextBox>
                            </span>

                            <span>To:   
                                <asp:TextBox runat="server" ID="txtToDate" CssClass="datepicker margin_R10 margin_L10" Enabled="false" Style="width: 90px !important;padding:5px !important;"></asp:TextBox>
                            </span>


                            <span>Location:  
                                <asp:DropDownList runat="server" ID="ddlLocation" AppendDataBoundItems="true" CssClass="margin_R10 margin_L10" Style="width: 170px !important; float: none !important">
                                    <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                </asp:DropDownList>
                            </span>

                            <span>Billing Provider: 
                                <asp:DropDownList runat="server" ID="ddlBillingProvider" AppendDataBoundItems="true" CssClass="margin_R10 margin_L10" Style="width: 170px !important; float: none !important">
                                    <asp:ListItem Value="All" Text="All" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </span>
                            <span  class="">

                            <span class="">
                                <asp:RadioButton runat="server" ID="PostRb" GroupName="radio" Checked="true"/>Post Date</span>
                                <asp:RadioButton runat="server" ID="DOSRb" GroupName="radio"  />DOS</span>

     
                            <span>
                                <input type="button" value="Filter Result" class="btn_filter " onclick="FilterResult();" />
                            </span>



                        </div>




                    </div>
                   
                </div>

            </div>

        </div>



    </div>



    <%-- Start Payemnts charegs balance due  --%>


    <div style=" width: 100%; float:left;margin-bottom:10px">
        <%-- Charges --%>
        <div style="" class="div_payment_box Pl_0">
            <div class="Payment_box P20" style="">
           <div class="amount">
                <asp:Label runat="server" ID="lblCharges" CssClass="" Style="font-size: 22px; color: #006291">$ 12,225</asp:Label>
            </div>

            <div class="amount_label" style="">
                <span class="label" style="font-size: 20px; color: #333333;line-height: 24px; text-align: right;">Charges</span>
            </div>
                </div>
      
        </div>
        

        <%-- Payments --%>
        <div style="" class="div_payment_box Pl_0">
        <div class="Payment_box P20" style="">
           <div class="amount">
                <asp:Label runat="server" ID="lblPayments" CssClass="" Style="font-size: 22px; color: #02813a">$ 12,225</asp:Label>
            </div>

            <div class="amount_label" style="">
                <span class="label" style="font-size: 20px; color: #333333; text-align: right;line-height: 24px;">Payments</span>
            </div>
       </div>
        </div>
           

        <%-- Adjustment --%>
        <div style="" class="div_payment_box Pl_0">
 <div class="Payment_box P20" style="">
           <div class="amount">
                <asp:Label runat="server" ID="lblAdjustments" CssClass="" Style="font-size: 22px; color: #f61006">$ 12,225</asp:Label>
            </div>

            <div class="amount_label" style="">
                <span class="label" style="font-size: 20px; color: #333333; text-align: right;line-height: 24px;">Patient Payment</span>
            </div>
       </div>
        </div>
           <%-- balance --%>
        <div style="" class="div_payment_box Pr_0 Pl_0">
             <div class="Payment_box P20" style="">
           <div class="amount">
                <asp:Label runat="server" ID="lblBalanceDue" CssClass="" Style="font-size: 22px; color: #f68802">$ 12,225</asp:Label>
            </div>

            <div class="amount_label" style="">
                <span class="label" style="font-size: 20px; color: #333333; text-align: right;line-height: 24px;">Balance Due</span>
            </div>
       </div>
        </div>
        

       

    </div>




    <%-- End Payemnts charegs balance due  --%>

    <%-- start ratio chart --%>
    <div class="widget" style="width: 100%; background-color: white; height: 270px; box-shadow: 0px 0px 2px 0 rgba(0,0,0,.125);">
        <div class="widgettitle" style="float: left">Ratio Charts</div>
        <div class="widgetcontent">
            <div style="width: 75%; padding-left: 165px; height: 220px; margin-bottom: 0px" id="divRatio"></div>
        </div>

    </div>

    <%-- End ratio chart --%>



     <div style=" width: 100%; float:left;margin-bottom:10px">
       <%-- start Claim Submission Status Chart --%>
        <div style="" class=" div_pie_charts Pl_0">
            <div class="" style="">
          <div class="widget "  style="margin-bottom:0px !important">
            <div class="widgettitle" style="float: left">Claim Submission Status </div>
            <div class="widgetcontent">
                <div class="content" id="divClaimSubmission"></div>
            </div>
        </div>
                </div>
      
        </div>
        

          <%-- start Claim Submission Status Aging Report Chart --%>
        <div style="" class=" div_pie_charts Pl_0">
        <div class="" style="">
           <div class="widget " style="margin-bottom:0px !important">
            <div class="widgettitle" style="float: left">Claim Submission Status Aging Report </div>
            <div class="widgetcontent">
                <div class="content" id="divAgingReport"></div>
            </div>
        </div>
       </div>
        </div>
           

         <%-- start Payer Claim Distribution Chart --%>
        <div style="" class="div_pie_charts Pr_0 Pl_0">
 <div class="" style="">
             <div class="widget" style="margin-bottom:0px !important">
            <div class="widgettitle" style="float: left">Payer Claim Distribution </div>
            <div class="widgetcontent">
                <div class="content" id="divClaimDistribution"></div>
            </div>
        </div>
       </div>
        </div>
          
   </div>

    


    <%-- start Column Chart --%>
    <div class="widget" style="width: 100%; background-color: white; padding-bottom:10px; box-shadow: 0px 0px 2px 0 rgba(0,0,0,.125);">
        <div class="widgettitle" style="float: left">Column Chart </div>
        <div class="widgetcontent">
            <div style="" class="columnchart" id="divColumnChart">
            </div>
        </div>

    </div>

    <%-- End Column Chart --%>



    <div id="DivChartsDetailsReport"></div>
  
    <asp:Literal runat="server" ID="ltrlScript"></asp:Literal>




     <script type="text/javascript">
         $(function () {
             $(".datepicker").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 maxDate: (0),

             }).mask("99/99/9999");
         });
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
             if ($("[id$='ddldate']").val()=="MonthToDate") {
                 DateType = "MonthToDate";
             }
             else if ($("[id$='ddldate']").val()=="LastMonth") {
                 DateType = "LastMonth";
             }
             else if ($("[id$='ddldate']").val()=="YearToDate") {
                 DateType = "YearToDate";
             }
             else if ($("[id$='ddldate']").val() == "last3month") {
                 DateType = "Last3Month";
             }
             else if ($("[id$='ddldate']").val() == "selectdate") {
                 var DateFrom = $("[id$='txtFromDate']").val();
                 var DateTo = $("[id$='txtToDate']").val();
                 if (DateFrom == "" && DateTo == "") {
                     $("[id$='txtFromDate']").css("border-color", "red");
                     $("[id$='txtToDate']").css("border-color", "red");

                     return;
                 }
                 if (DateFrom == "" && DateTo != "") {
                     $("[id$='txtFromDate']").css("border-color", "red");
                     $("[id$='txtToDate']").css("border-color", "#c4c4c4");

                     return;
                 }

                 if (DateFrom != "" && DateTo == "") {
                     $("[id$='txtToDate']").css("border-color", "red");
                     $("[id$='txtFromDate']").css("border-color", "#c4c4c4");

                     return;
                 }
                 else {
                     $("[id$='txtFromDate']").css("border-color", "#c4c4c4");
                     $("[id$='txtToDate']").css("border-color", "#c4c4c4");

                 }

                 $("[id$='txtFromDate']").css("background", "none");
                 $("[id$='txtToDate']").css("background", "none");
                 DateType = "Select";
                 StartDate = $("[id$='txtFromDate']").val();
                 EndDate = $("[id$='txtToDate']").val();
                 if (StartDate != "" && EndDate != "") {

                     if (new Date(EndDate) < new Date(StartDate)) {
                         $("<div style='margin-top:8px'></div>").html("<span>To Date cannot be less than From Date.</span>").dialog({
                             width: 360,
                             modal: true,
                             title: "Information!",
                             buttons: {
                                 Ok: function () {
                                     $("[id$='txtFromDate']").val("");
                                     $("[id$='txtToDate']").val("");
                                     $(this).dialog("destroy");
                                 }
                             }
                         });
                         return
                     }
                 }
             }



             window.location = "Dashboard.aspx?Location=" + Location + "&Provider=" + Provider + "&DateType=" + DateType + "&StartDate=" + StartDate + "&EndDate=" + EndDate + "&Radiobtn=" + Radiobtn;

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

         $("[id$='ddldate']").change(function () {
            

                 //$("[id$='txtFromDate']").prop("disabled", false);
                 //$("[id$='txtToDate']").prop("disabled", false);

             if ($("[id$='ddldate']").val() == "selectdate") {
                 $("[id$='txtFromDate']").prop("disabled", false);
                 $("[id$='txtFromDate']").css("background", "none")
                 $("[id$='txtToDate']").prop("disabled", false);
                 $("[id$='txtToDate']").css("background", "none")
                 }
                 else {
                 $("[id$='txtFromDate']").prop("disabled", true);
                 $("[id$='txtFromDate']").css("background", "#eaeaea");
                 $("[id$='txtToDate']").prop("disabled", true);
                 $("[id$='txtToDate']").css("background", "#eaeaea");
                     $("[id$='txtToDate']").val("");
                     $("[id$='txtFromDate']").val("");
                     $("[id$='txtFromDate']").css("border-color", "#c4c4c4");
                     $("[id$='txtToDate']").css("border-color", "#c4c4c4");
                 }

             }

            
               

            
         );
         

    </script>

<%--    <script type="text/javascript"
        src="https://www.google.com/jsapi?autoload={
            'modules':[{
              'name':'visualization',
              'version':'1.1',
              'packages':['corechart']
            }]
          }
        "></script>--%>


    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
<script type="text/javascript">

    // Load the Visualization API library and the piechart library.
    google.load('visualization', '1.0', { 'packages': ['corechart'] });
    google.setOnLoadCallback(drawChart);
    function drawChart() {

        // Start Ratio charts
        debugger
        var data = google.visualization.arrayToDataTable(PaymentChargesAdjustmentRatio);

        var options = {
            curveType: 'function',
            backgroundColor: { fill: '#FFFFFF' },
            legend: { textStyle: { color: 'black' }, position: 'bottom', alignemnt: 'center' },
            vAxis: { gridlines: { color: 'black' }, ticks: [0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100], textStyle: { color: 'black' } },
            chartArea: { backgroundColor: '#FFFFFF', left: '5%', top: '25', width: '90%' },
            hAxis: { textStyle: { color: 'black' } },
            pointSize: 5,
            series: {
                0: { color: '#1fbd13' },
                1: { color: '#4313bd' }
            }
        };

        var chart = new google.visualization.LineChart(document.getElementById('divRatio'));
        chart.draw(data, options);
        // End Ratio charts

        //Start Column charts
        var data1 = google.visualization.arrayToDataTable(ClaimChargesAdjustment);

        var options = {
            backgroundColor: { fill: '#FFFFFF' },
            legend: { textStyle: { color: 'black' }, position: 'bottom', alignemnt: 'center' },
            vAxis: { gridlines: { color: '#000000' }, textStyle: { color: '#black' } },
            chartArea: { backgroundColor: '#FFFFFF', left: '5%', top: '25', width: '90%' },
            hAxis: { textStyle: { color: 'black' } },
            series: {
                0: { color: '#0057ae' },
                1: { color: '#6faa3b' },
                2: { color: '#ab4311' }
            }
        };
        var chart = new google.visualization.ColumnChart(document.getElementById('divColumnChart'));
        chart.draw(data1, options);

        google.visualization.events.addListener(chart, 'click', function (e) {





            var status = e.targetID;
            if (status == "legendentry#0") {
                columnChartsCharges();
            }
            else if (status == "legendentry#1") {
                columnChartsPayments();
            }
            else if (status == "legendentry#2") {
                columnChartsAdjustment();
            }

        });


        // End Column charts

        var data2 = google.visualization.arrayToDataTable(ClaimSubmissionStatusAging);
        var options = {

            legend: { textStyle: { color: '#000000' }, position: 'bottom', alignemnt: 'center' },
            vAxis: { gridlines: { color: '#000000' }, textStyle: { color: '#FFFFFF' }, textPosition: 'none' },
            chartArea: { backgroundColor: '#FFFFFF', left: '5%', top: '25', width: '90%' },

            isStacked: true,
            series: {
                0: { color: '#4281a4' },
                1: { color: '#6faa3b' },
                2: { color: '#b65145' },
                3: { color: '#ff9900' }
            }
        };

        var chart = new google.visualization.ColumnChart(document.getElementById('divAgingReport'));
        chart.draw(data2, options);

        google.visualization.events.addListener(chart, 'select', function () {

            var total = 0;


            var selectedItem = chart.getSelection()[0];
            var arr = chart.getSelection();


            $.each(arr, function () {


                var column = Object.keys(this)[1];
                columnvalue = this[column];



            });


            if (selectedItem) {

                var status = data2.getValue(selectedItem.row, 0);
                ClaimSubmissionStatusAgingCHARTDetail(status, columnvalue);




            }


        });





    }
</script>

    <script type="text/javascript">




        $(document).ready(function () {
            var urlParams = new URLSearchParams(window.location.search);
            var DateType = (urlParams.get('DateType'));
            
            if (DateType == "Select") {
                $("[id$='ddldate']").val("selectdate");
            }
            else if (DateType == "YearToDate") {
                $("[id$='ddldate']").val("YearToDate");
            }
            else if (DateType == "LastMonth") {
                $("[id$='ddldate']").val("LastMonth");
            }
            else if (DateType == "MonthToDate") {
                $("[id$='ddldate']").val("MonthToDate");
            }
            else if (DateType == "Last3Month") {
                $("[id$='ddldate']").val("last3month");
            }
            if ($("[id$='ddldate']").val() !== "selectdate") {
                $("[id$='txtFromDate']").css("background", "#eaeaea");
                $("[id$='txtToDate']").css("background", "#eaeaea");
            }
            if (!checkModuleRights("Dashboard")) {
                $("[id$='divRightsSettings']").html("You don't have rights to View Dashboard").show();
                $("#ContentMaindiv").hide();
                return false;
            }
            debugger;
            claimsubmissonPieChart();
            PayerclaimPieChart();
         
            $(".highcharts-title").remove();
            $(".highcharts-button").remove();
            $(".highcharts-credits").remove();

           
        });
       
        function claimsubmissonPieChart() {
         
           // var data = google.visualization.arrayToDataTable(ClaimSubmissionStatus);
            var css = ClaimSubmissionStatus;// 
            css.splice(0, 1);
            var mycss = css;

            var chart = {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie',

            };

            var tooltip = {
                pointFormat: ' {point.y} : ({point.percentage:.1f} %)'
            };
            var plotOptions = {
                pie: {
                    colors: ['#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
                    allowPointSelect: false,
                    size: '70%',
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {

                                debugger;
                                var status = this.name;
                                CLAIMSUBMISSIONSTATUSPIECHARTDetail(status);
                            }

                        }
                    },
                    dataLabels: {

                        enabled: true,
                        connectorWidth: 1.5,

                        format: '<b>{point.name}</b> {point.y} : ({point.percentage:.1f} %)',
                        style: {
                            fontSize: 11,
                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) ||
                                'black'

                        }
                    },

                }
            };
            var series = [{
                type: 'pie',
                animation: false,

                data: mycss,
            }];
            Highcharts.getOptions().colors = Highcharts.map(
                Highcharts.getOptions().colors, function (color) {
                    return {
                        radialGradient: { cx: 0.5, cy: 0.3, r: 0.7 },
                        stops: [
                            [0, color],
                          
                        ]
                    };
                }
            );
            var json = {};
            json.chart = chart;
            json.tooltip = tooltip;
            json.series = series;
            json.plotOptions = plotOptions;
            $('#divClaimSubmission').highcharts(json);
        }
        function PayerclaimPieChart() {
         
           // var data = google.visualization.arrayToDataTable(ClaimPayerDistribution);
            var css = ClaimPayerDistribution; 
            css.splice(0, 1);
            var mycss = css;

            var chart = {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie',

            };

            var tooltip = {
                pointFormat: '{point.y} : ({point.percentage:.1f} %)'
            };
            var plotOptions = {

                pie: {
                    allowPointSelect: false,
                    size: '70%',
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {
                              
                                debugger;
                                var status = this.name;
                                PayerCLAIMDistributionPIECHARTDetail(status);
                            }
                        }
                    },
                    dataLabels: {

                       
                        enabled: true,
                        connectorWidth: 1.5,


                        format: '<b>{point.name}</b> {point.y} : ({point.percentage:.1f} %)',
                        style: {

                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) ||
                                'black'
                        }
                    }
                }
            };
            var series = [{
                type: 'pie',
                animation: false,

                data: mycss,
            }];
            var json = {};
            json.chart = chart;
            json.tooltip = tooltip;
            json.series = series;
            json.plotOptions = plotOptions;
            $('#divClaimDistribution').highcharts(json);
        }

      
       
        var chart; var data3; var columnvalue;
     

       // google.setOnLoadCallback(drawChart);





    </script>


   
</asp:Content>

