using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class BillingManager_Payment_CallBacks_PaymentFilterHandler : System.Web.UI.Page
{
    string _ddldate = "";
    string PostDateFrom = "";
    string PostDateTo = "";
    string DATEOFSERIVCEFROM = "";
    string DATEOFSERIVCETO = "";
    protected void Page_Load(object sender, EventArgs e)
  {
        int Rows; int PageNumber; string SortBy; bool ERA; bool EOB; bool Unsettled;

        string Insurance = Request.Form["Insurance"] == "All" ? "" : Request.Form["Insurance"];
        string ProviderId = Request.Form["_ddlProvider"] == "All" ? "" : Request.Form["_ddlProvider"];
        _ddldate = Request.Form["_ddldate"] == "All" ? "" : Request.Form["_ddldate"];

        string _DateType = Request.Form["_DateType"];


        if (_DateType == "Post")
        {
            _DateType = "PostDate";
         
            PostDate();
          
           
        }

        else if (_DateType == "DOS")
        {
           
            DOSDate();
          
          
        }

        //else
        //{
        //    _DateType = "PostDate";
        //    DateTime Date = DateTime.Now;
        //    PostDateFrom = "01/01/2016";
        //    PostDateTo = DateTime.Today.ToString("M/d/yyyy");

        //}



        ERAMasterDB objERAMasterDB = new ERAMasterDB();
        long PracticeId = Profile.PracticeId;
        if (Request.Form["action"] == "true")
        {
            bool Verifiedstatus = true;
            string MasterId = Request.Form["MasterId"].ToString();
            DataSet dstrue = objERAMasterDB.UpdateCheckVerifingStatus(PracticeId, Convert.ToInt32(MasterId), Verifiedstatus);

        }

        if (Request.Form["action"] == "false")
        {
            bool Verifiedstatus = false;
            string MasterId = Request.Form["MasterId"].ToString();
            DataSet dstrue = objERAMasterDB.UpdateCheckVerifingStatus(PracticeId, Convert.ToInt32(MasterId), Verifiedstatus);

        }

        string CheckNumber = Request.Form["CheckNo"];
        string CheckDateStr = Request.Form["CheckDate"];
        string PostDateStr = Request.Form["PostDate"];
        string CheckAmount = Request.Form["CheckAmount"];
        string PostedAmount = Request.Form["PostedAmount"];
        string Vrified = Request.Form["verified"];
      
   
        if (Request.Form["Rows"] != null)
        {
           Rows = int.Parse(Request.Form["Rows"]);
        }
        else
        {
            Rows = int.Parse(Request.Form["Rowss"]);
        }
        if (Request.Form["pageNumber"] != null)
        {
           PageNumber = int.Parse(Request.Form["pageNumber"]);
        }

        else
        {
            if (Request.Form["pageNumbers"] == null)
            {
                PageNumber = 0;
            }
            else
            {
                PageNumber = int.Parse(Request.Form["pageNumbers"]);
            }
          
        }
        if (Request.Form["SortBy"] != null)
        {
        SortBy = Request.Form["SortBy"];
        }
        else
        {
        SortBy = Request.Form["SortBys"];
        }

        if (Request.Form["ERA"] != null)
        {
            ERA = bool.Parse(Request.Form["ERA"]);
        }
        else
        {
           ERA = bool.Parse(Request.Form["ERAs"]);
        }
        if (Request.Form["EOB"] != null)
        {
            EOB = bool.Parse(Request.Form["EOB"]);
        }
        else
        {
            EOB = bool.Parse(Request.Form["EOBs"]);
        }

        if (Request.Form["Unsettled"] != null)
        {
            Unsettled = bool.Parse(Request.Form["Unsettled"]);
        }
        else
        {
         Unsettled = bool.Parse(Request.Form["Unsettleds"]);
        
        }


        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

       
        DataSet ds = objERAMasterDB.GetBySearchCriteria(PracticeId, CheckNumber, CheckDateStr, PostDateStr, CheckAmount, PostedAmount, Insurance, Rows, PageNumber, SortBy,
            ERA, EOB, Unsettled, Vrified, IsImportedDataOnly, PostDateFrom, PostDateTo, DATEOFSERIVCEFROM, DATEOFSERIVCETO, ProviderId, _DateType);
        if (ds.Tables[0].Rows.Count > 0)
        {

       
            rptClaimCheck.DataSource = ds.Tables[0];
            rptClaimCheck.DataBind();
            ltrTotalRow.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();


            double chkamount = Convert.ToDouble(ds.Tables[0].Compute("SUM(CheckAmount)", string.Empty));
            hdnchkamount.Value = "$" + chkamount.ToString();

            double postamount = Convert.ToDouble(ds.Tables[0].Compute("SUM(PostedAmount)", string.Empty));
            hdnpostamount.Value = "$" + postamount.ToString();
        }
        else
        {
            ltrTotalRow.Text = "0";
        }
    }
    protected void rptClaimCheck_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {

            var dr = (DataRowView)e.Item.DataItem;
            Label lblOasisStatus = (Label)e.Item.FindControl("lblVerify");
            lblOasisStatus.CssClass = bool.Parse(dr["Verified"].ToString()) ? "tick" : "cross";
        }
    }


    protected void DOSDate()
    {
      
        if (!string.IsNullOrEmpty(_ddldate))
        {
            if (_ddldate == "MonthToDate")
            {
                DateTime Date = DateTime.Now;


                DATEOFSERIVCEFROM = new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy"); ;
                DATEOFSERIVCETO= Date.AddDays(1).ToString("M/d/yyyy"); ;

            }

            else if (_ddldate == "LastMonth")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 1)
                {
                    DATEOFSERIVCEFROM = new DateTime(Date.Year - 1, 12, 1).ToString("M/d/yyyy"); ;
                    DATEOFSERIVCETO = new DateTime(Date.Year - 1, Date.AddMonths(-1).Month, DateTime.DaysInMonth(Date.Year - 1, 12)).ToString("M/d/yyyy"); ;
                 
                }
                else
                {
                    DATEOFSERIVCEFROM = new DateTime(Date.Year, Date.Month - 1, 1).ToString("M/d/yyyy"); ;
                    DATEOFSERIVCETO = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year, Date.Month - 1)).ToString("M/d/yyyy"); ;
                  
                }



            }
            else if (_ddldate == "Last3Month")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 3)
                {
                    DATEOFSERIVCEFROM = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                    DATEOFSERIVCETO = DateTime.Today.ToString("M/d/yyyy"); ;

                    // DATEOFSERIVCETo = new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy");;
                }
                else
                {
                    DATEOFSERIVCEFROM = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                    DATEOFSERIVCETO = DateTime.Today.ToString("M/d/yyyy"); ;

                    //  DATEOFSERIVCETo=new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy");;
                }


               

            }


            else if (_ddldate == "YearToDate")
            {
                DateTime Date = DateTime.Now;

                DATEOFSERIVCEFROM = new DateTime(Date.Year, 1, 1).ToString("M/d/yyyy"); ;
                DATEOFSERIVCETO = Date.AddDays(1).ToString("M/d/yyyy"); ;
                //chkYearToDate.Checked = true;
               
            }
            else if (_ddldate == "selectdate")
            {
                DateTime Date = DateTime.Now;

                DATEOFSERIVCEFROM = Request.Form["_DateFrom"];
                DATEOFSERIVCETO = Request.Form["_DateTo"];
                //chkYearToDate.Checked = true;

            }

            
            else
            {
                DateTime Date = DateTime.Now;


                DATEOFSERIVCEFROM = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                DATEOFSERIVCETO = DateTime.Today.ToString("M/d/yyyy"); ;
              
            }


        }
    }
    protected void PostDate()
    {
        

        if (!string.IsNullOrEmpty(_ddldate))
        {
            if (_ddldate == "MonthToDate")
            {
                DateTime Date = DateTime.Now;

                PostDateFrom = new DateTime(Date.Year, Date.Month, 1).ToString("M/d/yyyy"); ;
                PostDateTo = Date.AddDays(1).ToString("M/d/yyyy"); ;

              
            }

            else if (_ddldate == "LastMonth")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 1)
                {
                    PostDateFrom = new DateTime(Date.Year - 1, 12, 1).ToString("M/d/yyyy"); ;

                    PostDateTo = new DateTime(Date.Year - 1, Date.AddMonths(-1).Month, DateTime.DaysInMonth(Date.Year - 1, 12)).ToString("M/d/yyyy"); ;
                }
                else
                {
                    PostDateFrom = new DateTime(Date.Year, Date.Month - 1, 1).ToString("M/d/yyyy"); ;

                    PostDateTo = new DateTime(Date.Year, Date.Month - 1, DateTime.DaysInMonth(Date.Year, Date.Month - 1)).ToString("M/d/yyyy"); ;
                }

               

            }
            else if (_ddldate == "Last3Month")
            {
                DateTime Date = DateTime.Now;

                if (Date.Month == 3)
                {
                    PostDateFrom = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                    PostDateTo = DateTime.Today.ToString("M/d/yyyy"); ;

                }
                else
                {
                    PostDateFrom = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                    PostDateTo = DateTime.Today.ToString("M/d/yyyy"); ;

                }

               
            }


            else if (_ddldate == "YearToDate")
            {
                DateTime Date = DateTime.Now;

                PostDateFrom = new DateTime(Date.Year, 1, 1).ToString("M/d/yyyy"); ;
                PostDateTo = Date.AddDays(1).ToString("M/d/yyyy"); ;
               
            }


           
            else if (_ddldate == "Last3Month")
            {
                DateTime Date = DateTime.Now;

              
                PostDateFrom = Date.AddDays(-90).ToString("M/d/yyyy"); ;
                PostDateTo = DateTime.Today.ToString("M/d/yyyy"); ;
               
            }
            else if (_ddldate == "selectdate")
            {
                DateTime Date = DateTime.Now;

                PostDateFrom = Request.Form["_DateFrom"];
                PostDateTo = Request.Form["_DateTo"];
                //chkYearToDate.Checked = true;

            }
        }
    }

}