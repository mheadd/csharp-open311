using System;

namespace Open311API.RequestListingOptions
{
	/// <summary>
	/// Options class for retrieving list of service requests.
	/// </summary>
	public class Options
	{
		public string Service_request_id { get; set; }
		public string Service_code { get; set; }
		public string Start_date { get; set; }
		public string End_date { get; set; }
		public string Status { get; set; }
		
		/// <summary>
		/// Class constructor.
		/// </summary>
		public Options()
		{
		}
	}
}
