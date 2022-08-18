using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientDocument_CallBacks_PatientDocumentFilterHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FilterDocuments();
    }

    private void FilterDocuments()
    {
        string Name = Request.Form["Name"].ToString();
        string Date = Request.Form["Date"].ToString();
        string Category = Request.Form["Category"].ToString();
        int Rows = int.Parse(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());
        string SortBy = Request.Form["SortBy"].ToString();
        string PatientName = Request.Form["PatientName"].ToString();
        string ProviderName = Request.Form["ProviderName"].ToString();

        LoadPatientDocuments(Name, Date, Category, Rows, PageNumber, SortBy, PatientName, ProviderName);
    }

    private void LoadPatientDocuments(string Name, string Date, string Category, int Rows, int PageNumber, string SortBy, string PatientName, string ProviderName)
    {
        PatientDocumentDB objPatientDocumentDB = new PatientDocumentDB();

        long PatientId = long.Parse(Request.Form["PatientId"]);

        DataSet dsPatientDocuments = objPatientDocumentDB.FilterPatientDocuments(PatientId, Name, Date, Category, Rows, PageNumber, SortBy, PatientName, ProviderName);

        rptPatientDocuments.DataSource = dsPatientDocuments.Tables[0];
        rptPatientDocuments.DataBind();

        ltrlPatientDocumentsRowsCount.Text = dsPatientDocuments.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}