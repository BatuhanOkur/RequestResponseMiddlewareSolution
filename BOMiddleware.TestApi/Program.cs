using BO.RequestResponseMiddleware.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddLogging(conf =>
{
    conf.AddConsole();
});
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
    //opt.UseHandler(async context =>
    //{
    //    Console.WriteLine($"RequestBody: {context.RequestBody}");
    //    Console.WriteLine($"ResponseBody: {context.ResponseBody}");
    //    Console.WriteLine($"Timing: {context.FormattedCreationTime}");
    //    Console.WriteLine($"Url: {context.Url}");
    //});

    opt.UseLogger(app.Services.GetRequiredService<ILoggerFactory>(), opt =>
    {
        opt.LogLevel = LogLevel.Error;
        opt.LoggerCategoryName = "CustomCategoryName";
        opt.LoggingFields.Add(LogFields.Request);
        opt.LoggingFields.Add(LogFields.Response);
        opt.LoggingFields.Add(LogFields.ResponseTiming);
        opt.LoggingFields.Add(LogFields.Path);
        opt.LoggingFields.Add(LogFields.QueryString);
    });

});

app.MapControllers();

app.Run();
