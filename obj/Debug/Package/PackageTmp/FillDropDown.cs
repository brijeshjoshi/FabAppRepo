using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FillDropDown
/// </summary>
public class FillDropDown
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FAB"].ToString());
    SqlCommand cm;
    SqlDataAdapter da;
    DataTable dt;

    public FillDropDown()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable FillCity()
    {
        cm = new SqlCommand("FillCity", cn);
        cm.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable FillArea(Int32 City_Id)
    {
        cm = new SqlCommand("FillArea", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cm.Parameters.AddWithValue("@City_Id", City_Id);
        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable FillBank()
    {
        cm = new SqlCommand("FillBank", cn);
        cm.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}