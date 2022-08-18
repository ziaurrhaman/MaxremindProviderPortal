<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainReport.aspx.cs" Inherits="EMR_ReportsNew_MainReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="js/MainReport.js"></script>
    <link href="style/MainReportStyle.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.0.272/jspdf.debug.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.js"></script>


    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.12/css/all.css"/> 

</head>

<body>
    <form id="form1" runat="server">
    <div>
        
    <div class="div_leftReportList">
<span id="ReportsTag">REPORTS</span>
        <table>
            <thead>

            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptReportMenu" OnItemDataBound="Unnamed_ItemDataBound">
                    <ItemTemplate>
                        <tr  >
                            <td  runat="server" id="Categorytd"><asp:Label class="ReportsCategoryHeader" runat="server" ID="lblCategory" />

                                
                            </td>
                          
                            
                        </tr>
                        <tr id="trsubRow" runat="server" class="ReportName" style="width:100%">
                           
                            <td class="nametd">  <span style="padding-right: 5px;float: left;color: #439abf;">></span>  <asp:Label runat="server" CssClass="lblReportName" ID="lblname" onclick="loadReport(this)" />
                            <div style="display:none">
                            <asp:Label id="lblReportfileName" class="lblReportfileName" runat="server"/>
                            <asp:Label id="lblReportFilterName" class="lblReportFilterName" runat="server"/></div>
                            </td>
                                
                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>


    <div class="div_RightReportShow">
        <div class="Report_Header">
          
         <div class="Reports_Rows_Per_Page">
                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                <select id="ddlPaging"  onchange="RowsChange();">
                                    <option value="10">10</option>
                                    <option value="25">25</option>
                                    <option value="50">50</option>
                                    <option value="75">75</option>
                                    <option value="100">100</option>
                                    
                                </select>
                            </span><span style="float: left;">&nbsp;entries</span>
                        </div>
         <div class="report-export">
                   <span style="float: left; margin-left: 5px;">Export To: &nbsp;</span>                         


                <select id="ddlExportTo" class="custom-export-drop-down" onchange="ExportReport();">
                                                        <option></option>
                                                        <option value="Excel">Excel</option>
                                                        <option value="PDF" >PDF</option>
                                                        <option value="Word">Word</option>
                                                    </select>




        </div> 

          
            </div>
        <div class="Report_Body"></div>
        <div class="Report_Footer">
             <label class="totalRows" style="float:left"></label>
             <label class="message"  ></label>
            <input class="Report_Footer_child" type="button" value="Last" onclick="LastPage()" />
          <span class="Report_Footer_child" id="Next" style="width:32px !important;height: 19px;padding-left: 7px;box-sizing: border-box;" onclick="NextPage()"><i id="filtersubmitright" class="fas fa-angle-double-right"></i></span>
        
            <label class="lblTotalPages" id="TotalPages"></label>
            <label style="float:right;margin-left:10px;"  >of</label>
            <input class="txt_page_Number" style="width:25px;height:13px" type="text" value="1"  /> 
            <span class="Report_Footer_child" style="border-radius: 5px 0 0 5px;width:32px !important;height: 19px;padding-left: 8px;box-sizing: border-box; " onclick="PreviousPage()"><i id="filtersubmitleft" class="fas fa-angle-double-left"></i></span>

            <%-- NextPage("divReportPaging"); --%>
            <input class="Report_Footer_child"  type="button" onclick="FirstPage()" value="First"/>
        </div>
    </div>

    </div>
    </form>
</body>
</html>
