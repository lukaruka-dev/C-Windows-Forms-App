namespace WindowsFormsApp2
{
    partial class EditForm
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
            this.TableSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InputsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.InsertButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ItemCountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableSelect
            // 
            this.TableSelect.FormattingEnabled = true;
            this.TableSelect.Location = new System.Drawing.Point(65, 12);
            this.TableSelect.Name = "TableSelect";
            this.TableSelect.Size = new System.Drawing.Size(121, 21);
            this.TableSelect.TabIndex = 0;
            this.TableSelect.SelectedIndexChanged += new System.EventHandler(this.TableSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tabela";
            // 
            // InputsTableLayout
            // 
            this.InputsTableLayout.ColumnCount = 2;
            this.InputsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.InputsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InputsTableLayout.Location = new System.Drawing.Point(6, 19);
            this.InputsTableLayout.Name = "InputsTableLayout";
            this.InputsTableLayout.RowCount = 3;
            this.InputsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.InputsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.InputsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.InputsTableLayout.Size = new System.Drawing.Size(293, 341);
            this.InputsTableLayout.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InputsTableLayout);
            this.groupBox1.Location = new System.Drawing.Point(16, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 366);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inputs";
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(16, 411);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(28, 23);
            this.PreviousButton.TabIndex = 5;
            this.PreviousButton.Text = "<";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(293, 411);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(28, 23);
            this.NextButton.TabIndex = 6;
            this.NextButton.Text = ">";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(50, 411);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 7;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(131, 411);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 8;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(212, 411);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ItemCountLabel
            // 
            this.ItemCountLabel.AutoSize = true;
            this.ItemCountLabel.Location = new System.Drawing.Point(192, 15);
            this.ItemCountLabel.Name = "ItemCountLabel";
            this.ItemCountLabel.Size = new System.Drawing.Size(30, 13);
            this.ItemCountLabel.TabIndex = 10;
            this.ItemCountLabel.Text = "0 / 0";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 450);
            this.Controls.Add(this.ItemCountLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TableSelect);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TableSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel InputsTableLayout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label ItemCountLabel;
    }
}