using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class ProviderPortal_Claims_CallBacks_OpenClaimForm : System.Web.UI.Page
{
    string ClaimChargeId = "";
    string Action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Request.Form["Action"];
        if (Action == "FilterClaimNotes")
        {
            FilterClaimNotes();
        }
        else
        {
            long ClaimId = Convert.ToInt64(Request.Form["ClaimId"].ToString());
            int Patientid = Convert.ToInt32(Request.Form["PatientId"].ToString());
            ClaimDB objclaimdb = new ClaimDB();
            DataSet ds = objclaimdb.GetClaimDetails(ClaimId, Patientid);

            GetClaimNotesByClaimId(ClaimId);
            // #region DxCodes

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow drClaim = ds.Tables[0].Rows[0];

                dxcode1.Text = drClaim["DxCode1"].ToString();
                dxcode2.Text = drClaim["DxCode2"].ToString();
                dxcode3.Text = drClaim["DxCode3"].ToString();
                dxcode4.Text = drClaim["DxCode4"].ToString();
                dxcode5.Text = drClaim["DxCode5"].ToString();
                dxcode6.Text = drClaim["DxCode6"].ToString();
                dxcode7.Text = drClaim["DxCode7"].ToString();
                dxcode8.Text = drClaim["DxCode8"].ToString();
                dxcode9.Text = drClaim["DxCode9"].ToString();
                dxcode10.Text = drClaim["DxCode10"].ToString();
                dxcode11.Text = drClaim["DxCode11"].ToString();
                dxcode12.Text = drClaim["DxCode12"].ToString();

                dxcode1Desc.Text = drClaim["dx1Description"].ToString();
                dxcode2Desc.Text = drClaim["dx2Description"].ToString();
                dxcode3Desc.Text = drClaim["dx3Description"].ToString();
                dxcode4Desc.Text = drClaim["dx4Description"].ToString();
                dxcode5Desc.Text = drClaim["dx5Description"].ToString();
                dxcode6Desc.Text = drClaim["dx6Description"].ToString();
                dxcode7Desc.Text = drClaim["dx7Description"].ToString();
                dxcode8Desc.Text = drClaim["dx8Description"].ToString();
                dxcode9Desc.Text = drClaim["dx9Description"].ToString();
                dxcode10Desc.Text = drClaim["dx10Description"].ToString();
                dxcode11Desc.Text = drClaim["dx11Description"].ToString();
                dxcode12Desc.Text = drClaim["dx12Description"].ToString();



                lblClaimId.Text = ClaimId.ToString();
                lblDos.Text = drClaim["DOS"].ToString();

                if (!string.IsNullOrEmpty(Request.Form["Status"]))
                {
                    string Status = Request.Form["Status"].ToString();
                    lblStatus.Text = Status;
                }
                else
                {
                    lblStatus.Text = "";
                }

                string ClaimTotal = string.Format("{0:0,0.00}", Convert.ToDouble(drClaim["ClaimTotal"].ToString()));
                lblTotalCharges.Text = "$" + ClaimTotal;
                string PrimaryInsurancePayment = string.Format("{0:0,0.00}", Convert.ToDouble(drClaim["PrimaryInsurancePayment"].ToString()));
                lblPriPaid.Text = "$" + PrimaryInsurancePayment;
                string SecondaryInsurancePayment = string.Format("{0:0,0.00}", Convert.ToDouble(drClaim["SecondaryInsurancePayment"].ToString()));
                lblSecPaid.Text = "$" + SecondaryInsurancePayment;
                string OtherInsurancePayment = string.Format("{0:0,0.00}", Convert.ToDouble(drClaim["OtherInsurancePayment"].ToString()));
                lblOthPaid.Text = "$" + OtherInsurancePayment;
                string PatientPayment = string.Format("{0:0,0.00}", Convert.ToDouble(drClaim["PatientPayment"].ToString()));
                lblPatPaid.Text = "$" + PatientPayment;
                string AmountDue = string.Format("{0:0,0.00}", Convert.ToDouble(drClaim["AmountDue"].ToString()));
                lblBalanceDue.Text = "$" + AmountDue;

                string AmountPaid = string.Format("{0:0,0.00}", Convert.ToDouble(drClaim["AmountPaid"].ToString()));
                lblTotalPaid.Text = "$" + AmountPaid;

                lblAdmissionDate.Text = drClaim["AdmissionDate"].ToString();
                lblDischargeDate.Text = drClaim["DischargeDate"].ToString();
                /// Modified By Irfan Mahmood 9/August/2022 : Add Provider
                ProvderName.Text = drClaim["AttendingPhysicianName"].ToString();
                /// End Modified By Irfan Mahmood 9/August/2022 : Add Provider

            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                DataRow drClaim = ds.Tables[3].Rows[0];
                string Adjustment = string.Format("{0:0,0.00}", Convert.ToDouble(drClaim["Adjustment"].ToString()));
                lblAdjusted.Text = "$" + Adjustment;
            }


            DataSet objClaimChargesAdjustment = objclaimdb.GetClaimChargesAndAdjustment(Convert.ToInt32(ClaimId));
            if (objClaimChargesAdjustment.Tables[0].Rows.Count > 0)
            {

                rptClaim.DataSource = objClaimChargesAdjustment.Tables[0];
                rptClaim.DataBind();


                //RepeaterSummary.DataSource = objClaimChargesAdjustment.Tables[0];
                //RepeaterSummary.DataBind();

            }
            DataTable ObjPaymentsummarydt = objclaimdb.GetClaimSummary(Convert.ToInt32(ClaimId));
            if (ObjPaymentsummarydt.Rows.Count > 0)
            {




                RepeaterSummary.DataSource = ObjPaymentsummarydt;
                RepeaterSummary.DataBind();

            }


            if (ds.Tables[2].Rows.Count > 0)
            {
                lblserviceLocation.Text = ds.Tables[2].Rows[0]["PlaceOfService"].ToString();

            }

            PatientDB objPatientDB = new PatientDB();
            DataSet ddtPatient = objPatientDB.Patient_GetById(Patientid, Profile.PracticeId);
            if (ddtPatient.Tables[0].Rows.Count > 0)
            {

                DataRow drPat = ddtPatient.Tables[0].Rows[0];

                string FirstName = drPat["FirstName"].ToString();
                string lastName = drPat["LastName"].ToString();
                string PatientId = drPat["PatientId"].ToString();

                lblName.Text = lastName + ", " + FirstName + ' ' + '(' + PatientId + ')';
                lblGender.Text = drPat["Gender"].ToString();
                lblPhone.Text = drPat["Phone"].ToString();
                if (drPat["Address"].ToString() == "No Address" || drPat["Zip"].ToString() == "00000" || drPat["DateOfBirth"].ToString() == "09/09/1900")
                {
                    lblDOB.Text = null;
                    lblAddress.Text = null;
                    lblCity.Text = null;
                    lblState.Text = null;
                    lblZip.Text = null;
                }
                else
                {
                    lblDOB.Text = drPat["DateOfBirth"].ToString();
                    lblAddress.Text = drPat["Address"].ToString();
                    lblCity.Text = drPat["City"].ToString();
                    lblState.Text = drPat["State"].ToString();
                    lblZip.Text = drPat["Zip"].ToString();
                }

            }

            DataSet dsInsurances = objclaimdb.GetInsurancesNameFromClaim(Convert.ToInt32(ClaimId), Patientid);
            if (dsInsurances.Tables[0].Rows.Count > 0)
            {
                string PriPolicyNo = dsInsurances.Tables[0].Rows[0]["PolicyNumber"].ToString();
                lblPriIns.Text = dsInsurances.Tables[0].Rows[0]["PrimaryInsurance"].ToString() + ' ' + '(' + PriPolicyNo + ')';
            }
            if (dsInsurances.Tables[1].Rows.Count > 0)
            {
                string SecPolicyNo = dsInsurances.Tables[1].Rows[0]["PolicyNumber"].ToString();
                lblSecIns.Text = dsInsurances.Tables[1].Rows[0]["SecondaryInsurance"].ToString() + ' ' + '(' + SecPolicyNo + ')';

            }
        }
    }
    protected void rptClaim_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            //HtmlTableCell CptCodetd = (HtmlTableCell)e.Item.FindControl("CptCodetd");

            
            HtmlTableRow tr1 = (HtmlTableRow)e.Item.FindControl("cpttr_data");
            HtmlTableCell tdDate = (HtmlTableCell)tr1.FindControl("tdClaimChargesId");
            string ClaimChargesIdDb = drv["ProcedurePaymentsId"].ToString();
            if (ClaimChargesIdDb != ClaimChargeId)
            {
                string a = tdDate.InnerText.Trim();
                ClaimChargeId = a;
               string reason= drv["Reasons"].ToString();
                Label lblReasons = (Label)e.Item.FindControl("lblReasons");
                lblReasons.Text = reason;

            }
            else
            {
                HtmlTableRow cpttr_head = (HtmlTableRow)e.Item.FindControl("cpttr_head");
                cpttr_head.Style.Add("display", "none");

                HtmlTableRow cpttr_data = (HtmlTableRow)e.Item.FindControl("cpttr_data");
                cpttr_data.Style.Add("display", "none");
                string reason = drv["Reasons"].ToString();
                Label lblReasons = (Label)e.Item.FindControl("lblReasons");
                lblReasons.Text = reason;
            }
          
            //if (!string.IsNullOrEmpty(drv["ClaimChargesId"].ToString()))
            //{


            //    string Deductible = drv["Reasons"].ToString();

            //    Label lblReasons = (Label)e.Item.FindControl("lblReasons");
            //    lblReasons.Text = Deductible;
            //    HtmlTableCell tdValue2 = (HtmlTableCell)e.Item.FindControl("tdValue2");
            //}

        }
        
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    DataRowView drv = (DataRowView)e.Item.DataItem;
        //    if (!string.IsNullOrEmpty(drv["Deductible"].ToString()))
        //    {
               

        //        string Deductible = drv["Deductible"].ToString();
                
        //        Label lblDeductible = (Label)e.Item.FindControl("lblDeductible");
        //        lblDeductible.Text = Deductible;
             
        //    }
        //    else
        //    {
        //        HtmlTableRow trCoInsuranc = (HtmlTableRow)e.Item.FindControl("trCoInsuranc");
        //        trCoInsuranc.Style.Add("display","none");
        //    }

        //    if (!string.IsNullOrEmpty(drv["CoInsurance"].ToString()))
        //    {


        //        string CoInsurance = drv["CoInsurance"].ToString();
        //        //string Deductible = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Deductible"].ToString()));
        //        Label lblCoInsurance = (Label)e.Item.FindControl("lblCoInsurance");
        //        lblCoInsurance.Text = CoInsurance;

        //    }
        //    else
        //    {
        //        HtmlTableRow trCoInsuranc = (HtmlTableRow)e.Item.FindControl("trcpay");
        //        trCoInsuranc.Style.Add("display", "none");
        //    }

        //    if (!string.IsNullOrEmpty(drv["CoPay"].ToString()))
        //    {


        //        string CoPay = drv["CoPay"].ToString();
        //        //string Deductible = string.Format("{0:0,0.00}", Convert.ToDouble(drv["Deductible"].ToString()));
        //        Label lblCopay = (Label)e.Item.FindControl("lblCopay");
        //        lblCopay.Text = CoPay;

        //    }
        //    else
        //    {
        //        HtmlTableRow trcpay = (HtmlTableRow)e.Item.FindControl("trcpay");
        //        trcpay.Style.Add("display", "none");
        //    }
        //}
    }

    DataTable dtClaimNotes = new DataTable();
    int ClaimNotesCount = 0;
    string notes = "";
    long ClaimNotesId = 0;
    string NoteDate = "";
    string CategoryName = "";
    string UserName = "";
    string Note1 = "Claim Accepted";
    string Note2 = "Status Update";
    string Note3 = "Payment is Added";
    private void GetClaimNotesByClaimId(long ClaimId)
    {
        ClaimDB claimdb = new ClaimDB();
        DataTable dtClaimNotesDetail = claimdb.GetClaimNotesByClaimId(ClaimId);
        if (dtClaimNotesDetail.Rows.Count > 0) { 
            foreach (DataRow row in dtClaimNotesDetail.Rows)
            {
                ClaimNotesId = Convert.ToInt32(row["ClaimNotesId"]);
                NoteDate = row["NoteDate"].ToString();
                notes = row["Notes"].ToString();
                if (notes.Contains(Note1))
                {
                    notes = "Claim Accepted for processing";
                }
                else if (notes.Contains(Note2))
                {
                    notes = "PRI Status Update From Accepted For Processing to Paid Up";
                }
                else if (notes.Contains(Note3))
                {
                    notes += " (Patient Payment)";
                }
                    CategoryName = row["CategoryName"].ToString();
                UserName = row["UserName"].ToString();
                ClaimNotesdt();
            }
        }
    }
    //code for make claim Notes table dynamically
    private void ClaimNotesdt()
    {
        if (ClaimNotesCount == 0)
        {
            dtClaimNotes.Columns.Add("ClaimNotesId");
            dtClaimNotes.Columns.Add("NoteDate");
            dtClaimNotes.Columns.Add("Notes");
            dtClaimNotes.Columns.Add("CategoryName");
            dtClaimNotes.Columns.Add("UserName");
            ClaimNotesCount = 1;
        }

        DataRow drDuplicateCliamSameDos = null;
        drDuplicateCliamSameDos = dtClaimNotes.NewRow();
        drDuplicateCliamSameDos[0] = ClaimNotesId;
        drDuplicateCliamSameDos[1] = Convert.ToDateTime(NoteDate).ToString("MM/dd/yyyy");
        drDuplicateCliamSameDos[2] = notes;
        drDuplicateCliamSameDos[3] = CategoryName;
        drDuplicateCliamSameDos[4] = UserName;
        dtClaimNotes.Rows.Add(drDuplicateCliamSameDos);

        rptClaimNotes.DataSource = dtClaimNotes;
        rptClaimNotes.DataBind();

    }
    //start added by Arslan satti on 04-20-2022
    private void FilterClaimNotes()
    {
        long ClaimId = Convert.ToInt64(Request.Form["ClaimId"].ToString());
        string SortBy = Request.Form["SORTBY"];
        ClaimDB claimdb = new ClaimDB();
        DataTable dtClaimNotesDetail = claimdb.GetFilterClaimNotesByClaimId(ClaimId, SortBy);
        rptFilterClaimNotes.DataSource = dtClaimNotesDetail;
        rptFilterClaimNotes.DataBind();
    }
    //end added by Arslan satti on 04-20-2022
}