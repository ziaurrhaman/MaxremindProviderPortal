using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProviderPortal_Claims_CallBacks_CheckPaymentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["Action"]))
        {
            if (Request.Form["Action"].ToString() == "LoadInfo")
            {
                LoadBillandPaidProc();
            }
        }
        else
        {
            string CheckNumber = Request.Form["CheckNumber"];
            string PaymentType = Request.Form["PaymentType"];

            ERAMasterDB objERAMasterDB = new ERAMasterDB();
            DataTable dtERAMasterCheck = objERAMasterDB.GetByCheckNumber(CheckNumber, PaymentType, Profile.PracticeId);
            rptChkDetails.DataSource = dtERAMasterCheck;
            rptChkDetails.DataBind();
        }
    }

    public void LoadBillandPaidProc()
    {
        ClaimDB objClaimDB = new ClaimDB();
        long ClaimId = long.Parse(Request.Form["ClaimId"]);
        //DataTable dt = objClaimDB.GetBillandPaidProc(Profile.PracticeId, ClaimId);
        //rptBillandPaidProc.DataSource = dt;
       // rptBillandPaidProc.DataBind();
    }
}