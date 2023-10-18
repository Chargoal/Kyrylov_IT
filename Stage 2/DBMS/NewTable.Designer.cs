namespace DBMS
{
    partial class NewTable
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
            this.AttributeAdd = new System.Windows.Forms.Button();
            this.NewTableWindowTitle = new System.Windows.Forms.Label();
            this.NewTableAttributesTitle = new System.Windows.Forms.Label();
            this.NewTableNameTextBox = new System.Windows.Forms.TextBox();
            this.TableNameLabel = new System.Windows.Forms.Label();
            this.RemoveLabel = new System.Windows.Forms.Label();
            this.AttributeNameLabel = new System.Windows.Forms.Label();
            this.AttributeTypeLabel = new System.Windows.Forms.Label();
            this.AddLabel = new System.Windows.Forms.Label();
            this.NewTableConfirm = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // AttributeAdd
            // 
            this.AttributeAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttributeAdd.Location = new System.Drawing.Point(87, 194);
            this.AttributeAdd.Name = "AttributeAdd";
            this.AttributeAdd.Size = new System.Drawing.Size(37, 37);
            this.AttributeAdd.TabIndex = 0;
            this.AttributeAdd.Text = "+";
            this.AttributeAdd.UseVisualStyleBackColor = true;
            this.AttributeAdd.Click += new System.EventHandler(this.AttributeAdd_Click);
            // 
            // NewTableWindowTitle
            // 
            this.NewTableWindowTitle.AutoSize = true;
            this.NewTableWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewTableWindowTitle.Location = new System.Drawing.Point(307, 30);
            this.NewTableWindowTitle.Name = "NewTableWindowTitle";
            this.NewTableWindowTitle.Size = new System.Drawing.Size(158, 32);
            this.NewTableWindowTitle.TabIndex = 4;
            this.NewTableWindowTitle.Text = "New Table";
            // 
            // NewTableAttributesTitle
            // 
            this.NewTableAttributesTitle.AutoSize = true;
            this.NewTableAttributesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewTableAttributesTitle.Location = new System.Drawing.Point(307, 134);
            this.NewTableAttributesTitle.Name = "NewTableAttributesTitle";
            this.NewTableAttributesTitle.Size = new System.Drawing.Size(145, 32);
            this.NewTableAttributesTitle.TabIndex = 5;
            this.NewTableAttributesTitle.Text = "Attributes";
            // 
            // NewTableNameTextBox
            // 
            this.NewTableNameTextBox.Location = new System.Drawing.Point(313, 84);
            this.NewTableNameTextBox.Name = "NewTableNameTextBox";
            this.NewTableNameTextBox.Size = new System.Drawing.Size(418, 22);
            this.NewTableNameTextBox.TabIndex = 6;
            // 
            // TableNameLabel
            // 
            this.TableNameLabel.AutoSize = true;
            this.TableNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TableNameLabel.Location = new System.Drawing.Point(65, 84);
            this.TableNameLabel.Name = "TableNameLabel";
            this.TableNameLabel.Size = new System.Drawing.Size(64, 25);
            this.TableNameLabel.TabIndex = 7;
            this.TableNameLabel.Text = "Name";
            // 
            // RemoveLabel
            // 
            this.RemoveLabel.AutoSize = true;
            this.RemoveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveLabel.Location = new System.Drawing.Point(65, 264);
            this.RemoveLabel.Name = "RemoveLabel";
            this.RemoveLabel.Size = new System.Drawing.Size(84, 25);
            this.RemoveLabel.TabIndex = 8;
            this.RemoveLabel.Text = "Remove";
            // 
            // AttributeNameLabel
            // 
            this.AttributeNameLabel.AutoSize = true;
            this.AttributeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttributeNameLabel.Location = new System.Drawing.Point(344, 264);
            this.AttributeNameLabel.Name = "AttributeNameLabel";
            this.AttributeNameLabel.Size = new System.Drawing.Size(64, 25);
            this.AttributeNameLabel.TabIndex = 9;
            this.AttributeNameLabel.Text = "Name";
            // 
            // AttributeTypeLabel
            // 
            this.AttributeTypeLabel.AutoSize = true;
            this.AttributeTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttributeTypeLabel.Location = new System.Drawing.Point(619, 264);
            this.AttributeTypeLabel.Name = "AttributeTypeLabel";
            this.AttributeTypeLabel.Size = new System.Drawing.Size(57, 25);
            this.AttributeTypeLabel.TabIndex = 10;
            this.AttributeTypeLabel.Text = "Type";
            // 
            // AddLabel
            // 
            this.AddLabel.AutoSize = true;
            this.AddLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddLabel.Location = new System.Drawing.Point(262, 200);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(234, 25);
            this.AddLabel.TabIndex = 18;
            this.AddLabel.Text = "Add (to the end of the list)";
            // 
            // NewTableConfirm
            // 
            this.NewTableConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewTableConfirm.Location = new System.Drawing.Point(70, 22);
            this.NewTableConfirm.Name = "NewTableConfirm";
            this.NewTableConfirm.Size = new System.Drawing.Size(134, 53);
            this.NewTableConfirm.TabIndex = 19;
            this.NewTableConfirm.Text = "Create Table";
            this.NewTableConfirm.UseVisualStyleBackColor = true;
            this.NewTableConfirm.Click += new System.EventHandler(this.NewTableConfirm_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // NewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
            this.Controls.Add(this.NewTableConfirm);
            this.Controls.Add(this.AddLabel);
            this.Controls.Add(this.AttributeTypeLabel);
            this.Controls.Add(this.AttributeNameLabel);
            this.Controls.Add(this.RemoveLabel);
            this.Controls.Add(this.TableNameLabel);
            this.Controls.Add(this.NewTableNameTextBox);
            this.Controls.Add(this.NewTableAttributesTitle);
            this.Controls.Add(this.NewTableWindowTitle);
            this.Controls.Add(this.AttributeAdd);
            this.Name = "NewTable";
            this.Text = "NewTable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AttributeAdd;
        private System.Windows.Forms.Label NewTableWindowTitle;
        private System.Windows.Forms.Label NewTableAttributesTitle;
        private System.Windows.Forms.TextBox NewTableNameTextBox;
        private System.Windows.Forms.Label TableNameLabel;
        private System.Windows.Forms.Label RemoveLabel;
        private System.Windows.Forms.Label AttributeNameLabel;
        private System.Windows.Forms.Label AttributeTypeLabel;
        private System.Windows.Forms.Label AddLabel;
        private System.Windows.Forms.Button NewTableConfirm;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}