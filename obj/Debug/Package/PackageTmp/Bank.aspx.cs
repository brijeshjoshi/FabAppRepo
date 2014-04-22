using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Bank : System.Web.UI.Page
    {
        ClassBank a = new ClassBank();
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
                FillBank();
                FillCity();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            a.InsertBankData(Convert.ToInt32(ddlATM.SelectedValue), txtFaddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlArea.SelectedValue));
            BindData();
            ClearData();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            a.UpdateBankData(Convert.ToInt32(txtID.Text), Convert.ToInt32(ddlATM.SelectedValue), txtFaddress.Text, Convert.ToInt32(ddlCity.SelectedValue), Convert.ToInt32(ddlArea.SelectedValue));
            BindData();
            ClearData();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            a.DeleteBankData(Convert.ToInt32(txtID.Text));
            BindData();
            ClearData();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        public void BindData()
        {
            gvBank.DataSource = a.GetBankData();
            gvBank.DataBind();
        }
        public void ClearData()
        {
            txtID.Text = "";
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
        public void FillBank()
        {
            ddlATM.DataSource = fd.FillBank();
            ddlATM.DataTextField = "Bank_Name";
            ddlATM.DataValueField = "BankID";
            ddlATM.DataBind();
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillArea();
        }
        protected void gvBank_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Label lblID = (Label)e.Item.FindControl("lblFID");
                txtID.Text = lblID.Text;
                //Label lblCno = (Label)e.Item.FindControl("lblTitle");
                //txtFname.Text = lblCno.Text;
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
        protected void gvBank_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
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