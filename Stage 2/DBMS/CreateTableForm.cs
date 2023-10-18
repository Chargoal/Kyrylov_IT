using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DBMS
{
    public partial class CreateTableForm : Form
    {
        private DataManager dataManager = DataManager.Instance;
        private TypeConverter converter = TypeConverter.Instance;
        private int initAttrAmount = 3;
        private int currentAttrAmount;
        private List<AttributeGroup> attributes = new List<AttributeGroup>();

        public CreateTableForm()
        {
            InitializeComponent();
            currentAttrAmount = initAttrAmount;

            for (int i = 0; i < currentAttrAmount; i++)
            {
                CreateAttribute();
            }
        }

        private void CreateAttribute()
        {
            AttributeGroup attr = new AttributeGroup(AttributesFlowLayoutPanel, RemoveAttribute);
            AttributesFlowLayoutPanel.Controls.Add(attr);
        }

        private void CreateAttributeButton_Click(object sender, EventArgs e)
        {
            CreateAttribute();
        }

        public void RemoveAttribute(object sender, EventArgs e)
        {
            // Get the parent object of the sender.
            Button btn = (Button)sender;
            AttributeGroup parent = btn.Parent as AttributeGroup;

            if (parent != null)
            {
                // Remove the groupbox from the flow layout panel.
                AttributesFlowLayoutPanel.Controls.Remove(parent);
            }
        }

        private void GlobalValidation()
        {
            try
            {
                TextBox TableName = (TextBox)Controls.Find("TableNameTextBox", true)[0];
                bool flag = ValidateName(TableName.Text);
                if (flag)
                {
                    TableName.BackColor = Color.White;
                    FlowLayoutPanel flp = (FlowLayoutPanel)Controls.Find("AttributesFlowLayoutPanel", true)[0];
                    foreach (Control c in flp.Controls.Find("AttributeGroup", true))
                    {
                        AttributeGroup ag = (AttributeGroup)c;
                        TextBox tb = (TextBox)ag.Controls.Find("AttributeName", true)[0];
                        tb.BackColor = Color.White;
                        if (!ValidateName(tb.Text))
                        {
                            flag = false;
                            tb.BackColor = Color.Red;
                        }
                    }
                    if (!flag)
                    {
                        Exception e = new Exception("Деякі значення назв атрибутів не підпадають під формат назв." +
                            "Переконайтеся, що назви абетко-цифрові, перший символ не є цифрою, та в назві нема інших символів.");
                        throw e;
                    }
                }
                else
                {
                    TableName.BackColor = Color.Red;
                    Exception e = new Exception("Назва таблиці не не підпадає під формат назв." +
                            "Переконайтеся, що назва абетко-цифрова, перший символ не є цифрою, та в назві нема інших символів.");
                    throw e;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                    "Помилка формату назв", MessageBoxButtons.OK);
            }
        }

        private void CreateTableButton_Click(object sender, EventArgs e)
        {
            GlobalValidation();
            CreateTable();
            this.Close();
        }

        private void CreateTable()
        {
            try
            {
                TextBox TableName = (TextBox)Controls.Find("TableNameTextBox", true)[0];
                FlowLayoutPanel flp = (FlowLayoutPanel)Controls.Find("AttributesFlowLayoutPanel", true)[0];
                List<Attribute> attributes = new List<Attribute>();
                foreach (Control c in flp.Controls.Find("AttributeGroup", true))
                {
                    AttributeGroup ag = (AttributeGroup)c;
                    TextBox tb = (TextBox)ag.Controls.Find("AttributeName", true)[0];
                    ListBox typeList = (ListBox)ag.Controls.Find("AttributeType", true)[0];
                    DataType type = converter.StringToEnum(typeList.Text);
                    Attribute attr = dataManager.CreateAttribute(tb.Text, type);
                    attributes.Add(attr);
                }
                dataManager.CreateTable(TableName.Text, attributes);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                    "Помилка при створенні таблиці", MessageBoxButtons.OK);
            }
        }

        private void AttributesFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)sender;
            foreach (Control c in flp.Controls)
            {
                Button button = (Button)c.Controls.Find("AttributeRemove", true)[0];
                TextBox name = (TextBox)c.Controls.Find("AttributeName", true)[0];
                ListBox type = (ListBox)c.Controls.Find("AttributeType", true)[0];

                c.Width = flp.Width - 25;
                type.Height = name.Height;
                c.Height = name.Height * 2;
                button.Width = button.Height;
                name.Width = (c.Width / 3);
            }
        }

        public bool ValidateName(string text)
        {
            // Check if the text is empty.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            // Check if the first character of the text is a number.
            if (text[0] >= '0' && text[0] <= '9')
            {
                return false;
            }

            // Check if all of the characters in the text are alphanumeric.
            foreach (char character in text)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    return false;
                }
            }

            // The text is valid.
            return true;
        }
    }

    //===========================================================

    class AttributeGroup : FlowLayoutPanel
    {
        private TypeConverter Converter = TypeConverter.Instance;

        public AttributeGroup(FlowLayoutPanel parent, EventHandler eb)
        {
            Button AttributeRemoveButton = new Button();
            TextBox AttributeNameTextBox = new TextBox();
            ListBox AttributeTypeListBox = new ListBox();

            Name = "AttributeGroup";
            Width = parent.Width -25;
            FlowDirection = FlowDirection.LeftToRight;

            AttributeRemoveButton.Name = "AttributeRemove";
            AttributeRemoveButton.Text = "-";
            AttributeRemoveButton.Location = new Point(parent.Width - AttributeRemoveButton.Width, 0);
            AttributeRemoveButton.Click += new EventHandler(eb);
            AttributeRemoveButton.Width = AttributeRemoveButton.Height;

            AttributeNameTextBox.Name = "AttributeName";
            AttributeNameTextBox.Width = (parent.Width / 3);

            AttributeTypeListBox.Name = "AttributeType";
            AttributeTypeListBox.Height = AttributeNameTextBox.Height;

            Height = AttributeNameTextBox.Height * 2;

            AttributeTypeListBox.BeginUpdate();
            foreach (string name in Converter.GetTypeNames)
            {
                AttributeTypeListBox.Items.Add(name);
            }
            AttributeTypeListBox.EndUpdate();

            Controls.Add(AttributeNameTextBox);
            Controls.Add(AttributeTypeListBox);
            Controls.Add(AttributeRemoveButton);
        }

        public string AttributeName
        {
            get 
            {
                TextBox AttributeNameTextBox = (TextBox)Controls.Find("AttributeName", true)[0];
                return AttributeNameTextBox.Text; 
            }
        }

        public string AttributeType
        {
            get 
            {
                ListBox AttributeTypeListBox = (ListBox)Controls.Find("AttributeType", true)[0];
                return AttributeTypeListBox.Text; 
            }
        }

        public Button AttributeRemove
        {
            get 
            {
                Button AttributeRemoveButton = (Button)Controls.Find("AttributeRemove", true)[0];
                return AttributeRemoveButton; 
            }
        }


    }
}