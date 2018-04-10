// Copyright (c) Jeferson Tenorio. All rights reserved.
// Licensed under MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace EnterpriseApp.WebAPI
{
	/// <summary>
	/// Bootstrap server
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Build server
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IWebHost BuildWebHost(string[] args)
		{
			// UseKestrel() – This registers the IServer interface for Kestrel as the server that will be used to host your application. In the future, there could be other options, including WebListener which will be Windows only.
			// https://github.com/aspnet/KestrelHttpServer

			// UseIISIntegration() – This tells ASP.NET that IIS will be working as a reverse proxy in front of Kestrel.This then specifies some settings around which port Kestrel should listen on, forwarding headers, and other details.
			// https://github.com/aspnet/IISIntegration

			// UseApplicationInsights() - ASP.NET Core web applications monitoring
			// https://github.com/Microsoft/ApplicationInsights-aspnetcore/
			// https://docs.microsoft.com/en-us/azure/application-insights/

			return WebHost.CreateDefaultBuilder(args)
				.UseKestrel()
				.UseIISIntegration()
				.UseApplicationInsights()
				.UseStartup<Startup>()
				.Build();
		}

		/// <summary>
		/// Run server
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}
	}
}