using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
public partial class ProviderPortal_Register_Details_UserDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeComp();
        if (Profile.SpecificUserId=="") Response.Redirect("/ProviderPortal/Login.aspx");
        string id = Profile.SpecificUserId;
        //id = id.Replace("#", "");
        //if (id.Trim() != ""){ getById(long.Parse(id));}
        //else { getById(Convert.ToInt32(Profile.SpecificUserId)); }
        getById(long.Parse(id));
    }
    public void getById(long userid)
    {       
        UserRegistrationDB userRegistrationDB = new UserRegistrationDB();
        UserRegistration objUserRegistration = new UserRegistration();
        objUserRegistration.UserRegistrationId = userid;
        objUserRegistration.UserName = null;
        objUserRegistration.Password = null;
        DataTable dt = userRegistrationDB.GetByID(objUserRegistration);
        if (dt.Rows.Count>0)
        {
            UserRegistration userRegistration = new UserRegistration();

            //ID
            ID.Text = userid.ToString();

            //first Name
            userRegistration.FirstName = (dt.Rows[0]["FirstName"]).ToString();
            First_Name.Text = userRegistration.FirstName;
            //Last Name
            userRegistration.LastName = (dt.Rows[0]["LastName"]).ToString();
            Last_Name.Text = userRegistration.LastName;

            /*   //Name
             // Name.Text = First_Name.Text + " " + Last_Name.Text; 

              
              //Email_2.Text = userRegistration.Email;

            

             

            

              //medical provider

              userRegistration.MedicaidProvider = (dt.Rows[0]["MedicaidProvider"]).ToString();
              Medical_Provider.Text = userRegistration.MedicaidProvider;

              //ServicingProviderName

              userRegistration.ServicingProviderName = (dt.Rows[0]["ServicingProviderName"]).ToString();
              Servicing_Provider_Name.Text = userRegistration.ServicingProviderName;

            

              //ProviderTaxonomyCode
              userRegistration.ProviderTaxonomyCode = (dt.Rows[0]["ProviderTaxonomyCode"]).ToString();
              PT_Code.Text = userRegistration.ProviderTaxonomyCode;

              //StateLicenseNumber
              userRegistration.StateLicenseNumber = (dt.Rows[0]["StateLicenseNumber"]).ToString();
              Stat_License_Number.Text = userRegistration.StateLicenseNumber;

            

              //GroupNPIMedicareGroupPTAN
              userRegistration.GroupNPIMedicareGroupPTAN = (dt.Rows[0]["GroupNPIMedicareGroupPTAN"]).ToString();
              Group_NPI_Medicare_Group_PTAN.Text = userRegistration.GroupNPIMedicareGroupPTAN;

              //MedicareProviderPTAN
              userRegistration.MedicareProviderPTAN = (dt.Rows[0]["MedicareProviderPTAN"]).ToString();
              Medicare_Provider_PTAN.Text = userRegistration.MedicareProviderPTAN;

              //Phone
              userRegistration.Phone = (dt.Rows[0]["Phone"]).ToString();
              Phone.Text = userRegistration.Phone;

              //Fax
              userRegistration.Fax = (dt.Rows[0]["Fax"]).ToString();
              Fax.Text = userRegistration.Fax;

              //PhysicalAddress
              userRegistration.PhysicalAddress = (dt.Rows[0]["PhysicalAddress"]).ToString();
              Physical_Address.Text = userRegistration.PhysicalAddress;

              //MailingAddress

              userRegistration.MailingAddress = (dt.Rows[0]["MailingAddress"]).ToString();
              Mailing_Address.Text = userRegistration.MailingAddress;

              //Password

              userRegistration.Password = (dt.Rows[0]["Password"]).ToString();
              Password.Text = userRegistration.Password; 
             
             //MedicaidGroup
            userRegistration.MedicaidGroup = (dt.Rows[0]["MedicaidGroup"]).ToString();
            Medical_Group.Text = userRegistration.MedicaidGroup;
             
             */

            //Tax ID

            userRegistration.TaxID = (dt.Rows[0]["TaxID"]).ToString();
            TaxID.Text = userRegistration.TaxID;


            //Email
            userRegistration.Email = (dt.Rows[0]["Email"]).ToString();
            Email.Text = userRegistration.Email;



            //practicename

           userRegistration.PracticeName = (dt.Rows[0]["PracticeName"]).ToString();
            Practice_Name.Text = userRegistration.PracticeName;

            

            // Group NPI

            userRegistration.GroupNPI = (dt.Rows[0]["GroupNPI"]).ToString();
            GroupNPI.Text = userRegistration.GroupNPI;

            //ProviderNPI
            userRegistration.ProviderNPI = (dt.Rows[0]["ProviderNPI"]).ToString();
            _Provider_NPI.Text = userRegistration.ProviderNPI;

            //image path

            userRegistration.UserImage = (dt.Rows[0]["UserImage"]).ToString();
            User_image_Box.Src +=userRegistration.UserImage;
            Image_Retained_Name.Value = userRegistration.UserImage;
             
        }
        else
        {
            //do nothing
        }
    }

    private void InitializeComp()
    {
        //Password.Attributes["type"] = "Password";
        _Provider_NPI.Enabled = false;
    }

}