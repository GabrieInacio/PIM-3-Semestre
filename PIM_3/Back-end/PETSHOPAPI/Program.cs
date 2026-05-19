using Microsoft.EntityFrameworkCore;
using PETSHOPAPI.data;

var builder = WebApplication.CreateBuilder(args);

// =========================
// CONTROLLERS
// =========================

builder.Services.AddControllers();

// =========================
// SQL SERVER
// =========================

builder.Services.AddDbContext<PetshopContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        )
    )
);

// =========================
// CORS
// =========================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// =========================
// SWAGGER
// =========================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// =========================
// SWAGGER
// =========================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

// =========================
// HTTPS
// =========================

app.UseHttpsRedirection();

// =========================
// CORS
// =========================

app.UseCors("AllowAll");

// =========================
// AUTHORIZATION
// =========================

app.UseAuthorization();

// =========================
// CONTROLLERS
// =========================

app.MapControllers();

// =========================
// TESTE API
// =========================

app.MapGet("/", () => "API PETSHOP ONLINE");

// =========================
// EXECUTAR
// =========================

app.Run();