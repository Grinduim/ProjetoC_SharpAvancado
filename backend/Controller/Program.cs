using Microsoft.AspNetCore.Authentication.JwtBearer; //add
using Microsoft.IdentityModel.Tokens; //add 
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(); // lib
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>{ //configuração do token 
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters(){
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(p=>p.AddPolicy("corsapp", builder =>{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS
app.UseCors("corsapp");

app.UseAuthentication(); // add
app.UseAuthorization();


app.MapControllers();

app.Run();



