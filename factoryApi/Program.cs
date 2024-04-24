using Microsoft.EntityFrameworkCore;
using factoryApi.Context;
using factoryApi.Repositories;
using factoryApi.Services;
using static factoryApi.Repositories.IProductStatusRepository;
using static factoryApi.Repositories.IFlowRecordRepository;
using static factoryApi.Repositories.IProductionLineRepository;
using static factoryApi.Repositories.IRawMaterialProductRepository;
using static factoryApi.Services.IProductionCapacityService;
using static factoryApi.Repositories.IRegistrationActionRepository;
using static factoryApi.Services.IRegistrationActionService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection"); // almacenar en la 
builder.Services.AddDbContext<FactoryDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IFlowRecordRepository, FlowRecordRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductStatusRepository, ProductStatusRepository>();
builder.Services.AddScoped<IProductionCapacityRepository, ProductionCapacityRepository>();
builder.Services.AddScoped<IProductionLineRepository, ProductionLineRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();
builder.Services.AddScoped<IRawMaterialProductRepository, RawMaterialProductRepository>();
builder.Services.AddScoped<IRegistrationActionRepository, RegistrationActionRepository>();

builder.Services.AddScoped<IFlowRecordService, FlowRecordService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductStatusService, ProductStatusService>();
builder.Services.AddScoped<IProductionCapacityService, ProductionCapacityService>();
builder.Services.AddScoped<IProductionLineService, ProductionLineService>();
builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<IRawMaterialService, RawMaterialService>();
builder.Services.AddScoped<IRawMaterialProductService, RawMaterialProductService>();
builder.Services.AddScoped<IRegistrationActionService, RegistrationActionService>();


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
