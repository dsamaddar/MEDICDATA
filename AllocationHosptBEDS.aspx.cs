using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AllocationHosptBEDS : System.Web.UI.Page
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
                DataAlloc d = new DataAlloc();
                d = Session["DataAlloc"] as DataAlloc;
                BindYear();
                BindMonth();
                BindDgvCD1();
                PageTitle.InnerText = d.FrmTitle;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindDgvCD1();
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AllocationHosptBEDS.aspx", "btnSearch_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void BindDgvCD1()
    {
        try
        {
            int month = Obj.strtoint(ddlMonth.SelectedValue.ToString());
            int year = Obj.strtoint(ddlYear.SelectedValue.ToString());
            //int month = 6;
            //int year = 2019;
            Int64 TStateId = 0;
            if (Session["StateId"] != null)
            {
                TStateId = Obj.strtoint64(Session["StateId"].ToString());
            }
            DataAlloc d = new DataAlloc();
            d = Session["DataAlloc"] as DataAlloc;
            CompanyId.Value = Session["CompanyId"].ToString();
            StateId.Value = TStateId.ToString();
            CreatedBy.Value = Session["UID"].ToString();
            HType.Value = d.HType.ToString();
            DataSet Ds = new DataSet();
            Ds = Obj.GetAllHosptBEDS(Obj.strtoint64(CompanyId.Value.ToString()), Obj.strtoint64(StateId.Value.ToString()), System.Environment.MachineName.ToString(), month, year, Obj.strtoint(HType.Value.ToString()));
            if (Obj.chkdataset(Ds))
            {
                RPTAllocBEDS.DataSource = Ds.Tables[0];
                RPTAllocBEDS.DataBind();
            }
            else
            {
                RPTAllocBEDS.DataSource = null;
                RPTAllocBEDS.DataSource = "";
                RPTAllocBEDS.DataBind();
            }

            DataSet DsAC = new DataSet();

            DsAC = Obj.GetPatientAdmitOutcomes(Obj.strtoint64(CompanyId.Value.ToString()), Obj.strtoint64(StateId.Value.ToString()), System.Environment.MachineName.ToString(), month, year, Obj.strtoint(HType.Value.ToString()));
            if (Obj.chkdataset(DsAC))
            {
                RPTPatientAdmitOutcom.DataSource = DsAC.Tables[0];
                RPTPatientAdmitOutcom.DataBind();
            }
            else
            {
                RPTPatientAdmitOutcom.DataSource = null;
                RPTPatientAdmitOutcom.DataSource = "";
                RPTPatientAdmitOutcom.DataBind();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AllocationHosptBEDS.aspx", "BindDgvCD1", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void BindMonth()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetMonthDrp(false);
            if (Obj.chkdataset(Ds))
            {
                ddlMonth.DataSource = Ds.Tables[0];
                ddlMonth.DataTextField = "MontName";
                ddlMonth.DataValueField = "MonthId";
                ddlMonth.SelectedValue = System.DateTime.Now.Month.ToString();
                ddlMonth.DataBind();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AllocationHosptBEDS.aspx", "BindMonth", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void BindYear()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetYearDrp();
            if (Obj.chkdataset(Ds))
            {
                ddlYear.DataSource = Ds.Tables[0];
                ddlYear.DataTextField = "YearName";
                ddlYear.DataValueField = "YearID";
                ddlYear.SelectedValue = System.DateTime.Now.Year.ToString();
                ddlYear.DataBind();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AllocationHosptBEDS.aspx", "BindYear", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
}