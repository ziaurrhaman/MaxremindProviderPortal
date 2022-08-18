using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Controls_CallBacks_NewPatientInsuranceSearchHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Name = Request.Form["Name"];
        string City = Request.Form["City"];
        string State = Request.Form["State"];
        string Zip = Request.Form["Zip"];

        int rows = Convert.ToInt32(Request.Form["Rows"]);
        int pageNumber = Convert.ToInt32(Request.Form["pageNumber"]);
        string sortBy = Request.Form["SortBy"];

        InsuranceDB ObjInsuranceDB = new InsuranceDB();
        DataSet dsInsurance = ObjInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, Name, City, State, Zip, rows, pageNumber, sortBy);

        rptInsuranceSearch.DataSource = dsInsurance.Tables[0];
        rptInsuranceSearch.DataBind();
        ltrlInsuranceRowsCount.Text = dsInsurance.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}