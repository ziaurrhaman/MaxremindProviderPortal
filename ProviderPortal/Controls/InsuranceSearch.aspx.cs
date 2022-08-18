using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Controls_InsuranceSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StatesDB objStatesDB = new StatesDB();
        ddlInsuranceState.DataSource = objStatesDB.GetAllAsDataTable();

        ddlInsuranceState.DataValueField = "StateCode";
        ddlInsuranceState.DataTextField = "StateName";
        ddlInsuranceState.DataBind();
        ddlInsuranceState.Items.Insert(0, new ListItem("All", ""));

        InsuranceDB ObjInsuranceDB = new InsuranceDB();
        DataSet dsInsurance = ObjInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 10, 0, "");
        hdnTotalRowsINS.Value = dsInsurance.Tables[1].Rows[0]["TotalRows"].ToString();
        rptInsurance.DataSource = dsInsurance.Tables[0];
        rptInsurance.DataBind();
    }
}