using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClassBank
/// </summary>
public class ClassBank
{
	public ClassBank()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FAB"].ToString());
    SqlCommand cm;
    SqlDataAdapter da;
    DataTable dt;

    public DataTable GetBankData()
    {
        cm = new SqlCommand("GetBankData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cm);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public void InsertBankData(Int32 BankID, String Address, Int32 City_Id, Int32 Area_Id)
    {
        cm = new SqlCommand("InsertBankData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@BankID", BankID);
        cm.Parameters.AddWithValue("@Address", Address);
        cm.Parameters.AddWithValue("@City_Id", City_Id);
        cm.Parameters.AddWithValue("@Area_Id", Area_Id);
        cm.ExecuteNonQuery();
        cn.Close();
    }
    public void UpdateBankData(Int32 Bank_Id, Int32 BankID, String Address, Int32 City_Id, Int32 Area_Id)
    {
        cm = new SqlCommand("UpdateBankData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@Bank_Id", Bank_Id);
        cm.Parameters.AddWithValue("@BankID", BankID);
        cm.Parameters.AddWithValue("@Address", Address);
        cm.Parameters.AddWithValue("@City_Id", City_Id);
        cm.Parameters.AddWithValue("@Area_Id", Area_Id);
        cm.ExecuteNonQuery();
        cn.Close();
    }
    public void DeleteBankData(Int32 Bank_Id)
    {
        cm = new SqlCommand("DeleteBankData", cn);
        cm.CommandType = CommandType.StoredProcedure;
        cn.Open();
        cm.Parameters.AddWithValue("@Bank_Id", Bank_Id);
        cm.ExecuteNonQuery();
        cn.Close();
    }
}