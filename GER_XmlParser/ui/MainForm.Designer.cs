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
            buttonModelUpload = new Button();
            buttonModelBrowser = new Button();
            textBoxModelFile = new TextBox();
            labelModelFile = new Label();
            groupBoxModel = new GroupBox();
            groupBoxModelInfo = new GroupBox();
            textBoxModelPublicVersNum = new TextBox();
            labelModelPublicVersNum = new Label();
            labelModelProvider = new Label();
            textBoxModelVendor = new TextBox();
            textBoxModelDescr = new TextBox();
            labelModelDescr = new Label();
            textBoxModelName = new TextBox();
            labelModelName = new Label();
            tabControlModel = new TabControl();
            tabPageModelFindRef = new TabPage();
            treeViewModelFindRef = new TreeView();
            buttonModelFindRef = new Button();
            textBoxModelFindRef = new TextBox();
            labelModelOpFindRef = new Label();
            tabPageMapping = new TabPage();
            tabPageFormat = new TabPage();
            tabControlMain.SuspendLayout();
            tabPageModel.SuspendLayout();
            groupBoxModel.SuspendLayout();
            groupBoxModelInfo.SuspendLayout();
            tabControlModel.SuspendLayout();
            tabPageModelFindRef.SuspendLayout();
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
            tabPageModel.Controls.Add(groupBoxModel);
            tabPageModel.Location = new Point(4, 29);
            tabPageModel.Name = "tabPageModel";
            tabPageModel.Padding = new Padding(3);
            tabPageModel.Size = new Size(749, 651);
            tabPageModel.TabIndex = 0;
            tabPageModel.Text = "Model";
            tabPageModel.UseVisualStyleBackColor = true;
            // 
            // buttonModelUpload
            // 
            buttonModelUpload.Location = new Point(649, 26);
            buttonModelUpload.Name = "buttonModelUpload";
            buttonModelUpload.Size = new Size(94, 29);
            buttonModelUpload.TabIndex = 3;
            buttonModelUpload.Text = "Importa";
            buttonModelUpload.UseVisualStyleBackColor = true;
            buttonModelUpload.Click += buttonModelUpload_Click;
            // 
            // buttonModelBrowser
            // 
            buttonModelBrowser.Location = new Point(6, 25);
            buttonModelBrowser.Name = "buttonModelBrowser";
            buttonModelBrowser.Size = new Size(94, 29);
            buttonModelBrowser.TabIndex = 2;
            buttonModelBrowser.Text = "Cerca";
            buttonModelBrowser.UseVisualStyleBackColor = true;
            buttonModelBrowser.Click += buttonModelBrowser_Click;
            // 
            // textBoxModelFile
            // 
            textBoxModelFile.Location = new Point(106, 26);
            textBoxModelFile.Name = "textBoxModelFile";
            textBoxModelFile.Size = new Size(537, 27);
            textBoxModelFile.TabIndex = 1;
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
            // groupBoxModel
            // 
            groupBoxModel.Controls.Add(groupBoxModelInfo);
            groupBoxModel.Controls.Add(tabControlModel);
            groupBoxModel.Location = new Point(6, 59);
            groupBoxModel.Name = "groupBoxModel";
            groupBoxModel.Size = new Size(737, 586);
            groupBoxModel.TabIndex = 5;
            groupBoxModel.TabStop = false;
            groupBoxModel.Text = "Model";
            // 
            // groupBoxModelInfo
            // 
            groupBoxModelInfo.Controls.Add(textBoxModelPublicVersNum);
            groupBoxModelInfo.Controls.Add(labelModelPublicVersNum);
            groupBoxModelInfo.Controls.Add(labelModelProvider);
            groupBoxModelInfo.Controls.Add(textBoxModelVendor);
            groupBoxModelInfo.Controls.Add(textBoxModelDescr);
            groupBoxModelInfo.Controls.Add(labelModelDescr);
            groupBoxModelInfo.Controls.Add(textBoxModelName);
            groupBoxModelInfo.Controls.Add(labelModelName);
            groupBoxModelInfo.Location = new Point(10, 26);
            groupBoxModelInfo.Name = "groupBoxModelInfo";
            groupBoxModelInfo.Size = new Size(717, 172);
            groupBoxModelInfo.TabIndex = 5;
            groupBoxModelInfo.TabStop = false;
            groupBoxModelInfo.Text = "Info";
            // 
            // textBoxModelPublicVersNum
            // 
            textBoxModelPublicVersNum.Enabled = false;
            textBoxModelPublicVersNum.Location = new Point(6, 118);
            textBoxModelPublicVersNum.Name = "textBoxModelPublicVersNum";
            textBoxModelPublicVersNum.Size = new Size(199, 27);
            textBoxModelPublicVersNum.TabIndex = 7;
            // 
            // labelModelPublicVersNum
            // 
            labelModelPublicVersNum.AutoSize = true;
            labelModelPublicVersNum.Location = new Point(6, 95);
            labelModelPublicVersNum.Name = "labelModelPublicVersNum";
            labelModelPublicVersNum.Size = new Size(65, 20);
            labelModelPublicVersNum.TabIndex = 6;
            labelModelPublicVersNum.Text = "Versione";
            // 
            // labelModelProvider
            // 
            labelModelProvider.AutoSize = true;
            labelModelProvider.Location = new Point(489, 23);
            labelModelProvider.Name = "labelModelProvider";
            labelModelProvider.Size = new Size(64, 20);
            labelModelProvider.TabIndex = 5;
            labelModelProvider.Text = "Provider";
            // 
            // textBoxModelVendor
            // 
            textBoxModelVendor.Enabled = false;
            textBoxModelVendor.Location = new Point(489, 46);
            textBoxModelVendor.Name = "textBoxModelVendor";
            textBoxModelVendor.Size = new Size(222, 27);
            textBoxModelVendor.TabIndex = 4;
            // 
            // textBoxModelDescr
            // 
            textBoxModelDescr.Enabled = false;
            textBoxModelDescr.Location = new Point(211, 46);
            textBoxModelDescr.Name = "textBoxModelDescr";
            textBoxModelDescr.Size = new Size(272, 27);
            textBoxModelDescr.TabIndex = 3;
            // 
            // labelModelDescr
            // 
            labelModelDescr.AutoSize = true;
            labelModelDescr.Location = new Point(211, 23);
            labelModelDescr.Name = "labelModelDescr";
            labelModelDescr.Size = new Size(86, 20);
            labelModelDescr.TabIndex = 2;
            labelModelDescr.Text = "Descrizione";
            // 
            // textBoxModelName
            // 
            textBoxModelName.Enabled = false;
            textBoxModelName.Location = new Point(6, 46);
            textBoxModelName.Name = "textBoxModelName";
            textBoxModelName.Size = new Size(199, 27);
            textBoxModelName.TabIndex = 1;
            // 
            // labelModelName
            // 
            labelModelName.AutoSize = true;
            labelModelName.Location = new Point(6, 23);
            labelModelName.Name = "labelModelName";
            labelModelName.Size = new Size(50, 20);
            labelModelName.TabIndex = 0;
            labelModelName.Text = "Nome";
            // 
            // tabControlModel
            // 
            tabControlModel.Controls.Add(tabPageModelFindRef);
            tabControlModel.Location = new Point(6, 204);
            tabControlModel.Name = "tabControlModel";
            tabControlModel.SelectedIndex = 0;
            tabControlModel.Size = new Size(725, 376);
            tabControlModel.TabIndex = 4;
            // 
            // tabPageModelFindRef
            // 
            tabPageModelFindRef.Controls.Add(treeViewModelFindRef);
            tabPageModelFindRef.Controls.Add(buttonModelFindRef);
            tabPageModelFindRef.Controls.Add(textBoxModelFindRef);
            tabPageModelFindRef.Controls.Add(labelModelOpFindRef);
            tabPageModelFindRef.Location = new Point(4, 29);
            tabPageModelFindRef.Name = "tabPageModelFindRef";
            tabPageModelFindRef.Padding = new Padding(3);
            tabPageModelFindRef.Size = new Size(717, 343);
            tabPageModelFindRef.TabIndex = 0;
            tabPageModelFindRef.Text = "Trova riferimenti";
            tabPageModelFindRef.UseVisualStyleBackColor = true;
            // 
            // treeViewModelFindRef
            // 
            treeViewModelFindRef.Location = new Point(6, 59);
            treeViewModelFindRef.Name = "treeViewModelFindRef";
            treeViewModelFindRef.Size = new Size(705, 278);
            treeViewModelFindRef.TabIndex = 4;
            // 
            // buttonModelFindRef
            // 
            buttonModelFindRef.Location = new Point(617, 25);
            buttonModelFindRef.Name = "buttonModelFindRef";
            buttonModelFindRef.Size = new Size(94, 29);
            buttonModelFindRef.TabIndex = 3;
            buttonModelFindRef.Text = "Ricerca";
            buttonModelFindRef.UseVisualStyleBackColor = true;
            buttonModelFindRef.Click += buttonModelFindRef_Click;
            // 
            // textBoxModelFindRef
            // 
            textBoxModelFindRef.Location = new Point(6, 26);
            textBoxModelFindRef.Name = "textBoxModelFindRef";
            textBoxModelFindRef.Size = new Size(605, 27);
            textBoxModelFindRef.TabIndex = 2;
            // 
            // labelModelOpFindRef
            // 
            labelModelOpFindRef.AutoSize = true;
            labelModelOpFindRef.Location = new Point(6, 3);
            labelModelOpFindRef.Name = "labelModelOpFindRef";
            labelModelOpFindRef.Size = new Size(310, 20);
            labelModelOpFindRef.TabIndex = 1;
            labelModelOpFindRef.Text = "Inserire una stringa per ricercarne i riferimenti";
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 708);
            Controls.Add(tabControlMain);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GER Xml Parser";
            Load += MainForm_Load;
            tabControlMain.ResumeLayout(false);
            tabPageModel.ResumeLayout(false);
            tabPageModel.PerformLayout();
            groupBoxModel.ResumeLayout(false);
            groupBoxModelInfo.ResumeLayout(false);
            groupBoxModelInfo.PerformLayout();
            tabControlModel.ResumeLayout(false);
            tabPageModelFindRef.ResumeLayout(false);
            tabPageModelFindRef.PerformLayout();
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
        private TabControl tabControlModel;
        private TabPage tabPageModelFindRef;
        private GroupBox groupBoxModel;
        private GroupBox groupBoxModelInfo;
        private TextBox textBoxModelName;
        private Label labelModelName;
        private TextBox textBoxModelVendor;
        private TextBox textBoxModelDescr;
        private Label labelModelDescr;
        private Button buttonModelFindRef;
        private TextBox textBoxModelFindRef;
        private Label labelModelOpFindRef;
        private Label labelModelProvider;
        private TextBox textBoxModelPublicVersNum;
        private Label labelModelPublicVersNum;
        private TreeView treeViewModelFindRef;
    }
}