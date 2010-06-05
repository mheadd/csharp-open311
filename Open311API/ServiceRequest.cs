using System;

namespace Open311API.ServiceRequest
{
	/// <summary>
	/// Request class represents a new 311 service request. 
	/// </summary>
	public class Request
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Addrress { get; set; }
		public int Address_id { get; set; }
		public string Email { get; set; }
		public string Device_id { get; set; }
		public string Account_id { get; set; }
		public string First_name { get; set; }
		public string Last_name { get; set; }
		public string Phone { get; set; }
		public string Description { get; set; }
		public string Media_url { get; set; }
		
		/// <summary>
		/// Simple validation for the request object.
		/// </summary>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public bool isValid()
		{
			if (Latitude == 0 && Longitude == 0 && String.IsNullOrEmpty(Addrress))
			{
				return false;
			}
			return true;
		}
	}
}
