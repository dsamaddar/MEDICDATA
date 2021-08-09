using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    ClsDataset Obj = new ClsDataset();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ContactUs.aspx",false);
            //if (System.IO.File.Exists(Server.MapPath("winapp/MEDICDATA.msi")))
            //{
            //    Response.Redirect("winapp/MEDICDATA.msi");
            //}
            //else
            //{
            //    lblErrormsg.Text = "Unable to find version, Contact to administrator";
            //    lblErrormsg.Visible = true;
            //}
        }
        catch (Exception Ex)
        {
            Obj.ErrorLog("Default.cs", "lnkdownload_Click", Ex.Message.ToString(), System.DateTime.Now.ToString());
        }
    }
}