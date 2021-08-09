using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Web.UI.HtmlControls;

public partial class UserList : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();

    protected void Page_Load(object sender, EventArgs e)
    {
        spErrorMsg.Visible = false;
        try
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
                    BindUsers();
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserList.cs", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    public void BindUsers()
    {
        try
        {
            DataSet Ds = new DataSet();
            Int64 UID = Obj.strtoint64(Session["UID"].ToString());
            Ds = Obj.GetUserList(txtSearch.Text, UID);
            if (Obj.chkdataset(Ds))
            {
                PagedDataSource pgitems = new PagedDataSource();
                DataView dv = new DataView(Ds.Tables[0]);
                pgitems.DataSource = dv;
                pgitems.AllowPaging = true;
                pgitems.PageSize = 25;
                pgitems.CurrentPageIndex = PageNumber;

                if (pgitems.PageCount > 1)
                {
                    RptPaging.Visible = true;
                    ArrayList pages = new ArrayList();

                    for (int i = 0; i <= pgitems.PageCount - 1; i++)
                        pages.Add((i + 1).ToString());

                    RptPaging.DataSource = pages;
                    RptPaging.DataBind();
                }
                else
                {
                    RptPaging.Visible = false;
                }

                lbltotrecords.Text = Ds.Tables[0].Rows.Count.ToString();
                RptUserList.DataSource = pgitems;
                RptUserList.DataBind();
            }
            else
            {
                RptUserList.DataSource = null;
                RptUserList.DataSource = "";
                RptUserList.DataBind();
                lbltotrecords.Text = "0";
                RptPaging.Visible = false;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserList.cs", "BindUsers", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void RptUserList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("AddUser.aspx?RecId=" + e.CommandArgument, false);
            }
            if (e.CommandName == "Delete")
            {
                Int64 RecId = Obj.strtoint64(e.CommandArgument.ToString());
                Int64 Result = 0;
                Result = Obj.DeleteUser(RecId);
                if (Result != 0)
                {
                    BindUsers();
                }
                else
                {
                    spErrorMsg.InnerText = "Unable to delete record";
                    spErrorMsg.Visible = false;
                    //MessageBox.Show("Unable to delete record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (e.CommandName == "Login")
            {
                DataSet Ds = new DataSet();
                Int64 RecId = Obj.strtoint64(e.CommandArgument.ToString());
                Ds = Obj.GetUserMaster(RecId);
                if (Obj.chkdataset(Ds))
                {
                    Session["UID"] = Convert.ToString(Ds.Tables[0].Rows[0]["RecId"]);
                    Session["UserId"] = Convert.ToString(Ds.Tables[0].Rows[0]["UserId"]);
                    Session["UserName"] = Convert.ToString(Ds.Tables[0].Rows[0]["UserName"]);
                    Session["EmailId"] = Convert.ToString(Ds.Tables[0].Rows[0]["EmailId"]);
                    Session["Contact"] = Convert.ToString(Ds.Tables[0].Rows[0]["Contact"]);
                    Session["UserType"] = Convert.ToString(Ds.Tables[0].Rows[0]["UserType"]);
                    Session["StateId"] = Convert.ToString(Ds.Tables[0].Rows[0]["State"]);
                    Session["CompanyId"] = Convert.ToString(Ds.Tables[0].Rows[0]["CompanyId"]);
                    Response.Redirect("Home.aspx", false);
                }
            }
            if (e.CommandName == "Deactive")
            {
                Int64 RecId = 0;
                RecId = Obj.strtoint64(e.CommandArgument.ToString());
                if (RecId > 0)
                {
                    Obj.UpdateUserIsActive(RecId);
                    BindUsers();
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserList.cs", "RptUserList_ItemCommand", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void RptUserList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserList.cs", "RptUserList_ItemDataBound", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindUsers();
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserList.cs", "btnSearch_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void RptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl Rptlipage = (HtmlGenericControl)e.Item.FindControl("lipage");
                HiddenField RpthfPage = (HiddenField)e.Item.FindControl("hfPage");

                if (RpthfPage.Value == PageNumber.ToString())
                    Rptlipage.Attributes.Add("class", "active");
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserList.cs", "RptPaging_ItemDataBound", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void RptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Page")
            {
                PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
                BindUsers();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserList.cs", "RptPaging_ItemCommand", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUser.aspx", false);
    }
}