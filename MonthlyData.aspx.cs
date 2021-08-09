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
                    BindMonth();
                    BindReport();
                }
            }

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("MonthlyData.aspx", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
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
            Obj.ErrorLog("MonthlyData.cs", "btnSearch_Click", ex.Message.ToString(), System.DateTime.Now.ToString());
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
            Obj.ErrorLog("MonthlyData.aspx", "BindYear", Ex.Message.ToString(), System.DateTime.Now.ToString());
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

    public void BindReport()
    {
        try
        {
            DataSet Ds = new DataSet();
            DataSet DsSummary = new DataSet();
            DataSet DSHead = new DataSet();

            Data d = new Data();
            d = Session["Data"] as Data;
            Int64 StateId = Obj.strtoint64(Session["StateId"].ToString());
            int CurrentMonth = Obj.strtoint(ddlMonth.SelectedValue.ToString());
            int SMonth = Obj.RptGetSmonth(CurrentMonth);
            int EMonth = Obj.RptGetEmonth(CurrentMonth);
            int CurrentYear = Obj.strtoint(ddlYear.SelectedValue.ToString());
            string period = Obj.RptGetPeriod(CurrentMonth, CurrentYear);
            Int64 CompanyId = Obj.strtoint64(ddlCompany.SelectedValue.ToString());


            Ds = Obj.GetMonthly(SMonth, CurrentYear, d.HType, StateId, txtRefNo.Text, CompanyId, EMonth);
            DsSummary = Obj.GetMonthlySummary(SMonth, CurrentYear, d.HType, StateId, CompanyId, EMonth);

            DSHead = Obj.RptGetHeaderDetails(CompanyId, d.HType, txtRefNo.Text, period);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            if (chkchart.Checked == true)
            {
                ReportViewer1.LocalReport.ReportPath = "Reports\\MonthlyChart.rdlc";
            }
            else
            {
                ReportViewer1.LocalReport.ReportPath = "Reports\\MonthlyData.rdlc";
            }
            
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportDataSource RDS = new ReportDataSource("RptMonthly", Ds.Tables[0]);
            ReportDataSource RDS1 = new ReportDataSource("RptMonthlySummary", DsSummary.Tables[0]);
            ReportDataSource RDS2 = new ReportDataSource("DSHead", DSHead.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Add(RDS);
            ReportViewer1.LocalReport.DataSources.Add(RDS1);
            ReportViewer1.LocalReport.DataSources.Add(RDS2);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("MonthlyData.cs", "BindReport", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }

    }
}