using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Fuel
/// </summary>
public class FuelPump
{
    public FuelPump()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FAB"].ToString());
    SqlCommand cm;
    SqlDataAdapter da;
    DataTable dt;

    public DataTable GetFuelData()
    {
        cm = new SqlCommand("GetFuelData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public void InsertFuelData(String Title,String Address,Int32 City_Id,Int32 Area_Id,String Fuel_type)
    {
        cm = new SqlCommand("InsertFuelData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@Title", Title);
        cm.Parameters.AddWithValue("@Address", Address);
        cm.Parameters.AddWithValue("@City_Id", City_Id);
        cm.Parameters.AddWithValue("@Area_Id", Area_Id);
        cm.Parameters.AddWithValue("@Fuel_type", Fuel_type);
        cm.ExecuteNonQuery();
        cn.Close();
    }
    public void UpdateFuelData(Int32 Fuelpump_Id, String Title, String Address, Int32 City_Id, Int32 Area_Id, String Fuel_type)
    {
        cm = new SqlCommand("UpdateFuelData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@Fuelpump_Id", Fuelpump_Id);
        cm.Parameters.AddWithValue("@Title", Title);
        cm.Parameters.AddWithValue("@Address", Address);
        cm.Parameters.AddWithValue("@City_Id", City_Id);
        cm.Parameters.AddWithValue("@Area_Id", Area_Id);
        cm.Parameters.AddWithValue("@Fuel_type", Fuel_type);
        cm.ExecuteNonQuery();
        cn.Close();
    }
    public void DeleteFuelData(Int32 Fuelpump_Id)
    {
        cm = new SqlCommand("DeleteFuelData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@Fuelpump_Id", Fuelpump_Id);
        cm.ExecuteNonQuery();
        cn.Close();
    }
}