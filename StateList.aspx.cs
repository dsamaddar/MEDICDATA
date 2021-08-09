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
        try
        {
            spErrorMsg.Visible = false;
            if (Session["UserId"] == null)
            {
                Response.Redirect("SignIn.aspx", false);
            }
            if (!IsPostBack)
            {
                if (Session["UserType"] != null)
                {
                    if (Obj.strtoint(Session["UserType"].ToString()) != 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enabled to access this page');window.location ='Home.aspx';", true);
                        //Response.Redirect("Home.aspx", false);
                    }
                    BindState();
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("StateList.cs", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    public void BindState()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetStateList(txtSearch.Text);
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
                RptStateList.DataSource = pgitems;
                RptStateList.DataBind();
            }
            else
            {
                RptStateList.DataSource = null;
                RptStateList.DataSource = "";
                RptStateList.DataBind();
                lbltotrecords.Text = "0";
                RptPaging.Visible = false;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("StateList.cs", "BindState", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void RptStateList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("AddState.aspx?RecId=" + e.CommandArgument, false);
            }
            if (e.CommandName == "Deactive")
            {
                Int64 RecId = 0;
                RecId = Obj.strtoint64(e.CommandArgument.ToString());
                if (RecId > 0)
                {
                    Obj.UpdateStateIsActive(RecId);
                    BindState();
                }
            }

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("StateList.cs", "RptUserList_ItemCommand", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void RptStateList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("StateList.cs", "RptUserList_ItemDataBound", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindState();
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("StateList.cs", "btnSearch_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
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
            Obj.ErrorLog("StateList.cs", "RptPaging_ItemDataBound", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    protected void RptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Page")
            {
                PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
                BindState();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("StateList.cs", "RptPaging_ItemCommand", Ex.Message.ToString(), System.DateTime.Now.ToString());
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
        Response.Redirect("AddState.aspx", false);
    }
}