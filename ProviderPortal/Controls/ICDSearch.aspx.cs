using System;
using System.Data;


public partial class ProviderPortal_Controls_ICDSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request.Form["Code"].ToString();
        string description = Request.Form["Description"].ToString();
        string action = Request.Form["action"];
        var objIcd9CodesDb = new ICD9CodesDB();
        if (action == "Pdf")
        {
            DataTable dt = objIcd9CodesDb.ICD9Codes_AutoComplete(code, description);
            if (dt.Rows.Count == 0)
            {
                code = description;
                description = "";
                dt = objIcd9CodesDb.ICD9Codes_AutoComplete(code, description);
            }
            divCross.Style.Remove("display");
            rptICDCodeSearch.DataSource = dt;
            rptICDCodeSearch.DataBind();
        }
        else
        {
            rptICDCodeSearch.DataSource = objIcd9CodesDb.ICD9Codes_AutoComplete(code, description);
            rptICDCodeSearch.DataBind();
        }
    }
}