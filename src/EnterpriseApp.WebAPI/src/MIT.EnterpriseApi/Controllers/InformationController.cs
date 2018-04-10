// Copyright (c) Jeferson Tenorio. All rights reserved.
// Licensed under MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EnterpriseApp.WebAPI.Controllers
{
	/// <summary>
	/// Controller information
	/// </summary>
	[Route("api/[controller]")]
	[EnableCors("AllowSpecificOrigin")]
	public class InformationController : Controller
	{
		/// <summary>
		/// Show information about WebAPI service
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public object Index()
		{
			return new
			{
				Ping = "pong",
				ApplicationGuid = Constants.ApplicationGuid
			};
		}
	}
}