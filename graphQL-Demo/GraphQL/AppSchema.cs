using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace TodoListQL.GraphQL
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            ////Query = provider.GetService<Query>();
            ////Mutation = provider.GetService<Mutation>();
            ////Subscription = provider.GetService<Subscription>();
           // Filter = provider.GetRequiredService<ISchemaFilter>();
        }
    }
}
