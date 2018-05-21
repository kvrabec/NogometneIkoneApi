using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NogometneIkone.DAL;
using NogometneIkone.DAL.Repository;
using NogometneIkone.Model;
using Swashbuckle.AspNetCore.SwaggerGen;
using NogometneIkone.Web.Services;

namespace NogometneIkone.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private List<string> clients { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            clients = new List<string>();
            services.AddMvc();
            services.AddScoped<QuizRepository>();
            services.AddScoped<QuestionRepository>();
            services.AddScoped<AnswerRepository>();
            services.AddDbContext<NIManagerDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:localConn"]));
            services.AddMvc().AddJsonOptions(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<NIManagerDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            //services.AddApiVersioning(options =>
            //{
            //    options.ReportApiVersions = true;
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //    options.ApiVersionReader = new HeaderApiVersionReader("api-v");
            //});

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1.0", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Nogometne Ikone API", Version = "v1.0" });

            //    options.DocInclusionPredicate((docName, apiDesc) =>
            //    {
            //        var versions = apiDesc.ControllerAttributes()
            //            .OfType<ApiVersionAttribute>()
            //            .SelectMany(attr => attr.Versions);

            //        return versions.Any(v => $"v{v.ToString()}" == docName);
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "pusher_auth",
                    template: "pusher/auth",
                    defaults: new { controller = "Auth", action = "ChannelAuth" });
            });
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024
            };
            app.UseWebSockets(webSocketOptions);
            app.Use(async (context, next) =>
            {
                if (!string.IsNullOrWhiteSpace(context.Request.Path))
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        await Echo(context, webSocket);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }

            });
            //app.UseSwagger();
            //app.UseSwaggerUi(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Nogometne Ikone API V1.0");
            //});
        }
        private async Task Echo(HttpContext context, WebSocket webSocket)
        {
            //clients.Add(context.User.Identity.Name);
            clients.Add(context.Connection.Id);

            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                //
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
