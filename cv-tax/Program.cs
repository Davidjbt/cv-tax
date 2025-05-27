using System.Reflection;
using cv_tax.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PictureGalleryDatabase") ?? throw new InvalidOperationException("Invalid connection string");


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSqlServer<PictureGalleryDbContext>(connectionString, opts => opts.EnableRetryOnFailure());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
