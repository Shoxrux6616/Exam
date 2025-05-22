using Exam6.Endpoiind;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configure();
builder.Configuration();
builder.ConfigurationJwtAuth();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseGlobalExceptionHandling();
app.UseMiddleware<RequestDurationMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAll");


app.MapControllers();

app.MapGet("/hello", () => "Hello, World!")
       .WithName("HelloEndpoint")
       .WithTags("Custom Section");

app.MapUserEndpoints();
app.Run();
