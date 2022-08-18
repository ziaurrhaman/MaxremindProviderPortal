using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Claim_CallBacks_ClaimSubmissionStatus : System.Web.UI.Page
{
    string DateCriteria = "";
    string PostStartDate = "";
    string PostEndDate = "";

    string StartDate = "";
    string EndDate = "";
    string Datetype = "";
    protected void Page_Load(object sender, EventArgs e)
    {

      
       

     

     
        ClaimChargesDB db = new ClaimChargesDB();
        if (Request.Form["DateCriteria"] != null)
        {
            DateCriteria = Request.Form["DateCriteria"].ToString();
        }
        else
        {
            DateCriteria = "Last90Days";
        }

        if (Request.Form["Datetype"] != null)
        {
            Datetype = Request.Form["Datetype"].ToString();
        }
        else
        {
            Datetype = "Dos";
        }
      
        
        string Location = Request.Form["Location"] == "All" ? "" : Request.Form["Location"];
       // string Location = Request.Form["Location"].ToString();

        string Provider = Request.Form["Provider"] == "All" ? "" : Request.Form["Provider"];
     //   string Provider = Request.Form["Provider"].ToString();
        string SubmissionStatus = Request.Form["SubmissionStatus"].ToString();
        if (Datetype == "Dos")
        {
            DOSDate();
        }
        else
        {
            PostDate();
        }


        DataSet ClaimSubmissionChar = db.CLAIMSUBMISSIONSTATUSPIECHARTDetail(Profile.PracticeId, 10, 0, "ClaimId asc", Location, StartDate, EndDate, Provider, SubmissionStatus, "", "", "", "", "", "", PostStartDate, PostEndDate,"");
        // DataSet ClaimSubmissionChar = db.CLAIMSUBMISSIONSTATUSPIECHARTDetail(Profile.PracticeId, 10, 0, "ClaimId asc", "",StartDate,EndDate);
        rptClaimSS.DataSource = ClaimSubmissionChar.Tables[0];
        rptClaimSS.DataBind();

        hdnTotalRows.Value = ClaimSubmissionChar.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnPracticeId.Value = Convert.ToString(Profile.PracticeId);



        

    }

    protected void DOSDate()
    {
        

        if (!string.IsNullOrEmpty(DateCriteria))
        {
            if (DateCriteria == "MonthToDate")
            {
                DateTime Date = DateTime.Now;


                StartDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                EndDate = Date.AddDays(1).ToShortDateString();


                // Label.Text = " Month To Date ";
            }

            if (DateCriteria == "LastMonth")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 1)
                {
                    StartDate = new DateTime(Date.Year - 1, 12, 1).ToShortDateString();
                    // EndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year - 1, 12)).ToShortDateString();
                    EndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                }
                else
                {
                    StartDate = new DateTime(Date.Year, Date.Month - 1, 1).ToShortDateString();
                    //  EndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year, Date.Month - 1)).ToShortDateString();
                    EndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                }



                //Label.Text = " Last Month ";

            }


            if (DateCriteria == "YearToDate")
            {
                DateTime Date = DateTime.Now;

                StartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                EndDate = Date.AddDays(1).ToShortDateString();

                // Label.Text = "Year To Date";
            }


            if (DateCriteria == "Select")
            {
                //chkSelectDate.Checked = true;
                //txtFromDate.Enabled = true;
                //txtToDate.Enabled = true;
                StartDate = Request.Form["stratDate"].ToString();
                EndDate = Request.Form["EndDate"].ToString();
            }

            else if (DateCriteria == "Last90Days")
            {
                DateTime Date = DateTime.Now;

                //StartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                StartDate = Date.AddDays(-90).ToShortDateString();
                EndDate = DateTime.Today.ToShortDateString();

            }

        }
    }
    protected void PostDate()
    {
        //txtFromDate.Text = PostStartDate;
        //txtToDate.Text = PostEndDate;

        if (!string.IsNullOrEmpty(DateCriteria))
        {
            if (DateCriteria == "MonthToDate")
            {
                DateTime Date = DateTime.Now;

                PostStartDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                PostEndDate = Date.AddDays(1).ToShortDateString();


                // Label.Text = " Month To Date ";
            }

            if (DateCriteria == "LastMonth")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 1)
                {
                    PostStartDate = new DateTime(Date.Year - 1, 12, 1).ToShortDateString();
                    //PostEndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year - 1, 12)).ToShortDateString();
                    PostEndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                }
                else
                {
                    PostStartDate = new DateTime(Date.Year, Date.Month - 1, 1).ToShortDateString();
                    PostEndDate = new DateTime(Date.Year, Date.Month, 1).ToShortDateString();
                    // PostEndDate = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year, Date.Month - 1)).ToShortDateString();
                }

                //  chkLastMonth.Checked = true;
                // Label.Text = " Last Month ";

            }


            if (DateCriteria == "YearToDate")
            {
                DateTime Date = DateTime.Now;

                PostStartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                PostEndDate = Date.AddDays(1).ToShortDateString();
                //chkYearToDate.Checked = true;
                //Label.Text = "Year To Date";
            }


            if (DateCriteria == "Select")
            {
                PostStartDate = Request.Form["stratDate"].ToString();
                PostEndDate = Request.Form["EndDate"].ToString();
            }

            else if (DateCriteria == "Last90Days")
            {
                DateTime Date = DateTime.Now;

                //StartDate = new DateTime(Date.Year, 1, 1).ToShortDateString();
                PostStartDate = Date.AddDays(-90).ToShortDateString();
                PostEndDate = DateTime.Today.ToShortDateString();

            }

        }
    }
    protected void rptClaimSS_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
         var dr = (DataRowView)e.Item.DataItem;
         if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
         {
             DropDownList ddl = (DropDownList)e.Item.FindControl("ddl");
             ddl.Text = "T1";
         }
    }
}