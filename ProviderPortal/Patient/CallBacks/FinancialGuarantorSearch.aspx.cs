using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Patient_CallBacks_FinancialGuarantorSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FinancialGuarantorDB objFinancialGuarantorDB = new FinancialGuarantorDB();
        long PracticeId = Profile.PracticeId;

        DataSet dsFinancialGuarantorDB = objFinancialGuarantorDB.GetBySearchCriteria("", "", "", "", "", PracticeId, 10, 0);

        rptFinancialGuarantor.DataSource = dsFinancialGuarantorDB.Tables[0];
        rptFinancialGuarantor.DataBind();

        hdnFinancialGuarantorTotalRows.Value = dsFinancialGuarantorDB.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}