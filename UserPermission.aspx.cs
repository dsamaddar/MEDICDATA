using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserPermission : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();

    protected void Page_Load(object sender, EventArgs e)
    {
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
                    if (Obj.strtoint(Session["UserType"].ToString()) > 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enabled to access this page');window.location ='Home.aspx';", true);
                    }
                    GetUserTypeDrp();
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserPermission.cs", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlUserType.SelectedIndex > 0)
            {
                Int64 TypeId = Obj.strtoint64(ddlUserType.SelectedValue.ToString());
                GetUserPermission(TypeId);
            }
            else
            {
                GetUserPermission(0);
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserPermission.cs", "ddlUserType_SelectedIndexChanged", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void chkMenu_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LoadStart", "$('.se-pre-con').show()", true);
            CheckBox chk = (CheckBox)sender;
            Int64 PMRecId = Obj.strtoint64(chk.ToolTip.ToString().Split(',')[0]);
            Int64 MenuId = Obj.strtoint64(chk.ToolTip.ToString().Split(',')[1]);
            Int64 TypeId = Obj.strtoint64(ddlUserType.SelectedValue.ToString());
            Int64 CrBy = 0;
            if (Session["UID"] != null)
            {
                CrBy = Obj.strtoint64(Session["UID"].ToString());
            }
            int IsActive = 0;
            if (chk.Checked == true)
            {
                IsActive = 1;
            }
            PMRecId = Obj.SavePermissionMaster(PMRecId, MenuId, TypeId, IsActive, CrBy);
            if (PMRecId > 0)
            {
                GetUserPermission(TypeId);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "LoadEnd", "$('.se-pre-con').fadeOut('slow');", true);
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserPermission.cs", "chkMenu_CheckedChanged", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    public void GetUserPermission(Int64 TypeId)
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetUserPermission(TypeId);
            if (Obj.chkdataset(Ds))
            {
                dlMenuList.DataSource = Ds.Tables[0];
                dlMenuList.DataBind();
            }
            else
            {
                dlMenuList.DataSource = "";
                dlMenuList.DataSource = null;
                dlMenuList.DataBind();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("UserPermission.cs", "GetUserPermission", Ex.Message, System.DateTime.Now.ToString());
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
}