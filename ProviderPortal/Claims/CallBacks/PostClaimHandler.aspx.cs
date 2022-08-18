using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.Script.Serialization;
public partial class HomeHealth_EpisodeClaims_CallBacks_PostClaimHandler : System.Web.UI.Page
{
    private Int64 claimNumber;
    private decimal claimAdjustments;
    private decimal claimPayments;
    private string ProcedureCode;
    protected void Page_Load(object sender, EventArgs e)
    {
            
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<ERAClaimList> objERAClaimList = serializer.Deserialize<List<ERAClaimList>>(Request.Form["ERAClaimList"]);
        StringBuilder sbReportTable = new StringBuilder();
        sbReportTable.Append("<table class='Grid Widget'><tr><th>Claim No</th><th>Procedure Code</th><th>Status</th></tr>");

        ClaimDB objClaimDb = new ClaimDB();

        for (int i = 0; i < objERAClaimList.Count; i++)
        {
            claimNumber = Convert.ToInt64(objERAClaimList[i].ClaimNumber);
            claimAdjustments = objERAClaimList[i].ClaimAdjustments;
            claimPayments = objERAClaimList[i].ClaimPayments;
            ProcedureCode = objERAClaimList[i].ProcedureCode;
            DataTable ddtClaims = objClaimDb.Claim_GetStatusById(claimNumber);

            if (ddtClaims.Rows.Count == 0)
            {
                sbReportTable.Append("<tr><td>" + claimNumber + "<td>"+ ProcedureCode + "</td>"+ "</td><td>" + "Claim not found" + "</td></tr>");
                continue;
            }

            if (Convert.ToInt32(ddtClaims.Rows[0]["ClaimStatus"]) == 104)
            {
                sbReportTable.Append("<tr><td>" + claimNumber + "<td>" + ProcedureCode + "</td>" + "</td><td>" + "Claim already Paid" + "</td></tr>");
                continue;
            }

            int result = objClaimDb.Claim_UpdateAfterERA(claimNumber, claimAdjustments, claimPayments);

            if (result == 1)
            {
                sbReportTable.Append("<tr><td>" + claimNumber + "<td>" + ProcedureCode + "</td>" + "</td><td>" + "Claim Paid Successfully" + "</td></tr>");
                continue;
            }
            else
            {
                sbReportTable.Append("<tr><td>" + claimNumber + "<td>" + ProcedureCode + "</td>" + "</td><td>" + "Claim Posting failure" + "</td></tr>");
                
            }
        }
        sbReportTable.Append("</table>");
        divReport.InnerHtml = sbReportTable.ToString();
    }
}

class ERAClaimList
{
    public string ClaimNumber { get; set; }
    public decimal ClaimPayments { get; set; }
    public decimal ClaimAdjustments { get; set; }
    public string ProcedureCode { get; set; }
}