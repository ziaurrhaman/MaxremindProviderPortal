using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Patient_CallBacks_VarifyProviderPinHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long UserId = Profile.UserId;
        string PinCode = Request.Form["PinCode"];
        string PINCode = PinCode;
        UserProfileDB objUserProfileDB = new UserProfileDB();
        if (!string.IsNullOrEmpty(Request.Form["ServiceProviderId"]))
        {
            DataTable dtVerifyPIN = objUserProfileDB.VerifyProviderDigitalPIN(long.Parse(Request.Form["ServiceProviderId"]), PINCode);

            if (dtVerifyPIN.Rows[0]["ISPINEXIST"].ToString() != "0")
            {
                ltrPINResponse.Text = "Valid";
            }
            else
            {
                ltrPINResponse.Text = "InValid";
            }
        }
        else
        {
            DataTable dtVerifyPIN = objUserProfileDB.VerifyProfileDigitalPIN(UserId, PINCode);

            if (dtVerifyPIN.Rows[0]["ISPINEXIST"].ToString() != "0")
            {
                ltrPINResponse.Text = "Valid";
            }
            else
            {
                ltrPINResponse.Text = "InValid";
            }
        }
    }
}