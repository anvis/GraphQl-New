using System.Linq;
using GraphQL.Types;
using HotChocolate;
using HotChocolate.Data;
using TodoListQL.Data;
using TodoListQL.Models;

namespace TodoListQL.GraphQL
{
    public class Query //:   ObjectGraphType
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetList([ScopedService] ApiDbContext context)
        {
            return context.Lists;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetDatas([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }
    }
}