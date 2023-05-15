using JustEatIt.DrinkAPI.Infrastructure;
using JustEatIt.DrinkAPI.Queries;
using JustEatIt.DrinkAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("JustEatItDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer()
    .RegisterService<IDrinkService>()
    .AddQueryType<Query>();

builder.Services.AddScoped<IDrinkService, DrinkService>();
builder.Services.AddSingleton<IDrinkRepository, DrinkRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGraphQL();

app.UseAuthorization();

app.MapControllers();

app.Run();
