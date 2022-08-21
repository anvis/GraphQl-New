using System.Threading.Tasks;
using GraphQL.Types;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using TodoListQL.Data;
using TodoListQL.GraphQL.DataItem;
using TodoListQL.GraphQL.Lists;
using TodoListQL.Models;

namespace TodoListQL.GraphQL
{
    public class Mutation  //: ObjectGraphType
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] ApiDbContext context)
           // [Service] ITopicEventSender eventSender )//, CancellationToken cancellationToken)
        {
            var list = new ItemList
            {
                Name = input.name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync();

            // await eventSender.SendAsync(nameof(Subscription.OnListAdded), list);

            return new AddListPayload(list);
        }

        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddItemPayload> AddItemAsync(AddItemInput input, [ScopedService] ApiDbContext context)
        {
            var item = new ItemData
            {
                IsDone = input.isDone,
                Description = input.description,
                ListId = input.listId,
                Title = input.title
            };

            context.Items.Add(item);
            await context.SaveChangesAsync();

            return new AddItemPayload(item);
        }
    }
}