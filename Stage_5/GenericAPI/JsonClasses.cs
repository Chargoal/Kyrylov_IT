using DBClasses.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using Attribute = DBClasses.Models.Attribute;
using DataType = DBClasses.Models.DataType;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System;

namespace DBClasses.Json
{
    /*
    public class TableSchema : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(Table))
            {
                // TODO: Set the example.
                schema.Example = new OpenApiObject
                {
                    ["Name"] = new OpenApiString("tableName")                   
                };
            }
            if (context.Type == typeof(Attribute))
            {
                // TODO: Set the example.
                schema.Example = new OpenApiObject
                {
                    ["Name"] = new OpenApiString("attrName")
                };
            }
        }
    }
    */
    public static class JsonSerializerExtensions
    {
        public static JsonSerializerOptions CopyAndRemoveConverter(this JsonSerializerOptions options, Type converterType)
        {
            var copy = new JsonSerializerOptions(options);
            for (var i = copy.Converters.Count - 1; i >= 0; i--)
                if (copy.Converters[i].GetType() == converterType)
                    copy.Converters.RemoveAt(i);
            return copy;
        }
    }

    // There may be wonky stylized code for adding additional JSON converters
    // It works perfectly fine, just not in my priority to check
    // whether I can make it similar to each other,
    // instead of randomly doing one of the approaches

    public class EntryValueJsonConverter : JsonConverter<EntryValue>
    {
        public override EntryValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            TypeToNameConverter converter = TypeToNameConverter.Instance;
            JsonSerializerOptions tempOptions = new JsonSerializerOptions(options);
            tempOptions.PropertyNameCaseInsensitive = true;
            tempOptions.Converters.Add(new JsonStringEnumConverter<DataType>());
            tempOptions.Converters.Add(new AttributeJsonConverter());

            var ev = JsonSerializer.Deserialize<JsonObject>(ref reader, tempOptions)!;
            JsonNode? valueValue = new JsonObject();
            JsonNode? attrValue = new JsonObject();
            ev.TryGetPropertyValue("Value", out valueValue);
            ev.TryGetPropertyValue("Attribute", out attrValue);
            Object? value = valueValue.Deserialize<Object>(tempOptions);
            Attribute? attr = attrValue.Deserialize<Attribute>(tempOptions);
            EntryValue result = new EntryValue(value, attr);
            return result;
        }
        public override void Write(Utf8JsonWriter writer, EntryValue value, JsonSerializerOptions options)
        {
            JsonSerializerOptions tempOptions = options.CopyAndRemoveConverter(GetType());
            tempOptions.PropertyNameCaseInsensitive = true;
            JsonSerializer.Serialize<EntryValue>(writer, value, tempOptions);
        }
    }
    public class EntryJsonConverter : JsonConverter<Entry>
    {
        public override Entry? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            TypeToNameConverter converter = TypeToNameConverter.Instance;
            JsonSerializerOptions tempOptions = new JsonSerializerOptions(options);
            tempOptions.PropertyNameCaseInsensitive = true;
            tempOptions.Converters.Add(new JsonStringEnumConverter<DataType>());
            tempOptions.Converters.Add(new EntryValueJsonConverter());

            var entry = JsonSerializer.Deserialize<JsonObject>(ref reader, tempOptions)!;
            JsonNode? entriesNode = new JsonObject();
            entry.TryGetPropertyValue("Values", out entriesNode);
            List<EntryValue>? entryList = entriesNode.Deserialize<List<EntryValue>>(new JsonSerializerOptions
            {
                Converters = { new EntryValueJsonConverter() }
            });
            Entry? result = new Entry(entryList);
            return result;
        }
        public override void Write(Utf8JsonWriter writer, Entry value, JsonSerializerOptions options)
        {
            JsonSerializerOptions tempOptions = options.CopyAndRemoveConverter(GetType());
            tempOptions.PropertyNameCaseInsensitive = true;
            JsonSerializer.Serialize<Entry>(writer, value, tempOptions);
        }
    }
    public class AttributeJsonConverter : JsonConverter<Attribute>
    {
        public override Attribute? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            TypeToNameConverter converter = TypeToNameConverter.Instance;
            JsonSerializerOptions tempOptions = new JsonSerializerOptions(options);
            tempOptions.PropertyNameCaseInsensitive = true;
            tempOptions.Converters.Add(new JsonStringEnumConverter<DataType>());

            var attr = JsonSerializer.Deserialize<JsonObject>(ref reader, tempOptions)!;
            JsonNode? typeValue = new JsonObject();
            attr.TryGetPropertyValue("Type", out typeValue);
            string typeStr = (typeValue != null) ? typeValue.ToString() : "";

            DataType type = converter.StringToEnum(typeStr);
            switch (type)
            {
                case DataType.Integer:
                    return attr.Deserialize<IntegerAttribute>(tempOptions);
                case DataType.RealNumber:
                    return attr.Deserialize<RealNumberAttribute>(tempOptions);
                case DataType.String:
                    return attr.Deserialize<StringAttribute>(tempOptions);
                case DataType.Char:
                    return attr.Deserialize<CharAttribute>(tempOptions);
                case DataType.Color:
                    return attr.Deserialize<ColorAttribute>(tempOptions);
                case DataType.ColorInvl:
                    return attr.Deserialize<ColorIntervalAttribute>(tempOptions);
                default:
                    throw new Exception("Type of Attribute can't be identified");
            }
        }
        public override void Write(Utf8JsonWriter writer, Attribute value, JsonSerializerOptions options)
        {
            JsonSerializerOptions tempOptions = options.CopyAndRemoveConverter(GetType());
            tempOptions.PropertyNameCaseInsensitive = true;
            JsonSerializer.Serialize<Attribute>(writer, value, tempOptions);
        }

    }
    public class TableJsonConverter : JsonConverter<Table>
    {
        public override Table? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var tempOptions = new JsonSerializerOptions(options);
            tempOptions.PropertyNameCaseInsensitive = true;

            
            var table = JsonSerializer.Deserialize<JsonObject>(ref reader, tempOptions)!;
            JsonNode? tableName = new JsonObject();
            JsonNode? attrNode = new JsonObject();
            JsonNode? entriesValue = new JsonObject();
            table.TryGetPropertyValue("Name", out tableName);
            table.TryGetPropertyValue("Attributes", out attrNode);
            table.TryGetPropertyValue("Entries", out entriesValue);
            string name = (tableName != null) ? tableName.ToString() : "";
            List<Attribute>? attrList = attrNode.Deserialize<List<Attribute>>(new JsonSerializerOptions
            {
                Converters = { new AttributeJsonConverter() }
            }
            );
            List<Entry>? entryList = entriesValue.Deserialize<List<Entry>>(new JsonSerializerOptions
            {
                Converters = { new EntryJsonConverter() }
            }
);

            Table? resultTable = new Table(name, attrList, entryList);
            return resultTable;
        }
        public override void Write(Utf8JsonWriter writer, Table value, JsonSerializerOptions options)
        {
            JsonSerializerOptions tempOptions = options.CopyAndRemoveConverter(GetType());
            tempOptions.PropertyNameCaseInsensitive = true;
            JsonSerializer.Serialize<Table>(writer, value, tempOptions);
        }
    }
    public class DatabaseJsonConverter : JsonConverter<Database>
    {
        public override Database? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var tempOptions = new JsonSerializerOptions(options);
            tempOptions.PropertyNameCaseInsensitive = true;
            var db = JsonSerializer.Deserialize<JsonObject>(ref reader, tempOptions)!;
            JsonNode? tableNode = new JsonObject();
            db.TryGetPropertyValue("Tables", out tableNode);
            List<Table>? tableList = tableNode.Deserialize<List<Table>>(new JsonSerializerOptions
            {
                Converters = { new TableJsonConverter() }
            }
            );

            Database? resultDB = new Database(tableList);
            return resultDB;
        }
        public override void Write(Utf8JsonWriter writer, Database value, JsonSerializerOptions options)
        {
            JsonSerializerOptions tempOptions = options.CopyAndRemoveConverter(GetType());
            tempOptions.PropertyNameCaseInsensitive = true;
            JsonSerializer.Serialize<Database>(writer, value, tempOptions);
        }
    }
}
