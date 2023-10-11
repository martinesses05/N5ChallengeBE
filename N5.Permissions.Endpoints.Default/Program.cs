using Microsoft.EntityFrameworkCore;
using N5.Permissions.Core.BL;
using N5.Permissions.Core.Contracts;
using N5.Permissions.Core.DAL;

var builder = WebApplication.CreateBuilder(args);

AppSettings.Settings = new Settings();
builder.Configuration.Bind("App", AppSettings.Settings);
builder.Services.AddScoped<IAppDBContext, AppDBContext>();
builder.Services.AddScoped<IPermissionsBL, PermissionsBL>();
builder.Services.AddScoped<IPermissionTypesBL, PermissionTypesBL>();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(AppSettings.Settings.ConnectionString).EnableSensitiveDataLogging(true));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
