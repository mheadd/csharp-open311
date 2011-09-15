using System;

namespace Open311API.Structs
{
	/// <summary>
	/// API resource names.
	/// </summary>
	public struct ResourceNames 
	{
		public static string ServiceRequest = "requests";
		public static string Services = "services";
		public static string Token = "token";
	}
	
	/// <summary>
	/// Valid response formats.
	/// </summary>
	public struct ResponseFormat
	{
		public static string XML = "xml";
		public static string JSON = "json";
	}
	
	/// <summary>
	/// Valid HTTP methods. 
	/// </summary>
	public struct MethodType
	{
		public static string POST = "POST";
		public static string GET = "GET";
	}
}
