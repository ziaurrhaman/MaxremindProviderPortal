<%@ WebHandler Language="C#" Class="ChatHandler" %>

using System;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Text;

public class ChatHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        //our code here
        if (context.Request.Form["Action"] != null)
        {
            string Action = context.Request.Form["Action"].ToString();
            if (Action == "SentMessage")
            {
                SentMessage(context);
            }else if (Action == "GetAll")
            {
                GetAll(context);
            }
        }
    }
    public void SentMessage(HttpContext context)
    {
        long? replymsgid = null;
        string username = context.Request.Form["username"];
        long userid = long.Parse(context.Request.Form["userid"]);
        long ticketid = long.Parse(context.Request.Form["ticketid"]);
        string message = context.Request.Form["message"];
        if (!string.IsNullOrEmpty( context.Request.Form["replymsgid"].ToString()))
            replymsgid = long.Parse(context.Request.Form["replymsgid"]);
        string messageid = context.Request.Form["messageid"];
        CustomerSupportQuriesDB dbm = new CustomerSupportQuriesDB();
        long rmessageid = dbm.SendMessage(userid, ticketid, userid, username, message, replymsgid);
        context.Response.Write(new JavaScriptSerializer().Serialize(
            new Status() { messageid = messageid.ToString(), rmessageid = rmessageid.ToString(), status = "success" }
            ));
        context.Response.ContentType = "json";
    }

    public void GetAll(HttpContext context)
    {
        long ticketid = long.Parse(context.Request.Form["ticketid"]);
        DataTable tb = new CustomerSupportQuriesDB().GetAllMessages(ticketid);
        string MsgsArray = GetJsonStringArray(tb);
        context.Response.Write(MsgsArray);
        context.Response.ContentType = "json";
    }

    public string GetJsonStringArray(DataTable tb)
    {
        JavaScriptSerializer serialize = new JavaScriptSerializer();
        serialize.MaxJsonLength = Int32.MaxValue;
        StringBuilder jsonstring = new StringBuilder();
        jsonstring.Append("[");
        foreach (DataRow row in tb.Rows)
        {
            Dictionary<string, object> Lrow =new Dictionary<string, object>();
            foreach (DataColumn col in tb.Columns)
            {
                Lrow.Add(col.ColumnName, row[col]);
            }
            jsonstring.Append(serialize.Serialize(Lrow));
            jsonstring.Append(",");
        }
        if (jsonstring.Length>1)
            jsonstring.Remove(jsonstring.Length - 1, 1);
        jsonstring.Append("]");
        return jsonstring.ToString();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
    private class Status
    {
        public string messageid { get; set; }
        public string rmessageid { get; set; }
        public string status { get; set; }
    }

}