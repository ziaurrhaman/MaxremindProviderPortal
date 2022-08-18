using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_MainReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MainReportdb mainReportdb = new MainReportdb();
        rptReportMenu.DataSource= mainReportdb.getReportList();
        rptReportMenu.DataBind();

        if (!string.IsNullOrEmpty(Request.Form["action"]) && Request.Form["action"] == "PrintRequest")
        {
            string ExportTo = Request.Form["Export"].ToString();
            string ReportHtml = Request.Form["ReportHtml"].ToString();
            
        }


    }
    string CategoryChk = "";
    protected void Unnamed_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        string name = dr["name"].ToString();
        string categoty = dr["category"].ToString();
        string ReportfileName = dr["ReportfileName"].ToString();
        string ReportFilterName = dr["Report_Filter_fileName"].ToString();

        Label lblReportFilterName = (Label)e.Item.FindControl("lblReportFilterName");
        lblReportFilterName.Text = ReportFilterName;

        Label lblname = (Label)e.Item.FindControl("lblname");
        lblname.Text = name;

        Label lblfilename = (Label)e.Item.FindControl("lblReportfileName");
        lblfilename.Text = ReportfileName;
        if (CategoryChk != categoty)
        {
            Label lblCategory = (Label)e.Item.FindControl("lblCategory");

            lblCategory.Text = categoty + "<span onclick='hideShowDiv(this)' style='cursor: pointer;color: #ccc;padding: 3px 10px 0 22px;float:right'>" + "<i class='fas fa-angle-down'></i>" + "</span>";
            HtmlTableCell tdstyle = (HtmlTableCell)e.Item.FindControl("Categorytd");
            //tdstyle.Attributes.Add("style", "border-bottom: 1px solid #439abf;padding: 5px 0px 5px 0px;box-sizing: border-box;width: 90%;float: left;margin-left: 13px;");

        }
        HtmlTableRow trsubRow = (HtmlTableRow)e.Item.FindControl("trsubRow");

        CategoryChk = categoty;
        string ctg = categoty.Replace(" ", string.Empty);
        trsubRow.Attributes.Add("class", ctg);

        if (ReportfileName == "ReportPostClaimSummary.aspx")
        {
            trsubRow.Style.Add("display", "none");
        }
    }
    
  

}