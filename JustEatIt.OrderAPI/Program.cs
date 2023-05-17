using JustEatIt.OrderAPI.Infrastructure;
using JustEatIt.OrderAPI.Queries;
using JustEatIt.OrderAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("JustEatItDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
    .AddFiltering()
    .RegisterService<IOrderService>()
    .AddQueryType<Query>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
