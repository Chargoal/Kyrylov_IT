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
            this.stripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchCheckBox = new System.Windows.Forms.CheckBox();
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
            this.stripMenuItem_Save});
            this.stripMenuItem_File.Name = "stripMenuItem_File";
            this.stripMenuItem_File.Size = new System.Drawing.Size(59, 24);
            this.stripMenuItem_File.Text = "Файл";
            // 
            // stripMenuItem_New
            // 
            this.stripMenuItem_New.Name = "stripMenuItem_New";
            this.stripMenuItem_New.Size = new System.Drawing.Size(155, 26);
            this.stripMenuItem_New.Text = "Нова";
            this.stripMenuItem_New.Click += new System.EventHandler(this.stripMenuItem_NewDatabase_Click);
            // 
            // stripMenuItem_Open
            // 
            this.stripMenuItem_Open.Name = "stripMenuItem_Open";
            this.stripMenuItem_Open.Size = new System.Drawing.Size(155, 26);
            this.stripMenuItem_Open.Text = "Відкрити";
            this.stripMenuItem_Open.Click += new System.EventHandler(this.stripMenuItem_OpenDatabase_Click);
            // 
            // stripMenuItem_Save
            // 
            this.stripMenuItem_Save.Name = "stripMenuItem_Save";
            this.stripMenuItem_Save.Size = new System.Drawing.Size(155, 26);
            this.stripMenuItem_Save.Text = "Зберегти";
            this.stripMenuItem_Save.Click += new System.EventHandler(this.stripMenuItem_Save_Click);
            this.stripMenuItem_Save.Paint += new System.Windows.Forms.PaintEventHandler(this.stripMenuItem_Save_Paint);
            // 
            // stripMenuItem_Edit
            // 
            this.stripMenuItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.stripMenuItem_Edit.Name = "stripMenuItem_Edit";
            this.stripMenuItem_Edit.Size = new System.Drawing.Size(110, 24);
            this.stripMenuItem_Edit.Text = "Редагування";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.addToolStripMenuItem.Text = "Додати таблицю";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.stripMenuItem_NewTable_Click);
            this.addToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.stripMenuItem_NewTable_Paint);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.deleteToolStripMenuItem.Text = "Видалити таблицю";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.delTableToolStripMenuItem_Click);
            this.deleteToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.delTableToolStripMenuItem_Paint);
            // 
            // stripMenuItem_Help
            // 
            this.stripMenuItem_Help.Name = "stripMenuItem_Help";
            this.stripMenuItem_Help.Size = new System.Drawing.Size(94, 24);
            this.stripMenuItem_Help.Text = "Допомога";
            this.stripMenuItem_Help.Click += new System.EventHandler(this.stripMenuItem_Help_Click);
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
            this.tabControl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControl_ControlAddedRemoved);
            this.tabControl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabControl_ControlAddedRemoved);
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.Location = new System.Drawing.Point(701, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(92, 28);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Пошук";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Visible = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchCheckBox
            // 
            this.searchCheckBox.AutoSize = true;
            this.searchCheckBox.Location = new System.Drawing.Point(572, 6);
            this.searchCheckBox.Name = "searchCheckBox";
            this.searchCheckBox.Size = new System.Drawing.Size(123, 20);
            this.searchCheckBox.TabIndex = 4;
            this.searchCheckBox.Text = "Режим пошуку";
            this.searchCheckBox.UseVisualStyleBackColor = true;
            this.searchCheckBox.Visible = false;
            this.searchCheckBox.CheckedChanged += new System.EventHandler(this.searchCheckBox_CheckedChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchCheckBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "mainForm";
            this.Text = "СКБД";
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
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem stripMenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.CheckBox searchCheckBox;
    }
}

