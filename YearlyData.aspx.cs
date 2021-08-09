using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class MonthlyData : System.Web.UI.Page
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
                    GetHospitalDrp();
                    BindYear();
                    BindReport();
                }
            }

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("YearlyData.aspx", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
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
            Obj.ErrorLog("YearlyData.aspx", "BindYear", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
    public void BindReport()
    {
        try
        {
            DataSet Ds = new DataSet();
            DataSet DsSummary = new DataSet();
            DataSet DsHead = new DataSet();

            Data d = new Data();
            d = Session["Data"] as Data;
            Int64 StateId = Obj.strtoint64(Session["StateId"].ToString());
            int CurrentYear = Obj.strtoint(ddlYear.SelectedValue.ToString());
            Int64 CompanyId = Obj.strtoint64(ddlCompany.SelectedValue.ToString());
            string period = Obj.RptGetPeriod(0, CurrentYear);

            Ds = Obj.GetYearly(CurrentYear, d.HType, StateId, txtRefNo.Text, CompanyId);
            DsSummary = Obj.GetYearlySummary(CurrentYear, d.HType, StateId, CompanyId);
            DsHead = Obj.RptGetHeaderDetails(CompanyId, d.HType, txtRefNo.Text, period);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = "Reports\\YearlyData.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportDataSource RDS = new ReportDataSource("RptYearly", Ds.Tables[0]);
            ReportDataSource RDS1 = new ReportDataSource("RptYearlySummary", DsSummary.Tables[0]);
            ReportDataSource RDS2 = new ReportDataSource("DSHead", DsHead.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Add(RDS);
            ReportViewer1.LocalReport.DataSources.Add(RDS1);
            ReportViewer1.LocalReport.DataSources.Add(RDS2);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("YearlyData.cs", "BindReport", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }

    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        try
        {
            BindReport();
        }
        catch (Exception ex)
        {
            Obj.ErrorLog("YearlyData.cs", "btnSearch_Click", ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
    public void GetHospitalDrp()
    {
        try
        {
            DataSet Ds = new DataSet();
            Int64 CompanyId = Obj.strtoint64(Session["CompanyId"].ToString());
            Int64 UserType = Obj.strtoint64(Session["UserType"].ToString());
            Ds = Obj.GetHospitalDrpReport(CompanyId, UserType);
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
}