using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/api/error/unauthorized";
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("http://localhost:8080").AllowAnyMethod()
            .AllowAnyHeader().AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePages(context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.BadRequest)
    {
        response.Redirect("/api/error/bagRequest");
    }

    if (response.StatusCode == (int)HttpStatusCode.NotFound)
    {
        response.Redirect("/api/error/notFound");
    }

    if (response.StatusCode == (int)HttpStatusCode.Forbidden)
    {
        response.Redirect("/api/error/forbidden");
    }

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        response.Redirect("/api/error/unauthorized");
    }

    return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseCors("CorsPolicy");
app.Run();
