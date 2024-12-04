using CrudOperationWithMongoDb.DataAccessLayer;
using CrudOperationWithMongoDb.DataAccessLayer;
using Microsoft.OpenApi.Models;
using CrudOperationWithMongoDb.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CrudOperations", Version = "v1" });
});
builder.Services.AddScoped<ICrudOperationDl, CrudOperationDl>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CrudOperations v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
