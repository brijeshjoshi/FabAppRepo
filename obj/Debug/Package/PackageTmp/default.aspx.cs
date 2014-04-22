using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Styles
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void sbmit_Click(object sender, EventArgs e)
        {
            String conn = System.Configuration.ConfigurationManager.ConnectionStrings["FAB"].ToString();
            SqlConnection con = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("SELECT User_Id,Password FROM Admin_Detail WHERE User_Id='" + UsrID.Text + "'and Password='" + Pass.Text + "'", con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["Admin"] = UsrID.Text;
                LblMsg.Text = "Login Successfull";
                lnbLogout.Visible = true;
            }
            else
            {
                lnbLogout.Visible = false;
                LblMsg.Text = "Login Unsuccessfull";
            }
        }
        protected void lnbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["Admin"] = null;
            Response.Redirect("default.aspx");
        }
    }
}