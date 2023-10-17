using Demo.Web.Services;

var policyName = "AllowOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


builder.Services.AddScoped<DeployService>();
builder.Services.AddScoped<ProcessService>();
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

app.Run();