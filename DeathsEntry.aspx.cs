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
                    Data d = new Data();
                    d = Session["Data"] as Data;
                    HType.Value = d.HType.ToString();

                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["RecId"] != null)
                        {
                            BindData();
                            ViewState["RecId"] = Request.QueryString["RecId"];
                        }
                    }

                    PageTitle.InnerText = d.FrmTitle;
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("DeathsEntry.cs", "Page_Load", Ex.Message, System.DateTime.Now.ToString());
        }
    }
    protected void btnUpdatebtnUpdateDeaths_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDeceased.Text != "" && txtRefNo.Text != "" && txtAge.Text != "" && rdGender.SelectedValue != "" && txtAddress.Text != "" && txtAdmiddion.Text != "" && txtDateofDeath.Text != "")
            {
                Int64 Result = 0;

                DateTime DOA = new DateTime(1900, 1, 1);
                DOA = Obj.strtodate(txtAdmiddion.Text);

                DateTime DOD = new DateTime(1900, 1, 1);
                DOD = Obj.strtodate(txtDateofDeath.Text);

                int Gender = 0;
                if (rdGender.Items[0].Selected == true)
                {
                    Gender = Obj.strtoint(rdGender.Items[0].Value);
                }
                else
                {
                    Gender = Obj.strtoint(rdGender.Items[1].Value);
                }

                Int64 RecId = 0;
                if (ViewState["RecId"] != null)
                {
                    RecId = Obj.strtoint64(ViewState["RecId"].ToString());
                }
                Int64 StateId = 0;
                if (Session["StateId"] != null)
                {
                    StateId = Obj.strtoint64(Session["StateId"].ToString());
                }
                Int64 CompanyId = 0;
                if (Session["CompanyId"] != null)
                {
                    CompanyId = Obj.strtoint64(Session["CompanyId"].ToString());
                }
                Int64 UserId = 0;
                if (Session["UID"] != null)
                {
                    UserId = Obj.strtoint64(Session["UID"].ToString());
                }
                Result = Obj.SaveDeathsDetails(RecId, Obj.strtoint(HType.Value), StateId, CompanyId, txtDeceased.Text, Gender, Obj.strtoint(txtAge.Text), txtAddress.Text, DOA, DOD, txtcases.Text, UserId, txtRefNo.Text, Environment.MachineName.ToString());
                if (Result != 0)
                {
                    txtDeceased.Text = "";
                    txtAge.Text = "";
                    txtRefNo.Text = "";
                    txtAddress.Text = "";
                    txtAdmiddion.Text = "";
                    txtDateofDeath.Text = "";
                    txtcases.Text = "";
                    lblSuccessmsg.Text = "Successfully saved!";
                    lblSuccessmsg.Visible = true;
                    //Response.Redirect("UserList.aspx", false);
                }
                else
                {
                    lblErrormsg.Text = "Unable to Save record";
                    lblErrormsg.Visible = true;
                }
            }
            else
            {
                lblErrormsg.Text = "Userid, Password, Username, Gender, Date of Birth field required";
                lblErrormsg.Visible = true;
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("AddUser.cs", "SaveData", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }


    public void BindData()
    {
        try
        {
            DataSet Ds = new DataSet();
            Int64 RecId = Obj.strtoint64(Request.QueryString["RecId"]);
            Ds = Obj.GetDeathsMaster(RecId);
            if (Obj.chkdataset(Ds))
            {
                txtDeceased.Text = Ds.Tables[0].Rows[0]["Decease"].ToString();
                txtAge.Text = Ds.Tables[0].Rows[0]["Age"].ToString();
                txtRefNo.Text = Ds.Tables[0].Rows[0]["RefNo"].ToString();
                txtAddress.Text = Ds.Tables[0].Rows[0]["Address"].ToString();
                txtAdmiddion.Text = Ds.Tables[0].Rows[0]["DOA"].ToString();
                txtDateofDeath.Text = Ds.Tables[0].Rows[0]["DOD"].ToString();
                txtcases.Text = Ds.Tables[0].Rows[0]["CausesDeath"].ToString();
                HType.Value = Ds.Tables[0].Rows[0]["HType"].ToString();


                if (Obj.strtoint(Ds.Tables[0].Rows[0]["Sex"].ToString()) == 0)
                {
                    rdGender.Items[0].Selected = false;
                    rdGender.Items[1].Selected = false;
                }
                else if (Obj.strtoint(Ds.Tables[0].Rows[0]["Sex"].ToString()) == 1)
                {
                    rdGender.Items[0].Selected = true;
                }
                else if (Obj.strtoint(Ds.Tables[0].Rows[0]["Sex"].ToString()) == 2)
                {
                    rdGender.Items[1].Selected = true;
                }
            }
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("DeathsEntry.cs", "BindData", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
}