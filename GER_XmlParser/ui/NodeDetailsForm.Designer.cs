namespace GER_XmlParser.ui
{
    partial class NodeDetailsForm
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
            labelTitle = new Label();
            labelNodePath = new Label();
            dataGridView1 = new DataGridView();
            Key = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.Location = new Point(12, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(142, 25);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Dettagli nodo:";
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelNodePath
            // 
            labelNodePath.Location = new Point(160, 9);
            labelNodePath.Name = "labelNodePath";
            labelNodePath.Size = new Size(628, 25);
            labelNodePath.TabIndex = 1;
            labelNodePath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Key, Value });
            dataGridView1.Location = new Point(12, 50);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(776, 388);
            dataGridView1.TabIndex = 2;
            // 
            // Key
            // 
            Key.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Key.HeaderText = "Nome attributo";
            Key.MinimumWidth = 6;
            Key.Name = "Key";
            Key.ReadOnly = true;
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Value.HeaderText = "Valore Attributo";
            Value.MinimumWidth = 6;
            Value.Name = "Value";
            Value.ReadOnly = true;
            // 
            // NodeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(labelNodePath);
            Controls.Add(labelTitle);
            Name = "NodeDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NodeDetailsForm";
            Load += NodeDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelTitle;
        private Label labelNodePath;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn Value;
    }
}