using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.IO;
using System.Text.Json;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace DBMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
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

    public enum DataType
    {
        Integer,
        RealNumber,
        Char,
        String,
        Color,
        ColorInvl
    }

    public class EntryValue
    {
        public object Value { get; }
        public Attribute Argument { get; }

        public EntryValue(object value, Attribute argument)
        {
            Value = value;
            Argument = argument;

            //Argument.Validate(Value);
        }
        /*
        private void Validate()
        {
            switch (Argument.Type)
            {
                case DataType.Integer:
                    if (!(value is int))
                    {
                        throw new Exception("Value does not correspond with type.");
                    }
                    break;
                case DataType.RealNumber:
                    if (!(value is double))
                    {
                        throw new Exception("Value does not correspond with type.");
                    }
                    break;
                case DataType.Char:
                    if (!(value is char))
                    {
                        throw new Exception("Value does not correspond with type.");
                    }
                    break;
                case DataType.String:
                    if (!(value is string))
                    {
                        throw new Exception("Value does not correspond with type.");
                    }
                    break;
                case DataType.TextFile:
                    if (!(value is string) || !(File.Exists((string)value)))
                    {
                        throw new Exception("Value does not correspond with type.");
                    }
                    break;
                case DataType.StringInterval:
                    if (value is string)
                    {
                        throw new Exception("Value does not correspond with type.");
                    }
                    break;
                default:
                    throw new Exception("Unknown data type.");
            }
        }
        */
    }

    public class Database
    {
        public string Name { get; }
        public List<Table> Tables { get; }

        public Database(string name)
        {
            Name = name;
            Tables = new List<Table>();
        }
        
        public bool ContainsTable(string tableName)
        {
            return Tables.Any(table => table.Name == tableName);
        }

        public void AddTable(Table table)
        {
            if (ContainsTable(table.Name))
            {
                throw new Exception("Database already contains a table with the specified name.");
            }

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

        public Table GetTable(string name)
        {
            return this.Tables.Find(t => t.Name == name);
        }

        public void Search(string pattern)
        {
            // Search for entries in all tables that match the pattern.
        }
    }

    public class Table
    {
        public string Name { get; }
        public List<Attribute> Attributes { get; }
        public List<Entry> Entries { get; }

        public Table(string name)
        {
            Name = name;
            Attributes = new List<Attribute>();
            Entries = new List<Entry>();
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

        public Attribute GetAttribute(string name)
        {
            return Attributes.Find(a => a.Name == name);
        }

        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }

        public Entry GetEntry(int index)
        {
            return Entries[index];
        }

        public void DeleteEntry(int index)
        {
            Entries.RemoveAt(index);
        }
    }

    //=====================================================================
    public abstract class Attribute
    {
        public string Name { get; set; }
        public DataType Type { get; }

        public Attribute(string name, DataType type)
        {
            Name = name;
            Type = type;
        }

        public abstract bool Validate(object value);
    }

    public class IntegerAttribute : Attribute
    {
        public IntegerAttribute(string name) : base(name, DataType.Integer) { }

        public override bool Validate(object value)
        {
            return value is int;
        }
    }

    public class RealNumberAttribute : Attribute
    {
        public RealNumberAttribute(string name) : base(name, DataType.RealNumber) { }

        public override bool Validate(object value)
        {
            return value is double;
        }
    }

    public class CharAttribute : Attribute
    {
        public CharAttribute(string name) : base(name, DataType.Char) { }

        public override bool Validate(object value)
        {
            return value is char;
        }
    }

    public class StringAttribute : Attribute
    {
        public StringAttribute(string name) : base(name, DataType.String) { }

        public override bool Validate(object value)
        {
            return value is string;
        }
    }

    public class ColorAttribute : Attribute
    {
        public ColorAttribute(string name) : base(name, DataType.Color) { }

        public override bool Validate(object value)
        {
            return value is Color;           
        }
    }

    public class ColorIntervalAttribute : Attribute
    {
        public ColorIntervalAttribute(string name) : base(name, DataType.ColorInvl)
        {
        }

        public override bool Validate(object value)
        {
            return value is ColorInterval;
        }
    }
    //========================================================================
    public class Entry
    {
        private List<EntryValue> Values { get; }

        public Entry()
        {
            Values = new List<EntryValue>();
        }

        public void AddValue(EntryValue value)
        {
            Values.Add(value);
        }

        public object GetValue(string attributeName)
        {
            return Values.Find(v => v.Argument.Name == attributeName);
        }
    }

    //============================================

    public class DataManager
    {
        private static DataManager instance;
        public Database CurrentDatabase { get; set; }
        public Table LastCreatedTable { get; set; }

        private DataManager() { }

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
        
        public void WriteDatabase(FileStream fileStream)
        {
            // Get the current database.
            Database database = CurrentDatabase;

            // Serialize the database to JSON.
            string json = JsonSerializer.Serialize(database);

            // Write the JSON to the file stream.
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            fileStream.Write(bytes, 0, bytes.Length);
        }
        /*
        // Rotten!
        
        public void ReadDatabase(Stream stream)
        {
            // Create a new BinaryFormatter object.
            BinaryFormatter formatter = new BinaryFormatter();

            // Deserialize the database object from the JSON file.
            Database database = (Database)formatter.Deserialize(stream);

            // Close the stream.
            stream.Close();
        }
        */
        // Rotten!
        
        public void ReadDatabase(Stream stream)
        {
            // Read the JSON from the stream.
            string json = new StreamReader(stream).ReadToEnd();
            
            // Deserialize the JSON to a database object.
            Database database = JsonSerializer.Deserialize<Database>(json);

            // Set the current database to the deserialized database object.
            CurrentDatabase = database;
        }
        

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
                        WriteDatabase(fs);
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

                    ReadDatabase(fs);
                    fs.Close();
                }
                else
                {

                }
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

            LastCreatedTable = table;
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

        public void DeleteTable(string tableName)
        {
            Table t = CurrentDatabase.Tables.Find(table => table.Name == tableName);
            CurrentDatabase.RemoveTable(t);
        }
    }

    class TypeConverter
    {
        private static TypeConverter instance;
        private Dictionary<DataType, string> dict = new Dictionary<DataType, string>();
        private List<string> TypeNames;

        public TypeConverter() 
        {
            foreach (DataType type in (DataType[])Enum.GetValues(typeof(DataType)))
            {
                string name = Enum.GetName(typeof(DataType), type);
                dict.Add(type, name);
            }

            TypeNames = new List<string>(Enum.GetNames(typeof(DataType)));
        }

        public static TypeConverter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TypeConverter();
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
            Enum.TryParse(str, out DataType type);
            return type;
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