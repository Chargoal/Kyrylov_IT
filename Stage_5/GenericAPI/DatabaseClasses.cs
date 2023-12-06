using System.Text.Json;
using System.ComponentModel;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DBClasses.Models
{
    public struct Color
    {
        public int R;
        public int G;
        public int B;

        public Color(int r = 0, int g = 0, int b = 0)
        {
            R = r;
            B = b;
            G = g;
        }

        public Color(string rgbString)
        {
            // Remove any leading or trailing spaces.
            rgbString = rgbString.Trim();

            // Check if the string starts with a left bracket and ends with a right bracket.
            if (!rgbString.StartsWith("(") || !rgbString.EndsWith(")"))
            {
                throw new ArgumentException("The input string must start with a left bracket and end with a right bracket.");
            }

            // Remove the brackets.
            rgbString = rgbString.Substring(1, rgbString.Length - 2);

            // Split the string into 3 values using commas or whitespaces as separators.
            string[] rgbValues = rgbString.Split(',', ' ');
            List<string> rgbStringList = new List<string>();
            foreach (string v in rgbValues)
            {
                if (v.Trim() != "")
                    rgbStringList.Add(v);
            }
            rgbValues = rgbStringList.ToArray();

            // Check if there are exactly 3 values.
            if (rgbValues.Length != 3)
            {
                throw new ArgumentException("The input string must contain exactly 3 values for R, G, and B.");
            }

            // Parse each value as an integer between 0 and 255.
            int[] rgbInts = new int[3];
            for (int i = 0; i < 3; i++)
            {
                string value = rgbValues[i].Trim();
                int intValue = int.Parse(value);

                if (intValue < 0 || intValue > 255)
                {
                    throw new ArgumentException("The values for R, G, and B must be between 0 and 255.");
                }

                rgbInts[i] = intValue;
            }

            R = rgbInts[0];
            G = rgbInts[1];
            B = rgbInts[2];
        }

        public override string ToString()
        {
            return $"({R}, {G}, {B})";
        }
    }
    public struct ColorInterval
    {
        public Color start;
        public Color end;
        public ColorInterval(Color start, Color end)
        {
            this.start = start;
            this.end = end;
        }
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum DataType
    {
        Integer,
        RealNumber,
        Char,
        String,
        Color,
        ColorInvl
    }

    //=====================================================================

    public class Database
    {
        public List<Table> Tables { get; }

        public Database()
        {
            Tables = new List<Table>();
        }
        
        public Database(List<Table> tables = null!)
        {
            if (tables != null)
                Tables = tables;
            else
                Tables = new List<Table>();
        }
        
        public bool ContainsTable(string tableName)
        {
            return Tables.Any(table => table.Name == tableName);
        }

        public Table GetTable(string name)
        {
            return this.Tables.Find(t => t.Name == name);
        }

        public void AddTable(Table table)
        {
            if (ContainsTable(table.Name))
            {
                throw new Exception("Database already contains a table with the specified name.");
            }

            Tables.Add(table);
        }

        public void UpdateTable(Table table)
        {
            Table oldTable = Tables.Find(t => t.Name == table.Name);
            Tables.Remove(oldTable);
            Tables.Add(table);
        }

        public void RemoveTable(Table table)
        {
            if (!ContainsTable(table.Name))
            {
                throw new Exception("Database already doesn't have specific table");
            }

            Tables.Remove(table);
        }
        public void RemoveTable(string tableName)
        {
            if (!ContainsTable(tableName))
            {
                throw new Exception("Database already doesn't have specific table");
            }

            Tables.Remove(GetTable(tableName));
        }
    }

    public class Table
    {
        [Required]
        public string Name { get; }
        public List<Attribute> Attributes { get; }
        public List<Entry> Entries { get; }
        // Not a parameter but good to create
        // infinite amount of entry schemes
        /*
        public Entry EntryScheme()
        {
            Entry entry = new Entry();
            foreach (Attribute attr in Attributes)
                entry.AddValue(new EntryValue(null, attr));
            return entry;
        }
        */
        public Table(string name)
        {
            Name = name;
            Attributes = new List<Attribute>();
            Entries = new List<Entry>();
        }
        public Table(string name, List<Attribute>? attributes, List<Entry>? entries)
        {
            Name = name;
            Attributes = new List<Attribute>();
            Entries = new List<Entry>();

            if (attributes != null)
                foreach (Attribute attr in attributes)
                    AddAttribute(attr);
            if (entries != null)
                foreach (Entry entry in entries)
                    AddEntry(entry);

        }

        public bool ContainsAttribute(string attributeName)
        {
            return Attributes.Any(attribute => attribute.Name == attributeName);
        }
        public void AddAttribute(Attribute attribute)
        {
            if (ContainsAttribute(attribute.Name))
            {
                throw new Exception("Table already contains an attribute with the specified name.");
            }

            Attributes.Add(attribute);
        }
        public Attribute? GetAttribute(string name)
        {
            return Attributes.Find(a => a.Name == name);
        }
        public void RemoveAttribute(string attrName)
        {
            Attribute? attr = GetAttribute(attrName);
            if (attr != null)
            {
                Attributes.Remove(attr);
                foreach (Entry entry in Entries)
                    entry.RemoveValue(attr.Name);
            }
        }
        
        public bool? AddEntry(Entry entry)
        {
            if (IsEntryValid(entry) == true)
                Entries.Add(entry);
            return IsEntryValid(entry);
        }
        public Entry? GetEntry(int index)
        {
            try
            {
                return Entries[index];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
        public void RemoveEntry(int index)
        {
            Entries.RemoveAt(index);
        }
        public bool RemoveEntry(Entry entry)
        {
            return Entries.Remove(entry);
        }
        public bool? IsEntryValid(Entry? entry)
        {
            if (entry == null)
                return null;
            else
            {
                foreach (Attribute attr in Attributes)
                {
                    string attrName = attr.Name;
                    if (entry.Values.FindAll(v => v.Attribute == attr).Count > 1)
                        return false;
                }
            }
            return true;
        }

        public Table Clone()
        {
            Table clonedTable = new Table(this.Name);
            foreach (Attribute attribute in this.Attributes)
            {
                clonedTable.Attributes.Add(attribute.Clone());
            }
            foreach (Entry entry in this.Entries)
            {
                clonedTable.Entries.Add(entry.Clone());
            }
            return clonedTable;
        }
    }

    public abstract class Attribute
    {
        [Required]
        public string Name { get; set; }
        public DataType Type { get; set; }

        public Attribute(string name, DataType type)
        {
            Name = name;
            Type = type;
        }

        public abstract bool Validate(object value);

        public static bool operator== (Attribute obj1, Attribute obj2)
        {
            return (obj1.Name == obj2.Name 
                && obj1.Type == obj2.Type);
        }
        public static bool operator!= (Attribute obj1, Attribute obj2)
        {
            return (obj1.Name != obj2.Name
                || obj1.Type != obj2.Type);
        }

        public Attribute Clone()
        {
            return DataManager.Instance.CreateAttribute(this.Name, this.Type);
        }
    }
    public class IntegerAttribute : Attribute
    {
        public IntegerAttribute(string name) : base(name, DataType.Integer) { }

        public int StringToType(object value)
        {
            int propValue = 0;
            TypeConverter typeConverter = TypeDescriptor.GetConverter(propValue);
            propValue = (int)typeConverter.ConvertFromString(value.ToString());
            return propValue;
        }

        public override bool Validate(object value)
        {
            try
            {
                if (value is string)
                {
                    StringToType(value);
                    return true;
                }
                else if (value is int)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }
    }
    public class RealNumberAttribute : Attribute
    {
        public RealNumberAttribute(string name) : base(name, DataType.RealNumber) { }

        public double StringToType(object value)
        {
            double propValue = 0;
            TypeConverter typeConverter = TypeDescriptor.GetConverter(propValue);
            propValue = (double)typeConverter.ConvertFromString(value.ToString());
            return propValue;
        }

        public override bool Validate(object value)
        {
            try
            {
                if (value is string)
                {
                    StringToType(value);
                    return true;
                }
                else if (value is double)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }
    }
    public class CharAttribute : Attribute
    {
        public CharAttribute(string name) : base(name, DataType.Char) { }

        public char StringToType(object value)
        {
            char propValue = ' ';
            TypeConverter typeConverter = TypeDescriptor.GetConverter(propValue);
            propValue = (char)typeConverter.ConvertFromString(value.ToString());
            return propValue;
        }

        public override bool Validate(object value)
        {
            try
            {
                if (value is string)
                {
                    StringToType(value);
                    return true;
                }
                else if (value is char)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }
    }
    public class StringAttribute : Attribute
    {
        public StringAttribute(string name) : base(name, DataType.String) { }


        public string StringToType(object value)
        {
            return value.ToString();
        }

        public override bool Validate(object value)
        {
            try
            {
                if (!(value is string))
                {
                    string v = StringToType(value);
                    return true;
                }
                else if (value is string)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }
    }
    public class ColorAttribute : Attribute
    {
        public ColorAttribute(string name) : base(name, DataType.Color) { }

        public override bool Validate(object value)
        {
            try
            {
                if (value is string && value != "")
                {
                    Color col = new Color((string)value);
                    return true;
                }
                else if (value is Color)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }
    }
    public class ColorIntervalAttribute : Attribute
    {
        public ColorIntervalAttribute(string name) : base(name, DataType.ColorInvl) { }

        public ColorInterval StringToType(object value)
        {
            ColorAttribute cAttr = new ColorAttribute("c");
            string valstr = value.ToString().Trim();

            // Split the string into two parts at the semicolon.
            string[] parts = valstr.Split(';');

            string col1str = parts[0];
            string col2str = parts[1];

            int openBracketIndex = col1str.IndexOf('[');
            int closeBracketIndex = col2str.IndexOf(']');

            col1str = col1str.Substring(openBracketIndex + 1).Trim();
            col2str = col2str.Substring(0, col2str.Length - 1).Trim();

            if (!cAttr.Validate(col1str) || !cAttr.Validate(col2str))
            {
                throw new Exception("Empty string for color name");
            }

            Color col1 = new Color(col1str);
            Color col2 = new Color(col2str);

            return new ColorInterval(col1, col2);
        }

        public override bool Validate(object value)
        {
            try
            {
                if (value is string)
                {
                    StringToType(value);
                    return true;
                }
                else if (value is ColorInterval)
                {
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }
    }

    public class Entry
    {
        public List<EntryValue> Values { get; }
        public Entry()
        {
            Values = new List<EntryValue>();
        }
        public Entry(List<EntryValue>? list)
        {
            if (list != null) Values = list;
            else Values = new List<EntryValue>();
        }

        public void AddValue(EntryValue value)
        {
            Values.Add(value);
        }
        public EntryValue? GetValue(string attributeName)
        {
            return Values.Find(v => v.Attribute.Name == attributeName);
        }
        public void RemoveValue(string attributeName)
        {
            EntryValue? value = GetValue(attributeName);
            if (value != null) Values.Remove(value);
        }
        public Entry Clone()
        {
            Entry clonedEntry = new Entry();
            foreach (EntryValue entryValue in this.Values)
            {
                clonedEntry.Values.Add(entryValue.Clone());
            }
            return clonedEntry;
        }
    }
    public class EntryValue
    {
        public object? Value { get; }
        [Required]
        public Attribute Attribute { get; }

        public EntryValue(object? value, Attribute attribute)
        {
            Attribute = attribute;
            Value = value;
        }
        public EntryValue Clone()
        {
            return new EntryValue(this.Value, this.Attribute.Clone());
        }
    }
    //============================================

    public class DataManager
    {
        public Database? CurrentDatabase { get; set; }

        private DataManager()
        {
            //CurrentDatabase = new Database();
        }

        private static DataManager? instance;
        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }

                return instance;
            }
        }
        
        // Will be deprecated if new JsonConverters can be used instead.
        /*
        public static void Serialize(Database database, Stream stream)
        {
            var writer = new Utf8JsonWriter(stream);
            writer.WriteStartObject();
            writer.WritePropertyName("Tables");
            writer.WriteStartArray();
            foreach (var table in database.Tables)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("Name");
                writer.WriteStringValue(table.Name);
                writer.WritePropertyName("Attributes");
                writer.WriteStartArray();
                foreach (var attribute in table.Attributes)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("Name");
                    writer.WriteStringValue(attribute.Name);
                    writer.WritePropertyName("Type");
                    writer.WriteStringValue(attribute.Type.ToString());
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WritePropertyName("Entries");
                writer.WriteStartArray();
                foreach (var entry in table.Entries)
                {
                    writer.WriteStartObject();
                    foreach (var attribute in table.Attributes)
                    {
                        writer.WritePropertyName(attribute.Name);
                        var value = entry.GetValue(attribute.Name);
                        if (value != null)
                            writer.WriteStringValue(value.ToString());
                        else
                            writer.WriteStringValue("");
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Flush();
        }

        public static Database Deserialize(ReadOnlyMemory<byte> json)
        {
            var converter = TypeToNameConverter.Instance;
            var document = JsonDocument.Parse(json);
            var database = new Database();

            var tables = document.RootElement.GetProperty("Tables");
            foreach (var tableElement in tables.EnumerateArray())
            {
                string tableName = tableElement.GetProperty("Name").GetString();
                var table = new Table(tableName);

                var attributes = tableElement.GetProperty("Attributes");
                foreach (var attributeElement in attributes.EnumerateArray())
                {
                    string attrName = attributeElement.GetProperty("Name").GetString();

                    DataType attrType = converter.StringToEnum(attributeElement.GetProperty("Type").GetString());

                    var attribute = Instance.CreateAttribute(attrName, attrType);

                    table.Attributes.Add(attribute);
                }

                var entries = tableElement.GetProperty("Entries");
                foreach (var entryElement in entries.EnumerateArray())
                {
                    var entry = new Entry();

                    foreach (var attributeElement in attributes.EnumerateArray())
                    {
                        string attrName = attributeElement.GetProperty("Name").GetString();
                        Attribute attr = table.GetAttribute(attrName);
                        EntryValue ev = new EntryValue(entryElement.GetProperty(attributeElement.GetProperty("Name").GetString()).GetString(), attr);
                        entry.AddValue(ev);
                    }
                    table.Entries.Add(entry);
                }
                database.Tables.Add(table);
            }
            return database;
        }
        */
        
        // Open/Save feature. Used WinForms, needs tweaks
        /*
        public void SaveDatabase()
            {
                if (CurrentDatabase != null)
                {
                    // Ask the user to save their work.
                    DialogResult unsavedDBWarningResult =
                        MessageBox.Show("You have an open database. Would you like to save your work before closing this database?",
                        "Open/Create New Database", MessageBoxButtons.YesNoCancel);
                    if (unsavedDBWarningResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (unsavedDBWarningResult == DialogResult.Yes)
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Database (*.json)|*.json";
                        saveFileDialog.Title = "Save your database";
                        saveFileDialog.RestoreDirectory = true;
                        saveFileDialog.ShowDialog();
                        if (saveFileDialog.FileName != "")
                        {
                            FileStream fs = (FileStream)saveFileDialog.OpenFile();
                            //WriteDatabase(fs);
                            Serialize(CurrentDatabase, fs);
                            fs.Close();
                        }

                        // Close the current database.
                        //CurrentDatabase = null;
                    }
                }
            }

        public void CreateDatabase(string name)
            {
                SaveDatabase();

                // Create the new database.
                Database database = new Database(name);

                // Set the new database as the current database.
                CurrentDatabase = database;
            }
        
        public void OpenDatabase()
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                if (CurrentDatabase != null)
                    SaveDatabase();

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Database files (*.json)|";
                    openFileDialog.Title = "Open your database";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        Stream fs = openFileDialog.OpenFile();

                        var file = ReadFully(fs);
                        CurrentDatabase = Deserialize(file);
                        fs.Close();
                    }
                    else
                    {

                    }
                }
            }
        */
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public void CreateTable(string name, List<Attribute> attributes)
        {
            // Validate the name and attributes of the new table.
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Table name cannot be empty.");
            }

            if (attributes.Count == 0)
            {
                throw new Exception("Table must have at least one attribute.");
            }

            // Create a new Table object with the name and attributes of the new table.
            Table table = new Table(name);
            foreach (Attribute attribute in attributes)
            {
                table.AddAttribute(attribute);
            }

            // Add the new table to the DataManager class's list of tables.
            CurrentDatabase.AddTable(table);
        }

        public Attribute CreateAttribute(string name, DataType type)
        {
            switch (type)
            {
                case DataType.Integer:
                    return new IntegerAttribute(name);
                case DataType.RealNumber:
                    return new RealNumberAttribute(name);
                case DataType.Char:
                    return new CharAttribute(name);
                case DataType.String:
                    return new StringAttribute(name);
                case DataType.Color:
                    return new ColorAttribute(name);
                case DataType.ColorInvl:
                    return new ColorIntervalAttribute(name);
                default:
                    throw new Exception($"Unknown data type: {type}");
            }
        }
        /*
        public void DeleteTable(string tableName)
        {
                Table t = CurrentDatabase.Tables.Find(table => table.Name == tableName);
                CurrentDatabase.RemoveTable(t);
        }
        */
        public Table SearchTable(Table table, Entry searchPatterns)
        {
            int i = 0;
            Table foundTable = table.Clone();

            // Iterate over the entry and add them to the foundEntries list if they match the search patterns.
            foreach (Entry entry in table.Entries)
            {
                bool matchesAllPatterns = true;
                foreach (EntryValue searchPattern in searchPatterns.Values)
                {
                    string ev = entry.GetValue(searchPattern.Attribute.Name).Value.ToString();
                    string searchStr;
                    if (searchPattern.Value == null)
                        searchStr = "";
                    else
                        searchStr = searchPattern.Value.ToString();
                    bool f = !ev.ToString().Contains(searchStr);
                    if (f)
                    {
                        matchesAllPatterns = false;
                        break;
                    }
                }

                if (!matchesAllPatterns)
                {
                    if (foundTable.Entries.Contains(entry))
                    {
                        foundTable.Entries.Remove(entry);
                    }
                    else
                    {
                        foundTable.Entries.RemoveAt(i);
                    }
                }
                else
                {
                    i++;
                }
            }
            // Return the list of found entries.
            return foundTable;
        }
    }

    class TypeToNameConverter
    {
        private static TypeToNameConverter instance;
        private Dictionary<DataType, string> dict = new Dictionary<DataType, string>();
        private List<string> TypeNames;

        public TypeToNameConverter()
        {
            foreach (DataType type in (DataType[])Enum.GetValues(typeof(DataType)))
            {
                string name = Enum.GetName(typeof(DataType), type);
                dict.Add(type, name);
            }

            TypeNames = new List<string>(Enum.GetNames(typeof(DataType)));
        }

        public static TypeToNameConverter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TypeToNameConverter();
                }

                return instance;
            }
        }

        public string EnumToString(DataType type)
        {
            dict.TryGetValue(type, out string str);
            return str;
        }

        public DataType StringToEnum(string str)
        {
            if (dict.ContainsValue(str))
            {
                DataType type = dict.FirstOrDefault(x => x.Value == str).Key;
                return type;
            }
            return DataType.Integer;
        }

        public List<string> GetTypeNames
        {
            get
            {
                //return new List<string>(Enum.GetNames(typeof(DataType)));
                return TypeNames;
            }
        }
    }
}