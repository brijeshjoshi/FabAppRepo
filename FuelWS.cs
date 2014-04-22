using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FuelWS
/// </summary>
public class FuelWS
{
	public FuelWS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Fuelpump_Id { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public int City_Id { get; set; }
    public int Area_Id { get; set; }
    public string Fuel_type { get; set; }
}