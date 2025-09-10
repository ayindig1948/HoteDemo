using HotelDataA.DataBase;
using HotelDataA.RoomMan;
using SqliteData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IDapAcasses,DapAcasses>();
builder.Services.AddTransient<IDataAcsesLite, DataAcsesLite>();
string dbChoice = builder.Configuration.GetValue<string>("DbChoice").ToLower();
if (dbChoice=="sql")
{
    builder.Services.AddTransient<IdataDb, Sqldata>();
}
else if (dbChoice == "sqlite")
{
    builder.Services.AddTransient<IdataDb, LiteDbData>();
}
else
{
    builder.Services.AddTransient<IdataDb, Sqldata>();
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
