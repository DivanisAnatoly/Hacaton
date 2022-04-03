using Amazon;
using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using NuretaNeko.API.Modules;
using NuretaNeko.AppModel.Repositories;
using NuretaNeko.AppModel.Services;
using NuretaNeko.AppModel.Services.Storage;
using NuretaNeko.Domain.Entities;
using NuretaNeko.Infrastructure.Database;
using NuretaNeko.Infrastructure.Repositories;
using NuretaNeko.Services.Services;
using NuretaNeko.Services.Services.Storage;

namespace NuretaNeko.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddControllers();

            services.AddAutomapperModule();
            services.AddDbContext<NNDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("LocalCompeterDbConnection")));
            //services.AddTransient<IConfigurationService, ConfigurationService>();

            services.AddSingleton<IAmazonS3>(sp =>
            {
                var clientConfig = new AmazonS3Config
                {
                    AuthenticationRegion = RegionEndpoint.EUWest1.SystemName,// Configuration["AWS:Region"],
                    ServiceURL = Configuration["AWS:ServiceURL"],
                    ForcePathStyle = true
                };
                return new AmazonS3Client(Configuration["AWS:AccessKey"], Configuration["AWS:SecretKey"], clientConfig);

            });

            services.AddTransient<IAppService, AppService>();
            services.AddTransient<ICloudStorageService, CloudStorageService>();
            services.AddTransient<IStorageService, StorageService>();

            services.AddTransient<IRepository<BaseEntity>, Repository<BaseEntity>>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<ISkillOptionRepository, SkillOptionRepository>();
            services.AddTransient<IResumeRepository, ResumeRepository>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();


            //services.AddSwaggerModule();
            services.AddSwaggerGen();


            //services.AddApplicationModule(Configuration);

            //services.AddMediatR(typeof(MediatREntryPoint).Assembly);

            services.AddHttpContextAccessor();
            services.AddHttpClient();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder => builder.AllowAnyOrigin());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NuretaNeko.API  v1"));
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
