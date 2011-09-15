using System;
using Open311API;
using Open311API.Exception;
using Open311API.ServiceRequest;
using Open311API.Structs;
using Open311API.RequestListingOptions;

namespace Sample
{
	/// <summary>
	/// A simple example that uses the Open311API class library.
	/// </summary>
	class Open311Sample
	{
		// The development endpoint for the Baltimore City Open311 API.
		const string ENDPOINT = "http://311test.baltimorecity.gov/open311/v2/";
		
		// The jurisdiction ID for Washington DC.
		const string JURISDICTION_ID = "baltimorecity.gov";
		
		// Sample service request ID.
		const string SERVICE_RQUEST_ID = "4e6cbd2a9dc2f112940000bc";
		
		// Sample service code.
		const string SERVICE_CODE = "4e39a3abd3e2c20ed8000027";
		
		// App entry point.
		public static void Main (string[] args)
		{
			// Create a new instance of the Open311 object.
			Open311 report = new Open311(ENDPOINT, JURISDICTION_ID);
			
			// Sample service discovery.
			//Console.WriteLine(ServiceDiscovery(report, ResponseFormat.XML));
			
			// Sample retrieving service list.
			//Console.WriteLine(GetServiceList(report, ResponseFormat.XML));
			
			// Sample get service defenition.
			//Console.WriteLine(GetServiceDefinition(report, ResponseFormat.XML, SERVICE_CODE));
			
			// Sample retrieveing a service request.
			Console.WriteLine(GetServiceRequest(report, ResponseFormat.XML, SERVICE_RQUEST_ID));
			
			// Sample retrieving multiple requests.
			//Options options = new Options();
			//options.Service_code = SERVICE_CODE;
			//Console.WriteLine(GetServiceReqeusts(report, ResponseFormat.XML, options));
			
		}
		
		// Method to perform service discovery.
		public static string ServiceDiscovery(Open311 report, string format)
		{
			try 
			{				
				return report.ServiceDiscovery(format);
			}
			catch (Open311Exception ex) 
			{
				 return "Sorry. An error occured: " + ex.Message;
			}	
		}
		
		// Method to retrieve list of availalbe services.
		public static string GetServiceList(Open311 report, string format) 
		{
			try 
			{
				return report.GetServiceList(format);
			}
			catch (Open311Exception ex)
			{
				return "Sorry. An error occured: " + ex.Message;
			}
		}
		
		// Method to retrieve specifics of a service defentition.
		public static string GetServiceDefinition(Open311 report, string format, string service_code)
		{
			try 
			{
				return report.GetServiceDefinition(format, service_code);
			}
			catch (Open311Exception ex)
			{
				return "Sorry. An error occured: " + ex.Message;
			}
		}
		
		// Method to retireve a specific service request.
		public static string GetServiceRequest(Open311 report, string format, string service_request_id)
		{
			try 
			{				
				return report.GetServiceRequest(format, service_request_id);
			}
			catch (Open311Exception ex) 
			{
				return "Sorry. An error occured: " + ex.Message;
			}
		}
		
		public static string GetServiceReqeusts(Open311 report, string format, Options options) 
		{
			try 
			{				
				return report.GetServiceRequests(format, options);
			}
			catch (Open311Exception ex) 
			{
				return "Sorry. An error occured: " + ex.Message;
			}
		}
	}
}