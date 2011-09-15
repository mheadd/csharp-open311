CSharpOpen311-V2
================

A set of C# classes for working with v.2 of the Open311 API (GeoReport API V2).  For documentation on the GeoReport API, see http://wiki.open311.org/GeoReport_v2

This project was created using Mono version 2.4.4 (http://mono-project.com) and MonoDevelop 2.2.1 (http://monodevelop.com/).

Usage:
=====
	using System;
	using Open311API;
	using Open311API.Exception;
	using Open311API.Structs;

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
		
			// App entry point.
			public static void Main (string[] args)
			{
				// Create a new instance of the Open311 object.
				Open311 report = new Open311(ENDPOINT, JURISDICTION_ID);
			
				try 
				{				
					Console.WriteLine(report.GetServiceRequest(ResponseFormat.XML, SERVICE_RQUEST_ID));
				}
				catch (Open311Exception ex) 
				{
					Console.WriteLine("Sorry. An error occured: " + ex.Message);
				}
			
			}
		
		}
	
	}

Output:
======

	<?xml version="1.0" encoding="UTF-8"?>
	<service_requests>
	  <request>
	    <token>4e6cbd2a9dc2f112940000bc</token>
	    <status>submitted</status>
	    <service_name>Graffiti Removal</service_name>
	    <service_code>4e39a3aad3e2c20ed800000c</service_code>
	    <requested_datetime>2011-09-11T09:52:43-04:00</requested_datetime>
	    <updated_datetime>2011-09-11T09:52:43-04:00</updated_datetime>
	    <lat>39.3257703014457</lat>
	    <long>-76.5906496206646</long>
	    <media_url>http://311test.baltimorecity.gov/attachments/report/4e6cbd2a9dc2f112940000bc/photo/395284434.jpg</media_url>
	  </request>
	</service_requests>



