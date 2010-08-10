using System;
using Open311API;
using Open311API.Exception;
using Open311API.ServiceRequest;
using Open311API.Structs;

namespace Sample
{
	/// <summary>
	/// A simple example that uses the Open311API class library.
	/// </summary>
	class MainClass
	{
		// The development endpoint for the Washington DC Open311 API.
		const string ENDPOINT = "http://api.dc.gov/open311/v2_dev";
		
		// The jurisdiction ID for Washington DC.
		const string JURISDICTION_ID = "dc.gov";
		
		// A faux API key. No key needed for most calls to dev endpoint.
		const string API_KEY = "1234567890abcdefghijklmnopqrstuvwxyz";
		
		// Parking meter service code. Currently the only one enabled for DC.
		const string SERVICE_CODE = "S0276";
		
		public static void Main (string[] args)
		{
			try 
			{				
				Open311 myOpen311 = new Open311(ENDPOINT, JURISDICTION_ID, API_KEY);
				//Console.WriteLine(myOpen311.GetServiceDefinition(ResponseFormat.JSON, SERVICE_CODE));
				Console.WriteLine(myOpen311.GetServiceList("json"));
			}
			catch (Open311Exception ex) 
			{
				Console.WriteLine("Sorry. An error occured: " + ex.Message);
			}
						
		}
	}
}
