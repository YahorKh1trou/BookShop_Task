using Data.Extensions;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using RestAPI;
using Services.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddData(builder.Configuration);
builder.Services.AddServices();
/*
builder.Services.AddIdentityServer()
    .AddInMemoryClients(new List<Client>())
    .AddInMemoryIdentityResources(new List<IdentityResource>())
    .AddInMemoryApiResources(new List<ApiResource>())
    .AddInMemoryApiScopes(new List<ApiScope>())
    .AddTestUsers(new List<TestUser>())
    .AddDeveloperSigningCredential();
//        .AddDeveloperSigningCredential()
//        .AddInMemoryApiScopes(Configur.ApiScopes)
//        .AddInMemoryClients(Configur.Clients);
*/
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.Authority = "https://localhost:7030";
        options.ApiName = "BookAPI";
//        options.RoleClaimType = JwtClaimTypes.Role;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policyAdmin =>
    {
        policyAdmin.RequireClaim("client_Role", "admin");
    });

    //otherwise you already have "api1" as scope
/*
    options.AddPolicy("admin", builder =>
    {
        builder.RequireScope("BookAPI.read");
    });
*/
});

/*
builder.Services.AddAuthorization(opts => {
    opts.AddPolicy("TestPolicy", policy => {
        policy.RequireClaim("role");
    });
});
*/
builder.Services.AddControllers();
/*
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options => {
    options.Authority = "https://localhost:7032";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false
    };
});
//builder.Services.AddAuth();
*/
//builder.Services.AddAuth();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

//app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
} else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
