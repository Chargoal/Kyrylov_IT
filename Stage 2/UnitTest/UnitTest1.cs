using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DBMS;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateIntegerValue()
        {
            // Create an integer attribute.
            DBMS.Attribute attribute = new IntegerAttribute("age");

            // Create a value of type integer.
            int value = 123;

            // Validate the value.
            Assert.IsTrue(attribute.Validate(value));
        }

        [TestMethod]
        public void ValidateRealNumberValue()
        {
            // Create a real number attribute.
            DBMS.Attribute attribute = new RealNumberAttribute("height");

            // Create a value of type double.
            double value = 5.5;

            // Validate the value.
            Assert.IsTrue(attribute.Validate(value));
        }

        [TestMethod]
        public void ValidateCharValue()
        {
            // Create a char attribute.
            DBMS.Attribute attribute = new CharAttribute("gender");

            // Create a value of type char.
            char value = 'M';

            // Validate the value.
            Assert.IsTrue(attribute.Validate(value));
        }

        [TestMethod]
        public void ValidateStringValue()
        {
            // Create a string attribute.
            DBMS.Attribute attribute = new StringAttribute("name");

            // Create a value of type string.
            string value = "John Doe";

            // Validate the value.
            Assert.IsTrue(attribute.Validate(value));
        }

        [TestMethod]
        public void ValidateTextFileValue()
        {
            // Create a text file attribute.
            DBMS.Attribute attribute = new TextFileAttribute("file");

            // Create a value of type string.
            string value = "C:\\Users\\volko\\Documents\\Uni\\DBMS\\file.txt";

            // Validate the value.
            Assert.IsTrue(attribute.Validate(value));
        }

        [TestMethod]
        public void ValidateStringIntervalValue()
        {
            // Create a string interval attribute.
            DBMS.Attribute attribute = new StringIntervalAttribute("interval");

            // Create a value of type string.
            StringInterval value = new StringInterval("asd", "nnn");

            // Validate the value.
            Assert.IsTrue(attribute.Validate(value));
        }
        /*
        [TestMethod]
        public void TestMethod6()
        {
            DBMenu menu = new DBMenu();
            menu.CurrentBase = new Base();
            List<Tuple<string, string>> NamesTypes = new List<Tuple<string, string>>();
            NamesTypes.Add(new Tuple<string, string>("1", "String"));
            NamesTypes.Add(new Tuple<string, string>("2", "String"));
            menu.CreateTable("Table1", NamesTypes);
            NamesTypes = new List<Tuple<string, string>>();
            NamesTypes.Add(new Tuple<string, string>("2", "String"));
            NamesTypes.Add(new Tuple<string, string>("1", "String"));
            menu.CreateTable("Table2", NamesTypes);
            menu.OpenTable("Table1");
            menu.AddRow(); menu.AddRow();
            menu.ChangeRowValue(0, 0, "1"); menu.ChangeRowValue(0, 1, "2");
            menu.ChangeRowValue(1, 0, "1"); menu.ChangeRowValue(1, 1, "1");
            menu.OpenTable("Table2");
            menu.AddRow(); menu.AddRow();
            menu.ChangeRowValue(0, 0, "2"); menu.ChangeRowValue(0, 1, "1");
            menu.ChangeRowValue(1, 0, "2"); menu.ChangeRowValue(1, 1, "2");
            List<string> s = new List<string>(); s.Add("Table1"); s.Add("Table2");
            menu.Union("Table3", s);
            menu.OpenTable("Table3");
            Assert.AreEqual(menu.CurrentTable.Fields[0].Values.Count, 3);
        }
        */
    }
}