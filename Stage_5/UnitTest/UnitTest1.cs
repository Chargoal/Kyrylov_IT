using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using DBMS;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateIntegerValue()
        {
            DBMS.Attribute attribute = new IntegerAttribute("Int");
            Assert.IsTrue(attribute.Validate("14"));
        }

        [TestMethod]
        public void ValidateRealNumberValue()
        {
            DBMS.Attribute attribute = new RealNumberAttribute("Real");
            Assert.IsTrue(attribute.Validate("3,123"));
        }

        [TestMethod]
        public void ValidateCharValue()
        {
            DBMS.Attribute attribute = new CharAttribute("Char");
            Assert.IsTrue(attribute.Validate("s"));
        }

        [TestMethod]
        public void ValidateStringValue()
        {
            DBMS.Attribute attribute = new StringAttribute("str");
            Assert.IsTrue(attribute.Validate("a quick brown fox"));
        }

        [TestMethod]
        public void ValidateColorValue()
        {
            DBMS.Attribute attribute = new ColorAttribute("Color");
            Assert.IsTrue(attribute.Validate("(10, 255, 0)"));
        }

        [TestMethod]
        public void ValidateColorIntervalValue()
        {
            DBMS.Attribute attribute = new ColorIntervalAttribute("interval");
            Assert.IsTrue(attribute.Validate("[(23, 34, 45); (250, 123, 32)]"));
        }

        [TestMethod]
        public void ValidateSearchTable()
        {
            DataManager dataManager = DataManager.Instance;

            Table table = new Table("Search");
            DBMS.Attribute a1 = dataManager.CreateAttribute("a1", DataType.Integer);
            DBMS.Attribute a2 = dataManager.CreateAttribute("a2", DataType.Integer);
            table.AddAttribute(a1);
            table.AddAttribute(a2);
            Entry e1 = new Entry();
            e1.AddValue(new EntryValue(3123, a1));
            e1.AddValue(new EntryValue(634, a2));
            table.AddEntry(e1);
            Entry e2 = new Entry();
            e2.AddValue(new EntryValue(3461, a1));
            e2.AddValue(new EntryValue(6, a2));
            table.AddEntry(e2);
            Entry e3 = new Entry();
            e3.AddValue(new EntryValue(1234, a1));
            e3.AddValue(new EntryValue(134, a2));
            table.AddEntry(e3);
            Entry e4 = new Entry();
            e4.AddValue(new EntryValue(6131, a1));
            e4.AddValue(new EntryValue(345, a2));
            table.AddEntry(e4);

            Entry searchEntry = new Entry();
            searchEntry.AddValue(new EntryValue("12", a1));
            searchEntry.AddValue(new EntryValue("6", a2));

            // Act
            Table resTable = dataManager.SearchTable(table, searchEntry);
            bool flag = (resTable.Entries.Count == 1)
                && ((int)resTable.Entries[0].GetValue("a1") == (int)e1.GetValue("a1")) 
                && ((int)resTable.Entries[0].GetValue("a2") == (int)e1.GetValue("a2"));
            Assert.IsTrue(flag);
        }
    }
}