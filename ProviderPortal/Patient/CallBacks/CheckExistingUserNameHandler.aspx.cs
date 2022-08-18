using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Patient_CallBacks_CheckExistingUserNameHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        PatientDB objPatientDB = new PatientDB();
        long PatientId = long.Parse(Request.Form["PatientId"]);
        DataTable dtExisting = objPatientDB.CheckExistingUserName(Request.Form["userName"], PatientId);
        if (dtExisting.Rows.Count > 0)
        {
            ltrResponse.Text = "Existing";
        }
        else
        {
            ltrResponse.Text = "NotExisting";
        }
    }
}