var builder = DistributedApplication.CreateBuilder(args);


var cache = builder.AddRedisContainer("rediscache");

// builder

var appInsightsConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]; 

var api = builder.AddProject<Projects.WebApi>("hussapi")
.WithEnvironment("APPLICATIONINSIGHTS_CONNECTION_STRING", appInsightsConnectionString);

builder.AddProject<Projects.BlazorApp>("hussfrontend")
    .WithReference(api)
    .WithReference(cache)
    .WithEnvironment("APPLICATIONINSIGHTS_CONNECTION_STRING", appInsightsConnectionString);
    
builder.Build().Run();
