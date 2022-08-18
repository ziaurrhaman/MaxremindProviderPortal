using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class BillingManager_Home : System.Web.UI.Page
{
    int countRows = 0;
    int matchCount = 0;
    int count = 0;
    string ScriptForInnerSection = "";
    string ScriptForInnerSection1 = "";
    string ScriptForInnerSection2 = "";
    string ScriptForInnerSection3 = "";
    string ScriptForInnerSection4 = "";
    string ScriptForInnerSection5 = "";
    string ScriptForInnerSection6 = "";
    string ScriptForInnerSection7 = "";
    string ScriptForInnerSection8 = "";
    string ScriptForInnerSection9 = "";
    string ScriptForInnerSection10 = "";
    string headerscript1 = "<tr>" +
                            "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                     "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Accounts Recievable</span>" +
                                "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                            "</td>" +
                        "</tr> ";
    string headerscript2 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Productivity & Analysis</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript3 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Accounts Recievable</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript4 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Patients</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript5 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Appointments</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript6 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Claims/Visits</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript7 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Payments</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript8 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Refund</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript9 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>PTL</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript10 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Practice</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    string headerscript11 = "<tr>" +
                           "<td runat='server' id='Categorytd' style='border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;'>" +
                                    "<span class='ReportsCategoryHeader' runat='server' ID='lblCategory' onclick='hideShowDiv(this)'>Company</span>" +
                               "<span style = 'cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right' onclick='hideShowDiv(this)'><i class='fas fa-angle-down'></i></span>" +
                           "</td>" +
                       "</tr> ";
    protected void Page_Load(object sender, EventArgs e)
    {
        string Action = Request.Form["Action"];
        matchCount = 0;
        countRows = 0;
        MainReportdb mainReportdb = new MainReportdb();
        DataTable dt = new DataTable();
        dt = mainReportdb.getReportList();
        //countRows = Convert.ToInt32(dt.Rows.Count);
        rptReportMenu.DataSource = dt;
        rptReportMenu.DataBind();
        //int c = countRows;
        //script.Value =  headerscript1 + ScriptForInnerSection1 + headerscript2 + ScriptForInnerSection2 + headerscript4 + ScriptForInnerSection3 +
        // headerscript6 + ScriptForInnerSection5 + headerscript7 + ScriptForInnerSection8  + headerscript9 + ScriptForInnerSection10 + headerscript10 + ScriptForInnerSection6 + headerscript11 + ScriptForInnerSection7;

    }
    string CategoryChk = "";
    


    protected void Unnamed_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        DataRowView dr = (DataRowView)e.Item.DataItem;
        string name = dr["name"].ToString();
        string categoty = dr["category"].ToString();
        string ReportfileName = dr["ReportfileName"].ToString();
        string ReportFilterName = dr["Report_Filter_fileName"].ToString();
        string Discription = dr["Report_Description"].ToString();
        string ctg = "";
        Regex pattern = new Regex("[;,\t\r / ]|[\n][/][ & ]");

        string ReportType = dr["ReportType"].ToString();

        Label lblReportFilterName = (Label)e.Item.FindControl("lblReportFilterName");
        lblReportFilterName.Text = ReportFilterName;

        Label lblname = (Label)e.Item.FindControl("lblname");
        lblname.Text = name;
       // lblname.Attributes.Add("data-title", Discription);
      //  lblname.Attributes.Add("data-toggle='tooltip' data-placement='right' title='"+ Discription + "',","");
        lblname.Attributes.Add("title='" + Discription + "',", "");
        Label lblfilename = (Label)e.Item.FindControl("lblReportfileName");
        lblfilename.Text = ReportfileName;

        Label hdnReportType = (Label)e.Item.FindControl("hdnReportType");
        hdnReportType.Text = ReportType;

        if (CategoryChk != categoty)
        {
            Label lblCategory = (Label)e.Item.FindControl("lblCategory");

            lblCategory.Text = categoty;
            //";
            HtmlTableCell tdstyle = (HtmlTableCell)e.Item.FindControl("Categorytd");
            //tdstyle.Attributes.Add("style", "border-bottom: 1px solid #439abf;");
            tdstyle.Attributes.Add("style", "border-bottom: 1px solid white;padding: 7px;box-sizing: border-box;width: 100%;float: left;cursor:pointer");
            
        }
        HtmlTableRow trsubRow = (HtmlTableRow)e.Item.FindControl("trsubRow");

        CategoryChk = categoty;

        // categoty.Replace("&", string.Empty);
        //categoty.Replace(" ", string.Empty);
        ctg= pattern.Replace(categoty,"");

        trsubRow.Attributes.Add("class", ctg);

        //if (ReportfileName == "ReportPostClaims.aspx")
        //{
        //    trsubRow.Style.Add("display", "none");
        //}



        //else if ((categoty.Contains("Productivity") || categoty.Contains("Financial")) && name.Contains("Most Commonly") || name.Contains("Productivity"))
        //{
        //    ScriptForInnerSection2 += "<tr id='trsubRow3' runat='server' class='ctg2' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else if ((categoty.Contains("Patient") || categoty.Contains("Financial")) && name.Contains("Patient") || name.Contains("Itemization") || name.Contains("Responsibility"))
        //{
        //    ScriptForInnerSection3 += "<tr id='trsubRow3' runat='server' class='ctg3' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else if (categoty.Contains("Appointment") && name.Contains("Appointment"))
        //{
        //    ScriptForInnerSection4 += "<tr id='trsubRow3' runat='server' class='ctg4' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else if ((categoty.Contains("Claims") || categoty.Contains("Financial")) && name.Contains("Payer Paid") || name.Contains("Post Claims") || name.Contains("Over Paid") || name.Contains("Claim Summary") || name.Contains("Claims Subm"))
        //{
        //    ScriptForInnerSection5 += "<tr id='trsubRow3' runat='server' class='ctg5' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else if (categoty.Contains("Practice") || name.Contains("Top 10"))
        //{
        //    ScriptForInnerSection6 += "<tr id='trsubRow3' runat='server' class='ctg6' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else if (categoty.Contains("Company") || name.Contains("Company"))
        //{
        //    ScriptForInnerSection7 += "<tr id='trsubRow3' runat='server' class='ctg7' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else if (categoty.Contains("Financial") && name.Contains("Collection") || name.Contains("Rejected Denied") || name.Contains("Contract Management") || name.Contains("Procedure Payment") || name.Contains("Adjustments Summary") || name.Contains("Payments Summary") || name.Contains("UnApplied") || name.Contains("collection") || name.Contains("Patient Balance") || name.Contains("Post Claims") || name.Contains("Unposted") || name.Contains("Provider Collection") || name.Contains("payment Detail") || name.Contains("Payment Applica"))
        //{
        //    ScriptForInnerSection8 += "<tr id='trsubRow3' runat='server' class='ctg8' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else if (categoty.Contains("Refund") && name.Contains("Refund"))
        //{
        //    ScriptForInnerSection9 += "<tr id='trsubRow3' runat='server' class='ctg9' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else if (categoty.Contains("PTL") && name.Contains("PTL Patient") || name.Contains("PTL Claim"))
        //{
        //    ScriptForInnerSection10 += "<tr id='trsubRow3' runat='server' class='ctg10' style='width: 100 %; '>" +
        //                          "<td class='nametd'>" +
        //                            "<span style = 'padding-right: 5px; float: left; color: #439abf; font-size: 10px;' >></span>" +
        //                            "<asp:Label Class='lblReportName' ID='lblname' onclick='loadReport(this)' Style='cursor: pointer; border: none !important' >" + name + "</asp:label>" +
        //                            "<span><span Class='lblReportName' ID='Label' Style='color: red !important; margin-top: 2px; cursor: none !important' ></span></span>" +
        //                            "<div style='display: none'>" +
        //                                "<asp:Label ID = 'lblReportfileName2' class='lblReportfileName'  runat='server'>" + ReportfileName + "</asp:label>" +
        //                                "<asp:Label ID = 'lblReportFilterName2' class='lblReportFilterName' runat='server' >" + ReportFilterName + "</asp:label>" +
        //                            "</div>" +
        //                            "<asp:Label ID = 'hdnReportType' class='ReportType' text=" + ReportType + " runat='server' Style='display: none' />" +
        //                        "</td>" +
        //    "</tr>";
        //    CategoryChk = categoty;
        //}
        //else
        //    {

        //        if (ReportfileName == "ClaimsDetailReport.aspx")
        //        {
        //            return;
        //        }
        //        Label lblReportFilterName = (Label)e.Item.FindControl("lblReportFilterName");
        //        lblReportFilterName.Text = ReportFilterName;

        //        Label lblname = (Label)e.Item.FindControl("lblname");
        //        lblname.Text = name;

        //        Label lblfilename = (Label)e.Item.FindControl("lblReportfileName");
        //        lblfilename.Text = ReportfileName;

        //        Label hdnReportType = (Label)e.Item.FindControl("hdnReportType");
        //        hdnReportType.Text = ReportType;

        //        Label lblbeta = (Label)e.Item.FindControl("lblbeta");
        //    //if (CategoryChk != categoty)
        //    //{
        //    //    Label lblCategory = (Label)e.Item.FindControl("lblCategory");

        //    //    lblCategory.Text = "Other Reports";
        //    //    //";
        //    //    HtmlTableCell tdstyle = (HtmlTableCell)e.Item.FindControl("Categorytd");
        //    //    //tdstyle.Attributes.Add("style", "border-bottom: 1px solid #439abf;");
        //    //    tdstyle.Attributes.Add("style", "border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;");
        //    //}


        //    CategoryChk = categoty;
        //        string ctg = categoty.Replace(" ", string.Empty);
        //        if (CategoryChk == "Company")
        //        {
        //            HtmlTableCell tdstyle = (HtmlTableCell)e.Item.FindControl("Categorytd");
        //            tdstyle.Style.Add("display", "none");
        //        }

        //        //lblbeta.Text = "(Beta)";


        //        if (ReportfileName == "UserAuditReport.aspx" || ReportfileName == "UserClaimSummaryReport.aspx" || ReportfileName == "MissedCopaysReport.aspx" || ReportfileName == "ReadyForSubmissionClaimsDetail.aspx")
        //        {
        //            trsubRow.Style.Add("display", "none");
        //        }
        //        else
        //        {
        //            trsubRow.Attributes.Add("class", ctg);
        //            //trsubRow2.Attributes.Add("class", ctg);
        //        }
        //    }

    }






}