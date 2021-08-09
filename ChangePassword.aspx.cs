using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ChangePassword : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["key"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["key"] != null)
                {
                    if (Request.QueryString["key"].ToString() != "")
                    {
                        hdOTPkey.Value = Request.QueryString["key"].ToString();

                        DataSet Ds = new DataSet();
                        Ds = Obj.GetForgotTrans(hdOTPkey.Value);

                        if (Obj.chkdataset(Ds) == false)
                        {
                            Response.Redirect("Default.aspx", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("ChangePassword.cs", "Page_Load", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblErrormsg.Text = "";
            lblErrormsg.Visible = false;
            if (txtPassword.Text != "" && txtCPassword.Text != "")
            {
                if (txtPassword.Text == txtCPassword.Text && txtPassword.Text.Length > 7)
                {
                    DataSet Ds = new DataSet();
                    Ds = Obj.GetForgotTrans(hdOTPkey.Value);
                    if (Obj.chkdataset(Ds))
                    {
                        string UserId = Ds.Tables[0].Rows[0]["UserId"].ToString();
                        string otp = Ds.Tables[0].Rows[0]["OTP"].ToString();
                        if (otp == hdOTPkey.Value)
                        {
                            int Result = 0;
                            Result = Obj.SavePassword(UserId, txtPassword.Text, otp);
                            if (Result > 0)
                            {
                                Response.Redirect("SignIn.aspx", false);
                            }
                            else
                            {
                                lblErrormsg.Text = "Password not change";
                                lblErrormsg.Visible = true;
                            }
                        }
                        else
                        {
                            lblErrormsg.Text = "Invalid otp. please try again";
                            lblErrormsg.Visible = true;
                        }
                    }
                    else
                    {
                        lblErrormsg.Text = "Something went to wrong please try again";
                        lblErrormsg.Visible = true;
                    }
                }
                else
                {
                    lblErrormsg.Text = "Password and Confirm Password Must be same and at least 8 characters";
                    lblErrormsg.Visible = true;
                }
            }
            else
            {
                lblErrormsg.Text = "All Field is required";
                lblErrormsg.Visible = true;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("ChangePassword.cs", "btnLogin_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
}