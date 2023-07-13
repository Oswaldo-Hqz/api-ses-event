using Nelibur.ObjectMapper;
using sesEntities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

TinyMapper.Bind<SESEvent, JsonResponse>(config =>
{
    config.Ignore(src => src.records[0].eventVersion);
    config.Ignore(src => src.records[0].eventSource);
    config.Ignore(src => src.records[0].ses.receipt.timestamp);
    config.Ignore(src => src.records[0].ses.receipt.recipients);
    config.Ignore(src => src.records[0].ses.receipt.action);
    config.Ignore(src => src.records[0].ses.mail.source);
    config.Ignore(src => src.records[0].ses.mail.messageId);
    config.Ignore(src => src.records[0].ses.mail.headersTruncated);
    config.Ignore(src => src.records[0].ses.mail.headers);
    config.Ignore(src => src.records[0].ses.mail.commonHeaders);

    config.Bind(src => src.records[0].ses.receipt.spamVerdict.status, dest => dest.spam);
    config.Bind(src => src.records[0].ses.receipt.virusVerdict.status, dest => dest.virus);
    config.Bind(src => src.records[0].ses.receipt, dest => dest.dns);
    config.Bind(src => src.records[0].ses.mail.timestamp, dest => dest.mes);
    config.Bind(src => src.records[0].ses.receipt.processingTimeMillis, dest => dest.retrasado);
    config.Bind(src => src.records[0].ses.mail.source, dest => dest.emisor);
    config.Bind(src => src.records[0].ses.mail.destination, dest => dest.receptor);
});

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
