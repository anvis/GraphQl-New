using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using GraphQL.Server.Ui.Voyager;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TodoListQL.Data;
using TodoListQL.GraphQL;

namespace TodoListQL
{
    public class Startup
    {
        public IConfiguration Configuration {get;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApiDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")
                ));

            ////services.AddSingleton<AppSchema>();
            ////services.AddGraphQL(
            ////        (_, serviceProvider) =>
            ////        {
            ////            _.EnableMetrics = false;
            ////            var logger = serviceProvider.GetRequiredService<ILogger<Startup>>();
            ////            _.UnhandledExceptionDelegate = ctx =>
            ////                logger.LogError(ctx.OriginalException.Message, "Error occurred");
            ////        })
            ////    .AddGraphTypes(typeof(AppSchema))
            ////    .AddWebSockets();
            //  .AddSystemTextJson()
            // .AddUserContextBuilder<HttpGraphQLUserContextBuilder>();

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<ListType>()
                .AddProjections()
                .AddMutationType<Mutation>() //.AddSubscriptionType<Subscription>()
                .AddFiltering()
                .AddSorting();
            //.AddSubscriptionType<Subscription>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-ui");

            app.UseWebSockets();

            //app.UseGraphQLWebSockets<AppSchema>();
            //app.UseGraphQLWebSockets<AppSchema>("/subscription");
            //app.UseGraphQL<AppSchema>();
        }
    }
}
