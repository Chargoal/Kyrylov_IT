using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DBMS
{
    public partial class mainForm : Form
    {
        private static HttpClient Client = new HttpClient();
        private DataManager dataManager = DataManager.Instance;
        private TypeToNameConverter Converter = TypeToNameConverter.Instance;
        public mainForm()
        {
            InitializeComponent();
            tabControl.TabPages.Clear();
        }

        private void defaultForm()
        {
            searchCheckBox.Checked = false;
        }

        private void stripMenuItem_NewDatabase_Click(object sender, EventArgs e)
        {            
            dataManager.CreateDatabase("newDB");
            defaultForm();
            renderDatabase(dataManager.CurrentDatabase);
        }

        private void stripMenuItem_NewTable_Click(object sender, EventArgs e)
        {
            int n = dataManager.CurrentDatabase.Tables.Count;
            CreateTableForm newTableForm = new CreateTableForm();
            newTableForm.ShowDialog();

            defaultForm();

            try
            {
                renderTable(dataManager.LastCreatedTable);
            }
            catch (Exception) { }
        }

        private void stripMenuItem_OpenDatabase_Click(object sender, EventArgs e)
        {
            dataManager.OpenDatabase();

            defaultForm();

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

        private TabPage currentTab()
        {
            try
            {
                return tabControl.TabPages[tabControl.SelectedIndex];
            }
            catch (Exception)
            {
                //tabControl.TabPages.Add(new TabPage());
                return null;
            }
        }

        private DataGridView currentTabDGV()
        {

            return (DataGridView)currentTab().Controls.Find("Grid", true)[0];
        }

        private bool isRowEmpty(DataGridViewRow row)
        {
            bool emptyRow = true;
            foreach (DataGridViewCell cell in row.Cells)
            {
                bool emptyCell = cell.Value == null || (cell.Value != null && cell.Value.ToString().Trim() == "");
                emptyRow = emptyRow && emptyCell;
                if (!emptyRow) return emptyRow;
            }
            return emptyRow;
        }

        private void CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //SaveToDB();
            //DataGridViewCell cell = (DataGridViewCell)sender;
            DataGridView dgv = currentTabDGV();
            string tableName = currentTab().Text;
            Table table = dataManager.CurrentDatabase.GetTable(tableName);
            string attrName = dgv.Columns[e.ColumnIndex].Name;
            Attribute attr = table.GetAttribute(attrName);
            //DataGridViewCell cell = dgv.CurrentCell;

            bool emptyCell = e.FormattedValue == null || (e.FormattedValue != null && e.FormattedValue.ToString().Trim() == "");
            try
            {
                if (emptyCell || attr.Validate(e.FormattedValue))
                {
                    dgv.Rows[e.RowIndex].ErrorText = "";
                    DataGridViewDataErrorContexts er = new DataGridViewDataErrorContexts();
                    currentTabDGV().CommitEdit(er);
                    e.Cancel = false;
                }
                else
                {
                    dgv.Rows[e.RowIndex].ErrorText = "Помилка значення";
                    e.Cancel = true;
                }
            }
            catch (Exception) { }
        }

        private void renderTable(Table table)
        {
            tabControl.TabPages.Add(table.Name);
            TabPage page = tabControl.TabPages[tabControl.Controls.Count - 1];
            tabControl.SelectedIndex = tabControl.Controls.Count - 1;
            page.Name = table.Name;
            DataGridView dgv = new DataGridView();
            page.Controls.Add(dgv);
            dgv.Name = "Grid";
            dgv.Dock = DockStyle.Fill;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.CellValidating += new DataGridViewCellValidatingEventHandler(CellValidating);


            // Create columns for each attribute in the table.
            foreach (Attribute attribute in table.Attributes)
            {
                dgv.Columns.Add(attribute.Name, attribute.Name);
            }

            // Create rows for each entry in the table.
            foreach (Entry entry in table.Entries)
            {
                DataGridViewRow row = new DataGridViewRow();

                // Add a cell to the row for each attribute in the table.
                foreach (Attribute attribute in table.Attributes)
                {
                    object value = entry.GetValue(attribute.Name);
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = value });
                }

                // Add the row to the DataGridView object.
                dgv.Rows.Add(row);
            }

            currentTab().Controls.Add(dgv);
            //tabControl.TabPages[tabControl.TabPages.Count - 1].Controls.Add(dgv);
        }

        private void clearForm()
        {
            tabControl.Visible = false;
            tabControl.TabPages.Clear();
        }

        private void stripMenuItem_Save_Click(object sender, EventArgs e)
        {
            SaveProjection();
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

        private void delTableToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ((ToolStripMenuItem)sender).Enabled = dataManager.CurrentDatabase != null && 
                dataManager.CurrentDatabase.Tables.Count > 0;
        }

        private void delTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToDB();
            
            var tab = currentTab();
            string name = tab.Text;
            tabControl.Controls.Remove(tab);
            clearForm();

            //tabControl.Update();
            
            dataManager.DeleteTable(name);
            renderDatabase(dataManager.CurrentDatabase);
        }

        private bool ValidateRows()
        {
            bool DBValid = true;

            try
            {
                foreach (TabPage page in tabControl.TabPages)
                {
                    bool pageValid = true;
                    string tableName = page.Text;
                    Table table = dataManager.CurrentDatabase.GetTable(tableName);
                    DataGridView dgv = (DataGridView)page.Controls.Find("Grid", true)[0];
                    dgv.CurrentCell = dgv.Rows[0].Cells[0];
                    dgv.BeginEdit(false);
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        row.ReadOnly = true;
                        bool rowValid = true;
                        bool rowEmpty = true;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            //cell.ReadOnly = true;   
                            string attrName = dgv.Columns[cell.ColumnIndex].Name;
                            Attribute attr = table.GetAttribute(attrName);
                            bool emptyCell = cell.Value == null || (cell.Value != null && cell.Value.ToString().Trim() == "");
                            if (!emptyCell)
                            {
                                rowEmpty = false;
                                if (!attr.Validate(cell.Value))
                                {
                                    rowValid = false;
                                }
                            }
                            else
                            {
                                rowValid = false;
                            }
                        }
                        row.ReadOnly = true;
                        if (rowEmpty)
                        {
                            if (!row.IsNewRow)
                            {
                                row.Visible = false;
                                dgv.Rows.RemoveAt(row.Index);
                            }
                            row.ReadOnly = false;
                        }
                        else if (!rowValid)
                        {
                            row.ErrorText = "Не усі значення комірок відповідають типам атрибутів";
                            pageValid = false;
                        }
                        row.ReadOnly = false;
                    }
                    dgv.ReadOnly = false;
                    DBValid = DBValid && pageValid;
                }
            }
            catch (Exception) { }

            return DBValid;
        }
        /*
        private List<Attribute> ColumnsToAttributes(DataGridViewColumn)
        {
            Attribute attr = new Attribute();


        } 
        */
        private Entry RowToEntry(DataGridView dgv, Table table, DataGridViewRow row)
        {
            Entry entry = new Entry();
            foreach (DataGridViewCell cell in row.Cells)
            {
                string attrName = cell.OwningColumn.Name;
                Attribute attr = table.GetAttribute(attrName);
                EntryValue ev = new EntryValue(cell.Value, attr);
                entry.AddValue(ev);
            }
            return entry;
        }
        
        private void SaveToDB()
        {
            foreach (TabPage page in tabControl.TabPages)
            {
                string tableName = page.Text;
                Table table = dataManager.CurrentDatabase.GetTable(tableName);
                table.Entries.Clear();
                DataGridView dgv = (DataGridView)page.Controls.Find("Grid", true)[0];
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible && !row.IsNewRow)
                    {
                        table.AddEntry(RowToEntry(dgv, table, row));
                    }
                }
                dataManager.CurrentDatabase.UpdateTable(table);
            }
        }

        private void SaveProjection()
        {
            //if (ValidateRows())
            //{
                //Gets here even with not full entries
                SaveToDB();
            //}
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if ((dataManager.CurrentDatabase != null) && dataManager.CurrentDatabase.Tables.Count > 0)
            {
                //string tableName = currentTab().Text;
                //Table table = dataManager.CurrentDatabase.GetTable(tableName);
                SearchTableWrapper(currentTabDGV());
            }
        }

        private void SearchTableWrapper(DataGridView dgv)
        {
            Table table = dataManager.CurrentDatabase.GetTable(currentTab().Name);
            Entry searchEntry = RowToEntry(dgv, table, dgv.Rows[0]);
            DataGridViewRow searchRow = CloneRowWithValues(dgv, dgv.Rows[0]);

            tabControl.TabPages.Remove(currentTab());
            Table foundTable = dataManager.SearchTable(table, searchEntry);

            renderTable(foundTable);
            DataGridView newdgv = currentTabDGV();
            foreach (DataGridViewRow row in newdgv.Rows)
                row.ReadOnly = true;
            searchButton.Enabled = false;
        }
        /*
        private void SearchTable(DataGridView table)
        {
            // Get the DataGridView inside of the TabPage.
            DataGridViewRow searchRow = CloneRowWithValues(table, table.Rows[0]);
            table.Rows.RemoveAt(0);
            DataGridView tempDGV = new DataGridView();
            List<DataGridViewRow> foundRows = new List<DataGridViewRow>();

            foreach (DataGridViewColumn col in table.Columns)
            {
                DataGridViewColumn newCol = (DataGridViewColumn)col.Clone();
                newCol.Name = col.Name;
                newCol.HeaderText = col.HeaderText;
                tempDGV.Columns.Add(newCol);
            }

            foreach (DataGridViewRow row in table.Rows)
            {
                foundRows.Insert(row.Index, row);
                row.Visible = true;
            }

            foreach (DataGridViewRow row in table.Rows)
            {
                int rowIndex = row.Index;
                foreach (DataGridViewColumn col in table.Columns)
                {
                    int colIndex = col.Index;
                    if (foundRows.Contains(row) && table.Rows[rowIndex].IsNewRow == false)
                    {
                        var cellValue = table.Rows[rowIndex].Cells[colIndex].Value;
                        var patternCellValue = searchRow.Cells[colIndex].Value;
                        string cellStrValue;
                        string patternCellStrValue;
                        if (cellValue == null) cellStrValue = "";
                        else cellStrValue = cellValue.ToString();
                        if (patternCellValue == null) patternCellStrValue = "";
                        else patternCellStrValue = patternCellValue.ToString();
                        if (!cellStrValue.Contains(patternCellStrValue))
                        {
                            foundRows.Remove(row);
                            row.Visible = false;
                        }
                    }
                }
            }

            table.Rows.Insert(0, searchRow);
        }
        */
        
        private DataGridViewRow CloneRowWithValues(DataGridView table, DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            //table.Rows.Add(clonedRow);
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            //table.Rows.Remove(clonedRow);
            return clonedRow;
        }
        
        private void SearchSetup()
        {
            foreach (TabPage page in tabControl.TabPages)
            {
                DataGridView dgv = (DataGridView)page.Controls.Find("Grid", true)[0];
                DataGridViewRow searchRow = new DataGridViewRow();

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    searchRow.Cells.Add(new DataGridViewTextBoxCell { Value = "Enter search pattern..." });
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.ReadOnly = true;
                    if (isRowEmpty(row)) row.Visible = true;
                }

                searchRow.HeaderCell = new DataGridViewRowHeaderCell { Value = "Search Pattern" };
                searchRow.ReadOnly = false;
                dgv.Rows.Insert(0, searchRow);
            }
        }

        private void SearchStop()
        {
            renderDatabase(dataManager.CurrentDatabase);
            /*
            foreach (TabPage page in tabControl.TabPages)
            {
                DataGridView dgv = (DataGridView)page.Controls.Find("Grid", true)[0];
                dgv.Rows.RemoveAt(0);

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.ReadOnly = false;
                    row.Visible = true;
                }
            }
            */
        }

        private void stripMenuItem_Help_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void searchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (searchCheckBox.CheckState == CheckState.Checked)
            {
                SaveProjection();
                SearchSetup();
                searchButton.Enabled = true;
            }
            else
            {
                SearchStop();
                searchButton.Enabled = false;
            }
        }

        private void tabControl_ControlAddedRemoved(object sender, ControlEventArgs e)
        {
            if (tabControl.TabPages.Count == 0 || tabControl.Visible == false)
            {
                searchButton.Visible = false;
                searchCheckBox.Visible = false;
            }
            else
            {
                searchButton.Visible = true;
                searchCheckBox.Visible = true;
            }
        }
    }
}