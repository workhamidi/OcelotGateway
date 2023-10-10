using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway;

var builder = WebApplication.CreateBuilder(args);


/* ******************************************************************* */
builder.Configuration.AddJsonFile("ocelot.json");

builder.Services
    .AddOcelot(builder.Configuration)

    // If it is set to true then it becomes a global
    // handler and will be applied to all Routes.
    .AddDelegatingHandler<RequestHandler>(true);
/* ******************************************************************* */



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



/* ******************************************************************* */

// to add guid to each incoming request 
var configuration = new OcelotPipelineConfiguration
{
    PreErrorResponderMiddleware = async (ctx, next) =>
    {
        ctx.Request.Headers.Add("RequestId",Guid.NewGuid().ToString());
        await next.Invoke();
    }
};


app.UseOcelot(configuration)
    // async request 
    // is using Wait() necessary to prevent the system from blocking
    .Wait();

/* ******************************************************************* */

app.Run();
