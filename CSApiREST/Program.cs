var frontendUI = "_frontendUI";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/// CORS 
// allow calls from AngularUI
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: frontendUI, policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        });
    });

// CORS

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(frontendUI);
app.UseAuthorization();

app.MapControllers();

app.Run();
