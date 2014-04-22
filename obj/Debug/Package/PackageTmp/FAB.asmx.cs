using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Configuration;

namespace WebApplication1
{

    /// <summary>
    /// Summary description for FAB
    /// </summary>
    [WebService(Namespace = "FABwebservice")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FAB : System.Web.Services.WebService
    {
        SqlConnection conn;
        DataTable dt;
        SqlDataAdapter adap;
        

        public FAB()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FAB"].ConnectionString);
        }

        private void initCon()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        [WebMethod]
        public void GetFuelPump()
        {
            adap = new SqlDataAdapter("Select * from Fuelpump_Details", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);
            FuelWS[] fp = new FuelWS[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fp[i] = new FuelWS();
                fp[i].Fuelpump_Id = Convert.ToInt16(dt.Rows[i][0]);
                fp[i].Title = dt.Rows[i][1].ToString();
                fp[i].Address = dt.Rows[i][2].ToString();
                fp[i].City_Id = Convert.ToInt16(dt.Rows[i][3]);
                fp[i].Area_Id = Convert.ToInt16(dt.Rows[i][4]);
                fp[i].Fuel_type = dt.Rows[i][5].ToString();
            }
            JavaScriptSerializer srs = new JavaScriptSerializer();
            Context.Response.Write("{Category:" + srs.Serialize(fp) + "}");
        }
        [WebMethod]
        public void GetBank()
        {
            adap = new SqlDataAdapter("Select * from Bank_Details", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            BankWS[] ws = new BankWS[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws[i] = new BankWS();
                ws[i].Bank_Id = Convert.ToInt16(dt.Rows[i][0]);
                ws[i].BankID = Convert.ToInt16(dt.Rows[i][1]);
                ws[i].Address = dt.Rows[i][2].ToString();
                ws[i].City_Id = Convert.ToInt16(dt.Rows[i][3]);
                ws[i].Area_Id = Convert.ToInt16(dt.Rows[i][4]);
                //ps[i].City_Name = dt.Rows[i][1].ToString();
                //ps[i].Bank_Name = dt.Rows[i][1].ToString();//Convert.ToInt16(dt.Rows[i][0]);
            }

            JavaScriptSerializer srs = new JavaScriptSerializer();
            Context.Response.Write("{Category:" + srs.Serialize(ws) + "}");
        }
        [WebMethod]
        public void GetATM()
        {
            // adap = new SqlDataAdapter("Select * from ATM_Details", conn);

            adap = new SqlDataAdapter("SELECT Area_Details.Area_Name, ATM_Details.Address, City_Details.City_Name, BankList.Bank_Name FROM Area_Details INNER JOIN ATM_Details ON Area_Details.Area_Id = ATM_Details.Area_Id INNER JOIN BankList ON ATM_Details.BankID = BankList.BankID INNER JOIN City_Details ON Area_Details.City_Id = City_Details.City_Id AND ATM_Details.City_Id = City_Details.City_Id", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            ATMWS[] ws = new ATMWS[dt.Rows.Count];
            AreaWS[] aws = new AreaWS[dt.Rows.Count];
            //BankListWS[] bws = new BankListWS[dt.Rows.Count];
            //CityWS[] cws = new CityWS[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws[i] = new ATMWS();
                //  bws[i] = new BankListWS();
                aws[i] = new AreaWS();
                //cws[i] = new CityWS();



                ws[i].Address = dt.Rows[i][1].ToString();
                //cws[i].City_Name = dt.Rows[i][2].ToString();
                aws[i].Area_Name = dt.Rows[i][0].ToString();
                //bws[i].Bank_Name = dt.Rows[i][3].ToString();//Convert.ToInt16(dt.Rows[i][0]);
            }

            JavaScriptSerializer srs = new JavaScriptSerializer();
            Context.Response.Write("{Category:" + srs.Serialize(ws) + "}");
            
        }


        [WebMethod]
        public void GetCity()
        {
            adap = new SqlDataAdapter("Select * from City_Details", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            CityWS[] ws = new CityWS[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws[i] = new CityWS();

                ws[i].City_Id = Convert.ToInt16(dt.Rows[i][0]);
                ws[i].City_Name = dt.Rows[i][1].ToString();
                ws[i].State_Id = Convert.ToInt16(dt.Rows[i][2]);

            }

            JavaScriptSerializer srs = new JavaScriptSerializer();
            Context.Response.Write("{Category:" + srs.Serialize(ws) + "}");
        }

        [WebMethod]
        public void GetArea(String City)
        {
            adap = new SqlDataAdapter("Select Area_Details.Area_Id,Area_Details.Area_Name,Area_Details.City_Id from Area_Details INNER JOIN City_Details ON Area_Details.City_Id = City_Details.City_Id where City_Details.City_Name = '" + City + "'", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            AreaWS[] ws = new AreaWS[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws[i] = new AreaWS();

                ws[i].Area_Id = Convert.ToInt16(dt.Rows[i][0]);
                ws[i].Area_Name = dt.Rows[i][1].ToString();
                ws[i].City_Id = Convert.ToInt16(dt.Rows[i][2]);

            }

            JavaScriptSerializer srs = new JavaScriptSerializer();
            Context.Response.Write("{Category:" + srs.Serialize(ws) + "}");
        }

        [WebMethod]
        public void GetPetrolDetails(String FuelType)
        {


            adap = new SqlDataAdapter("SELECT Fuelpump_Details.Title, Fuelpump_Details.Address, City_Details.City_Name, Area_Details.Area_Name, Fuelpump_Details.Fuel_type FROM Fuelpump_Details INNER JOIN City_Details ON Fuelpump_Details.City_Id = City_Details.City_Id INNER JOIN Area_Details ON Fuelpump_Details.Area_Id = Area_Details.Area_Id WHERE Fuelpump_Details.Fuel_type = '" + FuelType + "'", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);
            FuelWS[] fp = new FuelWS[dt.Rows.Count];
            AreaWS[] aw = new AreaWS[dt.Rows.Count];
            CityWS[] cw = new CityWS[dt.Rows.Count];


            for (int i = 0; i < dt.Rows.Count; i++)
            {

                fp[i] = new FuelWS();
                aw[i] = new AreaWS();
                cw[i] = new CityWS();


                fp[i].Title = dt.Rows[i][0].ToString();
                fp[i].Address = dt.Rows[i][1].ToString();
                aw[i].Area_Name = dt.Rows[i][3].ToString();
                cw[i].City_Name = dt.Rows[i][2].ToString();

            }
            JavaScriptSerializer srs = new JavaScriptSerializer();

            Context.Response.Write("{FuelDetail: " + srs.Serialize(fp) + "}" + "{City :" + srs.Serialize(cw) + "}" + "{Area:-" + srs.Serialize(aw) + "}");


        }

        [WebMethod]
        public void GetFuelByAreaType(String Place, String FuelType)
        {
            adap = new SqlDataAdapter("SELECT Fuelpump_Details.Title, Area_Details.Area_Name, Fuelpump_Details.Address FROM Fuelpump_Details INNER JOIN Area_Details ON Fuelpump_Details.Area_Id = Area_Details.Area_Id WHERE Fuelpump_Details.Fuel_type = '" + FuelType + "' AND Area_Details.Area_Name = '" + Place + "' ", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            FuelWS[] fp = new FuelWS[dt.Rows.Count];
            AreaWS[] aw = new AreaWS[dt.Rows.Count];
            // CityWS[] cw = new CityWS[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fp[i] = new FuelWS();
                aw[i] = new AreaWS();



                fp[i].Title = dt.Rows[i][0].ToString();
                fp[i].Address = dt.Rows[i][2].ToString();
                aw[i].Area_Name = dt.Rows[i][1].ToString();
                //cw[i].City_Name = dt.Rows[i][3].ToString();

            }
            JavaScriptSerializer srs = new JavaScriptSerializer();

            Context.Response.Write("{FuelDetail: " + srs.Serialize(fp) + "}" + "{Area:-" + srs.Serialize(aw) + "}");

        }

        [WebMethod]
        public void GetFuelByCityType(String City, String FuelType)
        {
            adap = new SqlDataAdapter("SELECT Fuelpump_Details.Title, Fuelpump_Details.Address, City_Details.City_Name FROM Fuelpump_Details INNER JOIN City_Details ON Fuelpump_Details.City_Id = City_Details.City_Id WHERE Fuelpump_Details.Fuel_type = '" + FuelType + "' AND City_Details.City_Name = '" + City + "'", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            FuelWS[] fp = new FuelWS[dt.Rows.Count];

            CityWS[] cw = new CityWS[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fp[i] = new FuelWS();
                cw[i] = new CityWS();


                fp[i].Title = dt.Rows[i][0].ToString();
                fp[i].Address = dt.Rows[i][1].ToString();
                cw[i].City_Name = dt.Rows[i][2].ToString();

            }
            JavaScriptSerializer srs = new JavaScriptSerializer();

            Context.Response.Write("{FuelDetail: " + srs.Serialize(fp) + "}" + "{City :" + srs.Serialize(cw) + "}");

        }

        [WebMethod]
        public void GetBankbyArea(String Place, String Bank)
        {
            adap = new SqlDataAdapter("SELECT BankList.Bank_Name, Area_Details.Area_Name, Bank_Details.Address FROM Bank_Details INNER JOIN BankList ON Bank_Details.BankID = BankList.BankID INNER JOIN Area_Details ON Bank_Details.Area_Id = Area_Details.Area_Id WHERE Area_Details.Area_Name = '" + Place + "' AND BankList.Bank_Name = '" + Bank + "'", conn);
            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            AreaWS[] ws = new AreaWS[dt.Rows.Count];
            BankListWS[] bws = new BankListWS[dt.Rows.Count];
            BankWS[] bw = new BankWS[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws[i] = new AreaWS();
                bws[i] = new BankListWS();
                bw[i] = new BankWS();

                //ws[i].Area_Id = Convert.ToInt16(dt.Rows[i][0]);
                ws[i].Area_Name = dt.Rows[i][1].ToString();
                bws[i].Bank_Name = dt.Rows[i][0].ToString();
                bw[i].Address = dt.Rows[i][2].ToString();
                //Convert.ToInt16(dt.Rows[i][2]);

            }

            JavaScriptSerializer srs = new JavaScriptSerializer();
            Context.Response.Write("{Category:" + srs.Serialize(ws) + srs.Serialize(bws) + srs.Serialize(bw) + "}");
        }

        /* [WebMethod]
         public void GetATMbyArea(String Place, String Bank)
         {
             adap = new SqlDataAdapter("SELECT ATM_Details.Address, Area_Details.Area_Name, ATM_Details.Area_Id, BankList.BankID, BankList.Bank_Name FROM Area_Details INNER JOIN ATM_Details ON Area_Details.Area_Id = ATM_Details.Area_Id INNER JOIN BankList ON ATM_Details.BankID = BankList.BankID WHERE  Area_Details. and BankList.Bank_Name= '" + Place + Bank+ "'", conn);
             initCon();
             dt = new DataTable();
             adap.Fill(dt);

             AreaWS[] ws = new AreaWS[dt.Rows.Count];
             BankListWS[] bws = new BankListWS[dt.Rows.Count];

             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 ws[i] = new AreaWS();

                 //ws[i].Area_Id = Convert.ToInt16(dt.Rows[i][0]);
                 ws[i].Area_Name = dt.Rows[i][1].ToString();
                 bws[i].Bank_Name = dt.Rows[i][2].ToString();
                     //Convert.ToInt16(dt.Rows[i][2]);

             }

             JavaScriptSerializer srs = new JavaScriptSerializer();
             Context.Response.Write("{Category:" + srs.Serialize(ws) + "}");
         }*/
        [WebMethod]
        public void GetATMbyArea(String Place, String Bank)
        {
            adap = new SqlDataAdapter("SELECT ATM_Details.Address, BankList.Bank_Name, Area_Details.Area_Name FROM ATM_Details INNER JOIN BankList ON ATM_Details.BankID = BankList.BankID INNER JOIN Area_Details ON ATM_Details.Area_Id = Area_Details.Area_Id WHERE BankList.Bank_Name = '" + Bank + "' AND Area_Details.Area_Name = '" + Place + "'", conn);

            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            AreaWS[] ws = new AreaWS[dt.Rows.Count];
            BankListWS[] bws = new BankListWS[dt.Rows.Count];
            ATMWS[] aws = new ATMWS[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws[i] = new AreaWS();
                bws[i] = new BankListWS();
                aws[i] = new ATMWS();

                //ws[i].Area_Id = Convert.ToInt16(dt.Rows[i][0]);
                ws[i].Area_Name = dt.Rows[i][2].ToString();
                bws[i].Bank_Name = dt.Rows[i][1].ToString();
                aws[i].Address = dt.Rows[i][0].ToString();
                //Convert.ToInt16(dt.Rows[i][2]);

            }

            JavaScriptSerializer srs = new JavaScriptSerializer();
            Context.Response.Write("{Category:" + srs.Serialize(ws) + srs.Serialize(aws) + srs.Serialize(bws) + "}");
        }

        [WebMethod]
        public void GetATMbyCity(String City, String Bank)
        {
            adap = new SqlDataAdapter("SELECT ATM_Details.Address, BankList.Bank_Name, City_Details.City_Name FROM ATM_Details INNER JOIN BankList ON ATM_Details.BankID = BankList.BankID INNER JOIN City_Details ON ATM_Details.City_Id = City_Details.City_Id WHERE BankList.Bank_Name = '" + Bank + "' AND City_Details.City_Name = '" + City + "'", conn);

            initCon();
            dt = new DataTable();
            adap.Fill(dt);

            CityWS[] ws = new CityWS[dt.Rows.Count];
            BankListWS[] bws = new BankListWS[dt.Rows.Count];
            ATMWS[] aws = new ATMWS[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws[i] = new CityWS();
                bws[i] = new BankListWS();
                aws[i] = new ATMWS();

                //ws[i].Area_Id = Convert.ToInt16(dt.Rows[i][0]);
                ws[i].City_Name = dt.Rows[i][2].ToString();
                bws[i].Bank_Name = dt.Rows[i][1].ToString();
                aws[i].Address = dt.Rows[i][0].ToString();
                //Convert.ToInt16(dt.Rows[i][2]);

            }

            JavaScriptSerializer srs = new JavaScriptSerializer();
            Context.Response.Write("{Category:" + srs.Serialize(ws) + srs.Serialize(aws) + srs.Serialize(bws) + "}");
        }

    }
}
