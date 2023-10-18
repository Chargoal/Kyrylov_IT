using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
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
        public void ValidateColorValue()
        {
            // Create a text file attribute.
            Color slateBlue = Color.FromName("SlateBlue");
            DBMS.Attribute attribute = new ColorAttribute("Color");

            // Create a value.
            Color value = slateBlue;

            // Validate the value.
            Assert.IsTrue(attribute.Validate(value));
        }

        [TestMethod]
        public void ValidateColorIntervalValue()
        {
            // Create a string interval attribute.
            Color slateBlue = Color.FromName("SlateBlue");
            Color AliceBlue = Color.FromName("AliceBlue");
            DBMS.Attribute attribute = new ColorIntervalAttribute("interval");

            // Create a value of type string.
            ColorInterval value = new ColorInterval(slateBlue, AliceBlue);

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