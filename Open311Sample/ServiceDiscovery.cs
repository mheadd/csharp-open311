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
	class ServiceDiscovery
	{
		// The development endpoint for the Baltimore City Open311 API.
		const string ENDPOINT = "http://311test.baltimorecity.gov/open311/";
		
		// The jurisdiction ID for Washington DC.
		const string JURISDICTION_ID = "baltimorecity.gov";
		
		public static void _Main (string[] args)
		{
			try 
			{				
				Open311 report = new Open311(ENDPOINT, JURISDICTION_ID);
				Console.WriteLine(report.ServiceDiscovery("json"));
			}
			catch (Open311Exception ex) 
			{
				Console.WriteLine("Sorry. An error occured: " + ex.Message);
			}
						
		}
	}
}
