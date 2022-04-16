var builder = WebApplication.CreateBuilder(args);

#region ����ע��
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDaprClient();

#endregion

builder.Logging.AddConsole();

var app = builder.Build();

#region �ܵ�ע��


app.UseCloudEvents();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapSubscribeHandler();
#endregion

app.Run();
