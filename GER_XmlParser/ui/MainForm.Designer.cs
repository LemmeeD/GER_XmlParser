namespace GER_XmlParser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlMain = new TabControl();
            tabPageModel = new TabPage();
            tabPageMapping = new TabPage();
            tabPageFormat = new TabPage();
            labelModelFile = new Label();
            textBoxModelFile = new TextBox();
            buttonModelBrowser = new Button();
            buttonModelUpload = new Button();
            tabControlMain.SuspendLayout();
            tabPageModel.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageModel);
            tabControlMain.Controls.Add(tabPageMapping);
            tabControlMain.Controls.Add(tabPageFormat);
            tabControlMain.Location = new Point(12, 12);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(757, 684);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageModel
            // 
            tabPageModel.Controls.Add(buttonModelUpload);
            tabPageModel.Controls.Add(buttonModelBrowser);
            tabPageModel.Controls.Add(textBoxModelFile);
            tabPageModel.Controls.Add(labelModelFile);
            tabPageModel.Location = new Point(4, 29);
            tabPageModel.Name = "tabPageModel";
            tabPageModel.Padding = new Padding(3);
            tabPageModel.Size = new Size(749, 651);
            tabPageModel.TabIndex = 0;
            tabPageModel.Text = "Model";
            tabPageModel.UseVisualStyleBackColor = true;
            // 
            // tabPageMapping
            // 
            tabPageMapping.Location = new Point(4, 29);
            tabPageMapping.Name = "tabPageMapping";
            tabPageMapping.Padding = new Padding(3);
            tabPageMapping.Size = new Size(749, 651);
            tabPageMapping.TabIndex = 1;
            tabPageMapping.Text = "Mapping";
            tabPageMapping.UseVisualStyleBackColor = true;
            // 
            // tabPageFormat
            // 
            tabPageFormat.Location = new Point(4, 29);
            tabPageFormat.Name = "tabPageFormat";
            tabPageFormat.Padding = new Padding(3);
            tabPageFormat.Size = new Size(749, 651);
            tabPageFormat.TabIndex = 2;
            tabPageFormat.Text = "Format";
            tabPageFormat.UseVisualStyleBackColor = true;
            // 
            // labelModelFile
            // 
            labelModelFile.AutoSize = true;
            labelModelFile.Location = new Point(6, 3);
            labelModelFile.Name = "labelModelFile";
            labelModelFile.Size = new Size(426, 20);
            labelModelFile.TabIndex = 0;
            labelModelFile.Text = "Selezionare il file .xml di un file relativo ad un Model di un GER";
            // 
            // textBoxModelFile
            // 
            textBoxModelFile.Location = new Point(6, 26);
            textBoxModelFile.Name = "textBoxModelFile";
            textBoxModelFile.Size = new Size(537, 27);
            textBoxModelFile.TabIndex = 1;
            // 
            // buttonModelBrowser
            // 
            buttonModelBrowser.Location = new Point(549, 25);
            buttonModelBrowser.Name = "buttonModelBrowser";
            buttonModelBrowser.Size = new Size(94, 29);
            buttonModelBrowser.TabIndex = 2;
            buttonModelBrowser.Text = "Cerca";
            buttonModelBrowser.UseVisualStyleBackColor = true;
            // 
            // buttonModelUpload
            // 
            buttonModelUpload.Location = new Point(649, 26);
            buttonModelUpload.Name = "buttonModelUpload";
            buttonModelUpload.Size = new Size(94, 29);
            buttonModelUpload.TabIndex = 3;
            buttonModelUpload.Text = "Importa";
            buttonModelUpload.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 708);
            Controls.Add(tabControlMain);
            Name = "MainForm";
            Text = "Form1";
            tabControlMain.ResumeLayout(false);
            tabPageModel.ResumeLayout(false);
            tabPageModel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabPageModel;
        private TabPage tabPageMapping;
        private TabPage tabPageFormat;
        private Label labelModelFile;
        private Button buttonModelUpload;
        private Button buttonModelBrowser;
        private TextBox textBoxModelFile;
    }
}