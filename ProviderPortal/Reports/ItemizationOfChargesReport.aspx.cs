using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_ItemizationOfChargesReport : System.Web.UI.Page
{
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    string ProviderId; string DateType; string CustomDate; string AsOf; string PatientIds; int Rows; string PayerId;

    protected void Page_Load(object sender, EventArgs e)
    {

        PatientIds = Request.Form["SearchedPatientId"].ToString();
         ProviderId = Request.Form["ProviderId"];
         DateType = Request.Form["DateType"];
         if (DateType == "")
         {
             DateType = "DOS";
         }
         else
         {
             DateType = Request.Form["DateType"];
         }
         PayerId = Request.Form["PayerId"];
         CustomDate = Request.Form["CustomDate"];
       
         if (CustomDate == "Today")
         {
             AsOf = DateTime.Today.ToShortDateString();
         }
         else if (CustomDate == "Yesterday")
         {
             AsOf = DateTime.Today.AddDays(-1).ToShortDateString();
         }
         else if (CustomDate == "Custom")
         {
             AsOf = Request.Form["AsOf"];
         }

         hdnAsOf.Value = AsOf;
         hdnPatId.Value = PatientIds;
         hdnProviderId.Value= ProviderId;
         hdnDateType.Value = DateType;





        lblReportTimeSpanTo.Text = AsOf;

        DataSet dsReportData = objPatientReportsDB.ItemizationOfcharges(Convert.ToInt32(Profile.PracticeId), 10, 0, "DOS Desc", DateType, AsOf, ProviderId,int.Parse( PatientIds), PayerId);
        rptItemizationOfCharges.DataSource = dsReportData;
        rptItemizationOfCharges.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        Rows =Convert.ToInt32(dsReportData.Tables[1].Rows[0]["TotalRows"].ToString()); 
       
        Control FooterTemplate = rptItemizationOfCharges.Controls[rptItemizationOfCharges.Controls.Count - 1].Controls[0];
        
        if (dsReportData.Tables[0].Rows.Count > 0)
        {
            Label lblGranAverage = FooterTemplate.FindControl("lblGranAverage") as Label;
            lblGranAverage.Text = "Grand Total";
            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Charges"].ToString()))
            {
                float TotalCharges = float.Parse(dsReportData.Tables[0].Compute("sum(Charges)", string.Empty).ToString());
                Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }

            string adjustments = dsReportData.Tables[0].Rows[0]["Adjustments"].ToString();
            if (!string.IsNullOrEmpty(adjustments))
            {
                float TotalAdjustment = float.Parse(dsReportData.Tables[0].Compute("sum(Adjustments)", string.Empty).ToString());
                Label lblTotalAdjustments = FooterTemplate.FindControl("lblTotalAdjustments") as Label;
                lblTotalAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAdjustment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Payment"].ToString()))
            {
                float TotalPayment = float.Parse(dsReportData.Tables[0].Compute("sum(Payment)", string.Empty).ToString());
                Label lblTotalPayments = FooterTemplate.FindControl("lblTotalPayments") as Label;
                lblTotalPayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPayment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Balance"].ToString()))
            {
                float TotalBalance = float.Parse(dsReportData.Tables[0].Compute("sum(Balance)", string.Empty).ToString());
                Label lblTotalBalance = FooterTemplate.FindControl("lblTotalBalance") as Label;
                lblTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalBalance));
            }
        }


    }

    public void GetTotal()
    {
        PatientIds = Request.Form["SearchedPatientId"].ToString();

        ProviderId = Request.Form["ProviderId"];
        DateType = Request.Form["DateType"];
        CustomDate = Request.Form["CustomDate"];

       if (CustomDate == "Today")
       {
           AsOf = DateTime.Today.ToShortDateString();
       }
       else if (CustomDate == "Yesterday")
       {
           AsOf = DateTime.Today.AddDays(-1).ToShortDateString();
       }
       else if (CustomDate == "Custom")
       {
           AsOf = Request.Form["AsOf"];
       }
        lblReportTimeSpanTo.Text = AsOf;
        DataSet dsReportData = objPatientReportsDB.ItemizationOfcharges(Convert.ToInt32(Profile.PracticeId), Rows, 0, "DOS Desc", DateType, AsOf, ProviderId,int.Parse( PatientIds), PayerId);
    
        Control FooterTemplate = rptItemizationOfCharges.Controls[rptItemizationOfCharges.Controls.Count - 1].Controls[0];
        if (dsReportData.Tables[0].Rows.Count > 0)
        {
            Label lblGranAverage = FooterTemplate.FindControl("lblGranAverage") as Label;
            lblGranAverage.Text = "Grand Total";
            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Charges"].ToString()))
            {
                float TotalCharges = float.Parse(dsReportData.Tables[0].Compute("sum(Charges)", string.Empty).ToString());
                Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }


            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Adjustments"].ToString()))
            {
                float TotalAdjustment = float.Parse(dsReportData.Tables[0].Compute("sum(Adjustments)", string.Empty).ToString());
                Label lblTotalAdjustments = FooterTemplate.FindControl("lblTotalAdjustments") as Label;
                lblTotalAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAdjustment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Payment"].ToString()))
            {
                float TotalPayment = float.Parse(dsReportData.Tables[0].Compute("sum(Payment)", string.Empty).ToString());
                Label lblTotalPayments = FooterTemplate.FindControl("lblTotalPayments") as Label;
                lblTotalPayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPayment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Balance"].ToString()))
            {
                float TotalBalance = float.Parse(dsReportData.Tables[0].Compute("sum(Balance)", string.Empty).ToString());
                Label lblTotalBalance = FooterTemplate.FindControl("lblTotalBalance") as Label;
                lblTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalBalance));
            }
        }

    }




    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        if (exportTo == "Excel")
        {
            ExportToExcel(sender, e);
        }
        else if (exportTo == "PDF")
        {
            repeaterExportToPDF(sender, e);
        }
        else if (exportTo == "Word")
        {
            repeaterExportToWord(sender, e);
        }
    }


    public void repeaterExportToPDF(object sender, EventArgs e)
    {
        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        PatientIds = Request.Form["SearchedPatientId"].ToString();
        ProviderId = Request.Form["ProviderId"];
        DateType = Request.Form["DateType"];
        CustomDate = Request.Form["CustomDate"];

        if (CustomDate == "Today")
        {
            AsOf = DateTime.Today.ToShortDateString();
        }
        else if (CustomDate == "Yesterday")
        {
            AsOf = DateTime.Today.AddDays(-1).ToShortDateString();
        }
        else if (CustomDate == "Custom")
        {
            AsOf = Request.Form["AsOf"];
        }
        lblReportTimeSpanTo.Text = AsOf;
        DataSet dsReportData = objPatientReportsDB.ItemizationOfcharges(Convert.ToInt32(Profile.PracticeId), Rows, 0, "DOS Desc", DateType, AsOf, ProviderId,int.Parse(PatientIds), PayerId);
        Document document = new Document();
        Response.ContentType = "application/pdf"; Response.AddHeader("content-disposition", "attachment;filename=Itemization Of Charges.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter.GetInstance(document, Response.OutputStream);
        document.Open();
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 8);

        PdfPTable table = new PdfPTable(dsReportData.Tables[0].Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[] { 10f, 10f, 10f, 0f };

        // table.SetWidths(widths);

        table.WidthPercentage = 100;
        int iCol = 0;
        string colname = "";
        PdfPCell cell = new PdfPCell(new Phrase("Products"));

        cell.Colspan = dsReportData.Tables[0].Columns.Count;

        /*foreach (DataColumn c in dtReportData.Columns)
        {

            table.AddCell(new Phrase(c.ColumnName, font5));
        }*/

        table.AddCell(new Phrase("S.NO", font5));
        table.AddCell(new Phrase("Visit #", font5));
        table.AddCell(new Phrase("Patient", font5));
        table.AddCell(new Phrase("Provider", font5));
        table.AddCell(new Phrase("DOS", font5));
        table.AddCell(new Phrase("Post Date", font5));
        table.AddCell(new Phrase("Procedure Description", font5));
        table.AddCell(new Phrase("Codes", font5));
        table.AddCell(new Phrase("Charges", font5));
        table.AddCell(new Phrase("Adjustments", font5));
        table.AddCell(new Phrase("Payments", font5));
        table.AddCell(new Phrase("Balance", font5));

        foreach (DataRow r in dsReportData.Tables[0].Rows)
        {
            if (dsReportData.Tables[0].Rows.Count > 0)
            {

                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
                table.AddCell(new Phrase(r[2].ToString(), font5));
                table.AddCell(new Phrase(r[3].ToString(), font5));
                table.AddCell(new Phrase(r[4].ToString(), font5));
                table.AddCell(new Phrase(r[5].ToString(), font5));
                table.AddCell(new Phrase(r[6].ToString(), font5));
                table.AddCell(new Phrase(r[7].ToString(), font5));
                table.AddCell(new Phrase("$" + r[8].ToString(), font5));
                table.AddCell(new Phrase("$" + r[9].ToString(), font5));
                table.AddCell(new Phrase("$" + r[10].ToString(), font5));
                table.AddCell(new Phrase("$" + r[11].ToString(), font5));
            
            }
        }
        /***************Footer************/
 
           Control FooterTemplate = rptItemizationOfCharges.Controls[rptItemizationOfCharges.Controls.Count - 1].Controls[0];
        if (dsReportData.Tables[0].Rows.Count > 0)
        {
            Label lblGranAverage = FooterTemplate.FindControl("lblGranAverage") as Label;
            Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
            Label lblTotalAdjustments = FooterTemplate.FindControl("lblTotalAdjustments") as Label;
            Label lblTotalPayments = FooterTemplate.FindControl("lblTotalPayments") as Label;
            Label lblTotalBalance = FooterTemplate.FindControl("lblTotalBalance") as Label;
            lblGranAverage.Text = "Grand Total";
            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Charges"].ToString()))
            {
                float TotalCharges = float.Parse(dsReportData.Tables[0].Compute("sum(Charges)", string.Empty).ToString());
              //  Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }


            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Adjustments"].ToString()))
            {
                float TotalAdjustment = float.Parse(dsReportData.Tables[0].Compute("sum(Adjustments)", string.Empty).ToString());
          
                lblTotalAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAdjustment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Payment"].ToString()))
            {
                float TotalPayment = float.Parse(dsReportData.Tables[0].Compute("sum(Payment)", string.Empty).ToString());
             
                lblTotalPayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPayment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Balance"].ToString()))
            {
                float TotalBalance = float.Parse(dsReportData.Tables[0].Compute("sum(Balance)", string.Empty).ToString());
                
                lblTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalBalance));
            }
        


            PdfPTable tableFooter = new PdfPTable(dsReportData.Tables[0].Columns.Count);
            float[] widthsFooter = new float[] { 10f, 10f, 10f, 0f };
            table.WidthPercentage = 100;
            PdfPCell cellFooter = new PdfPCell(new Phrase("Products"));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
            table.AddCell(new Phrase("", font5));
       
            table.AddCell(new Phrase(lblGranAverage.Text, font5));
            table.AddCell(new Phrase(lblTotalCharges.Text, font5));
            table.AddCell(new Phrase(lblTotalAdjustments.Text, font5));
            table.AddCell(new Phrase(lblTotalPayments.Text, font5));
            table.AddCell(new Phrase(lblTotalBalance.Text, font5));

            document.Add(tableFooter);
        }
        /***************end footer***********/
        document.Add(table);
        document.Close();
        Response.Write(document);
        Response.End();

    }


    protected void ExportToExcel(object sender, EventArgs e)
    {

        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        PatientIds = Request.Form["SearchedPatientId"].ToString();
        ProviderId = Request.Form["ProviderId"];
        DateType = Request.Form["DateType"];
        CustomDate = Request.Form["CustomDate"];

        if (CustomDate == "Today")
        {
            AsOf = DateTime.Today.ToShortDateString();
        }
        else if (CustomDate == "Yesterday")
        {
            AsOf = DateTime.Today.AddDays(-1).ToShortDateString();
        }
        else if (CustomDate == "Custom")
        {
            AsOf = Request.Form["AsOf"];
        }
        lblReportTimeSpanTo.Text = AsOf;
        DataSet dsReportData = objPatientReportsDB.ItemizationOfcharges(Convert.ToInt32(Profile.PracticeId), Rows, 0, "DOS Desc", DateType, AsOf, ProviderId, Convert.ToInt32(PatientIds), PayerId);
        rptItemizationOfCharges.DataSource = dsReportData.Tables[0];
        rptItemizationOfCharges.DataBind();
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Itemization of Charges.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        GetTotal();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptItemizationOfCharges.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }


    public void repeaterExportToWord(object sender, EventArgs e)
    {


        int Rows = Convert.ToInt32(hdnTotalRows.Value);
        PatientIds = Request.Form["SearchedPatientId"].ToString();
        ProviderId = Request.Form["ProviderId"];
        DateType = Request.Form["DateType"];
        CustomDate = Request.Form["CustomDate"];

        if (CustomDate == "Today")
        {
            AsOf = DateTime.Today.ToShortDateString();
        }
        else if (CustomDate == "Yesterday")
        {
            AsOf = DateTime.Today.AddDays(-1).ToShortDateString();
        }
        else if (CustomDate == "Custom")
        {
            AsOf = Request.Form["AsOf"];
        }
        lblReportTimeSpanTo.Text = AsOf;
        DataSet dsReportData = objPatientReportsDB.ItemizationOfcharges(Convert.ToInt32(Profile.PracticeId), Rows, 0, "DOS Desc", DateType, AsOf, ProviderId, Convert.ToInt32(PatientIds), PayerId);
        rptItemizationOfCharges.DataSource = dsReportData.Tables[0];
        rptItemizationOfCharges.DataBind();
        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=Itemization of Charges.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        GetTotal();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptItemizationOfCharges.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void rptItemizationOfCharges_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Charges = drv["Charges"].ToString();
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            if (Charges != "")
            {
                lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Charges));
            }
            string Adjustment = drv["Adjustments"].ToString();
            Label lblAdjustments = (Label)e.Item.FindControl("lblAdjustments");
            if (Adjustment != "")
            {
                lblAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Adjustment));
            }

            string Payment = drv["Payment"].ToString();
            Label lblPayment = (Label)e.Item.FindControl("lblPayment");
            if (Payment != "")
            {
                lblPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Payment));
                
            }

            string Balance = drv["Balance"].ToString();
            Label lblBalance = (Label)e.Item.FindControl("lblBalance");
            if (Balance != "")
            {
                lblBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Balance));
                  
            }
         
        }
        
}

}