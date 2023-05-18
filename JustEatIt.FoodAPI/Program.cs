using JustEatIt.FoodAPI;
using JustEatIt.FoodAPI.Infrastructure;
using JustEatIt.FoodAPI.Queries;
using JustEatIt.FoodAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("JustEatItDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer()
    .AddFiltering()
    .RegisterService<IFoodService>()
    .AddQueryType<Query>()
    .InitializeOnStartup()
    .PublishSchemaDefinition(c => c.SetName("food"));

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddSingleton<IFoodRepository, FoodRepository>();

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
