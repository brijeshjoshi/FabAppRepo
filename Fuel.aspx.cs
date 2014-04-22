using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fuel : System.Web.UI.Page
    {
        FuelPump f = new FuelPump();
        FillDropDown fd = new FillDropDown();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("default.aspx");
            }
            BindData();
            if (!IsPostBack == true)
            {
                FillCity();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            f.InsertFuelData(txtFname.Text, txtFaddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlArea.SelectedValue), Convert.ToString(ddlFtype.SelectedValue));
            BindData();
            ClearData();

        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            f.UpdateFuelData(Convert.ToInt32(txtID.Text), txtFname.Text, txtFaddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlArea.SelectedValue), Convert.ToString(ddlFtype.SelectedValue));
            BindData();
            ClearData();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            f.DeleteFuelData(Convert.ToInt32(txtID.Text));
            BindData();
            ClearData();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        public void BindData()
        {
            gvFuel.DataSource = f.GetFuelData();
            gvFuel.DataBind();
        }
        public void ClearData()
        {
            txtID.Text = "";
            txtFname.Text = "";
            txtFaddress.Text = "";
        }
        public void FillCity()
        {
            ddlCity.DataSource = fd.FillCity();
            ddlCity.DataTextField = "City_Name";
            ddlCity.DataValueField = "City_Id";
            ddlCity.DataBind();
        }
        public void FillArea()
        {
            ddlArea.DataSource = fd.FillArea(Convert.ToInt32(ddlCity.SelectedItem.Value));
            ddlArea.DataTextField = "Area_Name";
            ddlArea.DataValueField = "Area_Id";
            ddlArea.DataBind();
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillArea();
        }
        protected void gvFuel_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Label lblID = (Label)e.Item.FindControl("lblFID");
                txtID.Text = lblID.Text;
                Label lblCno = (Label)e.Item.FindControl("lblTitle");
                txtFname.Text = lblCno.Text;
                Label lblCname = (Label)e.Item.FindControl("lblAddress");
                txtFaddress.Text = lblCname.Text;
                //Label lblAddress = (Label)e.Item.FindControl("lblCity");
                //txtAddress.Text = lblAddress.Text;
                //Label lblCity = (Label)e.Item.FindControl("lblArea");
                //txtCity.Text = lblCity.Text;
                //Label lblState = (Label)e.Item.FindControl("lblFuel");
                //txtSate.Text = lblState.Text;
            }
        }
        protected void gvFuel_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }
        protected void lnbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["Admin"] = null;
            Response.Redirect("default.aspx");
        }
    }
}