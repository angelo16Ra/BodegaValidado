using ApiWeb.Middleware;
using Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//CONFIGURACIN DEL CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "origins",
                      builder =>
                      {
                          //builder.WithOrigins("http://127.0.0.1:5500");
                          builder.AllowAnyOrigin();
                          builder.AllowAnyMethod();//get post put delete patch 
                          builder.AllowAnyHeader();//
                      });
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//JWT IMPLEMENTACIN
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });



builder.Services.AddSwaggerGen(c =>
{ 
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BodegaYanin",
        Version = "v1",
        Description = "Sistema de ventas y almacen de la bodega 'BODEGUITA YANIN' ",
        Contact = new OpenApiContact
        {
            Name = "Angelo Rodriguez Altez,  Abigaid Rojas Champa",
            Email = "i2226467@continental.edu.pe,i2212751@continental.edu.pe",
            Url = new Uri("https://www.linkedin.com/in/angelo-joseph-rodriguez-altez-a829b423b/ , https://www.linkedin.com/in/abigail-rojas-champa-b5580123b/")
        },
    }
    );
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments( xmlPath, includeControllerXmlComments: true );
});

// Configuracion del AutoMapper
builder.Services.AddAutoMapper(typeof(IStartup).Assembly,typeof(AutoMapperProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware(typeof(ApiMiddleware));


app.MapControllers();
app.UseCors("origins");

app.Run();
