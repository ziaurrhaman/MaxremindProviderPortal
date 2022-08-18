using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Controls_CallBacks_SubscriberSearchSaveHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
        Subscriber objSubscriber = objJavaScriptSerializer.Deserialize<Subscriber>(Request.Form["objSubscriber"]);

        SubscriberDB objSubscriberDB = new SubscriberDB();

        if (objSubscriber.SubscriberId == 0)
        {
            objSubscriber.PracticeId = Profile.PracticeId;
            objSubscriber.CreatedById = Profile.UserId;
            objSubscriber.CreatedDate = DateTime.Now;

            objSubscriberDB.Add(objSubscriber);
        }
        else
        {
            objSubscriber.ModifiedById = Profile.UserId;
            objSubscriber.ModifiedDate = DateTime.Now;
            objSubscriberDB.Update(objSubscriber);
        }


        long PracticeId = Profile.PracticeId;

        string firstName = Request.Form["firstName"];
        string lastName = Request.Form["lastName"];
        string subscriberGender = Request.Form["subscriberGender"];
        string subscriberDOB = Request.Form["subscriberDOB"];
        string subscriberAddress = Request.Form["subscriberAddress"];
        int pageNumber = int.Parse(Request.Form["pageNumber"].ToString());
        int rows = int.Parse(Request.Form["rows"].ToString());

        DataSet dsSubscriber = objSubscriberDB.GetBySearchCriteria(firstName, lastName, subscriberDOB, subscriberGender, subscriberAddress, PracticeId, rows, pageNumber);

        rptSubscriber.DataSource = dsSubscriber.Tables[0];
        rptSubscriber.DataBind();

        hdnSubscriberListCount.Text = dsSubscriber.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}