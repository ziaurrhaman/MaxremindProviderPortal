using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_CallBacks_PatientBalanceDueDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            LoadPatientBalanceDueDetail();
        
    }

    private void LoadPatientBalanceDueDetail()
    {
        long PatientId = long.Parse(Request.Form["PatientId"]);

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsRecords = objPatientReportsDB.PatientBalanceDueDetail(PatientId);

        DataTable dtClaimCharges = dsRecords.Tables[0];
        DataTable dtPatientInfo = dsRecords.Tables[1];

        rptClaimCharges.DataSource = dtClaimCharges;
        rptClaimCharges.DataBind();

        SetPatientInfo(dtPatientInfo);
    }

    private void SetPatientInfo(DataTable dtPatientInfo)
    {
        if (dtPatientInfo.Rows.Count > 0)
        {
            lblPatientAccountReport.Text = dtPatientInfo.Rows[0]["PatientId"].ToString();
            lblPatientNameReport.Text = dtPatientInfo.Rows[0]["PatientName"].ToString();
            lblPatientAddressReport.Text = dtPatientInfo.Rows[0]["Address"].ToString();
            lblPatientContactReport.Text = dtPatientInfo.Rows[0]["Cell"].ToString();
        }
    }
}