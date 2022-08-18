using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Insurances_CallBacks_InsurancesListHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string rows = Request.Form["Rows"].ToString();
        string pageNO = Request.Form["PageNumber"].ToString();
        string InsuranceName = Request.Form["InsuranceName"].ToString();
        var objInsuranceDb = new InsuranceDB();
        DataSet dsInsurancesRecord = objInsuranceDb.GetInsurances(Profile.PracticeId, Convert.ToInt32(rows), Convert.ToInt32(pageNO), "Name", InsuranceName);
        rptInsurances.DataSource = dsInsurancesRecord.Tables[0];
        rptInsurances.DataBind();
        hdnInsurancesTotalCount.Value = dsInsurancesRecord.Tables[1].Rows[0]["TotalRows"].ToString();
        ltrlInsuranceRowsCount.Text = dsInsurancesRecord.Tables[1].Rows[0]["TotalRows"].ToString();

    }
}