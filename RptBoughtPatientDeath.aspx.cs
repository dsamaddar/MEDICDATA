using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class RptBoughtPatientDeath : System.Web.UI.Page
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
                GetHospitalDrp();
                BindMonth();
                BindYear();
                BindReport();
            }

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("RptPatientDeath.cs", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindReport();
        }
        catch (Exception ex)
        {
            Obj.ErrorLog("RptPatientDeath.cs", "btnSearch_Click", ex.Message.ToString(), System.DateTime.Now.ToString());
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
            Obj.ErrorLog("RptPatientDeath.cs", "BindYear", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void BindMonth()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetMonthDrp(true);
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
            Obj.ErrorLog("MonthlyData.aspx", "BindMonth", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void GetHospitalDrp()
    {
        try
        {
            DataSet Ds = new DataSet();
            Int64 CompanyId = Obj.strtoint64(Session["CompanyId"].ToString());
            Int64 UserType = Obj.strtoint64(Session["UserType"].ToString());
            Ds = Obj.GetHospitalDrpReport(CompanyId,UserType);
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
            Obj.ErrorLog("RptPatientDeath.cs", "GetServicesDrp", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }

    public void BindReport()
    {
        try
        {
            DataSet Ds = new DataSet();
            DataSet DsHead = new DataSet();

            Data d = new Data();
            d = Session["Data"] as Data;
            Int64 StateId = Obj.strtoint64(Session["StateId"].ToString());
            int CurrentMonth = 0;
            int SMonth = 0;
            int EMonth = 0;
            if (Obj.strtoint(ddlMonth.SelectedValue) > 0)
            {
                CurrentMonth = Obj.strtoint(ddlMonth.SelectedValue.ToString());
                SMonth = Obj.RptGetSmonth(CurrentMonth);
                EMonth = Obj.RptGetEmonth(CurrentMonth);
            }
            int CurrentYear = Obj.strtoint(ddlYear.SelectedValue.ToString());
            Int64 CompanyId = Obj.strtoint64(ddlCompany.SelectedValue.ToString());
            string period = Obj.RptGetPeriod(CurrentMonth, CurrentYear);
            //int HtypeT = 23;
            //if (d.HType == 25)
            //{
            //    HtypeT = 26;
            //}
            if (d.HType2 > 0)
            {
                Ds = Obj.RptGetBoughtPatientDeathComplex(SMonth, CurrentYear, StateId, txtRefNo.Text, CompanyId, d.HType, d.HType1, d.HType2, d.HType3, EMonth);
                DsHead = Obj.RptGetHeaderDetails(CompanyId, 27, txtRefNo.Text, period);
            }
            else
            {
                Ds = Obj.RptGetBoughtPatientDeathDetails(SMonth, CurrentYear, StateId, txtRefNo.Text, CompanyId, d.HType, d.HType1, EMonth);
                DsHead = Obj.RptGetHeaderDetails(CompanyId, d.HType, txtRefNo.Text, period);
            }
            
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Reports\\rptBoughtPatientDeath.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportDataSource RDS = new ReportDataSource("DsBought", Ds.Tables[0]);
            ReportDataSource RDS1 = new ReportDataSource("DSHead", DsHead.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(RDS);
            ReportViewer1.LocalReport.DataSources.Add(RDS1);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("RptPatientDeath.cs", "BindReport", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }

    }
}