using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

public partial class HomeHealth_EpisodeClaims_CallBacks_EOBApplyPaymentsHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<ProcedurePayments> objProcedurePaymentsList =
            serializer.Deserialize<List<ProcedurePayments>>(Request.Form["procedurePaymentsList"]);
        List<ProcedureAdjustments> objProcedureAdjustmentsList =
            serializer.Deserialize<List<ProcedureAdjustments>>(Request.Form["ProcedureAdjustmentList"]);
        ProcedureAdjustmentsDB objProcedureAdjustmentDb = new ProcedureAdjustmentsDB();
        ProcedurePaymentsDB objProcedurePaymentsDb = new ProcedurePaymentsDB();

        for (int i = 0; i < objProcedurePaymentsList.Count; i++)
        {
            objProcedurePaymentsList[i].CreatedById = Convert.ToInt64(Profile.UserId);
            objProcedurePaymentsList[i].CreatedDate = DateTime.Now;
            Int64 ProcedurePaymentId = objProcedurePaymentsDb.Add(objProcedurePaymentsList[i]);

            for (int j = 0; j < objProcedureAdjustmentsList.Count; j++)
            {
                if (objProcedureAdjustmentsList[j].ProcedurePaymentsId == objProcedurePaymentsList[i].ClaimChargesId)
                {
                    objProcedureAdjustmentsList[j].ProcedurePaymentsId = ProcedurePaymentId;
                    objProcedureAdjustmentsList[j].CreatedById = Convert.ToInt64(Profile.UserId);
                    objProcedureAdjustmentsList[j].CreatedDate = DateTime.Now;
                    objProcedureAdjustmentDb.Add(objProcedureAdjustmentsList[j]);

                }
            }
        }
    }
}







