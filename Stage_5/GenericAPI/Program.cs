using DBClasses.Models;
using Microsoft.Extensions.Options;
using DBClasses.Json;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Attribute = DBClasses.Models.Attribute;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//=========================================================
//~~~~~~~~~~~~~~~~~~   To future self   ~~~~~~~~~~~~~~~~~~~
//=========================================================

// Database & Table seems fine
// Table and Attribute needs CamelCase for Name!
// otherwise blank object of the right class
// Database, Attribute, Table were given custom Deserializers
// Entry, EntryValue are not ready


// Solution to Swagger not showing enum serialized as string
// And added custom deserialiser for Attribute (and other classes)
// https://stackoverflow.com/questions/76643787/how-to-make-enum-serialization-default-to-string-in-minimal-api-endpoints-and-sw
// Docs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0#configure-json-deserialization-options-globally
// and issue between minimal WebAPI and Swashbuckle Swagger https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2293

JsonConverter enumConverter = new JsonStringEnumConverter<DataType>();
JsonConverter entryvalueConverter = new EntryValueJsonConverter();
JsonConverter entryConverter = new EntryJsonConverter();
JsonConverter attrConverter = new AttributeJsonConverter();
JsonConverter tableConverter = new TableJsonConverter();
JsonConverter databaseConverter = new DatabaseJsonConverter();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(enumConverter);
    options.SerializerOptions.Converters.Add(entryvalueConverter);
    options.SerializerOptions.Converters.Add(entryConverter);
    options.SerializerOptions.Converters.Add(attrConverter);
    options.SerializerOptions.Converters.Add(tableConverter);
    options.SerializerOptions.Converters.Add(databaseConverter);
    //This one doesn't make any difference? 
    //options.SerializerOptions.PropertyNameCaseInsensitive = true;
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(enumConverter);
    options.JsonSerializerOptions.Converters.Add(entryvalueConverter);
    options.JsonSerializerOptions.Converters.Add(entryConverter);
    options.JsonSerializerOptions.Converters.Add(attrConverter);
    options.JsonSerializerOptions.Converters.Add(tableConverter);
    options.JsonSerializerOptions.Converters.Add(databaseConverter);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var myDatabaseAPI = app.MapGroup("/database");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

//=====================================================

DataManager dm = DataManager.Instance;

//=====================================================
//                     Database
//=====================================================

//GET Database
myDatabaseAPI.MapGet("/", () =>
    TypedResults.Ok(dm.CurrentDatabase))
.WithName("GET Database")
.WithOpenApi();

//POST Database
app.MapPost("/", (Database strDB) =>
{
    if (dm.CurrentDatabase == null)
        dm.CurrentDatabase = strDB;
    return TypedResults.Created($"/database/");
})
.WithName("POST Database")
.WithOpenApi();

//DELETE Table
myDatabaseAPI.MapDelete("/", () =>
{
    if (dm.CurrentDatabase is Database database)
        dm.CurrentDatabase = null;
    return Results.NotFound(dm.CurrentDatabase);
})
.WithName("DELETE Database")
.WithOpenApi();

//=====================================================
//                      Table
//=====================================================

//GET Table
myDatabaseAPI.MapGet("/Table={tableName}", (string tableName) =>
    ((dm.CurrentDatabase is Database) && (dm.CurrentDatabase.GetTable(tableName) is Table t))
        ? Results.Ok(t)
        : Results.NotFound())
.WithName("GET Table")
.WithOpenApi();

//POST Table
myDatabaseAPI.MapPost("/", (Table t) =>
{
    if (dm.CurrentDatabase is Database)
        dm.CurrentDatabase.AddTable(t);
    return TypedResults.Created($"/database/Table={t.Name}");
})
.WithName("POST Table")
.WithOpenApi();

//DELETE Table
myDatabaseAPI.MapDelete("/Table={tableName}", (string tableName) =>
{
    if (dm.CurrentDatabase is Database database)
        if (dm.CurrentDatabase.GetTable(tableName) is Table table)
        {
            dm.CurrentDatabase.RemoveTable(tableName);
        }
    return Results.NotFound();
})
.WithName("DELETE Table")
.WithOpenApi();

//=====================================================
//                     Attribute
//=====================================================

//GET Attribute
myDatabaseAPI.MapGet("/Table={tableName}/Attribute={attrName}", (string tableName, string attrName) =>
    ((dm.CurrentDatabase is Database db) 
    && (db.GetTable(tableName) is Table t)
    && (t.GetAttribute(attrName) is Attribute attr))
        ? Results.Ok(t)
        : Results.NotFound())
.WithName("GET Attribute")
.WithOpenApi();

//POST Attribute
myDatabaseAPI.MapPost("/Table={tableName}/Attributes", (string tableName, Attribute attr) =>
{
    if ((dm.CurrentDatabase is Database db)
    && (db.GetTable(tableName) is Table t))
        t.AddAttribute(attr);
    return TypedResults.Created($"/database/Table={tableName}/Attribute={attr.Name}");
})
.WithName("POST Attribute")
.WithOpenApi();

//DELETE Attribute
myDatabaseAPI.MapDelete("/Table={tableName}/Attribute={attrName}", (string tableName, string attrName) =>
{
    if (dm.CurrentDatabase is Database db)
        if (db.GetTable(tableName) is Table table)
            table.RemoveAttribute(attrName);
    return Results.NotFound();
})
.WithName("DELETE Attribute")
.WithOpenApi();

//=====================================================
//                       Entry
//=====================================================

// Note: my entries do not have proper IDs.
// I would have differently built Table it they had ID (with hash map).
// That's why I either need to get all entries or search for a specific ones
// I don't want to do the last option, but I'll do it for a SEARCH operation

//SEARCH Entry
myDatabaseAPI.MapPost("/Table={tableName}/Search", (string tableName, Entry searchPattern) =>
    ((dm.CurrentDatabase is Database db)
    && (db.GetTable(tableName) is Table t)
    && (t.IsEntryValid(searchPattern) == true))
        ? Results.Ok(dm.SearchTable(t, searchPattern))
        : Results.NotFound())
.WithName("SEARCH Entry")
.WithOpenApi();

//GET Entry
myDatabaseAPI.MapGet("/Table={tableName}/Entry={entryID}", (string tableName, int entryID) =>
    ((dm.CurrentDatabase is Database db)
    && (db.GetTable(tableName) is Table t)
    && (t.GetEntry(entryID) is Entry e))
        ? Results.Ok(e)
        : Results.NotFound())
.WithName("GET Entry")
.WithOpenApi();

//POST Entry
myDatabaseAPI.MapPost("/Table={tableName}/Entries", (string tableName, Entry entry) =>

    ((dm.CurrentDatabase is Database db)
    && (db.GetTable(tableName) is Table t)
    && (t.IsEntryValid(entry) == true)
    && (t.AddEntry(entry) != false))
        ? Results.Created()
        : Results.NotFound(entry)      
)
.WithName("POST Entry")
.WithOpenApi();

// Note: my entries do not have ID.
// I would have differently built Table it they had ID (with hash map).
// That's why I either need to delete all entries or search for a specific ones
// I don't want to do the last option

//DELETE Entry
myDatabaseAPI.MapDelete("/Table={tableName}/Entry={entryID}", (string tableName, int entryID) =>
{ 
    if (dm.CurrentDatabase is Database db)
        if (db.GetTable(tableName) is Table table)
            table.RemoveEntry(entryID);
    return Results.NotFound();
})
.WithName("DELETE Entry")
.WithOpenApi();
//
//=====================================================

app.Run();