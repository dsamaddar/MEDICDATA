using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddUser : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("SignIn.aspx", false);
        }
        if (!IsPostBack)
        {
            if (Session["UserType"] != null)
            {
                if (Obj.strtoint(Session["UserType"].ToString()) > 2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enabled to access this page');window.location ='Home.aspx';", true);
                }
                GetUserTypeDrp();
                GetHospitalDrp();
                //GetStateDrp();
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["RecId"] != null)
                    {
                        BindData();
                        ViewState["RecId"] = Request.QueryString["RecId"];
                    }
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblErrormsg.Visible = false;
            lblSuccessmsg.Visible = false;
            SaveData();
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddUser.cs", "btnAdd_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void SaveData()
    {
        try
        {
            if (txtUserId.Text != "" && txtPassword.Text != "" && txtUserName.Text != "" && rdGender.SelectedValue != "")
            {
                if (ddlUserType.SelectedValue != "1" && ddlUserType.SelectedValue != "3" && ddlCompany.SelectedIndex < 1)
                {
                    lblErrormsg.Text = "Please Select Hospital";
                    lblErrormsg.Visible = true;
                }
                else
                {
                    Int64 Result = 0;

                    DateTime DOB = new DateTime(1900, 1, 1);
                    DOB = Obj.strtodate(txtDOB.Text);

                    int Gender = 0;
                    if (rdGender.Items[0].Selected == true)
                    {
                        Gender = Obj.strtoint(rdGender.Items[0].Value);
                    }
                    else
                    {
                        Gender = Obj.strtoint(rdGender.Items[1].Value);
                    }

                    if (fuProfile.HasFile == true)
                    {
                        String FName = GetFileName();
                        String Extention = fuProfile.FileName.ToString().Substring(fuProfile.FileName.LastIndexOf("."));
                        hdProfilePic.Value = FName + Extention;
                        fuProfile.SaveAs(Server.MapPath("images\\ProfilePic\\" + FName + Extention));
                    }

                    Int64 RecId = 0;
                    if (ViewState["RecId"] != null)
                    {
                        RecId = Obj.strtoint64(ViewState["RecId"].ToString());
                    }
                    Result = Obj.SaveUser(RecId, txtUserId.Text, txtPassword.Text, txtUserName.Text, DOB, Gender, txtEmailId.Text,
                                          txtContact.Text, txtAddress.Text, txtCity.Text, "0", txtZipCode.Text, hdProfilePic.Value, Obj.strtoint(ddlUserType.SelectedValue), 1, Obj.strtoint64(Session["UID"].ToString()), Obj.strtoint(ddlCompany.SelectedValue));
                    if (Result != 0)
                    {
                        lblSuccessmsg.Text = "Successfully saved!";
                        lblSuccessmsg.Visible = true;
                        Response.Redirect("UserList.aspx", false);
                    }
                    else
                    {
                        lblErrormsg.Text = "Unable to Save record";
                        lblErrormsg.Visible = true;
                    }
                }
            }
            else
            {
                lblErrormsg.Text = "Userid, Password, Username, Gender, Date of Birth field required";
                lblErrormsg.Visible = true;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddUser.cs", "SaveData", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void BindData()
    {
        try
        {
            DataSet Ds = new DataSet();
            Int64 RecId = Obj.strtoint64(Request.QueryString["RecId"]);
            Ds = Obj.GetUserMaster(RecId);
            if (Obj.chkdataset(Ds))
            {
                txtUserId.Text = Ds.Tables[0].Rows[0]["UserId"].ToString();
                txtPassword.Text = Ds.Tables[0].Rows[0]["PWD"].ToString();
                txtPassword.Attributes.Add("value", Ds.Tables[0].Rows[0]["PWD"].ToString());
                txtUserName.Text = Ds.Tables[0].Rows[0]["UserName"].ToString();
                txtDOB.Text = Ds.Tables[0].Rows[0]["DOB"].ToString();
                ddlUserType.SelectedValue = Ds.Tables[0].Rows[0]["UserType"].ToString();
                ddlCompany.SelectedValue = Ds.Tables[0].Rows[0]["CompanyId"].ToString();
                //if (Obj.strtoint(Ds.Tables[0].Rows[0]["Gender"].ToString()) == 1)
                //{
                //    rdGender.SelectedIndex = 1;
                //}
                //else if (Obj.strtoint(Ds.Tables[0].Rows[0]["Gender"].ToString()) == 2)
                //{
                //    rdGender.SelectedIndex = 2;
                //}
                //else
                //{

                //}

                if (Obj.strtoint(Ds.Tables[0].Rows[0]["Gender"].ToString()) == 0)
                {
                    rdGender.Items[0].Selected = false;
                    rdGender.Items[1].Selected = false;
                }
                else if (Obj.strtoint(Ds.Tables[0].Rows[0]["Gender"].ToString()) == 1)
                {
                    rdGender.Items[0].Selected = true;
                }
                else if (Obj.strtoint(Ds.Tables[0].Rows[0]["Gender"].ToString()) == 2)
                {
                    rdGender.Items[1].Selected = true;
                }

                txtEmailId.Text = Ds.Tables[0].Rows[0]["EmailId"].ToString();
                txtContact.Text = Ds.Tables[0].Rows[0]["Contact"].ToString();
                txtAddress.Text = Ds.Tables[0].Rows[0]["Address"].ToString();
                txtCity.Text = Ds.Tables[0].Rows[0]["City"].ToString();
                //ddlState.SelectedValue = Ds.Tables[0].Rows[0]["State"].ToString();
                txtZipCode.Text = Ds.Tables[0].Rows[0]["ZipCode"].ToString();

                if (Ds.Tables[0].Rows[0]["ProfilePic"].ToString() == "")
                {
                    flProfile.ImageUrl = "~/images/addimage.png";
                    hdProfilePic.Value = Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                }
                else
                {
                    if (System.IO.File.Exists(Server.MapPath("~/images/ProfilePic/" + Ds.Tables[0].Rows[0]["ProfilePic"].ToString())))
                    {
                        flProfile.ImageUrl = "~/images/ProfilePic/" + Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                        hdProfilePic.Value = Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                    }
                    else
                    {
                        flProfile.ImageUrl = "~/images/addimage.png";
                        hdProfilePic.Value = Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddUser.cs", "BindData", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public String GetFileName()
    {
        String FileName = "";
        try
        {
            FileName = System.DateTime.Now.ToString("ddMMyyyyhhmmsstt");
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddUser.cs", "GetFileName", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return FileName;
    }

    public void GetHospitalDrp()
    {
        try
        {
            DataSet Ds = new DataSet();
            Int64 UserId = Obj.strtoint64(Session["UID"].ToString());
            Ds = Obj.GetHospitalDrp(UserId);
            if (Obj.chkdataset(Ds))
            {
                ddlCompany.DataSource = Ds.Tables[0];
                ddlCompany.DataTextField = "CName";
                ddlCompany.DataValueField = "RecId";
                ddlCompany.SelectedIndex = 0;
                ddlCompany.DataBind();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddService.cs", "GetServicesDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void GetUserTypeDrp()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetUserTypeDrp(Obj.strtoint(Session["UserType"].ToString()));
            if (Obj.chkdataset(Ds))
            {
                ddlUserType.DataSource = Ds.Tables[0];
                ddlUserType.DataTextField = "TypeName";
                ddlUserType.DataValueField = "TypeId";
                ddlUserType.SelectedIndex = 0;
                ddlUserType.DataBind();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserPermission.cs", "GetUserTypeDrp", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    //public void GetStateDrp()
    //{
    //    try
    //    {
    //        DataSet Ds = new DataSet();
    //        Ds = Obj.GetStateDrp();
    //        if (Obj.chkdataset(Ds))
    //        {
    //            ddlState.DataSource = Ds.Tables[0];
    //            ddlState.DataTextField = "StateName";
    //            ddlState.DataValueField = "RecId";
    //            ddlState.DataBind();
    //            ddlState.SelectedIndex = 0;
    //        }
    //    }
    //    catch (Exception Ex)
    //    {
    //        Obj.ErrorLog("AddHospital.cs", "GetStateDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
    //    }
    //}
}