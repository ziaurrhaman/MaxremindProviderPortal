using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HomeHealth_EpisodeClaims_ViewClaims : System.Web.UI.Page
{
   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string queryString = Request.QueryString.ToString();
        string[] queryStringSet = queryString.Split('&');
        for (int i = 0; i <queryStringSet.Length; i++)
        {
            Int64 claimId = Convert.ToInt64(queryStringSet[i].Split('=')[1]);
            if ( hdnQueryString.Value == "")
            {
                hdnQueryString.Value += claimId.ToString();
            }
            else
            {

                hdnQueryString.Value += "," + claimId.ToString();
            }

        }
    }
   
}