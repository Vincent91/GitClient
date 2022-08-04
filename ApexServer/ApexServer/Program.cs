using ApexServer;

var gitClient = new GitClient();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/trades", async (HttpContext context) =>
{
   var query = context.Request.QueryString;
   var promise = gitClient.RequestData(query.ToString());

   return await promise;
});

app.Run();