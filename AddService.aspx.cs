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
                
                GetServicesDrp();
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
            Obj.ErrorLog("AddService.cs", "btnAdd_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void SaveData()
    {
        try
        {
            if (txtServiceName.Text != "")
            {
                Int64 Result = 0;

                Int64 ParentId = 0;
                if (ddlParentService.SelectedIndex > 0)
                {
                    ParentId = Obj.strtoint64(ddlParentService.SelectedValue.ToString());
                }

                Int64 RecId = 0;
                if (ViewState["RecId"] != null)
                {
                    RecId = Obj.strtoint64(ViewState["RecId"].ToString());
                }

                Result = Obj.SaveServicesMaster(RecId, ParentId, txtServiceName.Text, txtDescription.Text, 1, Obj.strtoint64(Session["UID"].ToString()));
                if (Result != 0)
                {
                    lblSuccessmsg.Text = "Successfully saved!";
                    lblSuccessmsg.Visible = true;
                    Response.Redirect("ServiceList.aspx", false);
                }
                else
                {
                    lblErrormsg.Text = "Unable to Save record";
                    lblErrormsg.Visible = true;
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
            Obj.ErrorLog("AddService.cs", "SaveData", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void BindData()
    {
        try
        {
            DataSet Ds = new DataSet();
            Int64 RecId = Obj.strtoint64(Request.QueryString["RecId"]);
            Ds = Obj.GetServicesMaster(RecId);
            if (Obj.chkdataset(Ds))
            {
                txtServiceName.Text = Ds.Tables[0].Rows[0]["ServiceName"].ToString();
                ddlParentService.SelectedValue = Ds.Tables[0].Rows[0]["ParentId"].ToString();
                txtDescription.Text = Ds.Tables[0].Rows[0]["Description"].ToString();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddService.cs", "BindData", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void GetServicesDrp()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetServicesDrp();
            if (Obj.chkdataset(Ds))
            {
                ddlParentService.DataSource = Ds.Tables[0];
                ddlParentService.DataTextField = "ServiceName";
                ddlParentService.DataValueField = "RecId";
                ddlParentService.SelectedIndex = 0;
                ddlParentService.DataBind();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddService.cs", "GetServicesDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

}