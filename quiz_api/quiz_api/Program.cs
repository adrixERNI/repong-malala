using Microsoft.EntityFrameworkCore;
using quiz_api.Data;
using quiz_api.Entites;
using quiz_api.Profiles;
using quiz_api.Repositories;
using quiz_api.Repositories.AnswerRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddScoped<IQuizRepository,QuizRepository>();
builder.Services.AddAutoMapper(typeof(QuizProfile).Assembly);
builder.Services.AddScoped<IAnswerRepository,AnswerRepository>();

builder.Services.AddAutoMapper(typeof(AnswerProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
