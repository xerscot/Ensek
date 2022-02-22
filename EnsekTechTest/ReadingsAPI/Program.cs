using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Readings") ?? "Data Source=Readings.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<ReadingsDbContext>(connectionString);
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapFallback(() => Results.Redirect("/swagger"));

app.MapGet("/accounts", async (ReadingsDbContext db) =>
{
    return await db.Accounts.ToListAsync();
});

app.MapPost("/accounts", async (ReadingsDbContext db, Account account) =>
{
    await db.Accounts.AddAsync(account);
    await db.SaveChangesAsync();

    return Results.Created($"/account/{account.AccountId}", account);
});

app.MapGet("/accounts/{AccountId}", async (ReadingsDbContext db, int AccountId) =>
{
    return await db.Accounts.FindAsync(AccountId) switch
    {
        Account account => Results.Ok(account),
        null => Results.NotFound()
    };
});

app.MapGet("/readings", async (ReadingsDbContext db) =>
{
    return await db.MeterReadings.ToListAsync();
});

app.MapPost("/meter-reading-uploads", async Task<IResult> (ReadingsDbContext db, HttpRequest request) =>
{
    if (!request.HasFormContentType)
        return Results.BadRequest();

    var form = await request.ReadFormAsync();
    var formFile = form.Files["file"];

    if (formFile is null || formFile.Length == 0)
        return Results.BadRequest();

    ReadingsAPI.MeterReadingService mrs = new ReadingsAPI.MeterReadingService(db);
    await mrs.ProcessFileAsync(formFile);

    int success = 0;
    int fail = 0;

    var results = mrs.GetMeterReadingResults();
    if(results is null)
    {
        return Results.BadRequest();
    }
    else
    {
        success = results.Where(s => s.Success == true).Count();
        fail = results.Where(s => s.Success == false).Count();

        await db.SaveChangesAsync();
    }

    string message = "Stored: " + success + " | Skipped: " + fail;

    return Results.Ok(message);
}).Accepts<IFormFile>("multipart/form-data").Produces(200);

app.Run();