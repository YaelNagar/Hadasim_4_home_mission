using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Swashbuckle;
using BL.interfaces;
using BL.classes;
using DAL.interfaces;
using DAL.classes;
using DAL.models;

namespace finalProject
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

            //הרשאות לאנגולר
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddCors(option => option.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


            //בעייה נוספת של התאמת אותיות בין השרת ללקוח
            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            //הזרקת תלויות
            services.AddDbContext<HMOCoronaDBContext>(o => o.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=HMOCoronaDB;Trusted_Connection=True;"));

            services.AddScoped(typeof(ICoronaPatientsBL), typeof(CoronaPatientsBL));
            services.AddScoped(typeof(IHMOMembersBL), typeof(HMOMembersBL));
            services.AddScoped(typeof(IVaccineToMemberBL), typeof(VaccineToMemberBL));
            services.AddScoped(typeof(ICoronaVaccinesBL), typeof(CoronaVaccinesBL));

            services.AddScoped(typeof(ICoronaPatientsDAL), typeof(CoronaPatientsDAL));
            services.AddScoped(typeof(IHMOMembersDAL), typeof(HMOMembersDAL));
            services.AddScoped(typeof(IVaccineToMemberDAL), typeof(VaccineToMemberDAL));
            services.AddScoped(typeof(ICoronaVaccinesDAL), typeof(CoronaVaccinesDAL));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
