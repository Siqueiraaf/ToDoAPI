using Microsoft.EntityFrameworkCore;
using TodoAPi.Interfaces;
using TodoAPI.AppDataContext;
using TodoAPI.Middleware;
using TodoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

// Registro dos serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<ITodoServices, TodoServices>();
builder.Services.AddLogging();

var app = builder.Build();

// Configuração do middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();

app.MapControllers();

app.Run();
