using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Services;
using System.Net;

public partial class Contact : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();
    protected static string ReCaptcha_Key = ConfigurationManager.AppSettings["sitekey"].ToString();
    protected static string ReCaptcha_Secret = ConfigurationManager.AppSettings["secretkey"].ToString();

    [WebMethod]
    public static string VerifyCaptcha(string response)
    {
        string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
        return (new WebClient()).DownloadString(url);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnContact_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCaptcha.Text == "6LfSg5YUAAAAALRc8OZ7gGpylmDxKZTCFdMK-9-x")
            {
                if (txtName.Text != "" && txtphone.Text != "" && txtMsg.Text != "" && txtEmail.Text != "")
                {
                    Boolean EmailResult = Obj.EmailSent(GetEmailBodyUserContct(txtName.Text, txtphone.Text, txtEmail.Text, txtMsg.Text));
                    if (EmailResult == true)
                    {
                        lblMsg.Visible = true;
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtphone.Text = "";
                        txtMsg.Text = "";
                    }
                }
            }
            else
            {
                rfvCaptcha.Style.Add("display", "block");
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Contact.cs", "btnContact_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public string GetEmailBodyUserContct(string FirstName, string Phone, string Email, string Message)
    {
        String EmailBody = "";
        try
        {
            EmailBody = "<h3><b>NEW REQUEST FOR DEMO</b></h3> <br/><br/> <b>Name : </b>" + FirstName + "<br/> <b>Phone :</b>" + Phone + "<br/> <b>Email :</b>" + Email + "<br/> <b>Message :</b>" + Message + "  ";
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("ContactUs.cs", "GetEmailBodyUserContct", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return EmailBody;
    }
}