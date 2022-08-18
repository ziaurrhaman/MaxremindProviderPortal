using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Eligibility_Eligibility : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPayerName();
    }
    public void LoadPayerName()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        //long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetAllinsurancePayerID();
        ddlPayerName.DataSource = dtPatient;
        ddlPayerName.DataBind();
        ddlPayerName.DataTextField = "InsuranceName";
        ddlPayerName.DataValueField = "InsuranceId";
        ddlPayerName.DataBind();
        ddlPayerName.Items.Insert(0, new ListItem("Please Select Payer Name", "0"));
    }
}