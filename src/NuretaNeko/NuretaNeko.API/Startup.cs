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
            //services.AddTransient<IDishCategoryRepository, DishCategoryRepository>();


            //services.AddSwaggerModule();
            services.AddSwaggerGen();


            //services.AddApplicationModule(Configuration);

            //services.AddMediatR(typeof(MediatREntryPoint).Assembly);

            services.AddHttpContextAccessor();
            services.AddHttpClient();

            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = Configuration["JWT:Issuer"],
            //            ValidAudience = Configuration["JWT:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
            //        };
            //    });

            //services.AddQuartz(q =>
            //{
            //    q.UseMicrosoftDependencyInjectionJobFactory();

            //    var currencySpyJobKey = new JobKey("CurrencySpy");
            //    q.AddJob<CurrencySpy>(opt => opt.WithIdentity(currencySpyJobKey));

            //    var oldMonthRatesToAverageJobKey = new JobKey("OldMonthRatesToAverage");
            //    q.AddJob<OldMonthRatesToAverage>(opt => opt.WithIdentity(oldMonthRatesToAverageJobKey));

            //    q.AddTrigger(opts => opts
            //        .WithIdentity("CurrencySpy-trigger")
            //        .ForJob(currencySpyJobKey)
            //        .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow.AddSeconds(3)))
            //        .WithCronSchedule("0 0 23 * * ?")
            //        .WithDescription("Trigger for collecting currencies rates")
            //    );

            //    q.AddTrigger(opts => opts
            //        .WithIdentity("OldMonthRatesToAverage-trigger")
            //        .ForJob(oldMonthRatesToAverageJobKey)
            //        .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow.AddSeconds(3)))
            //        .WithCronSchedule("0 50 23 L * ? *")
            //        .WithDescription("Trigger which brings old month currencies rates to the average value")
            //    );
            //});

            //services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            //services.AddScoped<ITokenService, JwtTokenService>();
            //services.AddScoped<IIdentityService, IdentityService>();

            //services.AddTransient<IValidator<LoginUserRequest>, LoginUserRequestValidator>();
            //services.AddTransient<IValidator<RegisterUserRequest>, RegisterUserRequestValidator>();

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
