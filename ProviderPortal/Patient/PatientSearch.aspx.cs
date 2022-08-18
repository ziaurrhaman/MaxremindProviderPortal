using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillingManager_Patient_PatientSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //edited by Khayyam Adeel as per task reuirement dated 8/10/2021;
           //int  Practice = 1026;
            spnPatientSection.Visible = (Profile.PracticeId== 1026) ? false : spnPatientSection.Visible = false;
        
        }
        else
        {
            PatientPayments();
        }
        bool isRPM = false;
        if (!string.IsNullOrEmpty(Request.QueryString["RPM"]))
        {
            var n = Request.QueryString["RPM"].ToString();
            isRPM = (n == "1") ? true : false;

        }
        
        PatientDB ObjPatientDB = new PatientDB();
        long PracticeId = Profile.PracticeId;

        DataSet dsPatientRecord = ObjPatientDB.FilterPatients(0, "", "", "", "", "", "", "", PracticeId, 10, 0, "Account Number desc",false, "", "","","", isRPM);    //FirstName
        foreach(DataRow Row in dsPatientRecord.Tables[0].Rows)
        {
            string DummyDOB = Row["DateOfBirth"].ToString();
            string DummyAddress = Row["Address"].ToString();
            string DummyAddress1 = "No Address";
            string DummyAddress2 = "00000";

            if (DummyDOB == "09/09/1900")
            {
                Row["DateOfBirth"] = null;
            }
            if(DummyAddress == "No Address, ,   , 00000" || DummyAddress.Contains(DummyAddress1) || DummyAddress.Contains(DummyAddress2))
            {
                Row["Address"] = null;
            }
        }

        rptPatients.DataSource = dsPatientRecord.Tables[0];
        rptPatients.DataBind();

        hdnTotalRows.Value = dsPatientRecord.Tables[1].Rows[0]["TotalRows"].ToString();

        hdnPracticeId.Value = Profile.PracticeId.ToString();
        
    }
    private void LoadPatients()
    {
        long PatientId = long.Parse(Request.Form["PatientId"].ToString());
        string FirstName = Request.Form["FirstName"].ToString();
        string LastName = Request.Form["LastName"].ToString();
        bool isRPM = false;
        if (!string.IsNullOrEmpty(Request.QueryString["RPM"]))
        {
            var n = Request.QueryString["RPM"].ToString();
            isRPM = (n == "1") ? true : false;

        }
        isRPM = bool.Parse(Request.Form["isRPM"].ToString());


        int Rows = int.Parse(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());

        string Gender = Request.Form["Gender"].ToString();
        string Address = Request.Form["Address"].ToString();
        string PhoneNumber = Request.Form["Phone"].ToString();

        string SortBy = Request.Form["SortBy"].ToString();
        string DOB = Request.Form["DOB"].ToString();
        string PriInsurance = Request.Form["PriInsurance"].ToString();
        long PracticeId = Profile.PracticeId;
        string PatientCondition = Request.Form["PatientCondition"];

        bool IsPTL = false;

        if (Request.Form["IsPTL"] != null)
        {
            IsPTL = bool.Parse(Request.Form["IsPTL"]);
        }

        PatientDB ObjPatientDB = new PatientDB();

        DataSet dsPatients = ObjPatientDB.FilterPatients(PatientId, FirstName, LastName, DOB, PhoneNumber, Gender, Address, PatientCondition, PracticeId, Rows, PageNumber, SortBy, IsPTL, "", PriInsurance,"","", isRPM);

        foreach (DataRow Row in dsPatients.Tables[0].Rows)
        {
            string DummyDOB = Row["DateOfBirth"].ToString();
            string DummyAddress = Row["Address"].ToString();
            string DummyAddress1 = "No Address";
            string DummyAddress2 = "00000";

            if (DummyDOB == "09/09/1900")
            {
                Row["DateOfBirth"] = null;
            }
            if (DummyAddress == "No Address, ,   , 00000" || DummyAddress.Contains(DummyAddress1) || DummyAddress.Contains(DummyAddress2))
            {
                Row["Address"] = null;
            }
        }
        rptPatients.DataSource = dsPatients.Tables[0];
        rptPatients.DataBind();

        //ltrlPatientRowsCount.Text = dsPatients.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void rptPatients_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal PatientResponsibility = (Literal)e.Item.FindControl("ltrPatientResposibilty");
            Literal PatientPayment = (Literal)e.Item.FindControl("ltrPatientPayment");
            Literal PatientBalence = (Literal)e.Item.FindControl("ltrPatientBalence");
            HiddenField PatId = (HiddenField)e.Item.FindControl("hdnPatientId");
            HiddenField hdnCheckNos = (HiddenField)e.Item.FindControl("hdnCheckNos");
            ProcedurePaymentsDB objPPDB = new ProcedurePaymentsDB();
            DataSet ds = new DataSet();
            ds= objPPDB.GetPatientPayment(long.Parse(PatId.Value.ToString()));
            PatientResponsibility.Text =Convert.ToDecimal(ds.Tables[1].Rows[0]["PR"]).ToString("0.00");
            PatientPayment.Text = Convert.ToDecimal(ds.Tables[1].Rows[0]["TotalPaid"]).ToString("0.00");
            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[0]["RemainingBalance"].ToString()))
            {
                PatientBalence.Text = Convert.ToDecimal(ds.Tables[1].Rows[0]["RemainingBalance"]).ToString("0.00");
            }
            

            var mainresult = from myrow in ds.Tables[0].AsEnumerable()
                             select new
                             {
                                 CheckNumber = myrow.Field<string>("CheckNumber")
                             };

            foreach (var s in mainresult.Distinct())
            {
                hdnCheckNos.Value += s.CheckNumber+",";
            }
            //Left Repeater on Dialogue box


        }
    }

    public void PatientPayments()
    {
        string a = "";
        long patientid = long.Parse(Request.QueryString["PatientId"]);
        ProcedurePaymentsDB procedurePaymentsdb = new ProcedurePaymentsDB();
        DataSet ds = procedurePaymentsdb.GetPatientPayment(patientid);
        var mainresult = from myrow in ds.Tables[0].AsEnumerable()
                         select new
                         {
                             checknumber = myrow.Field<string>("CheckNumber"),
                             checkdate = myrow.Field<DateTime?>("checkDate"),
                             checkAmount = myrow.Field<decimal?>("PaymentAmount"),
                             PaymentPosted = myrow.Field<decimal?>("PaymentPosted"),
                             UnAppliedAmount = myrow.Field<decimal?>("UnAppliedAmount")

                         };
        RptBalanceSheet_Trn.DataSource = mainresult.Distinct();
        RptBalanceSheet_Trn.DataBind();

        if (ds.Tables[1].Rows.Count > 0)
        {
        }
    }
}