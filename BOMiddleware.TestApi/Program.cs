using BO.RequestResponseMiddleware.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.AddBORequestResponseMiddleware(opt =>
{
    opt.UseHandler(async context =>
    {
        Console.WriteLine($"RequestBody: {context.RequestBody}");
        Console.WriteLine($"ResponseBody: {context.ResponseBody}");
        Console.WriteLine($"Timing: {context.FormattedCreationTime}");
        Console.WriteLine($"Url: {context.Url}");
    });

});

app.MapControllers();

app.Run();
