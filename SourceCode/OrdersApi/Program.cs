using Confluent.Kafka;
using OrdersApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var consumerConfig = new ConsumerConfig { 
    GroupId = "add-product-consumer-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

builder.Services.AddSingleton<IConsumer<Null, string>>(
    x => new ConsumerBuilder<Null, string>(consumerConfig).Build()
);

builder.Services.AddSingleton<IOrdersService, OrdersService>(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
