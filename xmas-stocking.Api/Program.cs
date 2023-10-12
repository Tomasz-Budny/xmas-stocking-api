using xmas_stocking.Api.Exceptions;
using xmas_stocking.Api.Options;
using xmas_stocking.Api.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

builder.Services.AddScoped<ErrorHandlerMiddleware>();
builder.Services.AddScoped<IDrawnService, DrawnService>();
builder.Services.AddScoped<ISmtpService, SmtpService>();
builder.Services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
builder.Services.Configure<SmtpOptions>(configuration.GetSection(SmtpOptions.SectionName));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("AllowAny");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
