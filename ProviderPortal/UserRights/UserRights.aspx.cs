using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_UserRights_UserRights : System.Web.UI.Page
{
    private DataSet _dsUsersRights = null;
    private string moduleName = "";
    private string subModuleName = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        UserRightsDB objUserRightsDb = new UserRightsDB();
        _dsUsersRights = objUserRightsDb.GetUsersAndModules(Profile.PracticeId);

        _dsUsersRights.Relations.Add("Modules", _dsUsersRights.Tables[0].Columns["ModuleMasterId"], _dsUsersRights.Tables[1].Columns["ModuleMasterId"]);
        _dsUsersRights.Relations.Add("ModuleRights", _dsUsersRights.Tables[1].Columns["ModuleId"], _dsUsersRights.Tables[2].Columns["ModuleId"]);

        var rows = _dsUsersRights.Tables[0].Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            string _modulename = rows[i]["ModuleName"].ToString();
            if (_modulename == "AR" || _modulename == "CustomerSupport" || _modulename == "Lab")
                _dsUsersRights.Tables[0].Rows[i].Delete();
        }
        _dsUsersRights.Tables[0].AcceptChanges();

        rptModulesMaster.DataSource = _dsUsersRights.Tables[0];
        rptModulesMaster.DataBind();

        rptUserRoles.DataSource = _dsUsersRights.Tables[3];
        rptUserRoles.DataBind();

        rptUsers.DataSource = _dsUsersRights.Tables[4];
        rptUsers.DataBind();
    }
    protected void rptModulesMaster_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptModules = (Repeater)e.Item.FindControl("rptModules");
        DataRowView dr = (DataRowView)e.Item.DataItem;
        moduleName = dr["ModuleName"].ToString().Replace(" ", "");
        rptModules.DataSource = ((DataRowView)e.Item.DataItem).CreateChildView("Modules");
        rptModules.DataBind();
    }
    protected void rptModules_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptModuleRights = (Repeater)e.Item.FindControl("rptModuleRights");
        DataRowView dr = (DataRowView)e.Item.DataItem;
        subModuleName = dr["ModuleName"].ToString().Replace(" ", "");
        Literal ltrSubModule = e.Item.FindControl("ltrSubModule") as Literal;
        ltrSubModule.Text = "<span class='" + moduleName + " " + subModuleName + "'></span>";

        rptModuleRights.DataSource = ((DataRowView)e.Item.DataItem).CreateChildView("ModuleRights");
        rptModuleRights.DataBind();
    }
    protected void rptModuleRights_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string moduleRightName = dr["ModuleRightId"].ToString();

            Literal ltrModuleRightId = e.Item.FindControl("ltrModuleRightId") as Literal;
            ltrModuleRightId.Text = "<span class='" + moduleName + " " +
                                     subModuleName + "_" + dr["ModeuleRightName"] +
                                     " spanModuleRightId' style='display: none;'>" + moduleRightName + "</span>";

            Repeater rptRightsStatus = e.Item.FindControl("rptRightsStatus") as Repeater;
            switch (moduleRightName)
            {

                case "4":
                case "6":
                    {
                        rptRightsStatus.DataSource = _dsUsersRights.Tables[5];
                        rptRightsStatus.DataBind();
                        break;
                    }

                case "33":
                case "35":
                case "36":
                case "37":
                case "38":
                case "39":
                case "40":
                    {
                        rptRightsStatus.DataSource = _dsUsersRights.Tables[7];
                        rptRightsStatus.DataBind();
                        break;
                    }

                case "105":
                case "106":
                    {
                        rptRightsStatus.DataSource = _dsUsersRights.Tables[6];
                        rptRightsStatus.DataBind();
                        break;
                    }
                default:
                    {
                        PlaceHolder placeHolder = e.Item.FindControl("placeHolderStatus") as PlaceHolder;
                        placeHolder.Controls.Clear();
                        break;
                    }

            }

        }

    }
}