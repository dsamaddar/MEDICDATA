using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Home : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();
    //int CMonthId, CYearId;
    //int HType=1, CaseType=1, GenderType=1, StateId=1;

    protected void Page_Load(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("SignIn.aspx", false);
            }
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {                    
                    BindYear();
                    BindMonth();
                    BindDgvCD1();
                    if (HType.Value == "1")
                    {
                        string pagetit = PageTitle.InnerText;
                        PageTitle.InnerText = pagetit + "OPD GENERAL - Deaths";
                    }
                    if (HType.Value == "2")
                    {
                        string pagetit = PageTitle.InnerText;
                        PageTitle.InnerText = pagetit + "OPD MCC - Deaths";
                    }
                    if (HType.Value == "4")
                    {
                        string pagetit = PageTitle.InnerText;
                        PageTitle.InnerText = pagetit + "IPD GENERAL - Deaths";
                    }
                    if (HType.Value == "5")
                    {
                        string pagetit = PageTitle.InnerText;
                        PageTitle.InnerText = pagetit + "IPD MCC - Deaths";
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Deaths.aspx", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
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
            Obj.ErrorLog("Deaths.aspx", "BindYear", Ex.Message.ToString(), System.DateTime.Now.ToString());
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
            Obj.ErrorLog("Deaths.aspx", "BindMonth", Ex.Message.ToString(), System.DateTime.Now.ToString());
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
            Data d = new Data();
            d = Session["Data"] as Data;
            GroupId.Value = d.GroupId.ToString();
            HType.Value = d.HType.ToString();
            CaseType.Value = "0";
            GenderType.Value = "0";
            CreatedBy.Value = Session["UID"].ToString();
            StateId.Value = TStateId.ToString();
            DataSet Ds = new DataSet();
            Int64 CompanyId = Obj.strtoint64(Session["CompanyId"].ToString());
            Ds = Obj.GetCaseDetail(Obj.strtoint(GroupId.Value), month, year, Obj.strtoint(HType.Value), 0, 0, TStateId, CompanyId,"");
            if (Obj.chkdataset(Ds))
            {
                RPTCaseDetails.DataSource = Bindtotalcount(Ds.Tables[0]);
                RPTCaseDetails.DataBind();
                int days = DateTime.DaysInMonth(year, month);
                int TotalDay = Obj.strtoint(Ds.Tables[0].Rows[0]["TotDay"].ToString()) - 2;
                if (TotalDay < 29)
                    hday29.Visible = false;
                else
                    hday29.Visible = true;
                if (TotalDay < 30)
                    hday30.Visible = false;
                else
                    hday30.Visible = true;
                if (TotalDay < 31)
                    hday31.Visible = false;
                else
                    hday31.Visible = true;
            }
            else
            {
                RPTCaseDetails.DataSource = null;
                RPTCaseDetails.DataSource = "";
                RPTCaseDetails.DataBind();
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Deaths.aspx", "BindDgvCD1", Ex.Message.ToString(), System.DateTime.Now.ToString());
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
            Obj.ErrorLog("Deaths.aspx", "Btnsearch_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
    public DataTable Bindtotalcount(DataTable Dt)
    {
        try
        {
            Dt.AcceptChanges();
            int rowcount = 0, colcount = 0;
            Int64 rowsum = 0;
            Int64 colsum = 0;


            colcount = 10;

            while (colcount < Dt.Columns.Count - 7)
            {
                rowcount = 0;
                while (rowcount < Dt.Rows.Count - 1)
                {
                    int smparentid = Obj.strtoint(Dt.Rows[rowcount]["smparentid"].ToString());
                    if (smparentid != 9999)
                    {
                        if (Dt.Rows[rowcount][colcount] != null)
                        {
                            colsum = colsum + Obj.strtoint64(Dt.Rows[rowcount][colcount].ToString());
                        }
                    }
                    else
                    {
                        Dt.Rows[rowcount][colcount] = colsum;
                        colsum = 0;
                    }
                    rowcount = rowcount + 1;
                }
                Dt.Rows[rowcount][colcount] = colsum;
                colsum = 0;
                colcount = colcount + 1;
            }

            rowcount = 0;
            while (rowcount < Dt.Rows.Count)
            {
                //int smparentid = Obj.strtoint(Dt.Rows[rowcount]["smparentid"].ToString());
                //if (smparentid != 9999)
                //{
                colcount = 10;
                while (colcount < Dt.Columns.Count - 7)
                {
                    if (Dt.Rows[rowcount][colcount] != null)
                    {
                        rowsum = rowsum + Obj.strtoint64(Dt.Rows[rowcount][colcount].ToString());
                    }
                    colcount = colcount + 1;
                }
                Dt.Rows[rowcount][colcount] = rowsum;
                rowsum = 0;
                //}
                rowcount = rowcount + 1;
            }

        }
        catch (Exception ex)
        {
            Obj.ErrorLog("CaseDetails.aspx", "Bindtotalcount", ex.Message.ToString(), System.DateTime.Now.ToString());
        }
        return Dt;
    }

    public string abc { get; set; }
}