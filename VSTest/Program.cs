using System.Reflection;
using VSTest.BLL.Intefaces;
using VSTest.Core;
using VSTest.DAL;
using VSTest.DAL.Interfaces;
using VSTest.BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly,
                typeof(CustomerBLL).Assembly,
                typeof(DbContextBase).Assembly);
builder.Services.AddSelfRegisteredServices(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(
                typeof(IRepository<>),
                typeof(Repository<>));
builder.Services.AddScoped(
                typeof(IReadonlyRepository<>),
                typeof(Repository<>));

builder.Services.AddScoped<VSDbContext>();
builder.Services.AddTransient<ICustomerBLL, CustomerBLL>();

builder.Services.AddScoped<IUnitOfWork>(provider => provider.GetService<VSDbContext>());

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
