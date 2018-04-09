// Copyright (c) Jeferson Tenorio. All rights reserved.
// Licensed under MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using System;

namespace EnterpriseApp.WebAPI.Controllers
{
	[Route("api/[controller]")]
	//[EnableCors("AllowSpecificOrigin")]

	public class InformationController : Controller
	{
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