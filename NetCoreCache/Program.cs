using Cache;
using NetCoreCache;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContexts(Configuration);
#region ����
builder.Services.AddCors(cor =>
{
    cor.AddPolicy("Cors", policy =>
    {
        policy
        //.WithOrigins("https://localhost:15911", "http://0.0.0.0:3201")// ������վ���������
        .AllowAnyOrigin()// ��������վ���������
        .AllowAnyHeader()// ������������ͷ
                         //.AllowCredentials() //
        .AllowAnyMethod();// �����������󷽷�
    });
});
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache().AddSingleton<ICacheFactory, MemoryCacheFactory>();

var app = builder.Build();
var a1 = builder.Services.BuildServiceProvider();
ServiceProviderHelper.Configure(a1);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Cors");

app.UseAuthorization();

app.MapControllers();

app.Run();
