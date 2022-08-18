using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_PendingTranstionClaimList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientLoad();
        PTLReasonsLoad();
    }





    public void PatientLoad()
    { 
        PatientDB ObjPatientDB = new PatientDB();
        long PracticeId = Profile.PracticeId;

        DataSet dsPatientRecord = ObjPatientDB.PendingTransitionFilterPatients(0, "", "", "", "", "", "", "", PracticeId, 10, 0, "");    //FirstName

        rptPatients.DataSource = dsPatientRecord.Tables[0];
        rptPatients.DataBind();

        hdnTotalRows.Value = dsPatientRecord.Tables[1].Rows[0]["TotalRows"].ToString();

        hdnPracticeId.Value = Profile.PracticeId.ToString();
    }
    public void PTLReasonsLoad()
    {
        //PTLReasonsDB db = new PTLReasonsDB();
        //DataSet ds = db.GetAllPTLReasons(Profile.PracticeId);

        //ddlPtlReasons.DataSource = ds.Tables[0];
        //ddlPtlReasons.DataTextField = "Reason";
        //ddlPtlReasons.DataValueField = "Reason";
        //ddlPtlReasons.DataBind();
        //ddlPtlReasons.Items.Insert(0, new ListItem(string.Empty, string.Empty));


        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();

        DataSet dsPTLReasons = objPTLReasonsDB.GetAllPTLReasons();

        rptPTLReasonsPatient.DataSource = dsPTLReasons.Tables[0];
        rptPTLReasonsPatient.DataBind();

        //rptPTLReasonsClaim.DataSource = dsPTLReasons.Tables[1];
        //rptPTLReasonsClaim.DataBind();


    }



}