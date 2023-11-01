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
            Assert.IsTrue(attribute.Validate("SlateBlue"));
        }

        [TestMethod]
        public void ValidateColorIntervalValue()
        {
            DBMS.Attribute attribute = new ColorIntervalAttribute("interval");
            Assert.IsTrue(attribute.Validate("[Red; Teal]"));
        }

        [TestMethod]
        public void ValidateLoadAndSearch()
        {
            /*
            DataManager dataManager = DataManager.Instance;
            dataManager.OpenDatabase();

            // Act
            SearchTable(tabPage, table);
            Assert.AreEqual(1, dataGridView.Rows.VisibleCount);
            */
            //gridControl.BindingContext = new System.Windows.Forms.BindingContext();
            //Assert.AreEqual(1, dataGridView.Rows.VisibleCount);
        }
    }
}