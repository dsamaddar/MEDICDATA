using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class site : System.Web.UI.MasterPage
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
                    int UserType = Obj.strtoint(Session["UserType"].ToString());
                    if (UserType == 1)
                    {
                        HospitalMenu.Visible = true;
                        UsersMenu.Visible = true;
                        PermissionMenu.Visible = true;
                        StateMenu.Visible = true;
                    }
                    else if (UserType == 2)
                    {
                        HospitalMenu.HRef = "AddHospital.aspx";
                        HospitalMenu.Visible = true;
                        UsersMenu.Visible = true;
                    }
                    else if (UserType == 2)
                    {

                    }
                    SetSiteLogo(UserType);
                    Permissionset();
                    LoginUserName.InnerText = Session["UserName"].ToString();
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    public void SetSiteLogo(int UserType)
    {
        try
        {
            if (UserType == 1)
            {
                divSiteLogo.Attributes.Add("class", "form-inline mx-auto search-form jamx_logo1");
            }
            else if (UserType == 2)
            {
                divSiteLogo.Attributes.Add("class", "form-inline mx-auto search-form jamx_logo");
            }
            else if (UserType == 3)
            {
                divSiteLogo.Attributes.Add("class", "form-inline mx-auto search-form jamx_logo1");
            }
            else if (UserType == 4)
            {
                divSiteLogo.Attributes.Add("class", "form-inline mx-auto search-form jamx_logo");
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "SetSiteLogo", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    private void Permissionset()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj.GetPermission(Obj.strtoint(Session["UserType"].ToString()));
            if (Obj.chkdataset(Ds))
            {
                foreach (DataRow Row in Ds.Tables[0].Rows)
                {
                    LinkButton lnkbtn = (LinkButton)this.FindControl("Menu" + Row["MenuId"].ToString());
                    if (lnkbtn != null)
                    {
                        lnkbtn.Visible = true;
                        this.FindControl("PMenu" + Row["PMenuId"].ToString()).Visible = true;
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Permissionset", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void txtLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Default.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "txtLogout_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    /*OPD Entry*/
    protected void lnkgennewcasemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 1;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) GENERAL NEW CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkgennewcasemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkgennewcasefemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 1;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) GENERAL NEW CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkgennewcasefemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkgenoldcasemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 1;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) GENERAL OLD CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkgenoldcasemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkgenoldcasefemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 1;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) GENERAL OLD CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkgenoldcasefemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkmccnewcasemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 2;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) MCC NEW CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkmccnewcasemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkmccnewcasefemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 2;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) MCC NEW CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkmccnewcasefemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkmccoldcasemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 2;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) MCC OLD CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkmccoldcasemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkmccoldcasefemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 2;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "OUTPATIENT CASES AND ATTENDANCE (DOPCA) MCC OLD CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkmccoldcasefemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    /*SOO (STATE) - By Jaydip - START*/
    /*GENERAL*/
    protected void lnkOPDMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 7;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) GENERAL OUT-PATIENT MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkOPDFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 7;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) GENERAL OUT-PATIENT FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkIPDMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 29;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) GENERAL IN-PATIENT MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkIPDFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 29;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) GENERAL IN-PATIENT FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    /*MCC*/
    protected void lnkOPDMaleMCC_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 8;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) MCC OUT-PATIENT MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkOPDFemaleMCC_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 8;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) MCC OUT-PATIENT FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkIPDMaleMCC_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 31;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) MCC IN-PATIENT MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDMaleMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkIPDFemaleMCC_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 2;
            D.HType = 31;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "ATTENDANCE BY STATE OF ORIGIN (SOO) MCC IN-PATIENT FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDFemaleMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }


    /*CIPD GENERATOR(CASES)*/
    protected void lnkOneYearMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 101;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (CASES) MALE [<1 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkFourYearMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 102;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (CASES) MALE [1-4 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkFourtineMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 103;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (CASES) MALE [5-14 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnlFourtiNineMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 104;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (CASES) MALE [15-49 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkFiftyMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 105;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (CASES) MALE [>50 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkOneYearFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 106;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (CASES) FEMALE [<1 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkFourYearFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 107;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (CASES) FEMALE [1-4 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkFourtineFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 108;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (CASES) FEMALE [5-14 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnlFourtiNineFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 109;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (CASES) FEMALE [15-49 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkFiftyFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 110;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (CASES) FEMALE [>50 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }


    /*CIPD GENERATOR(DEATH)*/
    protected void lnkdOneYearMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 101;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (DEATH) MALE [<1 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdFourYearMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 102;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (DEATH) MALE [1-4 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdFourtineMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 103;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (DEATH) MALE [5-14 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnldFourtiNineMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 104;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (DEATH) MALE [15-49 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdFiftyMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 105;
            //D.CaseType = 3;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "CIPD GENERATOR (DEATH) MALE [>50 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkdOneYearFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 106;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (DEATH) FEMALE [<1 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdFourYearFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 107;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (DEATH) FEMALE [1-4 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdFourtineFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 108;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (DEATH) FEMALE [5-14 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkOPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnldFourtiNineFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 109;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (DEATH) FEMALE [15-49 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkdFiftyFemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 3;
            D.HType = 110;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "CIPD GENERATOR (DEATH) FEMALE [>50 YR]";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkIPDFemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    /*By Jaydip - END*/

    /*IPD Entry*/
    protected void IPDlnkgennewcasemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 4;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "DOPCA GENERAL IN PATIENTS NEW CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);

        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkgennewcasemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkgenoldcasemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 4;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "DOPCA GENERAL IN PATIENTS OLD CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkgenoldcasemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkmccnewcasemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 5;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "DOPCA MCC IN PATIENTS NEW CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkmccnewcasemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkmccoldcasemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 5;
            D.CaseType = 2;
            D.GenderType = 1;
            D.FrmTitle = "DOPCA MCC IN PATIENTS OLD CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkmccoldcasemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void IPDlnkgennewcasefemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 4;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "DOPCA GENERAL IN PATIENTS NEW CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkgennewcasefemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkgenoldcasefemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 4;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "DOPCA GENERAL IN PATIENTS OLD CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkgenoldcasefemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkmccnewcasefemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 5;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "DOPCA MCC IN PATIENTS NEW CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkmccnewcasefemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkmccoldcasefemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 1;
            D.HType = 5;
            D.CaseType = 2;
            D.GenderType = 2;
            D.FrmTitle = "DOPCA MCC IN PATIENTS OLD CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkmccoldcasefemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    //OPD Report
    protected void lnkgenmonthly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 1;
            D.FrmTitle = "DOPCA GENERAL OUT PATIENTS MONTHLY DATA";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkgenmonthly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkgenquarterly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 1;
            D.FrmTitle = "DOPCA GENERAL OUT PATIENTS QUARTERLY DATA";
            Session["Data"] = D;
            Response.Redirect("QuarterlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkgenquarterly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkgenyearly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 1;
            D.FrmTitle = "DOPCA GENERAL OUT PATIENTS YEARLY DATA";
            Session["Data"] = D;
            Response.Redirect("YearlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkgenyearly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkmccmonthly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 2;
            D.FrmTitle = "DOPCA MCC OUT PATIENTS MONTHLY DATA";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkmccmonthly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkmccquarterly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 2;
            D.FrmTitle = "DOPCA MCC OUT PATIENTS QUARTERLY DATA";
            Session["Data"] = D;
            Response.Redirect("QuarterlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkmccquarterly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkmccyearly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 2;
            D.FrmTitle = "DOPCA MCC OUT PATIENTS YEARLY DATA";
            Session["Data"] = D;
            Response.Redirect("YearlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkmccyearly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void lnkcommonthly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 3;
            D.FrmTitle = "DOPCA COMPLEX OUT PATIENTS MONTHLY DATA";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkcommonthly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkcomquarterly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 3;
            D.FrmTitle = "DOPCA COMPLEX OUT PATIENTS QUARTERLY DATA";
            Session["Data"] = D;
            Response.Redirect("QuarterlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkcomquarterly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void lnkcomyearly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 3;
            D.FrmTitle = "DOPCA COMPLEX OUT PATIENTS YEARLY DATA";
            Session["Data"] = D;
            Response.Redirect("YearlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "lnkcomyearly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    //IPD Report
    protected void IPDlnkgenmonthly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 4;
            D.FrmTitle = "DOPCA GENERAL IN PATIENTS MONTHLY DATA";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkgenmonthly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkgenquarterly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 4;
            D.FrmTitle = "DOPCA GENERAL IN PATIENTS QUARTERLY DATA";
            Session["Data"] = D;
            Response.Redirect("QuarterlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkgenquarterly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkgenyearly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 4;
            D.FrmTitle = "DOPCA GENERAL IN PATIENTS YEARLY DATA";
            Session["Data"] = D;
            Response.Redirect("YearlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkgenyearly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void IPDlnkmccmonthly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 5;
            D.FrmTitle = "DOPCA MCC IN PATIENTS MONTHLY DATA";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkmccmonthly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkmccquarterly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 5;
            D.FrmTitle = "DOPCA MCC IN PATIENTS QUARTERLY DATA";
            Session["Data"] = D;
            Response.Redirect("QuarterlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkmccquarterly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkmccyearly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 5;
            D.FrmTitle = "DOPCA MCC IN PATIENTS YEARLY DATA";
            Session["Data"] = D;
            Response.Redirect("YearlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkmccyearly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void IPDlnkcommonthly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 6;
            D.FrmTitle = "DOPCA COMPLEX IN PATIENTS MONTHLY DATA";
            Session["Data"] = D;
            Response.Redirect("MonthlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkcommonthly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkcomquarterly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 6;
            D.FrmTitle = "DOPCA COMPLEX IN PATIENTS QUARTERLY DATA";
            Session["Data"] = D;
            Response.Redirect("QuarterlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkcomquarterly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void IPDlnkcomyearly_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 6;
            D.FrmTitle = "DOPCA COMPLEX IN PATIENTS YEARLY DATA";
            Session["Data"] = D;
            Response.Redirect("YearlyData.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "IPDlnkcomyearly_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    /*Active Menu*/
    /*public string CurrentPageName { get; set; }
    public string IsCurrentPage(string itemName)
    {
        
        //return CurrentPageName == itemName ? "class='active'" : string.Empty;
    }*/


    /*DeathEntry START*/
    /*General*/
    protected void opdlnkgendeath_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 22;
            D.FrmTitle = "OUT PATIENT DEATH GENERAL";
            Session["Data"] = D;
            Response.Redirect("DeathsList.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "opdlnkgendeath_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ipdlnkgendeath_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 23;
            D.FrmTitle = "IN PATIENT DEATH GENERAL";
            Session["Data"] = D;
            Response.Redirect("DeathsList.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ipdlnkgendeath_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    /*MCC*/
    protected void opdlnkmccdeath_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 25;
            D.FrmTitle = "OUT PATIENT DEATH MCC";
            Session["Data"] = D;
            Response.Redirect("DeathsList.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "opdlnkmccdeath_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ipdlnkmccdeath_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.HType = 26;
            D.FrmTitle = "IN PATIENT DEATH MCC";
            Session["Data"] = D;
            Response.Redirect("DeathsList.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ipdlnkmccdeath_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    /*DeathEntry END*/


    /*A&S DISTR GENERAL*/
    protected void ASDGlnkgenadmissionmale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 10;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "AGE AND SEX DISTRIBUTION BY ADMISSION AND THE TOTAL OUTCOME GENERAL - ADMISSION MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDGlnkgenadmissionmale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDGlnkgenadmissionfemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 10;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "AGE AND SEX DISTRIBUTION BY ADMISSION AND THE TOTAL OUTCOME GENERAL - ADMISSION FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDGlnkgenadmissionfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDGlnkgendeathmale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 11;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "AGE AND SEX DISTRIBUTION BY ADMISSION AND THE TOTAL OUTCOME GENERAL - DEATH MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDGlnkgendeathmale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDGlnkgendeathfemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 11;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "AGE AND SEX DISTRIBUTION BY ADMISSION AND THE TOTAL OUTCOME GENERAL - DEATH FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDGlnkgendeathfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }


    /*A&S DISTR MCC*/
    protected void ASDGlnkmccadmissionmale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 12;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "AGE AND SEX DISTRIBUTION BY ADMISSION AND THE TOTAL OUTCOME MCC - ADMISSION MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDGlnkmccadmissionmale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDGlnkmccadmissionfemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 12;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "AGE AND SEX DISTRIBUTION BY ADMISSION AND THE TOTAL OUTCOME MCC - ADMISSION FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDGlnkmccadmissionfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDGlnkmccdeathmale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 13;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "AGE AND SEX DISTRIBUTION BY ADMISSION AND THE TOTAL OUTCOME MCC - DEATH MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDGlnkmccdeathmale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDGlnkmccdeathfemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 13;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "AGE AND SEX DISTRIBUTION BY ADMISSION AND THE TOTAL OUTCOME MCC - DEATH FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDGlnkmccdeathfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }


    /*A&S DISTR OPT CAUSALTY GENERAL*/
    protected void ASDOGlnkgenadmissionmale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 16;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW  CASES DEATH BY AGE GROUP SEX GENERAL - ADMISSION MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDOGlnkgenadmissionmale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDOGlnkgenadmissionfemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 16;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW  CASES DEATH BY AGE GROUP SEX GENERAL - ADMISSION FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDOGlnkgenadmissionfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDOGlnkgendeathmale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 17;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW  CASES DEATH BY AGE GROUP SEX GENERAL - DEATH MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDOGlnkgendeathmale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDOGlnkgendeathfemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 17;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW  CASES DEATH BY AGE GROUP SEX GENERAL - DEATH FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDOGlnkgendeathfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }



    /*A&S DISTR OPT CAUSALITY MCC*/
    protected void ASDOGlnkmccadmissionmale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 18;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW  CASES DEATH BY AGE GROUP SEX MCC - ADMISSION MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDOGlnkgendeathfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDOGlnkmccadmissionfemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 18;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW  CASES DEATH BY AGE GROUP SEX MCC - ADMISSION FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDOGlnkgendeathfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDOGlnkmccdeathmale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 19;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW  CASES DEATH BY AGE GROUP SEX MCC - DEATH MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDOGlnkgendeathfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void ASDOGlnkmccdeathfemale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 4;
            D.HType = 19;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "OUT-PATIENT CASUALITY NEW  CASES DEATH BY AGE GROUP SEX MCC - DEATH FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "ASDOGlnkgendeathfemale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    /*CIPD GENERATOR(DEATH)*/

    /*Changes  - 23 Sept 19 : - Jaydip*/
    protected void Menu101_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 150;
            D.FrmTitle = "ALLOCATION OF HOSPITAL BEDS GENERAL";
            Session["DataAlloc"] = D;
            Response.Redirect("AllocationHosptBEDS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu101_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu102_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 151;
            D.FrmTitle = "ALLOCATION OF HOSPITAL BEDS MCC";
            Session["DataAlloc"] = D;
            Response.Redirect("AllocationHosptBEDS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu102_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu103_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 152;
            D.FrmTitle = "ALLOCATION OF HOSPITAL BEDS COMPLEX";
            Session["DataAlloc"] = D;
            Response.Redirect("AllocationHosptBEDS.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu103_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu104_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 155;
            D.FrmTitle = "BLINDNESS PREVENTION DATA GENERAL";
            Session["DataAlloc"] = D;
            Response.Redirect("BlindnessPrevProg.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu104_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu105_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 156;
            D.FrmTitle = "BLINDNESS PREVENTION DATA MCC";
            Session["DataAlloc"] = D;
            Response.Redirect("BlindnessPrevProg.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu105_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu106_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 157;
            D.FrmTitle = "BLINDNESS PREVENTION DATA COMPLEX";
            Session["DataAlloc"] = D;
            Response.Redirect("BlindnessPrevProg.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu106_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu107_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 160;
            D.FrmTitle = "DENTAL PROCEDURES";
            Session["DataAlloc"] = D;
            Response.Redirect("DentalProcedures.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu107_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu108_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 161;
            D.FrmTitle = "DENTAL PROCEDURES";
            Session["DataAlloc"] = D;
            Response.Redirect("DentalProcedures.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu108_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu109_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 162;
            D.FrmTitle = "DENTAL PROCEDURES";
            Session["DataAlloc"] = D;
            Response.Redirect("DentalProcedures.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu109_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu110_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 165;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION GENERAL";
            Session["DataAlloc"] = D;
            Response.Redirect("MaternalHealth.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu110_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu111_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 166;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION MCC";
            Session["DataAlloc"] = D;
            Response.Redirect("MaternalHealth.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu111_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu112_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 167;
            D.FrmTitle = "MATERNAL HEALTH SERVICES INFORMATION COMPLEX";
            Session["DataAlloc"] = D;
            Response.Redirect("MaternalHealth.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu112_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void Menu113_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 170;
            D.FrmTitle = "LIVE BIRTH WEIGHT BY SEX GENERAL";
            Session["DataAlloc"] = D;
            Response.Redirect("LiveBirthWeight.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu113_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu114_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 171;
            D.FrmTitle = "LIVE BIRTH WEIGHT BY SEX MCC";
            Session["DataAlloc"] = D;
            Response.Redirect("LiveBirthWeight.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu114_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void Menu115_Click(object sender, EventArgs e)
    {
        try
        {
            DataAlloc D = new DataAlloc();
            D.HType = 172;
            D.FrmTitle = "LIVE BIRTH WEIGHT BY SEX COMPLEX";
            Session["DataAlloc"] = D;
            Response.Redirect("LiveBirthWeight.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "Menu115_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    /*Changes  - 23 Sept 19 : - Jaydip*/

    /*MISCELLANEOUS MENU*/
    protected void MisGenMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 10;
            D.HType = 1;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "MISCELLANEOUS GENERAL NEW CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "MisGenMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void MisGenFeMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 10;
            D.HType = 1;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "MISCELLANEOUS GENERAL NEW CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "MisGenFeMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void MisMCCMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 10;
            D.HType = 2;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "MISCELLANEOUS MCC NEW CASE MALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "MisMCCMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void MisMCCFeMale_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 10;
            D.HType = 2;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "MISCELLANEOUS MCC NEW CASE FEMALE";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "MisMCCFeMale_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }

    protected void OutPatientMaleDeathGeneral_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 15;
            D.HType = 1;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "PATIENT DEATH GENERAL OUT PATIENT TOTAL MALE DEATH";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "OutPatientMaleDeathGeneral_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void OutPatientFeMaleDeathGeneral_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 15;
            D.HType = 1;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "PATIENT DEATH GENERAL OUT PATIENT TOTAL FEMALE DEATH";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "OutPatientFeMaleDeathGeneral_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void OutPatientMaleDeathMCC_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 15;
            D.HType = 2;
            D.CaseType = 1;
            D.GenderType = 1;
            D.FrmTitle = "PATIENT DEATH MCC OUT PATIENT TOTAL MALE DEATH";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "OutPatientMaleDeathMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void OutPatientFeMaleDeathMCC_Click(object sender, EventArgs e)
    {
        try
        {
            Data D = new Data();
            D.GroupId = 15;
            D.HType = 2;
            D.CaseType = 1;
            D.GenderType = 2;
            D.FrmTitle = "PATIENT DEATH MCC OUT PATIENT TOTAL FEMALE DEATH";
            Session["Data"] = D;
            Response.Redirect("CaseDetails.aspx", false);
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Site.master.cs", "OutPatientFeMaleDeathMCC_Click", Ex.Message, System.DateTime.Now.ToString());
        }
    }
}