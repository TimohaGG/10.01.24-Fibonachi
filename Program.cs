using _10._01._24___Fibonachi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/fibonacci", appBuilder => {
    appBuilder.UseMiddleware<FibonacciMiddleware>();
});

app.Run();
