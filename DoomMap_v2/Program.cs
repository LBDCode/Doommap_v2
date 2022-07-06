using DoomMap_v2.Models;
using DoomMap_v2.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services);


builder.Services.AddControllersWithViews();


builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(Point)));
    options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(Coordinate)));
    options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(LineString)));
    options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(MultiLineString)));
    options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(MultiPolygon)));

});


builder.Services.AddControllers()
  .AddJsonOptions(options => {
      var geoJsonConverterFactory = new GeoJsonConverterFactory();
      options.JsonSerializerOptions.Converters.Add(geoJsonConverterFactory);
  });


builder.Services.AddSingleton(NtsGeometryServices.Instance);


var connectionString = builder.Configuration.GetConnectionString("DoomMap");

var dbBuilder = new NpgsqlConnectionStringBuilder(connectionString);
builder.Services.AddDbContext<DoomMapContext>(options => options.UseNpgsql(dbBuilder.ConnectionString, o => o.UseNetTopologySuite()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();


void ConfigureServices(IServiceCollection services)
{

    services.AddTransient<IFiresService, FiresService>();
    services.AddTransient<IMetricsService, MetricsService>();
    services.AddTransient<IDroughtsService, DroughtsService>();
    services.AddTransient<IAdvisoryAreasService, AdvisoryAreasService>();
    services.AddTransient<IStormsService, StormsService>();
    services.AddTransient<IStormTracksService, StormTracksService>();

}