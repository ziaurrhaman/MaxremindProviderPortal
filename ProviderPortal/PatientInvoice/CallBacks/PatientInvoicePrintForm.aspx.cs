using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientInvoice_CallBacks_PatientInvoicePrintForm : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        #region variable_define
        string RandomPageStr = "";
        int iCounter = 9;
        float fBalanceDue = 0;
        float fBalanceDue1 = 0;
        float fBalanceDue2 = 0;
        float lastpaid = 0;
        int RowsPerPage = 7;
        int PageNumber = 0;
        int count = 0;
        string totalbal = "";
        //............ 
        int firstPageRows = 0;
        int MultiPageRows = 0;
        int eachRowsCount = 0;
        bool isFirstPageComplete = false;
        bool isMultiplePageComplete = false;
        int MaxFirspageRows = 15;
        int MaxMultipageRows = 26;
        bool insertHeader = true;
        bool lastMultiPage = false;
        string PR_Pri = "";
        int countclaimnumber = 0;
        string CodedesPPA = "";
        //...........
        #endregion

        #region request

        //hdnPracticeId.Value = Profile.PracticeId.ToString();

        if (Request.Form["Action"] == "InvoicesFiles")
        {
            //InvoicesFilter();
        }



        if (Request.Form["Action"] == "UpdateIsEmailTo")
        {
            //UpdateIsEmailTo();
            //InvoicesFilter();
        }

        if (Request.QueryString["patientid"] != null)
        {


            string sPatientids = Request.QueryString["PatientId"].ToString();
            sPatientids = sPatientids.TrimEnd(',');
            string Type = Request.QueryString["Type1"];

            DataTable dtInvoiceDetail = null;

            DataTable dtPatientDetail = null;
            DataTable dtTotal = null;

            PatientInvoiceDB objInvoiceDB = new PatientInvoiceDB();

            DataSet dsPatientInvoices = objInvoiceDB.GetInvoiceData(Profile.PracticeId, sPatientids, Type);
            // DataSet dsPatientInvoices = objInvoiceDB.Tempinvoicefun();
            dtPatientDetail = dsPatientInvoices.Tables[0];
            dtInvoiceDetail = dsPatientInvoices.Tables[1];
            dtTotal = dsPatientInvoices.Tables[4];
            //Patient & Service provider info
            totalbal = dtTotal.Rows[0]["BalanceDue"].ToString();
            spPatientName.InnerText = dtPatientDetail.Rows[0]["patientName"].ToString();
            if (dtPatientDetail.Rows[0]["patientAddress"].ToString() == "No Address")
            { spPatientAddress.InnerText = "";}
            else { spPatientAddress.InnerText = dtPatientDetail.Rows[0]["patientAddress"].ToString(); }
            if (dtPatientDetail.Rows[0]["patientZip"].ToString() == "00000") { spPatientZip.InnerText = ""; }
            else { 
            spPatientZip.InnerText = dtPatientDetail.Rows[0]["patientCity"].ToString() + ", " +
                                     dtPatientDetail.Rows[0]["patientState"].ToString() + ", " +
                                     dtPatientDetail.Rows[0]["patientZip"].ToString();
            }
            spServiceProviderName.InnerText = dtPatientDetail.Rows[0]["practiceName"].ToString();
            spServiceProviderAddress.InnerText = dtPatientDetail.Rows[0]["practiceAddress"].ToString();
            spServiceProviderZip.InnerText = dtPatientDetail.Rows[0]["practiceCity"].ToString() + ", " +
                                             dtPatientDetail.Rows[0]["practiceState"].ToString() + ", " +
                                             dtPatientDetail.Rows[0]["practiceZip"].ToString();

            spServiceProviderNameL.InnerText = dtPatientDetail.Rows[0]["practiceName"].ToString();
            spServiceProviderAddressL.InnerText = dtPatientDetail.Rows[0]["practiceAddress"].ToString();
            spServiceProviderZipL.InnerText = dtPatientDetail.Rows[0]["practiceCity"].ToString() + ", " +
                                              dtPatientDetail.Rows[0]["practiceState"].ToString() + ", " +
                                              dtPatientDetail.Rows[0]["practiceZip"].ToString();

            spServiceProviderNameLL.InnerText = dtPatientDetail.Rows[0]["practiceName"].ToString();
            spServiceProviderAddressLL.InnerText = dtPatientDetail.Rows[0]["practiceAddress"].ToString();
            spServiceProviderZipLL.InnerText = dtPatientDetail.Rows[0]["practiceCity"].ToString() + ", " +
                                               dtPatientDetail.Rows[0]["practiceState"].ToString() + ", " +
                                               dtPatientDetail.Rows[0]["practiceZip"].ToString();
            if (Profile.PracticeId == 1000 || Profile.PracticeId == 1010)
            {
                spnOtherInfo.InnerText = "Payments can be made online at";
                Spanother2.InnerText = " www.texendocrine.com";

            }


            spACCT.InnerText = dtPatientDetail.Rows[0]["PatientId"].ToString();

            spAccG.InnerText = dtPatientDetail.Rows[0]["PatientId"].ToString();

            spStatementDate.InnerText = DateTime.Now.ToShortDateString();

            spStatementDateG.InnerText = DateTime.Now.ToShortDateString();

            string locationName = "";
            string providerName = "";



            int innerRowsCount = 0;
            countclaimnumber = dtInvoiceDetail.Rows.Count;
            foreach (DataRow dr in dtInvoiceDetail.Rows)
            {
                float patResp = 0;
                float adjamount = 0;

                if (!(String.IsNullOrEmpty(dr["PatientResp"].ToString()) || dr["PatientResp"].ToString() != "0.00"))
                {
                    patResp = float.Parse(dr["PatientResp"].ToString());
                    adjamount = float.Parse(dr["TotalCharges"].ToString()) -
                                (patResp + float.Parse(dr["PaidAmount"].ToString()));
                }
                else if (!String.IsNullOrEmpty(dr["AllowedAmount"].ToString()) &&
                         dr["AllowedAmount"].ToString() != null &&
                    float.Parse(dr["AllowedAmount"].ToString()) > 0
                    )
                {
                    patResp = float.Parse(dr["AllowedAmount"].ToString()) - float.Parse(dr["PaidAmount"].ToString());
                    adjamount = float.Parse(dr["TotalCharges"].ToString()) -
                                (patResp + float.Parse(dr["PaidAmount"].ToString()));
                }
                // start changes added Syed Sajid Ali 7 jan 2020
                else if (dr["PaidAmount"].ToString() == dr["PatPaidAmount"].ToString())
                {
                    patResp = float.Parse(dr["TotalCharges"].ToString()) -
                               (float.Parse(dr["PaidAmount"].ToString()));
                    adjamount = 0;
                }
                //ended changes added Syed Sajid Ali 7 jan 2020
                else
                {
                    patResp = float.Parse(dr["TotalCharges"].ToString()) -
                              (float.Parse(dr["PaidAmount"].ToString()) + float.Parse(dr["AdjustedAmount"].ToString()));
                    adjamount = float.Parse(dr["TotalCharges"].ToString()) -
                                (patResp + float.Parse(dr["PaidAmount"].ToString()));

                }
        #endregion
                /*
                 * start Multipage Print View
                 */

                count = dr.Table.Rows.IndexOf(dr);


                #region firstPage



                if (firstPageRows >= MaxFirspageRows && isFirstPageComplete == false)
                {
                    ltStatementTable.Text += RandomPageStr;
                    isFirstPageComplete = true;
                    spTotalBalance.InnerText = "$" + fBalanceDue1.ToString("0.00");
                    spAmountDueNow.InnerText = "$" + fBalanceDue1.ToString("0.00");
                    RandomPageStr = "";
                    fBalanceDue2 = fBalanceDue1;
                    fBalanceDue += fBalanceDue1;
                    fBalanceDue1 = 0;
                    PageNumber++;

                }

                #endregion

                #region MoreThanOnePage

                if (isFirstPageComplete == true)//  when first page is finished than enter in this block
                {

                    if (isMultiplePageComplete == false)
                    {

                    }

                    if (isMultiplePageComplete == true)
                    {
                        #region footerDesign

                        /*
                           * footer  Page start
                           */
                        fBalanceDue2 = fBalanceDue;
                        fBalanceDue += fBalanceDue1;
                        RandomPageStr += "</tbody></table>" +
                                         "<table style='margin-bottom:50px;width:100%;'><tbody>" +
                                         "<tr><td style='width:50%;'>" +
                                         "<table style='height:80px;width:100%;border:1px solid;' class='MessBord'> " +
                                         "<tr style='text-align:center;'><th>Message</th></tr>" +
                                         "<tr style='text-align:center;'><td></td></tr>" +
                                         "<tr style='text-align:center;'><td></td></tr>" +
                                         "</table> " +
                                         "</td><td style='width:50%;'>" +
                                         "<table style='width:100%;height:80px;' class='BlnBord'>" +
                                         "<tr style=''><th style='border:1px solid;' >Balance This Page</th><th style='border:1px solid;'>" +
                                         "$" + fBalanceDue1.ToString("0.00") + "</th></tr>" +
                                         "<tr style=''><th style='border:1px solid;'>Balance Carry Forward</th><th style='border:1px solid;'>" +
                                         "$" + fBalanceDue2.ToString("0.00") + "</th></tr>" +
                                         "<tr style=''><th style='border:1px solid;'>Total Amount Due</th><th style='border:1px solid;'>" +
                                         "<span  runat='server'>" + "$" + fBalanceDue.ToString("0.00") + "</span></th></tr>" +
                                         "</table>" +
                                         "</td></tr>" +
                                         "</tbody></table></div>" +
                                          "<script> $('.t1').text(" + fBalanceDue + ");</script>";
                        /*
                         * footer  Page end
                         */

                        ltrRandomInfo.Text += RandomPageStr;
                        //fBalanceDue2 = fBalanceDue1;

                        RandomPageStr = "";
                        fBalanceDue1 = 0;
                        #endregion
                        isMultiplePageComplete = false;
                        lastMultiPage = false;
                        insertHeader = true;
                    }
                    if (insertHeader == true)
                    {

                        #region header design
                        /*
                         * Header Page Start
                         */

                        PageNumber++;
                        //var PageCount = PageNumber;
                        RandomPageStr += @"  
                        
                            <div class='pageBreak'  style=' font-family: arial; top:2px;position:relative; page-break-after: always;page-break-inside: avoid;'>
                            <table style='font-family: arial; width:100%;'> <tr><td> 
                            <div> <hr> </div>
                            </td</tr></table>
                            <table style='border:1px solid; width:100%;height:60px;margin-bottom:10px;'>
                           
                            <tr><th style='border-right:1px solid'> Statement ID</th><th style='border-right:1px solid'> Statement Date</th> <th>Total Amount Due</th> </tr>
                            <tr><th style='border-right:1px solid'>" + spACCT.InnerText + @"</th><th style='border-right:1px solid'>" + spStatementDate.InnerText + @"</th><th><span runat='server' class='A'>" + "$" + Convert.ToDouble(totalbal).ToString("0.00") + "</span>" +
                            @"</th></tr>
                           
                            </table>                          
                            <table>
                            <tbody style='font-size:12px;'>
                            <tr style='text-align:left;' ><th style='font-weight:800;'>Sent To:</th><th style='Padding-left:130px;font-weight:800;'>Remit To:</th></tr>
                            <tr style=''><th style='text-align:left;'>&nbsp;&nbsp;&nbsp;&nbsp;" + spPatientName.InnerText + @"</th><th style='text-align:left;Padding-left:135px;'>&nbsp;&nbsp;&nbsp;&nbsp;" +
                            spServiceProviderNameL.InnerText + @"</th></tr>
                            <tr style=''><td >&nbsp;&nbsp;&nbsp;&nbsp;" + spPatientAddress.InnerText + @"</td><td style='Padding-left:135px;'>&nbsp;&nbsp;&nbsp;&nbsp;" +
                            spServiceProviderAddressL.InnerText + @"</td></tr>
                            <tr style=''><td >&nbsp;&nbsp;&nbsp;&nbsp;" + spPatientZip.InnerText + @"</td><td style='Padding-left:135px;'>&nbsp;&nbsp;&nbsp;&nbsp;" +
                            spServiceProviderZipL.InnerText + @"</td></tr></table>
                            <table style='width:100%;'><tr><td>
                            <div class='backTest' style='width:50%;background-color:black;height:20px;color:white;padding-left:10px;padding-top:5px; margin-top: 10px;  margin-bottom:20px;'>
                             page " + PageNumber + " of " + "<span runat='server' class='totalpages'>2</span></div></td></tr>" +
                                    @"</tbody>
                                    </table>" +
                            @"
                            <table style='width:100%;'>
                            <tr><tH >STATEMENT</tH></tr>
                            </table>
                            <table cellspacing='1' cellpadding='0'  class='StatementTable'>
                            <thead>
                            <tr>
                            <th style='width:10%;background-color:lightgray;'>DOS</th>
                            <th style='width:15%;background-color:lightgray;'>Provider</th>
                            <th style='width:30%;background-color:lightgray;'>Service Description</th>
                            <th style='width:10%;background-color:lightgray;'>Allowed</th>
                            <th style='width:10%;background-color:lightgray;'>Paid</th>                                
                            <th style='width:10%;background-color:lightgray;'>Adjusted</th>
                            <th style='width:10%;background-color:lightgray;'>Balance</th>                                
                            </tr>
                            </thead>
                            <tbody>
                            ";
                        /*
                         * End Header Page
                         */
                        #endregion
                        insertHeader = false;
                    }
                    if (MultiPageRows >= MaxMultipageRows)
                    {
                        MultiPageRows = 0;
                        isMultiplePageComplete = true;
                        lastMultiPage = true;
                    }
                }
                #endregion

                #region common

                #region add LocationRows
                if (locationName != dr["locationName"].ToString())
                {
                    locationName = dr["locationName"].ToString();
                    providerName = dr["ServiceProviderName"].ToString();
                    //ltrRandomInfo.Text
                    RandomPageStr += "<tr>" +
                                     "<td></td>" +
                                     "<td></td>" +
                                     "<td style='font-weight:bold; font-size:10px; padding-left:2px;'> Location:  " +
                                     dr["locationName"].ToString() + "</td>" +
                                     "<td style='text-align:center;'></td>" +
                                     "<td style='text-align:center;'></td>" +
                                     "<td style='text-align:center;'></td>" +
                                     "<td style='text-align:center;'></td>" +
                                     "</tr>";

                    if (isFirstPageComplete == false)
                    {
                        firstPageRows++;

                    }
                    else
                    {
                        MultiPageRows++;
                    }
                }
                #endregion

                #region patient payment detail
                string paidA;
                int SCEPaidAmount = 0;
                DataSet dsInvoiceAdjustments = objInvoiceDB.GetInvoiceAdjustments(Profile.PracticeId, sPatientids,
                    Int64.Parse(dr["ClaimId"].ToString()), Int64.Parse(dr["ClaimChargesId"].ToString()));
                if (String.IsNullOrEmpty(float.Parse(dr["PaidAmount"].ToString()).ToString("0.00")))
                {
                    paidA = "0";
                }
                else
                {
                    paidA = float.Parse(dr["PaidAmount"].ToString()).ToString("0.00");
                }

                lastpaid = float.Parse(paidA);
                DataTable dtInvoiceAdjustments = dsInvoiceAdjustments.Tables[0];

                if (dtInvoiceAdjustments.Rows.Count > 0)
                {
                    //ltrRandomInfo.Text
                    //Row 1
                    RandomPageStr += "<tr>" +
                                     "<td style='text-align:center; font-weight:bold;'>" +
                                     dr["DOS"].ToString() + "</td>" +
                                     "<td style='text-align:center;'>" +
                                     dr["ServiceProviderName"].ToString() + "</td>" +
                                     "<td style='padding-left:2px;'>" + dr["CPTdescription"].ToString() +
                                     "</td>" +
                                     "<td style='text-align:center;' class='chargescolumntd'>" + "$" +
                                     float.Parse(dr["AllowedAmount"].ToString()).ToString("0.00") + "</td>" +
                                     "<td style='text-align:center;'>" + "$" + paidA + "</td>" +
                                     "<td style='text-align:center;'>" + "$" +
                                     float.Parse(dr["AdjustedAmount"].ToString()).ToString("0.00") +
                                     "</td>" +
                                     "<td style='text-align:center;'>" + "$" +
                                     float.Parse(dr["BalanceDue"].ToString()).ToString("0.00") + "</td>" +
                                     "</tr>";
                    if (isFirstPageComplete == false)
                    {
                        firstPageRows++;
                    }
                    else
                    {
                        MultiPageRows++;
                    }
                }
                else if (float.Parse(dr["PaidAmount"].ToString()).ToString("0.00") == "0.00")
                {
                    //ltrRandomInfo.Text
                    RandomPageStr += "<tr>" +
                                     "<td style='text-align:center; font-weight:bold;'>" +
                                     dr["DOS"].ToString() + "</td>" +
                                     "<td style='text-align:center;'>" +
                                     dr["ServiceProviderName"].ToString() + "</td>" +
                                     "<td style='padding-left:2px;'>" + dr["CPTdescription"].ToString() +
                                     "</td>" +
                                     "<td style='text-align:center;'class='chargescolumntd'>" + "$" +
                                     float.Parse(dr["AllowedAmount"].ToString()).ToString("0.00") + "</td>" +
                                     "<td style='text-align:center;'>" + "$" +
                                     float.Parse(dr["PaidAmount"].ToString()).ToString("0.00") + "</td>" +
                                     "<td style='text-align:center;'>" + "$" + adjamount.ToString("0.00") +
                                     "</td>" +
                                     "<td style='text-align:center;'>" + "$" + float.Parse(dr["BalanceDue"].ToString()) +
                                     "</td>" +
                                     "</tr>";
                    if (isFirstPageComplete == false)
                    {
                        firstPageRows++;
                    }
                    else
                    {
                        MultiPageRows++;
                    }
                }
                else
                {
                    //ltrRandomInfo.Text
                    //Row 2
                    RandomPageStr += "<tr>" +
                                     "<td style='text-align:center; font-weight:bold;'>" +
                                     dr["DOS"].ToString() + "</td>" +
                                     "<td style='text-align:center;'>" +
                                     dr["ServiceProviderName"].ToString() + "</td>" +
                                     "<td style='padding-left:2px;'>" + dr["CPTdescription"].ToString() +
                                     "</td>" +
                                     "<td style='text-align:center;'Class='chargescolumntd'>" + "$" +
                                     float.Parse(dr["AllowedAmount"].ToString()).ToString("0.00") + "</td>" +
                                     "<td style='text-align:center;'>" + "$" +
                                     float.Parse(dr["PaidAmount"].ToString()).ToString("0.00") + "</td>" +
                                     "<td style='text-align:center;'>" + "$" + adjamount.ToString("0.00") +
                                     "</td>" +
                                     "<td style='text-align:center;'>" + "$" + patResp.ToString("0.00") +
                                     "</td>" +
                                     "</tr>";
                    if (isFirstPageComplete == false)
                    {
                        firstPageRows++;
                    }
                    else
                    {
                        MultiPageRows++;
                    }
                }
                #endregion
                //Row 3
                string CheckPR45 = "";
                int countPat = 0;
                int countSec = 0;
                int countLoop = 0;
                string ClaimChargesId = "";
                if (dtInvoiceAdjustments.Rows.Count == 0)
                {


                    string patientpayment = float.Parse(dr["PatPaidAmount"].ToString()).ToString("0.00");
                    if (float.Parse(patientpayment) > 0 && dr["insuranceid"].ToString() == "0")
                    {
                        RandomPageStr += "<tr >" +
                                         "<td></td>" +
                                         "<td></td>" +
                                         "<td style='padding-left:4px;'>" +
                                         @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + "Patient Responsibility" + "</td><td style='border:none;font-size:10px;'>" + float.Parse(dr["TotalCharges"].ToString()).ToString("0.00") + @"</td></tr>
                 <tr><td style='border:none;font-size:10px;'> Patient Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["PatPaidAmount"].ToString()) + @"</td></tr>
                 <tr style='height:10px;'><td style='border:none'><hr/></td><td style='border:none'><hr style='float:left; width:20%'/></td></tr>
                 <tr style='height:10px;'><td style='border:none;font-size:10px;'>" + "Due Amt." + "</td><td style='border:none;font-size:10px;'>" +
                      (float.Parse(dr["TotalCharges"].ToString()) - float.Parse(dr["PatPaidAmount"].ToString())).ToString("0.00") + @"</td></tr>
                 </table>" +

                                         "</td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'> </td>" +
                                         "</tr>";
                    }
                }
                int count_Pri_SEC_PA = 0;
                int countPR45 = 0;
                int PRIPAIDAMOUNTCount = 0;
                foreach (DataRow drAdj in dtInvoiceAdjustments.Rows)
                {


                    string ppp = dr["PaidAmount"].ToString();

                    #region startAdjustment PR




                    DataTable dtPriPR = dsInvoiceAdjustments.Tables[1];
                    PR_Pri = dtPriPR.Rows[0][0].ToString();
                    //Row 4

                    // Checking Sec SumofPR 
                    //If SumofPR = Balance then go to region  PriAndSECPAIDAMOUNT_SEC also PR 
                    DataTable dtSecPRS = dsInvoiceAdjustments.Tables[1];

                    double sumofSECPR = 0.00;
                    string PrimaryPR = "";
                    string AdjustedAmont = "";
                    int CountPrimaryPr = 0;

                    for (int i = 0; i < dtSecPRS.Rows.Count; i++)
                    {

                        if (dtSecPRS.Columns.Contains("AdjustedAmount"))
                        {



                            PrimaryPR = dsInvoiceAdjustments.Tables[1].Rows[i]["PrimaryPR"].ToString();

                            AdjustedAmont = dsInvoiceAdjustments.Tables[1].Rows[i]["AdjustedAmount"].ToString();

                            if (PrimaryPR == "SEC")
                            {


                                sumofSECPR += Convert.ToDouble(AdjustedAmont);


                            }
                            else
                            {
                                CountPrimaryPr++;
                            }
                        }

                    }
                    //Case 1
                    //start changes added by ali imran 17 june 2019 {teamperaraly fixed need to view in detail} 
                    #region  Pri_SEC_PAT_PAIDAMOUNT_stillBalanceDue

                    double BD_Pri_SEC_PAT = Math.Round(sumofSECPR - float.Parse(dr["PatPaidAmount"].ToString()), 2);

                    var aaa = dr["PatPaidAmount"].ToString();

                    if (float.Parse(dr["SecPaidAmount"].ToString()) > 0 && float.Parse(dr["PriInsPaidAmount"].ToString()) > 0 && double.Parse(dr["BalanceDue"].ToString()) == BD_Pri_SEC_PAT && drAdj["paymentsource"].ToString() == "SEC" && float.Parse(dr["PatPaidAmount"].ToString()) > 0)
                    {
                        count_Pri_SEC_PA++;
                        RandomPageStr += "<tr >" +
                                                 "<td></td>" +
                                                 "<td></td>" +
                                                 "<td style='padding-left:4px;'>" +
                                                 @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + drAdj["CodeDescription"].ToString() +
                 '=' + "</td><td style='border:none;font-size:10px;'>" + '$' + float.Parse(drAdj["AdjustedAmount"].ToString()).ToString("0.00") + @"</td></tr>
               
               <tr><td style='border:none;font-size:10px;'> Patient Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["PatPaidAmount"].ToString()) + @"</td></tr>
                 <tr style='height:10px;'><td style='border:none'><hr/></td><td style='border:none'><hr style='float:left; width:20%'/></td></tr>
                 <tr style='height:10px;'><td style='border:none;font-size:10px;'>" + "Due Amt." + "</td><td style='border:none;font-size:10px;'>" +
                        BD_Pri_SEC_PAT.ToString("0.00") + @"</td></tr>

                 </table>" +

                                                 "</td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'> </td>" +
                                                 "</tr>";

                        if (dtInvoiceAdjustments.Rows.Count == 2 && count_Pri_SEC_PA == 2)
                        {
                            RandomPageStr += "<tr >" +
                                                 "<td></td>" +
                                                 "<td></td>" +
                                                 "<td style='padding-left:4px;'>" +
                                                 @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + "Patient Paid" +
                 '=' + "</td><td style='border:none;font-size:10px;'>-" + '$' + float.Parse(dr["PatPaidAmount"].ToString()).ToString("0.00") + @"</td></tr>
                <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + "<hr/>" +
                   "</td><td style='border:none;font-size:10px;'>" + "<hr style='float:left; width:20%'/>" + @"</td></tr>
                <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + "Due Amt." +
                 '=' + "</td><td style='border:none;font-size:10px;'>" + '$' + BD_Pri_SEC_PAT + @"</td></tr>
              
                 </table>" +

                                                 "</td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'> </td>" +
                                                 "</tr>";


                        }


                    }



                    #endregion

                    //Case 2
                    #region  SECPaidAmount>0 AndPrimaryPaid <=0 and ReasonCode=253
                    //Row 4
                    else if (float.Parse(dr["SecPaidAmount"].ToString()) > 0 && float.Parse(dr["PriInsPaidAmount"].ToString()) == 0 && double.Parse(dr["BalanceDue"].ToString()) != sumofSECPR && countSec == 0 && sumofSECPR != 0.0)
                    {
                        string CodesDes = "";
                        double a = sumofSECPR;
                        // PR_Pri=dtPriPR.Rows[1]["AdjustedAmount"].ToString();
                        decimal dd = 0;
                        string AdjAmt = dsInvoiceAdjustments.Tables[1].Rows[0]["AdjustedAmount"].ToString();
                        string PriSrc = dsInvoiceAdjustments.Tables[1].Rows[0]["PrimaryPR"].ToString();
                        if (AdjAmt != "" && PriSrc == "PRI")
                        {
                            dd = dtPriPR.AsEnumerable().Where(data => data.Field<string>("PrimaryPR") == "PRI").Select(data => data.Field<decimal>("AdjustedAmount")).Single();
                        }
                        decimal Secondadjustment = Convert.ToDecimal(dsInvoiceAdjustments.Tables[2].Rows[0]["AdjustedAmount"].ToString());
                        PR_Pri = Convert.ToString(dd - Secondadjustment);
                        string dueamount = "";
                        string literalPat = "";
                        if (float.Parse(dr["PatPaidAmount"].ToString()) > 0)
                        {
                            literalPat = "<tr><td style='border:none;font-size:10px;'> Pat Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["PatPaidAmount"].ToString()) + @"</td></tr>";
                            dueamount = (float.Parse(PR_Pri) - float.Parse(dr["SecPaidAmount"].ToString()) - float.Parse(dr["PatPaidAmount"].ToString())).ToString("0.00");
                        }
                        else
                        {
                            dueamount = (float.Parse(PR_Pri) - float.Parse(dr["SecPaidAmount"].ToString())).ToString("0.00");

                        }




                        CodesDes = dtPriPR.Rows[0]["CodeDescription"].ToString();


                        countSec++;
                        RandomPageStr += "<tr >" +
                                         "<td></td>" +
                                         "<td></td>" +
                                         "<td style='padding-left:4px;'>" +
                                         @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + CodesDes + "</td><td style='border:none;font-size:10px;'>" + float.Parse(PR_Pri.ToString()).ToString("0.00") + @"</td></tr>
                 <tr><td style='border:none;font-size:10px;'> Sec Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["SecPaidAmount"].ToString()) + @"</td></tr>" +

         literalPat

         + @"<tr style='height:10px;'><td style='border:none'><hr/></td><td style='border:none'><hr style='float:left; width:20%'/></td></tr>
                 <tr style='height:10px;'><td style='border:none;font-size:10px;'>" + "Due Amt." + "</td><td style='border:none;font-size:10px;'>" + dueamount + @"</td></tr>
                 </table>" +

                                         "</td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'> </td>" +
                                         "</tr>";

                        if (isFirstPageComplete == false)
                        {
                            firstPageRows += 6;

                        }
                        else
                        {
                            MultiPageRows += 6;
                        }
                    }


                    #endregion

                    //Case 3

                    #region  PriAndSECPAIDAMOUNT_SEC also PR

                    else if (float.Parse(dr["SecPaidAmount"].ToString()) > 0 && float.Parse(dr["PriInsPaidAmount"].ToString()) > 0 && double.Parse(dr["BalanceDue"].ToString()) == sumofSECPR)
                    {
                        if (CountPrimaryPr > 1)
                        {
                            #region  PriAndSECPAIDAMOUNT_SEC also PR if Primary PR Rows >1





                            if ((ClaimChargesId == drAdj["ClaimChargesId"].ToString()))
                            {
                                break;
                            }
                            if (!dsInvoiceAdjustments.Tables.Contains("table"))
                            {

                            }
                            else
                            {

                                if (!dsInvoiceAdjustments.Tables.Contains("table1"))
                                {

                                }
                                else
                                {


                                    string codedes = "";
                                    float pritotaladjustment = 0;
                                    for (int j = 0; j < dsInvoiceAdjustments.Tables[1].Rows.Count; j++)
                                    {
                                        string checkDisplay = "none";
                                        int checkRow = dsInvoiceAdjustments.Tables[1].Rows.Count;
                                        var a = dsInvoiceAdjustments.Tables[1].Rows[j]["PrimaryPR"].ToString();

                                        if (j == dsInvoiceAdjustments.Tables[1].Select("PrimaryPR='PRI'").Count() - 1)
                                        {
                                            checkDisplay = "block";
                                        }
                                        var temp2 = dsInvoiceAdjustments.Tables[1].Rows[j]["PrimaryPR"].ToString();
                                        if (dsInvoiceAdjustments.Tables[1].Rows[j]["PrimaryPR"].ToString() == "PRI" && countSec == 0)
                                        {

                                            codedes = dsInvoiceAdjustments.Tables[1].Rows[j]["CodeDescription"].ToString();
                                            PR_Pri = dsInvoiceAdjustments.Tables[1].Rows[j]["AdjustedAmount"].ToString();
                                            pritotaladjustment += float.Parse(PR_Pri.ToString());
                                            RandomPageStr += "<tr >" +
                                                    "<td></td>" +
                                                    "<td></td>" +
                                                    "<td style='padding-left:4px;'>" +
                                                    @"<table style='border-collapse: collapse' >
                 <tr>
                 <td style='width:50% ;border:none;font-size:10px;'>" + codedes +
                    '=' + "</td><td style='border:none;font-size:10px;'>" + '$' + float.Parse(PR_Pri.ToString()).ToString("0.00") + @"</td></tr>"
                                            + "</table>" +




                                            @"<table style='border-collapse: collapse ;display:" + checkDisplay + "' >" +
                                       "<tr style='height:10px;'>" +
                                       "<td style='width:50% ;border:none;font-size:10px;'>Sec Paid Amt.</td><td style='width:32% ;float:right;border:none;font-size:10px;'>-" + float.Parse(dr["SecPaidAmount"].ToString()) + "</td></tr>" +
                                       "<tr><td style='width:50% ;border:none;font-size:10px;'><hr style='float:left; width:150%'/></td></tr>" +
                      "<tr style='height:10px;'><td style='width:50% ;border:none;font-size:10px;'>" + "Due Amt." + "</td><td style='width:50% ;border:none;font-size:10px;'>" +
                           (pritotaladjustment - float.Parse(dr["SecPaidAmount"].ToString())).ToString("0.00") + @"</td></tr>"
                           + "</table>" +

                                                   "</td>" +



                                                   "<td style='text-align:center;'></td>" +
                                                   "<td style='text-align:center;'></td>" +
                                                   "<td style='text-align:center;'></td>" +
                                                   "<td style='text-align:center;'> </td>"
                                                   + "</tr>";

                                        }


                                    }






                                    countSec++;
                                    ClaimChargesId = dr["ClaimChargesId"].ToString();
                                    if (isFirstPageComplete == false)
                                    {
                                        firstPageRows += 6;

                                    }
                                    else
                                    {
                                        MultiPageRows += 6;
                                    }
                                }
                            }


                            #endregion
                        }
                        if (CountPrimaryPr == 1)
                        {
                            #region  PriAndSECPAIDAMOUNT_SEC also PR if Primary PR Rows ==1

                            if ((ClaimChargesId == drAdj["ClaimChargesId"].ToString()))
                            {
                                break;
                            }
                            if (!dsInvoiceAdjustments.Tables.Contains("table"))
                            {

                            }
                            else
                            {

                                if (!dsInvoiceAdjustments.Tables.Contains("table1"))
                                {

                                }
                                else
                                {

                                    //                                    DataTable dt = dsInvoiceAdjustments.Tables[1];
                                    //                                    string codedescription = dt.Rows[1]["CodeDescription"].ToString();
                                    //                                    string AdjustedAmount = dt.Rows[1]["AdjustedAmount"].ToString();
                                    //                                    RandomPageStr += "<tr >" +
                                    //                                                 "<td></td>" +
                                    //                                                 "<td></td>" +
                                    //                                                 "<td style='padding-left:4px;'>" +
                                    //                                                 @"<table style='border-collapse: collapse' >
                                    //                 <tr  >
                                    //                 <td style='width:50% ;border:none;font-size:10px;'>" + codedescription + "</td><td style='border:none;font-size:10px;'>" + float.Parse(AdjustedAmount).ToString("0.00") + @"</td></tr>
                                    //                 <tr><td style='border:none;font-size:10px;'> Sec Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["SecPaidAmount"].ToString()) + @"</td></tr>
                                    //                
                                    //                 </table>" +

                                    //                                                 "</td>" +
                                    //                                                 "<td style='text-align:center;'></td>" +
                                    //                                                 "<td style='text-align:center;'></td>" +
                                    //                                                 "<td style='text-align:center;'></td>" +
                                    //                                                 "<td style='text-align:center;'> </td>" +
                                    //                                                 "</tr>";




                                    //Comment By Rizwan kharal 23Aug2019
                                    //New Requirments by Madam Saba 

                                    string codedes = "";
                                    float pritotaladjustment = 0;
                                    for (int j = 0; j < dsInvoiceAdjustments.Tables[1].Rows.Count; j++)
                                    {
                                        string checkDisplay = "block";
                                        int checkRow = dsInvoiceAdjustments.Tables[1].Rows.Count;

                                        var a = dsInvoiceAdjustments.Tables[1].Rows[j]["PrimaryPR"].ToString();

                                        if (dsInvoiceAdjustments.Tables[1].Rows[j]["PrimaryPR"].ToString() == "PRI" && countSec == 0)
                                        {
                                            codedes = dsInvoiceAdjustments.Tables[1].Rows[j]["CodeDescription"].ToString();
                                            var duedes = dsInvoiceAdjustments.Tables[1].Rows[j + 1]["CodeDescription"].ToString();
                                            if (duedes == "Deductible Amount")
                                            {
                                                duedes = "Deductible";

                                            }

                                            else if (duedes == "Co-payment Amount")
                                            {
                                                duedes = "Co-payment";
                                            }
                                            else if (duedes == "Co-Insurance Amount")
                                            {
                                                duedes = "Co-Insurance";
                                            }
                                            PR_Pri = dsInvoiceAdjustments.Tables[1].Rows[j]["AdjustedAmount"].ToString();
                                            pritotaladjustment += float.Parse(PR_Pri.ToString());
                                            RandomPageStr += "<tr >" +
                                                    "<td></td>" +
                                                    "<td></td>" +
                                                    "<td style='padding-left:4px;'>" +
                                                    @"<table style='border-collapse: collapse' >
                                                         <tr>
                                                         <td style='width:50% ;border:none;font-size:10px;'>" + codedes +
                    '=' + "</td><td style='border:none;font-size:10px;'>" + '$' + float.Parse(PR_Pri.ToString()).ToString("0.00") + @"</td></tr>"
                                            + "</table>" +




                                            @"<table style='border-collapse: collapse ;display:" + checkDisplay + "' >" +
                                       "<tr style='height:10px;'>" +
                                       "<td style='width:50% ;border:none;font-size:10px;'>Sec Paid Amt.</td><td style='width:32% ;float:left;margin-left:9px;border:none;font-size:10px;'>-" + float.Parse(dr["SecPaidAmount"].ToString()) + "</td></tr>" +
                                       "<tr><td style='width:50% ;border:none;font-size:10px;'><hr style='float:left; width:150%'/></td></tr>" +
                      "<tr style='height:10px;'><td style='width:50% ;border:none;font-size:10px;'>" + duedes + " - " + "Due Amt." + "</td><td style='width:50% ;border:none;font-size:10px;'>" +
                           (pritotaladjustment - float.Parse(dr["SecPaidAmount"].ToString())).ToString("0.00") + @"</td></tr>"
                           + "</table>" +

                                                   "</td>" +



                                                   "<td style='text-align:center;'></td>" +
                                                   "<td style='text-align:center;'></td>" +
                                                   "<td style='text-align:center;'></td>" +
                                                   "<td style='text-align:center;'> </td>"
                                                   + "</tr>";

                                        }


                                    }






                                    countSec++;
                                    ClaimChargesId = dr["ClaimChargesId"].ToString();
                                    if (isFirstPageComplete == false)
                                    {
                                        firstPageRows += 6;

                                    }
                                    else
                                    {
                                        MultiPageRows += 6;
                                    }
                                }
                            }
                        }

                            #endregion
                    }


                    #endregion

                    #region  PriAndSECPAIDAMOUNT
                    else if (float.Parse(dr["SecPaidAmount"].ToString()) > 0 && float.Parse(dr["PriInsPaidAmount"].ToString()) > 0 && float.Parse(dr["BalanceDue"].ToString()) == float.Parse(PR_Pri.ToString()))
                    {
                        if (!dsInvoiceAdjustments.Tables.Contains("table"))
                        {

                        }
                        else
                        {

                            if (!dsInvoiceAdjustments.Tables.Contains("table1"))
                            {

                            }
                            else
                            {




                                countSec++;
                                RandomPageStr += "<tr >" +
                                                 "<td></td>" +
                                                 "<td></td>" +
                                                 "<td style='padding-left:4px;'>" +
                                                 @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + drAdj["CodeDescription"].ToString() +
                 '=' + "</td><td style='border:none;font-size:10px;'>" + '$' + float.Parse(PR_Pri.ToString()).ToString("0.00") + @"</td></tr>
               
              
                 </table>" +

                                                 "</td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'> </td>" +
                                                 "</tr>";

                                if (isFirstPageComplete == false)
                                {
                                    firstPageRows += 6;

                                }
                                else
                                {
                                    MultiPageRows += 6;
                                }
                            }
                        }
                    }

                    #endregion

                    #region PATANDSECPAIDAMOUNT

                    else if (float.Parse(dr["PatPaidAmount"].ToString()) > 0 && countPat == 0 && float.Parse(dr["SecPaidAmount"].ToString()) > 0 && countSec == 0)
                    {
                        float due = 0;
                        due = float.Parse(drAdj["AdjustedAmount"].ToString()) - float.Parse(dr["PatPaidAmount"].ToString()) - float.Parse(dr["SecPaidAmount"].ToString());
                        countPat++;
                        float balance = float.Parse(dr["BalanceDue"].ToString());

                        if (due.ToString("0.00") == balance.ToString("0.00"))
                        {


                            RandomPageStr += "<tr >" +
                                             "<td></td>" +
                                             "<td></td>" +
                                             "<td style='padding-left:4px;'>" +
                                             @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + drAdj["CodeDescription"].ToString() + "</td><td style='border:none;font-size:10px;'>" + float.Parse(drAdj["AdjustedAmount"].ToString()).ToString("0.00") + @"</td></tr>
                 <tr><td style='border:none;font-size:10px;'> Patient Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["PatPaidAmount"].ToString()) + @"</td></tr>
                 <tr><td style='border:none;font-size:10px;'> Sec Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["SecPaidAmount"].ToString()) + @"</td></tr>
                 <tr style='height:10px;'><td style='border:none'><hr/></td><td style='border:none'><hr style='float:left; width:20%'/></td></tr>
                 <tr style='height:10px;'><td style='border:none;font-size:10px;'>" + "Due Amt." + "</td><td style='border:none;font-size:10px;'>" +
                            due.ToString("0.00") + @"</td></tr>
                 </table>" +

                                             "</td>" +
                                             "<td style='text-align:center;'></td>" +
                                             "<td style='text-align:center;'></td>" +
                                             "<td style='text-align:center;'></td>" +
                                             "<td style='text-align:center;'> </td>" +
                                             "</tr>";
                        }
                        else
                        {
                            due = float.Parse(drAdj["AdjustedAmount"].ToString()) - float.Parse(dr["PatPaidAmount"].ToString());
                            RandomPageStr += "<tr >" +
                                             "<td></td>" +
                                             "<td></td>" +
                                             "<td style='padding-left:4px;'>" +
                                             @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + drAdj["CodeDescription"].ToString() + "</td><td style='border:none;font-size:10px;'>" + float.Parse(drAdj["AdjustedAmount"].ToString()).ToString("0.00") + @"</td></tr>
                 <tr><td style='border:none;font-size:10px;'> Patient Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["PatPaidAmount"].ToString()) + @"</td></tr>
    
                 <tr style='height:10px;'><td style='border:none'><hr/></td><td style='border:none'><hr style='float:left; width:20%'/></td></tr>
                 <tr style='height:10px;'><td style='border:none;font-size:10px;'>" + "Due Amt." + "</td><td style='border:none;font-size:10px;'>" +
                            due.ToString("0.00") + @"</td></tr>
                 </table>" +

                                             "</td>" +
                                             "<td style='text-align:center;'></td>" +
                                             "<td style='text-align:center;'></td>" +
                                             "<td style='text-align:center;'></td>" +
                                             "<td style='text-align:center;'> </td>" +
                                             "</tr>";
                        }
                        if (isFirstPageComplete == false)
                        {
                            firstPageRows += 6;

                        }
                        else
                        {
                            MultiPageRows += 6;
                        }
                    }
                    #endregion
                    //Case 4
                    #region PATPAIDAMOUNT
                    else if (float.Parse(dr["PatPaidAmount"].ToString()) > 0 && countPat == 0)
                    {
                        CodedesPPA = drAdj["CodeDescription"].ToString();
                        float due = float.Parse(drAdj["AdjustedAmount"].ToString()) - float.Parse(dr["PatPaidAmount"].ToString());
                        countPat++;
                        RandomPageStr += "<tr >" +
                                         "<td></td>" +
                                         "<td></td>" +
                                         "<td style='padding-left:4px;'>" +
                                         @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + drAdj["CodeDescription"].ToString() + "</td><td style='border:none;font-size:10px;'>" + float.Parse(drAdj["AdjustedAmount"].ToString()).ToString("0.00") + @"</td></tr>
                 <tr><td style='border:none;font-size:10px;'> Patient Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["PatPaidAmount"].ToString()) + @"</td></tr>
                 <tr style='height:10px;'><td style='border:none'><hr/></td><td style='border:none'><hr style='float:left; width:20%'/></td></tr>
                 <tr style='height:10px;'><td style='border:none;font-size:10px;'>" + "Due Amt." + "</td><td style='border:none;font-size:10px;'>" +
                        due.ToString("0.00") + @"</td></tr>
                 </table>" +

                                         "</td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'></td>" +
                                         "<td style='text-align:center;'> </td>" +
                                         "</tr>";

                        if (isFirstPageComplete == false)
                        {
                            firstPageRows += 6;

                        }
                        else
                        {
                            MultiPageRows += 6;
                        }
                    }
                    #endregion


                    //Case 5
                    #region  SECPAIDAMOUNT
                    //Row 4
                    else if (float.Parse(dr["SecPaidAmount"].ToString()) > 0 && countSec == 0)
                    {


                        // Select("Where PrimaryPR='SEC'");


                        if (!dsInvoiceAdjustments.Tables.Contains("table"))
                        {

                        }

                            //When multiple Sec PR avaliable 

                        else if (dsInvoiceAdjustments.Tables[0].Rows.Count > 1)
                        {
                            if (dsInvoiceAdjustments.Tables[0].Rows.Count > 1 && SCEPaidAmount == 0)
                            {
                                for (int i = 0; i < dsInvoiceAdjustments.Tables[0].Rows.Count; i++)
                                {
                                    string codedescription = dsInvoiceAdjustments.Tables[0].Rows[i]["CodeDescription"].ToString();
                                    string AdjustedAmount = dsInvoiceAdjustments.Tables[0].Rows[i]["AdjustedAmount"].ToString();
                                    if (codedescription == "Deductible Amount")
                                    {
                                        RandomPageStr += "<tr Class=''>" +
                                                                          "<td></td>" +
                                                                          "<td></td>" +
                                                                          "<td style='padding-left:2px;'>" +
                                                                          codedescription + " = " +
                                                                          "$" + float.Parse(AdjustedAmount)
                                                                              .ToString("0.00") +
                                                                          "</td>" +
                                                                          "<td style='text-align:center;'></td>" +
                                                                          "<td style='text-align:center;'></td>" +
                                                                          "<td style='text-align:center;'></td>" +
                                                                          "<td style='text-align:center;'> </td>" +
                                                                          "</tr>";
                                        SCEPaidAmount++;
                                    }

                                }
                            }
                        }
                        else
                        {

                            if (!dsInvoiceAdjustments.Tables.Contains("table1"))
                            {

                            }
                            else
                            {

                                // DataTable dtPriPR = dsInvoiceAdjustments.Tables[1];
                                string CodesDes = "";
                                if (dtPriPR.Rows.Count > 1)
                                {
                                    //PR_Pri=dtPriPR.Rows[1]["AdjustedAmount"].ToString();
                                    decimal dd = 0;
                                    string AdjAmt = dsInvoiceAdjustments.Tables[1].Rows[0]["AdjustedAmount"].ToString();
                                    string PriSrc = dsInvoiceAdjustments.Tables[1].Rows[0]["PrimaryPR"].ToString();
                                    if (AdjAmt != "" && PriSrc == "PRI")
                                    {
                                        dd = dtPriPR.AsEnumerable().Where(data => data.Field<string>("PrimaryPR") == "PRI").Select(data => data.Field<decimal>("AdjustedAmount")).Single();
                                    }
                                    PR_Pri = dd.ToString();
                                    dtPriPR.Rows[1]["AdjustedAmount"].ToString();
                                    CodesDes = dtPriPR.Rows[1]["CodeDescription"].ToString();


                                }

                                else
                                {
                                    // PR_Pri=dtPriPR.Rows[1]["AdjustedAmount"].ToString();
                                    decimal dd = 0;
                                    string AdjAmt = dsInvoiceAdjustments.Tables[1].Rows[0]["AdjustedAmount"].ToString();
                                    string PriSrc = dsInvoiceAdjustments.Tables[1].Rows[0]["PrimaryPR"].ToString();
                                    if (AdjAmt != "" && PriSrc == "PRI")
                                    {
                                        dd = dtPriPR.AsEnumerable().Where(data => data.Field<string>("PrimaryPR") == "PRI").Select(data => data.Field<decimal>("AdjustedAmount")).Single();
                                    }
                                    PR_Pri = dd.ToString();
                                    CodesDes = dtPriPR.Rows[0]["CodeDescription"].ToString();
                                }

                                countSec++;
                                RandomPageStr += "<tr >" +
                                                 "<td></td>" +
                                                 "<td></td>" +
                                                 "<td style='padding-left:4px;'>" +
                                                 @"<table style='border-collapse: collapse' >
                 <tr  >
                 <td style='width:50% ;border:none;font-size:10px;'>" + CodesDes + "</td><td style='border:none;font-size:10px;'>" + float.Parse(PR_Pri.ToString()).ToString("0.00") + @"</td></tr>
                 <tr><td style='border:none;font-size:10px;'> Sec Paid Amt.</td><td style='border:none;font-size:10px;'>-" + float.Parse(dr["SecPaidAmount"].ToString()) + @"</td></tr>
                 <tr style='height:10px;'><td style='border:none'><hr/></td><td style='border:none'><hr style='float:left; width:20%'/></td></tr>
                 <tr style='height:10px;'><td style='border:none;font-size:10px;'>" + "Due Amt." + "</td><td style='border:none;font-size:10px;'>" + (float.Parse(PR_Pri) - float.Parse(dr["SecPaidAmount"].ToString())).ToString("0.00") + @"</td></tr>
                 </table>" +

                                                 "</td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'></td>" +
                                                 "<td style='text-align:center;'> </td>" +
                                                 "</tr>";

                                if (isFirstPageComplete == false)
                                {
                                    firstPageRows += 6;

                                }
                                else
                                {
                                    MultiPageRows += 6;
                                }
                            }
                        }
                    }
                    #endregion

                    //Case 6
                    #region PRIPAIDAMOUNT
                    else
                    {

                        if (PRIPAIDAMOUNTCount == 0)
                        {



                            string ClassPR45 = "";
                            // CheckPR45 = drAdj["CodeDescription"].ToString();
                            foreach (DataRow drAdj2 in dtInvoiceAdjustments.Rows)
                            {
                                //if(CheckPR45!=""){
                                CheckPR45 = drAdj2["CodeDescription"].ToString();
                                if (CheckPR45 == "PR 45") { break; }
                                //}


                            }

                            string CallBackPR45 = "";
                            if (!string.IsNullOrEmpty(Request.QueryString["PR45DivHideShow"]))
                            {
                                CallBackPR45 = Request.QueryString["PR45DivHideShow"].ToString();
                            }

                            if (CheckPR45 == "PR 45")
                            {
                                ClassPR45 = "ClassCheckPR45";
                                //lblPR45Check.Text = "True";

                            }

                            if (CallBackPR45 == "" && countPR45 == 0)
                            {

                                DataTable dtpayments = dsInvoiceAdjustments.Tables[3];
                                float paidamount = 0;
                                float paidamountpri = 0;
                                if (dtpayments.Rows.Count > 0)
                                {
                                    paidamountpri = float.Parse(dtpayments.Rows[0]["PaidAmount"].ToString());
                                }
                                if (dtpayments.Rows.Count > 1)
                                {
                                    paidamount = float.Parse(dtpayments.Rows[1]["PaidAmount"].ToString());
                                    paidamountpri = float.Parse(dtpayments.Rows[0]["PaidAmount"].ToString());
                                }
                                if ((paidamount == 0.00 || paidamount == 0) && (paidamountpri == 0.00 || paidamountpri == 0))
                                {
                                    DataTable dt = dsInvoiceAdjustments.Tables[1];
                                    if (dt.Rows.Count > 1)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            string codedescription = dt.Rows[i]["CodeDescription"].ToString();

                                            if (codedescription == "PR 45")
                                            {
                                                ClassPR45 = "ClassCheckPR45";
                                            }
                                            else
                                            {
                                                ClassPR45 = "";
                                            }
                                            string CD = dt.Rows[i]["CodeDescription"].ToString();
                                            if (CD != "PR 45") { ClassPR45 = ""; } else if (CD == "PR 45") { ClassPR45 = "ClassCheckPR45"; }
                                            string AdjustedAmount = dt.Rows[i]["AdjustedAmount"].ToString();
                                            RandomPageStr += "<tr Class='" + ClassPR45 + "'>" +
                                                                              "<td></td>" +
                                                                              "<td></td>" +
                                                                              "<td style='padding-left:2px;'>" +
                                                                              codedescription + " = " +
                                                                              "$" + float.Parse(AdjustedAmount)
                                                                                  .ToString("0.00") +
                                                                              "</td>" +
                                                                              "<td style='text-align:center;'></td>" +
                                                                              "<td style='text-align:center;'></td>" +
                                                                              "<td style='text-align:center;'></td>" +
                                                                              "<td style='text-align:center;'> </td>" +
                                                                              "</tr>";

                                            countPR45++;
                                        }

                                    }
                                    else
                                    {
                                        string CD = dt.Rows[0]["CodeDescription"].ToString();
                                        if (CD != "PR 45") { ClassPR45 = ""; } else if (CD == "PR 45") { ClassPR45 = "ClassCheckPR45"; }
                                        string codedescription = dt.Rows[0]["CodeDescription"].ToString();
                                        string AdjustedAmount = dt.Rows[0]["AdjustedAmount"].ToString();
                                        RandomPageStr += "<tr Class='" + ClassPR45 + "'>" +
                                                                          "<td></td>" +
                                                                          "<td></td>" +
                                                                          "<td style='padding-left:2px;'>" +
                                                                          codedescription + " = " +
                                                                          "$" + float.Parse(AdjustedAmount)
                                                                              .ToString("0.00") +
                                                                          "</td>" +
                                                                          "<td style='text-align:center;'></td>" +
                                                                          "<td style='text-align:center;'></td>" +
                                                                          "<td style='text-align:center;'></td>" +
                                                                          "<td style='text-align:center;'> </td>" +
                                                                          "</tr>";
                                    }

                                }
                                else
                                {

                                    DataTable SecPRSdt = dsInvoiceAdjustments.Tables[3];
                                    string Payments = "";
                                    if (SecPRSdt.Rows.Count > 1)
                                    {
                                        Payments = SecPRSdt.Rows[1]["PaidAmount"].ToString();
                                    }

                                    if (SecPRSdt.Rows.Count == 3)
                                    {
                                        Payments = SecPRSdt.Rows[2]["PaidAmount"].ToString();
                                    }


                                    if (Payments == "0.00" || Payments == "0.0000")
                                    {
                                        string CD = drAdj["CodeDescription"].ToString();
                                        if (CD != "PR 45") { ClassPR45 = ""; } else if (CD == "PR 45") { ClassPR45 = "ClassCheckPR45"; }
                                        RandomPageStr += "<tr Class='" + ClassPR45 + "'>" +
                                          "<td></td>" +
                                          "<td></td>" +
                                          "<td style='padding-left:2px;'>" +
                                          drAdj["CodeDescription"].ToString() + " = " +
                                          "$" + float.Parse(drAdj["AdjustedAmount"].ToString())
                                              .ToString("0.00") +
                                          "</td>" +
                                          "<td style='text-align:center;'></td>" +
                                          "<td style='text-align:center;'></td>" +
                                          "<td style='text-align:center;'></td>" +
                                          "<td style='text-align:center;'> </td>" +
                                          "</tr>";


                                    }
                                    else
                                    {


                                        //Using it when pri leaves multiple addjustment
                                        DataTable PRidt = dsInvoiceAdjustments.Tables[1];
                                        if (PRidt.Rows.Count > 1)
                                        {

                                            foreach (DataRow drAdj1 in PRidt.Rows)
                                            {

                                                string CD = drAdj1["CodeDescription"].ToString();
                                                if (CD != "PR 45") { ClassPR45 = ""; } else if (CD == "PR 45") { ClassPR45 = "ClassCheckPR45"; }
                                                if (CodedesPPA != CD)
                                                {
                                                    RandomPageStr += "<tr Class='" + ClassPR45 + "'>" +
                                                       "<td></td>" +
                                                       "<td></td>" +
                                                       "<td style='padding-left:2px;'>" +
                                                       drAdj1["CodeDescription"].ToString() + " = " +
                                                       "$" + float.Parse(drAdj1["AdjustedAmount"].ToString())
                                                           .ToString("0.00") +
                                                       "</td>" +
                                                       "<td style='text-align:center;'></td>" +
                                                       "<td style='text-align:center;'></td>" +
                                                       "<td style='text-align:center;'></td>" +
                                                       "<td style='text-align:center;'> </td>" +
                                                       "</tr>";

                                                }

                                            }

                                            PRIPAIDAMOUNTCount++;
                                        }
                                        else
                                        {
                                            string CD = PRidt.Rows[0]["CodeDescription"].ToString();
                                            if (CD != "PR 45") { ClassPR45 = ""; } else if (CD == "PR 45") { ClassPR45 = "ClassCheckPR45"; }

                                            RandomPageStr += "<tr Class='" + ClassPR45 + "'>" +
                                            "<td></td>" +
                                            "<td></td>" +
                                            "<td style='padding-left:2px;'>" +
                                            PRidt.Rows[0]["CodeDescription"].ToString() + " = " +
                                            "$" + float.Parse(PRidt.Rows[0]["AdjustedAmount"].ToString())
                                                .ToString("0.00") +
                                            "</td>" +
                                            "<td style='text-align:center;'></td>" +
                                            "<td style='text-align:center;'></td>" +
                                            "<td style='text-align:center;'></td>" +
                                            "<td style='text-align:center;'> </td>" +
                                            "</tr>";
                                        }





                                    }
                                }


                                if (isFirstPageComplete == false)
                                {
                                    firstPageRows++;
                                }
                                else
                                {
                                    MultiPageRows++;
                                }

                            }
                            else if (CallBackPR45 != "")
                            {
                                if (CallBackPR45 == "hidePR45" && CheckPR45 == "PR 45")
                                {

                                }
                                else
                                {
                                    string CD = drAdj["CodeDescription"].ToString();
                                    if (CD != "PR 45") { ClassPR45 = ""; } else if (CD == "PR 45") { ClassPR45 = "ClassCheckPR45"; }
                                    RandomPageStr += "<tr Class='" + ClassPR45 + "'>" +
                                                                     "<td></td>" +
                                                                     "<td></td>" +
                                                                     "<td style='padding-left:2px;'>" +
                                                                     drAdj["CodeDescription"].ToString() + " = " +
                                                                     "$" + float.Parse(drAdj["AdjustedAmount"].ToString())
                                                                         .ToString("0.00") +
                                                                     "</td>" +
                                                                     "<td style='text-align:center;'></td>" +
                                                                     "<td style='text-align:center;'></td>" +
                                                                     "<td style='text-align:center;'></td>" +
                                                                     "<td style='text-align:center;'> </td>" +
                                                                     "</tr>";

                                    if (isFirstPageComplete == false)
                                    {
                                        firstPageRows++;
                                    }
                                    else
                                    {
                                        MultiPageRows++;
                                    }
                                }
                            }



                        }
                    }

                    #endregion

                }

                //


                    #endregion
                //   fBalanceDue += patResp;


                fBalanceDue1 += float.Parse(dr["BalanceDue"].ToString());
                if (dr["InsuranceId"].ToString() == "0")
                {
                    spnMessage.InnerText = "Please update your insurance information with provider's office.";
                }



            }// table end rows dtInvoiceDetail

            #region if only first Page

            if (isFirstPageComplete == false)
            {

                fBalanceDue2 = fBalanceDue1;
                fBalanceDue += fBalanceDue1;

                ltStatementTable.Text += RandomPageStr;
                spTotalBalance.InnerText = "$" + fBalanceDue.ToString("0.00");
                spAmountDueNow.InnerText = "$" + fBalanceDue.ToString("0.00");
                PageNumber++;
                RandomPageStr = "";
                fBalanceDue1 = 0;


                if (countclaimnumber > 3)
                {
                    MaxFirspageRows = 11;
                }
                else
                {
                    MaxFirspageRows = 15;
                }

                for (int i = firstPageRows; i < MaxFirspageRows; i++)
                {
                    ltStatementTable.Text += "<tr>" +
                                             "<td></td>" +
                                             "<td></td>" +
                                             "<td></td>" +
                                             "<td></td>" +
                                             "<td></td>" +
                                             "<td></td>" +
                                             "<td></td>" +
                                             "</tr>";
                }
            }


            #endregion

            #region iflastPageIsNotComplete

            if ((isMultiplePageComplete == false || lastMultiPage == true) && isFirstPageComplete == true)
            {
                fBalanceDue2 = fBalanceDue;
                fBalanceDue += fBalanceDue1;

                for (int i = MultiPageRows; i <= MaxMultipageRows; i++)
                {
                    RandomPageStr += "<tr>" +
                                     "<td></td>" +
                                     "<td></td>" +
                                     "<td></td>" +
                                     "<td></td>" +
                                     "<td></td>" +
                                     "<td></td>" +
                                     "<td></td>" +
                                     "</tr>";
                }

                RandomPageStr += "</tbody></table>" +
                                 "<table style='margin-bottom:50px;width:100%;'><tbody>" +
                                 "<tr><td style='width:50%;'>" +
                                 "<table style='height:80px;width:100%;border:1px solid;' class='MessBord'> " +
                                 "<tr style='text-align:center;'><th>Message</th></tr>" +
                                 "<tr style='text-align:center;'><td></td></tr>" +
                                 "<tr style='text-align:center;'><td></td></tr>" +
                                 "</table> " +
                                 "</td><td style='width:50%;'>" +
                                 "<table style='width:100%;height:80px;' class='BlnBord'>" +
                                 "<tr style=''><th style='border:1px solid;' >Balance This Page</th><th style='border:1px solid;'>" +
                                 "$" + fBalanceDue1.ToString("0.00") + "</th></tr>" +
                                 "<tr style=''><th style='border:1px solid;'>Balance Carry Forward</th><th style='border:1px solid;'>" +
                                 "$" + fBalanceDue2.ToString("0.00") + "</th></tr>" +
                                 "<tr style=''><th style='border:1px solid;'>Total Amount Due</th><th style='border:1px solid;'> <span  runat='server'>" +
                                 "$" + fBalanceDue.ToString("0.00") + "</th></tr>" +
                                 "</table>" +
                                 "</td></tr>" +
                                 "</tbody></table></div>" +
                                  "<script> $('.t1').text(" + fBalanceDue + ");</script>";


                innerRowsCount = 0;
                if (count < RowsPerPage)
                {
                    ltrRandomInfo.Text += RandomPageStr;
                }
                else
                {
                    ltrRandomInfo.Text += RandomPageStr;
                }

                RandomPageStr = "";
                fBalanceDue1 = 0;
            }

            #endregion

            #region

            totalPage.Value = PageNumber.ToString();
            spPayThisAmount.InnerText = "$" + fBalanceDue.ToString("0.00");
            spCurrentBalanceG.InnerText = "$" + fBalanceDue.ToString("0.00");
            spTotalBalanceG.InnerText = "$" + fBalanceDue.ToString("0.00");
            spLastPaidAmount.InnerText = "$" + lastpaid.ToString("0.00");
            string phonenumber = "214-736-3209";
            if (Profile.PracticeId == 1010) { phonenumber = "214-547-7557"; }
            spBillingQuestions.InnerText =
                "For questions regarding this invoice, please call us at " + phonenumber + " Or email at BillingSupport@mremind.com";
            #endregion

                #endregion


        }
    }
}