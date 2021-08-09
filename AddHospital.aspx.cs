using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HospitalInfo : System.Web.UI.Page
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

                    if (Obj.strtoint(Session["UserType"].ToString()) > 2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enabled to access this page');window.location ='Home.aspx';", true);
                    }
                    GetStateDrp();
                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["RecId"] != null)
                        {
                            BindData();
                            ViewState["RecId"] = Request.QueryString["RecId"];
                        }
                    }
                    if (Obj.strtoint(Session["UserType"].ToString()) == 2)
                    {
                        BindData();
                        Int64 CompanyId = Obj.strtoint64(Session["CompanyId"].ToString());
                        ViewState["RecId"] = CompanyId;
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddHospital.cs", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    public void BindData()
    {
        try
        {
            DataSet Ds = new DataSet();
            Int64 RecId = 0;
            if (Obj.strtoint(Session["UserType"].ToString()) == 2)
            {
                RecId = Obj.strtoint64(Session["CompanyId"].ToString());
            }
            else
            {
                RecId = Obj.strtoint64(Request.QueryString["RecId"]);
            }
            Ds = Obj.GetCompanyMaster(RecId);
            if (Obj.chkdataset(Ds))
            {
                ViewState["RecId"] = Ds.Tables[0].Rows[0]["RecId"].ToString();
                txtHospital.Text = Ds.Tables[0].Rows[0]["CName"].ToString();
                txtCity.Text = Ds.Tables[0].Rows[0]["City"].ToString();
                ddlState.SelectedValue = Ds.Tables[0].Rows[0]["State"].ToString();
                txtContact.Text = Ds.Tables[0].Rows[0]["Contact"].ToString();
                txtEmail.Text = Ds.Tables[0].Rows[0]["Email"].ToString();
                txtReportTitle1.Text = Ds.Tables[0].Rows[0]["Header1"].ToString();
                txtReportTitle2.Text = Ds.Tables[0].Rows[0]["Header2"].ToString();
                txtReportTitle3.Text = Ds.Tables[0].Rows[0]["Header3"].ToString();
                if (Ds.Tables[0].Rows[0]["Logo"].ToString() != "")
                    DisplayLogo.ImageUrl = String.Format(@"data:image/jpeg;base64,{0}", Ds.Tables[0].Rows[0]["Logo"].ToString());
                else
                    LogoArea.Visible = false;
            }
            else
            {
                ViewState["RecId"] = "0";
                txtHospital.Text = "";
                txtCity.Text = "";
                ddlState.SelectedIndex = 0;
                txtContact.Text = "";
                txtEmail.Text = "";
                txtReportTitle1.Text = "";
                txtReportTitle2.Text = "";
                txtReportTitle3.Text = "";
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddHospital.cs", "BindData", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
    public void GetStateDrp()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetStateDrp();
            if (Obj.chkdataset(Ds))
            {
                ddlState.DataSource = Ds.Tables[0];
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "RecId";
                ddlState.DataBind();
                ddlState.SelectedIndex = 0;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddHospital.cs", "GetStateDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
    protected void btnUpdateHospitalInfo_Click(object sender, EventArgs e)
    {
        try
        {
            lblErrormsg.Visible = false;
            lblSuccessmsg.Visible = false;
            string validate = Validation();
            if (validate == "")
            {
                int Result = 0;
                Int64 RecId = 0;
                Int64 State = Obj.strtoint64(ddlState.SelectedValue.ToString());
                if (ViewState["RecId"] != null)
                {
                    RecId = Obj.strtoint64(ViewState["RecId"].ToString());
                }
                string LogoString = "";
                if (fuLogo.HasFile == true)
                {
                    System.IO.Stream fs = fuLogo.PostedFile.InputStream;
                    System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    LogoString = Convert.ToBase64String(bytes, 0, bytes.Length);
                }
                if (RecId > 0 || LogoString != "")
                {
                    Result = Obj.SaveCompanyMaster(RecId, txtHospital.Text, txtCity.Text, State, txtContact.Text, txtEmail.Text, LogoString, 1, Obj.strtoint64(Session["UID"].ToString()), txtReportTitle1.Text, txtReportTitle2.Text, txtReportTitle3.Text);
                    if (Result != 0)
                    {
                        lblSuccessmsg.Text = "Successfully saved!";
                        lblSuccessmsg.Visible = true;
                        if (Obj.strtoint(Session["UserType"].ToString()) == 1)
                        {
                            Response.Redirect("HospitalList.aspx", false);
                        }
                    }
                    else
                    {
                        lblErrormsg.Text = "Unable to Save record";
                        lblErrormsg.Visible = true;
                    }
                }
                else
                {
                    lblErrormsg.Text = "Hospital logo required";
                    lblErrormsg.Visible = true;
                }

            }
            else
            {
                lblErrormsg.Text = validate;
                lblErrormsg.Visible = true;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddHospital.cs", "btnSave_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public string Validation()
    {
        String Result = "";
        try
        {
            if (txtHospital.Text == "")
            {
                if (Result == "")
                {
                    Result += "Hospital Name ";
                }
                else
                {
                    Result += ",Hospital Name ";
                }
            }
            if (txtCity.Text == "")
            {
                if (Result == "")
                {
                    Result += "City Name ";
                }
                else
                {
                    Result += ",City Name ";
                }
            }
            if (ddlState.SelectedIndex == 0)
            {
                if (Result == "")
                {
                    Result += "State Name ";
                }
                else
                {
                    Result += ",State Name ";
                }
            }

            if (Result != "")
            {
                Result = "Please Enter " + Result;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("frmAddHospital.cs", "Validation", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Result;
    }
}