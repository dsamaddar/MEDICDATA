using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Drawing;

public partial class ForgotPassword : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("ForgotPassword.cs", "Page_Load", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblErrormsg.Text = "";
            lblErrormsg.Visible = false;
            lblErrormsg.ForeColor = Color.Red;
            if (txtUserId.Text != "")
            {
                DataSet Ds = new DataSet();
                Ds = Obj.ForgotPassword(txtUserId.Text);
                if (Obj.chkdataset(Ds))
                {
                    string ToEmailId = Ds.Tables[0].Rows[0]["EmailId"].ToString();
                    if (ToEmailId != "")
                    {
                        string UserId = Ds.Tables[0].Rows[0]["UserId"].ToString();
                        string UserName = Ds.Tables[0].Rows[0]["UserName"].ToString();
                        string otp = "";
                        otp = Obj.SaveOTPMaster(UserId, UserName, otp, Environment.MachineName, 0, ToEmailId);
                        if (otp != "")
                        {
                            Boolean Result = false;
                            string MailBody = GetMailBody(UserName, otp);
                            Result = Obj.ForgotPwdEmailSent(MailBody, ToEmailId, "MEDICDATA Forgot Password");
                            if (Result == true)
                            {
                                txtUserId.Text = "";
                                lblErrormsg.Text = "Change Password link sent on your email address please check your inbox.";
                                lblErrormsg.ForeColor = Color.Green;
                                lblErrormsg.Visible = true;
                            }
                            else
                            {
                                lblErrormsg.Text = "Email not sent please try again";
                                lblErrormsg.Visible = true;
                            }
                        }
                        else
                        {
                            lblErrormsg.Text = "Email not sent please try again";
                            lblErrormsg.Visible = true;
                        }
                    }
                    else
                    {
                        lblErrormsg.Text = "Email not found with user data contact to administrator";
                        lblErrormsg.Visible = true;
                    }
                }
                else
                {
                    lblErrormsg.Text = "Invalid UserId";
                    lblErrormsg.Visible = true;
                }
            }
            else
            {
                lblErrormsg.Text = "UserId Field is required";
                lblErrormsg.Visible = true;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("ForgotPassword.cs", "btnSubmit_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public string GetMailBody(string UserName, string ForgotKey)
    {
        string MailBody = "";
        try
        {
            string HostName = "";
            HostName = ConfigurationManager.AppSettings["DomainName"].ToString();
            string Link = HostName + "ChangePassword.aspx?key=" + ForgotKey;
            MailBody = "<table><tr><td><span><b>Hello " + UserName + ".</b></span></td></tr><tr><td></td></tr><tr><td><span>Click <a href='" + Link + "'> here </a> to change password</span></td></tr><tr><td>if above link not working then copy below link and put your browser.</td></tr><tr><td><span>" + Link + "</span></td></tr><tr><td></td></tr><tr><td><span>Use This Link Change Password.</span></td></tr></table>";
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("ForgotPassword.cs", "GetMailBody", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return MailBody;
    }
}