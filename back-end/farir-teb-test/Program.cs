using Application.Repositories.CandidateAggregate;
using Application.Repositories.TechnologyAggregate;
using Application.Services.CandidateAggregate;
using Application.Services.TechnologyAggregate;
using Domain.Messages.CandidateAggregate;
using Domain.Repositories.CandidateAggregate;
using Domain.Repositories.TechnologyAggregate;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.SeedWorks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mainContext"));
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<TechnologyService>();
builder.Services.AddScoped<CandidateService>();

builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services.AddAutoMapper(typeof(CandidateMappingProfile).Assembly);

var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    dbContext.Database.Migrate();

    new TechnologySeed(dbContext).Initial();
    new CandidateSeed(dbContext).Initial();
}

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
