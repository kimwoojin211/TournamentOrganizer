using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TournamentOrganizer.Helpers;
using TournamentOrganizer.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TournamentOrganizer.Models;
using TournamentOrganizer.Entities;
using Newtonsoft.Json;

namespace TournamentOrganizer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
				services.AddCors();
				services.AddDbContext<TournamentOrganizerContext>(opt =>
						opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
				// services.AddDbContext<UserContext>(opt =>
				// 		opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
				services.AddControllers();

				// services.AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

				// configure strongly typed settings objects
				var appSettingsSection = Configuration.GetSection("AppSettings");
				services.Configure<AppSettings>(appSettingsSection);

				// configure jwt authentication
				var appSettings = appSettingsSection.Get<AppSettings>();
				var key = Encoding.ASCII.GetBytes(appSettings.Secret);
				services.AddAuthentication(x =>
				{
						x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
						x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(x =>
				{
						x.RequireHttpsMetadata = false;
						x.SaveToken = true;
						x.TokenValidationParameters = new TokenValidationParameters
						{
								ValidateIssuerSigningKey = true,
								IssuerSigningKey = new SymmetricSecurityKey(key),
								ValidateIssuer = false,
								ValidateAudience = false
						};
				});

				// configure DI for application services
				services.AddScoped<IUserService, UserService>();


			}

			// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
			public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
			{
				if (env.IsDevelopment())
				{
						app.UseDeveloperExceptionPage();
				}
				else
				{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
				}

				// app.UseHttpsRedirection();

				app.UseRouting();

			// global cors policy
			app.UseCors(x => x
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
					endpoints.MapControllers();
			});
		}
	}
}


