using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ekleme
//burada projede .net core altyapýsýnda bulunan IoC yi deðil autofac altyapýsýný kullanacaðýmýzý bildirdik
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
     .ConfigureContainer<ContainerBuilder>(builder =>
     {
         builder.RegisterModule(new AutofacBusinessModule());
     });

//bitiþ


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:3000").AllowAnyHeader()
                                                  .AllowAnyMethod().AllowAnyOrigin();
                      });
});

//builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().WithMethods("GET", "POST", "DELETE", "PUT"));

app.UseAuthorization();

app.MapControllers();

app.Run();

