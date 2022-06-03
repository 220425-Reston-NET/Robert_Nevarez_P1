using LeagueStoreBL;
using StoreRepo;
using Summoner;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Environment.GetEnvironmentVariable("Connection_String")
//builder.Configuration.GetConnectionString("Robert_Nevarez_Champion")

// builder.Services.AddScoped<IRepository<OrderHistory>, SQLOrderHistoryRepo>(repo => new SQLOrderHistoryRepo(builder.Configuration.GetConnectionString("Robert_Nevarez_Champion")));
// builder.Services.AddScoped<IOrderHistoryBL, OrderHistoryBL>();
builder.Services.AddScoped<IRepository<ChampionInfo>, SQLChampRepo>(repo => new SQLChampRepo(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IRPBL, SearchRPBL>();
builder.Services.AddScoped<IRepository<ChampionInfoInventory>, SQLStoreChampion>(repo => new SQLStoreChampion(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IStoreItemsBL, StoreItemsBL>();
builder.Services.AddScoped<IRepository<ChampionInfo>, SQLChampRepo>(repo => new SQLChampRepo(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<ILeagueStoreBL<ChampionInfo>, SearchChampionBL>();
builder.Services.AddScoped<IRepository<SummonerInfo>, SQLSumRepo>(repo => new SQLSumRepo(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<ILeagueStoreBL<SummonerInfo>, SearchSummonerBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
