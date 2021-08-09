using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SignIn : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                Response.Redirect("Home.aspx", false);
            }
            if (!IsPostBack)
            {
                //if (Environment.MachineName == "OMIT-2-PC")
                //{
                //    txtUserId.Text = "test";
                //    txtPassword.Text = "test1234";
                //    txtPassword.Attributes.Add("value", "test1234");
                //}
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("SignIn.cs", "Page_Load", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUserId.Text != "" && txtPassword.Text != "")
            {
                DataSet ds = new DataSet();
                ds = Obj.SignInUserMaster(txtUserId.Text, txtPassword.Text);
                if (Obj.chkdataset(ds))
                {
                    if (Obj.strtoint(ds.Tables[0].Rows[0]["IsActive"].ToString()) == 1)
                    {
                        Session["UID"] = Convert.ToString(ds.Tables[0].Rows[0]["RecId"]);
                        Session["UserId"] = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                        Session["UserName"] = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                        Session["EmailId"] = Convert.ToString(ds.Tables[0].Rows[0]["EmailId"]);
                        Session["Contact"] = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                        Session["UserType"] = Convert.ToString(ds.Tables[0].Rows[0]["UserType"]);
                        Session["StateId"] = Convert.ToString(ds.Tables[0].Rows[0]["StateId"]);
                        Session["CompanyId"] = Convert.ToString(ds.Tables[0].Rows[0]["CompanyId"]);
                        Response.Redirect("Home.aspx", false);
                    }
                    else
                    {
                        lblErrormsg.Text = "User is deactivated please contact to administrator";
                        lblErrormsg.Visible = true;
                    }
                }
                else
                {
                    lblErrormsg.Text = "Invalid UserId or Password";
                    lblErrormsg.Visible = true;
                }
            }
            else
            {
                lblErrormsg.Text = "ALL Field is required";
                lblErrormsg.Visible = true;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("SignIn.cs", "btnLogin_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
}