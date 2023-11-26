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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            buttonModelFindRefCollapse = new Button();
            buttonModelFindRefExpand = new Button();
            buttonModelFindRefReset = new Button();
            treeViewModelFindRef = new TreeView();
            buttonModelFindRef = new Button();
            textBoxModelFindRef = new TextBox();
            labelModelOpFindRef = new Label();
            tabPageMapping = new TabPage();
            comboBoxMapVers = new ComboBox();
            labelMapVersion = new Label();
            groupBoxMap = new GroupBox();
            groupBoxMapInfo = new GroupBox();
            textBoxMapModelMapping = new TextBox();
            labelMapModelMapping = new Label();
            textBoxMapVers = new TextBox();
            labelMapPublicVers = new Label();
            labelMapProvider = new Label();
            textBoxMapProvider = new TextBox();
            textBoxMapDescr = new TextBox();
            labelMapDescr = new Label();
            textBoxMapName = new TextBox();
            labelMapName = new Label();
            tabControlMap = new TabControl();
            tabPage1 = new TabPage();
            treeViewMapFindRefBinding = new TreeView();
            treeViewMapFindRefDatasource = new TreeView();
            buttonMapFinndRef = new Button();
            textBoxMapFindRef = new TextBox();
            labelMapFindRef = new Label();
            buttonMapUpload = new Button();
            textBoxMapFile = new TextBox();
            buttonMapBrowse = new Button();
            labelMap = new Label();
            tabPageFormat = new TabPage();
            groupBoxFormat = new GroupBox();
            groupBoxFormatInfo = new GroupBox();
            textBoxFormatVers = new TextBox();
            labelFormatVers = new Label();
            labelFormatProvider = new Label();
            textBoxFormatProvider = new TextBox();
            textBoxFormatDescr = new TextBox();
            labelFormatDescr = new Label();
            textBoxFormatName = new TextBox();
            labelFormatName = new Label();
            tabControlFormat = new TabControl();
            tabPageFormatFindRef = new TabPage();
            treeViewFormatFindRefMap = new TreeView();
            treeViewFormatFindRef = new TreeView();
            buttonFormatFindRef = new Button();
            textBoxFormatFindRef = new TextBox();
            labelFormatFindRef = new Label();
            tabPageFormatRebase = new TabPage();
            buttonFormatRebase = new Button();
            labelFormatRebase = new Label();
            buttonFormatUpload = new Button();
            textBoxFormat = new TextBox();
            buttonFormatBrowse = new Button();
            labelFormat = new Label();
            tabControlMain.SuspendLayout();
            tabPageModel.SuspendLayout();
            groupBoxModel.SuspendLayout();
            groupBoxModelInfo.SuspendLayout();
            tabControlModel.SuspendLayout();
            tabPageModelFindRef.SuspendLayout();
            tabPageMapping.SuspendLayout();
            groupBoxMap.SuspendLayout();
            groupBoxMapInfo.SuspendLayout();
            tabControlMap.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPageFormat.SuspendLayout();
            groupBoxFormat.SuspendLayout();
            groupBoxFormatInfo.SuspendLayout();
            tabControlFormat.SuspendLayout();
            tabPageFormatFindRef.SuspendLayout();
            tabPageFormatRebase.SuspendLayout();
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
            tabControlMain.Size = new Size(757, 772);
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
            tabPageModel.Size = new Size(749, 739);
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
            groupBoxModel.Size = new Size(737, 674);
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
            tabControlModel.Size = new Size(725, 464);
            tabControlModel.TabIndex = 4;
            // 
            // tabPageModelFindRef
            // 
            tabPageModelFindRef.Controls.Add(buttonModelFindRefCollapse);
            tabPageModelFindRef.Controls.Add(buttonModelFindRefExpand);
            tabPageModelFindRef.Controls.Add(buttonModelFindRefReset);
            tabPageModelFindRef.Controls.Add(treeViewModelFindRef);
            tabPageModelFindRef.Controls.Add(buttonModelFindRef);
            tabPageModelFindRef.Controls.Add(textBoxModelFindRef);
            tabPageModelFindRef.Controls.Add(labelModelOpFindRef);
            tabPageModelFindRef.Location = new Point(4, 29);
            tabPageModelFindRef.Name = "tabPageModelFindRef";
            tabPageModelFindRef.Padding = new Padding(3);
            tabPageModelFindRef.Size = new Size(717, 431);
            tabPageModelFindRef.TabIndex = 0;
            tabPageModelFindRef.Text = "Trova riferimenti";
            tabPageModelFindRef.UseVisualStyleBackColor = true;
            // 
            // buttonModelFindRefCollapse
            // 
            buttonModelFindRefCollapse.Location = new Point(617, 259);
            buttonModelFindRefCollapse.Name = "buttonModelFindRefCollapse";
            buttonModelFindRefCollapse.Size = new Size(94, 29);
            buttonModelFindRefCollapse.TabIndex = 7;
            buttonModelFindRefCollapse.Text = "Collassa";
            buttonModelFindRefCollapse.UseVisualStyleBackColor = true;
            buttonModelFindRefCollapse.Click += buttonModelFindRefCollapse_Click;
            // 
            // buttonModelFindRefExpand
            // 
            buttonModelFindRefExpand.Location = new Point(617, 224);
            buttonModelFindRefExpand.Name = "buttonModelFindRefExpand";
            buttonModelFindRefExpand.Size = new Size(94, 29);
            buttonModelFindRefExpand.TabIndex = 6;
            buttonModelFindRefExpand.Text = "Espandi";
            buttonModelFindRefExpand.UseVisualStyleBackColor = true;
            buttonModelFindRefExpand.Click += buttonModelFindRefExpand_Click;
            // 
            // buttonModelFindRefReset
            // 
            buttonModelFindRefReset.Location = new Point(617, 189);
            buttonModelFindRefReset.Name = "buttonModelFindRefReset";
            buttonModelFindRefReset.Size = new Size(94, 29);
            buttonModelFindRefReset.TabIndex = 5;
            buttonModelFindRefReset.Text = "Reset";
            buttonModelFindRefReset.UseVisualStyleBackColor = true;
            buttonModelFindRefReset.Click += buttonModelFindRefReset_Click;
            // 
            // treeViewModelFindRef
            // 
            treeViewModelFindRef.Location = new Point(6, 59);
            treeViewModelFindRef.Name = "treeViewModelFindRef";
            treeViewModelFindRef.Size = new Size(605, 366);
            treeViewModelFindRef.TabIndex = 4;
            treeViewModelFindRef.NodeMouseDoubleClick += treeViewModelFindRef_NodeMouseDoubleClick;
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
            tabPageMapping.Controls.Add(comboBoxMapVers);
            tabPageMapping.Controls.Add(labelMapVersion);
            tabPageMapping.Controls.Add(groupBoxMap);
            tabPageMapping.Controls.Add(buttonMapUpload);
            tabPageMapping.Controls.Add(textBoxMapFile);
            tabPageMapping.Controls.Add(buttonMapBrowse);
            tabPageMapping.Controls.Add(labelMap);
            tabPageMapping.Location = new Point(4, 29);
            tabPageMapping.Name = "tabPageMapping";
            tabPageMapping.Padding = new Padding(3);
            tabPageMapping.Size = new Size(749, 739);
            tabPageMapping.TabIndex = 1;
            tabPageMapping.Text = "Mapping";
            tabPageMapping.UseVisualStyleBackColor = true;
            // 
            // comboBoxMapVers
            // 
            comboBoxMapVers.FormattingEnabled = true;
            comboBoxMapVers.Location = new Point(158, 64);
            comboBoxMapVers.Name = "comboBoxMapVers";
            comboBoxMapVers.Size = new Size(585, 28);
            comboBoxMapVers.TabIndex = 8;
            comboBoxMapVers.SelectedIndexChanged += comboBoxMapVers_SelectedIndexChanged;
            // 
            // labelMapVersion
            // 
            labelMapVersion.AutoSize = true;
            labelMapVersion.Location = new Point(3, 67);
            labelMapVersion.Name = "labelMapVersion";
            labelMapVersion.Size = new Size(120, 20);
            labelMapVersion.TabIndex = 7;
            labelMapVersion.Text = "Mapping version";
            // 
            // groupBoxMap
            // 
            groupBoxMap.Controls.Add(groupBoxMapInfo);
            groupBoxMap.Controls.Add(tabControlMap);
            groupBoxMap.Location = new Point(6, 98);
            groupBoxMap.Name = "groupBoxMap";
            groupBoxMap.Size = new Size(737, 635);
            groupBoxMap.TabIndex = 6;
            groupBoxMap.TabStop = false;
            groupBoxMap.Text = "Mapping";
            // 
            // groupBoxMapInfo
            // 
            groupBoxMapInfo.Controls.Add(textBoxMapModelMapping);
            groupBoxMapInfo.Controls.Add(labelMapModelMapping);
            groupBoxMapInfo.Controls.Add(textBoxMapVers);
            groupBoxMapInfo.Controls.Add(labelMapPublicVers);
            groupBoxMapInfo.Controls.Add(labelMapProvider);
            groupBoxMapInfo.Controls.Add(textBoxMapProvider);
            groupBoxMapInfo.Controls.Add(textBoxMapDescr);
            groupBoxMapInfo.Controls.Add(labelMapDescr);
            groupBoxMapInfo.Controls.Add(textBoxMapName);
            groupBoxMapInfo.Controls.Add(labelMapName);
            groupBoxMapInfo.Location = new Point(6, 26);
            groupBoxMapInfo.Name = "groupBoxMapInfo";
            groupBoxMapInfo.Size = new Size(717, 172);
            groupBoxMapInfo.TabIndex = 5;
            groupBoxMapInfo.TabStop = false;
            groupBoxMapInfo.Text = "Info";
            // 
            // textBoxMapModelMapping
            // 
            textBoxMapModelMapping.Enabled = false;
            textBoxMapModelMapping.Location = new Point(211, 118);
            textBoxMapModelMapping.Name = "textBoxMapModelMapping";
            textBoxMapModelMapping.Size = new Size(272, 27);
            textBoxMapModelMapping.TabIndex = 9;
            // 
            // labelMapModelMapping
            // 
            labelMapModelMapping.AutoSize = true;
            labelMapModelMapping.Location = new Point(211, 95);
            labelMapModelMapping.Name = "labelMapModelMapping";
            labelMapModelMapping.Size = new Size(161, 20);
            labelMapModelMapping.TabIndex = 8;
            labelMapModelMapping.Text = "Nome mapping model";
            // 
            // textBoxMapVers
            // 
            textBoxMapVers.Enabled = false;
            textBoxMapVers.Location = new Point(6, 118);
            textBoxMapVers.Name = "textBoxMapVers";
            textBoxMapVers.Size = new Size(199, 27);
            textBoxMapVers.TabIndex = 7;
            // 
            // labelMapPublicVers
            // 
            labelMapPublicVers.AutoSize = true;
            labelMapPublicVers.Location = new Point(6, 95);
            labelMapPublicVers.Name = "labelMapPublicVers";
            labelMapPublicVers.Size = new Size(65, 20);
            labelMapPublicVers.TabIndex = 6;
            labelMapPublicVers.Text = "Versione";
            // 
            // labelMapProvider
            // 
            labelMapProvider.AutoSize = true;
            labelMapProvider.Location = new Point(489, 23);
            labelMapProvider.Name = "labelMapProvider";
            labelMapProvider.Size = new Size(64, 20);
            labelMapProvider.TabIndex = 5;
            labelMapProvider.Text = "Provider";
            // 
            // textBoxMapProvider
            // 
            textBoxMapProvider.Enabled = false;
            textBoxMapProvider.Location = new Point(489, 46);
            textBoxMapProvider.Name = "textBoxMapProvider";
            textBoxMapProvider.Size = new Size(222, 27);
            textBoxMapProvider.TabIndex = 4;
            // 
            // textBoxMapDescr
            // 
            textBoxMapDescr.Enabled = false;
            textBoxMapDescr.Location = new Point(211, 46);
            textBoxMapDescr.Name = "textBoxMapDescr";
            textBoxMapDescr.Size = new Size(272, 27);
            textBoxMapDescr.TabIndex = 3;
            // 
            // labelMapDescr
            // 
            labelMapDescr.AutoSize = true;
            labelMapDescr.Location = new Point(211, 23);
            labelMapDescr.Name = "labelMapDescr";
            labelMapDescr.Size = new Size(86, 20);
            labelMapDescr.TabIndex = 2;
            labelMapDescr.Text = "Descrizione";
            // 
            // textBoxMapName
            // 
            textBoxMapName.Enabled = false;
            textBoxMapName.Location = new Point(6, 46);
            textBoxMapName.Name = "textBoxMapName";
            textBoxMapName.Size = new Size(199, 27);
            textBoxMapName.TabIndex = 1;
            // 
            // labelMapName
            // 
            labelMapName.AutoSize = true;
            labelMapName.Location = new Point(6, 23);
            labelMapName.Name = "labelMapName";
            labelMapName.Size = new Size(50, 20);
            labelMapName.TabIndex = 0;
            labelMapName.Text = "Nome";
            // 
            // tabControlMap
            // 
            tabControlMap.Controls.Add(tabPage1);
            tabControlMap.Location = new Point(6, 204);
            tabControlMap.Name = "tabControlMap";
            tabControlMap.SelectedIndex = 0;
            tabControlMap.Size = new Size(725, 425);
            tabControlMap.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(treeViewMapFindRefBinding);
            tabPage1.Controls.Add(treeViewMapFindRefDatasource);
            tabPage1.Controls.Add(buttonMapFinndRef);
            tabPage1.Controls.Add(textBoxMapFindRef);
            tabPage1.Controls.Add(labelMapFindRef);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(717, 392);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Trova riferimenti";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeViewMapFindRefBinding
            // 
            treeViewMapFindRefBinding.Location = new Point(361, 59);
            treeViewMapFindRefBinding.Name = "treeViewMapFindRefBinding";
            treeViewMapFindRefBinding.Size = new Size(346, 327);
            treeViewMapFindRefBinding.TabIndex = 5;
            // 
            // treeViewMapFindRefDatasource
            // 
            treeViewMapFindRefDatasource.Location = new Point(6, 59);
            treeViewMapFindRefDatasource.Name = "treeViewMapFindRefDatasource";
            treeViewMapFindRefDatasource.Size = new Size(349, 327);
            treeViewMapFindRefDatasource.TabIndex = 4;
            // 
            // buttonMapFinndRef
            // 
            buttonMapFinndRef.Location = new Point(617, 25);
            buttonMapFinndRef.Name = "buttonMapFinndRef";
            buttonMapFinndRef.Size = new Size(94, 29);
            buttonMapFinndRef.TabIndex = 3;
            buttonMapFinndRef.Text = "Ricerca";
            buttonMapFinndRef.UseVisualStyleBackColor = true;
            // 
            // textBoxMapFindRef
            // 
            textBoxMapFindRef.Location = new Point(6, 26);
            textBoxMapFindRef.Name = "textBoxMapFindRef";
            textBoxMapFindRef.Size = new Size(605, 27);
            textBoxMapFindRef.TabIndex = 2;
            // 
            // labelMapFindRef
            // 
            labelMapFindRef.AutoSize = true;
            labelMapFindRef.Location = new Point(9, 6);
            labelMapFindRef.Name = "labelMapFindRef";
            labelMapFindRef.Size = new Size(310, 20);
            labelMapFindRef.TabIndex = 1;
            labelMapFindRef.Text = "Inserire una stringa per ricercarne i riferimenti";
            // 
            // buttonMapUpload
            // 
            buttonMapUpload.Location = new Point(649, 28);
            buttonMapUpload.Name = "buttonMapUpload";
            buttonMapUpload.Size = new Size(94, 27);
            buttonMapUpload.TabIndex = 5;
            buttonMapUpload.Text = "Importa";
            buttonMapUpload.UseVisualStyleBackColor = true;
            buttonMapUpload.Click += buttonMapUpload_Click;
            // 
            // textBoxMapFile
            // 
            textBoxMapFile.Location = new Point(106, 28);
            textBoxMapFile.Name = "textBoxMapFile";
            textBoxMapFile.Size = new Size(537, 27);
            textBoxMapFile.TabIndex = 4;
            // 
            // buttonMapBrowse
            // 
            buttonMapBrowse.Location = new Point(6, 26);
            buttonMapBrowse.Name = "buttonMapBrowse";
            buttonMapBrowse.Size = new Size(94, 29);
            buttonMapBrowse.TabIndex = 3;
            buttonMapBrowse.Text = "Cerca";
            buttonMapBrowse.UseVisualStyleBackColor = true;
            buttonMapBrowse.Click += buttonMapBrowse_Click;
            // 
            // labelMap
            // 
            labelMap.AutoSize = true;
            labelMap.Location = new Point(6, 3);
            labelMap.Name = "labelMap";
            labelMap.Size = new Size(443, 20);
            labelMap.TabIndex = 1;
            labelMap.Text = "Selezionare il file .xml di un file relativo ad un Mapping di un GER";
            // 
            // tabPageFormat
            // 
            tabPageFormat.Controls.Add(groupBoxFormat);
            tabPageFormat.Controls.Add(buttonFormatUpload);
            tabPageFormat.Controls.Add(textBoxFormat);
            tabPageFormat.Controls.Add(buttonFormatBrowse);
            tabPageFormat.Controls.Add(labelFormat);
            tabPageFormat.Location = new Point(4, 29);
            tabPageFormat.Name = "tabPageFormat";
            tabPageFormat.Padding = new Padding(3);
            tabPageFormat.Size = new Size(749, 739);
            tabPageFormat.TabIndex = 2;
            tabPageFormat.Text = "Format";
            tabPageFormat.UseVisualStyleBackColor = true;
            // 
            // groupBoxFormat
            // 
            groupBoxFormat.Controls.Add(groupBoxFormatInfo);
            groupBoxFormat.Controls.Add(tabControlFormat);
            groupBoxFormat.Location = new Point(6, 59);
            groupBoxFormat.Name = "groupBoxFormat";
            groupBoxFormat.Size = new Size(737, 586);
            groupBoxFormat.TabIndex = 7;
            groupBoxFormat.TabStop = false;
            groupBoxFormat.Text = "Format";
            // 
            // groupBoxFormatInfo
            // 
            groupBoxFormatInfo.Controls.Add(textBoxFormatVers);
            groupBoxFormatInfo.Controls.Add(labelFormatVers);
            groupBoxFormatInfo.Controls.Add(labelFormatProvider);
            groupBoxFormatInfo.Controls.Add(textBoxFormatProvider);
            groupBoxFormatInfo.Controls.Add(textBoxFormatDescr);
            groupBoxFormatInfo.Controls.Add(labelFormatDescr);
            groupBoxFormatInfo.Controls.Add(textBoxFormatName);
            groupBoxFormatInfo.Controls.Add(labelFormatName);
            groupBoxFormatInfo.Location = new Point(10, 26);
            groupBoxFormatInfo.Name = "groupBoxFormatInfo";
            groupBoxFormatInfo.Size = new Size(717, 172);
            groupBoxFormatInfo.TabIndex = 5;
            groupBoxFormatInfo.TabStop = false;
            groupBoxFormatInfo.Text = "Info";
            // 
            // textBoxFormatVers
            // 
            textBoxFormatVers.Enabled = false;
            textBoxFormatVers.Location = new Point(6, 118);
            textBoxFormatVers.Name = "textBoxFormatVers";
            textBoxFormatVers.Size = new Size(199, 27);
            textBoxFormatVers.TabIndex = 7;
            // 
            // labelFormatVers
            // 
            labelFormatVers.AutoSize = true;
            labelFormatVers.Location = new Point(6, 95);
            labelFormatVers.Name = "labelFormatVers";
            labelFormatVers.Size = new Size(65, 20);
            labelFormatVers.TabIndex = 6;
            labelFormatVers.Text = "Versione";
            // 
            // labelFormatProvider
            // 
            labelFormatProvider.AutoSize = true;
            labelFormatProvider.Location = new Point(489, 23);
            labelFormatProvider.Name = "labelFormatProvider";
            labelFormatProvider.Size = new Size(64, 20);
            labelFormatProvider.TabIndex = 5;
            labelFormatProvider.Text = "Provider";
            // 
            // textBoxFormatProvider
            // 
            textBoxFormatProvider.Enabled = false;
            textBoxFormatProvider.Location = new Point(489, 46);
            textBoxFormatProvider.Name = "textBoxFormatProvider";
            textBoxFormatProvider.Size = new Size(222, 27);
            textBoxFormatProvider.TabIndex = 4;
            // 
            // textBoxFormatDescr
            // 
            textBoxFormatDescr.Enabled = false;
            textBoxFormatDescr.Location = new Point(211, 46);
            textBoxFormatDescr.Name = "textBoxFormatDescr";
            textBoxFormatDescr.Size = new Size(272, 27);
            textBoxFormatDescr.TabIndex = 3;
            // 
            // labelFormatDescr
            // 
            labelFormatDescr.AutoSize = true;
            labelFormatDescr.Location = new Point(211, 23);
            labelFormatDescr.Name = "labelFormatDescr";
            labelFormatDescr.Size = new Size(86, 20);
            labelFormatDescr.TabIndex = 2;
            labelFormatDescr.Text = "Descrizione";
            // 
            // textBoxFormatName
            // 
            textBoxFormatName.Enabled = false;
            textBoxFormatName.Location = new Point(6, 46);
            textBoxFormatName.Name = "textBoxFormatName";
            textBoxFormatName.Size = new Size(199, 27);
            textBoxFormatName.TabIndex = 1;
            // 
            // labelFormatName
            // 
            labelFormatName.AutoSize = true;
            labelFormatName.Location = new Point(6, 23);
            labelFormatName.Name = "labelFormatName";
            labelFormatName.Size = new Size(50, 20);
            labelFormatName.TabIndex = 0;
            labelFormatName.Text = "Nome";
            // 
            // tabControlFormat
            // 
            tabControlFormat.Controls.Add(tabPageFormatFindRef);
            tabControlFormat.Controls.Add(tabPageFormatRebase);
            tabControlFormat.Location = new Point(6, 204);
            tabControlFormat.Name = "tabControlFormat";
            tabControlFormat.SelectedIndex = 0;
            tabControlFormat.Size = new Size(725, 376);
            tabControlFormat.TabIndex = 4;
            // 
            // tabPageFormatFindRef
            // 
            tabPageFormatFindRef.Controls.Add(treeViewFormatFindRefMap);
            tabPageFormatFindRef.Controls.Add(treeViewFormatFindRef);
            tabPageFormatFindRef.Controls.Add(buttonFormatFindRef);
            tabPageFormatFindRef.Controls.Add(textBoxFormatFindRef);
            tabPageFormatFindRef.Controls.Add(labelFormatFindRef);
            tabPageFormatFindRef.Location = new Point(4, 29);
            tabPageFormatFindRef.Name = "tabPageFormatFindRef";
            tabPageFormatFindRef.Padding = new Padding(3);
            tabPageFormatFindRef.Size = new Size(717, 343);
            tabPageFormatFindRef.TabIndex = 0;
            tabPageFormatFindRef.Text = "Trova riferimenti";
            tabPageFormatFindRef.UseVisualStyleBackColor = true;
            // 
            // treeViewFormatFindRefMap
            // 
            treeViewFormatFindRefMap.Location = new Point(355, 59);
            treeViewFormatFindRefMap.Name = "treeViewFormatFindRefMap";
            treeViewFormatFindRefMap.Size = new Size(356, 278);
            treeViewFormatFindRefMap.TabIndex = 5;
            // 
            // treeViewFormatFindRef
            // 
            treeViewFormatFindRef.Location = new Point(6, 59);
            treeViewFormatFindRef.Name = "treeViewFormatFindRef";
            treeViewFormatFindRef.Size = new Size(343, 278);
            treeViewFormatFindRef.TabIndex = 4;
            // 
            // buttonFormatFindRef
            // 
            buttonFormatFindRef.Location = new Point(617, 25);
            buttonFormatFindRef.Name = "buttonFormatFindRef";
            buttonFormatFindRef.Size = new Size(94, 29);
            buttonFormatFindRef.TabIndex = 3;
            buttonFormatFindRef.Text = "Ricerca";
            buttonFormatFindRef.UseVisualStyleBackColor = true;
            // 
            // textBoxFormatFindRef
            // 
            textBoxFormatFindRef.Location = new Point(6, 26);
            textBoxFormatFindRef.Name = "textBoxFormatFindRef";
            textBoxFormatFindRef.Size = new Size(605, 27);
            textBoxFormatFindRef.TabIndex = 2;
            // 
            // labelFormatFindRef
            // 
            labelFormatFindRef.AutoSize = true;
            labelFormatFindRef.Location = new Point(6, 3);
            labelFormatFindRef.Name = "labelFormatFindRef";
            labelFormatFindRef.Size = new Size(310, 20);
            labelFormatFindRef.TabIndex = 1;
            labelFormatFindRef.Text = "Inserire una stringa per ricercarne i riferimenti";
            // 
            // tabPageFormatRebase
            // 
            tabPageFormatRebase.Controls.Add(buttonFormatRebase);
            tabPageFormatRebase.Controls.Add(labelFormatRebase);
            tabPageFormatRebase.Location = new Point(4, 29);
            tabPageFormatRebase.Name = "tabPageFormatRebase";
            tabPageFormatRebase.Padding = new Padding(3);
            tabPageFormatRebase.Size = new Size(717, 343);
            tabPageFormatRebase.TabIndex = 1;
            tabPageFormatRebase.Text = "Rebase";
            tabPageFormatRebase.UseVisualStyleBackColor = true;
            // 
            // buttonFormatRebase
            // 
            buttonFormatRebase.Location = new Point(241, 171);
            buttonFormatRebase.Name = "buttonFormatRebase";
            buttonFormatRebase.Size = new Size(242, 58);
            buttonFormatRebase.TabIndex = 7;
            buttonFormatRebase.Text = "Rimuovi attributi XML";
            buttonFormatRebase.UseVisualStyleBackColor = true;
            buttonFormatRebase.Click += buttonFormatRebase_Click;
            // 
            // labelFormatRebase
            // 
            labelFormatRebase.Location = new Point(6, 3);
            labelFormatRebase.Name = "labelFormatRebase";
            labelFormatRebase.Size = new Size(705, 165);
            labelFormatRebase.TabIndex = 2;
            labelFormatRebase.Text = resources.GetString("labelFormatRebase.Text");
            // 
            // buttonFormatUpload
            // 
            buttonFormatUpload.Location = new Point(649, 28);
            buttonFormatUpload.Name = "buttonFormatUpload";
            buttonFormatUpload.Size = new Size(94, 27);
            buttonFormatUpload.TabIndex = 6;
            buttonFormatUpload.Text = "Importa";
            buttonFormatUpload.UseVisualStyleBackColor = true;
            buttonFormatUpload.Click += buttonFormatUpload_Click;
            // 
            // textBoxFormat
            // 
            textBoxFormat.Location = new Point(106, 27);
            textBoxFormat.Name = "textBoxFormat";
            textBoxFormat.Size = new Size(537, 27);
            textBoxFormat.TabIndex = 5;
            // 
            // buttonFormatBrowse
            // 
            buttonFormatBrowse.Location = new Point(6, 26);
            buttonFormatBrowse.Name = "buttonFormatBrowse";
            buttonFormatBrowse.Size = new Size(94, 29);
            buttonFormatBrowse.TabIndex = 4;
            buttonFormatBrowse.Text = "Cerca";
            buttonFormatBrowse.UseVisualStyleBackColor = true;
            buttonFormatBrowse.Click += buttonFormatBrowse_Click;
            // 
            // labelFormat
            // 
            labelFormat.AutoSize = true;
            labelFormat.Location = new Point(6, 3);
            labelFormat.Name = "labelFormat";
            labelFormat.Size = new Size(430, 20);
            labelFormat.TabIndex = 2;
            labelFormat.Text = "Selezionare il file .xml di un file relativo ad un Format di un GER";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 796);
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
            tabPageMapping.ResumeLayout(false);
            tabPageMapping.PerformLayout();
            groupBoxMap.ResumeLayout(false);
            groupBoxMapInfo.ResumeLayout(false);
            groupBoxMapInfo.PerformLayout();
            tabControlMap.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPageFormat.ResumeLayout(false);
            tabPageFormat.PerformLayout();
            groupBoxFormat.ResumeLayout(false);
            groupBoxFormatInfo.ResumeLayout(false);
            groupBoxFormatInfo.PerformLayout();
            tabControlFormat.ResumeLayout(false);
            tabPageFormatFindRef.ResumeLayout(false);
            tabPageFormatFindRef.PerformLayout();
            tabPageFormatRebase.ResumeLayout(false);
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
        private Label labelMap;
        private TextBox textBoxMapFile;
        private Button buttonMapBrowse;
        private Button buttonMapUpload;
        private GroupBox groupBoxMap;
        private GroupBox groupBoxMapInfo;
        private TextBox textBoxMapVers;
        private Label labelMapPublicVers;
        private Label labelMapProvider;
        private TextBox textBoxMapProvider;
        private TextBox textBoxMapDescr;
        private Label labelMapDescr;
        private TextBox textBoxMapName;
        private Label labelMapName;
        private TabControl tabControlMap;
        private TabPage tabPage1;
        private TreeView treeViewMapFindRefDatasource;
        private Button buttonMapFinndRef;
        private TextBox textBoxMapFindRef;
        private Label labelMapFindRef;
        private Button buttonFormatBrowse;
        private Label labelFormat;
        private TextBox textBoxFormat;
        private GroupBox groupBoxFormat;
        private GroupBox groupBoxFormatInfo;
        private TextBox textBoxFormatVers;
        private Label labelFormatVers;
        private Label labelFormatProvider;
        private TextBox textBoxFormatProvider;
        private TextBox textBoxFormatDescr;
        private Label labelFormatDescr;
        private TextBox textBoxFormatName;
        private Label labelFormatName;
        private TabControl tabControlFormat;
        private TabPage tabPageFormatFindRef;
        private TreeView treeViewFormatFindRef;
        private Button buttonFormatFindRef;
        private TextBox textBoxFormatFindRef;
        private Label labelFormatFindRef;
        private TabPage tabPageFormatRebase;
        private Label labelFormatRebase;
        private Label labelMapVersion;
        private ComboBox comboBoxMapVers;
        private TreeView treeViewMapFindRefBinding;
        private TreeView treeViewFormatFindRefMap;
        private Button buttonFormatRebase;
        private Button buttonFormatUpload;
        private TextBox textBoxMapModelMapping;
        private Label labelMapModelMapping;
        private Button buttonModelFindRefReset;
        private Button buttonModelFindRefCollapse;
        private Button buttonModelFindRefExpand;
    }
}