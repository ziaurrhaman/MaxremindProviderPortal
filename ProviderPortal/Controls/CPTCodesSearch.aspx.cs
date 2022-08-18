using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProviderPortal_Controls_ICD9CodesSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request.Form["Code"];
        string Description = Request.Form["Description"];
        string PriIns = Request.Form["PriIns"];
        string PrimaryStatus = "INS";
        if (PriIns == "0") { PrimaryStatus = "SELF"; }

        var objCpt1CodesDb = new CPT1CodesDB();


        rptCPTCode.DataSource = objCpt1CodesDb.FilterCPTs(code, Description, Profile.PracticeId, PrimaryStatus,false);
        rptCPTCode.DataBind();

        //rptCPTSearchReport.DataSource = objCpt1CodesDb.FilterCPTs(code, Description, Profile.PracticeId, PrimaryStatus, Profile.FeeSchedule);
        //rptCPTSearchReport.DataBind();
    }
}