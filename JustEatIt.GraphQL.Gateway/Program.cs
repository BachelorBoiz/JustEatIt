var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("food", c =>
{
    c.BaseAddress = new Uri("http://foodapi/graphql");
});

builder.Services.AddHttpClient("drink", c =>
{
    c.BaseAddress = new Uri("http://drinkapi/graphql");
});

builder.Services.AddHttpClient("order", c =>
{
    c.BaseAddress = new Uri("http://orderapi/graphql");
});

builder.Services.AddGraphQLServer()
    .AddRemoteSchema("food")
    .AddRemoteSchema("drink")
    .AddRemoteSchema("order");
    

var app = builder.Build();
app.MapGraphQL();
app.Run();
