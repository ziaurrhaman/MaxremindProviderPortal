using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using ProviderBillingPortal;

public partial class ProviderPortal_Chat_ChatClientSupportHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //ChatDB db = new ChatDB();
        //long UserId = Convert.ToInt64(Request.Form["UserId"].ToString());
        //long PracticeId= Convert.ToInt64(Request.Form["PracticeId"].ToString());
        //string Message = Request.Form["Message"].ToString();
        //int rows = db.AddMessage(PracticeId, UserId, Message, DateTime.Now);
        DataChatRptGet();

    }

    public void DataChatRptGet()
    {

        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(@"SELECT [UserId],Message From CustomerSupportChat", connection))
            {
                // Make sure the command object does not already have
                // a notification object associated with it.
                command.Notification = null;

                SqlDependency dependency = new SqlDependency(command);
                dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                var listCus = reader.Cast<IDataRecord>()
                        .Select(x => new
                        {
                            UserId = Convert.ToInt32(x["UserId"]),
                            Message = x["Message"].ToString(),

                        }).ToList();
                rpt.DataSource = listCus;
                rpt.DataBind();
            }
        }
    }

    private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
        ChatHub.Show();
    }


}