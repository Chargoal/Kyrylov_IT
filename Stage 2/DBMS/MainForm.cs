using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public partial class mainForm : Form
    {
        private DataManager dataManager = DataManager.Instance;
        public mainForm()
        {
            InitializeComponent();
            tabControl.TabPages.Clear();
        }

        private void stripMenuItem_NewDatabase_Click(object sender, EventArgs e)
        {            
            dataManager.CreateDatabase("newDB");

            renderDatabase(dataManager.CurrentDatabase);
        }

        private void stripMenuItem_NewTable_Click(object sender, EventArgs e)
        {
            int n = dataManager.CurrentDatabase.Tables.Count;
            CreateTableForm newTableForm = new CreateTableForm();
            newTableForm.ShowDialog();
            
            renderDatabase(dataManager.CurrentDatabase);
        }

        private void stripMenuItem_OpenDatabase_Click(object sender, EventArgs e)
        {
            dataManager.OpenDatabase();

            renderDatabase(dataManager.CurrentDatabase);
        }

        private void renderDatabase(Database db)
        {
            clearForm();
            tabControl.Visible = true;

            //prepareRender();
            if (db != null && db.Tables.Count > 0)
            {
                foreach (Table table in db.Tables)
                {
                    renderTable(table);
                }
            }
        }

        private void renderTable(Table table)
        {
            tabControl.TabPages.Add(table.Name);
            DataGridView dgv = new DataGridView();
            dgv.Name = "Grid";
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = table;

            // Add a column for each attribute in the table.
            foreach (Attribute attribute in table.Attributes)
            {
                dgv.Columns.Add(attribute.Name, attribute.Name);
            }

            // Add a row for each entry in the table.
            foreach (Entry entry in table.Entries)
            {
                DataGridViewRow row = new DataGridViewRow();

                // Add a cell for each attribute in the entry.
                foreach (Attribute attribute in table.Attributes)
                {
                    object value = entry.GetValue(attribute.Name);
                    DataGridCell cell = new DataGridCell();
                    row.Cells.Add(new DataGridViewTextBoxCell());
                }

                // Add the row to the DataGridView.
                dgv.Rows.Add(row);
            }


            tabControl.TabPages[tabControl.TabPages.Count - 1].Controls.Add(dgv);
        }

        private void createTab(string name)
        {

        }

        private void renderDataGrid(Table table)
        {

        }

        private void clearForm()
        {
            tabControl.Visible = false;
            tabControl.TabPages.Clear();
        }

        private void stripMenuItem_Save_Click(object sender, EventArgs e)
        {
            dataManager.SaveDatabase();
        }

        private void stripMenuItem_NewTable_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null;
        }

        private void stripMenuItem_Save_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null;
        }

        private void stripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null;
        }

        private void deleteToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null && dataManager.CurrentDatabase.Tables.Count > 0;
        }

        private void searchToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null && dataManager.CurrentDatabase.Tables.Count > 0;
        }

        private void newEntryToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null && dataManager.CurrentDatabase.Tables.Count > 0;
        }

        private void newAttributeToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null && dataManager.CurrentDatabase.Tables.Count > 0;
        }

        private void delTableToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null && dataManager.CurrentDatabase.Tables.Count > 0;
        }

        private void delEntryToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null && dataManager.CurrentDatabase.Tables.Count > 0;
        }

        private void delAttributeToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null && dataManager.CurrentDatabase.Tables.Count > 0;
        }

        private void delTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = tabControl.TabPages[tabControl.SelectedIndex].Text;
            dataManager.DeleteTable(name);

            renderDatabase(dataManager.CurrentDatabase);
        }

        private void newEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)tabControl.TabPages[tabControl.SelectedIndex].Controls.Find("Grid", true)[0];
            int i = dgv.Rows.Add();
            /*
            foreach (DataGridViewCell c in DataGridView.Rows[i].Cells)
            {

            }
            */
            //dataManager.CreateEntry()
        }
    }
}