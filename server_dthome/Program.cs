using Microsoft.EntityFrameworkCore;
using server_dthome.Entities;
using server_dthome.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Modified thêm
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<DthomeContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Program));

//Các repository
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IMemberOfRentalRepository, MemberOfRentalRepository>();
builder.Services.AddScoped<IWaterRepository, WaterRepository>();
builder.Services.AddScoped<ITrashRepository, TrashRepository>();    
builder.Services.AddScoped<IPowerRepository, PowerRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IOwnerAccountRepository, OwnerAccountRepository>();
builder.Services.AddScoped<IOwnerBuildingRepository, OwnerBuildingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Configure Kestrel to listen on all IP addresses and port 9912
app.Urls.Add("https://*:7095");

app.Run();
