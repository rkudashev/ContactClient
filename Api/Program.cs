using Api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<DataContext>();

string connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:SqliteConnection");
builder.Services.AddSingleton<IStorage>(new SqLiteStorage(connectionString));


builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>
{
    policy.AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins(builder.Configuration["Client"]);
}));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseCors("CorsPolicy");

app.Run();
