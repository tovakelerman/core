using Books.Interfaces;
using Books.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// שירות הספרים הוא singleton כדי שהנתונים יישמרו בין בקשות
builder.Services.AddSingleton<IBookService, BookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
