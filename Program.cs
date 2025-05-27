using Microsoft.AspNetCore.Diagnostics; // Add this using directive
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));

// Fix for CS1061: Ensure the correct namespace is included for AddDatabaseDeveloperPageExceptionFilter
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

// Registration db services
using (var scope = app.Services.CreateScope())
{
        var services = scope.ServiceProvider;
   
        var context = services.GetRequiredService<SchoolContext>();
    // Ensure the database is created and apply migrations
   // context.Database.EnsureCreated();
    // Seed the database if necessary - uncomment the line below if you have a DbInitializer class
     DbInitializer.Initialize(context); 
}
//Other middleware registrations
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
