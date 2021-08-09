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
                if (Session["UserId"] != null)
                {
                    Permissionset();
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Home.cs", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    private void Permissionset()
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetPermission(Obj.strtoint(Session["UserType"].ToString()));
            if (Obj.chkdataset(Ds))
            {
                foreach (DataRow Row in Ds.Tables[0].Rows)
                {
                    LinkButton lnkbtn = (LinkButton)this.Master.FindControl("contentplaceholder1").FindControl("Menu" + Row["MenuId"].ToString());
                    if (lnkbtn != null)
                    {
                        lnkbtn.Visible = true;
                        System.Web.UI.HtmlControls.HtmlControl DivLine = (System.Web.UI.HtmlControls.HtmlControl)this.Master.FindControl("contentplaceholder1").FindControl("LineMenu" + Row["MenuId"].ToString());
                        if (DivLine != null)
                        {
                            DivLine.Visible = true;
                        }
                    }

                }
            }
            if (Menu2008.Visible == true)
            {
                divAggRptHeader.Style["display"] = "block";
            }
            else
            {
                divAggRptHeader.Style["display"] = "none";
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Home.cs", "Permissionset", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkDOPCAGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 1;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) GENERAL";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkDOPCAGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkAandSDistGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 10;
            D.HType1 = 11;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "AGE SEX DISTRIBUTION BY ADMISSION GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptAandS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkAandSDistGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkBroughtInDeathGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 22;
            D.HType1 = 23;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "Bought Patient Death Deatils";
            Session["Data"] = D;
            Response.Redirect("RptBoughtPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkBroughtInDeathGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkDOPCAMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 2;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) MCC";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkDOPCAMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkAandSDistMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 12;
            D.HType1 = 13;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "AGE SEX DISTRIBUTION BY ADMISSION MCC";
            Session["Data"] = D;
            Response.Redirect("RptAandS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkAandSDistMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkBroughtInDeathMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 25;
            D.HType1 = 26;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "Bought Patient Death Deatils";
            Session["Data"] = D;
            Response.Redirect("RptBoughtPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkBroughtInDeathMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkDOPCAComplex_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 3;
            D.HType1 = 4;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) COMPLEX";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkDOPCAComplex_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkAandSDistComplex_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 10;
            D.HType1 = 11;
            D.HType2 = 12;
            D.HType3 = 13;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "AGE SEX DISTRIBUTION BY ADMISSION COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptAandS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkAandSDistComplex_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkBroughtInDeathComplex_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 22;
            D.HType1 = 23;
            D.HType2 = 25;
            D.HType3 = 26;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "Patient Death Deatils";
            Session["Data"] = D;
            Response.Redirect("RptBoughtPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkBroughtInDeathComplex_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkSOOGeneral_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 7;
            D.HType1 = 29;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptSOOGeneral.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkSOOGeneral_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkOUTPatientDeathGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 22;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT DEATH GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOUTPatientDeathGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkINPatientDeathGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 23;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "IN-PATIENT DEATH GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkINPatientDeathGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkSOOMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 8;
            D.HType1 = 31;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) MCC";
            Session["Data"] = D;
            Response.Redirect("RptSOOGeneral.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkSOOMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkOUTPatientDeathMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 25;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT DEATH MCC";
            Session["Data"] = D;
            Response.Redirect("RptPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOUTPatientDeathMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkINPatientDeathMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 26;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "IN-PATIENT DEATH MCC";
            Session["Data"] = D;
            Response.Redirect("RptPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkINPatientDeathMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkSOOComplex_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 7;
            D.HType1 = 29;
            D.HType2 = 8;
            D.HType3 = 31;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptSOOGeneral.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkSOOComplex_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkOUTPatientDeathComplex_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 22;
            D.HType1 = 25;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT DEATH COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOUTPatientDeathComplex_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkINPatientDeathComplex_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 23;
            D.HType1 = 26;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "IN-PATIENT DEATH COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptPatientDeath.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkINPatientDeathComplex_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdocng_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 16;
            D.HType1 = 17;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW CASES AND DEATH BY AGE GROUP AND SEX GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptCasualty.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkdocng_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdocnm_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 18;
            D.HType1 = 19;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW CASES AND DEATH BY AGE GROUP AND SEX MCC";
            Session["Data"] = D;
            Response.Redirect("RptCasualty.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkINPatientDeathComplex_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdocnc_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.GroupId = 0;
            D.HType = 16;
            D.HType1 = 17;
            D.HType2 = 18;
            D.HType3 = 19;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW CASES AND DEATH BY AGE GROUP AND SEX COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptCasualty.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkINPatientDeathComplex_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    /*New Report By Jaydip : 04 Oct 19*/
    protected void rptHospitalBedsGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 150;
            D.FrmTitle = "ALLOCATION OF HOSPITAL BEDS GENERAL";
            Session["DataAlloc"] = D;
            Response.Redirect("RptHospitalBeds.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptHospitalBedsGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptHospitalBedsMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 151;
            D.FrmTitle = "ALLOCATION OF HOSPITAL BEDS MCC";
            Session["DataAlloc"] = D;
            Response.Redirect("RptHospitalBeds.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptHospitalBedsMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptHospitalBedsComp_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 152;
            D.FrmTitle = "ALLOCATION OF HOSPITAL BEDS COMPLEX";
            Session["DataAlloc"] = D;
            Response.Redirect("RptHospitalBeds.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptHospitalBedsComp_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void rptPatientOutGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 150;
            D.FrmTitle = "IN-PATIENT ADMISSION AND THEIR OUTCOME";
            Session["DataAlloc"] = D;
            Response.Redirect("RptInPatientAdmission.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptPatientOutGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptPatientOutMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 151;
            D.FrmTitle = "IN-PATIENT ADMISSION AND THEIR OUTCOME";
            Session["DataAlloc"] = D;
            Response.Redirect("RptInPatientAdmission.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptPatientOutMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptPatientOutComp_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 152;
            D.FrmTitle = "IN-PATIENT ADMISSION AND THEIR OUTCOME";
            Session["DataAlloc"] = D;
            Response.Redirect("RptInPatientAdmission.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptPatientOutComp_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void rptBlindnessGEN_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 155;
            D.FrmTitle = "BLINDNESS PREVENTION PROGRAMME UNIT GENERAL";
            Session["DataAlloc"] = D;
            Response.Redirect("RptBlindnessPrevProg.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptBlindnessGEN_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptBlindnessMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 156;
            D.FrmTitle = "BLINDNESS PREVENTION PROGRAMME UNIT MCC";
            Session["DataAlloc"] = D;
            Response.Redirect("RptBlindnessPrevProg.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptBlindnessMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptBlindnessComp_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 157;
            D.FrmTitle = "BLINDNESS PREVENTION PROGRAMME UNIT COMPLEX";
            Session["DataAlloc"] = D;
            Response.Redirect("RptBlindnessPrevProg.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptBlindnessComp_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void rptDentalGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 160;
            D.FrmTitle = "DENTAL PROCEDURE GENERAL";
            Session["DataAlloc"] = D;
            Response.Redirect("RptDentalProcedure.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptDentalGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptDentalMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 161;
            D.FrmTitle = "DENTAL PROCEDURE MCC";
            Session["DataAlloc"] = D;
            Response.Redirect("RptDentalProcedure.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptDentalMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptDentalComp_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 162;
            D.FrmTitle = "DENTAL PROCEDURE COMPLEX";
            Session["DataAlloc"] = D;
            Response.Redirect("RptDentalProcedure.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptDentalComp_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void rptMaternalGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 165;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION";
            Session["DataAlloc"] = D;
            Response.Redirect("RptMaternalHealth.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptMaternalGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptMaternalMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 166;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION";
            Session["DataAlloc"] = D;
            Response.Redirect("RptMaternalHealth.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptMaternalMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptMaternalComp_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 167;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION";
            Session["DataAlloc"] = D;
            Response.Redirect("RptMaternalHealth.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptMaternalComp_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void rptLiveBirthGen_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 170;
            D.FrmTitle = "LIVE BIRTH WEIGHT BY SEX GENERAL";
            Session["DataAlloc"] = D;
            Response.Redirect("RptLiveBirthWeight.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptLiveBirthGen_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptLiveBirthMCC_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 171;
            D.FrmTitle = "LIVE BIRTH WEIGHT BY SEX MCC";
            Session["DataAlloc"] = D;
            Response.Redirect("RptLiveBirthWeight.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptLiveBirthMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void rptLiveBirthComp_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 172;
            D.FrmTitle = "LIVE BIRTH WEIGHT BY SEX COMPLEX";
            Session["DataAlloc"] = D;
            Response.Redirect("RptLiveBirthWeight.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "rptLiveBirthComp_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void CMF12_Click(object sender, EventArgs e)
    {
        ClsDataset Obj = new ClsDataset();
        try
        {
            Data D = new Data();
            D.HType = 101;
            D.HType1 = 110;
            D.FrmTitle = "C.M.F. 12";
            Session["Data"] = D;
            Response.Redirect("RptCMF.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "CMF12_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    //Goverment User Report Added By Ashish(18Jan2020)
    protected void Menu2008_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 10;
            D.FrmTitle = "ADMISSION BY AGE-GROUP GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovABAG.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2008_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2018_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 12;
            D.FrmTitle = "ADMISSION BY AGE-GROUP MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovABAG.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2018_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2048_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "ADMISSION BY AGE-GROUP COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovABAG.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2048_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2005_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 11;
            D.FrmTitle = "DEATH BY AGE-GROUP (IN PATIENTS) GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovDBAGIP.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2005_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2015_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 13;
            D.FrmTitle = "DEATH BY AGE-GROUP (IN PATIENTS) MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovDBAGIP.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2015_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2045_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "DEATH BY AGE-GROUP (IN PATIENTS) COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovDBAGIP.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2045_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2010_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 150;
            D.FrmTitle = "IN-PATIENT STATISTICS GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovIPS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2010_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2020_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 151;
            D.FrmTitle = "IN-PATIENT STATISTICS MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovIPS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2020_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2050_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "IN-PATIENT STATISTICS COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovIPS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2050_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2002_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 165;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovMHSI.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2002_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2012_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 166;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovMHSI.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2012_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2042_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovMHSI.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2042_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2009_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 1;
            D.FrmTitle = "MISCELLANEOUS ATTENDANCES GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovMA.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2009_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2019_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 2;
            D.FrmTitle = "MISCELLANEOUS ATTENDANCES MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovMA.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2019_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2049_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "MISCELLANEOUS ATTENDANCES COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovMA.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2049_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2003_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 1;
            D.FrmTitle = "NEW CASES OUT-PATIENT CONSULTANT CLINIC GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovNCOPCC.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2003_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2013_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 2;
            D.FrmTitle = "NEW CASES OUT-PATIENT CONSULTANT CLINIC MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovNCOPCC.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2013_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2043_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "NEW CASES OUT-PATIENT CONSULTANT CLINIC COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovNCOPCC.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2043_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2004_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 1;
            D.FrmTitle = "OLD CASES OUT-PATIENT CONSULTANT CLINIC GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovOCOPCC.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2004_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2014_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 2;
            D.FrmTitle = "OLD CASES OUT-PATIENT CONSULTANT CLINIC MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovOCOPCC.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2014_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2044_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "OLD CASES OUT-PATIENT CONSULTANT CLINIC COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovOCOPCC.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2044_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2006_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 1;
            D.FrmTitle = "OUT-PATIENT TOTAL ATTENDANCES GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovOPTA.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2006_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2016_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 2;
            D.FrmTitle = "OUT-PATIENT TOTAL ATTENDANCES MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovOPTA.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2016_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2046_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "OUT-PATIENT TOTAL ATTENDANCES COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovOPTA.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2046_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2007_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 16;
            D.FrmTitle = "OUT-PATIENTS NEW CASES BY AGE-GROUP GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovOPNCBAG.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2007_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2017_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 12;
            D.FrmTitle = "OUT-PATIENTS NEW CASES BY AGE-GROUP MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovOPNCBAG.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2017_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2047_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.FrmTitle = "OUT-PATIENTS NEW CASES BY AGE-GROUP COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovOPNCBAG.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2047_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2001_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 7;
            D.HType1 = 29;
            D.FrmTitle = "UTILIZATION OF HOSPITALS SERVICE ACCORDING TO STATE OF ORIGIN GENERAL";
            Session["Data"] = D;
            Response.Redirect("RptGovUOHSATSOO.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2001_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2011_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 8;
            D.HType1 = 31;
            D.FrmTitle = "UTILIZATION OF HOSPITALS SERVICE ACCORDING TO STATE OF ORIGIN MCC";
            Session["Data"] = D;
            Response.Redirect("RptGovUOHSATSOO.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2011_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2041_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = -100;
            D.HType1 = -100;
            D.FrmTitle = "UTILIZATION OF HOSPITALS SERVICE ACCORDING TO STATE OF ORIGIN COMPLEX";
            Session["Data"] = D;
            Response.Redirect("RptGovUOHSATSOO.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2041_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu2051_Click(object sender, EventArgs e)
    {
        try
        {
            //MORBIDITY CASES PATTERN BY GENDER
            //RptGovMCPBG
            Response.Redirect("RptGovMCPBG.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2051_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2052_Click(object sender, EventArgs e)
    {
        try
        {
            //MORBIDITY CASES PATTERN BY AGE
            //RptGovMCPBA
            Response.Redirect("RptGovMCPBA.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2052_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2053_Click(object sender, EventArgs e)
    {
        try
        {
            //MORBIDITY DEATH PATTERN BY GENDER
            //RptGovMDPBG
            Response.Redirect("RptGovMDPBG.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2053_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu2054_Click(object sender, EventArgs e)
    {
        try
        {
            //MORBIDITY DEATH PATTERN BY AGE
            //RptGovMDPBA
            Response.Redirect("RptGovMDPBA.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu2054_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
}