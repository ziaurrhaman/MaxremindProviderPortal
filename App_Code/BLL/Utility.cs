using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Collections;
using System.Collections.Generic;
using iTextSharp.text.html;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    public Utility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool GetWorkDayOptions(DateTime Dat, string weekday)
    {
        DateTime dt = new DateTime();
        //int remain;
        int noOfWeek;
        DateTime tempdate;
        switch (weekday)
        {
            case "First":

                //following code is commented by Arshad for checking the week of month (01/25/2008)
                //dt = FindTheNthSpecificWeekday(Dat.Year,Dat.Month,1, Dat.DayOfWeek);
                //if (dt == Dat)
                //    return true;
                //else
                //    return false;

                //*****Following code is add by Arshad Mahmood to check week of month
                tempdate = new DateTime(Dat.Year, Dat.Month, 1);
                noOfWeek = 1;
                tempdate = tempdate.AddDays(1);
                while (tempdate.Day <= Dat.Day)
                {
                    if (tempdate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        noOfWeek += 1;
                    }
                    if (tempdate.Day == Dat.Day)
                    {
                        break;
                    }
                    tempdate = tempdate.AddDays(1);
                }

                if (noOfWeek == 1)
                    return true;
                else
                    return false;
            //break;

            case "Second":
                // dt = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 2, Dat.DayOfWeek);
                //if (dt == Dat)
                //    return true;
                //else
                //    return false;


                tempdate = new DateTime(Dat.Year, Dat.Month, 1);
                noOfWeek = 1;
                tempdate = tempdate.AddDays(1);
                while (tempdate.Day <= Dat.Day)
                {
                    if (tempdate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        noOfWeek += 1;

                    }
                    if (tempdate.Day == Dat.Day)
                    {
                        break;
                    }
                    tempdate = tempdate.AddDays(1);
                }

                if (noOfWeek == 2)
                    return true;
                else
                    return false;

            //break;
            case "Third":
                // dt = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 3, Dat.DayOfWeek);
                //if (dt == Dat)
                //    return true;
                //else
                //    return false;

                tempdate = new DateTime(Dat.Year, Dat.Month, 1);
                noOfWeek = 1;
                tempdate = tempdate.AddDays(1);
                while (tempdate.Day <= Dat.Day)
                {
                    if (tempdate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        noOfWeek += 1;

                    }
                    if (tempdate.Day == Dat.Day)
                    {
                        break;
                    }
                    tempdate = tempdate.AddDays(1);
                }

                if (noOfWeek == 3)
                    return true;
                else
                    return false;
            //break;
            case "Fourth":
                // dt = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 4, Dat.DayOfWeek);
                //if (dt == Dat)
                //    return true;
                //else
                //    return false;

                tempdate = new DateTime(Dat.Year, Dat.Month, 1);
                noOfWeek = 1;
                tempdate = tempdate.AddDays(1);
                while (tempdate.Day <= Dat.Day)
                {
                    if (tempdate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        noOfWeek += 1;

                    }
                    if (tempdate.Day == Dat.Day)
                    {
                        break;
                    }
                    tempdate = tempdate.AddDays(1);
                }

                if (noOfWeek == 4)
                    return true;
                else
                    return false;
            //break;
            case "Fifth":
                // dt = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 4, Dat.DayOfWeek);
                //if (dt == Dat)
                //    return true;
                //else
                //    return false;

                tempdate = new DateTime(Dat.Year, Dat.Month, 1);
                noOfWeek = 1;
                tempdate = tempdate.AddDays(1);
                while (tempdate.Day <= Dat.Day)
                {
                    if (tempdate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        noOfWeek += 1;

                    }
                    if (tempdate.Day == Dat.Day)
                    {
                        break;
                    }
                    tempdate = tempdate.AddDays(1);
                }

                if (noOfWeek == 5)
                    return true;
                else
                    return false;
            //break;
            case "Alternate"://this opion should be removed with 2nd-4th and ist-3rd
                dt = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 1, Dat.DayOfWeek);
                DateTime dt1 = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 3, Dat.DayOfWeek);
                if (dt == Dat || dt1 == Dat)
                    return true;
                else
                    return false;
            //break;
            case "First-Third":
                //dt = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 1, Dat.DayOfWeek);
                //DateTime dt12 = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 3, Dat.DayOfWeek);
                //if (dt == Dat || dt12 == Dat)
                //    return true;
                //else
                //    return false;

                tempdate = new DateTime(Dat.Year, Dat.Month, 1);
                noOfWeek = 1;
                tempdate = tempdate.AddDays(1);
                while (tempdate.Day <= Dat.Day)
                {
                    if (tempdate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        noOfWeek += 1;

                    }
                    if (tempdate.Day == Dat.Day)
                    {
                        break;
                    }
                    tempdate = tempdate.AddDays(1);
                }

                if (noOfWeek == 1 || noOfWeek == 3)
                    return true;
                else
                    return false;

            //break;
            case "First-Third-Fifth":
                //dt = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 1, Dat.DayOfWeek);
                //DateTime dt12 = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 3, Dat.DayOfWeek);
                //if (dt == Dat || dt12 == Dat)
                //    return true;
                //else
                //    return false;

                tempdate = new DateTime(Dat.Year, Dat.Month, 1);
                noOfWeek = 1;
                tempdate = tempdate.AddDays(1);
                while (tempdate.Day <= Dat.Day)
                {
                    if (tempdate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        noOfWeek += 1;

                    }
                    if (tempdate.Day == Dat.Day)
                    {
                        break;
                    }
                    tempdate = tempdate.AddDays(1);
                }

                if (noOfWeek == 1 || noOfWeek == 3 || noOfWeek == 5)
                    return true;
                else
                    return false;

            //break;
            case "Second-Fourth":
                //dt = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 2, Dat.DayOfWeek);
                //DateTime dt13 = FindTheNthSpecificWeekday(Dat.Year, Dat.Month, 4, Dat.DayOfWeek);
                //if (dt == Dat || dt13 == Dat)
                //    return true;
                //else
                //    return false;

                tempdate = new DateTime(Dat.Year, Dat.Month, 1);
                noOfWeek = 1;
                tempdate = tempdate.AddDays(1);
                while (tempdate.Day <= Dat.Day)
                {
                    if (tempdate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        noOfWeek += 1;

                    }
                    if (tempdate.Day == Dat.Day)
                    {
                        break;
                    }
                    tempdate = tempdate.AddDays(1);
                }

                if (noOfWeek == 2 || noOfWeek == 4)
                    return true;
                else
                    return false;
            //break;

            case "Odd Week of Year":
                System.Globalization.CultureInfo ciCurr = System.Globalization.CultureInfo.CurrentCulture;
                int weekNum = ciCurr.Calendar.GetWeekOfYear(Dat, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                if (weekNum % 2 > 0)
                    return true;
                else
                    return false;
            //break;
            case "Even Week of Year":
                //System.Globalization.CultureInfo 
                ciCurr = System.Globalization.CultureInfo.CurrentCulture;
                weekNum = ciCurr.Calendar.GetWeekOfYear(Dat, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                if (weekNum % 2 == 0)
                    return true;
                else
                    return false;
            //break;

        }
        return true;
    }
    
    public static DateTime FindTheNthSpecificWeekday(int year, int month, int nth, System.DayOfWeek day_of_the_week)
    {
        // validate month value
        if (month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException("Invalid month value.");
        }

        // validate the nth value
        if (nth < 0 || nth > 5)
        {
            throw new ArgumentOutOfRangeException("Invalid nth value.");
        }

        // start from the first day of the month
        DateTime dt = new DateTime(year, month, 1);

        // loop until we find our first match day of the week
        while (dt.DayOfWeek != day_of_the_week)
        {
            dt = dt.AddDays(1);
        }

        if (dt.Month != month)
        {
            // we skip to the next month, we throw an exception
            throw new ArgumentOutOfRangeException("The given month has less than " + nth.ToString() + " " +
                day_of_the_week.ToString() + "s");
        }

        // Complete the gap to the nth week
        dt = dt.AddDays((nth - 1) * 7);


        return dt;
    }
    
    public static int Days_In_Month(string month)
    {
        string small_month = month.ToLower();
        int days = 1;
        switch (small_month)
        {
            case "january":
                days = 31;
                break;
            case "february":
                days = 28; // or 29 in the case of leap year
                break;
            case "march":
                days = 31;
                break;
            case "april":
                days = 30;
                break;
            case "may":
                days = 31;
                break;
            case "june":
                days = 30;
                break;
            case "july":
                days = 31;
                break;
            case "august":
                days = 31;
                break;
            case "september":
                days = 30;
                break;
            case "october":
                days = 31;
                break;
            case "november":
                days = 30;
                break;
            case "december":
                days = 31;
                break;

        }
        return days;
    }
    
    public static DateTime FindNthWeekday(int year, int month, int end_month, int day, int nth, System.DayOfWeek day_of_the_week)
    {
        // validate month value
        if (month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException("Invalid month value.");
        }

        // validate the nth value
        if (nth < 0 || nth > 5)
        {
            throw new ArgumentOutOfRangeException("Invalid nth value.");
        }

        // start from the first day of the month
        DateTime dt = new DateTime(year, month, day);

        // loop until we find our first match day of the week
        while (dt.DayOfWeek != day_of_the_week)
        {

            dt = dt.AddDays(1);

        }

        if (dt.Month != month && dt.Month > end_month)
        {
            // we skip to the next month, we throw an exception
            throw new ArgumentOutOfRangeException("The given month has less than " + nth.ToString() + " " +
                day_of_the_week.ToString() + "s");
        }

        // Complete the gap to the nth week
        dt = dt.AddDays((nth - 1) * 7);

        return dt;
    }
    
    #region 2065
    public static long dateDiff(string firstDate, string secondDate)
    {
        TimeSpan timeDiff = Convert.ToDateTime(firstDate) - Convert.ToDateTime(secondDate);
        return timeDiff.Ticks;

    }
    #endregion
    
    
    #region Export Functionality
    public void ExportToExcel(ref string html, string fileName)
    {
        html = html.Replace("&gt;", ">");
        html = html.Replace("&lt;", "<");
        
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("M_dd_yyyy_H_M_s") + ".xls");
        HttpContext.Current.Response.ContentType = "application/xls";
        
        //HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Report.xlsx");
        
        HttpContext.Current.Response.Write(html);
        HttpContext.Current.Response.End();
    }
    
    public void ExportToPDF(ref string html, string fileName)
    {
        string FileName = fileName + DateTime.Now.ToString("M_dd_yyyy_H_M_s");
        html = html.Replace("&gt;", ">");
        html = html.Replace("&lt;", "<");
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".pdf");// + fileName + "_" + DateTime.Now.ToString("M_dd_yyyy_H_M_s") + ".pdf");        
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        StringReader sr = new StringReader(html);
        Document pdfDoc = new Document(PageSize._11X17, 2f, 2f, 2f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        HttpContext.Current.Response.Write(pdfDoc);
        HttpContext.Current.Response.End();
    }

    public void ExportToWord(string html, string fileName)
    {
        html = html.Replace("&gt;", ">");
        html = html.Replace("&lt;", "<");

        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".doc");
        HttpContext.Current.Response.Write(html);
        HttpContext.Current.Response.End();
    }
    
    //public void ExportToPDF(iTextSharp.text.Table grdTable, string fileName)
    //{
    //    string FileName = fileName + DateTime.Now.ToString("M_dd_yyyy_H_M_s");
    //    iTextSharp.text.Document Doc = new iTextSharp.text.Document();
    //    iTextSharp.text.pdf.PdfWriter.GetInstance(Doc, HttpContext.Current.Response.OutputStream);
    //    Doc.Open();
    //    Doc.Add(grdTable);
    //    Doc.Close();
    //    HttpContext.Current.Response.ContentType = "application/pdf";
    //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".pdf");
    //    HttpContext.Current.Response.End();
    //}
    
    public void ExportToPDFA2(ref string html, string filename)
    {
        string FileName = filename + DateTime.Now.ToString("M_dd_yyyy_H_M_s");
        html = html.Replace("&gt;", ">");
        html = html.Replace("&lt;", "<");
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".pdf");// + fileName + "_" + DateTime.Now.ToString("M_dd_yyyy_H_M_s") + ".pdf");        
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        StringReader sr = new StringReader(html);
        Document pdfDoc = new Document(PageSize.A2, 2f, 62f, 2f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        HttpContext.Current.Response.Write(pdfDoc);
        HttpContext.Current.Response.End();
    }
    public void ExportToPDFA3(ref string html, string filename)
    {

        string FileName = filename + DateTime.Now.ToString("M_dd_yyyy_H_M_s");
        html = html.Replace("&gt;", ">");
        html = html.Replace("&lt;", "<");
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".pdf");// + fileName + "_" + DateTime.Now.ToString("M_dd_yyyy_H_M_s") + ".pdf");        
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        StringReader sr = new StringReader(html);
        Document pdfDoc = new Document(PageSize.A1, 2.0f, 62f, 2.0f, 2.0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        HttpContext.Current.Response.Write(pdfDoc);
        HttpContext.Current.Response.End();

    }
    
    //public void ExportAllData(iTextSharp.text.Table DataTable, string filename)
    //{
    //    string FileName = filename + DateTime.Now.ToString("M_dd_yyyy_H_M_s");
    //    iTextSharp.text.Font font_th = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 6, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED);
    //    HttpContext.Current.Response.ContentType = "application/pdf";
    //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".pdf");
    //    iTextSharp.text.Document document = new iTextSharp.text.Document();

    //    //    // step 2:
    //    //    // we create a writer that listens to the document
    //    //    // and directs a PDF-stream to a file
    //    iTextSharp.text.pdf.PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
    //    // step 3: we open the document
    //    document.Open();
    //    // step 4: we create a table and add it to the document
    //    document.Add(DataTable);
    //    // step 5: we close the document
    //    document.Close();
    //    HttpContext.Current.Response.Write(document);
    //    HttpContext.Current.Response.End();
    //}
    #endregion
}