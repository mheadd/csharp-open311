using System;
using System.Net;

namespace Open311API.Exception
{
	/// <summary>
	/// An Exception class for Open311 API exceptions.
	/// </summary>
	public class Open311Exception : WebException
	{
		public Open311Exception() : base()
		{		
		}
		
		public Open311Exception(string message) : base(message) 
		{			
		}
		
		public Open311Exception(string message, WebException innerException) : base(message, innerException)
		{
		}
	}
}
