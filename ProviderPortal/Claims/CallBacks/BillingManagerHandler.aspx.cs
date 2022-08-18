using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class EMR_Claims_CallBacks_BillingManagerHandler : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(Request.Form["Action"]))
        {
            string action = Request.Form["Action"];
            if (action == "SearchMultiInsuranceFromInsurance")
            {
                SearchMultiInsurancesFunction_Insurance_Reports();
            }
            else if (action == "SearchMultiInsuranceFromERA")
            {
                SearchMultiInsurancesFunction_ERA_Reports();
            }

            else if (action == "InsuranceList")
            {
                IsnuranceList();
            }
            else if (action == "SetSessionVarIsImported")
            {
                changeSeesionValueIsImported();
            }
            else
            {
                SearchMultiInsurancesFunction();
            }

            return;
        }
        else
        {
            LoadClaims();
        }
        
    }

    private void LoadClaims()
    {
        string ClaimId = Request.Form["ClaimId"];
        string PatientId = Request.Form["PatientId"];
        string PatientName = Request.Form["PatientName"];
        string DateOfService = Request.Form["DateOfService"];
        string BillDate = Request.Form["BillDate"];
        string InsuranceId = Request.Form["InsuranceId"];
        string SubmissionStatusId = Request.Form["SubmissionStatusId"];
        string Location = Request.Form["Location"];
        string Locationids = Request.Form["Locationids"];
        if (Locationids == "") { Locationids = null; }
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SORTBY"];
        string MRN = "";
        string PTLReasons = "";
        //string Location = "";
        string billedas = "";
        string charge = "";
        string balanceDue = Request.Form["AmountDue"];
        string AmountPaid = Request.Form["AmountPaid"];
        string Charges = Request.Form["charges"];
        /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Filter
        string ProviderId = Request.Form["ProviderId"];
        /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Filter
        bool isRPM = false;
        try
        {
              isRPM = bool.Parse(Request.Form["isRPM"]);
        }
        catch
        {

        }
        string dateFrom = Request.Form["dateFrom"];
        string dateTo = Request.Form["dateTo"];
        /***start***/
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        /***End***/
        var objClaimD = new ClaimDB();
        var ses = Session["SpecificView"];
        //Removed Session["SpecficView"] from  If
        if (dateFrom != null )
        {
           
            /******edited by sahid kazmi 1/22/2018*******/
            DataSet dsClaims = objClaimD.GetClaims_AllByUserId(Rows, PageNumber, Profile.PracticeId, SortBy, Convert.ToInt32(Profile.UserId.ToString()), ClaimId, PatientId,  PatientName, DateOfService, BillDate, InsuranceId, SubmissionStatusId, false, Location,  balanceDue, AmountPaid,true, IsImportedDataOnly, Locationids, isRPM,dateFrom,dateTo,Charges, ProviderId);
            /*********end shahid kazmi 1/22/2018************/
            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();

            hdnClaimsCount.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
        }
        else
        {
            
            /******edited by sahid kazmi 01/22/2018*******/
            DataSet dsClaims = objClaimD.GetAllByPractice(Rows, PageNumber, Profile.PracticeId, SortBy, ClaimId, PatientId,  PatientName, DateOfService, BillDate, InsuranceId, SubmissionStatusId, false, PTLReasons, Location, balanceDue, AmountPaid,true, IsImportedDataOnly, Locationids,isRPM,dateFrom,dateTo,Charges, ProviderId);
            /*********end shahid kazmi 1/22/2018************/
            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();

            hdnClaimsCount.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
        }

    }

    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsuranceId = drv["InsuranceId"].ToString();
            string Name = drv["Name"].ToString();

            Label lblInsuranceName = (Label)e.Item.FindControl("lblInsuranceName");
            //
            Label lblstatus = (Label)e.Item.FindControl("lblstatus");
            //if (drv["InsuranceStatus"].ToString() == "No Response")
            //{
            //    lblstatus.Text = "Billed";

            //}
            //else
            //{
            lblstatus.Text = drv["SubmissionStatus"].ToString();
            //}
            ////
            if (Name == "")
            {
                lblInsuranceName.Text = "Self Pay";
            }
            else
            {
                lblInsuranceName.Text = Name;
            }
        }
    }

    
    protected void rptInsurances_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsDeleted = drv["Deleted"].ToString();
            var InsList = e.Item.FindControl("InsList") as HtmlGenericControl;
            if (InsDeleted == "True")
            {
                InsList.Style.Add("background-color", "#808080");
                InsList.Style.Add("color", "#ffffff");
            }


        }

    }

    protected void SearchMultiInsurancesFunction()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        string InsuranceName = Request.Form["SearchMultiInsurances"].ToString();
        using (DataTable dtInsuranceDb = objInsuranceDB.GetAllInsurancesHavingClaims(Profile.PracticeId, InsuranceName))
        {
            rptInsurances.DataSource = dtInsuranceDb;
            rptInsurances.DataBind();
        }
    }

    protected void SearchMultiInsurancesFunction_Insurance_Reports()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        string InsuranceName = Request.Form["SearchMultiInsurances"].ToString();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, InsuranceName, "", "", "", 50, 0, "").Tables[0])
        {
            rptInsurances_Reports.DataSource = dtInsuranceDb;
            rptInsurances_Reports.DataBind();
        }
    }

    protected void SearchMultiInsurancesFunction_ERA_Reports()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        string InsuranceName = Request.Form["SearchMultiInsurances"].ToString();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, InsuranceName, "", "", "", 50, 0, "").Tables[0])
        {
            rptInsurances_Reports.DataSource = dtInsuranceDb;
            rptInsurances_Reports.DataBind();
        }
    }

    protected void IsnuranceList()
    {


        InsuranceDB objInsuranceDB = new InsuranceDB();
        DataTable dtInsuranceDb = objInsuranceDB.GetAllInsurancesHavingClaims(Profile.PracticeId, "");

        rptinsurance.DataSource = dtInsuranceDb;
       
        rptinsurance.DataBind();
        

    }

    public void changeSeesionValueIsImported()
    {
        var isimported= Request.Form["IsImported"];
        Session["IsImported"] = isimported;

    }
}