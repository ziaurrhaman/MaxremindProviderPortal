using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Claims_CallBacks_GetServiceCharges : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dos = Request.Form["dos"];
        string code = Request.Form["code"];
        
        CPT1CodesDB objServiceCharges = new CPT1CodesDB();
        
        DataTable dtServiceCharges = objServiceCharges.ServiceCharges(code, dos);
        
        if (dtServiceCharges.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtServiceCharges.Rows[0]["Par_Amount"].ToString()))
            {
                hdnParCharges.Value = dtServiceCharges.Rows[0]["Par_Amount"].ToString();
            }
            else
            {
                hdnParCharges.Value = "0";
            }
            
            if (!string.IsNullOrEmpty(dtServiceCharges.Rows[0]["Non_Par_Amount"].ToString()))
            {
                hdnNonParCharges.Value = dtServiceCharges.Rows[0]["Non_Par_Amount"].ToString();
            }
            else
            {
                hdnNonParCharges.Value = "0";
            }
        }
    }
}