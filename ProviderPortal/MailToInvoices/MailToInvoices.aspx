<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="MailToInvoices.aspx.cs" Inherits="ProviderPortal_MailToInvoices_MailToInvoices" %>
<%--Created By Agha Sibtain, Dated:04/10/2019--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/MailToInvoices.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
    <style>
        .container{
            /*background-color: #006291;*/
            padding: 0;
        }
        .div_leftMailToList {
    background-color: #f7f7f7;
    width: 22%;
    float: left;
    box-sizing: border-box;
    border: 1px solid #ccc;
    padding-bottom: 10px;
    margin-bottom: 5%;
}
        .div_rightMailToList {
    background-color: #f7f7f7;
    width: 56%;
    float: left;
    box-sizing: border-box;
    border: 1px solid #ccc;
    padding-bottom: 10px;
    margin-bottom: 5%;
}
        .MailToTag {
    font-size: 18px;
    float: left;
    border-bottom: 2px solid #c7d8e0;
    width: 100%;
    padding-left: 10px;
    padding-right: 10px;
    padding-bottom: 5px;
    padding-top: 5px;
    box-sizing: border-box;
    text-align:center;
}

        .trhighlight1{
        background-color: #449EBE !important;
    border-radius: 10px !important;
    color: #f9f9f9 !important;
 
    float: left;
    margin-left: 24%;
        }

        .trhighlight2{
              background-color: #A7D7ED;
              color: #000;
              border-radius: 10px;
              float: left;
              margin-left: 12%;
                }

        body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.header {
  padding: 10px 16px;
}

.content {
  padding: 16px;
}

.sticky {
  position: fixed;
  top: 0;
  width: 100%;
}

.sticky + .content {
  padding-top: 102px;
}

.heading2{
    margin-top: 0;
    margin-bottom: 0;
    background: #006291;
    color: white;
    padding: 15px 0px 15px 20px;
    border: 1px solid #006291;
}

table #trMailTo1:hover {
  background-color: #a3d0e0;
  border-radius: 10px !important;
    color: #000 !important;

}
table #trMailTo2:hover {
  background-color: #e4f5fd;
  border-radius: 10px;
  color: #000;

 
}

.searchFile{
background-color: #f7f7f7;
border:none;
background: url(../../Images/Search.png) no-repeat scroll 5px 2px;
padding-left: 30px;
background-size: 20px;

}
.searchtextboxdesign{
    width: 95% !important;
    margin: 1px 0 !important;
    float: left !important;
   background-color:#068ccc1f !important;
    border-radius: 0 !important;
    border: none !important;
        padding-left: 45px !important;
}
.nametdAlignCenter{
    padding: 10px 10px !important;
    text-align: center;
   
}
table.MailToInvoice:hover
{
    background-color:none !important;
}
    </style>

    <asp:HiddenField ID="hdnPracticeId" runat="server" />
    <asp:HiddenField runat="server" ID="hdnTotalRows" />

<h2 class="heading2">MAIL TO INVOICE</h2>

    <div class="div_leftMailToList" style="border-right: 1px solid #006291;">
<span class="MailToTag" style="background-color: #449EBE;color: #fff;">Invoice Batch</span>
<span class="MailToTa1g">
   
    <input type="text" class="BiWeeklyInvoiceTxt searchtextboxdesign" placeholder="Search" id="WeeklyInvoicetxt" onkeyup="setSearch(event,'WeeklyInvoice')" />

</span>
    <span style="float: left;margin-top: -23px;margin-left: 25px;"> <img src="../../Images/Search.png" style="width:16px;height:16px;" /> </span>
        <div class="Grid" style="overflow-y:scroll;height:430px">
        <table>
            <tbody id="tbodyMailToInvoice">
                <asp:Repeater ID="rptMailToInvoices" runat="server">
                    <ItemTemplate>
                        <tr id="trMailTo1" class="MailToInvoice content" style="width: 100%;cursor: pointer" onclick="ShowDetails(' <%# Eval("ModifiedDate") %>', this)">
                          
                            <td title="Total Invoices : <%# Eval("TotalInvoice") %>" class="nametd nametdAlignCenter">
                               <span class="spanhover"> <%# Eval("Batch") %> </span>
                                
                            </td>             
                                 <td style="display:none"><input type="hidden" class="hdndate" value="<%# Eval("ModifiedDate") %>" /></td>   
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</div>

    <div class="div_leftMailToList">
<span class="MailToTag" style="background-color: #A7D7ED;color: #000;">Patient Invoice</span>
        <span class="MailToTa1g">
   
    <input type="text" class="BiWeeklyInvoiceTxt searchtextboxdesign" placeholder="Search" id="Patientinvoicetxt"  onkeyup="setSearch(event,'Patientinvoice')"/>

</span>
    <span style="float: left;margin-top: -23px;margin-left: 25px;"> <img src="../../Images/Search.png" style="width:16px;height:16px;" /> </span>
        <div class="Grid" style="height: 430px;width: 100%;overflow-y: auto;overflow-x: hidden;">
      
            <table>
       
            <tbody id="tbodyDetailInvoice">
                
            </tbody>
        </table>
    </div>
</div>

     <div class="div_rightMailToList">
<span class="MailToTag" style="background-color: #D0D4D7;color: #000;float:left;">Invoice</span>  
         <span style="float:right;margin-right:10px;margin-top:-31px;"><input type="button" id="btnprint" value="Print" onclick="PrintInvoices()" style="background-image: none;border-bottom: none;background-color: #0a7cb3;color: white;" /></span>
        <div style="height: 459px;width: 100%;overflow-y: auto;background-color:white">
        <table>
            <thead>                
                <tr class="header" id="myHeader" style="background-color: #ebeff0;color: #00628f;">
                    <th id="thFileContents" style="border-bottom: 2px solid #c7d8e0; padding: 7px 0px 5px 5px; box-sizing: border-box;">
                        <div id="spnFileContents" class="ReportsCategoryHeader" style="text-align:left;padding-left: 15px;">File Contents</div>
                    </th>
                </tr>
            </thead>
            <tbody id="tbodyInvoiceFileContents">
                
            </tbody>
        </table>
    </div>
</div>

</asp:Content>