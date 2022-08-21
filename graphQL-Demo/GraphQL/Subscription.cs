using HotChocolate;
using HotChocolate.Types;
using TodoListQL.Models;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using GraphQL;
//using GraphQL.Authorization;
using GraphQL.Resolvers;
//using GraphQL.Subscription;
using GraphQL.Types;
using GraphQL.Subscription;
using System;
using System.Collections.Generic;

namespace TodoListQL.GraphQL
{
    public class Subscription :  ObjectGraphType
    {
       // private readonly ITopicEventSender _topicEventSender;

        public Subscription() //  ITopicEventSender topicEventSender)
        {
           // _topicEventSender = topicEventSender;
            Name = "Subscription";
            AddField(
               new EventStreamFieldType
               {
                   Name = "simpleValue",
                   Description = "dummy incrementing value",
                   Type = typeof(ListType),
                   Resolver = new FuncFieldResolver<ItemList>(ResolvePointValueUpdate),
                   Subscriber = new EventStreamResolver<ItemList>(SubscribeSimpleValue)
               });
        }

        private IObservable<ItemList> SubscribeSimpleValue(IResolveEventStreamContext context)
        {
            var pointAddresses = context.GetArgument<List<ItemList>>("items");
           // _topicEventSender.SendAsync();
            return (IObservable<ItemList>)(context.Source as ItemList);
        }

        private ItemList ResolvePointValueUpdate(IResolveFieldContext context)
        {
            return context.Source as ItemList;
        }


        


        [Subscribe]
        [Topic]
        public ItemList OnListAdded([EventMessage] ItemList list) => list;
    }
}
