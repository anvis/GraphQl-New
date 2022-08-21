# GraphQl-New

queries - 1

https://dev.to/moe23/net-5-api-with-graphql-step-by-step-2b20

https://github.com/mohamadlawand087/v28-Net5-GraphQL

https://github.com/mohamadlawand087/v28-Net5-GraphQL/tree/main/TodoListQL


https://www.linkedin.com/learning/api-development-in-dot-net-with-graphql/create-the-orderssubscription?autoplay=true&trk=learning-course_tocItem&upsellOrderOrigin=default_guest_learning

mutation{
  addList(input: {
    name: "Food"
  })
  {
    list
    {
      name
    }
  }
}

--------------------

mutation{
  addItem(input: {
    title: "Food",
    isDone: true,
    listId: 1
  })
  {
    data
    {
      title
    }
  }
}

---------------------------------

mutation{
  addItem(input: {
    title: "Bring laptop",
    description: "Bring the laptop with charger",
    isDone: true,
    listId: 1
  })
  {
    data
    {
      id
      title
    }
  }
}

------------------------

query getList
{
  list
  {
    name
  }
}

-------------------------------------


query getDatas
{
  datas
  {
    title
  }
}
