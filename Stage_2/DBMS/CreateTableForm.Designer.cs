namespace DBMS
{
    partial class CreateTableForm
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
            this.PrettifyerBox = new System.Windows.Forms.GroupBox();
            this.AttributesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.AttributeTypeLabel = new System.Windows.Forms.Label();
            this.AttributeNameLabel = new System.Windows.Forms.Label();
            this.CreateAttributeButton = new System.Windows.Forms.Button();
            this.CreateAttributesTitle = new System.Windows.Forms.Label();
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CreateTableButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.PrettifyerBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrettifyerBox
            // 
            this.PrettifyerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrettifyerBox.Controls.Add(this.AttributesFlowLayoutPanel);
            this.PrettifyerBox.Controls.Add(this.label1);
            this.PrettifyerBox.Controls.Add(this.AttributeTypeLabel);
            this.PrettifyerBox.Controls.Add(this.AttributeNameLabel);
            this.PrettifyerBox.Controls.Add(this.CreateAttributeButton);
            this.PrettifyerBox.Controls.Add(this.CreateAttributesTitle);
            this.PrettifyerBox.Controls.Add(this.TableNameTextBox);
            this.PrettifyerBox.Controls.Add(this.NameLabel);
            this.PrettifyerBox.Controls.Add(this.CreateTableButton);
            this.PrettifyerBox.Controls.Add(this.TitleLabel);
            this.PrettifyerBox.Location = new System.Drawing.Point(12, 12);
            this.PrettifyerBox.Name = "PrettifyerBox";
            this.PrettifyerBox.Size = new System.Drawing.Size(642, 505);
            this.PrettifyerBox.TabIndex = 0;
            this.PrettifyerBox.TabStop = false;
            // 
            // AttributesFlowLayoutPanel
            // 
            this.AttributesFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttributesFlowLayoutPanel.AutoScroll = true;
            this.AttributesFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.AttributesFlowLayoutPanel.Location = new System.Drawing.Point(7, 184);
            this.AttributesFlowLayoutPanel.Name = "AttributesFlowLayoutPanel";
            this.AttributesFlowLayoutPanel.Size = new System.Drawing.Size(629, 272);
            this.AttributesFlowLayoutPanel.TabIndex = 10;
            this.AttributesFlowLayoutPanel.WrapContents = false;
            this.AttributesFlowLayoutPanel.Resize += new System.EventHandler(this.AttributesFlowLayoutPanel_Resize);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(439, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Видалити атрибут";
            // 
            // AttributeTypeLabel
            // 
            this.AttributeTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AttributeTypeLabel.AutoSize = true;
            this.AttributeTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttributeTypeLabel.Location = new System.Drawing.Point(244, 160);
            this.AttributeTypeLabel.Name = "AttributeTypeLabel";
            this.AttributeTypeLabel.Size = new System.Drawing.Size(122, 20);
            this.AttributeTypeLabel.TabIndex = 8;
            this.AttributeTypeLabel.Text = "Тип атрибута";
            // 
            // AttributeNameLabel
            // 
            this.AttributeNameLabel.AutoSize = true;
            this.AttributeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttributeNameLabel.Location = new System.Drawing.Point(24, 160);
            this.AttributeNameLabel.Name = "AttributeNameLabel";
            this.AttributeNameLabel.Size = new System.Drawing.Size(144, 20);
            this.AttributeNameLabel.TabIndex = 7;
            this.AttributeNameLabel.Text = "Назва атрибута";
            // 
            // CreateAttributeButton
            // 
            this.CreateAttributeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateAttributeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateAttributeButton.Location = new System.Drawing.Point(445, 111);
            this.CreateAttributeButton.Name = "CreateAttributeButton";
            this.CreateAttributeButton.Size = new System.Drawing.Size(162, 34);
            this.CreateAttributeButton.TabIndex = 6;
            this.CreateAttributeButton.Text = "Додати новий";
            this.CreateAttributeButton.UseVisualStyleBackColor = true;
            this.CreateAttributeButton.Click += new System.EventHandler(this.CreateAttributeButton_Click);
            // 
            // CreateAttributesTitle
            // 
            this.CreateAttributesTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CreateAttributesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateAttributesTitle.Location = new System.Drawing.Point(252, 114);
            this.CreateAttributesTitle.Name = "CreateAttributesTitle";
            this.CreateAttributesTitle.Size = new System.Drawing.Size(111, 27);
            this.CreateAttributesTitle.TabIndex = 4;
            this.CreateAttributesTitle.Text = "Атрибути";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TableNameTextBox.Location = new System.Drawing.Point(208, 71);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(399, 22);
            this.TableNameTextBox.TabIndex = 3;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(24, 71);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(135, 20);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Назва таблиці:";
            // 
            // CreateTableButton
            // 
            this.CreateTableButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CreateTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateTableButton.Location = new System.Drawing.Point(221, 462);
            this.CreateTableButton.Name = "CreateTableButton";
            this.CreateTableButton.Size = new System.Drawing.Size(189, 37);
            this.CreateTableButton.TabIndex = 1;
            this.CreateTableButton.Text = "Створити";
            this.CreateTableButton.UseVisualStyleBackColor = true;
            this.CreateTableButton.Click += new System.EventHandler(this.CreateTableButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.Location = new System.Drawing.Point(234, 18);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(176, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Нова таблиця";
            // 
            // CreateTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 529);
            this.Controls.Add(this.PrettifyerBox);
            this.MinimumSize = new System.Drawing.Size(674, 576);
            this.Name = "CreateTableForm";
            this.Text = "CreateTableForm";
            this.PrettifyerBox.ResumeLayout(false);
            this.PrettifyerBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PrettifyerBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.FlowLayoutPanel AttributesFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AttributeTypeLabel;
        private System.Windows.Forms.Label AttributeNameLabel;
        private System.Windows.Forms.Button CreateAttributeButton;
        private System.Windows.Forms.Label CreateAttributesTitle;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button CreateTableButton;
    }
}