
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MuhammadAl_ZubairObaid.MedicalFoundation.Contexts;
using MuhammadAl_ZubairObaid.MedicalFoundation.Data.Repositories;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;
using Serilog;
using System.Reflection;
using System.Text;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                };

                options.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                };

                options.AddSecurityRequirement(securityRequirement); options.IncludeXmlComments(Assembly.GetExecutingAssembly().Location.Replace("dll", "xml"));
            });
            builder.Services.AddSerilog((config) => { config.WriteTo.File("MFlog.log", Serilog.Events.LogEventLevel.Error).WriteTo.Console(); });
            builder.Services.AddDbContext<MedicalFoundationDBContext>();
            builder.Services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Audience = "http://localhost:7163";
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["DefaultUser:PublicKey"])),
                    AuthenticationType = "Bearer",
                    ValidateIssuer = false
                };
            }).AddBearerToken(options =>
            {
                options.BearerTokenExpiration = new TimeSpan(0, 10, 0);
            });
            builder.Services.AddAuthorization(options => { options.AddPolicy("Admin", policy => policy.RequireRole("Administrator")); });
            builder.Services.AddScoped<IMFRepository<Patient>,PatientRepository>();
            builder.Services.AddScoped<IMFRepository<ClinicAppointment>,ClinicAppointmentRepository>();
            builder.Services.AddScoped<IMFRepository<Billing>,BillingRepository>();
            builder.Services.AddScoped<IMFRepository<Clinician>,ClinicianRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
