using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Open311API.Exception;
using Open311API.Structs;
using Open311API.ServiceRequest;

namespace Open311API
{
	/// <summary>
	/// Class for interacting with the Open311 API V2.
	/// </summary>
	public class Open311
	{
		// Private class members.
		private string _baseURL;
		private string _jurisdictionID;
		private string _apiKey;
		private string _urlTemplate = "{0}/{1}.{2}?jurisdiction_id={3}&api_key={4}";
		
		/// <summary>
		/// Open311 Class constructor.
		/// </summary>
		/// <param name="baseURL">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="jurisdictionID">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="apiKey">
		/// A <see cref="System.String"/>
		/// </param>
		public Open311(string baseURL, string jurisdictionID, string apiKey)
		{
			_baseURL = baseURL;
			_jurisdictionID = jurisdictionID;
			_apiKey = apiKey;
		}
		
		/// <summary>
		/// Gets a list of acceptable 311 services and associated service code.
		/// </summary>
		/// <param name="format">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public string GetServiceList(string format) 
		{
			string URL = String.Format(_urlTemplate, _baseURL, ResourceNames.Services, format, _jurisdictionID, _apiKey);
			return MakeAPIRequest(URL, MethodType.GET);
		}
		
		/// <summary>
		/// Define attributes associated with a service code.
		/// </summary>
		/// <param name="format">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="serviceCode">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public string GetServiceDefinition(string format, string serviceCode)
		{
			string URL = String.Format(_urlTemplate, _baseURL, ResourceNames.ServiceDefinition, format, _jurisdictionID, _apiKey);
			URL += "&service_code=" + serviceCode;
			return MakeAPIRequest(URL, MethodType.GET);
		}
		
		/// <summary>
		/// Create service requests.
		/// </summary>
		/// <param name="format">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="serviceCode">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="request">
		/// A <see cref="Request"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public string PostServiceRequest(string format, string serviceCode, Request request)
		{
			if(!request.isValid()) 
			{
				throw new Open311Exception("Address cannot be empty if no lat/long provided.");
			}				
			
			StringBuilder URLString = new StringBuilder();			
			URLString.Append(String.Format(_urlTemplate, _baseURL, ResourceNames.ServiceRequest, format, _jurisdictionID, _apiKey));
			URLString.Append("&service_code=" + serviceCode);
			URLString.Append("&lat=" + request.Latitude);
			URLString.Append("&long=" + request.Longitude);
			URLString.Append("&address_string=" + HttpUtility.UrlEncode(request.Address));
			URLString.Append("&address_id=" + request.Address_id);
			URLString.Append("&email=" + HttpUtility.UrlEncode(request.Email));
			URLString.Append("&device_id=" + request.Device_id);
			URLString.Append("&account_id=" + request.Account_id);
			URLString.Append("&first_name=" + request.First_name);
			URLString.Append("&last_name=" + request.Last_name);
			URLString.Append("&phone=" + request.Phone);
			URLString.Append("&description=" + HttpUtility.UrlEncode(request.Description));
			URLString.Append("&media_url=" + request.Media_url);
			
			return MakeAPIRequest(URLString.ToString(), MethodType.POST);			
		}
			
		/// <summary>
		/// Get the request_id from a temporary token. 
		/// This is unnecessary if the response from creating a service request does not contain a token.
		/// </summary>
		/// <param name="format">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="tokenID">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public string GetTokenWithRequestId(string format, int tokenID)
		{
			string URL = String.Format(_urlTemplate, _baseURL, tokenID , format,_jurisdictionID, _apiKey);
			return MakeAPIRequest(URL, MethodType.GET);
		}
		
		/// <summary>
		/// Query the current status of a request.
		/// </summary>
		/// <param name="format">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="serviceRequestID">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public string GetServiceRequests(string format, int serviceRequestID)
		{
			string URL = String.Format(_urlTemplate, _baseURL, ResourceNames.ServiceRequest, format, _jurisdictionID, _apiKey);
			URL += "&service_request_id=" + serviceRequestID;
			return MakeAPIRequest(URL, MethodType.GET);
		}
			
		/// <summary>
		/// Helper method to make the HTTP request to the Open311 API.
		/// </summary>
		/// <param name="URL">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="method">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		private string MakeAPIRequest(string URL, string method) 
		{
			try
			{
				HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
				
				if(method == MethodType.POST)
				{
					request.Method = "POST";	
				}
				
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) 
				{
					StreamReader reader = new StreamReader(response.GetResponseStream());
					return reader.ReadToEnd();
				}	
			}
			
			catch(WebException ex)
			{
				throw new Open311Exception(ex.Message);
			}
		}
	}
}


