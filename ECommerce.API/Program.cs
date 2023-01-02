using ECommerce.Core.Configuration.Mapper;
using ECommerce.Core.Extensions;
using ECommerce.Migrations.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));


#region di
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddECommerceRefs();
#endregion

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", b =>
{
    b.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db= scope.ServiceProvider.GetRequiredService<OShopDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MyPolicy");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
