using FastEndpoints;
using FastEndpoints.Swagger; //add this

var bld = WebApplication.CreateBuilder();
bld.Services
   .AddFastEndpoints()
   .AddCors(options =>
   {
       options.AddPolicy("AllowSpecificOrigin",
           builder =>
           {
               builder.WithOrigins("http://localhost:3000")
                      .AllowAnyMethod()
                      .AllowAnyHeader();
           });
   })
   .SwaggerDocument(o =>
   {
       o.EnableJWTBearerAuth = false;
       o.DocumentSettings = s =>
       {
           s.Title = "System Automated Queue API";
           s.Version = "v1";
       };
   }); //define a swagger document

var app = bld.Build();

app.UseCors("AllowSpecificOrigin");

app.UseCors("AllowLocalhost");

app.UseFastEndpoints(c =>
    {
        c.Endpoints.RoutePrefix = "api";
    })
   .UseSwaggerGen(); //add this
app.Run();
