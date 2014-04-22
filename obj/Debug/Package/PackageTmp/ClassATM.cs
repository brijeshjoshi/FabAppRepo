using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ATM
/// </summary>
public class ClassATM
{
    public ClassATM()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FAB"].ToString());
    SqlCommand cm;
    SqlDataAdapter da;
    DataTable dt;

    public DataTable GetATMData()
    {
        cm = new SqlCommand("GetATMData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public void InsertATMData(Int32 BankID, String Address, Int32 City_Id, Int32 Area_Id)
    {
        cm = new SqlCommand("InsertATMData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@BankID", BankID);
        cm.Parameters.AddWithValue("@Address", Address);
        cm.Parameters.AddWithValue("@City_Id", City_Id);
        cm.Parameters.AddWithValue("@Area_Id", Area_Id);
        cm.ExecuteNonQuery();
        cn.Close();
    }
    public void UpdateATMData(Int32 ATM_Id, Int32 BankID, String Address, Int32 City_Id, Int32 Area_Id)
    {
        cm = new SqlCommand("UpdateATMData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@ATM_Id", ATM_Id);
        cm.Parameters.AddWithValue("@BankID", BankID);
        cm.Parameters.AddWithValue("@Address", Address);
        cm.Parameters.AddWithValue("@City_Id", City_Id);
        cm.Parameters.AddWithValue("@Area_Id", Area_Id);
        cm.ExecuteNonQuery();
        cn.Close();
    }
    public void DeleteATMData(Int32 ATM_Id)
    {
        cm = new SqlCommand("DeleteATMData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@ATM_Id", ATM_Id);
        cm.ExecuteNonQuery();
        cn.Close();
    }
}