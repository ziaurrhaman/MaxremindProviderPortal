using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using System.Data;
using System.Web.UI.WebControls;

public partial class EMR_Claims_CallBacks_SaveClaimHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];
        
        if (action == "SaveClaim")
        {
            SaveClaim();
            LoadClaims();
        }
        else if (action == "DeleteCharges")
        {
            DeleteClaimCharges();
        }
    }
    
    private void SaveClaim()
    {
        ClaimDB objClaimDB = new ClaimDB();

        long ClaimId = 0;
        var serializer = new JavaScriptSerializer();

        Claim objClaim = serializer.Deserialize<Claim>(Request.Form["objClaim"]);

        objClaim.PracticeId = Profile.PracticeId;

        if (objClaim.ClaimId == 0)
        {
            objClaim.CreatedById = Profile.UserId;
            objClaim.CreatedDate = DateTime.Now;
            
            ClaimId = objClaimDB.Add(objClaim);
        }
        else
        {
            ClaimId = objClaim.ClaimId;
            
            objClaim.ModifiedById = Profile.UserId;
            objClaim.ModifiedDate = DateTime.Now;
            
            objClaimDB.Update(objClaim);
        }
        
        ltrClaimId.Text = ClaimId.ToString();
        
        AddClaimCharges(ClaimId);
        
        objClaimDB.UpdateAmountDue(ClaimId);
    }
    
    private void AddClaimCharges(long ClaimId)
    {
        var serializer = new JavaScriptSerializer();
        var listClaimCharges = serializer.Deserialize<List<ClaimCharges>>(Request.Form["listClaimCharges"]);
        
        var objClaimChargesDB = new ClaimChargesDB();
        
        foreach (var objClaimCharges in listClaimCharges)
        {
            objClaimCharges.ClaimId = ClaimId;
            
            if (objClaimCharges.ClaimChargesId == 0)
            {
                objClaimCharges.CreatedById = Profile.UserId;
                objClaimCharges.CreatedDate = DateTime.Now;
                
                objClaimChargesDB.Add(objClaimCharges);
            }
            else
            {
                objClaimCharges.ModifiedById = Profile.UserId;
                objClaimCharges.ModifiedDate = DateTime.Now;
                
                objClaimChargesDB.Update(objClaimCharges);
            }
        }
        
        LoadClaimCharges(ClaimId);
    }
    
    private void DeleteClaimCharges()
    {
        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();

        var objClaimCharges = new ClaimCharges();

        objClaimCharges.ClaimChargesId = long.Parse(Request.Form["chargesId"]);

        objClaimCharges.ModifiedById = Convert.ToInt64(Profile.UserId);
        objClaimCharges.ModifiedDate = DateTime.Now;

        objClaimChargesDB.Delete(objClaimCharges);
    }
    
    private void LoadClaims()
    {
        ClaimDB objClaimDB = new ClaimDB();
        DataSet dsClaims = objClaimDB.GetAllByPractice(10, 0, Profile.PracticeId, "", "", "", "", "", "", "",  "", false, "", "",  "", "");
        rptClaims.DataSource = dsClaims.Tables[0];
        rptClaims.DataBind();
        hdnClaimsCount.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    
    private void LoadClaimCharges(long ClaimId)
    {
        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();
        
        DataTable dtClaimCharges = objClaimChargesDB.GetByClaimForClaimServicesInClaimDetail(ClaimId);
        
        rptPatientServices.DataSource = dtClaimCharges;
        rptPatientServices.DataBind();
    }
    
    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsuranceId = drv["InsuranceId"].ToString();
            string Name = drv["Name"].ToString();

            Label lblInsuranceName = (Label)e.Item.FindControl("lblInsuranceName");

            if (InsuranceId == "0")
            {
                lblInsuranceName.Text = "Self Pay";
            }
            else
            {
                lblInsuranceName.Text = Name;
            }
        }
    }
    
    protected void rptPatientServices_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            DropDownList ddlUnitCode = (DropDownList)e.Item.FindControl("ddlUnitCode");
            ddlUnitCode.SelectedValue = drv["UnitCode"].ToString().Trim();

            CheckBox cbIncludeInSubmission = (CheckBox)e.Item.FindControl("cbIncludeInSubmission");
            DropDownList ddlBillingStatus = (DropDownList)e.Item.FindControl("ddlBillingStatus");
            Label lblPointers = (Label)e.Item.FindControl("lblPointers");

            string IncludeInSubmission = drv["IncludeInSubmission"].ToString();

            string DXPointer1 = drv["DXPointer1"].ToString().Trim();
            string DXPointer2 = drv["DXPointer2"].ToString().Trim();
            string DXPointer3 = drv["DXPointer3"].ToString().Trim();
            string DXPointer4 = drv["DXPointer4"].ToString().Trim();
            string DXPointer5 = drv["DXPointer5"].ToString().Trim();
            string DXPointer6 = drv["DXPointer6"].ToString().Trim();
            string DXPointer7 = drv["DXPointer7"].ToString().Trim();
            string DXPointer8 = drv["DXPointer8"].ToString().Trim();

            string BillingStatus = drv["BillingStatus"].ToString().Trim();
            ddlBillingStatus.SelectedValue = BillingStatus;


            if (IncludeInSubmission == "True")
            {
                cbIncludeInSubmission.Checked = true;
            }

            string pointerString = "";

            if (!string.IsNullOrEmpty(DXPointer1))
            {
                if (DXPointer1 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer1)).Checked = true;
                    pointerString += DXPointer1 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer2))
            {
                if (DXPointer2 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer2)).Checked = true;
                    pointerString += DXPointer2 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer3))
            {
                if (DXPointer3 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer3)).Checked = true;
                    pointerString += DXPointer3 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer4))
            {
                if (DXPointer4 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer4)).Checked = true;
                    pointerString += DXPointer4 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer5))
            {
                if (DXPointer5 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer5)).Checked = true;
                    pointerString += DXPointer5 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer6))
            {
                if (DXPointer6 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer6)).Checked = true;
                    pointerString += DXPointer6 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer7))
            {
                if (DXPointer7 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer7)).Checked = true;
                    pointerString += DXPointer7 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer8))
            {
                if (DXPointer8 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer8)).Checked = true;
                    pointerString += DXPointer8 + ", ";
                }
            }

            if (pointerString.Length != 0)
            {
                pointerString = pointerString.Remove(pointerString.Length - 2);
            }

            lblPointers.Text = pointerString;
            lblPointers.ToolTip = pointerString;
        }
    }
}