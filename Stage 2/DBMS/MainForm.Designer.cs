namespace DBMS
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.stripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_View = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.MenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenuItem_File,
            this.stripMenuItem_Edit,
            this.stripMenuItem_View,
            this.stripMenuItem_Help});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 28);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // stripMenuItem_File
            // 
            this.stripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenuItem_New,
            this.stripMenuItem_Open,
            this.stripMenuItem_Save,
            this.stripMenuItem_Exit});
            this.stripMenuItem_File.Name = "stripMenuItem_File";
            this.stripMenuItem_File.Size = new System.Drawing.Size(46, 24);
            this.stripMenuItem_File.Text = "File";
            // 
            // stripMenuItem_New
            // 
            this.stripMenuItem_New.Name = "stripMenuItem_New";
            this.stripMenuItem_New.Size = new System.Drawing.Size(152, 26);
            this.stripMenuItem_New.Text = "New DB";
            this.stripMenuItem_New.Click += new System.EventHandler(this.stripMenuItem_NewDatabase_Click);
            // 
            // stripMenuItem_Open
            // 
            this.stripMenuItem_Open.Name = "stripMenuItem_Open";
            this.stripMenuItem_Open.Size = new System.Drawing.Size(152, 26);
            this.stripMenuItem_Open.Text = "Open DB";
            this.stripMenuItem_Open.Click += new System.EventHandler(this.stripMenuItem_OpenDatabase_Click);
            // 
            // stripMenuItem_Save
            // 
            this.stripMenuItem_Save.Name = "stripMenuItem_Save";
            this.stripMenuItem_Save.Size = new System.Drawing.Size(152, 26);
            this.stripMenuItem_Save.Text = "Save DB";
            this.stripMenuItem_Save.Click += new System.EventHandler(this.stripMenuItem_Save_Click);
            this.stripMenuItem_Save.Paint += new System.Windows.Forms.PaintEventHandler(this.stripMenuItem_Save_Paint);
            // 
            // stripMenuItem_Exit
            // 
            this.stripMenuItem_Exit.Name = "stripMenuItem_Exit";
            this.stripMenuItem_Exit.Size = new System.Drawing.Size(152, 26);
            this.stripMenuItem_Exit.Text = "Exit";
            this.stripMenuItem_Exit.Click += new System.EventHandler(this.stripMenuItem_Exit_Click);
            // 
            // stripMenuItem_Edit
            // 
            this.stripMenuItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.stripMenuItem_Edit.Name = "stripMenuItem_Edit";
            this.stripMenuItem_Edit.Size = new System.Drawing.Size(49, 24);
            this.stripMenuItem_Edit.Text = "Edit";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTableToolStripMenuItem,
            this.newEntryToolStripMenuItem,
            this.newAttributeToolStripMenuItem});
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.addToolStripMenuItem_Paint);
            // 
            // newTableToolStripMenuItem
            // 
            this.newTableToolStripMenuItem.Name = "newTableToolStripMenuItem";
            this.newTableToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.newTableToolStripMenuItem.Text = "Table";
            this.newTableToolStripMenuItem.Click += new System.EventHandler(this.stripMenuItem_NewTable_Click);
            this.newTableToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.stripMenuItem_NewTable_Paint);
            // 
            // newEntryToolStripMenuItem
            // 
            this.newEntryToolStripMenuItem.Name = "newEntryToolStripMenuItem";
            this.newEntryToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.newEntryToolStripMenuItem.Text = "Entry";
            this.newEntryToolStripMenuItem.Click += new System.EventHandler(this.newEntryToolStripMenuItem_Click);
            this.newEntryToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.newEntryToolStripMenuItem_Paint);
            // 
            // newAttributeToolStripMenuItem
            // 
            this.newAttributeToolStripMenuItem.Name = "newAttributeToolStripMenuItem";
            this.newAttributeToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.newAttributeToolStripMenuItem.Text = "Attribute";
            this.newAttributeToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.newAttributeToolStripMenuItem_Paint);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delTableToolStripMenuItem,
            this.delEntryToolStripMenuItem,
            this.delAttributeToolStripMenuItem});
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.deleteToolStripMenuItem_Paint);
            // 
            // delTableToolStripMenuItem
            // 
            this.delTableToolStripMenuItem.Name = "delTableToolStripMenuItem";
            this.delTableToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.delTableToolStripMenuItem.Text = "Table";
            this.delTableToolStripMenuItem.Click += new System.EventHandler(this.delTableToolStripMenuItem_Click);
            this.delTableToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.delTableToolStripMenuItem_Paint);
            // 
            // delEntryToolStripMenuItem
            // 
            this.delEntryToolStripMenuItem.Name = "delEntryToolStripMenuItem";
            this.delEntryToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.delEntryToolStripMenuItem.Text = "Entry";
            this.delEntryToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.delEntryToolStripMenuItem_Paint);
            // 
            // delAttributeToolStripMenuItem
            // 
            this.delAttributeToolStripMenuItem.Name = "delAttributeToolStripMenuItem";
            this.delAttributeToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.delAttributeToolStripMenuItem.Text = "Attribute";
            this.delAttributeToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.delAttributeToolStripMenuItem_Paint);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Enabled = false;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.searchToolStripMenuItem_Paint);
            // 
            // stripMenuItem_View
            // 
            this.stripMenuItem_View.Name = "stripMenuItem_View";
            this.stripMenuItem_View.Size = new System.Drawing.Size(55, 24);
            this.stripMenuItem_View.Text = "View";
            // 
            // stripMenuItem_Help
            // 
            this.stripMenuItem_Help.Name = "stripMenuItem_Help";
            this.stripMenuItem_Help.Size = new System.Drawing.Size(55, 24);
            this.stripMenuItem_Help.Text = "Help";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 422);
            this.tabControl.TabIndex = 1;
            this.tabControl.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "mainForm";
            this.Text = "mainForm";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_New;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_Open;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_View;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAttributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delAttributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem newTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delTableToolStripMenuItem;
    }
}

