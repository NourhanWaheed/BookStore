using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StoreData.Data;
using StoreData.Extensions;
using StoreData.Interfaces;
using StoreData.Models;
using StoreData.Repositories;
using System.Net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
.AddJsonOptions(opt =>
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IServiceCollection serviceCollection = builder.Services.AddDbContext<StoreData.Data.StoreContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddSingleton<DapperContext>();
builder.Services.TryAddScoped<IAuthor, AuthorRepository>();
builder.Services.TryAddScoped<IBook, BookRepository>();

var app = builder.Build();
//app.ConfigureExceptionHandler();
//app.UseExceptionHandler(
//    appError =>
//    {
//        appError.Run(async context =>
//        {
//            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//            context.Response.ContentType = "application/json";
//            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
//            if (contextFeature != null)
//            {
//                await context.Response.WriteAsync(new ErrorMessage()
//                {
//                    StatusCode = context.Response.StatusCode,
//                    Message = "Internal Server Error."
//                }.ToString());
//            }
//        });
//    });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
