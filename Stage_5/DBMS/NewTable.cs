using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{


    class AttributeGroup : GroupBox
    {
        private Button AttributeRemoveButton;
        private TextBox AttributeNameTextBox;
        private ListBox AttributeTypeListBox;
        private TypeConverter Converter = TypeConverter.Instance;

        public AttributeGroup(Point point)
        {
            this.AttributeRemoveButton = new Button();
            this.AttributeNameTextBox = new TextBox();
            this.AttributeTypeListBox = new ListBox();

            this.Location = point;
            this.Size = new Size(661, 54);
            this.FlatStyle = FlatStyle.Flat;

            this.AttributeRemoveButton.Location = new Point(17, 10);
            this.AttributeRemoveButton.Size = new Size(37, 37);
            this.AttributeRemoveButton.Name = "AttributeRemove";
            this.AttributeRemoveButton.Text = "-";
            //this.AttributeRemove.Click += new EventHandler(AttributeRemove_Click);

            this.AttributeNameTextBox.Location = new Point(151, 13);
            this.AttributeNameTextBox.Size = new Size(321, 30);
            this.AttributeNameTextBox.Name = "AttributeName";

            this.AttributeTypeListBox.Location = new Point(495, 13);
            this.AttributeTypeListBox.Size = new Size(132, 29);
            this.AttributeTypeListBox.Name = "AttributeType";

            this.AttributeTypeListBox.BeginUpdate();
            foreach (string name in Converter.GetTypeNames)
            {
                this.AttributeTypeListBox.Items.Add(name);
            }
            this.AttributeTypeListBox.EndUpdate();

            this.Controls.Add(this.AttributeRemoveButton);
            this.Controls.Add(this.AttributeNameTextBox);
            this.Controls.Add(this.AttributeTypeListBox);

        }

        public string AttributeName
        {
            get
            {
                return AttributeNameTextBox.Text;
            }
        }

        public string AttributeType
        {
            get
            {
                return AttributeTypeListBox.Text;
            }
        }

        public Button AttributeRemove
        {
            get
            {
                return AttributeRemoveButton;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    public partial class NewTable : Form
    {
        private DataManager dataManager = DataManager.Instance;

        private int initAttrAmount = 3;
        private int currentAttrAmount;
        private List<AttributeGroup> attributes = new List<AttributeGroup>();
        private Point attributeRenderCurrent;
        private Point attributeRenderStart = new Point(70, 306);
        private Point attributeRenderOffset = new Point(0, 50);
        private Point attributeRenderAntiOffset = new Point(0, -50);

        private AttributeGroup renderGroupBox(Point point, AttributeGroup attributeGroup = null)
        {
            if (attributeGroup == null)
            {
                attributeGroup = new AttributeGroup(point);
            }

            attributeGroup.AttributeRemove.Click += new EventHandler(this.AttributeRemove_Click);
            return attributeGroup;
        }
        public NewTable()
        {
            InitializeComponent();
            currentAttrAmount = initAttrAmount;
            attributeRenderCurrent = attributeRenderStart;

            for (int i = 0; i < currentAttrAmount; i++)
            {
                AttributeGroup attr = renderGroupBox(attributeRenderCurrent);
                //attributes.Add(attr);
                //attr.AttributeRemove += new EventHandler(AttributeRemove_Click);
                Controls.Add(attr);
                attributeRenderCurrent.Offset(attributeRenderOffset);
            }
            
        }

        private void ControlRemoved(object sender, EventArgs e)
        {
            //currentAttrAmount++;
            //attributes.Add(renderGroupBox(attributeRenderCurrent));
            AttributeGroup attr = renderGroupBox(attributeRenderCurrent);
            Controls.Add(attr);
            attributeRenderCurrent.Offset(attributeRenderOffset);
        }

        private void AttributeAdd_Click(object sender, EventArgs e)
        {
            //currentAttrAmount++;
            //attributes.Add(renderGroupBox(attributeRenderCurrent));
            AttributeGroup attr = renderGroupBox(attributeRenderCurrent);
            Controls.Add(attr);
            attributeRenderCurrent.Offset(attributeRenderOffset);
        }

        private void AttributeRemove_Click(object sender, EventArgs e)
        {
            //currentAttrAmount--;

            Button btn = (Button)sender;
            AttributeGroup grp = (AttributeGroup)btn.Parent;
            Point removedPoint = grp.Location;

            //attributes.Remove(grp);
            Controls.Remove(btn);
            

            
            foreach (AttributeGroup attribute in this.Controls.OfType<AttributeGroup>())
            {
                if (attribute.Location.Y > grp.Location.Y)
                {

                    attribute.Location.Offset(attributeRenderAntiOffset);
                }
            }
            
        }

        private void NewTableConfirm_Click(object sender, EventArgs e)
        {
            string tableName = NewTableNameTextBox.Text;
            string attributeName;
            
            foreach (GroupBox attributeGroup in attributes)
            {
                //attributeName = attributeGroup.
                //Attribute attribute = new Attribute(attributeName, )
                //attributeName = attribute.Controls.Find(t => t.Name == "AttributeName");
                if (true)
                {
                //    attribute.Location.Offset(attributeRenderAntiOffset);
                }
            }
        }
    }
}