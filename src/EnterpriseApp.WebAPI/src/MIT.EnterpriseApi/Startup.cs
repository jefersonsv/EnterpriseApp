// Copyright (c) Jeferson Tenorio. All rights reserved.
// Licensed under MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;

namespace EnterpriseApp.WebAPI
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors("AllowSpecificOrigin");

			app.UseMvc();

			app.UseSwagger(c =>
			{
				c.RouteTemplate = "api-docs/{documentName}/swagger.json";
			});

			app.UseSwaggerUI(c =>
			{
				c.DisplayRequestDuration();
				c.RoutePrefix = "api-docs";
				c.DocumentTitle = "EnterpriseApp.WebAPI bootstrap";
				c.SwaggerEndpoint("/api-docs/v1/swagger.json", "EnterpriseApp.WebAPI bootstrap");
			});
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddMvc()
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.Formatting = Formatting.Indented;
				});

			// XML document file
			var xmlDocFile = Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".xml");

			// Use Swagger
			services.AddSwaggerGen(c =>
			{
				if (File.Exists(xmlDocFile))
					c.IncludeXmlComments(xmlDocFile);

				c.IgnoreObsoleteActions();
				c.IgnoreObsoleteProperties();
				c.DescribeAllEnumsAsStrings();
				c.DescribeStringEnumsInCamelCase();
				c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
				{
					Title = "EnterpriseApp.WebAPI bootstrap",
					Version = "v1",
					Contact = new Swashbuckle.AspNetCore.Swagger.Contact
					{
						Name = "Jeferson Tenorio",
						Url = "https://github.com/jefersonsv/"
					},
					License = new Swashbuckle.AspNetCore.Swagger.License
					{
						Name = "MIT",
						Url = "https://opensource.org/licenses/MIT"
					}
				});
			});

			// Use CORS
			// https://docs.microsoft.com/en-us/aspnet/core/security/cors
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});
		}
	}
}