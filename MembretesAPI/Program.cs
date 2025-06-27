var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.MapGet("/{mensaje}", (string mensaje) => Functions.ObtenerMensaje(mensaje));

app.MapGet("console/{type}/{mensaje}/",
    (string mensaje, int type = 0) => Functions.ConvertirParaExportarConsola( Functions.ObtenerMensaje(mensaje), type));

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
