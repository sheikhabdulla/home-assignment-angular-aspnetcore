var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "MyPolicy";

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register JsonPlaceholderService
builder.Services.AddHttpClient<JsonPlaceholderService>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
    // Add any other configuration for HttpClient if needed
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                        
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(MyAllowSpecificOrigins);
}

// app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
